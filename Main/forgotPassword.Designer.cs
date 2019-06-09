namespace Main
{
    partial class forgotPassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(forgotPassword));
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuSeparator1 = new Bunifu.Framework.UI.BunifuSeparator();
            this.FP_id = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.btn_FP_Submit = new Bunifu.Framework.UI.BunifuFlatButton();
            this.FP_Contact = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.FP_name = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.FP_Password = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.bunifuCustomLabel1 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.FP_UserName = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.bunifuCustomLabel2 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.FP_Table = new System.Windows.Forms.ComboBox();
            this.bunifuCustomLabel3 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuSeparator2 = new Bunifu.Framework.UI.BunifuSeparator();
            this.msg = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Exit = new System.Windows.Forms.PictureBox();
            this.bunifuCustomLabel4 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel5 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.bunifuCustomLabel6 = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(232, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(544, 56);
            this.label1.TabIndex = 0;
            this.label1.Text = "Forgot Password Panel";
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator1.LineThickness = 4;
            this.bunifuSeparator1.Location = new System.Drawing.Point(0, 79);
            this.bunifuSeparator1.Margin = new System.Windows.Forms.Padding(2);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Size = new System.Drawing.Size(1025, 21);
            this.bunifuSeparator1.TabIndex = 1;
            this.bunifuSeparator1.Transparency = 255;
            this.bunifuSeparator1.Vertical = false;
            // 
            // FP_id
            // 
            this.FP_id.BorderColorFocused = System.Drawing.Color.Maroon;
            this.FP_id.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FP_id.BorderColorMouseHover = System.Drawing.Color.Lavender;
            this.FP_id.BorderThickness = 3;
            this.FP_id.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FP_id.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FP_id.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FP_id.isPassword = false;
            this.FP_id.Location = new System.Drawing.Point(457, 128);
            this.FP_id.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.FP_id.Name = "FP_id";
            this.FP_id.Size = new System.Drawing.Size(235, 57);
            this.FP_id.TabIndex = 2;
            this.FP_id.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.FP_id.OnValueChanged += new System.EventHandler(this.FP_id_OnValueChanged);
            // 
            // btn_FP_Submit
            // 
            this.btn_FP_Submit.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_FP_Submit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_FP_Submit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_FP_Submit.BorderRadius = 0;
            this.btn_FP_Submit.ButtonText = "Submit";
            this.btn_FP_Submit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_FP_Submit.DisabledColor = System.Drawing.Color.Gray;
            this.btn_FP_Submit.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_FP_Submit.Iconcolor = System.Drawing.Color.Transparent;
            this.btn_FP_Submit.Iconimage = null;
            this.btn_FP_Submit.Iconimage_right = null;
            this.btn_FP_Submit.Iconimage_right_Selected = null;
            this.btn_FP_Submit.Iconimage_Selected = null;
            this.btn_FP_Submit.IconMarginLeft = 0;
            this.btn_FP_Submit.IconMarginRight = 0;
            this.btn_FP_Submit.IconRightVisible = true;
            this.btn_FP_Submit.IconRightZoom = 0D;
            this.btn_FP_Submit.IconVisible = true;
            this.btn_FP_Submit.IconZoom = 90D;
            this.btn_FP_Submit.IsTab = false;
            this.btn_FP_Submit.Location = new System.Drawing.Point(178, 392);
            this.btn_FP_Submit.Margin = new System.Windows.Forms.Padding(4);
            this.btn_FP_Submit.Name = "btn_FP_Submit";
            this.btn_FP_Submit.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.btn_FP_Submit.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.btn_FP_Submit.OnHoverTextColor = System.Drawing.Color.White;
            this.btn_FP_Submit.selected = false;
            this.btn_FP_Submit.Size = new System.Drawing.Size(591, 48);
            this.btn_FP_Submit.TabIndex = 3;
            this.btn_FP_Submit.Text = "Submit";
            this.btn_FP_Submit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btn_FP_Submit.Textcolor = System.Drawing.Color.White;
            this.btn_FP_Submit.TextFont = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_FP_Submit.Click += new System.EventHandler(this.btn_FP_Submit_Click);
            // 
            // FP_Contact
            // 
            this.FP_Contact.BorderColorFocused = System.Drawing.Color.Maroon;
            this.FP_Contact.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FP_Contact.BorderColorMouseHover = System.Drawing.Color.Lavender;
            this.FP_Contact.BorderThickness = 3;
            this.FP_Contact.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FP_Contact.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FP_Contact.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FP_Contact.isPassword = false;
            this.FP_Contact.Location = new System.Drawing.Point(457, 262);
            this.FP_Contact.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.FP_Contact.Name = "FP_Contact";
            this.FP_Contact.Size = new System.Drawing.Size(235, 57);
            this.FP_Contact.TabIndex = 2;
            this.FP_Contact.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.FP_Contact.OnValueChanged += new System.EventHandler(this.FP_Contact_OnValueChanged);
            // 
            // FP_name
            // 
            this.FP_name.BorderColorFocused = System.Drawing.Color.Maroon;
            this.FP_name.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FP_name.BorderColorMouseHover = System.Drawing.Color.Lavender;
            this.FP_name.BorderThickness = 3;
            this.FP_name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FP_name.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FP_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FP_name.isPassword = false;
            this.FP_name.Location = new System.Drawing.Point(457, 195);
            this.FP_name.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.FP_name.Name = "FP_name";
            this.FP_name.Size = new System.Drawing.Size(235, 57);
            this.FP_name.TabIndex = 2;
            this.FP_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // FP_Password
            // 
            this.FP_Password.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FP_Password.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FP_Password.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FP_Password.BorderThickness = 3;
            this.FP_Password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FP_Password.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FP_Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FP_Password.isPassword = false;
            this.FP_Password.Location = new System.Drawing.Point(528, 484);
            this.FP_Password.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.FP_Password.Name = "FP_Password";
            this.FP_Password.Size = new System.Drawing.Size(241, 57);
            this.FP_Password.TabIndex = 2;
            this.FP_Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.AutoSize = true;
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(524, 455);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(180, 24);
            this.bunifuCustomLabel1.TabIndex = 4;
            this.bunifuCustomLabel1.Text = "Your Password Is:";
            // 
            // FP_UserName
            // 
            this.FP_UserName.BorderColorFocused = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FP_UserName.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FP_UserName.BorderColorMouseHover = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FP_UserName.BorderThickness = 3;
            this.FP_UserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FP_UserName.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FP_UserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FP_UserName.isPassword = false;
            this.FP_UserName.Location = new System.Drawing.Point(173, 484);
            this.FP_UserName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.FP_UserName.Name = "FP_UserName";
            this.FP_UserName.Size = new System.Drawing.Size(241, 57);
            this.FP_UserName.TabIndex = 2;
            this.FP_UserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.AutoSize = true;
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(174, 455);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(198, 24);
            this.bunifuCustomLabel2.TabIndex = 4;
            this.bunifuCustomLabel2.Text = "Your User Name Is:";
            // 
            // FP_Table
            // 
            this.FP_Table.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FP_Table.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FP_Table.FormattingEnabled = true;
            this.FP_Table.Items.AddRange(new object[] {
            "Admin",
            "Staff",
            "Student"});
            this.FP_Table.Location = new System.Drawing.Point(457, 345);
            this.FP_Table.Name = "FP_Table";
            this.FP_Table.Size = new System.Drawing.Size(176, 29);
            this.FP_Table.TabIndex = 5;
            this.FP_Table.SelectedIndexChanged += new System.EventHandler(this.FP_Table_SelectedIndexChanged);
            // 
            // bunifuCustomLabel3
            // 
            this.bunifuCustomLabel3.AutoSize = true;
            this.bunifuCustomLabel3.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel3.Location = new System.Drawing.Point(357, 345);
            this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
            this.bunifuCustomLabel3.Size = new System.Drawing.Size(57, 24);
            this.bunifuCustomLabel3.TabIndex = 4;
            this.bunifuCustomLabel3.Text = "I Am";
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(105)))), ((int)(((byte)(105)))));
            this.bunifuSeparator2.LineThickness = 5;
            this.bunifuSeparator2.Location = new System.Drawing.Point(0, -12);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Size = new System.Drawing.Size(1025, 27);
            this.bunifuSeparator2.TabIndex = 1;
            this.bunifuSeparator2.Transparency = 255;
            this.bunifuSeparator2.Vertical = false;
            // 
            // msg
            // 
            this.msg.AutoSize = true;
            this.msg.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msg.Location = new System.Drawing.Point(12, 13);
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(200, 24);
            this.msg.TabIndex = 4;
            this.msg.Text = "Console Messages";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.msg);
            this.panel1.Controls.Add(this.bunifuSeparator2);
            this.panel1.Location = new System.Drawing.Point(0, 629);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1025, 139);
            this.panel1.TabIndex = 6;
            // 
            // Exit
            // 
            this.Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Exit.BackgroundImage")));
            this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Exit.Location = new System.Drawing.Point(982, -1);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(43, 44);
            this.Exit.TabIndex = 11;
            this.Exit.TabStop = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            this.Exit.MouseLeave += new System.EventHandler(this.Exit_MouseLeave);
            this.Exit.MouseHover += new System.EventHandler(this.Exit_Hover);
            // 
            // bunifuCustomLabel4
            // 
            this.bunifuCustomLabel4.AutoSize = true;
            this.bunifuCustomLabel4.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel4.Location = new System.Drawing.Point(333, 147);
            this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
            this.bunifuCustomLabel4.Size = new System.Drawing.Size(82, 24);
            this.bunifuCustomLabel4.TabIndex = 4;
            this.bunifuCustomLabel4.Text = "My Id is";
            // 
            // bunifuCustomLabel5
            // 
            this.bunifuCustomLabel5.AutoSize = true;
            this.bunifuCustomLabel5.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel5.Location = new System.Drawing.Point(248, 213);
            this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
            this.bunifuCustomLabel5.Size = new System.Drawing.Size(167, 24);
            this.bunifuCustomLabel5.TabIndex = 4;
            this.bunifuCustomLabel5.Text = "My Full Name is";
            // 
            // bunifuCustomLabel6
            // 
            this.bunifuCustomLabel6.AutoSize = true;
            this.bunifuCustomLabel6.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel6.Location = new System.Drawing.Point(266, 279);
            this.bunifuCustomLabel6.Name = "bunifuCustomLabel6";
            this.bunifuCustomLabel6.Size = new System.Drawing.Size(149, 24);
            this.bunifuCustomLabel6.TabIndex = 4;
            this.bunifuCustomLabel6.Text = "My Contact is";
            // 
            // forgotPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.FP_Table);
            this.Controls.Add(this.bunifuCustomLabel3);
            this.Controls.Add(this.bunifuCustomLabel6);
            this.Controls.Add(this.bunifuCustomLabel5);
            this.Controls.Add(this.bunifuCustomLabel4);
            this.Controls.Add(this.bunifuCustomLabel2);
            this.Controls.Add(this.bunifuCustomLabel1);
            this.Controls.Add(this.btn_FP_Submit);
            this.Controls.Add(this.FP_UserName);
            this.Controls.Add(this.FP_name);
            this.Controls.Add(this.FP_Password);
            this.Controls.Add(this.FP_Contact);
            this.Controls.Add(this.FP_id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "forgotPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "forgotPassword";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Exit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator1;
        private Bunifu.Framework.UI.BunifuMetroTextbox FP_id;
        private Bunifu.Framework.UI.BunifuFlatButton btn_FP_Submit;
        private Bunifu.Framework.UI.BunifuMetroTextbox FP_Contact;
        private Bunifu.Framework.UI.BunifuMetroTextbox FP_name;
        private Bunifu.Framework.UI.BunifuMetroTextbox FP_Password;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel1;
        private Bunifu.Framework.UI.BunifuMetroTextbox FP_UserName;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel2;
        private System.Windows.Forms.ComboBox FP_Table;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel3;
        private Bunifu.Framework.UI.BunifuSeparator bunifuSeparator2;
        private Bunifu.Framework.UI.BunifuCustomLabel msg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox Exit;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel4;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel5;
        private Bunifu.Framework.UI.BunifuCustomLabel bunifuCustomLabel6;
    }
}