namespace CommonLibrarySharpDemo
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button_Close = new System.Windows.Forms.Button();
            this.button_Open = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button_ConnectServer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ServerPort = new System.Windows.Forms.TextBox();
            this.textBox_ServerIP = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btn_PostJson = new System.Windows.Forms.Button();
            this.btn_PotsBody = new System.Windows.Forms.Button();
            this.btn_commonUrl = new System.Windows.Forms.Button();
            this.button_SendMsg = new System.Windows.Forms.Button();
            this.textBox_Send = new System.Windows.Forms.TextBox();
            this.richTextBox_Log = new System.Windows.Forms.RichTextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btn_sections = new System.Windows.Forms.Button();
            this.btn_keys = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Location = new System.Drawing.Point(0, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(689, 165);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.button_Close);
            this.tabPage1.Controls.Add(this.button_Open);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(681, 139);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "串口测试";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(225, 38);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 16);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "设置结束符";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button_Close
            // 
            this.button_Close.Location = new System.Drawing.Point(120, 31);
            this.button_Close.Name = "button_Close";
            this.button_Close.Size = new System.Drawing.Size(99, 28);
            this.button_Close.TabIndex = 9;
            this.button_Close.Text = "关闭串口";
            this.button_Close.UseVisualStyleBackColor = true;
            this.button_Close.Click += new System.EventHandler(this.button_Close_Click);
            // 
            // button_Open
            // 
            this.button_Open.Location = new System.Drawing.Point(15, 31);
            this.button_Open.Name = "button_Open";
            this.button_Open.Size = new System.Drawing.Size(99, 28);
            this.button_Open.TabIndex = 10;
            this.button_Open.Text = "打开串口";
            this.button_Open.UseVisualStyleBackColor = true;
            this.button_Open.Click += new System.EventHandler(this.button_Open_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button_ConnectServer);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.textBox_ServerPort);
            this.tabPage2.Controls.Add(this.textBox_ServerIP);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(681, 139);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "网口测试";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button_ConnectServer
            // 
            this.button_ConnectServer.Location = new System.Drawing.Point(446, 19);
            this.button_ConnectServer.Name = "button_ConnectServer";
            this.button_ConnectServer.Size = new System.Drawing.Size(98, 44);
            this.button_ConnectServer.TabIndex = 10;
            this.button_ConnectServer.Text = "连接服务端";
            this.button_ConnectServer.UseVisualStyleBackColor = true;
            this.button_ConnectServer.Click += new System.EventHandler(this.button_ConnectServer_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "端口:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(274, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "IP:";
            // 
            // textBox_ServerPort
            // 
            this.textBox_ServerPort.Location = new System.Drawing.Point(330, 46);
            this.textBox_ServerPort.Name = "textBox_ServerPort";
            this.textBox_ServerPort.Size = new System.Drawing.Size(100, 21);
            this.textBox_ServerPort.TabIndex = 6;
            this.textBox_ServerPort.Text = "10086";
            // 
            // textBox_ServerIP
            // 
            this.textBox_ServerIP.Location = new System.Drawing.Point(330, 19);
            this.textBox_ServerIP.Name = "textBox_ServerIP";
            this.textBox_ServerIP.Size = new System.Drawing.Size(100, 21);
            this.textBox_ServerIP.TabIndex = 7;
            this.textBox_ServerIP.Text = "127.0.0.1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(43, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 44);
            this.button1.TabIndex = 5;
            this.button1.Text = "启动server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.button2);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(681, 139);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "WebService";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(222, 44);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(124, 46);
            this.button3.TabIndex = 0;
            this.button3.Text = "传参调用";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(74, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 46);
            this.button2.TabIndex = 0;
            this.button2.Text = "helloWorld";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btn_PostJson);
            this.tabPage4.Controls.Add(this.btn_PotsBody);
            this.tabPage4.Controls.Add(this.btn_commonUrl);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(681, 139);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "http 请求";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btn_PostJson
            // 
            this.btn_PostJson.Location = new System.Drawing.Point(353, 45);
            this.btn_PostJson.Name = "btn_PostJson";
            this.btn_PostJson.Size = new System.Drawing.Size(119, 49);
            this.btn_PostJson.TabIndex = 0;
            this.btn_PostJson.Text = "post Json字符串";
            this.btn_PostJson.UseVisualStyleBackColor = true;
            this.btn_PostJson.Click += new System.EventHandler(this.btn_PostJson_Click);
            // 
            // btn_PotsBody
            // 
            this.btn_PotsBody.Location = new System.Drawing.Point(187, 45);
            this.btn_PotsBody.Name = "btn_PotsBody";
            this.btn_PotsBody.Size = new System.Drawing.Size(119, 49);
            this.btn_PotsBody.TabIndex = 0;
            this.btn_PotsBody.Text = "post表单请求";
            this.btn_PotsBody.UseVisualStyleBackColor = true;
            this.btn_PotsBody.Click += new System.EventHandler(this.btn_PotsBody_Click);
            // 
            // btn_commonUrl
            // 
            this.btn_commonUrl.Location = new System.Drawing.Point(19, 45);
            this.btn_commonUrl.Name = "btn_commonUrl";
            this.btn_commonUrl.Size = new System.Drawing.Size(119, 49);
            this.btn_commonUrl.TabIndex = 0;
            this.btn_commonUrl.Text = "通用get/post请求";
            this.btn_commonUrl.UseVisualStyleBackColor = true;
            this.btn_commonUrl.Click += new System.EventHandler(this.btn_commonUrl_Click);
            // 
            // button_SendMsg
            // 
            this.button_SendMsg.Location = new System.Drawing.Point(590, 387);
            this.button_SendMsg.Name = "button_SendMsg";
            this.button_SendMsg.Size = new System.Drawing.Size(99, 28);
            this.button_SendMsg.TabIndex = 13;
            this.button_SendMsg.Text = "发送消息";
            this.button_SendMsg.UseVisualStyleBackColor = true;
            this.button_SendMsg.Click += new System.EventHandler(this.button_SendMsg_Click);
            // 
            // textBox_Send
            // 
            this.textBox_Send.Location = new System.Drawing.Point(4, 387);
            this.textBox_Send.Multiline = true;
            this.textBox_Send.Name = "textBox_Send";
            this.textBox_Send.Size = new System.Drawing.Size(580, 28);
            this.textBox_Send.TabIndex = 12;
            // 
            // richTextBox_Log
            // 
            this.richTextBox_Log.Location = new System.Drawing.Point(4, 170);
            this.richTextBox_Log.Name = "richTextBox_Log";
            this.richTextBox_Log.Size = new System.Drawing.Size(685, 211);
            this.richTextBox_Log.TabIndex = 11;
            this.richTextBox_Log.Text = "";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btn_keys);
            this.tabPage5.Controls.Add(this.btn_sections);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(681, 139);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "配置文件测试";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // btn_sections
            // 
            this.btn_sections.Location = new System.Drawing.Point(38, 57);
            this.btn_sections.Name = "btn_sections";
            this.btn_sections.Size = new System.Drawing.Size(137, 32);
            this.btn_sections.TabIndex = 0;
            this.btn_sections.Text = "读取所有sections";
            this.btn_sections.UseVisualStyleBackColor = true;
            this.btn_sections.Click += new System.EventHandler(this.btn_sections_Click);
            // 
            // btn_keys
            // 
            this.btn_keys.Location = new System.Drawing.Point(232, 57);
            this.btn_keys.Name = "btn_keys";
            this.btn_keys.Size = new System.Drawing.Size(137, 32);
            this.btn_keys.TabIndex = 0;
            this.btn_keys.Text = "读取所有keys";
            this.btn_keys.UseVisualStyleBackColor = true;
            this.btn_keys.Click += new System.EventHandler(this.btn_keys_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 421);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button_SendMsg);
            this.Controls.Add(this.textBox_Send);
            this.Controls.Add(this.richTextBox_Log);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button_SendMsg;
        private System.Windows.Forms.TextBox textBox_Send;
        private System.Windows.Forms.RichTextBox richTextBox_Log;
        private System.Windows.Forms.Button button_Close;
        private System.Windows.Forms.Button button_Open;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button_ConnectServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_ServerPort;
        private System.Windows.Forms.TextBox textBox_ServerIP;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btn_commonUrl;
        private System.Windows.Forms.Button btn_PotsBody;
        private System.Windows.Forms.Button btn_PostJson;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btn_keys;
        private System.Windows.Forms.Button btn_sections;
    }
}

