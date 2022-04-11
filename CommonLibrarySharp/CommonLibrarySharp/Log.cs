using NLog;
using NLog.Config;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CommonLibrarySharp.WriteLog
{
    public class Log
    {
        public Logger _Logger = LogManager.GetCurrentClassLogger();
        private RichTextBox _richtextBox = null;
        private string _Config_path = Application.StartupPath + "\\NLog.config";
        private readonly object _Lock = new object();

        public Log(string strConfigPath = "")
        {
            if (!string.IsNullOrEmpty(strConfigPath))
            {
                _Config_path = strConfigPath;
            }
        }

        public void BindLogControl(RichTextBox rtBox)
        {
            _richtextBox = rtBox;
        }

        private void WriteLog(string strMsg, bool bError = false)
        {
            try
            {
                lock (_Lock)
                {
                    LogManager.Configuration = new XmlLoggingConfiguration(_Config_path);

                    if (bError == true)
                    {
                        _Logger.Error(strMsg);
                    }
                    else
                    {
                        _Logger.Info(strMsg);
                    }
                }
            }
            catch (Exception ex)
            {
                _Logger.Error("WriteLog catch error:" + ex.Message.ToString());
            }
        }

        // 对外暴露的写日志方法
        public void WriteMessage(string strLogInfo, bool bError = false)
        {
            try
            {
                lock (_Lock)
                {
                    WriteLog(strLogInfo, bError);

                    strLogInfo = DateTime.Now.ToString("[HH:mm:ss] ") + strLogInfo;
                    if (_richtextBox == null || !_richtextBox.IsHandleCreated)
                    {
                        return;
                    }

                    _richtextBox.Invoke((EventHandler)(delegate
                    {
                        if (_richtextBox.Lines.Length > 100)
                        {
                            _richtextBox.Clear();
                        }
                        strLogInfo += Environment.NewLine;
                        if (bError)
                        {
                            _richtextBox.SelectionColor = Color.Red;
                        }
                        _richtextBox.SelectionStart = _richtextBox.TextLength;
                        _richtextBox.SelectionLength = 0;
                        _richtextBox.AppendText(strLogInfo);
                        _richtextBox.SelectionColor = _richtextBox.ForeColor;
                        _richtextBox.ScrollToCaret();
                    }));
                }
            }
            catch (Exception ex)
            {
                string strErrorMsg = ex.Message.ToString();
            }
        }
    }
}
