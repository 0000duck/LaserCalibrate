using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Preview
{
    public partial class LoginWindow : Form
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            //TODO：判断用户名和密码是否正确
            if (true) //此处修改为判断条件
            {
                var startup = new StartupWindow();
                startup.Closed += (object senderObject, EventArgs eventArgs) => this.Close();
                startup.Show();
                this.Hide();
            }


        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
