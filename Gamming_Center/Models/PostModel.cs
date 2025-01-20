using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gamming_Center.DB;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Gamming_Center.Models
{
    internal class PostModel : DbConnection
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
                                            "Post.ID, " +
                                            "Post.Name, " +
                                            "Type.Name AS Type, " +
                                            "Category.Name AS Category " +
                                        "FROM " +
                                            "Post " +
                                        "JOIN " +
                                            "Type ON Post.Type = Type.ID " +
                                        "JOIN " +
                                            "Category ON Post.Category = Category.ID;" ;

                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        var dataTable = new DataTable();
                        adapter.Fill(dataTable); // Fill the DataTable with the result set
                        dataGridView.DataSource = dataTable; // Bind the DataTable to the DataGridView
                    }
                }
            }
        }
        public void LoadTypesToDataGridView(DataGridView dataGridView)
        {
            using (var connection = GetConnection()) // Use the inherited GetConnection method
            {
                connection.Open();
                using (var command = new SQLiteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Type";

                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        var dataTable = new DataTable();
                        adapter.Fill(dataTable); // Fill the DataTable with the result set
                        dataGridView.DataSource = dataTable; // Bind the DataTable to the DataGridView
                    }
                }
            }
        }
        public void UpdatePost(int id, string name, string type, string category)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SQLiteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Post
                                    SET Name = @Name,
                                        Type = @Type,
                                        Category = @Category
                                    WHERE ID = @ID";

                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Type", type);
                    command.Parameters.AddWithValue("@Category", category);
                    command.ExecuteNonQuery();
                }
            }
        }


        public void AddPost(string name, string type, string category)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SQLiteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Post (Name, Type, Category)
                                    VALUES (@Name, @Type, @Category)";

                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Type", type);
                    command.Parameters.AddWithValue("@Category", category);
                    command.ExecuteNonQuery(); // Execute the insert query
                }
            }
        }



        public void DeletePost(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SQLiteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM Post WHERE ID = @ID";

                    command.Parameters.AddWithValue("@ID", id);

                    command.ExecuteNonQuery(); // Execute the delete query
                }
            }
        }



        public List<TypeItem> GetAvailableTypes()
        {
            List<TypeItem> types = new List<TypeItem>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SQLiteCommand("SELECT ID, Name FROM Type", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            types.Add(new TypeItem
                            {
                                ID = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }
                }
            }

            return types;
        }
        public List<TypeItem> GetAvailableCategories()
        {
            List<TypeItem> types = new List<TypeItem>();

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SQLiteCommand("SELECT ID, Name FROM Category", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            types.Add(new TypeItem
                            {
                                ID = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }
                }
            }

            return types;
        }
        public void UpdateType(int id, string name, string amount, int price2p, int price4p)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SQLiteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"UPDATE Type
                                    SET Name = @Name,
                                        Amount = @Amount,
                                        Price2p = @Price2p,
                                        Price4p = @Price4p
                                    WHERE ID = @ID";

                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@Price2p", price2p);
                    command.Parameters.AddWithValue("@Price4p", price4p);


                    command.ExecuteNonQuery();
                }
            }
        }


        public void AddType(string name, string amount, int price2p, int price4p)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SQLiteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO Type (Name, Amount, Price2p, Price4p)
                                    VALUES (@Name, @Amount, @Price2p, @Price4p)";

                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Amount", amount);
                    command.Parameters.AddWithValue("@Price2p", price2p);
                    command.Parameters.AddWithValue("@Price4p", price4p);

                    command.ExecuteNonQuery(); // Execute the insert query
                }
            }
        }



        public void DeleteType(int id)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SQLiteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM Type WHERE ID = @ID";

                    command.Parameters.AddWithValue("@ID", id);

                    command.ExecuteNonQuery(); // Execute the delete query
                }
            }
        }
    }
    public class TypeItem
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

 
}
