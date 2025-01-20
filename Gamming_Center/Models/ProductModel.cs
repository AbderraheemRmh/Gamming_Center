using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamming_Center.DB;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace Gamming_Center.Models
{

    internal class ProductModel : DbConnection
    {
        
        public void AddProduct(string name, string photopath, int priceOut, int price, int amount)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SQLiteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Product (Name, Photo, Price, Original_Price, Amount) VALUES (@Name, @Photo, @PriceOut, @Price, @Amount)";

                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Photo", photopath);
                    command.Parameters.AddWithValue("@PriceOut", priceOut);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Amount", amount);

                    command.ExecuteNonQuery();
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
                    command.CommandText = "SELECT * FROM Product";

                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        var dataTable = new DataTable();
                        adapter.Fill(dataTable); // Fill the DataTable with the result set
                        dataGridView.DataSource = dataTable; // Bind the DataTable to the DataGridView
                    }
                }
            }
        }

        public void UpdateProduct(int id, string name, string photo, int priceOut, int price, int amount)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SQLiteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Product
                                        SET Name = @Name,
                                            Photo = @Photo,
                                            Price = @PriceOut,
                                            Original_Price = @Price,
                                            Amount = @Amount
                                        WHERE ID = @ID";
        
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Photo", photo);
                    command.Parameters.AddWithValue("@PriceOut", priceOut);
                    command.Parameters.AddWithValue("@Price", price);
                    command.Parameters.AddWithValue("@Amount", amount);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteProduct(int id)
        {
            using (var connection = GetConnection())
            {

                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    try
                    {
                        // Step 1: Get the Photo path
                        command.CommandText = "SELECT Photo FROM Product WHERE ID = @ProductID";
                        command.Parameters.AddWithValue("@ProductID", id);
                        var photoPath = command.ExecuteScalar()?.ToString();

                        // Step 2: Delete the Photo file
                        if (!string.IsNullOrEmpty(photoPath))
                        {
                            string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, photoPath);
                            if (File.Exists(fullPath))
                            {
                                File.Delete(fullPath);
                            }
                        }

                        command.Connection = connection;
                        command.CommandText = @"DELETE FROM Product WHERE ID = @ID";

                        command.Parameters.AddWithValue("@ID", id);

                        command.ExecuteNonQuery(); // Execute the delete query
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }
    }
}
