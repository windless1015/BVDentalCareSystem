namespace BVDentalCareSystem.Forms
{
    partial class PatientsInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientsInfoForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GroupBox_Operation = new System.Windows.Forms.GroupBox();
            this.Button_add = new System.Windows.Forms.Button();
            this.Button_query = new System.Windows.Forms.Button();
            this.Button_modify = new System.Windows.Forms.Button();
            this.Button_delete = new System.Windows.Forms.Button();
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
            this.DataView_Patients = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birth_date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identity_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.create_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupBox_Operation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataView_Patients)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupBox_Operation
            // 
            this.GroupBox_Operation.Controls.Add(this.Button_add);
            this.GroupBox_Operation.Controls.Add(this.Button_query);
            this.GroupBox_Operation.Controls.Add(this.Button_modify);
            this.GroupBox_Operation.Controls.Add(this.Button_delete);
            this.GroupBox_Operation.Controls.Add(this.radioBtnFemale);
            this.GroupBox_Operation.Controls.Add(this.radioBtnMale);
            this.GroupBox_Operation.Controls.Add(this.dtpicker);
            this.GroupBox_Operation.Controls.Add(this.label_phone);
            this.GroupBox_Operation.Controls.Add(this.textBox_phone);
            this.GroupBox_Operation.Controls.Add(this.textBox_name);
            this.GroupBox_Operation.Controls.Add(this.label_name);
            this.GroupBox_Operation.Controls.Add(this.label_identity);
            this.GroupBox_Operation.Controls.Add(this.label_gender);
            this.GroupBox_Operation.Controls.Add(this.textBox_identity);
            this.GroupBox_Operation.Controls.Add(this.label_birthdate);
            this.GroupBox_Operation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GroupBox_Operation.Location = new System.Drawing.Point(0, 607);
            this.GroupBox_Operation.Name = "GroupBox_Operation";
            this.GroupBox_Operation.Size = new System.Drawing.Size(1250, 194);
            this.GroupBox_Operation.TabIndex = 23;
            this.GroupBox_Operation.TabStop = false;
            // 
            // Button_add
            // 
            this.Button_add.BackgroundImage = global::BVDentalCareSystem.Properties.Resources.btn_add_record;
            this.Button_add.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button_add.FlatAppearance.BorderSize = 0;
            this.Button_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_add.Location = new System.Drawing.Point(1006, 20);
            this.Button_add.Name = "Button_add";
            this.Button_add.Size = new System.Drawing.Size(113, 41);
            this.Button_add.TabIndex = 15;
            this.Button_add.Tag = "add";
            this.Button_add.UseVisualStyleBackColor = true;
            this.Button_add.Click += new System.EventHandler(this.Button_add_Click);
            // 
            // Button_query
            // 
            this.Button_query.BackgroundImage = global::BVDentalCareSystem.Properties.Resources.btn_query_record;
            this.Button_query.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button_query.FlatAppearance.BorderSize = 0;
            this.Button_query.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_query.Location = new System.Drawing.Point(820, 24);
            this.Button_query.Name = "Button_query";
            this.Button_query.Size = new System.Drawing.Size(113, 41);
            this.Button_query.TabIndex = 14;
            this.Button_query.Tag = "query";
            this.Button_query.UseVisualStyleBackColor = true;
            this.Button_query.Click += new System.EventHandler(this.Button_query_Click);
            // 
            // Button_modify
            // 
            this.Button_modify.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button_modify.BackgroundImage")));
            this.Button_modify.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button_modify.FlatAppearance.BorderSize = 0;
            this.Button_modify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_modify.Location = new System.Drawing.Point(820, 91);
            this.Button_modify.Name = "Button_modify";
            this.Button_modify.Size = new System.Drawing.Size(113, 41);
            this.Button_modify.TabIndex = 16;
            this.Button_modify.Tag = "modify";
            this.Button_modify.UseVisualStyleBackColor = true;
            this.Button_modify.Click += new System.EventHandler(this.Button_modify_Click);
            // 
            // Button_delete
            // 
            this.Button_delete.BackgroundImage = global::BVDentalCareSystem.Properties.Resources.btn_del_record;
            this.Button_delete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button_delete.FlatAppearance.BorderSize = 0;
            this.Button_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_delete.Location = new System.Drawing.Point(1006, 91);
            this.Button_delete.Name = "Button_delete";
            this.Button_delete.Size = new System.Drawing.Size(113, 41);
            this.Button_delete.TabIndex = 17;
            this.Button_delete.UseVisualStyleBackColor = true;
            this.Button_delete.Click += new System.EventHandler(this.Button_delete_Click);
            // 
            // radioBtnFemale
            // 
            this.radioBtnFemale.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioBtnFemale.Location = new System.Drawing.Point(660, 23);
            this.radioBtnFemale.Name = "radioBtnFemale";
            this.radioBtnFemale.Size = new System.Drawing.Size(44, 27);
            this.radioBtnFemale.TabIndex = 5;
            this.radioBtnFemale.TabStop = true;
            this.radioBtnFemale.Text = "女";
            this.radioBtnFemale.UseVisualStyleBackColor = true;
            // 
            // radioBtnMale
            // 
            this.radioBtnMale.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.radioBtnMale.Location = new System.Drawing.Point(553, 21);
            this.radioBtnMale.Name = "radioBtnMale";
            this.radioBtnMale.Size = new System.Drawing.Size(40, 27);
            this.radioBtnMale.TabIndex = 4;
            this.radioBtnMale.TabStop = true;
            this.radioBtnMale.Text = "男";
            this.radioBtnMale.UseVisualStyleBackColor = true;
            // 
            // dtpicker
            // 
            this.dtpicker.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpicker.Location = new System.Drawing.Point(553, 102);
            this.dtpicker.Name = "dtpicker";
            this.dtpicker.Size = new System.Drawing.Size(185, 26);
            this.dtpicker.TabIndex = 6;
            // 
            // label_phone
            // 
            this.label_phone.AutoSize = true;
            this.label_phone.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_phone.Location = new System.Drawing.Point(26, 64);
            this.label_phone.Name = "label_phone";
            this.label_phone.Size = new System.Drawing.Size(50, 25);
            this.label_phone.TabIndex = 13;
            this.label_phone.Text = "电话";
            // 
            // textBox_phone
            // 
            this.textBox_phone.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_phone.Location = new System.Drawing.Point(139, 63);
            this.textBox_phone.Name = "textBox_phone";
            this.textBox_phone.Size = new System.Drawing.Size(199, 26);
            this.textBox_phone.TabIndex = 2;
            this.textBox_phone.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_phone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_phone_KeyPress);
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_name.Location = new System.Drawing.Point(139, 23);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(199, 26);
            this.textBox_name.TabIndex = 1;
            this.textBox_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_name.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_name_KeyPress);
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_name.Location = new System.Drawing.Point(26, 24);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(50, 25);
            this.label_name.TabIndex = 4;
            this.label_name.Text = "姓名";
            // 
            // label_identity
            // 
            this.label_identity.AutoSize = true;
            this.label_identity.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_identity.Location = new System.Drawing.Point(26, 105);
            this.label_identity.Name = "label_identity";
            this.label_identity.Size = new System.Drawing.Size(50, 25);
            this.label_identity.TabIndex = 10;
            this.label_identity.Text = "社保";
            // 
            // label_gender
            // 
            this.label_gender.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_gender.Location = new System.Drawing.Point(416, 22);
            this.label_gender.Name = "label_gender";
            this.label_gender.Size = new System.Drawing.Size(82, 29);
            this.label_gender.TabIndex = 6;
            this.label_gender.Text = "性   别";
            this.label_gender.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_identity
            // 
            this.textBox_identity.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_identity.Location = new System.Drawing.Point(139, 104);
            this.textBox_identity.Name = "textBox_identity";
            this.textBox_identity.Size = new System.Drawing.Size(199, 26);
            this.textBox_identity.TabIndex = 3;
            this.textBox_identity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_identity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_identity_KeyPress);
            // 
            // label_birthdate
            // 
            this.label_birthdate.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_birthdate.Location = new System.Drawing.Point(416, 102);
            this.label_birthdate.Name = "label_birthdate";
            this.label_birthdate.Size = new System.Drawing.Size(93, 27);
            this.label_birthdate.TabIndex = 8;
            this.label_birthdate.Text = "出生日期";
            this.label_birthdate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DataView_Patients
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataView_Patients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataView_Patients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataView_Patients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.gender,
            this.birth_date,
            this.identity_number,
            this.phone,
            this.create_time});
            this.DataView_Patients.Location = new System.Drawing.Point(0, 0);
            this.DataView_Patients.MultiSelect = false;
            this.DataView_Patients.Name = "DataView_Patients";
            this.DataView_Patients.RowHeadersWidth = 62;
            this.DataView_Patients.RowTemplate.Height = 23;
            this.DataView_Patients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataView_Patients.Size = new System.Drawing.Size(1250, 601);
            this.DataView_Patients.TabIndex = 24;
            this.DataView_Patients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataView_Patients_CellClick);
            this.DataView_Patients.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataView_Patients_CellMouseEnter);
            this.DataView_Patients.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataView_Patients_CellMouseLeave);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.id.DefaultCellStyle = dataGridViewCellStyle2;
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 8;
            this.id.Name = "id";
            this.id.Width = 180;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.name.DefaultCellStyle = dataGridViewCellStyle3;
            this.name.HeaderText = "姓名";
            this.name.MinimumWidth = 8;
            this.name.Name = "name";
            this.name.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.name.Width = 175;
            // 
            // gender
            // 
            this.gender.DataPropertyName = "gender";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.gender.DefaultCellStyle = dataGridViewCellStyle4;
            this.gender.HeaderText = "性别";
            this.gender.MinimumWidth = 8;
            this.gender.Name = "gender";
            this.gender.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gender.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gender.Width = 170;
            // 
            // birth_date
            // 
            this.birth_date.DataPropertyName = "birth_date";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.birth_date.DefaultCellStyle = dataGridViewCellStyle5;
            this.birth_date.HeaderText = "出生日期";
            this.birth_date.MinimumWidth = 8;
            this.birth_date.Name = "birth_date";
            this.birth_date.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.birth_date.Width = 170;
            // 
            // identity_number
            // 
            this.identity_number.DataPropertyName = "identity_number";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.identity_number.DefaultCellStyle = dataGridViewCellStyle6;
            this.identity_number.HeaderText = "社保号";
            this.identity_number.MinimumWidth = 8;
            this.identity_number.Name = "identity_number";
            this.identity_number.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.identity_number.Width = 170;
            // 
            // phone
            // 
            this.phone.DataPropertyName = "phone";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.phone.DefaultCellStyle = dataGridViewCellStyle7;
            this.phone.HeaderText = "电话号码";
            this.phone.MinimumWidth = 8;
            this.phone.Name = "phone";
            this.phone.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.phone.Width = 170;
            // 
            // create_time
            // 
            this.create_time.DataPropertyName = "create_time";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.create_time.DefaultCellStyle = dataGridViewCellStyle8;
            this.create_time.HeaderText = "创建日期";
            this.create_time.MinimumWidth = 8;
            this.create_time.Name = "create_time";
            this.create_time.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.create_time.Width = 215;
            // 
            // PatientsInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 801);
            this.Controls.Add(this.GroupBox_Operation);
            this.Controls.Add(this.DataView_Patients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PatientsInfoForm";
            this.Text = "PatientsInfoForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PatientsInfoForm_FormClosing);
            this.Load += new System.EventHandler(this.PatientsInfoForm_Load);
            this.Resize += new System.EventHandler(this.PatientsInfoForm_Resize);
            this.GroupBox_Operation.ResumeLayout(false);
            this.GroupBox_Operation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataView_Patients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GroupBox_Operation;
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
        private System.Windows.Forms.Button Button_add;
        private System.Windows.Forms.Button Button_query;
        private System.Windows.Forms.Button Button_modify;
        private System.Windows.Forms.Button Button_delete;
        private System.Windows.Forms.DataGridView DataView_Patients;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn birth_date;
        private System.Windows.Forms.DataGridViewTextBoxColumn identity_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn create_time;
    }
}