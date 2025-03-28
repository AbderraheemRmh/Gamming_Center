﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using FontAwesome.Sharp;
using Button = System.Windows.Forms.Button;
using Color = System.Drawing.Color;
using Label = System.Windows.Forms.Label;
using Panel = System.Windows.Forms.Panel;

namespace Gamming_Center
{

    public partial class HomePage : Form
    {
        
        private Panel leftBorderBtn;
        private int issuer;
        private int countVip;
        private int countStandard;
        private int countBilliard;
        private ps4Timer[] vipPandel;
        private ps4Timer[] standardPandel;
        private soloTimer[] billiardPandel;
        private int borderSize = 5;
        private Size formSize;
        public HomePage(int issuer)
        {
           

            // Add a FlowLayoutPanel to organize the panels
            InitializeComponent();
            
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            this.Padding = new Padding(borderSize);//Border size
            this.BackColor = Color.FromArgb(0, 128, 128);//Border color
            this.issuer = issuer;
            lblUser.Text = GetWorkerNameById(issuer);
            LoadVIPDevices();
            LoadStandardDevices();
            LoadBilliard();

        }

        private string GetWorkerNameById(int workerId)
        {
            string workerName = string.Empty;

            string connectionString = "Data Source=GammingCenter.db;Version=3;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand("SELECT Name FROM Worker WHERE ID = @ID", connection))
                {
                    command.Parameters.AddWithValue("@ID", workerId);

                    var result = command.ExecuteScalar(); // ExecuteScalar is used for single-value results
                    if (result != null)
                    {
                        workerName = result.ToString();
                    }
                }
            }

            return workerName;
        }

        private void restPanelsIssuer(int workerId)
        {
           for(int i=0; i < countVip; i++)
            {
                vipPandel[i].changeIssuer(workerId);
            }
            for (int i = 0; i < countStandard; i++)
            {
                standardPandel[i].changeIssuer(workerId);
            }
            for (int i = 0; i < countBilliard; i++)
            {
                billiardPandel[i].changeIssuer(workerId);
            }
        }

        private int postsVIPCount()
        {
            string connectionString = "Data Source=GammingCenter.db;Version=3;";
            string query = "SELECT COUNT(*) FROM Post JOIN Category ON Post.Category = Category.ID WHERE Category.Name = 'VIP'";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count;
                }
            }
        }
        

        private void LoadVIPDevices()
        {
            countVip = postsVIPCount();
            vipPandel = new ps4Timer[countVip];
            int i = 0;
            // Replace with your actual SQLite database path
            string connectionString = "Data Source=GammingCenter.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT 
                            Post.ID, 
                            Post.Name, 
                            Type.Name AS TypeName
                        FROM 
                            Post
                        JOIN 
                            Category ON Post.Category = Category.ID
                        JOIN 
                            Type ON Post.Type = Type.ID
                        WHERE 
                            Category.Name = 'VIP'";// Adjust columns to match your table
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int Id = reader.GetInt32(0);
                        string Name = reader.GetString(1);
                        string Type = reader.GetString(2);
                        vipPandel[i] = new ps4Timer(issuer, Type);
                        vipPandel[i].Id = Id;
                        vipPandel[i].Title = Name;
                        vipPanel.Controls.Add(vipPandel[i]);
                        i++;
                    }
                }
            }
        }





        private int postsStandardCount()
        {
            string connectionString = "Data Source=GammingCenter.db;Version=3;";
            string query = "SELECT COUNT(*) FROM Post JOIN Category ON Post.Category = Category.ID WHERE Category.Name = 'Standard'";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count;
                }
            }
        }


        private void LoadStandardDevices()
        {
            countStandard = postsStandardCount();
            standardPandel = new ps4Timer[countStandard];
            int i = 0;
            // Replace with your actual SQLite database path
            string connectionString = "Data Source=GammingCenter.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
                     SELECT 
                            Post.ID, 
                            Post.Name, 
                            Type.Name AS TypeName
                        FROM 
                            Post
                        JOIN 
                            Category ON Post.Category = Category.ID
                        JOIN 
                            Type ON Post.Type = Type.ID
                        WHERE 
                            Category.Name = 'Standard'";// Adjust columns to match your table
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int Id = reader.GetInt32(0);
                        string Name = reader.GetString(1);
                        string Type = reader .GetString(2);
                        standardPandel[i] = new ps4Timer(issuer, Type);
                        standardPandel[i].Id = Id;
                        standardPandel[i].Title = Name;
                        standardPanel.Controls.Add(standardPandel[i]);
                        i++;
                    }
                }
            }
        }


        private int billiardCount()
        {
            string connectionString = "Data Source=GammingCenter.db;Version=3;";
            string query = "SELECT COUNT(*) FROM Post JOIN Category ON Post.Category = Category.ID WHERE Category.Name = 'Billiard'";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                {
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count;
                }
            }
        }


        private void LoadBilliard()
        {
            countBilliard = billiardCount();
            billiardPandel = new soloTimer[countBilliard];
            int i = 0;
            // Replace with your actual SQLite database path
            string connectionString = "Data Source=GammingCenter.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT Post.ID, Post.Name 
                    FROM Post
                    JOIN Category ON Post.Category = Category.ID
                    WHERE Category.Name = 'Billiard'";// Adjust columns to match your table
                using (SQLiteCommand command = new SQLiteCommand(query, connection))
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int Id = reader.GetInt32(0);
                        string Name = reader.GetString(1);
                        billiardPandel[i] = new soloTimer(issuer);
                        billiardPandel[i].Id = Id;
                        billiardPandel[i].Title = Name;
                        billiardPanel.Controls.Add(billiardPandel[i]);
                        i++;
                    }
                }
            }
        }





        private void HomePage_Load(object sender, EventArgs e)
        {
            formSize = this.ClientSize;
            vipPanel.Height = (this.Height - 177)/3 ;
            standardPanel.Height = (this.Height - 177) / 3;
            billiardPanel.Height = (this.Height - 177) / 3;
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //Overridden methods
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            const int SC_RESTORE = 0xF120; //Restore form (Before)
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;
            #region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right
            ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>
            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion
            //Remove border and keep snap window
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            //Keep form size when it is minimized and restored. Since the form is resized because it takes into account the size of the title bar and borders.
            if (m.Msg == WM_SYSCOMMAND)
            {
                /// <see cref="https://docs.microsoft.com/en-us/windows/win32/menurc/wm-syscommand"/>
                /// Quote:
                /// In WM_SYSCOMMAND messages, the four low - order bits of the wParam parameter 
                /// are used internally by the system.To obtain the correct result when testing 
                /// the value of wParam, an application must combine the value 0xFFF0 with the 
                /// wParam value by using the bitwise AND operator.
                int wParam = (m.WParam.ToInt32() & 0xFFF0);
                if (wParam == SC_MINIMIZE)  //Before
                    formSize = this.ClientSize;
                if (wParam == SC_RESTORE)// Restored form(Before)
                    this.Size = formSize;
            }
            base.WndProc(ref m);
        }
        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized: //Maximized form (After)
                    this.Padding = new Padding(8, 8, 8, 0);
                    break;
                case FormWindowState.Normal: //Restored form (After)
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
        }

        private void HomePage_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {

            formSize = this.ClientSize;
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                formSize = this.ClientSize;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = formSize;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit the Application?",
                                 "Close APP",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Application.Exit(); // Close the form if user confirms
            }
            
        }


        private void iconButton6_Click(object sender, EventArgs e)
        {

            var result = MessageBox.Show("Are you sure you want to logout?",
                                 "Log Out",
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Login loginp = new Login();
                loginp.Show();
                this.Hide();
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
                using (switchUser switchuser = new switchUser(this)) // Replace with your form name
                {
                    if (switchuser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        this.issuer = switchuser.issuer;// Opens the form as a modal dialog
                }
                lblUser.Text = GetWorkerNameById(issuer);
                restPanelsIssuer(issuer);
        }

        private void btnQuikSell_Click(object sender, EventArgs e)
        {
                checkoutProducts checkProduct = new checkoutProducts(issuer);
                checkProduct.Show();
        }
    }
}
