namespace Gamming_Center
{
    partial class switchUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(switchUser));
            this.Title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.exit = new FontAwesome.Sharp.IconButton();
            this.passwordtb = new System.Windows.Forms.TextBox();
            this.usertb = new System.Windows.Forms.TextBox();
            this.logintxt = new System.Windows.Forms.Label();
            this.passwordtxt = new System.Windows.Forms.Label();
            this.usertxt = new System.Windows.Forms.Label();
            this.loginbutton = new FontAwesome.Sharp.IconButton();
            this.passwordicon = new FontAwesome.Sharp.IconPictureBox();
            this.usericon = new FontAwesome.Sharp.IconPictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordicon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usericon)).BeginInit();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Dock = System.Windows.Forms.DockStyle.Left;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.Teal;
            this.Title.Location = new System.Drawing.Point(0, 0);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(188, 29);
            this.Title.TabIndex = 1;
            this.Title.Text = "Gaming Center";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Azure;
            this.panel1.Controls.Add(this.Title);
            this.panel1.Controls.Add(this.exit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 39);
            this.panel1.TabIndex = 1;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Firebrick;
            this.exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.exit.FlatAppearance.BorderSize = 0;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.IconChar = FontAwesome.Sharp.IconChar.X;
            this.exit.IconColor = System.Drawing.Color.Snow;
            this.exit.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.exit.IconSize = 30;
            this.exit.Location = new System.Drawing.Point(754, 0);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(46, 39);
            this.exit.TabIndex = 0;
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // passwordtb
            // 
            this.passwordtb.BackColor = System.Drawing.Color.Azure;
            this.passwordtb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordtb.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordtb.ForeColor = System.Drawing.Color.Teal;
            this.passwordtb.Location = new System.Drawing.Point(297, 270);
            this.passwordtb.Name = "passwordtb";
            this.passwordtb.Size = new System.Drawing.Size(257, 44);
            this.passwordtb.TabIndex = 25;
            this.passwordtb.UseSystemPasswordChar = true;
            // 
            // usertb
            // 
            this.usertb.BackColor = System.Drawing.Color.Azure;
            this.usertb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usertb.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usertb.ForeColor = System.Drawing.Color.Teal;
            this.usertb.Location = new System.Drawing.Point(297, 192);
            this.usertb.Name = "usertb";
            this.usertb.Size = new System.Drawing.Size(257, 44);
            this.usertb.TabIndex = 24;
            // 
            // logintxt
            // 
            this.logintxt.AutoSize = true;
            this.logintxt.BackColor = System.Drawing.Color.Transparent;
            this.logintxt.Font = new System.Drawing.Font("Forte", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logintxt.ForeColor = System.Drawing.Color.Azure;
            this.logintxt.Location = new System.Drawing.Point(297, 57);
            this.logintxt.Name = "logintxt";
            this.logintxt.Size = new System.Drawing.Size(221, 87);
            this.logintxt.TabIndex = 23;
            this.logintxt.Text = "Login";
            // 
            // passwordtxt
            // 
            this.passwordtxt.AutoSize = true;
            this.passwordtxt.BackColor = System.Drawing.Color.Transparent;
            this.passwordtxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordtxt.ForeColor = System.Drawing.Color.Azure;
            this.passwordtxt.Location = new System.Drawing.Point(292, 239);
            this.passwordtxt.Name = "passwordtxt";
            this.passwordtxt.Size = new System.Drawing.Size(101, 28);
            this.passwordtxt.TabIndex = 22;
            this.passwordtxt.Text = "Password";
            // 
            // usertxt
            // 
            this.usertxt.AutoSize = true;
            this.usertxt.BackColor = System.Drawing.Color.Transparent;
            this.usertxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usertxt.ForeColor = System.Drawing.Color.Azure;
            this.usertxt.Location = new System.Drawing.Point(292, 161);
            this.usertxt.Name = "usertxt";
            this.usertxt.Size = new System.Drawing.Size(116, 28);
            this.usertxt.TabIndex = 21;
            this.usertxt.Text = "User Name";
            // 
            // loginbutton
            // 
            this.loginbutton.BackColor = System.Drawing.Color.Transparent;
            this.loginbutton.FlatAppearance.BorderColor = System.Drawing.Color.Azure;
            this.loginbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginbutton.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginbutton.ForeColor = System.Drawing.Color.Azure;
            this.loginbutton.IconChar = FontAwesome.Sharp.IconChar.None;
            this.loginbutton.IconColor = System.Drawing.Color.GhostWhite;
            this.loginbutton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.loginbutton.Location = new System.Drawing.Point(249, 357);
            this.loginbutton.Name = "loginbutton";
            this.loginbutton.Size = new System.Drawing.Size(305, 59);
            this.loginbutton.TabIndex = 28;
            this.loginbutton.Text = "Change L\'utilisateur";
            this.loginbutton.UseVisualStyleBackColor = false;
            this.loginbutton.Click += new System.EventHandler(this.loginbutton_Click);
            // 
            // passwordicon
            // 
            this.passwordicon.BackColor = System.Drawing.Color.Transparent;
            this.passwordicon.ForeColor = System.Drawing.Color.Azure;
            this.passwordicon.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.passwordicon.IconColor = System.Drawing.Color.Azure;
            this.passwordicon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.passwordicon.IconSize = 45;
            this.passwordicon.Location = new System.Drawing.Point(246, 269);
            this.passwordicon.Name = "passwordicon";
            this.passwordicon.Size = new System.Drawing.Size(45, 45);
            this.passwordicon.TabIndex = 27;
            this.passwordicon.TabStop = false;
            // 
            // usericon
            // 
            this.usericon.BackColor = System.Drawing.Color.Transparent;
            this.usericon.ForeColor = System.Drawing.Color.Azure;
            this.usericon.IconChar = FontAwesome.Sharp.IconChar.User;
            this.usericon.IconColor = System.Drawing.Color.Azure;
            this.usericon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.usericon.IconSize = 45;
            this.usericon.Location = new System.Drawing.Point(246, 191);
            this.usericon.Name = "usericon";
            this.usericon.Size = new System.Drawing.Size(45, 45);
            this.usericon.TabIndex = 26;
            this.usericon.TabStop = false;
            // 
            // switchUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loginbutton);
            this.Controls.Add(this.passwordicon);
            this.Controls.Add(this.usericon);
            this.Controls.Add(this.passwordtb);
            this.Controls.Add(this.usertb);
            this.Controls.Add(this.logintxt);
            this.Controls.Add(this.passwordtxt);
            this.Controls.Add(this.usertxt);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "switchUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "switchUser";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.passwordicon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usericon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private FontAwesome.Sharp.IconButton exit;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton loginbutton;
        private FontAwesome.Sharp.IconPictureBox passwordicon;
        private FontAwesome.Sharp.IconPictureBox usericon;
        private System.Windows.Forms.TextBox passwordtb;
        private System.Windows.Forms.TextBox usertb;
        private System.Windows.Forms.Label logintxt;
        private System.Windows.Forms.Label passwordtxt;
        private System.Windows.Forms.Label usertxt;
    }
}