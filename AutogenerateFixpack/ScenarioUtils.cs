using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutogenerateFixpack
{
    class ScenarioUtils
    {
        private static bool CreateScenarioLineByFromFPDirPath(string path, out string scenarioLine)
        {
            if (path.IndexOf(".sql", StringComparison.InvariantCultureIgnoreCase) > -1)
            {
                scenarioLine = $"ORA||{path}||{ORASchemaFromScenarioLine.Match(path).Groups[1].Value}";
                return true;
            }
            if (path.IndexOf(".xml", StringComparison.InvariantCultureIgnoreCase) > -1)
            {
                scenarioLine = $"IPC||{path}";
                return true;
            }
            if (path.IndexOf(".txt", StringComparison.InvariantCultureIgnoreCase) > -1)
            {
                scenarioLine = $"STWF||{path}";
                return true;
            }
            scenarioLine = null;
            return false;
        }

        public static void CheckFilesAndPatchScenario(DirectoryInfo fixpackDirectory, List<DirectoryInfo> selectedPatches, out List<string> scenarioNotFound, out List<string> filesNotFound, out List<string> linesNotFound)
        {
            scenarioNotFound = new List<string>();
            filesNotFound = new List<string>();
            linesNotFound = new List<string>();

            foreach (DirectoryInfo patchDirectory in fixpackDirectory.EnumerateDirectories("*", SearchOption.TopDirectoryOnly))
            {
                if (selectedPatches.Where(x => x.FullName.Equals(patchDirectory.FullName, StringComparison.InvariantCultureIgnoreCase)).Count() > 0)
                {

                    List<string> scenarioFilePathes = new List<string>();

                    var fileScs = patchDirectory.GetFiles("file_sc.txt", SearchOption.TopDirectoryOnly);
                    if (fileScs.Length == 0)
                    {
                        scenarioNotFound.Add(patchDirectory.FullName);
                    }
                    else
                    {
                        using (var reader = fileScs[0].OpenText())
                        {
                            string currScenario = reader.ReadToEnd();
                            string[] currScenarioLines = currScenario.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

                            foreach (string oldScenarioLine in currScenarioLines)
                            {
                                MatchCollection ORAMatches = ORAPathFromScenarioLine.Matches(oldScenarioLine);
                                MatchCollection IPCMatches = IPCPathFromScenarioLine.Matches(oldScenarioLine);
                                MatchCollection STWFMatches = STWFPathFromScenarioLine.Matches(oldScenarioLine);

                                MatchCollection mainMatchCollection =
                                    ORAMatches.Count > 0 ? ORAMatches :
                                    IPCMatches.Count > 0 ? IPCMatches :
                                    STWFMatches.Count > 0 ? STWFMatches : null;

                                if (mainMatchCollection != null)
                                {
                                    string fullPath = Path.Combine(patchDirectory.FullName, mainMatchCollection[0].Groups[1].Value);
                                    scenarioFilePathes.Add(fullPath.Trim());
                                    if (!File.Exists(fullPath))
                                    {
                                        int insertIndex = mainMatchCollection[0].Groups[1].Index;
                                        filesNotFound.Add(FPScenarioLineByPatchScenarioLine(oldScenarioLine, patchDirectory, insertIndex));
                                    }
                                }
                            }
                        }
                    }

                    foreach (FileInfo fileInfo in patchDirectory.EnumerateFiles("*.*", SearchOption.AllDirectories))
                    {
                        if (scenarioFilePathes.Where(x => x.Equals(fileInfo.FullName, StringComparison.InvariantCultureIgnoreCase)).Count() == 0)
                        {
                            if (!WrongFiles.IsMatch(fileInfo.FullName))
                            {
                                string fromFPDirPath = fileInfo.FullName.Substring(fixpackDirectory.FullName.Length + 1);
                                if (CreateScenarioLineByFromFPDirPath(fromFPDirPath, out string scenarioLine))
                                {
                                    linesNotFound.Add(scenarioLine);
                                }
                                else
                                {
                                    linesNotFound.Add(fromFPDirPath);
                                }
                            }
                        }
                    }
                }
            }
        }

        //компаратор нужен для того, чтобы в сортированный список можно было добавлять пары с одинаковыми ключами
        public class DuplicateKeyComparer<TKey> : IComparer<TKey> where TKey : IComparable
        {
            public int Compare(TKey x, TKey y)
            {
                int result = x.CompareTo(y);

                if (result == 0)
                    return -1;   // обрабатываем равенство как "меньше", будет вставлять как в патче
                else
                    return result;
            }
        }

        public static int Priority(string line)
        {
            int priority = 0;

            //скрипты
            if (line.IndexOf("||DB_SCRIPT", StringComparison.InvariantCultureIgnoreCase) != -1)
            {
                priority += 1000;

                //порядок в скриптах
                if (line.IndexOf("\\SEQUENCE", StringComparison.InvariantCultureIgnoreCase) != -1)
                    priority += 5;
                else if (line.IndexOf("\\TABLE", StringComparison.InvariantCultureIgnoreCase) != -1)
                    priority += 10;
                else if (line.IndexOf("\\INDEX", StringComparison.InvariantCultureIgnoreCase) != -1)
                    priority += 15;
                else if (line.IndexOf("\\VIEW", StringComparison.InvariantCultureIgnoreCase) != -1)
                    priority += 20;
                else if (line.IndexOf("\\FUNCTION", StringComparison.InvariantCultureIgnoreCase) != -1)
                    priority += 25;
                else if (line.IndexOf("\\PROCEDURE", StringComparison.InvariantCultureIgnoreCase) != -1)
                    priority += 30;
                else if (line.IndexOf("\\PACKAGE", StringComparison.InvariantCultureIgnoreCase) != -1)
                    priority += 35;
                else if (line.IndexOf("\\SCRIPT", StringComparison.InvariantCultureIgnoreCase) != -1)
                    priority += 40;

                //DBATOOLS в конец скриптов
                if (line.IndexOf("\\DBATOOLS", StringComparison.InvariantCultureIgnoreCase) != -1)
                {
                    priority += 100;
                }
            }

            //информатика
            else if (line.IndexOf("||INFA_XML", StringComparison.InvariantCultureIgnoreCase) != -1)
            {
                priority += 2000;

                //сначала shared
                if (line.IndexOf("\\SHARED", StringComparison.InvariantCultureIgnoreCase) != -1)
                    priority += 100;
                else priority += 200;

                //порядок в информатике 
                if (line.IndexOf("\\SOURCE", StringComparison.InvariantCultureIgnoreCase) != -1)
                    priority += 5;
                else if (line.IndexOf("\\TARGET", StringComparison.InvariantCultureIgnoreCase) != -1)
                    priority += 10;
                else if (line.IndexOf("\\USER-DEFINED FUNCTION", StringComparison.InvariantCultureIgnoreCase) != -1)
                    priority += 15;
                else if (line.IndexOf("\\EXP_", StringComparison.InvariantCultureIgnoreCase) != -1)
                    priority += 20;
                else if (line.IndexOf("\\SEQ_", StringComparison.InvariantCultureIgnoreCase) != -1)
                    priority += 25;
                else if (line.IndexOf("\\LKP_", StringComparison.InvariantCultureIgnoreCase) != -1)
                    priority += 30;
                else if (line.IndexOf("\\MPL_", StringComparison.InvariantCultureIgnoreCase) != -1)
                    priority += 35;
                else if (line.IndexOf("\\M_", StringComparison.InvariantCultureIgnoreCase) != -1)
                    priority += 40;
                else if (line.IndexOf("\\CMD_", StringComparison.InvariantCultureIgnoreCase) != -1)
                    priority += 45;
                else if (line.IndexOf("\\S_", StringComparison.InvariantCultureIgnoreCase) != -1)
                    priority += 50;
                else if (line.IndexOf("\\WKLT_", StringComparison.InvariantCultureIgnoreCase) != -1)
                    priority += 55;
                else if (line.IndexOf("\\WF_", StringComparison.InvariantCultureIgnoreCase) != -1)
                    priority += 60;
            }

            //старты потоков
            else if (line.IndexOf("||START_WF") != -1)
            {
                priority += 3000;
            }

            return priority;
        }

        public static bool CreateFPScenarioByFiles(DirectoryInfo fixpackDirectory, List<DirectoryInfo> selectedPatches)
        {
            List<string> newScenarioLines = new List<string>();
            foreach (DirectoryInfo patchDirectory in fixpackDirectory.EnumerateDirectories("*", SearchOption.TopDirectoryOnly))
            {
                if (selectedPatches.Where(x => x.FullName.Equals(patchDirectory.FullName, StringComparison.InvariantCultureIgnoreCase)).Count() > 0)
                {
                    SortedList<int, string> priorityLinePair = new SortedList<int, string>(new DuplicateKeyComparer<int>());

                    foreach (FileInfo fileInfo in patchDirectory.EnumerateFiles("*.*", SearchOption.AllDirectories))
                    {
                        string fromFPPath = fileInfo.FullName.Substring(fixpackDirectory.FullName.Length + 1);
                        if (!WrongFiles.IsMatch(fromFPPath))
                        {
                            if (CreateScenarioLineByFromFPDirPath(fromFPPath, out string scenarioLine))
                            {
                                priorityLinePair.Add(Priority(scenarioLine), scenarioLine);
                            }
                        }
                    }

                    newScenarioLines.AddRange(priorityLinePair.Values);
                }
            }

            SaveFileSc(fixpackDirectory, newScenarioLines);

            return true;
        }

        public static bool CreateFPScenarioByPatchesScenario(DirectoryInfo fixpackDirectory, List<DirectoryInfo> selectedPatches)
        {
            CheckFilesAndPatchScenario(fixpackDirectory, selectedPatches, out List<string> scenarioNotFound, out List<string> filesNotFound, out List<string> linesNotFound);

            if(scenarioNotFound.Count > 0 || filesNotFound.Count > 0 || linesNotFound.Count > 0)
            {
                CheckForm cf = new CheckForm(
                    string.Join(Environment.NewLine, scenarioNotFound),
                    string.Join(Environment.NewLine, filesNotFound),
                    string.Join(Environment.NewLine, linesNotFound));

                DialogResult dr = cf.ShowDialog();

                if (dr == DialogResult.Abort || dr == DialogResult.Cancel)
                {
                    return false;
                }
            }

            List<string> newScenarioLines = new List<string>();

            foreach (DirectoryInfo patchDirectory in fixpackDirectory.EnumerateDirectories("*", SearchOption.TopDirectoryOnly))
            {
                if (selectedPatches.Where(x => x.FullName.Equals(patchDirectory.FullName, StringComparison.InvariantCultureIgnoreCase)).Count() > 0)
                {
                    var fileScs = patchDirectory.GetFiles("file_sc.txt", SearchOption.TopDirectoryOnly);
                    if (fileScs.Length != 0)
                    {
                        using (var reader = fileScs[0].OpenText())
                        {
                            string currScenario = reader.ReadToEnd();
                            string[] currScenarioLines = currScenario.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                            List<string> listScenarioLines = currScenarioLines.ToList();
                            DefaultScenarioOrderValidation(listScenarioLines);
                            newScenarioLines.AddRange(CreateNewScenarioLines(fixpackDirectory, patchDirectory, listScenarioLines));
                        }
                    }
                }
            }
            
            SaveFileSc(fixpackDirectory, newScenarioLines);
            return true;
        }

        public static void SaveFileSc(DirectoryInfo fixpackDir, IEnumerable<string> text)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "txt";
            sfd.Filter = "Текстовый файл|*.txt";
            sfd.FileName = "file_sc";
            sfd.InitialDirectory = fixpackDir.FullName;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.Delete(sfd.FileName);
                using (File.Create(sfd.FileName)) { }
                using (StreamWriter tw = new StreamWriter(sfd.FileName, false, Encoding.GetEncoding("Windows-1251")))
                {
                    tw.WriteLine(fixpackDir.Name);
                    tw.WriteLine(fixpackDir.Name);
                    foreach (var line in text)
                    {
                        if (text != null)
                            tw.WriteLine(line);
                    }
                }
            }
        }

        static Regex ORAPathFromScenarioLine  = new Regex(@"ORA\|\|(.*)\|\|(.*)", RegexOptions.IgnoreCase);
        static Regex IPCPathFromScenarioLine = new Regex(@"IPC\|\|(.*)", RegexOptions.IgnoreCase);
        static Regex STWFPathFromScenarioLine = new Regex(@"STWF\|\|(.*)", RegexOptions.IgnoreCase);
        static Regex WrongFiles = new Regex(@"file_sc\.|RELEASE_NOTES\.|VSSVER2\.|\.xls|IVSS\.tmp", RegexOptions.IgnoreCase);

        static Regex ORASchemaFromScenarioLine = new Regex(@"([^\\]+)@");

        private static string FPScenarioLineByPatchScenarioLine(string patchScenarioLine, DirectoryInfo patchDir, int pathIndex)
        {
            string FPScenarioLine = $"{patchScenarioLine.Substring(0, pathIndex)}{patchDir.Name}\\{patchScenarioLine.Substring(pathIndex)}";

            return FPScenarioLine;
        }

        public static List<string> CreateNewScenarioLines(DirectoryInfo fixpackDir, DirectoryInfo patchDir, List<string> oldScenarioLines)
        {
            List<string> newScenarioLines = new List<string>();
            for (int i = 2; i < oldScenarioLines.Count; ++i)
            {
                MatchCollection ORAMatches = ORAPathFromScenarioLine.Matches(oldScenarioLines[i]);
                MatchCollection IPCMatches = IPCPathFromScenarioLine.Matches(oldScenarioLines[i]);
                MatchCollection STWFMatches = STWFPathFromScenarioLine.Matches(oldScenarioLines[i]);

                MatchCollection mainMatchCollection =
                    ORAMatches.Count  > 0 ? ORAMatches :
                    IPCMatches.Count  > 0 ? IPCMatches :
                    STWFMatches.Count > 0 ? STWFMatches : null;

                if (mainMatchCollection != null)
                {
                    int insertIndex = mainMatchCollection[0].Groups[1].Index;
                    string fpScenarioLine = FPScenarioLineByPatchScenarioLine(oldScenarioLines[i], patchDir, insertIndex);
                    newScenarioLines.Add(fpScenarioLine);
                }
            }
            return newScenarioLines;
        }

        private static void DefaultScenarioOrderValidation(List<string> scenario)
        {
            int firstDWHLine = -1;
            int lastDWHLine = -1;
            int firstDBATOOLSLine = -1;
            int lastDBATOOLSLine = -1;

            for (int i = 0; i < scenario.Count; ++i)
            {
                MatchCollection schemaMatches = ORASchemaFromScenarioLine.Matches(scenario[i]);
                if(schemaMatches.Count > 0)
                {
                    if(schemaMatches[0].Groups[1].Value.Equals("DWH", StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (firstDWHLine == -1)
                            firstDWHLine = i;
                        lastDWHLine = i;
                    }
                    if (schemaMatches[0].Groups[1].Value.Equals("DBATOOLS", StringComparison.InvariantCultureIgnoreCase))
                    {
                        if (firstDBATOOLSLine == -1)
                            firstDBATOOLSLine = i;
                        lastDBATOOLSLine = i;
                    }
                }
            }

            if (firstDWHLine != -1 && lastDWHLine != -1 && firstDBATOOLSLine != -1 && lastDBATOOLSLine != -1 && lastDBATOOLSLine < firstDWHLine)
            {
                //забираем все DWH
                var dwhScenarioLines = scenario.GetRange(firstDWHLine, lastDWHLine - firstDWHLine + 1);
                //удаляем все DWH
                scenario.RemoveRange(firstDWHLine, lastDWHLine - firstDWHLine + 1);
                //вставляю перед DBATOOLS
                scenario.InsertRange(firstDBATOOLSLine, dwhScenarioLines);
            }
        }
    }
}
