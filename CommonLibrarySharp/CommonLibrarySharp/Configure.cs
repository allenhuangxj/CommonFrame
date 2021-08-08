﻿using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace CommonLibrarySharp
{
    public class Configure
    {
        private string _filePath = Application.StartupPath + "\\cfg.ini";

        public Configure()
        {

        }

        public Configure(string strFilePath)
        {
            _filePath = strFilePath;
        }

        public string FilePath
        {
            set
            {
                _filePath = value;
            }
        }

        /// <summary>
        /// 读取string类型数据
        /// </summary>
        /// <param name="strAppName"></param>
        /// <param name="strKeyName"></param>
        /// <param name="strDefault"></param>
        /// <returns></returns>
        public string ReadConfig(string strAppName, string strKeyName, string strDefault)
        {
            return ReadConfig(strAppName, strKeyName, strDefault, _filePath);
        }

        public double ReadConfig(string strAppName, string strKeyName, double dDefault)
        {
            string result = ReadConfig(strAppName, strKeyName, dDefault.ToString(), _filePath);
            return StringToDouble(result, dDefault);
        }

        public float ReadConfig(string strAppName, string strKeyName, float dDefault)
        {
            string result = ReadConfig(strAppName, strKeyName, dDefault.ToString(), _filePath);
            return StringToFloat(result, dDefault);
        }

        public string ReadConfig(string strAppName, string strKeyName, string strDefault, string strFilepath)
        {
            StringBuilder strReturn = new StringBuilder(255);
            GetPrivateProfileString(strAppName, strKeyName, strDefault, strReturn, 255, strFilepath);
            return strReturn.ToString();
        }

        /// <summary>
        /// 读取int类型数据
        /// </summary>
        /// <param name="strAppName"></param>
        /// <param name="strKeyName"></param>
        /// <param name="ndefault"></param>
        /// <returns></returns>
        public int ReadConfig(string strAppName, string strKeyName, int ndefault)
        {
            return ReadConfig(strAppName, strKeyName, ndefault, _filePath);
        }

        public bool ReadConfig(string strAppName, string strKeyName, bool bdefault)
        {
            string result = ReadConfig(strAppName, strKeyName, bdefault.ToString(), _filePath);
            return StringToBool(result, bdefault);
        }

        public int ReadConfig(string strAppName, string strKeyName, int ndefault, string strFilepath)
        {
            int result = GetPrivateProfileInt(strAppName, strKeyName, ndefault, strFilepath);
            return result;
        }

        /// <summary>
        /// 写入string类型数据
        /// </summary>
        /// <param name="strAppName"></param>
        /// <param name="strKeyName"></param>
        /// <param name="strString"></param>
        /// <returns></returns>
        public bool WriteConfig(string strAppName, string strKeyName, string strString)
        {
            return WritePrivateProfileString(strAppName, strKeyName, strString, _filePath);
        }

        public bool WriteConfig(string strAppName, string strKeyName, string strString, string strFilepath)
        {
            return WritePrivateProfileString(strAppName, strKeyName, strString, strFilepath);
        }

        /// <summary>
        /// 写入int类型数据
        /// </summary>
        /// <param name="strAppName"></param>
        /// <param name="strKeyName"></param>
        /// <param name="strString"></param>
        /// <returns></returns>
        public bool WriteConfig(string strAppName, string strKeyName, int strString)
        {
            return WritePrivateProfileString(strAppName, strKeyName, strString.ToString(), _filePath);
        }

        public bool WriteConfig(string strAppName, string strKeyName, int strString, string strFilepath)
        {
            return WritePrivateProfileString(strAppName, strKeyName, strString.ToString(), strFilepath);
        }

        public static double StringToDouble(string strValue, double Fail)
        {
            double result = Fail;
            if (strValue == null || strValue == "")
            {
                return result;
            }
            if (!Double.TryParse(strValue, out result))
            {
                result = Fail;
            }
            return result;
        }

        public static float StringToFloat(string strValue, float Fail)
        {
            float result = Fail;
            if (strValue == null || strValue == "")
            {
                return result;
            }
            if (!float.TryParse(strValue, out result))
            {
                result = Fail;
            }
            return result;
        }

        public static int StringToInt(string strValue, int Fail)
        {
            int result = Fail;
            if (strValue == null || strValue == "")
            {
                return result;
            }
            if (!Int32.TryParse(strValue, out result))
            {
                result = Fail;
            }
            return result;
        }

        public static bool StringToBool(string strValue, bool Fail)
        {
            bool result = Fail;
            if (strValue == null || strValue == "")
            {
                return result;
            }
            if (!bool.TryParse(strValue, out result))
            {
                result = Fail;
            }
            return result;
        }

        [DllImport("Kernel32.dll")]
        private static extern ulong GetPrivateProfileString(string strAppName, string strKeyName, string strDefault,
            StringBuilder sbReturnString, int nSize, string strFileName);

        [DllImport("Kernel32.dll")]
        private static extern bool WritePrivateProfileString(string strAppName, string strKeyName, string strString,
            string strFileName);

        [DllImport("Kernel32.dll")]
        private static extern int GetPrivateProfileInt(string strAppName, string strKeyName, int nDefault,
            string strFileName);
    }
}
