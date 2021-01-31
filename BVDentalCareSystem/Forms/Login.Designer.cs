
using System.Drawing;

namespace BVDentalCareSystem.Forms
{
    partial class Login
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
            this.btn_login = new System.Windows.Forms.Button();
            this.btn_signup = new System.Windows.Forms.Button();
            this.textBox_userName = new System.Windows.Forms.TextBox();
            this.textBox_pwd = new System.Windows.Forms.TextBox();
            this.label_userName = new System.Windows.Forms.Label();
            this.label_pwd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(560, 333);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(130, 41);
            this.btn_login.TabIndex = 3;
            this.btn_login.Text = "登录";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_signup
            // 
            this.btn_signup.Location = new System.Drawing.Point(715, 333);
            this.btn_signup.Name = "btn_signup";
            this.btn_signup.Size = new System.Drawing.Size(130, 41);
            this.btn_signup.TabIndex = 4;
            this.btn_signup.Text = "注册";
            this.btn_signup.UseVisualStyleBackColor = true;
            this.btn_signup.Click += new System.EventHandler(this.btn_signup_Click);
            // 
            // textBox_userName
            // 
            this.textBox_userName.Font = new System.Drawing.Font("宋体", 11F);
            this.textBox_userName.Location = new System.Drawing.Point(560, 182);
            this.textBox_userName.Multiline = true;
            this.textBox_userName.Name = "textBox_userName";
            this.textBox_userName.Size = new System.Drawing.Size(285, 36);
            this.textBox_userName.TabIndex = 1;
            this.textBox_userName.Text = "13760347852";
            this.textBox_userName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_userName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_userName_KeyPress);
            // 
            // textBox_pwd
            // 
            this.textBox_pwd.Font = new System.Drawing.Font("宋体", 11F);
            this.textBox_pwd.Location = new System.Drawing.Point(560, 245);
            this.textBox_pwd.Multiline = true;
            this.textBox_pwd.Name = "textBox_pwd";
            this.textBox_pwd.Size = new System.Drawing.Size(285, 36);
            this.textBox_pwd.TabIndex = 2;
            this.textBox_pwd.Text = "123456";
            this.textBox_pwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_userName
            // 
            this.label_userName.Location = new System.Drawing.Point(414, 195);
            this.label_userName.Name = "label_userName";
            this.label_userName.Size = new System.Drawing.Size(100, 23);
            this.label_userName.TabIndex = 2;
            this.label_userName.Text = "用户名:";
            this.label_userName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_pwd
            // 
            this.label_pwd.Location = new System.Drawing.Point(414, 258);
            this.label_pwd.Name = "label_pwd";
            this.label_pwd.Size = new System.Drawing.Size(100, 23);
            this.label_pwd.TabIndex = 2;
            this.label_pwd.Text = "密码:";
            this.label_pwd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 577);
            this.Controls.Add(this.label_pwd);
            this.Controls.Add(this.label_userName);
            this.Controls.Add(this.textBox_pwd);
            this.Controls.Add(this.textBox_userName);
            this.Controls.Add(this.btn_signup);
            this.Controls.Add(this.btn_login);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.Button btn_signup;
        private System.Windows.Forms.TextBox textBox_userName;
        private System.Windows.Forms.TextBox textBox_pwd;
        private System.Windows.Forms.Label label_userName;
        private System.Windows.Forms.Label label_pwd;
    }
}