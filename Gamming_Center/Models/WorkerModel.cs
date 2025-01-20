using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using Gamming_Center.DB;

namespace Gamming_Center.Models
{
    public class WorkerModel : DbConnection
    {
        public void CreateWorker(string name, string phone, string email, string level, string password)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SQLiteCommand())
                {
                    command.Connection = connection;
                    // Get Understock
                    command.CommandText = "INSERT INTO worker (Name, Phone, Email, Level, Password) " +
                        "VALUES (@Name, @Phone, @Email, @Level, @Password)";

                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Level", level);
                    command.Parameters.AddWithValue("@Password", password);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void LoadWorkersToDataGridView(DataGridView dataGridView)
        {
            using (var connection = GetConnection()) // Use the inherited GetConnection method
            {
                connection.Open();
                using (var command = new SQLiteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM worker";

                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        var dataTable = new DataTable();
                        adapter.Fill(dataTable); // Fill the DataTable with the result set
                        dataGridView.DataSource = dataTable; // Bind the DataTable to the DataGridView
                    }
                }
            }
        }
        public void UpdateWorker(int id, string name, string phone, string email, string level, string password)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SQLiteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE worker
                                    SET Name = @Name,
                                        Phone = @Phone,
                                        Email = @Email,
                                        Level = @Level,
                                        Password = @Password
                                    WHERE ID = @ID";

                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Level", level);
                    command.Parameters.AddWithValue("@Password", password);

                    command.ExecuteNonQuery();
                }
            }
        }


        public void AddWorker(string name, string phone, string email, string level, string password)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SQLiteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO worker (Name, Phone, Email, Level, Password)
                                    VALUES (@Name, @Phone, @Email, @Level, @Password)";

                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Level", level);
                    command.Parameters.AddWithValue("@Password", password);

                    command.ExecuteNonQuery(); // Execute the insert query
                }
            }
        }



        public void DeleteWorker(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SQLiteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM worker WHERE ID = @ID";

                    command.Parameters.AddWithValue("@ID", id);

                    command.ExecuteNonQuery(); // Execute the delete query
                }
            }
        }
    }
}
