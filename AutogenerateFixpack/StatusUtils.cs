using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutogenerateFixpack
{
    class StatusUtils
    {
        private static void InsertJiraTableIntoDB(string[,] jiraTable, Dictionary<string, string> jiraFieldToDBField)
        {
            int count = jiraFieldToDBField.Count;
            Dictionary<string, int> jiraFieldToJiraTableIndex = new Dictionary<string, int>();

            //находим соответствие полей в жире и номеров столбцов в таблице
            for(int i = 1; i < jiraTable.GetLength(0); ++i)
            {
                foreach(string jiraField in jiraFieldToDBField.Keys)
                {
                    if(jiraField.Equals(jiraTable[0, i], StringComparison.InvariantCultureIgnoreCase))
                    {
                        jiraFieldToJiraTableIndex.Add(jiraField, i);
                    }
                }
            }
        }
    }
}
