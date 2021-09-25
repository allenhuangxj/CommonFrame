using CommonLibrarySharp;
using System;
using System.Windows.Forms;

namespace CommonLaserFrameWork
{
    public partial class FormMesSetting : Form
    {
        private Configure _configure = new Configure();
        public FormMesSetting()
        {
            InitializeComponent();
        }

        private void FormMesSetting_Load(object sender, EventArgs e)
        {
            textBox_info.Text = _configure.ReadConfig("MES", "info", "");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            _configure.WriteConfig("MES", "info", textBox_info.Text);
            this.DialogResult = DialogResult.OK;
        }
    }
}
