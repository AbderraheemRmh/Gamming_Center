using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Gamming_Center
{
    public partial class Dashboard : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private bool canClose;

        private int borderSize = 2;
        private Size formSize;
        public Dashboard(bool canClose)
        {
            

            // Add a FlowLayoutPanel to organize the panels
            InitializeComponent();
            this.canClose = canClose;
            CollapseMenu();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            this.Padding = new Padding(borderSize);//Border size
            this.BackColor = Color.Crimson;//Border color
            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.Appearance = TabAppearance.FlatButtons;
            panelDesktop.ItemSize = new System.Drawing.Size(0, 1); // Set small size for tabs
            panelDesktop.SizeMode = TabSizeMode.Fixed;

            // Create tab pages
            panelDesktop.TabPages.Add("Dashboard");
            AddPictureBoxToTab(panelDesktop.TabPages[0]);

            panelDesktop.TabPages.Add("Worker");
            panelDesktop.TabPages[1].Controls.Add(new Label() { Text = "Worker", AutoSize = true });

            panelDesktop.TabPages.Add("Post");
            panelDesktop.TabPages[2].Controls.Add(new Label() { Text = "Post", AutoSize = true });

            panelDesktop.TabPages.Add("Product");
            panelDesktop.TabPages[3].Controls.Add(new Label() { Text = "Product", AutoSize = true });

            panelDesktop.TabPages.Add("Profit");
            panelDesktop.TabPages[4].Controls.Add(new Label() { Text = "Profit", AutoSize = true });
            string srcFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "src");
            string imagePath = Path.Combine(srcFolder, "Asset.png");

            if (File.Exists(imagePath))
            {
                // Load the image into the PictureBox
                pictureBox1.Image = Image.FromFile(imagePath);
            }

        }
        private void AddPictureBoxToTab(TabPage tabPage)
        {
            // Create a new PictureBox
            PictureBox pictureBox = new PictureBox
            {
                Dock = DockStyle.Fill, // Make it fill the entire TabPage
                SizeMode = PictureBoxSizeMode.Zoom // Adjust image to fit
            };

            // Path to the image in the 'src' folder
            string srcFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "src");
            string imagePath = Path.Combine(srcFolder, "Asset.png");

            if (File.Exists(imagePath))
            {
                // Load the image into the PictureBox
                pictureBox.Image = Image.FromFile(imagePath);
            }
            else
            {
                MessageBox.Show("Image not found in the src folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Add the PictureBox to the TabPage
            tabPage.Controls.Add(pictureBox);
        }

        private void SwitchToTab(int index)
        {
            panelDesktop.SelectedIndex = index;
        }

        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(0, 130, 75);
            public static Color color2 = Color.FromArgb(130, 30, 0);
            public static Color color3 = Color.FromArgb(0, 75, 130);
            public static Color color4 = Color.FromArgb(130, 0, 75);
        }
        private void ActivateButton(object senderBtn, string title, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(245, 245, 245);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
                //Current Child Form Icon
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
                lblTitleChildForm.Text = title;
                lblTitleChildForm.ForeColor = color;
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.Crimson;
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;

            }
        }
        private void OpenChildForm(Form childForm, int tabIndex)
        {

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.TabPages[tabIndex].Controls.Add(childForm);
            panelDesktop.TabPages[tabIndex].Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.Crimson;
            lblTitleChildForm.Text = "Dashboard";
            lblTitleChildForm.ForeColor = Color.Crimson;
        }






        private void HomePage_Load(object sender, EventArgs e)
        {
            formSize = this.ClientSize;
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
                this.Size = new Size(1200, 800);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (canClose)
            {
                Application.Exit();
            }
            else
            {
                isBilliardOpen = false;
                isPS4Open = false;
                isPS5Open = false;
                isSimulatorOpen = false;
                this.Hide();
            }


        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
        }
        private void CollapseMenu()
        {
            if (this.panelMenu.Width > 200) //Collapse menu
            {
                panelMenu.Width = 100;
                pictureBox1.Visible = false;
                btnMenu.Dock = DockStyle.Top;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            { //Expand menu
                panelMenu.Width = 230;
                pictureBox1.Visible = true;
                btnMenu.Dock = DockStyle.None;
                foreach (Button menuButton in panelMenu.Controls.OfType<Button>())
                {
                    menuButton.Text = "   " + menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                }
            }
        }
        private static Boolean isPS4Open, isPS5Open, isBilliardOpen, isSimulatorOpen = false;
        private void btnWorker_Click(object sender, EventArgs e)
        {

            SwitchToTab(1);
            ActivateButton(sender, "Worker", RGBColors.color1);
            if (!isPS4Open)
            {
                OpenChildForm(new Worker(), 1);
                isPS4Open = true;
            }

        }

        private void btnPost_Click(object sender, EventArgs e)
        {

            SwitchToTab(2);
            ActivateButton(sender, "Post", RGBColors.color2);
            if (!isPS5Open)
            {
                OpenChildForm(new Post(), 2);
                isPS5Open = true;
            }
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            Login loginp = new Login();
            loginp.Show();
            isPS4Open = false;
            isPS5Open = false;
            isBilliardOpen = false;
            isSimulatorOpen = false;
            this.Hide();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {

            SwitchToTab(3);
            ActivateButton(sender, "Product", RGBColors.color3);
            if (!isBilliardOpen)
            {
                OpenChildForm(new Product(), 3);
                isBilliardOpen = true;
            }
        }

        private void btnProfit_Click(object sender, EventArgs e)
        {

            SwitchToTab(4);
            ActivateButton(sender, "Profit", RGBColors.color4);
            if (!isSimulatorOpen)
            {
                OpenChildForm(new Profit(), 4);
                isSimulatorOpen = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            Reset();
            SwitchToTab(0);
        }


    }
}
