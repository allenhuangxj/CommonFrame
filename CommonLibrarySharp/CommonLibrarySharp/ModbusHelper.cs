using CommonLibrarySharp.WriteLog;
using Modbus.Device;
using System;
using System.IO.Ports;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CommonLibrarySharp.Modbus
{
    /// <summary>
    /// modbus 帮助类 (里面的日志使用的NLog库)
    /// 
    ///  使用方法: 
    ///  1 ModbusHelper _modbus_helper = null;
    ///  // 如果是rtu则使用ModbusRtu类进行初始化
    ///  2 _modbus_helper = new ModbusTcp(textBox_Modbus_IP.Text, Convert.ToInt32(textBox_Modbus_port.Text), Convert.ToInt32(textBox_Modbus_slaveNo.Text));
    ///  3 进行读写
    ///      字符串读写:   
    ///         string strValue = "ABCDEF";
    ///         _modbus_helper.WriteString(0, strValue, (ushort) strValue.Length);
    ///         _modbus_helper.ReadString(0, ref strValue, 8);
    ///         
    ///     浮点数读写:
    ///         float fValue = 1.24F;
    ///         _modbus_helper.WriteFloat((ushort)4, fValue);
    ///         _modbus_helper.ReadFloat((ushort)4, ref fValue);
    ///         
    ///     ushort读写:
    ///         ushort uValue = 45;
    ///         _modbus_helper.WriteUshort(8, uValue);
    ///         _modbus_helper.ReadUshort(8, ref uValue);
    ///         
    ///     整形读写:
    ///         int nValue = -1222;
    ///         _modbus_helper.WriteInt(10, nValue);
    ///         _modbus_helper.ReadInt(10, ref nValue);
    /// </summary>
    public class ModbusHelper
    {
        #region param
        /// <summary>
        /// modbus master操作对象
        /// </summary>
        protected IModbusMaster _master = null;
        /// <summary>
        /// 从机号
        /// </summary>
        protected byte _slave_no = 0;
        #endregion

        #region 暴露外层调用方法
        // 读写保持寄存器
        public bool ReadString(ushort uAddress, ref string strResult, ushort ulen = 8)
        {
            try
            {
                ushort[] buff = ReadHoldingRegisters(uAddress, ulen);
                strResult = ModbusUtils.GetString(buff, 0, ulen);
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteMessage("ReadString 失败:" + ex.Message, true);
            }
            return false;
        }

        public bool WriteString(ushort uAddress, string strValue, ushort ulen = 8)
        {
            try
            {
                ushort[] buff = new ushort[ulen];
                ModbusUtils.SetString(buff, 0, strValue);
                WriteMultipleRegisters(uAddress, buff);
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteMessage("WriteString 失败:" + ex.Message, true);
            }
            return false;
        }

        public bool ReadFloat(ushort uAddress, ref float fvalue)
        {
            try
            {
                ushort[] buff = ReadHoldingRegisters(uAddress, 2);
                fvalue = ModbusUtils.GetReal(buff, 0);
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteMessage("ReadFloat 失败:" + ex.Message, true);
            }
            return false;
        }

        public bool WriteFloat(ushort uAddress, float fvalue)
        {
            try
            {
                ushort[] buff = new ushort[2];
                ModbusUtils.SetReal(buff, 0, fvalue);
                WriteMultipleRegisters(uAddress, buff);
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteMessage("WriteFloat 失败:" + ex.Message, true);
            }
            return false;
        }

        public bool ReadUshort(ushort uaddress, ref ushort uvalue)
        {
            try
            {
                ushort[] uv = ReadHoldingRegisters(uaddress, 1);
                uvalue = uv[0];
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteMessage("ReadUshort 失败:" + ex.Message, true);
            }
            return false;
        }

        public bool WriteUshort(ushort uaddress, ushort uvalue)
        {
            try
            {
                WriteSingleRegister(uaddress, uvalue);
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteMessage("WriteUshort 失败:" + ex.Message, true);

            }
            return false;
        }

        // 处理有负数的情况
        public bool ReadInt(ushort uaddress, ref int nvalue)
        {
            try
            {
                ushort[] uv = ReadHoldingRegisters(uaddress, 2);
                nvalue = (uv[1] << 16) | uv[0];
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteMessage("ReadInt 失败:" + ex.Message, true);
            }
            return false;
        }

        public bool WriteInt(ushort uaddress, int nvalue)
        {
            try
            {
                ushort ux = (ushort)nvalue;
                ushort uy = (ushort)(nvalue >> 16);
                ushort[] uresult = { ux, uy };
                WriteMultipleRegisters(uaddress, uresult);
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteMessage("WriteInt 失败:" + ex.Message, true);

            }
            return false;
        }

        // 自行根据情况添加其他读写
        #endregion

        #region master 底层调用私有方法
        /// <summary>
        /// 读取线圈寄存器(DO) 功能码 0x01 (可读写)
        /// </summary>
        /// <param name="startAddress">读取地址</param>
        /// <param name="num">读取长度</param>
        /// <returns></returns>
        private bool[] ReadCoils(ushort startAddress, ushort num)
        {
            return _master.ReadCoils(_slave_no, startAddress, num);
        }

        /// <summary>
        /// 读离散输入寄存器(DI) 功能码 0x02 (只能读取输入的开关信号，不能写)
        /// </summary>
        /// <param name="startAddress">读取地址</param>
        /// <param name="num">读取长度</param>
        /// <returns></returns>
        private bool[] ReadInputs(ushort startAddress, ushort num)
        {
            return _master.ReadInputs(_slave_no, startAddress, num);
        }

        /// <summary>
        /// 读保持寄存器(AI) 功能码 0x03 (可读写)
        /// </summary>
        /// <param name="startAddress">读取地址</param>
        /// <param name="num">读取长度</param>
        /// <returns></returns>
        private ushort[] ReadHoldingRegisters(ushort startAddress, ushort num)
        {
            return _master.ReadHoldingRegisters(_slave_no, startAddress, num);
        }

        /// <summary>
        /// 读输入寄存器(AO) 功能码 0x04 (只读)
        /// </summary>
        /// <param name="startAddress">读取地址</param>
        /// <param name="num">读取长度</param>
        /// <returns></returns>
        private ushort[] ReadInputRegisters(ushort startAddress, ushort num)
        {
            return _master.ReadInputRegisters(_slave_no, startAddress, num);
        }

        /// <summary>
        /// 写单个线圈寄存器 功能码 0x05
        /// </summary>
        /// <param name="startAddress">写入地址</param>
        /// <param name="value">写入值</param>
        private void WriteSingleCoil(ushort startAddress, bool value)
        {
            _master.WriteSingleCoil(_slave_no, startAddress, value);
        }

        /// <summary>
        /// 写单个保持寄存器 功能码 0x06
        /// </summary>
        /// <param name="startAddress">写入地址</param>
        /// <param name="value">写入值</param>
        private void WriteSingleRegister(ushort startAddress, ushort value)
        {
            _master.WriteSingleRegister(_slave_no, startAddress, value);
        }

        /// <summary>
        /// 写多个线圈寄存器 功能码 0x0f
        /// </summary>
        /// <param name="startAddress">写入地址</param>
        /// <param name="value">写入值</param>
        private void WriteMultipleCoils(ushort startAddress, bool[] value)
        {
            _master.WriteMultipleCoils(_slave_no, startAddress, value);
        }

        /// <summary>
        /// 写多个保持寄存器 功能码 0x10
        /// </summary>
        /// <param name="startAddress">写入地址</param>
        /// <param name="value">写入值</param>
        private void WriteMultipleRegisters(ushort startAddress, ushort[] value)
        {
            _master.WriteMultipleRegisters(_slave_no, startAddress, value);
        }
        #endregion
    }
   

    #region tcp rtu
    /// <summary>
    /// modbus-tcp 初始化
    /// </summary>
    public class ModbusTcp : ModbusHelper
    {
        private TcpClient _tcpserver = null;
        /// <summary>
        /// 创建modbus-tcp
        /// </summary>
        /// <param name="strIP">从站IP</param>
        /// <param name="nPort">从站端口</param>
        /// <param name="nSlaveNo">从机号</param>
        public ModbusTcp(string strIP, int nPort, int nSlaveNo)
        {
            try
            {
                if (_tcpserver != null)
                    _tcpserver.Close();

                _tcpserver = new TcpClient();
                _tcpserver.ReceiveTimeout = 2000;
                _tcpserver.SendTimeout = 2000;
                _tcpserver.Connect(IPAddress.Parse(strIP), nPort);

                _slave_no = (byte)nSlaveNo;
                _master = ModbusIpMaster.CreateIp(_tcpserver);
                _master.Transport.ReadTimeout = 500;
                _master.Transport.WriteTimeout = 500;

                Log.WriteMessage("创建 modbus tcp 成功");
            }
            catch (Exception ex)
            {
                Log.WriteMessage("创建 modbus tcp 失败:" + ex.Message, true);
            }
        }
    }

    /// <summary>
    /// modbus-rtu 初始化
    /// </summary>
    public class ModbusRtu : ModbusHelper
    {
        private SerialPort _serialPort = new SerialPort();
        /// <summary>
        /// 创建modbus-rtu
        /// </summary>
        /// <param name="nCom">串口</param>
        /// <param name="nBaund">波特率</param>
        /// <param name="nDatabit">数据位</param>
        /// <param name="parity">奇偶校验</param>
        /// <param name="sb">停止位</param>
        /// <param name="nSlaveNo">从机号</param>
        /// <param name="nFirstAddress">首地址</param>
        public ModbusRtu(int nCom, int nBaund, int nDatabit, Parity parity, StopBits sb, byte nSlaveNo)
        {
            try
            {
                if (_serialPort.IsOpen)
                    _serialPort.Close();

                _serialPort.PortName = "COM" + nCom.ToString();
                _serialPort.BaudRate = nBaund;
                _serialPort.DataBits = nDatabit;
                _serialPort.StopBits = sb;
                _serialPort.Parity = parity;
                _serialPort.Open();

                _slave_no = nSlaveNo;
                _master = ModbusSerialMaster.CreateRtu(_serialPort);
                _master.Transport.ReadTimeout = 500;
                _master.Transport.WriteTimeout = 500;

                Log.WriteMessage("创建 modbus rtu 成功");
            }
            catch (Exception ex)
            {
                Log.WriteMessage("创建 modbus rtu 失败:" + ex.Message, true);
            }
        }
    }
    #endregion

    #region  modbus类型转换工具类
    public class ModbusUtils
    {
        public static void SetString(ushort[] src, int start, string value)
        {
            byte[] bytesTemp = Encoding.UTF8.GetBytes(value);
            ushort[] dest = Bytes2Ushorts(bytesTemp);
            dest.CopyTo(src, start);
        }

        public static string GetString(ushort[] src, int start, int len)
        {
            ushort[] temp = new ushort[len];
            for (int i = 0; i < len; i++)
            {
                temp[i] = src[i + start];
            }
            byte[] bytesTemp = Ushorts2Bytes(temp);
            string res = Encoding.UTF8.GetString(bytesTemp).Trim(new char[] { '\0' });
            return res;
        }

        public static void SetReal(ushort[] src, int start, float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            ushort[] dest = Bytes2Ushorts(bytes);

            dest.CopyTo(src, start);
        }

        public static float GetReal(ushort[] src, int start)
        {
            ushort[] temp = new ushort[2];
            for (int i = 0; i < 2; i++)
            {
                temp[i] = src[i + start];
            }
            byte[] bytesTemp = Ushorts2Bytes(temp);
            float res = BitConverter.ToSingle(bytesTemp, 0);
            return res;
        }

        public static void SetShort(ushort[] src, int start, short value)
        {
            byte[] bytes = BitConverter.GetBytes(value);

            ushort[] dest = Bytes2Ushorts(bytes);

            dest.CopyTo(src, start);
        }

        public static short GetShort(ushort[] src, int start)
        {
            ushort[] temp = new ushort[1];
            temp[0] = src[start];
            byte[] bytesTemp = Ushorts2Bytes(temp);
            short res = BitConverter.ToInt16(bytesTemp, 0);
            return res;
        }


        public static bool[] GetBools(ushort[] src, int start, int num)
        {
            ushort[] temp = new ushort[num];
            for (int i = start; i < start + num; i++)
            {
                temp[i] = src[i + start];
            }
            byte[] bytes = Ushorts2Bytes(temp);

            bool[] res = Bytes2Bools(bytes);

            return res;
        }

        private static bool[] Bytes2Bools(byte[] b)
        {
            bool[] array = new bool[8 * b.Length];

            for (int i = 0; i < b.Length; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //判定byte的最后一位是否为1，若为1，则是true；否则是false
                    array[i * 8 + j] = (b[i] & 1) == 1;
                    //将byte右移一位
                    b[i] = (byte)(b[i] >> 1);
                }
            }
            return array;
        }

        private static byte Bools2Byte(bool[] array)
        {
            if (array != null && array.Length > 0)
            {
                byte b = 0;
                for (int i = 0; i < 8; i++)
                {
                    if (array[i])
                    {
                        byte nn = (byte)(1 << i);//左移一位，相当于×2
                        b += nn;
                    }
                }
                return b;
            }
            return 0;
        }

        private static ushort[] Bytes2Ushorts(byte[] src, bool reverse = false)
        {
            int len = src.Length;

            byte[] srcPlus = new byte[len + 1];
            src.CopyTo(srcPlus, 0);
            int count = len >> 1;

            if (len % 2 != 0)
            {
                count += 1;
            }

            ushort[] dest = new ushort[count];
            if (reverse)
            {
                for (int i = 0; i < count; i++)
                {
                    dest[i] = (ushort)(srcPlus[i * 2] << 8 | srcPlus[2 * i + 1] & 0xff);
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    dest[i] = (ushort)(srcPlus[i * 2] & 0xff | srcPlus[2 * i + 1] << 8);
                }
            }

            return dest;
        }

        private static byte[] Ushorts2Bytes(ushort[] src, bool reverse = false)
        {

            int count = src.Length;
            byte[] dest = new byte[count << 1];
            if (reverse)
            {
                for (int i = 0; i < count; i++)
                {
                    dest[i * 2] = (byte)(src[i] >> 8);
                    dest[i * 2 + 1] = (byte)(src[i] >> 0);
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    dest[i * 2] = (byte)(src[i] >> 0);
                    dest[i * 2 + 1] = (byte)(src[i] >> 8);
                }
            }
            return dest;
        }
    }
    #endregion

}
