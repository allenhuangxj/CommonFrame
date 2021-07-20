﻿using CommonLibrarySharp;
using MyMarkEzd;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CommonLaserFrameWork
{
    public class WorkProcess
    {
        // 金橙子
        private static MyJCZ _MarkJcz = new MyJCZ();
        private static PictureBox _pictureBox1;

        // 打开主窗体前的初始化
        public static bool InitForm(PictureBox pictureBox1)
        {
            _pictureBox1 = pictureBox1;
            try
            {
                if (!_MarkJcz.InitLaserMark())
                {
                    string strMsg = string.Format("初始化激光器失败,错误信息:{0}", _MarkJcz.GetLastError());
                    MessageBox.Show(strMsg, "初始化激光器失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Log.WriteMessage(strMsg, true);

                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteMessage(string.Format("CheckBeforeMark 捕获到异常:{0}", ex.Message.ToString()), true);
            }

            return false;
        }

        public static bool TreggerReadPort(int nPort)
        {
            try
            {
                return _MarkJcz.TreggerReadPort(nPort);
            }
            catch (Exception ex)
            {
                Log.WriteMessage(string.Format("TreggerReadPort 捕获到异常:{0}", ex.Message.ToString()), true);
            }

            return false;
        }
        // 加载模板
        public static bool LoadEzdFile(string strEzdPath)
        {
            try
            {
                _MarkJcz.LoadEzdFile(strEzdPath);
                _MarkJcz.ShowPreviewBmp(_pictureBox1);

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteMessage(string.Format("LoadEzdFile 捕获到异常:{0}", ex.Message.ToString()), true);
            }

            return false;
        }

        // 打标前的校验
        private static bool CheckBeforeMark()
        {
            Log.WriteMessage("打标前检测");
            try
            {

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteMessage(string.Format("CheckBeforeMark 捕获到异常:{0}", ex.Message.ToString()), true);
            }

            return false;
        }

        // 加载模板替换打标
        private static bool ChangeVariableAndMark(Dictionary<string, string> dicControlValue)
        {
            Log.WriteMessage("加载模板并替换打标");
            try
            {
                // 加载模板
                string strEzdPath = dicControlValue["ezd"].ToString();
                if (!_MarkJcz.LoadEzdFile(strEzdPath))
                {
                    Log.WriteMessage("加载模板失败", true);
                    return false;
                }

                // 替换打标
                string strSn = dicControlValue["SN"].ToString();
                _MarkJcz.ChangeTextByName("SN", strSn);
                _MarkJcz.ShowPreviewBmp(_pictureBox1);
                Log.WriteMessage("开始打标");
                if (_MarkJcz.Mark())
                {
                    Log.WriteMessage("打标成功");
                }
                else
                {
                    Log.WriteMessage("打标失败");
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteMessage(string.Format("ChangeVariableAndMark 捕获到异常:{0}", ex.Message.ToString()), true);
            }

            return false;
        }

        // 打标流程
        public static bool MarkProcessImpl(Dictionary<string, string> dicControlValue)
        {
            try
            {
                CheckBeforeMark();

                if (ChangeVariableAndMark(dicControlValue))
                {
                    UploadAfterMark();
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteMessage(string.Format("MarkProcessImpl 捕获到异常:{0}", ex.Message.ToString()), true);
            }
            finally
            {

            }

            return false;
        }

        // 打标后的保存上传等操作
        private static bool UploadAfterMark()
        {
            Log.WriteMessage("打标后上传保存");
            try
            {


                return true;
            }
            catch (Exception ex)
            {
                Log.WriteMessage(string.Format("CheckBeforeMark 捕获到异常:{0}", ex.Message.ToString()), true);
            }

            return false;
        }

        // 关闭主窗体后执行
        public static bool CloseForm()
        {
            try
            {
                _MarkJcz.StopMark();
                _MarkJcz.CloseEZD();

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteMessage(string.Format("CloseForm 捕获到异常:{0}", ex.Message.ToString()), true);
            }

            return false;
        }

        public static void StopMark()
        {
            _MarkJcz.StopMark();
        }
    }
}