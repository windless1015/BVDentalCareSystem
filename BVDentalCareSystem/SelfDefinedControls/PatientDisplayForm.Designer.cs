
namespace BVDentalCareSystem.SelfDefinedControls
{
    partial class PatientDisplayForm
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
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.radioBtnFemale = new System.Windows.Forms.RadioButton();
            this.radioBtnMale = new System.Windows.Forms.RadioButton();
            this.dtpicker = new System.Windows.Forms.DateTimePicker();
            this.label_phone = new System.Windows.Forms.Label();
            this.textBox_phone = new System.Windows.Forms.TextBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.label_name = new System.Windows.Forms.Label();
            this.label_identity = new System.Windows.Forms.Label();
            this.label_gender = new System.Windows.Forms.Label();
            this.textBox_identity = new System.Windows.Forms.TextBox();
            this.label_birthdate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(234, 340);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(94, 23);
            this.btn_cancel.TabIndex = 0;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_confirm
            // 
            this.btn_confirm.Location = new System.Drawing.Point(60, 340);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(94, 23);
            this.btn_confirm.TabIndex = 0;
            this.btn_confirm.Text = "确定";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // radioBtnFemale
            // 
            this.radioBtnFemale.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioBtnFemale.Location = new System.Drawing.Point(270, 172);
            this.radioBtnFemale.Name = "radioBtnFemale";
            this.radioBtnFemale.Size = new System.Drawing.Size(44, 27);
            this.radioBtnFemale.TabIndex = 19;
            this.radioBtnFemale.TabStop = true;
            this.radioBtnFemale.Text = "女";
            this.radioBtnFemale.UseVisualStyleBackColor = true;
            this.radioBtnFemale.CheckedChanged += new System.EventHandler(this.radioBtnFemale_CheckedChanged);
            // 
            // radioBtnMale
            // 
            this.radioBtnMale.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioBtnMale.Location = new System.Drawing.Point(174, 172);
            this.radioBtnMale.Name = "radioBtnMale";
            this.radioBtnMale.Size = new System.Drawing.Size(40, 27);
            this.radioBtnMale.TabIndex = 17;
            this.radioBtnMale.TabStop = true;
            this.radioBtnMale.Text = "男";
            this.radioBtnMale.UseVisualStyleBackColor = true;
            this.radioBtnMale.CheckedChanged += new System.EventHandler(this.radioBtnMale_CheckedChanged);
            // 
            // dtpicker
            // 
            this.dtpicker.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpicker.Location = new System.Drawing.Point(139, 223);
            this.dtpicker.Name = "dtpicker";
            this.dtpicker.Size = new System.Drawing.Size(199, 26);
            this.dtpicker.TabIndex = 20;
            // 
            // label_phone
            // 
            this.label_phone.AutoSize = true;
            this.label_phone.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_phone.Location = new System.Drawing.Point(55, 70);
            this.label_phone.Name = "label_phone";
            this.label_phone.Size = new System.Drawing.Size(50, 25);
            this.label_phone.TabIndex = 24;
            this.label_phone.Text = "电话";
            // 
            // textBox_phone
            // 
            this.textBox_phone.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_phone.Location = new System.Drawing.Point(139, 71);
            this.textBox_phone.Name = "textBox_phone";
            this.textBox_phone.Size = new System.Drawing.Size(199, 26);
            this.textBox_phone.TabIndex = 15;
            this.textBox_phone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_phone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_phone_KeyPress);
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_name.Location = new System.Drawing.Point(139, 25);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(199, 26);
            this.textBox_name.TabIndex = 14;
            this.textBox_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_name.Location = new System.Drawing.Point(55, 24);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(50, 25);
            this.label_name.TabIndex = 18;
            this.label_name.Text = "姓名";
            // 
            // label_identity
            // 
            this.label_identity.AutoSize = true;
            this.label_identity.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_identity.Location = new System.Drawing.Point(55, 116);
            this.label_identity.Name = "label_identity";
            this.label_identity.Size = new System.Drawing.Size(50, 25);
            this.label_identity.TabIndex = 23;
            this.label_identity.Text = "社保";
            // 
            // label_gender
            // 
            this.label_gender.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_gender.Location = new System.Drawing.Point(23, 170);
            this.label_gender.Name = "label_gender";
            this.label_gender.Size = new System.Drawing.Size(82, 29);
            this.label_gender.TabIndex = 21;
            this.label_gender.Text = "性   别";
            this.label_gender.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_identity
            // 
            this.textBox_identity.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_identity.Location = new System.Drawing.Point(139, 117);
            this.textBox_identity.Name = "textBox_identity";
            this.textBox_identity.Size = new System.Drawing.Size(199, 26);
            this.textBox_identity.TabIndex = 16;
            this.textBox_identity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_identity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_identity_KeyPress);
            // 
            // label_birthdate
            // 
            this.label_birthdate.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_birthdate.Location = new System.Drawing.Point(12, 222);
            this.label_birthdate.Name = "label_birthdate";
            this.label_birthdate.Size = new System.Drawing.Size(93, 27);
            this.label_birthdate.TabIndex = 22;
            this.label_birthdate.Text = "出生日期";
            this.label_birthdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PatientDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 390);
            this.Controls.Add(this.radioBtnFemale);
            this.Controls.Add(this.radioBtnMale);
            this.Controls.Add(this.dtpicker);
            this.Controls.Add(this.label_phone);
            this.Controls.Add(this.textBox_phone);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.label_identity);
            this.Controls.Add(this.label_gender);
            this.Controls.Add(this.textBox_identity);
            this.Controls.Add(this.label_birthdate);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.btn_cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatientDisplayForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "患者信息展示";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.RadioButton radioBtnFemale;
        private System.Windows.Forms.RadioButton radioBtnMale;
        private System.Windows.Forms.DateTimePicker dtpicker;
        private System.Windows.Forms.Label label_phone;
        private System.Windows.Forms.TextBox textBox_phone;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_identity;
        private System.Windows.Forms.Label label_gender;
        private System.Windows.Forms.TextBox textBox_identity;
        private System.Windows.Forms.Label label_birthdate;
    }
}