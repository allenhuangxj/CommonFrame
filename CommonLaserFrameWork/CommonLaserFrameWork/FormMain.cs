﻿using CommonLaserFrameWork.SplashScreen;
using CommonLibrarySharp;
using MyMarkEzd;
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
        // 流程控制
        private static bool _IsMarking = false;
        private static Object _oLock = new Object();
        // 增加脚踏
        private static MyJCZ _MarkJcz = new MyJCZ();
        private static bool _exit = false;
        private static int _start_port = 0;
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
                Log.WriteMessage("初始化成功");
                Log.WriteMessage(string.Format("脚踏端口:{0}", _start_port));

                Thread tMark = new Thread(ThreadWork);
                tMark.Start();
            }
        }

        private void ThreadWork()
        {
            bool nBegin = false;
            bool nEnd = false;
            while (!_exit)
            {
                nBegin = _MarkJcz.ReadPort(_start_port);

                if ((nBegin && !nEnd))
                {
                    Log.WriteMessage("检测到脚踏信号");
                    MarkProcess();
                    nBegin = false;
                    nEnd = false;
                    continue;
                }
                else
                {
                    nEnd = nBegin;
                }
                Thread.Sleep(10);
            }
        }

        private void button_hand_Click(object sender, EventArgs e)
        {
            Log.WriteMessage("手动点击标刻");
            MarkProcess();
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

                _exit = true;
                _IsMarking = false;
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
                Log.WriteMessage("回车响应标刻");
                MarkProcess();
            }
        }

        private void button_Stop_Click(object sender, EventArgs e)
        {
            WorkProcess.StopMark();
        }
        #endregion

        private void ReadConfig()
        {
            textBox_model.Text = _configure.ReadConfig("SET", "EzdModel", "");
            _start_port = _configure.ReadConfig("IO", "StartPort", 4);
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
                _IsMarking = false;

                this.Invoke((EventHandler)(delegate
                {
                    textBox_SN.Text = "";
                    textBox_SN.Focus();
                }));
            }

            return false;
        }

        private void button_Setting_Click(object sender, EventArgs e)
        {
            FormPWD pwd = new FormPWD();
            if (pwd.ShowDialog() == DialogResult.OK)
            {
                FormMesSetting mes_setting = new FormMesSetting();
                mes_setting.ShowDialog();
            }

            this.Invoke((EventHandler)(delegate
            {
                textBox_SN.Text = "";
                textBox_SN.Focus();
            }));
        }
    }
}
