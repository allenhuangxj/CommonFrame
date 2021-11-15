using CommonLibrarySharp;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace CommonLibrarySharpDemo
{
    public partial class FormMain : Form
    {
        // 通用读取配置文件
        private Configure _configure = new Configure();

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 绑定日志控件  添加 NLog.dll NLog.config 文件到 exe目录即可
            Log.BindLogControl(richTextBox_Log);
            Log.WriteMessage("开启软件");

            Thread ThreadLog = new Thread(TestThreadLog);
            ThreadLog.Start();
        }

        private void TestThreadLog()
        {
            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    Log.WriteMessage("thread info msg" + i.ToString(), true);
                }
                else
                {
                    Log.WriteMessage("thread info msg" + i.ToString());
                }
            }
        }
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 释放相关对象
            m_SerialPort.Close();

            if (_TcpServer != null)
            {
                _TcpServer.Close();
            }

            if (_TcpClient.Connected)
            {
                _TcpClient.Close();
            }
        }

        private void button_SendMsg_Click(object sender, EventArgs e)
        {
            string strSendMsg = textBox_Send.Text.ToString();
            int nIndex = tabControl1.SelectedIndex;
            switch (nIndex)
            {
                case 0:
                    SendToCom(strSendMsg);
                    break;
                case 1:
                    string strErrorMsg = "";
                    string strReceiveMsg = "";

                    string strSend = textBox_Send.Text;
                    if (SendMsgToServer(strSend, ref strReceiveMsg, ref strErrorMsg))
                    {
                        string strMsg = string.Format("服务器返回数据成功: {0}", strReceiveMsg);
                        Log.WriteMessage(strMsg);
                    }
                    else
                    {
                        // 失败
                        string strMsg = string.Format("服务器返回数据失败,错误信息: {0}", strErrorMsg);
                        Log.WriteMessage(strMsg);
                    }
                    break;
            }
        }

        #region 串口测试
        private ComSerialPort m_SerialPort = new ComSerialPort();
        private void button_Open_Click(object sender, EventArgs e)
        {
            if (OpenCom())
            {
                // 设置结束符
                if (checkBox1.Checked == true)
                {
                    m_SerialPort.End = 0x03;
                }
                else
                {
                    m_SerialPort.End = 0x00;
                }
            }
        }
        private void button_Close_Click(object sender, EventArgs e)
        {
            m_SerialPort.Close();
        }

        private bool OpenCom()
        {
            try
            {
                short comport = (short)(_configure.ReadConfig("COM", "Port", 1));
                int baund = _configure.ReadConfig("COM", "BaudRate", 19200);
                int databit = _configure.ReadConfig("COM", "DataBits", 8);

                StopBits stopbit = StopBits.One;
                int nstopbitselect = _configure.ReadConfig("COM", "StopBits", 1);
                if (nstopbitselect == 0)          // 无停止位
                    stopbit = StopBits.None;
                else if (nstopbitselect == 1)     // 1个停止位
                    stopbit = StopBits.One;
                else if (nstopbitselect == 2)     // 2个停止位
                    stopbit = StopBits.Two;
                else
                    stopbit = StopBits.OnePointFive;

                Parity parity = Parity.None;
                int nparityselect = _configure.ReadConfig("COM", "Parity", 0);
                if (nparityselect == 0)        //无校验
                    parity = Parity.None;
                else if (nparityselect == 1)   //奇校验
                    parity = Parity.Odd;
                else if (nparityselect == 2)    //偶校验
                    parity = Parity.Even;

                if (m_SerialPort.IsOpen)
                {
                    m_SerialPort.Close();
                    Thread.Sleep(20);
                }
                m_SerialPort.SetCom(comport, baund, parity, databit, stopbit);

                if (!m_SerialPort.Open())
                {
                    Log.WriteMessage("打开串口失败", true);
                    return false;
                }

                m_SerialPort.DataEvent -= new RecvInfoHandler(m_comData_DataEvent);
                m_SerialPort.DataEvent += new RecvInfoHandler(m_comData_DataEvent);

                Log.WriteMessage("串口打开成功，等待接受串口指令数据");

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteMessage("串口打开失败:" + ex.Message, true);
            }
            return false;
        }

        public string ByteToString(byte[] InBytes)
        {
            string StringOut = "";
            int len = InBytes.Length;
            for (int i = 0; i < len; i++)
            {
                StringOut = StringOut + string.Format("{0:X2} ", InBytes[i]);
            }
            return StringOut;
        }

        private void m_comData_DataEvent(byte[] InBytes)
        {
            new Thread(delegate ()
            {
                string strResult = ByteToString(InBytes);
                Log.WriteMessage("接收到串口原数据为:" + strResult);

                // 根据返回的原数据 自行 去判断是否有起始符 结束符，截取数据等等
                int nLength = InBytes.Length;
                byte[] bLastData = new byte[nLength - 2];
                Array.Copy(InBytes, 1, bLastData, 0, nLength - 2);

                string strInfo = Encoding.Default.GetString(bLastData);
                Log.WriteMessage("截取起始结束符以后的数据为:" + strInfo);

                // 处理业务数据逻辑

            }).Start();
        }
        private void SendToCom(string strSendInfo)
        {
            try
            {
                if (m_SerialPort == null)
                {
                    Log.WriteMessage("串口处于未打开状态,取消发送数据", true);
                    return;
                }

                Log.WriteMessage("回复串口数据为:" + strSendInfo);

                // 根据实际情况 看是否需要添加起始结束符 
                byte[] bsend = new byte[strSendInfo.Length + 2];
                bsend[0] = 0x02;
                int i = 1;
                int j = 0;
                for (; i <= strSendInfo.Length; i++)
                {
                    bsend[i] = Convert.ToByte(strSendInfo[j++]);
                }
                bsend[i] = 0x03;

                if (!m_SerialPort.SendData(bsend))
                {
                    Log.WriteMessage("发送串口数据失败", true);
                }
                else
                {
                    Log.WriteMessage("回复串口数据成功");
                }
            }
            catch (Exception ex)
            {
                Log.WriteMessage("SendToCom 捕获到异常:" + ex.Message);
            }
        }
        #endregion

        #region 网口测试-服务端
        // tcp 服务端相关
        private Communication_TcpServer _TcpServer = null;

        private void button1_Click(object sender, EventArgs e)
        {
            StartServer();
        }
        private void StartServer()
        {
            string strIPLocate = "127.0.0.1";
            int nPort = 10086;
            _TcpServer = new Communication_TcpServer(strIPLocate, nPort);
            _TcpServer.StartTcpServer();
            _TcpServer.acceptClientEvent += new AcceptClientEventHandler(m_Server_acceptClientEvent);
            _TcpServer.reciveClientEvent += new ReciveClientEventHandler(m_Server_reciveClientEvent);
            _TcpServer.closeClientEvent += new CloseClientEventHandler(m_Server_closeClientEvent);

            string strMsg = string.Format("启动服务端 {0}:{1}", strIPLocate, nPort.ToString());
            Log.WriteMessage(strMsg);
        }
        private void m_Server_acceptClientEvent(TcpClient client)
        {
            string strMsg = string.Format("客户端连接 {0}:{1}", ((IPEndPoint)(client.Client.RemoteEndPoint)).Address.ToString(), ((IPEndPoint)(client.Client.RemoteEndPoint)).Port.ToString());
            Log.WriteMessage(strMsg);
        }

        private void m_Server_closeClientEvent(TcpClient client)
        {
            string strMsg = string.Format("客户端关闭 {0}:{1}", ((IPEndPoint)(client.Client.RemoteEndPoint)).Address.ToString(), ((IPEndPoint)(client.Client.RemoteEndPoint)).Port.ToString());
            Log.WriteMessage(strMsg);
        }
        private void m_Server_reciveClientEvent(TcpClient client, string strRecvData)
        {
            string strMsg = string.Format("接收客户端[{0}:{1}] 数据:{2} ", ((IPEndPoint)(client.Client.RemoteEndPoint)).Address.ToString(), ((IPEndPoint)(client.Client.RemoteEndPoint)).Port.ToString(), strRecvData);
            Log.WriteMessage(strMsg);
            ThreadClientReceiveMsg(client, strRecvData);
        }

        private void ThreadClientReceiveMsg(TcpClient client, string strRecvData)
        {
            // 根据 strRecvData 自行处理接收数据
            string strMsg = "";

            // 根据 client 回复对应client 数据
            string strSend = "hi server callback data";
            byte[] bSend = Encoding.Default.GetBytes(strSend);
            int nLen = client.Client.Send(bSend);
            strMsg = string.Format("回复客户端[{0}:{1}] 数据:{2} {3}",
                                    ((IPEndPoint)(client.Client.RemoteEndPoint)).Address.ToString(),
                                    ((IPEndPoint)(client.Client.RemoteEndPoint)).Port.ToString(),
                                    strSend, nLen == bSend.Length ? "成功" : "失败");

            Log.WriteMessage(strMsg);
        }
        #endregion

        #region 网口测试-客户端
        private Communication_TcpClient _TcpClient = new Communication_TcpClient();
        private bool ConnectServer(string strIP, int port)
        {
            if (!_TcpClient.Connected)
            {
                if (!_TcpClient.Connect(strIP, port, 5000))
                {
                    return false;
                }
                if (!_TcpClient.Connected)
                {
                    return false;
                }
                return true;
            }
            return true;
        }
        private void button_ConnectServer_Click(object sender, EventArgs e)
        {
            string strIP = textBox_ServerIP.Text;
            int nPort = Convert.ToInt32(textBox_ServerPort.Text);
            bool bRes = ConnectServer(strIP, nPort);

            string strMsg = string.Format("连接服务器 {0}:{1}", strIP, nPort.ToString()) + (bRes == true ? "成功" : "失败");
            Log.WriteMessage(strMsg);
        }


        private bool SendMsgToServer(string strSendMsg, ref string strReceiveMsg, ref string strErrorMsg)
        {
            strErrorMsg = "";
            strReceiveMsg = "";

            try
            {
                string strMsg = string.Format("发送服务器数据为 {0}", strSendMsg);
                Log.WriteMessage(strMsg);

                if (!_TcpClient.Write(strSendMsg, ref strErrorMsg))
                {
                    // 发送失败，重连再发送
                    _TcpClient.Close();
                    string strIP = textBox_ServerIP.Text;
                    int nPort = Convert.ToInt32(textBox_ServerPort.Text);

                    if (!ConnectServer(strIP, nPort))
                    {
                        return false;
                    }
                    if (!_TcpClient.Write(strSendMsg, ref strErrorMsg))
                    {
                        return false;
                    }
                }


                Thread.Sleep(100);
                if (_TcpClient.Read(ref strReceiveMsg, ref strErrorMsg))
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                strErrorMsg = "读取tcp服务器返回数据异常:" + ex.Message;
                Log.WriteMessage(strErrorMsg);
            }

            return false;
        }


        #endregion

        #region webService
        string strUrl = "https://localhost:44322/WebService1.asmx";
        private void button2_Click(object sender, EventArgs e)
        {
            // 请求webservice接口
            List<WebServiceClient.Parameter> lstParameters = new List<WebServiceClient.Parameter>();
            string returnFromService = MyWebService.RequestWebService(strUrl, "HelloWorld", lstParameters);
            MessageBox.Show(returnFromService);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 请求webservice接口
            List<WebServiceClient.Parameter> lstParameters = new List<WebServiceClient.Parameter>();
            // 其中 Name 就是 网页测试接口的参数名称， Value就是参数值
            lstParameters.Add(new WebServiceClient.Parameter { Name = "iA", Value = "123" });
            lstParameters.Add(new WebServiceClient.Parameter { Name = "iB", Value = "456" });
            string returnFromService = MyWebService.RequestWebService(strUrl, "Add", lstParameters);
            MessageBox.Show(returnFromService);
        }
        #endregion

        #region http 请求
        private void btn_commonUrl_Click(object sender, EventArgs e)
        {
            // 一般用于GET请求参数直接携带在url后面的http接口
            string strUrl = "http://127.0.0.1:8090/testGet?Name=hxj&Age=30";
            string strPostType = "GET";   //GET/POST
            string strReceiveMsg = httpHelper.CommonUrl(strUrl, strPostType);
            string strMsg = string.Format("http 服务器返回数据为: {0}", strReceiveMsg);
            Log.WriteMessage(strMsg);
        }

        private void btn_PotsBody_Click(object sender, EventArgs e)
        {
            // 一般用于POST表单数据 请求url的http接口 
            // (熟称body里面 类型为 application/x-www-form-urlencoded 添加的 key=value 对应的参数信息)
            string strUrl = "http://127.0.0.1:8090/testPostParam";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("name", "hxj");
            parameters.Add("age", "11");
            string strReceiveMsg = httpHelper.HttpPostFormData(strUrl, parameters);
            string strMsg = string.Format("http 服务器返回数据为: {0}", strReceiveMsg);
            Log.WriteMessage(strMsg);
        }

        private void btn_PostJson_Click(object sender, EventArgs e)
        {
            // 一般用于POST json字符串 请求url的http接口 
            // (熟称body 类型raw -- Json 格式里面添加json字符串)
            string strUrl = "http://127.0.0.1:8090/testPostJson";
            string strJson = "{\"name\": \"hxj\", \"age\": \"111\"}";
            string strReceiveMsg = httpHelper.HttpPostJsonData(strUrl, strJson);
            string strMsg = string.Format("http 服务器返回数据为: {0}", strReceiveMsg);
            Log.WriteMessage(strMsg);
        }

        #endregion

        private void btn_sections_Click(object sender, EventArgs e)
        {
            string v = _configure.ReadConfig("SET", "URL", "");
            List<string> lstSections = _configure.ReadSections();
            int i = 0;
        }

        private void btn_keys_Click(object sender, EventArgs e)
        {
            List<string> lstKeys = _configure.ReadKeys("SET");
            int i = 0;
        }
    }
}
