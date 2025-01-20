using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gamming_Center.Models
{
    internal class ProfitsModel : DB.DbConnection
    {
        public void LoadPostsToDataGridView(DataGridView dataGridView)
        {
            using (var connection = GetConnection()) // Use the inherited GetConnection method
            {
                connection.Open();
                using (var command = new SQLiteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT " +
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
                            "Post ON Post_Cashier.Post = Post.ID ";

                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        var dataTable = new DataTable();
                        adapter.Fill(dataTable); // Fill the DataTable with the result set
                        dataGridView.DataSource = dataTable; // Bind the DataTable to the DataGridView
                    }
                }
            }
        }
        public void LoadProductToDataGridView(DataGridView dataGridView)
        {
            using (var connection = GetConnection()) // Use the inherited GetConnection method
            {
                connection.Open();
                using (var command = new SQLiteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT " +
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
                        " Product ON  Product_Cashier.Product = Product.ID ";

                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        var dataTable = new DataTable();
                        adapter.Fill(dataTable); // Fill the DataTable with the result set
                        dataGridView.DataSource = dataTable; // Bind the DataTable to the DataGridView
                    }
                }
            }
        }

        public void LoadFilteredData(DataGridView dataGridView, string query, Dictionary<string, object> parameters = null)
        {
            using (var connection = GetConnection()) // Use the inherited GetConnection method
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            command.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        var dataTable = new DataTable();
                        dataTable.Load(reader);
                        dataGridView.DataSource = dataTable;
                    }
                }
            }
        }

    }
}
