using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutogenerateFixpack
{
    class ReleaseNotesUtils
    {
        static Microsoft.Office.Interop.Word.Application wordApp;

        private static void ReplaceWithStringValue(Document admReleaseNotes, string findWhat, string ReplaceWith)
        {
            object missing = System.Reflection.Missing.Value;

            Range range = admReleaseNotes.Content;
            Find find = range.Find;
            find.Text = findWhat;
            find.ClearFormatting();
            find.Replacement.ClearFormatting();
            find.Replacement.Text = ReplaceWith;

            object replaceAll = WdReplace.wdReplaceAll;

            find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                ref missing, ref missing, ref missing, ref missing, ref missing,
                ref replaceAll, ref missing, ref missing, ref missing, ref missing);
        }

        private static void SetFixpackName(Document admReleaseNotes, DirectoryInfo fixpackDir)
        {
            ReplaceWithStringValue(admReleaseNotes, "FIXPACK_NAME", fixpackDir.Name);
        }

        private static void SetDate(Document admReleaseNotes, DirectoryInfo fixpackDir)
        {
            ReplaceWithStringValue(admReleaseNotes, "CREATE_DATE", DateTime.Now.ToString("dd.MM.yyyy"));
        }

        private static void SetPrerequisites(Document admReleaseNotes, Document devReleaseNotes, bool isLast)
        {
            var prereqCell = devReleaseNotes.Tables[1].Cell(6, 1);
            ReplaceWithStringValue(admReleaseNotes, "PREREQUISITE",
                prereqCell.Range.Text + (isLast ? "" : Environment.NewLine + "PREREQUISITE"));
        }

        public static void GenerateReleaseNotes(DirectoryInfo fixpackDir)
        {
            if (wordApp == null)
                wordApp = new Microsoft.Office.Interop.Word.Application();

            FileInfo releaseNotesFile = new FileInfo(Path.Combine(fixpackDir.FullName, "release_notes.docx"));
            FileInfo releaseNotesFileSEED = new FileInfo(Path.Combine(fixpackDir.FullName, "Release_Notes_SEED.docx"));

            DialogResult result = DialogResult.None;

            if (File.Exists(releaseNotesFile.FullName))
            {
                result = MessageBox.Show("Файл release_notes.docx существует. Пересоздать?", "Предупреждение", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation);

                if (result == DialogResult.Yes)
                {
                    File.SetAttributes(releaseNotesFile.FullName, FileAttributes.Normal);
                    releaseNotesFile.Delete();
                    releaseNotesFileSEED.CopyTo(releaseNotesFile.FullName);
                }
            }

            if(result != DialogResult.Cancel)
            {
                Document admReleaseNotes = wordApp.Documents.Open(releaseNotesFile.FullName, System.Type.Missing, true);

                foreach (DirectoryInfo subDir in fixpackDir.EnumerateDirectories("*", SearchOption.TopDirectoryOnly))
                {
                    Document devReleaseNotes = wordApp.Documents.Open(Path.Combine(subDir.FullName, "release_notes.docx"), System.Type.Missing, true);
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


                    //adm_release_notes.Content.Paste();
                    SetPrerequisites(admReleaseNotes, devReleaseNotes, true);
                    admReleaseNotes.Save();
                }
            }

        }
    }
}
