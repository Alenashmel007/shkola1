using Guna.UI2.WinForms;
using OfficeOpenXml;

namespace SchoolSystem.Common;

public class ExportExcel
{
    public void Export(Guna2DataGridView grid)
    {
        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
        if (grid == null || grid.Rows.Count <= 0)
        {
            MessageBox.Show("Данные для экспорта не обнаружены.", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using (var package = new ExcelPackage())
        {
            var worksheet = package.Workbook.Worksheets.Add("Данные");

            for (int i = 0; i < grid.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1].Value = grid.Columns[i].HeaderText;
                worksheet.Cells[1, i + 1].Style.Font.Bold = true;
            }

            for (int i = 0; i < grid.Rows.Count; i++)
            {
                for (int j = 0; j < grid.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1].Value = grid.Rows[i].Cells[j].Value?.ToString();
                }
            }

            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Сохранить как Excel файл",
                FileName = "Export.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var file = new FileInfo(saveFileDialog.FileName);
                package.SaveAs(file);

                MessageBox.Show("Экспорт данных успешно завершен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
