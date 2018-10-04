namespace RetriveChassiLogs
{
    partial class Form1
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
            this.VIN = new System.Windows.Forms.TextBox();
            this.DeviceID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.requestedLog = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.errorCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sendButton = new System.Windows.Forms.Button();
            this.cookie = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.userID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.descriptionTxtBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.errorcodeTxtBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.writeToExcelChkBox = new System.Windows.Forms.CheckBox();
            this.passwordTxtBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // VIN
            // 
            this.VIN.Location = new System.Drawing.Point(12, 22);
            this.VIN.Multiline = true;
            this.VIN.Name = "VIN";
            this.VIN.Size = new System.Drawing.Size(231, 136);
            this.VIN.TabIndex = 0;
            this.VIN.TextChanged += new System.EventHandler(this.vinTxtBox_TextChanged);
            // 
            // DeviceID
            // 
            this.DeviceID.Location = new System.Drawing.Point(12, 181);
            this.DeviceID.Multiline = true;
            this.DeviceID.Name = "DeviceID";
            this.DeviceID.Size = new System.Drawing.Size(355, 135);
            this.DeviceID.TabIndex = 1;
            this.DeviceID.TextChanged += new System.EventHandler(this.deviceIDTxtBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "VIN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Device ID";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.requestedLog,
            this.errorCode});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(431, 22);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(292, 294);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.responseListView_SelectedIndexChanged);
            // 
            // requestedLog
            // 
            this.requestedLog.Text = "DeviceID / VIN";
            this.requestedLog.Width = 500;
            // 
            // errorCode
            // 
            this.errorCode.Text = "Error Code";
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(648, 411);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 23);
            this.sendButton.TabIndex = 15;
            this.sendButton.Text = "SEND";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // cookie
            // 
            this.cookie.Location = new System.Drawing.Point(15, 411);
            this.cookie.Name = "cookie";
            this.cookie.Size = new System.Drawing.Size(604, 22);
            this.cookie.TabIndex = 13;
            this.cookie.TextChanged += new System.EventHandler(this.cookie_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 388);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Cookie";
            // 
            // userID
            // 
            this.userID.Location = new System.Drawing.Point(249, 22);
            this.userID.Name = "userID";
            this.userID.Size = new System.Drawing.Size(118, 22);
            this.userID.TabIndex = 8;
            this.userID.TextChanged += new System.EventHandler(this.userIDTxtBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(249, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "User ID";
            // 
            // descriptionTxtBox
            // 
            this.descriptionTxtBox.Location = new System.Drawing.Point(18, 363);
            this.descriptionTxtBox.Name = "descriptionTxtBox";
            this.descriptionTxtBox.Size = new System.Drawing.Size(601, 22);
            this.descriptionTxtBox.TabIndex = 12;
            this.descriptionTxtBox.TextChanged += new System.EventHandler(this.descriptionTxtBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Description";
            // 
            // errorcodeTxtBox
            // 
            this.errorcodeTxtBox.Location = new System.Drawing.Point(648, 363);
            this.errorcodeTxtBox.Name = "errorcodeTxtBox";
            this.errorcodeTxtBox.Size = new System.Drawing.Size(75, 22);
            this.errorcodeTxtBox.TabIndex = 14;
            this.errorcodeTxtBox.TextChanged += new System.EventHandler(this.errorcodeTxtBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(645, 343);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 17);
            this.label6.TabIndex = 13;
            this.label6.Text = "Error";
            // 
            // writeToExcelChkBox
            // 
            this.writeToExcelChkBox.AutoSize = true;
            this.writeToExcelChkBox.Checked = true;
            this.writeToExcelChkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.writeToExcelChkBox.Location = new System.Drawing.Point(252, 136);
            this.writeToExcelChkBox.Name = "writeToExcelChkBox";
            this.writeToExcelChkBox.Size = new System.Drawing.Size(116, 21);
            this.writeToExcelChkBox.TabIndex = 11;
            this.writeToExcelChkBox.Text = "Write to Excel";
            this.writeToExcelChkBox.UseVisualStyleBackColor = true;
            this.writeToExcelChkBox.CheckedChanged += new System.EventHandler(this.writeToExcelChkBox_CheckedChanged);
            // 
            // passwordTxtBox
            // 
            this.passwordTxtBox.Location = new System.Drawing.Point(252, 75);
            this.passwordTxtBox.Name = "passwordTxtBox";
            this.passwordTxtBox.Size = new System.Drawing.Size(115, 22);
            this.passwordTxtBox.TabIndex = 9;
            this.passwordTxtBox.UseSystemPasswordChar = true;
            this.passwordTxtBox.TextChanged += new System.EventHandler(this.passwordTxtBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(252, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Password";
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(252, 107);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(86, 23);
            this.Login.TabIndex = 10;
            this.Login.Text = "Get cookie";
            this.Login.UseVisualStyleBackColor = true;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 451);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.passwordTxtBox);
            this.Controls.Add(this.writeToExcelChkBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.errorcodeTxtBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.descriptionTxtBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.userID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cookie);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DeviceID);
            this.Controls.Add(this.VIN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Retrive Chassi Logs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox VIN;
        private System.Windows.Forms.TextBox DeviceID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox cookie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox userID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader requestedLog;
        private System.Windows.Forms.ColumnHeader errorCode;
        private System.Windows.Forms.TextBox descriptionTxtBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox errorcodeTxtBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox writeToExcelChkBox;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox passwordTxtBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button Login;
    }
}

