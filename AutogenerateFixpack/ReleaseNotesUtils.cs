﻿using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutogenerateFixpack
{
    class ReleaseNotesUtils
    {
        public static Microsoft.Office.Interop.Word.Application wordApp;

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

        private static void SetAdminName(Document admReleaseNotes)
        {
            object objBookmark = "ADMIN_NAME";

            using (PrincipalContext pc = new PrincipalContext(ContextType.Machine))
            {
                using (UserPrincipal up = UserPrincipal.Current)
                {                    
                    admReleaseNotes.Bookmarks.get_Item(ref objBookmark).Range.Text = up.DisplayName;
                }
            }
        }       

        private static void SetPrerequisites(Document admReleaseNotes, Document devReleaseNotes, out bool prereqAdded)
        {
            var prereqCell = devReleaseNotes.Tables[1].Cell(6, 1);
            string[] prereqText = prereqCell.Range.Text.Split(new[] { Environment.NewLine, "\r\a" }, StringSplitOptions.RemoveEmptyEntries);
            object objBookmark = "PREREQUISITES";

            Range range = admReleaseNotes.Bookmarks.get_Item(ref objBookmark).Range;

            prereqAdded = false;

            foreach (var prereqLine in prereqText)
            {
                if (!string.IsNullOrWhiteSpace(prereqLine))
                {
                    range.Text += prereqLine + Environment.NewLine;
                    prereqAdded = true;
                }
            }
        }    
        
        public static void SetBeforeInstruction(Document admReleaseNotes, Document devReleaseNotes, DirectoryInfo patchDir)
        {
            object objBookmark = "BEFORE_INSTRUCTIONS";
            CreateTable(admReleaseNotes, admReleaseNotes.Bookmarks.get_Item(ref objBookmark).Range, (WdColor)(226 + 0x100 * 239 + 0x10000 * 217), $"Датафикс №{patchDir.Name}", devReleaseNotes.Tables[1].Cell(10, 1).Range);
        }

        public static void SetUninstall(Document admReleaseNotes, Document devReleaseNotes, DirectoryInfo patchDir)
        {
            object objBookmark = "UNINSTALL";
            CreateTable(admReleaseNotes, admReleaseNotes.Bookmarks.get_Item(ref objBookmark).Range, (WdColor)(255 + 0x100 * 242 + 0x10000 * 204), $"Датафикс №{patchDir.Name}", devReleaseNotes.Tables[1].Cell(8, 1).Range);
        }

        public static void SetAfterInstruction(Document admReleaseNotes, Document devReleaseNotes, DirectoryInfo patchDir)
        {
            object objBookmark = "AFTER_INSTRUCTIONS";
            CreateTable(admReleaseNotes, admReleaseNotes.Bookmarks.get_Item(ref objBookmark).Range, (WdColor)(217 + 0x100 * 226 + 0x10000 * 243), $"Датафикс №{patchDir.Name}", devReleaseNotes.Tables[1].Cell(12, 1).Range);
        }

        private static void CreateTable(Document admReleaseNotes, Range rangeWhere, WdColor color, string before, Range rangeToCopy)
        {
            if (!string.IsNullOrEmpty(rangeToCopy.Text.Replace("\r", "").Replace("\n", "").Replace("\a", "")))
            {
                rangeWhere.InsertParagraphAfter();
                rangeWhere = admReleaseNotes.Range(rangeWhere.End, rangeWhere.End);
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

                if (rangeToCopy != null)
                {
                    rangeToCopy.Copy();
                    table.Cell(2, 1).Range.Paste();
                }
            }
        }

        public static void GenerateReleaseNotes(DirectoryInfo fixpackDir, List<DirectoryInfo> selectedPatches)
        {
            if (wordApp == null)
                wordApp = new Microsoft.Office.Interop.Word.Application();

            FileInfo releaseNotesFile = new FileInfo(Path.Combine(fixpackDir.FullName, "release_notes.docx"));
            FileInfo releaseNotesFileSEED = new FileInfo("Release_Notes_SEED.docx");

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
            else
            {
                releaseNotesFileSEED.CopyTo(releaseNotesFile.FullName);
            }

            if(result != DialogResult.Cancel)
            {
                Document admReleaseNotes = wordApp.Documents.Open(releaseNotesFile.FullName, System.Type.Missing, false);

                SetFixpackName(admReleaseNotes, fixpackDir);
                SetDate(admReleaseNotes);
                SetAdminName(admReleaseNotes);

                List<DirectoryInfo> backwardSortedDirList = fixpackDir.GetDirectories().ToList();
                backwardSortedDirList.Sort((x, y) => -x.Name.CompareTo(y.Name));

                bool prereqAdded = false;
                bool prereqAddedOnce = false;

                foreach (DirectoryInfo patchDirectory in backwardSortedDirList)
                {
                    if (selectedPatches.Where(x => x.FullName.Equals(patchDirectory.FullName, StringComparison.InvariantCultureIgnoreCase)).Count() > 0)
                    {
                        Document devReleaseNotes = wordApp.Documents.Open(Path.Combine(patchDirectory.FullName, "release_notes.docx"), System.Type.Missing, true);

                        SetPrerequisites(admReleaseNotes, devReleaseNotes, out prereqAdded);
                        prereqAddedOnce |= prereqAdded;

                        SetBeforeInstruction(admReleaseNotes, devReleaseNotes, patchDirectory);
                        SetAfterInstruction(admReleaseNotes, devReleaseNotes, patchDirectory);
                        SetUninstall(admReleaseNotes, devReleaseNotes, patchDirectory);

                        devReleaseNotes.Close();
                    }
                }

                object objBookmark = "PREREQUISITES";
                Range range = admReleaseNotes.Bookmarks.get_Item(ref objBookmark).Range;
                if (!prereqAddedOnce)
                {
                    range.Text = "-";
                }

                admReleaseNotes.Save();
                admReleaseNotes.Close();
            }

        }

    }
}
