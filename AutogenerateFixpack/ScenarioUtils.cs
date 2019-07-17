using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutogenerateFixpack
{
    enum ScenarioLineStatus { Normal, NotInFiles, NotInScenario }

    class ScenarioLine
    {
        public string Line { get; private set; }
        public ScenarioLineStatus status;
        public DirectoryInfo dir;

        public ScenarioLine(string line, ScenarioLineStatus status, DirectoryInfo dir)
        {
            Line = line;
            this.status = status;
            this.dir = dir;
        }
    }

    class ScenarioUtils
    {
        public static void CreateMainScenario(DirectoryInfo fixpackDirectory)
        {
            Dictionary<string, string> patchScenarioPairs = new Dictionary<string, string>();
            List<string> scenarioNotFound = new List<string>();

            foreach (DirectoryInfo patchDirectory in fixpackDirectory.EnumerateDirectories("*", SearchOption.TopDirectoryOnly))
            {
                var fileScs = patchDirectory.GetFiles("file_sc.txt", SearchOption.TopDirectoryOnly);
                if (fileScs.Length == 0)
                {
                    scenarioNotFound.Add(patchDirectory.Name);
                }
                else
                {
                    using (var reader = fileScs[0].OpenText())
                    {
                        string currScenario = reader.ReadToEnd();
                        string[] currScenarioLines = currScenario.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);


                    }
                }
            }
        }

        Regex ORAPathFromScenarioLine  = new Regex(@"ORA\|\|(.*)\|\|(.*)");
        Regex IPCPathFromScenarioLine = new Regex(@"IPC\|\|(.*)");
        Regex STWFPathFromScenarioLine = new Regex(@"IPC\|\|(.*)");

        public List<ScenarioLine> CreateNewScenarioLines(DirectoryInfo fixpackDir, List<ScenarioLine> oldScenarioLines)
        {
            List<ScenarioLine> newScenarioLines = new List<ScenarioLine>();
            foreach(ScenarioLine oldScenarioLine in oldScenarioLines)
            {
                MatchCollection ORAMatches = ORAPathFromScenarioLine.Matches(oldScenarioLine.Line);
                if(ORAMatches.Count == 0)
                {
                    MatchCollection IPCMatches = IPCPathFromScenarioLine.Matches(oldScenarioLine.Line);
                    if(IPCMatches.Count == 0)
                    {
                        MatchCollection STWFMatches = STWFPathFromScenarioLine.Matches(oldScenarioLine.Line);
                        if(STWFMatches.Count == 0)
                        {
                            newScenarioLines.Add(new ScenarioLine(oldScenarioLine.Line, ScenarioLineStatus.Normal, oldScenarioLine.dir));
                        }
                        else
                        {
                            int insertIndex = STWFMatches[0].Groups[0].Index;
                            ScenarioLine newScenarioLine = 
                                new ScenarioLine(
                                $"{oldScenarioLine.Line.Substring(0, insertIndex)}{oldScenarioLine.dir.Name}{oldScenarioLine.Line.Substring(insertIndex)}",
                                ScenarioLineStatus.Normal,
                                oldScenarioLine.dir);
                            newScenarioLines.Add(newScenarioLine);
                        }
                    }
                }
                else
                {
                    ;
                }
            }
            return newScenarioLines;
        }
    }
}
