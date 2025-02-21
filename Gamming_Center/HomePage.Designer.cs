namespace Gamming_Center
{
    partial class HomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomePage));
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.btnQuikSell = new FontAwesome.Sharp.IconButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnMinimize = new FontAwesome.Sharp.IconButton();
            this.btnClose = new FontAwesome.Sharp.IconButton();
            this.btnMaximize = new FontAwesome.Sharp.IconButton();
            this.lblUser = new System.Windows.Forms.Label();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.iconButton6 = new FontAwesome.Sharp.IconButton();
            this.vipPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.billiardPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Panel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblVIP = new System.Windows.Forms.Label();
            this.standardPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelTitleBar.SuspendLayout();
            this.panel3.SuspendLayout();
            this.Panel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.Azure;
            this.panelTitleBar.Controls.Add(this.btnQuikSell);
            this.panelTitleBar.Controls.Add(this.panel3);
            this.panelTitleBar.Controls.Add(this.lblUser);
            this.panelTitleBar.Controls.Add(this.iconButton1);
            this.panelTitleBar.Controls.Add(this.iconButton6);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1582, 60);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // btnQuikSell
            // 
            this.btnQuikSell.BackColor = System.Drawing.Color.LightCyan;
            this.btnQuikSell.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnQuikSell.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btnQuikSell.FlatAppearance.BorderSize = 0;
            this.btnQuikSell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuikSell.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuikSell.ForeColor = System.Drawing.Color.Teal;
            this.btnQuikSell.IconChar = FontAwesome.Sharp.IconChar.MoneyBillAlt;
            this.btnQuikSell.IconColor = System.Drawing.Color.Teal;
            this.btnQuikSell.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnQuikSell.IconSize = 50;
            this.btnQuikSell.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuikSell.Location = new System.Drawing.Point(1212, 0);
            this.btnQuikSell.Name = "btnQuikSell";
            this.btnQuikSell.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnQuikSell.Size = new System.Drawing.Size(230, 60);
            this.btnQuikSell.TabIndex = 9;
            this.btnQuikSell.Tag = "signout";
            this.btnQuikSell.Text = "CheckOut";
            this.btnQuikSell.UseVisualStyleBackColor = false;
            this.btnQuikSell.Click += new System.EventHandler(this.btnQuikSell_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnMinimize);
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.btnMaximize);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1442, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(140, 60);
            this.panel3.TabIndex = 10;
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.BackColor = System.Drawing.Color.Cyan;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.ForeColor = System.Drawing.Color.Transparent;
            this.btnMinimize.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.btnMinimize.IconColor = System.Drawing.Color.White;
            this.btnMinimize.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnMinimize.IconSize = 25;
            this.btnMinimize.Location = new System.Drawing.Point(5, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(45, 25);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Crimson;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.Transparent;
            this.btnClose.IconChar = FontAwesome.Sharp.IconChar.X;
            this.btnClose.IconColor = System.Drawing.Color.White;
            this.btnClose.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnClose.IconSize = 20;
            this.btnClose.Location = new System.Drawing.Point(95, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 25);
            this.btnClose.TabIndex = 2;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.ForeColor = System.Drawing.Color.Transparent;
            this.btnMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.btnMaximize.IconColor = System.Drawing.Color.White;
            this.btnMaximize.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnMaximize.IconSize = 20;
            this.btnMaximize.Location = new System.Drawing.Point(50, 3);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(45, 25);
            this.btnMaximize.TabIndex = 4;
            this.btnMaximize.UseVisualStyleBackColor = false;
            this.btnMaximize.Click += new System.EventHandler(this.btnMaximize_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.Teal;
            this.lblUser.Location = new System.Drawing.Point(466, 9);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(103, 38);
            this.lblUser.TabIndex = 8;
            this.lblUser.Text = "label6";
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.LightCyan;
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton1.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.Color.Teal;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Sync;
            this.iconButton1.IconColor = System.Drawing.Color.Teal;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 40;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(230, 0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconButton1.Size = new System.Drawing.Size(230, 60);
            this.iconButton1.TabIndex = 7;
            this.iconButton1.Tag = "signout";
            this.iconButton1.Text = "Change User";
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // iconButton6
            // 
            this.iconButton6.BackColor = System.Drawing.Color.LightCyan;
            this.iconButton6.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton6.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.iconButton6.FlatAppearance.BorderSize = 0;
            this.iconButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton6.Font = new System.Drawing.Font("Dubai", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton6.ForeColor = System.Drawing.Color.Teal;
            this.iconButton6.IconChar = FontAwesome.Sharp.IconChar.SignOut;
            this.iconButton6.IconColor = System.Drawing.Color.Teal;
            this.iconButton6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton6.IconSize = 40;
            this.iconButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton6.Location = new System.Drawing.Point(0, 0);
            this.iconButton6.Name = "iconButton6";
            this.iconButton6.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.iconButton6.Size = new System.Drawing.Size(230, 60);
            this.iconButton6.TabIndex = 6;
            this.iconButton6.Tag = "signout";
            this.iconButton6.Text = "Exit";
            this.iconButton6.UseVisualStyleBackColor = false;
            this.iconButton6.Click += new System.EventHandler(this.iconButton6_Click);
            // 
            // vipPanel
            // 
            this.vipPanel.AutoScroll = true;
            this.vipPanel.BackColor = System.Drawing.Color.Transparent;
            this.vipPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.vipPanel.Location = new System.Drawing.Point(0, 99);
            this.vipPanel.Name = "vipPanel";
            this.vipPanel.Size = new System.Drawing.Size(1582, 300);
            this.vipPanel.TabIndex = 2;
            // 
            // billiardPanel
            // 
            this.billiardPanel.AutoScroll = true;
            this.billiardPanel.BackColor = System.Drawing.Color.Transparent;
            this.billiardPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.billiardPanel.Location = new System.Drawing.Point(0, 777);
            this.billiardPanel.Name = "billiardPanel";
            this.billiardPanel.Size = new System.Drawing.Size(1582, 300);
            this.billiardPanel.TabIndex = 3;
            // 
            // Panel
            // 
            this.Panel.BackColor = System.Drawing.Color.CadetBlue;
            this.Panel.Controls.Add(this.label3);
            this.Panel.Controls.Add(this.lblVIP);
            this.Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel.Location = new System.Drawing.Point(0, 60);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(1582, 39);
            this.Panel.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(1505, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 42);
            this.label3.TabIndex = 1;
            this.label3.Text = "VIP";
            // 
            // lblVIP
            // 
            this.lblVIP.AutoSize = true;
            this.lblVIP.BackColor = System.Drawing.Color.Transparent;
            this.lblVIP.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblVIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVIP.ForeColor = System.Drawing.Color.Silver;
            this.lblVIP.Location = new System.Drawing.Point(0, 0);
            this.lblVIP.Name = "lblVIP";
            this.lblVIP.Size = new System.Drawing.Size(77, 42);
            this.lblVIP.TabIndex = 0;
            this.lblVIP.Text = "VIP";
            // 
            // standardPanel
            // 
            this.standardPanel.AutoScroll = true;
            this.standardPanel.BackColor = System.Drawing.Color.Transparent;
            this.standardPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.standardPanel.Location = new System.Drawing.Point(0, 438);
            this.standardPanel.Name = "standardPanel";
            this.standardPanel.Size = new System.Drawing.Size(1582, 300);
            this.standardPanel.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CadetBlue;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 399);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1582, 39);
            this.panel1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(1327, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(255, 42);
            this.label4.TabIndex = 1;
            this.label4.Text = "Post Standard";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(255, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Post Standard";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CadetBlue;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 738);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1582, 39);
            this.panel2.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(1453, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 42);
            this.label5.TabIndex = 1;
            this.label5.Text = "Billiard";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 42);
            this.label2.TabIndex = 0;
            this.label2.Text = "Billiard";
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 1055);
            this.Controls.Add(this.billiardPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.standardPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.vipPanel);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.panelTitleBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomePage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.Resize += new System.EventHandler(this.HomePage_Resize);
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.Panel.ResumeLayout(false);
            this.Panel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTitleBar;
        private FontAwesome.Sharp.IconButton btnMaximize;
        private FontAwesome.Sharp.IconButton btnMinimize;
        private FontAwesome.Sharp.IconButton btnClose;
        private FontAwesome.Sharp.IconButton iconButton6;
        private System.Windows.Forms.FlowLayoutPanel vipPanel;
        private System.Windows.Forms.FlowLayoutPanel billiardPanel;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Label lblVIP;
        private System.Windows.Forms.FlowLayoutPanel standardPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Label lblUser;
        private FontAwesome.Sharp.IconButton btnQuikSell;
        private System.Windows.Forms.Panel panel3;
    }
}