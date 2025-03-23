using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gamming_Center
{
    public partial class ps4Timer : UserControl
    {

        private List<int> preCheckoutProducts = new List<int>();
        private int cornerRadius = 20;
        private Timer timer;
        private DateTime startTime;
        private TimeSpan elapsedTime;
        private string _title;
        private int _id;
        private int issuer;
        private TimeSpan? targetTime = null;
        private bool isPaused = false;
        private bool isStarted = false;
        private DateTime? endTime;
        public ps4Timer(int issuer, string type)

        {

            this.issuer = issuer;
            // Initialize form properties
            this.Text = "Chronometer";
            this.Size = new System.Drawing.Size(300, 250);

            // Timer
            timer = new Timer { Interval = 1000 }; // Tick every second
            timer.Tick += Timer_Tick;
            
            InitializeComponent();
            if (type == "PS4")
                this.consolType.Image = Properties.Resources.ps4;
            if (type == "PS5")
                this.consolType.Image = Properties.Resources.ps5;
            if (type == "PS3")
                this.consolType.Image = Properties.Resources.ps3;
        }

        public void changeIssuer(int issuer)
        {
            this.issuer = issuer;
        }

        private bool IsValidTime(string input)
        {
            // Try to parse the time directly
            return TimeSpan.TryParse(input, out _);
        }

        private string FormatTimeInput(string input)
        {
            // Split the input by ':' and ensure each component is properly padded with zeros
            var parts = input.Split(':');
            var formattedParts = new List<string>();

            // Ensure each part (hour, minute, second) is at least 2 digits
            foreach (var part in parts)
            {
                if (int.TryParse(part, out int number))
                {
                    formattedParts.Add(number.ToString("D2")); // Pad with leading zeros
                }
                else
                {
                    formattedParts.Add("00"); // Default to "00" if input is missing or invalid
                }
            }

            // Handle cases where input is incomplete (e.g., "hh:mm" instead of "hh:mm:ss")
            while (formattedParts.Count < 3)
            {
                formattedParts.Add("00"); // Add missing parts as "00"
            }

            return string.Join(":", formattedParts); // Combine the parts into a valid time format
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (isStarted)
            {

                if (isPaused)
                {
                    this.BackColor = Color.Green;
                    txtMasked.BackColor = Color.Green;
                    colorThemWhire();
                    isPaused = false;
                    startTime = DateTime.Now - elapsedTime; // Adjust start time to continue from where it left off
                    timer.Start();
                    btnStart.IconChar = FontAwesome.Sharp.IconChar.Pause;
                    
                    
                }
                else
                {
                    isPaused = true;
                    colorThemNormal();
                    this.BackColor = Color.Orange;
                    txtMasked.BackColor = Color.Orange;
                    timer.Stop();
                    btnStart.IconChar = FontAwesome.Sharp.IconChar.Play;
                }
            }
            else
            {
                isStarted = true;
                this.BackColor = Color.Green;
                txtMasked.BackColor = Color.Green;
                lblTimer.Text = "00:00:00";
                lblStart.Text = "00:00:00";
                lblEnd.Text = "00:00:00";
                colorThemWhire();
                string input = txtMasked.Text.Trim();
                string formattedInput = FormatTimeInput(input);
                txtMasked.Text = formattedInput;
                if (IsValidTime(formattedInput))
                {
                    targetTime = TimeSpan.Parse(formattedInput);
                }

                startTime = DateTime.Now; // Record the starting time
                elapsedTime = TimeSpan.Zero; // Reset elapsed time
                lblTimer.Text = "00:00:00";
                lblStart.Text = DateTime.Now.ToLongTimeString();
                btnStart.IconChar = FontAwesome.Sharp.IconChar.Pause;
                btnStop.Enabled = true;
                btnStop2.Enabled = true;
                txtMasked.ReadOnly = true;
                endTime = null; // Reset end time
                timer.Start();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Create a rounded rectangle path
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, cornerRadius, cornerRadius, 180, 90); // Top-left corner
            path.AddArc(this.Width - cornerRadius, 0, cornerRadius, cornerRadius, 270, 90); // Top-right corner
            path.AddArc(this.Width - cornerRadius, this.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90); // Bottom-right corner
            path.AddArc(0, this.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90); // Bottom-left corner
            path.CloseFigure();

            // Apply the rounded rectangle to the region of the control
            this.Region = new Region(path);

            // Optional: Draw a border
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (Pen pen = new Pen(Color.Transparent, 0))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }



        private void BtnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            endTime = DateTime.Now; // Record the end time
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            btnStop2.Enabled = false;
            txtMasked.ReadOnly = false;
            targetTime = null;
            txtMasked.Clear();
            colorThemNormal();
            txtMasked.BackColor = Color.FromArgb(236, 229, 240);
            this.BackColor = Color.FromArgb(236, 229, 240);
            lblEnd.Text = DateTime.Now.ToLongTimeString();
            isStarted = false;
            isPaused = false;
            btnStart.IconChar = FontAwesome.Sharp.IconChar.Play;
            Checkout checkform = new Checkout(this.Id,_title, elapsedTime.TotalHours, issuer, 2, preCheckoutProducts); // Pass the PostId to the new form
            checkform.Show();
            preCheckoutProducts.Clear();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!isPaused)
            {
                elapsedTime = DateTime.Now - startTime; // Calculate elapsed time
                lblTimer.Text = elapsedTime.ToString(@"hh\:mm\:ss"); // Update label
                if (targetTime.HasValue && targetTime.Value != TimeSpan.Zero && elapsedTime >= targetTime.Value)
                {
                    timer.Stop(); // Stop the timer
                    this.BackColor = Color.Crimson; // Change form background to red
                    txtMasked.BackColor = Color.Crimson;
                    MessageBox.Show("Target time reached!", Title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                lblPrice2.Text = CalculateTotalPrice(this.Id, elapsedTime.TotalHours, 2).ToString();
                lblPrice4.Text = CalculateTotalPrice(this.Id, elapsedTime.TotalHours, 4).ToString();
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to reset?",
                                "Rest",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                timer.Stop();
                this.BackColor = Color.White;
                lblTimer.Text = "00:00:00";
                lblStart.Text = "00:00:00";
                lblEnd.Text = "00:00:00";
                lblPrice2.Text = "0";
                lblPrice4.Text = "0";
                btnStart.Enabled = true;
                btnStop.Enabled = false;
                btnStop2.Enabled = false;
                txtMasked.Clear();
                txtMasked.ReadOnly = false;
                targetTime = null;
                isPaused = false;
                isStarted = false;
                btnStart.IconChar = FontAwesome.Sharp.IconChar.Play;
                txtMasked.BackColor = Color.FromArgb(236, 229, 240);
                this.BackColor = Color.FromArgb(236, 229, 240);
                preCheckoutProducts.Clear();
                colorThemNormal();
            }
        }

        private void colorThemWhire()
        {
            txtMasked.ForeColor = Color.White;
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            lblPrice2.ForeColor = Color.White;
            lblPrice4.ForeColor = Color.White;
            lblEnd.ForeColor = Color.White;
            lblStart.ForeColor = Color.White;
            lblTimer.ForeColor = Color.White;
            lblPost.ForeColor = Color.White;
            btnStart.IconColor = Color.White;
            btnStop.ForeColor = Color.White;
            btnStop2.ForeColor = Color.White;
            btnReset.IconColor = Color.White;
            btnAdd.IconColor = Color.White;
            btnAdd.FlatAppearance.BorderColor = Color.White;
            btnStart.FlatAppearance.BorderColor = Color.White;
            btnStop.FlatAppearance.BorderColor = Color.White;
            btnStop2.FlatAppearance.BorderColor = Color.White;
            btnReset.FlatAppearance.BorderColor = Color.White;

        }
        private void colorThemNormal()
        {
            txtMasked.ForeColor = Color.FromArgb(34, 34, 34);
            label1.ForeColor = Color.FromArgb(34, 34, 34);
            label2.ForeColor = Color.FromArgb(34, 34, 34);
            label3.ForeColor = Color.FromArgb(34, 34, 34);
            lblPrice2.ForeColor = Color.FromArgb(34, 34, 34);
            lblPrice4.ForeColor = Color.FromArgb(34, 34, 34);
            lblEnd.ForeColor = Color.FromArgb(34, 34, 34);
            lblStart.ForeColor = Color.FromArgb(34, 34, 34);
            lblTimer.ForeColor = Color.FromArgb(34, 34, 34);
            lblPost.ForeColor = Color.FromArgb(34, 34, 34);
            btnStart.IconColor = Color.FromArgb(34, 34, 34);
            btnStop.ForeColor = Color.FromArgb(34, 34, 34);
            btnStop2.ForeColor = Color.FromArgb(34, 34, 34);
            btnReset.IconColor = Color.FromArgb(34, 34, 34);
            btnAdd.IconColor = Color.FromArgb(34, 34, 34);
            btnAdd.FlatAppearance.BorderColor = Color.FromArgb(34, 34, 34);
            btnStart.FlatAppearance.BorderColor = Color.FromArgb(34, 34, 34);
            btnStop.FlatAppearance.BorderColor = Color.FromArgb(34, 34, 34);
            btnStop2.FlatAppearance.BorderColor = Color.FromArgb(34, 34, 34);
            btnReset.FlatAppearance.BorderColor = Color.FromArgb(34, 34, 34);

        }





        public string Title
        {
            get { return _title; }
            set { _title = value; lblPost.Text = _title; }
        }

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private void btnStop2_Click(object sender, EventArgs e)
        {
            timer.Stop();
            endTime = DateTime.Now; // Record the end time
            btnStop.Enabled = false;
            btnStop2.Enabled = false;
            targetTime = null;
            txtMasked.Clear();
            txtMasked.ReadOnly = false;
            colorThemNormal();
            txtMasked.BackColor = Color.FromArgb(236, 229, 240);
            this.BackColor = Color.FromArgb(236, 229, 240);
            lblEnd.Text = DateTime.Now.ToLongTimeString();
            isStarted = false;
            isPaused = false;
            btnStart.IconChar = FontAwesome.Sharp.IconChar.Play;

            Checkout checkform = new Checkout(this.Id,_title, elapsedTime.TotalHours, issuer, 4, preCheckoutProducts); // Pass the PostId to the new form
            checkform.Show();
            preCheckoutProducts.Clear();
        }
        private int CalculateTotalPrice(int postId, double timeUsed, int playerCount)
        {
            string connectionString = "Data Source=GammingCenter.db;Version=3;";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand())
                {
                    command.Connection = connection;
                    command.CommandText = @"
                SELECT CASE @PlayerCount 
                       WHEN 2 THEN Price2P
                       WHEN 4 THEN Price4P
                       ELSE 0 END AS PricePerHour
                FROM Type
                WHERE ID = (SELECT Type FROM Post WHERE ID = @PostId)";
                    command.Parameters.AddWithValue("@PlayerCount", playerCount);
                    command.Parameters.AddWithValue("@PostId", postId);

                    var result = command.ExecuteScalar();
                    if (result != null && double.TryParse(result.ToString(), out var pricePerHour))
                    {
                        return (int)(pricePerHour * timeUsed);
                    }
                    else
                    {
                        throw new Exception("Failed to retrieve price. Please check the post and type data.");
                    }
                }
            }
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            preCheckout precheckoutform = new preCheckout(preCheckoutProducts);// Pass the PostId to the new form
            precheckoutform.ShowDialog();
        }
    }

}
