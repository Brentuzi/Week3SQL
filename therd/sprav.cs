using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace therd
{
    public partial class sprav : Form
    {
        public sprav()
        {
            InitializeComponent();
        }

        private void itemsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
          
            this.tableAdapterManager.UpdateAll(this.auctionDBDataSet);

        }

        private void typeNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void itemTypesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.itemTypesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.auctionDBDataSet);

        }

        private void itemTypesBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.itemTypesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.auctionDBDataSet);

        }

        private void sprav_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "auctionDBDataSet.ItemTypes". При необходимости она может быть перемещена или удалена.
            this.itemTypesTableAdapter.Fill(this.auctionDBDataSet.ItemTypes);

        }
    }
}
