using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutogenerateFixpack
{
    class ReleaseNotesUtils
    {
        static Microsoft.Office.Interop.Word.Application wordApp;

        private static void SetFixpackName(Document adm_release_notes, DirectoryInfo fixpackDir)
        {
            object missing = System.Reflection.Missing.Value;

            Range range = adm_release_notes.Content;
            Find find = range.Find;
            find.Text = "FIXPACK_NAME";
            find.ClearFormatting();
            find.Replacement.ClearFormatting();
            find.Replacement.Text = fixpackDir.Name;

            object replaceAll = WdReplace.wdReplaceAll;

            find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref replaceAll, ref missing, ref missing, ref missing, ref missing);
        }

        public static void GenerateReleaseNotes(DirectoryInfo fixpackDir)
        {
            if(wordApp == null)
               wordApp = new Application();

            foreach(DirectoryInfo subDir in fixpackDir.EnumerateDirectories("*", SearchOption.TopDirectoryOnly))
            {
                Document dev_release_notes = wordApp.Documents.Open(Path.Combine(subDir.FullName, "release_notes.docx"), System.Type.Missing, true);
                /*
                //var cell1 = doc.Tables[0].Cell(0, 0);
                var table = dev_release_notes.Tables[1];
                var cell2 = table.Cell(2, 1);
                var cell3 = table.Cell(6, 1);
                var cell4 = table.Cell(8, 1);
                var cell5 = table.Cell(10, 1);
                var cell6 = table.Cell(12, 1);
                var cell7 = table.Cell(14, 2);
                var cell8 = table.Cell(15, 2);
                var cell9 = table.Cell(16, 2);

                cell2.Range.Copy();
                */

                Document adm_release_notes = wordApp.Documents.Open(Path.Combine(fixpackDir.FullName, "release_notes.docx"), System.Type.Missing, true);

                //adm_release_notes.Content.Paste();
                adm_release_notes.Save();
            }

        }
    }
}
