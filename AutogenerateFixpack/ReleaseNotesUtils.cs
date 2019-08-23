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

        /*
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
        */

        private static void SetFixpackName(Document admReleaseNotes, DirectoryInfo fixpackDir)
        {
            object objBookmark = "FIXPACK_NAME";
            admReleaseNotes.Bookmarks.get_Item(ref objBookmark).Range.Text = fixpackDir.Name;
        }

        private static void SetDate(Document admReleaseNotes)
        {
            object objBookmark = "CREATE_DATE";
            admReleaseNotes.Bookmarks.get_Item(ref objBookmark).Range.Text = DateTime.Now.ToString("dd.MM.yyyy");
        }        

        private static void SetPrerequisites(Document admReleaseNotes, Document devReleaseNotes)
        {
            var prereqCell = devReleaseNotes.Tables[1].Cell(6, 1);
            string prereqText = prereqCell.Range.Text.Trim(new char[] { '\n', '\r', '\t' });
            if (!String.IsNullOrWhiteSpace(prereqText))
            {
                object objBookmark = "PREREQUISITES";
                admReleaseNotes.Bookmarks.get_Item(ref objBookmark).Range.Text += prereqCell.Range.Text;                
            }
        }

        private static void CreateTable(Document admReleaseNotes, Range rangeWhere, WdColor color, string before, Range rangeToCopy)
        {
            rangeWhere.Text = before;
            var table = admReleaseNotes.Tables.Add(rangeWhere, 2, 1);

            table.Cell(1, 1).Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleSingle;
            table.Cell(1, 1).Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;
            table.Cell(1, 1).Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleSingle;
            table.Cell(1, 1).Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleSingle;

            table.Cell(2, 1).Borders[WdBorderType.wdBorderTop].LineStyle = WdLineStyle.wdLineStyleSingle;
            table.Cell(2, 1).Borders[WdBorderType.wdBorderBottom].LineStyle = WdLineStyle.wdLineStyleSingle;
            table.Cell(2, 1).Borders[WdBorderType.wdBorderLeft].LineStyle = WdLineStyle.wdLineStyleSingle;
            table.Cell(2, 1).Borders[WdBorderType.wdBorderRight].LineStyle = WdLineStyle.wdLineStyleSingle;

            table.Shading.BackgroundPatternColor = color;
            table.Cell(1, 1).Range.Text = before;

            if(rangeToCopy != null)
            {
                rangeToCopy.Copy();
                table.Cell(2, 1).Range.Paste();
            }
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
                Document admReleaseNotes = wordApp.Documents.Open(releaseNotesFile.FullName, System.Type.Missing, false);

                SetFixpackName(admReleaseNotes, fixpackDir);
                SetDate(admReleaseNotes);

                object objBookmark = "BEFORE_INSTRUCTIONS";
                foreach (DirectoryInfo subDir in fixpackDir.EnumerateDirectories("*", SearchOption.TopDirectoryOnly))
                {
                    Document devReleaseNotes = wordApp.Documents.Open(Path.Combine(subDir.FullName, "release_notes.docx"), System.Type.Missing, true);
                    
                    CreateTable(admReleaseNotes, admReleaseNotes.Bookmarks.get_Item(ref objBookmark).Range, WdColor.wdColorAqua, "Датафикс №", devReleaseNotes.Tables[1].Cell(10, 1).Range);
                    SetPrerequisites(admReleaseNotes, devReleaseNotes);
                }
                admReleaseNotes.Save();
            }

        }
    }
}
