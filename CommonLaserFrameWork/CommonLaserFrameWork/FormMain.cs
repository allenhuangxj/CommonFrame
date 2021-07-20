using CommonLaserFrameWork.SplashScreen;
using CommonLibrarySharp;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace CommonLaserFrameWork
{
    public partial class FormMain : Form
    {
        // 通用读取配置文件
        private Configure _configure = new Configure();
        // IO
        private static int _startIO = 4;
        private static Thread _ThreadIO = null;
        // 流程控制
        private static bool _IsMarking = false;
        private static Object _oLock = new Object();
        private static bool _bExit = false;
        private static bool _bManual = false;

        public FormMain()
        {
            SplashScreen.SplashScreen.Show(typeof(FormSplashShow));
            Thread.Sleep(500);
            SplashScreen.SplashScreen.Close();

            InitializeComponent();
            // 绑定日志控件  添加 NLog.dll NLog.config 文件到 exe目录即可
            Log.BindLogControl(richTextBox_Log);
        }

        #region 窗体相关事件
        private void FormMain_Load(object sender, EventArgs e)
        {
            ReadConfig();
            if (WorkProcess.InitForm(this.pictureBox1))
            {
                Log.WriteMessage("启动脚踏检测线程");
                _ThreadIO = new Thread(ThreadIO);
                _ThreadIO.Start();
            }

            Log.WriteMessage(string.Format("开启软件, 脚踏端口为:{0}", _startIO.ToString()));
        }

        private void ThreadIO()
        {
            try
            {
                while (!_bExit)
                {
                    lock (_oLock)
                    {
                        if (_IsMarking)
                        {
                            continue;
                        }
                    }

                    bool bTrgger = WorkProcess.TreggerReadPort(_startIO);
                    if (bTrgger || _bManual)
                    {
                        string strMsg = bTrgger == true ? "接收到开始打标信号" : "手动触发打标";
                        Log.WriteMessage(strMsg);
                        MarkProcess();
                    }

                    Thread.Sleep(20);
                }
            }
            catch (Exception ex)
            {
                Log.WriteMessage(string.Format("ThreadIO 捕获到异常:{0}", ex.Message.ToString()), true);
            }
        }

        private void button_hand_Click(object sender, EventArgs e)
        {
            _bManual = true;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (MessageBox.Show("是否退出程序?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                {
                    e.Cancel = true;
                    return;
                }

                _bExit = true;
                _IsMarking = false;
                _bManual = false;
                WriteConfig();
                WorkProcess.CloseForm();
            }
            catch (Exception ex)
            {
                Log.WriteMessage("FormMain_FormClosing 异常:" + ex.Message, true);
                return;
            }
        }

        private void button_load_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = null;
            openFileDialog.Filter = "ezd文件|*.ezd|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox_model.Text = openFileDialog.FileName;
                _configure.WriteConfig("SET", "EzdModel", textBox_model.Text);

                WorkProcess.LoadEzdFile(textBox_model.Text);
            }
        }
        private void FormMain_Shown(object sender, EventArgs e)
        {
            textBox_SN.Focus();
        }

        private void textBox_SN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                Log.WriteMessage("回车响应");
                _bManual = true;
            }
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            WorkProcess.StopMark();
        }
        #endregion

        private void ReadConfig()
        {
            _startIO = _configure.ReadConfig("SET", "StartIO", 4);
            textBox_model.Text = _configure.ReadConfig("SET", "EzdModel", "");
        }

        private void WriteConfig()
        {
            _configure.WriteConfig("SET", "EzdModel", textBox_model.Text);
        }

        // 获取主窗体控件内容
        public Dictionary<string, string> GetControlValue()
        {
            Dictionary<string, string> dicControlValue = new Dictionary<string, string>();

            try
            {
                this.Invoke((EventHandler)(delegate
                {
                    dicControlValue.Add("ezd", textBox_model.Text);
                    dicControlValue.Add("SN", textBox_SN.Text);
                }));
            }
            catch (Exception ex)
            {
                Log.WriteMessage("GetControlValue 异常:" + ex.Message, true);
            }

            return dicControlValue;
        }

        public bool MarkProcess()
        {
            _IsMarking = true;
            Log.WriteMessage("开始执行打标流程");

            try
            {
                Dictionary<string, string> dicControlValue = GetControlValue();
                WorkProcess.MarkProcessImpl(dicControlValue);
                Log.WriteMessage("++++++++++结束本次打标流程++++++++++");
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteMessage(string.Format("MarkProcess 捕获到异常:{0}", ex.Message.ToString()), true);
            }
            finally
            {
                _bManual = false;
                _IsMarking = false;

                this.Invoke((EventHandler)(delegate
                {
                    textBox_SN.Text = "";
                    textBox_SN.Focus();
                }));
            }

            return false;
        }

    }
}
