namespace BVDentalCareSystem.SelfDefinedControls
{
    partial class TeethCleanerPanel
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label_osc_state = new System.Windows.Forms.Label();
            this.label_osc_mode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioBtn_footPadel = new System.Windows.Forms.RadioButton();
            this.radioBtn_fingerControl = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.vScrollBar_pwr = new System.Windows.Forms.VScrollBar();
            this.textBox_pwr_level = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_pwr_increase = new System.Windows.Forms.Button();
            this.btn_pwr_descend = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.vScrollBar_waterPump = new System.Windows.Forms.VScrollBar();
            this.textBox_pump_level = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_pump_increase = new System.Windows.Forms.Button();
            this.btn_pump_descend = new System.Windows.Forms.Button();
            this.btn_init = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.LightGray;
            this.groupBox2.Controls.Add(this.label_osc_state);
            this.groupBox2.Controls.Add(this.label_osc_mode);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(49, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(245, 130);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "震荡指标";
            // 
            // label_osc_state
            // 
            this.label_osc_state.BackColor = System.Drawing.Color.DarkGray;
            this.label_osc_state.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_osc_state.Location = new System.Drawing.Point(132, 63);
            this.label_osc_state.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_osc_state.Name = "label_osc_state";
            this.label_osc_state.Size = new System.Drawing.Size(80, 28);
            this.label_osc_state.TabIndex = 5;
            this.label_osc_state.Text = "空闲状态";
            this.label_osc_state.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_osc_mode
            // 
            this.label_osc_mode.BackColor = System.Drawing.Color.DarkGray;
            this.label_osc_mode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_osc_mode.Location = new System.Drawing.Point(17, 63);
            this.label_osc_mode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_osc_mode.Name = "label_osc_mode";
            this.label_osc_mode.Size = new System.Drawing.Size(80, 28);
            this.label_osc_mode.TabIndex = 5;
            this.label_osc_mode.Text = "洁牙模式";
            this.label_osc_mode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(149, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "震荡状态";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "震荡模式";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightGray;
            this.groupBox3.Controls.Add(this.radioBtn_footPadel);
            this.groupBox3.Controls.Add(this.radioBtn_fingerControl);
            this.groupBox3.Location = new System.Drawing.Point(49, 151);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(245, 120);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作模式";
            // 
            // radioBtn_footPadel
            // 
            this.radioBtn_footPadel.AutoSize = true;
            this.radioBtn_footPadel.Location = new System.Drawing.Point(151, 57);
            this.radioBtn_footPadel.Name = "radioBtn_footPadel";
            this.radioBtn_footPadel.Size = new System.Drawing.Size(47, 16);
            this.radioBtn_footPadel.TabIndex = 5;
            this.radioBtn_footPadel.Text = "脚踏";
            this.radioBtn_footPadel.UseVisualStyleBackColor = true;
            // 
            // radioBtn_fingerControl
            // 
            this.radioBtn_fingerControl.AutoSize = true;
            this.radioBtn_fingerControl.Checked = true;
            this.radioBtn_fingerControl.Location = new System.Drawing.Point(27, 57);
            this.radioBtn_fingerControl.Name = "radioBtn_fingerControl";
            this.radioBtn_fingerControl.Size = new System.Drawing.Size(47, 16);
            this.radioBtn_fingerControl.TabIndex = 5;
            this.radioBtn_fingerControl.TabStop = true;
            this.radioBtn_fingerControl.Text = "指控";
            this.radioBtn_fingerControl.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.LightGray;
            this.groupBox5.Controls.Add(this.vScrollBar_pwr);
            this.groupBox5.Controls.Add(this.textBox_pwr_level);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.btn_pwr_increase);
            this.groupBox5.Controls.Add(this.btn_pwr_descend);
            this.groupBox5.Location = new System.Drawing.Point(49, 448);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(245, 165);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "能量级别";
            // 
            // vScrollBar_pwr
            // 
            this.vScrollBar_pwr.Location = new System.Drawing.Point(39, 28);
            this.vScrollBar_pwr.Maximum = 19;
            this.vScrollBar_pwr.Name = "vScrollBar_pwr";
            this.vScrollBar_pwr.Size = new System.Drawing.Size(17, 117);
            this.vScrollBar_pwr.TabIndex = 6;
            this.vScrollBar_pwr.Value = 10;
            // 
            // textBox_pwr_level
            // 
            this.textBox_pwr_level.Location = new System.Drawing.Point(136, 66);
            this.textBox_pwr_level.Name = "textBox_pwr_level";
            this.textBox_pwr_level.Size = new System.Drawing.Size(76, 21);
            this.textBox_pwr_level.TabIndex = 5;
            this.textBox_pwr_level.Text = "10";
            this.textBox_pwr_level.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(145, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "能量级别";
            // 
            // btn_pwr_increase
            // 
            this.btn_pwr_increase.Location = new System.Drawing.Point(173, 102);
            this.btn_pwr_increase.Name = "btn_pwr_increase";
            this.btn_pwr_increase.Size = new System.Drawing.Size(54, 21);
            this.btn_pwr_increase.TabIndex = 2;
            this.btn_pwr_increase.Text = "+";
            this.btn_pwr_increase.UseVisualStyleBackColor = true;
            // 
            // btn_pwr_descend
            // 
            this.btn_pwr_descend.Location = new System.Drawing.Point(106, 102);
            this.btn_pwr_descend.Name = "btn_pwr_descend";
            this.btn_pwr_descend.Size = new System.Drawing.Size(56, 21);
            this.btn_pwr_descend.TabIndex = 1;
            this.btn_pwr_descend.Text = "-";
            this.btn_pwr_descend.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.LightGray;
            this.groupBox4.Controls.Add(this.vScrollBar_waterPump);
            this.groupBox4.Controls.Add(this.textBox_pump_level);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.btn_pump_increase);
            this.groupBox4.Controls.Add(this.btn_pump_descend);
            this.groupBox4.Location = new System.Drawing.Point(49, 277);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(245, 165);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "水泵模式";
            // 
            // vScrollBar_waterPump
            // 
            this.vScrollBar_waterPump.Location = new System.Drawing.Point(39, 28);
            this.vScrollBar_waterPump.Maximum = 21;
            this.vScrollBar_waterPump.Name = "vScrollBar_waterPump";
            this.vScrollBar_waterPump.Size = new System.Drawing.Size(17, 117);
            this.vScrollBar_waterPump.TabIndex = 6;
            this.vScrollBar_waterPump.Value = 10;
            // 
            // textBox_pump_level
            // 
            this.textBox_pump_level.Location = new System.Drawing.Point(136, 66);
            this.textBox_pump_level.Name = "textBox_pump_level";
            this.textBox_pump_level.Size = new System.Drawing.Size(76, 21);
            this.textBox_pump_level.TabIndex = 5;
            this.textBox_pump_level.Text = "10";
            this.textBox_pump_level.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(145, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "水流级别";
            // 
            // btn_pump_increase
            // 
            this.btn_pump_increase.Location = new System.Drawing.Point(173, 102);
            this.btn_pump_increase.Name = "btn_pump_increase";
            this.btn_pump_increase.Size = new System.Drawing.Size(54, 21);
            this.btn_pump_increase.TabIndex = 2;
            this.btn_pump_increase.Text = "+";
            this.btn_pump_increase.UseVisualStyleBackColor = true;
            // 
            // btn_pump_descend
            // 
            this.btn_pump_descend.Location = new System.Drawing.Point(106, 102);
            this.btn_pump_descend.Name = "btn_pump_descend";
            this.btn_pump_descend.Size = new System.Drawing.Size(56, 21);
            this.btn_pump_descend.TabIndex = 1;
            this.btn_pump_descend.Text = "-";
            this.btn_pump_descend.UseVisualStyleBackColor = true;
            // 
            // btn_init
            // 
            this.btn_init.Location = new System.Drawing.Point(88, 643);
            this.btn_init.Name = "btn_init";
            this.btn_init.Size = new System.Drawing.Size(173, 31);
            this.btn_init.TabIndex = 12;
            this.btn_init.Text = "初始化";
            this.btn_init.UseVisualStyleBackColor = true;
            // 
            // TeethCleanerPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_init);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "TeethCleanerPanel";
            this.Size = new System.Drawing.Size(364, 984);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label_osc_state;
        private System.Windows.Forms.Label label_osc_mode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioBtn_footPadel;
        private System.Windows.Forms.RadioButton radioBtn_fingerControl;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.VScrollBar vScrollBar_pwr;
        private System.Windows.Forms.TextBox textBox_pwr_level;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_pwr_increase;
        private System.Windows.Forms.Button btn_pwr_descend;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.VScrollBar vScrollBar_waterPump;
        private System.Windows.Forms.TextBox textBox_pump_level;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_pump_increase;
        private System.Windows.Forms.Button btn_pump_descend;
        private System.Windows.Forms.Button btn_init;
    }
}
