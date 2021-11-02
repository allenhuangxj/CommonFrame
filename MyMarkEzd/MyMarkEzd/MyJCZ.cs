using Laser_JCZ;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace MyMarkEzd
{
    [ClassInterface(ClassInterfaceType.None)]
    public class MyJCZ : IMyJCZ
    {
        //获取错误信息
        public string GetLastError()
        {
            return MarkJcz.GetLastError();
        }

        // 初始化
        public bool InitLaserMark()
        {
            if (MarkJcz.InitLaser())
            {
                return true;
            }

            return false;
        }

        // 加载模板
        public bool LoadEzdFile(string strEzd)
        {
            if (MarkJcz.LoadEzdFile(strEzd))
            {
                return true;
            }

            return false;
        }

        // 替换打标内容
        public bool ChangeTextByName(string strName, string strText)
        {
            if (MarkJcz.ChangeTextByName(strName, strText))
            {
                return true;
            }

            return false;
        }

        // 预览
        public void ShowPreviewBmp(System.Windows.Forms.PictureBox pictureBox)
        {
            MarkJcz.ShowPreviewBmp(pictureBox);
        }

        // 打标
        public bool Mark(bool bFly = false)
        {
            if (MarkJcz.Mark(bFly))
            {
                return true;
            }

            return false;
        }

        // 选择对象打标
        public bool MarkEntity(string strEntityName)
        {
            if (MarkJcz.MarkEntity(strEntityName))
            {
                return true;
            }

            return false;
        }

        // 按对象中心旋转 指定角度
        public bool CenterRotateEnt(string strEntName, double dAngle)
        {
            if (MarkJcz.RoTateEnt(strEntName, dAngle))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // 获取对象中心坐标
        public bool GetCenterPoint(string strEntityName, out double dx, out double dy)
        {
            dx = 0.0;
            dy = 0.0;
            double dCenterX = 0.0;
            double dCenterY = 0.0;
            if (MarkJcz.GetEntPos(strEntityName, ref dCenterX, ref dCenterY))
            {
                dx = dCenterX;
                dy = dCenterY;

                return true;
            }

            return false;
        }

        // 按指定坐标旋转
        public bool RotateEnt(string strEntName, double dx, double dy, double dAngle)
        {
            if (MarkJcz.RoTateEnt(strEntName, dx, dy, dAngle))
            {
                return true;
            }

            return false;
        }

        // 关闭
        public bool CloseEZD()
        {
            if (MarkJcz.Close())
            {
                return true;
            }

            return false;
        }

        // 移动对象
        public bool MoveEnt(string pEntName, double dMovex, double dMovey)
        {
            return MarkJcz.MoveEnt(pEntName, dMovex, dMovey);
        }

        // 复制对象
        public bool CopyEnt(string strSourceName, string strDesName)
        {
            return MarkJcz.CopyEnt(strSourceName, strDesName);
        }

        // 停止标刻
        public void StopMark()
        {
            MarkJcz.StopMark();
        }

        // 输出信号电平
        public void SetOutPort(int nPort, int nState)
        {
            bool bState = nState == 1 ? true : false;
            MarkJcz.WritePort(nPort, bState);
        }

        // 输出信号脉冲
        public void SetOutPortPluse(int nPort, int nState, int nMillisecond)
        {
            bool bState = nState == 1 ? true : false;
            MarkJcz.WritePort(nPort, bState);
            Thread.Sleep(nMillisecond);
            MarkJcz.WritePort(nPort, !bState);
        }

        // 检测端口信号
        public bool ReadPort(int nPort)
        {
            return MarkJcz.ReadPort(nPort);
        }

        // 获取命名对象列表 返回 name-count(命名对应的个数)
        public Dictionary<string, int> GetEntryNamedCount()
        {
            int nCount = MarkJcz.GetEntityCount();
            Dictionary<string, int> dicName = new Dictionary<string, int>();
            for (int i = 0; i < nCount; i++)
            {
                string strName = "";
                MarkJcz.GetEntityNameByIndex(i, ref strName);
                if (!string.IsNullOrEmpty(strName))
                {
                    if (dicName.ContainsKey(strName))
                    {
                        int nTemp = dicName[strName];
                        dicName[strName] = ++nTemp;
                    }
                    else
                    {
                        dicName.Add(strName, 1);
                    }
                }
            }

            return dicName;
        }

    }
}

