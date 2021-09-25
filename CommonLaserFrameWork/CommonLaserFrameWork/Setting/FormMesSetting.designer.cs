namespace CommonLaserFrameWork
{
    partial class FormMesSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMesSetting));
            this.button_oK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_info = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_oK
            // 
            this.button_oK.Location = new System.Drawing.Point(64, 98);
            this.button_oK.Name = "button_oK";
            this.button_oK.Size = new System.Drawing.Size(75, 23);
            this.button_oK.TabIndex = 31;
            this.button_oK.Text = "确定";
            this.button_oK.UseVisualStyleBackColor = true;
            this.button_oK.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Location = new System.Drawing.Point(293, 98);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 31;
            this.button_Cancel.Text = "取消";
            this.button_Cancel.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "信息:";
            // 
            // textBox_info
            // 
            this.textBox_info.Location = new System.Drawing.Point(134, 22);
            this.textBox_info.Name = "textBox_info";
            this.textBox_info.Size = new System.Drawing.Size(180, 21);
            this.textBox_info.TabIndex = 30;
            // 
            // FormMesSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 153);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_oK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_info);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMesSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mes设置";
            this.Load += new System.EventHandler(this.FormMesSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_oK;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_info;
    }
}