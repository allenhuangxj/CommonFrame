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
        // 获取错误码
        string GetLastError();
        // 按对象中心旋转 指定角度
        bool CenterRotateEnt(string strEntName, double dAngle);
        // 获取对象中心坐标
        bool GetCenterPoint(string strEntityName, out double dx, out double dy);
        // 按指定坐标旋转
        bool RotateEnt(string strEntName, double dx, double dy, double dAngle);
        // 关闭
        bool CloseEZD();
        // 检测脚踏
        bool TreggerReadPort(int nPort);
        // 移动对象
        bool MoveEnt(string pEntName, double dMovex, double dMovey);
        // 复制对象
        bool CopyEnt(string strSourceName, string strDesName);
        // 停止标刻
        void StopMark();
        // 给输出信号
        void SetOutPort(int nPort, int nState, int nMillisecond);
        // 检测端口信号
        bool ReadPort(int nPort);
    }
}
