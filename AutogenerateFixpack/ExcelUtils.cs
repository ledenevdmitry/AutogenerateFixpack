using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace AutogenerateFixpack
{
    class ExcelUtils
    {
        public static Microsoft.Office.Interop.Excel.Application excApp;

        static Regex CRegex = new Regex(@"(C\d+)\.");

        public static HashSet<string> headers = new HashSet<string>(new string[] { "Тема", "Автор", "QC ID", "CR (номер изменения)", "FSD и пункты FSD", "Entity", "Описание", "Связанные запросы", "Длительная установка" });

        public static void PrepareExcelFileFixpack(FileInfo excelFile, DirectoryInfo fixpackDir)
        {
            if (excApp == null)
                excApp = new Microsoft.Office.Interop.Excel.Application();

            excApp.DisplayAlerts = false;

            Microsoft.Office.Interop.Excel.Workbook workbook = excApp.Workbooks.Open(excelFile.FullName);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.Sheets[1];
            
            worksheet.Shapes.Item(1).Delete();

            worksheet.Rows[1].Delete();
            worksheet.Rows[1].Delete();
            worksheet.Rows[1].Delete();

            var range = worksheet.UsedRange;

            int n = range.Columns.Count;
            for (int j = 1; j <= n; ++j)
            {
                string header = ((Range)worksheet.Cells[1, j]).Value2;
                if (!headers.Contains(header))
                {
                    worksheet.Columns[j].Delete();
                    j--;
                    n--;
                }
                //проверка dwdict
                else if (header.Equals("Entity", StringComparison.InvariantCultureIgnoreCase))
                {
                    for(int i = 2; i <= range.Rows.Count - 1; ++i)
                    {
                        string entityRow = ((Range)worksheet.Cells[i, j]).Value2;
                        if (entityRow != null && entityRow.IndexOf("004") != -1)
                        {
                            MessageBox.Show("Требуется проверить пререквизиты DWDICT!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            break;
                        }
                    }
                }
            }

            int lastRowIndex = range.Rows.Count;
            worksheet.Rows[lastRowIndex].Delete();            

            string filename = Path.Combine(fixpackDir.Parent.FullName, CRegex.Match(fixpackDir.Name).Groups[1].Value) + ".xlsx";

            workbook.SaveAs(filename, XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlShared, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);

            FileInfo resExcelFile = new FileInfo(filename);

            workbook.Close();

            string newPath = Path.Combine(fixpackDir.FullName, resExcelFile.Name);
            if(File.Exists(newPath))
            {
                File.Delete(newPath);
            }

            resExcelFile.MoveTo(newPath);

        }

        public static string[,] JiraExcelFileToArray(FileInfo excelFile)
        {
            if (excApp == null)
                excApp = new Microsoft.Office.Interop.Excel.Application();

            excApp.DisplayAlerts = false;

            Microsoft.Office.Interop.Excel.Workbook workbook = excApp.Workbooks.Open(excelFile.FullName);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.Sheets[1];

            worksheet.Shapes.Item(1).Delete();

            worksheet.Rows[1].Delete();
            worksheet.Rows[1].Delete();
            worksheet.Rows[1].Delete();

            var range = worksheet.UsedRange;
            int m = range.Columns.Count;
            int n = range.Rows.Column - 1;

            string[,] res = new string[n, m];

            for (int i = 1; i <= n; ++i)
            {
                for (int j = 1; j <= m; ++j)
                {
                    res[i - 1, j - 1] = ((Range)worksheet.Cells[1, j]).Value2;
                }
            }

            workbook.Close();

            return res;
        }
    }
}
