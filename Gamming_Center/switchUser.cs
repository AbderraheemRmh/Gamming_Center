using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gamming_Center
{

    public partial class switchUser : Form
    {
        public int issuer;
        private Form form;
        public switchUser(Form form)
        {
            this.form = form;
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            string username = usertb.Text.Trim();
            string password = passwordtb.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both Username and Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string connectionString = "Data Source=GammingCenter.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Query to check if the worker exists and retrieve their ID and Level
                string query = "SELECT ID, Level FROM Worker WHERE Name = @username AND Password = @password";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                             // Get the worker's ID
                            string userLevel = reader.GetString(1); // Get the worker's Level

                            // Redirect based on the level
                            if (userLevel == "Admin")
                            {
                                var result = MessageBox.Show("Are you sure you want to access dashboard?",
                                 "Open Dashboard",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Warning);

                                if (result == DialogResult.Yes)
                                {
                                    Dashboard dashboard = new Dashboard();
                                    dashboard.Show();
                                    form.Close();
                                    this.Hide();
                                }
                            }
                            else
                            {
                                issuer = reader.GetInt32(0);
                                this.DialogResult = DialogResult.OK;
                                this.Close();

                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
