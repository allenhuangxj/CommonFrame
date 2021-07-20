using System;
using System.IO.Ports;

namespace CommonLibrarySharp
{
    public delegate void RecvInfoHandler(byte[] InBytes);

    public class ComSerialPort
    {
        private SerialPort m_port = new SerialPort();
        public event RecvInfoHandler DataEvent = null;
        private object lockobject = new object();
        private byte[] m_DataRecvBuffer = new byte[4096];
        private int m_DataIndex = 0;
        // 结束符
        private byte m_EndChar = 0;

        public ComSerialPort()
        {

        }

        public ComSerialPort(short sPort, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            m_port.PortName = "COM" + sPort.ToString();
            m_port.BaudRate = baudRate;
            m_port.Parity = parity;
            m_port.DataBits = dataBits;
            m_port.StopBits = stopBits;
        }

        public void SetCom(short sPort, int baudRate, Parity parity, int dataBits, StopBits stopBits)
        {
            m_port.PortName = "COM" + sPort.ToString();
            m_port.BaudRate = baudRate;
            m_port.Parity = parity;
            m_port.DataBits = dataBits;
            m_port.StopBits = stopBits;
        }

        public bool IsOpen
        {
            get
            {
                return m_port.IsOpen;
            }
        }

        public byte End
        {
            set
            {
                m_EndChar = value;
            }
        }

        public bool Open()
        {
            try
            {
                if (m_port.IsOpen)
                    return true;
                m_port.Open();
                m_port.DiscardInBuffer();
                m_port.DiscardOutBuffer();
                m_port.DataReceived -= new SerialDataReceivedEventHandler(MyDataRecived);
                m_port.DataReceived += new SerialDataReceivedEventHandler(MyDataRecived);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Close()
        {
            if (m_port.IsOpen)
            {
                m_port.Close();
            }
        }

        public void MyDataRecived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] ReDatas = new byte[m_port.BytesToRead];
            int nLen = m_port.Read(ReDatas, 0, ReDatas.Length);
            Array.Copy(ReDatas, 0, m_DataRecvBuffer, m_DataIndex, ReDatas.Length);
            m_DataIndex += ReDatas.Length;

            // 起始符自行在外头根据返回的数据判断

            // 如果没有设置结束符 或者读取到结束符标志
            if (m_EndChar == 0 || (Array.IndexOf(ReDatas, m_EndChar) > 0))
            {
                m_port.DiscardInBuffer();
                m_port.DiscardOutBuffer();

                byte[] bTrueData = new byte[m_DataIndex];
                Array.Copy(m_DataRecvBuffer, 0, bTrueData, 0, m_DataIndex);
                //校验数据
                DataEvent?.Invoke(bTrueData);
                m_DataIndex = 0;
                GC.Collect();
            }
        }

        public bool SendData(byte[] bsend)
        {
            try
            {
                lock (lockobject)
                {
                    if (m_port.IsOpen)
                    {
                        m_port.DiscardInBuffer();
                        m_port.DiscardOutBuffer();
                        m_port.Write(bsend, 0, bsend.Length);
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
