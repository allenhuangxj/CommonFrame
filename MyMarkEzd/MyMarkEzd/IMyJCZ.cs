using System.Collections.Generic;

namespace MyMarkEzd
{
    public interface IMyJCZ
    {
        // 初始化
        bool InitLaserMark();
        // 加载模板
        bool LoadEzdFile(string strEzd);
        // 替换打标内容
        bool ChangeTextByName(string strName, string strText);
        // 预览
        void ShowPreviewBmp(System.Windows.Forms.PictureBox pictureBox);
        // 打标
        bool Mark(bool bFly);
        // 选择对象打标
        bool MarkEntity(string strEntityName);
        // 旋转偏移整个打标模板
        bool RotateAllEzdFile(double dMoveX, double dMoveY, double dCenterX, double dCenterY, double dRotateAng);
        // 获取错误码
        string GetLastError();
        // 按对象中心旋转 指定角度
        bool CenterRotateEnt(string strEntName, double dAngle);
        // 获取对象中心坐标
        bool GetCenterPoint(string strEntityName, out double dx, out double dy);
        // 旋转对象
        bool RotateEnt(string strEntName, double dx, double dy, double dAngle);
        // 关闭
        bool CloseEZD();
        // 移动对象
        bool MoveEnt(string pEntName, double dMovex, double dMovey);
        // 复制对象
        bool CopyEnt(string strSourceName, string strDesName);
        // 删除对象
        bool DeleteEnt(string strEntName);
        // 停止标刻
        void StopMark();
        // 给输出信号脉冲
        void SetOutPortPluse(int nPort, int nState, int nMillisecond);
        // 输出信号电平
        void SetOutPort(int nPort, int nState);
        // 检测端口信号
        bool ReadPort(int nPort);
        // 获取命名对象列表 返回 name-count(命名对应的个数)
        Dictionary<string, int> GetEntryNamedCount();
    }
}
