using CommonLibrarySharp;
using System;
using System.Windows.Forms;

namespace CommonLaserFrameWork
{
    public partial class FormPWD : Form
    {
        private static Configure _configure = new Configure();

        public FormPWD()
        {
            InitializeComponent();
        }

        private void FormPWD_Shown(object sender, EventArgs e)
        {
            textBox_pwd.Focus();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            string strpwd = _configure.ReadConfig("SET", "PWD", "123");
            if (strpwd == textBox_pwd.Text)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("密码输入错误!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Invoke((EventHandler)(delegate
                {
                    textBox_pwd.Text = "";
                    textBox_pwd.Focus();
                }));
            }
        }

        private void textBox_pwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button_ok_Click(sender, e);
            }
        }
    }
}
