using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace CommonLibrarySharp
{
    /*   
     *   使用注意:对于同一个IP创建多个客户端问题，本次封装没有做处理(默认处理最先连接进来的)
     */
    //客户端连接上
    public delegate void AcceptClientEventHandler(TcpClient client);
    //客户端接收数据
    public delegate void ReciveClientEventHandler(TcpClient client, string strRecvData);
    //客户端断开
    public delegate void CloseClientEventHandler(TcpClient client);

    public class Communication_TcpServer
    {
        //服务器监听的网卡IP
        private string _serverIp = "127.0.0.1";
        //服务器监听端口
        private int _listenerPort = 10010;
        //监听对象
        private TcpListener _listenerInstance = null;
        //监听线程
        private Thread _threadListenClient = null;
        //客户端对象链表
        public Dictionary<TcpClient, Thread> _clientInstanceDic = new Dictionary<TcpClient, Thread>();
        //服务器监听标志
        public bool _isListenning = true;

        //客户端连接事件
        public event AcceptClientEventHandler acceptClientEvent;
        //客户端发消息事件
        public event ReciveClientEventHandler reciveClientEvent;
        //客户端断开事件
        public event CloseClientEventHandler closeClientEvent;

        public Communication_TcpServer()
        {

        }

        public Communication_TcpServer(string Ip, int nPort)
        {
            _listenerPort = nPort;
            _serverIp = Ip;
        }

        public void StartTcpServer()
        {
            _clientInstanceDic.Clear();
            _threadListenClient = new Thread(AcceptClients);
            _threadListenClient.IsBackground = true;
            _threadListenClient.Start();
            _isListenning = true;
        }

        private void AcceptClients()
        {
            try
            {
                if (!Regex.IsMatch(_serverIp, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$") || _listenerPort > 65535)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("AcceptClients IP或者端口错误:{0}:{1}", _serverIp, _listenerPort), " error !", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return;
                }

                //获取本机IP
                _listenerInstance = new TcpListener(IPAddress.Parse(_serverIp), _listenerPort);
                _listenerInstance.Start();//开始监听

                while (_isListenning)
                {
                    TcpClient Client = _listenerInstance.AcceptTcpClient();
                    //客户端连接上
                    acceptClientEvent?.Invoke(Client);

                    Thread tmpClientThread = new Thread(new ParameterizedThreadStart(ReceiveClient));
                    _clientInstanceDic.Add(Client, tmpClientThread);

                    tmpClientThread.IsBackground = true;
                    tmpClientThread.Name = "client handle";

                    tmpClientThread.Start(Client);

                }
            }
            catch (SocketException ex)
            {
                Trace.WriteLine(ex.Message);
                System.Windows.Forms.MessageBox.Show("AcceptClients SocketException:" + ex.Message, " error !", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        private void ReceiveClient(object clientObject)
        {
            TcpClient client = clientObject as TcpClient;
            NetworkStream netStream = null;

            try
            {
                netStream = client.GetStream();

                while (_isListenning)
                {
                    if ((client.Client.Poll(100, SelectMode.SelectRead) && (client.Client.Available == 0) || !client.Connected))
                    {
                        //断开
                        _clientInstanceDic.Remove(client);
                        closeClientEvent?.Invoke(client);

                        return;
                    }
                    byte[] receiveBuffer = new byte[client.ReceiveBufferSize];
                    int nRecvLen = netStream.Read(receiveBuffer, 0, receiveBuffer.Length);
                    if (nRecvLen <= 0)
                    {
                        //断开
                        _clientInstanceDic.Remove(client);
                        closeClientEvent?.Invoke(client);
                        return;
                    }
                    string Data = System.Text.Encoding.Default.GetString(receiveBuffer);
                    Data = Data.Replace("\0", "");
                    reciveClientEvent(client, Data);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                _clientInstanceDic.Remove(client);
                closeClientEvent?.Invoke(client);
            }
        }

        public void Close()
        {
            _isListenning = false;
            foreach (TcpClient tc in _clientInstanceDic.Keys)
            {
                tc.Close();
            }
            _clientInstanceDic.Clear();
        }
    }
}
