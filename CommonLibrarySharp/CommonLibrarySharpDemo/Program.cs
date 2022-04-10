using System;
using System.Windows.Forms;

namespace CommonLibrarySharpDemo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#if !DEBUG
            if (DogDLl.HasDog())
#endif
            {
                Application.Run(new FormMain());
            }
        }
    }
}
