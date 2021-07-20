using System;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace CommonLibrarySharp
{
    /*
        同步 客户端
   */
    public class Communication_TcpClient
    {
        #region 变量
        //客户端实例
        private TcpClient _clientInstance = null;
        private NetworkStream _stream = null;
        //是否连接标志
        private bool _connected = false;
        private object _objectLockInstance = new object();

        public bool Connected
        {
            get
            {
                lock (_objectLockInstance)
                {
                    if (_clientInstance != null)
                        _connected = !((_clientInstance.Client.Poll(100, SelectMode.SelectRead) && (_clientInstance.Client.Available == 0)) || !_clientInstance.Client.Connected);
                    else
                        _connected = false;
                    return _connected;
                }
            }
        }

        #endregion

        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <param name="strIP">服务器IP</param>
        /// <param name="nPort">连接端口</param>
        /// <param name="nTimeOut">超时，0表示不设置超时 时间单位ms</param>
        /// <returns>是否连接服务器成功</returns>
        public bool Connect(string strIP, int nPort, int nTimeOut = 0)
        {
            try
            {
                if (!Regex.IsMatch(strIP, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$") || nPort > 65535)
                {
                    System.Windows.Forms.MessageBox.Show(string.Format("IP或者端口错误:{0}:{1}", strIP, nPort), " error !", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    return false;
                }
                if (_clientInstance != null)
                {
                    _clientInstance.Close();
                }
                _clientInstance = new TcpClient();
                _clientInstance.ReceiveTimeout = nTimeOut;
                _clientInstance.SendTimeout = nTimeOut;
                _clientInstance.Connect(IPAddress.Parse(strIP), nPort);

                return true;
            }
            catch (System.Exception ex)
            {
                Trace.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Read(ref string strReadString, ref string ErrorMessage)
        {
            try
            {
                ErrorMessage = "";
                if (!Connected)
                {
                    ErrorMessage = "Instance is null or socket closed";
                    return false;
                }
                _stream = _clientInstance.GetStream();
                if (_stream == null || !_stream.CanRead)
                {
                    ErrorMessage = "netstream is closed";
                    return false;
                }
                byte[] receiveBuffer = new byte[_clientInstance.ReceiveBufferSize];//接收数据缓冲区
                int nRecvLen = _stream.Read(receiveBuffer, 0, _clientInstance.ReceiveBufferSize);
                _stream.Flush();
                if (nRecvLen <= 0)
                {
                    ErrorMessage = "服务端返回数据超时, 未获取到任何数据";
                    return false;
                }
                // 用utf8中文反而乱码
                strReadString = System.Text.Encoding.Default.GetString(receiveBuffer);
                strReadString = strReadString.TrimEnd('\0');
            }
            catch (System.IO.IOException io)
            {
                ErrorMessage = "IOException:" +  io.Message;
                return false;
            }
            catch (Exception ex)
            {
                ErrorMessage = "socket is exception:" + ex.Message;
                return false;
            }

            return true;
        }
        public bool Write(string strWrite, ref string ErrorMessage)
        {
            ErrorMessage = "";
            try
            {
                if (!Connected)
                {
                    ErrorMessage = "Instance is null or socket closed";
                    return false;
                }
                _stream = _clientInstance.GetStream();
                if (_stream == null || !_stream.CanWrite)
                {
                    ErrorMessage = "netstream is closed";
                    return false;
                }

                // 用utf8中文反而乱码
                byte[] bWrite = System.Text.Encoding.Default.GetBytes(strWrite);
                _stream.Write(bWrite, 0, bWrite.Length);
                _stream.Flush();
            }
            catch (System.ObjectDisposedException ex)
            {
                //断开了
                ErrorMessage = "socket is closed:" + ex.Message;
                return false;
            }
            catch (Exception ex)
            {
                //其他异常
                ErrorMessage = "socket is exception:" + ex.Message;
                return false;
            }

            return true;
        }
        public bool Close()
        {
            try
            {
                if (_stream != null)
                {
                    _stream.Close(); _stream = null;
                }
                if (_clientInstance != null)
                {
                    _clientInstance.Close(); _clientInstance = null;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
