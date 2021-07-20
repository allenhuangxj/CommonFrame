using NLog;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CommonLibrarySharp
{
    public class Log
    {
        public static Logger _Logger = LogManager.GetCurrentClassLogger();
        private static RichTextBox _richtextBox = null;
        private static readonly object _Lock = new object();

        public static void BindLogControl(RichTextBox rtBox)
        {
            _richtextBox = rtBox;
        }

        private static void WriteLog(string strMsg, bool bError = false)
        {
            if (bError == true)
            {
                _Logger.Error(strMsg);
            }
            else
            {
                _Logger.Info(strMsg);
            }
        }

        // 对外暴露的写日志方法
        public static void WriteMessage(string strLogInfo, bool bError = false)
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
