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
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.btn_keys = new System.Windows.Forms.Button();
            this.btn_sections = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.button_read_int = new System.Windows.Forms.Button();
            this.button_write_int = new System.Windows.Forms.Button();
            this.button_read_ushort = new System.Windows.Forms.Button();
            this.button_write_ushort = new System.Windows.Forms.Button();
            this.button_read_str = new System.Windows.Forms.Button();
            this.button_write_str = new System.Windows.Forms.Button();
            this.button_read_float = new System.Windows.Forms.Button();
            this.button_write_float = new System.Windows.Forms.Button();
            this.button_connect_modbus = new System.Windows.Forms.Button();
            this.textBox_Modbus_slaveNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Modbus_port = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Modbus_IP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_SendMsg = new System.Windows.Forms.Button();
            this.textBox_Send = new System.Windows.Forms.TextBox();
            this.richTextBox_Log = new System.Windows.Forms.RichTextBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
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
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.button_read_int);
            this.tabPage6.Controls.Add(this.button_write_int);
            this.tabPage6.Controls.Add(this.button_read_ushort);
            this.tabPage6.Controls.Add(this.button_write_ushort);
            this.tabPage6.Controls.Add(this.button_read_str);
            this.tabPage6.Controls.Add(this.button_write_str);
            this.tabPage6.Controls.Add(this.button_read_float);
            this.tabPage6.Controls.Add(this.button_write_float);
            this.tabPage6.Controls.Add(this.button_connect_modbus);
            this.tabPage6.Controls.Add(this.textBox_Modbus_slaveNo);
            this.tabPage6.Controls.Add(this.label5);
            this.tabPage6.Controls.Add(this.textBox_Modbus_port);
            this.tabPage6.Controls.Add(this.label4);
            this.tabPage6.Controls.Add(this.textBox_Modbus_IP);
            this.tabPage6.Controls.Add(this.label3);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(681, 139);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Modbus测试";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // button_read_int
            // 
            this.button_read_int.Location = new System.Drawing.Point(593, 76);
            this.button_read_int.Name = "button_read_int";
            this.button_read_int.Size = new System.Drawing.Size(76, 30);
            this.button_read_int.TabIndex = 3;
            this.button_read_int.Text = "读取Int";
            this.button_read_int.UseVisualStyleBackColor = true;
            this.button_read_int.Click += new System.EventHandler(this.button_read_int_Click);
            // 
            // button_write_int
            // 
            this.button_write_int.Location = new System.Drawing.Point(510, 76);
            this.button_write_int.Name = "button_write_int";
            this.button_write_int.Size = new System.Drawing.Size(76, 30);
            this.button_write_int.TabIndex = 3;
            this.button_write_int.Text = "写入Int";
            this.button_write_int.UseVisualStyleBackColor = true;
            this.button_write_int.Click += new System.EventHandler(this.button_write_int_Click);
            // 
            // button_read_ushort
            // 
            this.button_read_ushort.Location = new System.Drawing.Point(427, 76);
            this.button_read_ushort.Name = "button_read_ushort";
            this.button_read_ushort.Size = new System.Drawing.Size(76, 30);
            this.button_read_ushort.TabIndex = 3;
            this.button_read_ushort.Text = "读取Ushort";
            this.button_read_ushort.UseVisualStyleBackColor = true;
            this.button_read_ushort.Click += new System.EventHandler(this.button_read_ushort_Click);
            // 
            // button_write_ushort
            // 
            this.button_write_ushort.Location = new System.Drawing.Point(344, 76);
            this.button_write_ushort.Name = "button_write_ushort";
            this.button_write_ushort.Size = new System.Drawing.Size(76, 30);
            this.button_write_ushort.TabIndex = 3;
            this.button_write_ushort.Text = "写入Ushort";
            this.button_write_ushort.UseVisualStyleBackColor = true;
            this.button_write_ushort.Click += new System.EventHandler(this.button_write_ushort_Click);
            // 
            // button_read_str
            // 
            this.button_read_str.Location = new System.Drawing.Point(261, 76);
            this.button_read_str.Name = "button_read_str";
            this.button_read_str.Size = new System.Drawing.Size(76, 30);
            this.button_read_str.TabIndex = 3;
            this.button_read_str.Text = "读取字符串";
            this.button_read_str.UseVisualStyleBackColor = true;
            this.button_read_str.Click += new System.EventHandler(this.button_read_str_Click);
            // 
            // button_write_str
            // 
            this.button_write_str.Location = new System.Drawing.Point(178, 76);
            this.button_write_str.Name = "button_write_str";
            this.button_write_str.Size = new System.Drawing.Size(76, 30);
            this.button_write_str.TabIndex = 3;
            this.button_write_str.Text = "写入字符串";
            this.button_write_str.UseVisualStyleBackColor = true;
            this.button_write_str.Click += new System.EventHandler(this.button_write_str_Click);
            // 
            // button_read_float
            // 
            this.button_read_float.Location = new System.Drawing.Point(95, 76);
            this.button_read_float.Name = "button_read_float";
            this.button_read_float.Size = new System.Drawing.Size(76, 30);
            this.button_read_float.TabIndex = 3;
            this.button_read_float.Text = "读取浮点数";
            this.button_read_float.UseVisualStyleBackColor = true;
            this.button_read_float.Click += new System.EventHandler(this.button_read_float_Click);
            // 
            // button_write_float
            // 
            this.button_write_float.Location = new System.Drawing.Point(12, 76);
            this.button_write_float.Name = "button_write_float";
            this.button_write_float.Size = new System.Drawing.Size(76, 30);
            this.button_write_float.TabIndex = 3;
            this.button_write_float.Text = "写入浮点数";
            this.button_write_float.UseVisualStyleBackColor = true;
            this.button_write_float.Click += new System.EventHandler(this.button_write_float_Click);
            // 
            // button_connect_modbus
            // 
            this.button_connect_modbus.Location = new System.Drawing.Point(577, 25);
            this.button_connect_modbus.Name = "button_connect_modbus";
            this.button_connect_modbus.Size = new System.Drawing.Size(75, 23);
            this.button_connect_modbus.TabIndex = 2;
            this.button_connect_modbus.Text = "连接";
            this.button_connect_modbus.UseVisualStyleBackColor = true;
            this.button_connect_modbus.Click += new System.EventHandler(this.button_connect_modbus_Click);
            // 
            // textBox_Modbus_slaveNo
            // 
            this.textBox_Modbus_slaveNo.Location = new System.Drawing.Point(444, 25);
            this.textBox_Modbus_slaveNo.Name = "textBox_Modbus_slaveNo";
            this.textBox_Modbus_slaveNo.Size = new System.Drawing.Size(114, 21);
            this.textBox_Modbus_slaveNo.TabIndex = 1;
            this.textBox_Modbus_slaveNo.Text = "1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(391, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "从机号:";
            // 
            // textBox_Modbus_port
            // 
            this.textBox_Modbus_port.Location = new System.Drawing.Point(243, 25);
            this.textBox_Modbus_port.Name = "textBox_Modbus_port";
            this.textBox_Modbus_port.Size = new System.Drawing.Size(114, 21);
            this.textBox_Modbus_port.TabIndex = 1;
            this.textBox_Modbus_port.Text = "502";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(205, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "端口:";
            // 
            // textBox_Modbus_IP
            // 
            this.textBox_Modbus_IP.Location = new System.Drawing.Point(74, 22);
            this.textBox_Modbus_IP.Name = "textBox_Modbus_IP";
            this.textBox_Modbus_IP.Size = new System.Drawing.Size(114, 21);
            this.textBox_Modbus_IP.TabIndex = 1;
            this.textBox_Modbus_IP.Text = "127.0.0.1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "IP:";
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
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.button7);
            this.tabPage7.Controls.Add(this.button6);
            this.tabPage7.Controls.Add(this.button5);
            this.tabPage7.Controls.Add(this.button4);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(681, 139);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Access测试";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(57, 44);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "连接数据库";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(177, 44);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "插入数据库";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(297, 44);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 1;
            this.button6.Text = "检测防重";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(405, 44);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 1;
            this.button7.Text = "关闭数据库";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
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
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage7.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button button_connect_modbus;
        private System.Windows.Forms.TextBox textBox_Modbus_slaveNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Modbus_port;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_Modbus_IP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_write_float;
        private System.Windows.Forms.Button button_read_float;
        private System.Windows.Forms.Button button_read_int;
        private System.Windows.Forms.Button button_write_int;
        private System.Windows.Forms.Button button_read_ushort;
        private System.Windows.Forms.Button button_write_ushort;
        private System.Windows.Forms.Button button_read_str;
        private System.Windows.Forms.Button button_write_str;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button7;
    }
}

