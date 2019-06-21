namespace ElectronicShop
{
    partial class LoginPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginPage));
            this.Usernametxt = new System.Windows.Forms.TextBox();
            this.Passwordtxt = new System.Windows.Forms.TextBox();
            this.Loginbtn = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.CreateanAccount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Usernametxt
            // 
            this.Usernametxt.Location = new System.Drawing.Point(330, 312);
            this.Usernametxt.Name = "Usernametxt";
            this.Usernametxt.ShortcutsEnabled = false;
            this.Usernametxt.Size = new System.Drawing.Size(295, 20);
            this.Usernametxt.TabIndex = 2;
            this.Usernametxt.Text = "User Name";
            this.Usernametxt.Click += new System.EventHandler(this.Usernametxt_Click);
            // 
            // Passwordtxt
            // 
            this.Passwordtxt.Location = new System.Drawing.Point(330, 368);
            this.Passwordtxt.Name = "Passwordtxt";
            this.Passwordtxt.Size = new System.Drawing.Size(295, 20);
            this.Passwordtxt.TabIndex = 3;
            this.Passwordtxt.UseSystemPasswordChar = true;
            // 
            // Loginbtn
            // 
            this.Loginbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Loginbtn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Loginbtn.BackgroundImage")));
            this.Loginbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Loginbtn.FlatAppearance.BorderSize = 0;
            this.Loginbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Loginbtn.Location = new System.Drawing.Point(385, 409);
            this.Loginbtn.Name = "Loginbtn";
            this.Loginbtn.Size = new System.Drawing.Size(175, 40);
            this.Loginbtn.TabIndex = 5;
            this.Loginbtn.Text = "LOG IN";
            this.Loginbtn.UseVisualStyleBackColor = false;
            this.Loginbtn.Click += new System.EventHandler(this.OK_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 599);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(857, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // CreateanAccount
            // 
            this.CreateanAccount.AutoSize = true;
            this.CreateanAccount.BackColor = System.Drawing.SystemColors.HighlightText;
            this.CreateanAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CreateanAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateanAccount.Location = new System.Drawing.Point(418, 572);
            this.CreateanAccount.Name = "CreateanAccount";
            this.CreateanAccount.Size = new System.Drawing.Size(96, 13);
            this.CreateanAccount.TabIndex = 7;
            this.CreateanAccount.Text = "Create an Account";
            this.CreateanAccount.Click += new System.EventHandler(this.CreateanAccount_Click);
            this.CreateanAccount.MouseEnter += new System.EventHandler(this.label2_MouseEnter);
            this.CreateanAccount.MouseLeave += new System.EventHandler(this.CreateanAccount_MouseLeave);
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(857, 621);
            this.Controls.Add(this.CreateanAccount);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Loginbtn);
            this.Controls.Add(this.Passwordtxt);
            this.Controls.Add(this.Usernametxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginPage";
            this.Text = "ShopOwner Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Usernametxt;
        private System.Windows.Forms.TextBox Passwordtxt;
        private System.Windows.Forms.Button Loginbtn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label CreateanAccount;
    }
}