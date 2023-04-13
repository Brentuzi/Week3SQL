using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;

namespace therd
{
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
            
            LoadData();
        }
        private void LoadData(string sortBy = "ItemID", bool ascending = true)
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-IITVJLG\\SQLEXPRESS;Initial Catalog=AuctionDB;Integrated Security=True"))
            {
                connection.Open();
                string query = $@"SELECT i.ItemID, i.ItemName, it.TypeName, i.ProductionYear, i.Owner, i.ReceptionDate, i.EstimatedPrice, s.AuctionDate, s.StartPrice, s.FinalPrice, s.IsSold, s.BuyerLastName
                          FROM Items i
                          INNER JOIN Sales s ON i.ItemID = s.ItemID
                          INNER JOIN ItemTypes it ON i.ItemTypeID = it.TypeID
                          ORDER BY {sortBy} {(ascending ? "ASC" : "DESC")}";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridViewSales.DataSource = table;
            }
        }
        private void buttonSort_Click(object sender, EventArgs e)
        {
            string sortBy = comboBoxSortBy.SelectedItem.ToString();
            LoadData(sortBy);
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "auctionDBDataSet.Sales". При необходимости она может быть перемещена или удалена.


        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog.FileName = "SalesData.xlsx";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToExcel(saveFileDialog.FileName);
                    MessageBox.Show("Данные успешно экспортированы в файл Excel.", "Экспорт данных", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void ExportToExcel(string filePath)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("SalesData");

                // Запись заголовков столбцов
                for (int i = 1; i <= dataGridViewSales.Columns.Count; i++)
                {
                    worksheet.Cells[1, i].Value = dataGridViewSales.Columns[i - 1].HeaderText;
                    worksheet.Cells[1, i].Style.Font.Bold = true;
                }

                // Запись данных ячеек
                for (int i = 0; i < dataGridViewSales.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridViewSales.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1].Value = dataGridViewSales.Rows[i].Cells[j].Value;
                    }
                }

                worksheet.Cells.AutoFitColumns(); // Автоматическое изменение ширины столбцов

                // Сохранение файла Excel
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {
                    excelPackage.SaveAs(fileStream);
                }
            }
        }

    }
}
