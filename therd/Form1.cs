using OfficeOpenXml.FormulaParsing.Excel.Functions.Information;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Logical;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

//--Создание базы данных
//CREATE DATABASE AuctionDB;
//GO

//-- Использование базы данных
//USE AuctionDB;
//GO

//-- Создание таблицы "Справочник видов предметов продажи"
//CREATE TABLE ItemTypes
//(
//    TypeID INT PRIMARY KEY IDENTITY(1, 1),
//    TypeName NVARCHAR(255) NOT NULL
//);
//GO

//-- Создание таблицы "Предметы"
//CREATE TABLE Items
//(
//    ItemID INT PRIMARY KEY IDENTITY(1, 1),
//    ItemName NVARCHAR(255) NOT NULL,
//    ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(TypeID),
//    ProductionYear INT,
//    Owner NVARCHAR(255),
//    ReceptionDate DATE,
//    EstimatedPrice DECIMAL(18, 2),
//    AdditionalInfo NVARCHAR(MAX)
//);
//GO

//-- Создание таблицы "Продажи"
//CREATE TABLE Sales
//(
//    SaleID INT PRIMARY KEY IDENTITY(1, 1),
//    ItemID INT FOREIGN KEY REFERENCES Items(ItemID),
//    AuctionDate DATE,
//    StartPrice DECIMAL(18, 2),
//    FinalPrice DECIMAL(18, 2),
//    IsSold BIT,
//    BuyerLastName NVARCHAR(255)
//);
//GO
//это моя база данных
namespace therd
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void справочникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sprav sprav = new sprav();
            sprav.Show();
        }

        private void предметыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pred Pred = new Pred();
            Pred.Show();
        }

        private void продажиToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Sales Pred = new Sales();
            Pred.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void контактыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string phoneNumber = "+7 (987) 456-7890";
            string address = "145362 Санкт-Петербург";
            MessageBox.Show($"Номер телефона: {phoneNumber}\nАдрес: {address}", "Контактная информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
