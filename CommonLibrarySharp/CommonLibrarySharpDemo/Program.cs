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
            if (DOG.DogDLl.HasDog())
            {
                Application.Run(new FormMain());
            }
        }
    }
}
