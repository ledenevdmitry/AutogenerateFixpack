using System;
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
        private static string CreateScenarioLineByFromFPDirPath(string path)
        {
            if (path.IndexOf(".sql", StringComparison.InvariantCultureIgnoreCase) > -1)
            {
                return $"ORA||{path}||{ORASchemaFromScenarioLine.Match(path).Groups[1].Value}";
            }
            if (path.IndexOf(".xml", StringComparison.InvariantCultureIgnoreCase) > -1)
            {
                return $"IPC||{path}";
            }
            if (path.IndexOf(".txt", StringComparison.InvariantCultureIgnoreCase) > -1)
            {
                return $"STWF||{path}";
            }
            throw new Exception($"Неизвестный тип для файла {path}. Невозможно создать строку сценария");
        }

        public static void CheckFilesAndPatchScenario(DirectoryInfo fixpackDirectory, out List<string> scenarioNotFound, out List<string> filesNotFound, out List<string> linesNotFound)
        {
            scenarioNotFound = new List<string>();
            filesNotFound = new List<string>();
            linesNotFound = new List<string>();

            foreach (DirectoryInfo patchDirectory in fixpackDirectory.EnumerateDirectories("*", SearchOption.TopDirectoryOnly))
            {
                HashSet<string> scenarioFilePathes = new HashSet<string>();

                var fileScs = patchDirectory.GetFiles("file_sc.txt", SearchOption.TopDirectoryOnly);
                if(fileScs.Length == 0)
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
                                scenarioFilePathes.Add(fullPath);
                                if(!File.Exists(fullPath))
                                {
                                    int insertIndex = mainMatchCollection[0].Groups[1].Index;
                                    filesNotFound.Add(FPScenarioLineByPatchScenarioLine(oldScenarioLine, patchDirectory, insertIndex));
                                }
                            }
                        }
                    }
                }

                foreach(FileInfo fileInfo in patchDirectory.EnumerateFiles("*.*", SearchOption.AllDirectories))
                {
                    if(!scenarioFilePathes.Contains(fileInfo.FullName))
                    {
                        if (!WrongFiles.IsMatch(fileInfo.FullName))
                        {
                            string fromFPDirPath = fileInfo.FullName.Substring(fixpackDirectory.FullName.Length + 1);
                            linesNotFound.Add(CreateScenarioLineByFromFPDirPath(fromFPDirPath));
                        }
                    }
                }
            }
        }

        public static void CreateFPScenarioByPatchesScenario(DirectoryInfo fixpackDirectory)
        {
            CheckFilesAndPatchScenario(fixpackDirectory, out List<string> scenarioNotFound, out List<string> filesNotFound, out List<string> linesNotFound);

            if(scenarioNotFound.Count > 0 || filesNotFound.Count > 0 || linesNotFound.Count > 0)
            {
                CheckForm cf = new CheckForm(
                    string.Join(Environment.NewLine, scenarioNotFound),
                    string.Join(Environment.NewLine, filesNotFound),
                    string.Join(Environment.NewLine, linesNotFound));

                if(cf.ShowDialog() == DialogResult.Abort)
                {
                    return;
                }
            }

            List<string> newScenarioLines = new List<string>();

            foreach (DirectoryInfo patchDirectory in fixpackDirectory.EnumerateDirectories("*", SearchOption.TopDirectoryOnly))
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
            
            SaveFileSc(fixpackDirectory, newScenarioLines);
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
                MessageBox.Show("Файл сценария создан", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        static Regex ORAPathFromScenarioLine  = new Regex(@"ORA\|\|(.*)\|\|(.*)", RegexOptions.IgnoreCase);
        static Regex IPCPathFromScenarioLine = new Regex(@"IPC\|\|(.*)", RegexOptions.IgnoreCase);
        static Regex STWFPathFromScenarioLine = new Regex(@"IPC\|\|(.*)", RegexOptions.IgnoreCase);
        static Regex WrongFiles = new Regex(@"file_sc\.|RELEASE_NOTES\.|VSSVER2\.|\.xls", RegexOptions.IgnoreCase);

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

            if (firstDWHLine != -1 && lastDWHLine != -1 && firstDBATOOLSLine != -1 && lastDBATOOLSLine != -1 && lastDBATOOLSLine > firstDWHLine)
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
