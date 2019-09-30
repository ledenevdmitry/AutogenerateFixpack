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

        public static void PrepareExcelFile(FileInfo excelFile, DirectoryInfo fixpackDir)
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
            for (int i = 1; i <= n; ++i)
            {
                if(!headers.Contains(((Range)worksheet.Cells[1, i]).Value2))
                {
                    worksheet.Columns[i].Delete();
                    i--;
                    n--;
                }
            }

            int lastRowIndex = range.Rows.Count;
            worksheet.Rows[lastRowIndex].Delete();
            
            string filename = Path.Combine(fixpackDir.Parent.FullName, CRegex.Match(fixpackDir.Name).Groups[1].Value) + ".xlsx";

            workbook.SaveAs(filename, XlFileFormat.xlOpenXMLWorkbook, Type.Missing, Type.Missing, true, false, XlSaveAsAccessMode.xlNoChange, XlSaveConflictResolution.xlLocalSessionChanges, Type.Missing, Type.Missing);

            workbook.Close();

            MessageBox.Show("Эксель-файл собран", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
