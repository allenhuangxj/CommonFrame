namespace CommonLaserFrameWork
{
    partial class FormMain
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.textBox_model = new System.Windows.Forms.TextBox();
            this.button_load = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.richTextBox_Log = new System.Windows.Forms.RichTextBox();
            this.button_hand = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_SN = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_model
            // 
            this.textBox_model.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_model.ForeColor = System.Drawing.Color.MidnightBlue;
            this.textBox_model.Location = new System.Drawing.Point(60, 11);
            this.textBox_model.Name = "textBox_model";
            this.textBox_model.ReadOnly = true;
            this.textBox_model.Size = new System.Drawing.Size(451, 21);
            this.textBox_model.TabIndex = 15;
            // 
            // button_load
            // 
            this.button_load.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_load.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_load.BackgroundImage")));
            this.button_load.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_load.FlatAppearance.BorderSize = 0;
            this.button_load.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_load.Location = new System.Drawing.Point(517, 8);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(26, 26);
            this.button_load.TabIndex = 14;
            this.button_load.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "打标模板:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.pictureBox1.Location = new System.Drawing.Point(4, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(527, 516);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // richTextBox_Log
            // 
            this.richTextBox_Log.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.richTextBox_Log.Location = new System.Drawing.Point(537, 81);
            this.richTextBox_Log.Name = "richTextBox_Log";
            this.richTextBox_Log.ReadOnly = true;
            this.richTextBox_Log.Size = new System.Drawing.Size(319, 475);
            this.richTextBox_Log.TabIndex = 18;
            this.richTextBox_Log.Text = "";
            // 
            // button_hand
            // 
            this.button_hand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_hand.FlatAppearance.BorderSize = 0;
            this.button_hand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_hand.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_hand.Image = ((System.Drawing.Image)(resources.GetObject("button_hand.Image")));
            this.button_hand.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_hand.Location = new System.Drawing.Point(773, 40);
            this.button_hand.Name = "button_hand";
            this.button_hand.Size = new System.Drawing.Size(74, 35);
            this.button_hand.TabIndex = 19;
            this.button_hand.Text = "标刻";
            this.button_hand.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_hand.UseVisualStyleBackColor = true;
            this.button_hand.Click += new System.EventHandler(this.button_hand_Click);
            // 
            // button_Stop
            // 
            this.button_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Stop.FlatAppearance.BorderSize = 0;
            this.button_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Stop.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button_Stop.Image = ((System.Drawing.Image)(resources.GetObject("button_Stop.Image")));
            this.button_Stop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_Stop.Location = new System.Drawing.Point(681, 40);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(72, 35);
            this.button_Stop.TabIndex = 20;
            this.button_Stop.Text = "停止";
            this.button_Stop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_Stop.UseVisualStyleBackColor = true;
            this.button_Stop.Click += new System.EventHandler(this.button_Stop_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(567, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "打标SN:";
            // 
            // textBox_SN
            // 
            this.textBox_SN.Location = new System.Drawing.Point(620, 11);
            this.textBox_SN.Name = "textBox_SN";
            this.textBox_SN.Size = new System.Drawing.Size(227, 21);
            this.textBox_SN.TabIndex = 22;
            this.textBox_SN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_SN_KeyPress);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(859, 561);
            this.Controls.Add(this.textBox_SN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.button_hand);
            this.Controls.Add(this.richTextBox_Log);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox_model);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CommonLaser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_model;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox_Log;
        private System.Windows.Forms.Button button_hand;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_SN;
    }
}

