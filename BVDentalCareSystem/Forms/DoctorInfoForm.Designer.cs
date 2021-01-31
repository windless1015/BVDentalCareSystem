
namespace BVDentalCareSystem.Forms
{
    partial class DoctorInfoForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView_doctorInfo = new System.Windows.Forms.DataGridView();
            this.btn_doctorInfoExit = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.create_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_doctorInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_doctorInfo
            // 
            this.dataGridView_doctorInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_doctorInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.phone,
            this.password,
            this.create_time});
            this.dataGridView_doctorInfo.Location = new System.Drawing.Point(22, 24);
            this.dataGridView_doctorInfo.Name = "dataGridView_doctorInfo";
            this.dataGridView_doctorInfo.RowTemplate.Height = 23;
            this.dataGridView_doctorInfo.Size = new System.Drawing.Size(609, 481);
            this.dataGridView_doctorInfo.TabIndex = 0;
            // 
            // btn_doctorInfoExit
            // 
            this.btn_doctorInfoExit.Location = new System.Drawing.Point(727, 279);
            this.btn_doctorInfoExit.Name = "btn_doctorInfoExit";
            this.btn_doctorInfoExit.Size = new System.Drawing.Size(117, 45);
            this.btn_doctorInfoExit.TabIndex = 1;
            this.btn_doctorInfoExit.Text = "退出";
            this.btn_doctorInfoExit.UseVisualStyleBackColor = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id.DefaultCellStyle = dataGridViewCellStyle5;
            this.id.HeaderText = "序号";
            this.id.Name = "id";
            // 
            // phone
            // 
            this.phone.DataPropertyName = "phone";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.phone.DefaultCellStyle = dataGridViewCellStyle6;
            this.phone.HeaderText = "电话";
            this.phone.Name = "phone";
            // 
            // password
            // 
            this.password.DataPropertyName = "password";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.password.DefaultCellStyle = dataGridViewCellStyle7;
            this.password.HeaderText = "密码";
            this.password.Name = "password";
            // 
            // create_time
            // 
            this.create_time.DataPropertyName = "create_time";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.create_time.DefaultCellStyle = dataGridViewCellStyle8;
            this.create_time.HeaderText = "创建时间";
            this.create_time.Name = "create_time";
            this.create_time.Width = 150;
            // 
            // DoctorInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 581);
            this.Controls.Add(this.btn_doctorInfoExit);
            this.Controls.Add(this.dataGridView_doctorInfo);
            this.Name = "DoctorInfoForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DoctorInfoForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_doctorInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_doctorInfo;
        private System.Windows.Forms.Button btn_doctorInfoExit;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn password;
        private System.Windows.Forms.DataGridViewTextBoxColumn create_time;
    }
}