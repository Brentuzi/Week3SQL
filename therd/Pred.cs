using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace therd
{
    public partial class Pred : Form
    {
        public Pred()
        {
            InitializeComponent();
            LoadData();
            LoadItemTypes();
        }

        private void Pred_Load(object sender, EventArgs e)
        {

        }
        private void LoadData(string filter = "")
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-IITVJLG\\SQLEXPRESS;Initial Catalog=AuctionDB;Integrated Security=True"))
            {
                connection.Open();
                string query = "SELECT * FROM Items" + filter;
                SqlCommand cmd = new SqlCommand(query, connection);

                if (!string.IsNullOrEmpty(filter))
                {
                    cmd.Parameters.AddWithValue("@filterPrice", decimal.Parse(textBoxFilterPrice.Text));
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }




        private void AddItem()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-IITVJLG\\SQLEXPRESS;Initial Catalog=AuctionDB;Integrated Security=True"))
            {
                connection.Open();
                string itemName = textBoxItemName.Text;
                int itemTypeID = (int)comboBoxItemType.SelectedValue;
                int productionYear = int.Parse(textBoxProductionYear.Text);
                string owner = textBoxOwner.Text;
                DateTime receptionDate = dateTimePickerReceptionDate.Value;
                decimal estimatedPrice = decimal.Parse(textBoxEstimatedPrice.Text);
                string additionalInfo = textBoxAdditionalInfo.Text;

                SqlCommand cmd = new SqlCommand("INSERT INTO Items (ItemName, ItemTypeID, ProductionYear, Owner, ReceptionDate, EstimatedPrice, AdditionalInfo) VALUES (@itemName, @itemTypeID, @productionYear, @owner, @receptionDate, @estimatedPrice, @additionalInfo)", connection);
                cmd.Parameters.AddWithValue("@itemName", itemName);
                cmd.Parameters.AddWithValue("@itemTypeID", itemTypeID);
                cmd.Parameters.AddWithValue("@productionYear", productionYear);
                cmd.Parameters.AddWithValue("@owner", owner);
                cmd.Parameters.AddWithValue("@receptionDate", receptionDate);
                cmd.Parameters.AddWithValue("@estimatedPrice", estimatedPrice);
                cmd.Parameters.AddWithValue("@additionalInfo", additionalInfo);

                cmd.ExecuteNonQuery();
            }
        }

        private void LoadItemTypes()
        {
            using (SqlConnection connection = new SqlConnection("Data Source=DESKTOP-IITVJLG\\SQLEXPRESS;Initial Catalog=AuctionDB;Integrated Security=True"))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM ItemTypes", connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                comboBoxItemType.DataSource = table;
                comboBoxItemType.DisplayMember = "TypeName";
                comboBoxItemType.ValueMember = "TypeID";
            }
        }


       

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddItem();
            LoadData(); 
        }
        private void buttonApplyFilter_Click(object sender, EventArgs e)
        {
            string filterType = comboBoxFilterType.SelectedItem.ToString();
            string filterOperator = filterType == "Больше" ? ">" : "<";
            decimal filterPrice = decimal.Parse(textBoxFilterPrice.Text);

            string filter = $" WHERE EstimatedPrice {filterOperator} @filterPrice";
            LoadData(filter);
        }

       


        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
