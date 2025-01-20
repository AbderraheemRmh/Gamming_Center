using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gamming_Center.Models;

namespace Gamming_Center
{
    
    public partial class Profit : Form
    {
        private ProfitsModel model;
        public Profit()
        {
            InitializeComponent();
            model = new ProfitsModel();
            model.LoadProductToDataGridView(listProduct);
            model.LoadPostsToDataGridView(listPost);
            editSize();
            CalculateTotalFromGrid();
            CalculateBaseFromGrid();
            CalculateTotalFromGridP();
        }


        private void editSize()
        {
            panel1.Width = this.Width / 2;
            panel2.Width = this.Width / 2;
            listPost.Height = panel1.Height * 4/5;
            listProduct.Height = panel2.Height * 4/5;
        }
        private void btnDay_Click(object sender, EventArgs e)
        {
            string query = "SELECT " +
                        "Product_Cashier.ID AS CashierID," +
                        "Worker.Name AS WorkerName, " +
                        "Product_Cashier.Date, " +
                        "Product_Cashier.Price, " +
                        "Product.Name AS ProductName," +
                        "Product_Cashier.Amount, " +
                        "Product_Cashier.Base " +
                        "FROM " +
                        "Product_Cashier " +
                        "JOIN " +
                            "Worker ON Product_Cashier.Issuer = Worker.ID " +
                        "JOIN  " +
                        " Product ON  Product_Cashier.Product = Product.ID " +
                        "WHERE Date >= datetime('now', '-1 day', 'localtime')";
            model.LoadFilteredData(listProduct,query);
            CalculateTotalFromGrid();
            CalculateBaseFromGrid();
        }

        private void btnWeek_Click(object sender, EventArgs e)
        {
            string query = "SELECT " +
                        "Product_Cashier.ID AS CashierID," +
                        "Worker.Name AS WorkerName, " +
                        "Product_Cashier.Date, " +
                        "Product_Cashier.Price, " +
                        "Product.Name AS ProductName," +
                        "Product_Cashier.Amount, " +
                        "Product_Cashier.Base " +
                        "FROM " +
                        "Product_Cashier " +
                        "JOIN " +
                            "Worker ON Product_Cashier.Issuer = Worker.ID " +
                        "JOIN  " +
                        " Product ON  Product_Cashier.Product = Product.ID " +
                        "WHERE Date >= datetime('now', '-7 days', 'localtime')";
            model.LoadFilteredData(listProduct, query);
            CalculateTotalFromGrid();
            CalculateBaseFromGrid();
        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            string query = "SELECT " +
                        "Product_Cashier.ID AS CashierID," +
                        "Worker.Name AS WorkerName, " +
                        "Product_Cashier.Date, " +
                        "Product_Cashier.Price, " +
                        "Product.Name AS ProductName," +
                        "Product_Cashier.Amount, " +
                        "Product_Cashier.Base " +
                        "FROM " +
                        "Product_Cashier " +
                        "JOIN " +
                            "Worker ON Product_Cashier.Issuer = Worker.ID " +
                        "JOIN  " +
                        " Product ON  Product_Cashier.Product = Product.ID " +
                        "WHERE Date >= datetime('now', '-1 month', 'localtime')";
            model.LoadFilteredData(listProduct, query);
            CalculateTotalFromGrid();
            CalculateBaseFromGrid();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            model.LoadProductToDataGridView(listProduct);
            CalculateTotalFromGrid();
            CalculateBaseFromGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "SELECT " +
                        "Product_Cashier.ID AS CashierID," +
                        "Worker.Name AS WorkerName, " +
                        "Product_Cashier.Date, " +
                        "Product_Cashier.Price, " +
                        "Product.Name AS ProductName," +
                        "Product_Cashier.Amount, " +
                        "Product_Cashier.Base " +
                        "FROM " +
                        "Product_Cashier " +
                        "JOIN " +
                            "Worker ON Product_Cashier.Issuer = Worker.ID " +
                        "JOIN  " +
                        " Product ON  Product_Cashier.Product = Product.ID " + 
                        "WHERE Date BETWEEN @StartDate AND @EndDate";
            var parameters = new Dictionary<string, object>
    {
        { "@StartDate", startDatePicker.Value.ToString("yyyy-MM-dd HH:mm:ss") },
        { "@EndDate", endDatePicker.Value.ToString("yyyy-MM-dd HH:mm:ss") }
    };
            model.LoadFilteredData(listProduct, query, parameters);
            CalculateTotalFromGrid();
            CalculateBaseFromGrid();
        }


        private void CalculateTotalFromGrid()
        {
            decimal total = 0;

            // Replace "PriceColumn" with the actual column name or index
            foreach (DataGridViewRow row in listProduct.Rows)
            {
                if (row.Cells["Price"].Value != null) // Check if the cell has a value
                {
                    decimal price;
                    if (decimal.TryParse(row.Cells["Price"].Value.ToString(), out price))
                    {
                        total += price;
                    }
                }
            }

            txtSum.Text = total.ToString();
        }
        private void CalculateBaseFromGrid()
        {
            decimal total = 0;

            // Replace "PriceColumn" with the actual column name or index
            foreach (DataGridViewRow row in listProduct.Rows)
            {
                if (row.Cells["Base"].Value != null) // Check if the cell has a value
                {
                    decimal price;
                    if (decimal.TryParse(row.Cells["Base"].Value.ToString(), out price))
                    {
                        total += price;
                    }
                }
            }

            txtBase.Text = total.ToString();
        }

        private void btnDayP_Click(object sender, EventArgs e)
        {
            string query = "SELECT " +
                            "Post_Cashier.ID AS CashierID, " +
                            "Worker.Name AS WorkerName, " +
                            "Post.Name AS PostName, " + 
                            "Post_Cashier.Date, " +
                            "Post_Cashier.Price " +
                        "FROM " +
                            "Post_Cashier " +
                        "JOIN " +
                            "Worker ON Post_Cashier.Issuer = Worker.ID " +
                        "JOIN " +
                            "Post ON Post_Cashier.Post = Post.ID " + 
                        "WHERE " +
                            "Date >= datetime('now', '-1 day', 'localtime');";
            model.LoadFilteredData(listPost, query);
            CalculateTotalFromGridP();
        }

        private void btnWeekP_Click(object sender, EventArgs e)
        {
            string query = "SELECT " +
                            "Post_Cashier.ID AS CashierID, " +
                            "Worker.Name AS WorkerName, " +
                            "Post.Name AS PostName, " +
                            "Post_Cashier.Date, " +
                            "Post_Cashier.Price " +
                        "FROM " +
                            "Post_Cashier " +
                        "JOIN " +
                            "Worker ON Post_Cashier.Issuer = Worker.ID " +
                        "JOIN " +
                            "Post ON Post_Cashier.Post = Post.ID " +
                        "WHERE " +
                            "Date >= datetime('now', '-7 day', 'localtime');";
            model.LoadFilteredData(listPost, query);
            CalculateTotalFromGridP();
        }

        private void btnMonthP_Click(object sender, EventArgs e)
        {
            string query = "SELECT " +
                            "Post_Cashier.ID AS CashierID, " +
                            "Worker.Name AS WorkerName, " +
                            "Post.Name AS PostName, " +
                            "Post_Cashier.Date, " +
                            "Post_Cashier.Price " +
                        "FROM " +
                            "Post_Cashier " +
                        "JOIN " +
                            "Worker ON Post_Cashier.Issuer = Worker.ID " +
                        "JOIN " +
                            "Post ON Post_Cashier.Post = Post.ID " +
                        "WHERE " +
                            "Date >= datetime('now', '-1 month', 'localtime');";
            model.LoadFilteredData(listPost, query);
            CalculateTotalFromGridP();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT " +
                            "Post_Cashier.ID AS CashierID, " +
                            "Worker.Name AS WorkerName, " +
                            "Post.Name AS PostName, " +
                            "Post_Cashier.Date, " +
                            "Post_Cashier.Price " +
                        "FROM " +
                            "Post_Cashier " +
                        "JOIN " +
                            "Worker ON Post_Cashier.Issuer = Worker.ID " +
                        "JOIN " +
                            "Post ON Post_Cashier.Post = Post.ID " +
                        "WHERE Date BETWEEN @StartDate AND @EndDate";
            var parameters = new Dictionary<string, object>
    {
        { "@StartDate", startDatePickerP.Value.ToString("yyyy-MM-dd HH:mm:ss") },
        { "@EndDate", endDatePickerP.Value.ToString("yyyy-MM-dd HH:mm:ss") }
    };
            model.LoadFilteredData(listPost, query, parameters);
            CalculateTotalFromGridP();
        }
        private void CalculateTotalFromGridP()
        {
            decimal total = 0;

            // Replace "PriceColumn" with the actual column name or index
            foreach (DataGridViewRow row in listPost.Rows)
            {
                if (row.Cells["Price"].Value != null) // Check if the cell has a value
                {
                    decimal price;
                    if (decimal.TryParse(row.Cells["Price"].Value.ToString(), out price))
                    {
                        total += price;
                    }
                }
            }

            txtSumPost.Text = total.ToString();
        }

        private void btnResetP_Click(object sender, EventArgs e)
        {
            model.LoadPostsToDataGridView(listPost);
            CalculateTotalFromGridP();
        }
    }
    
}
