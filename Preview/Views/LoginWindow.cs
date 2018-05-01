using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

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
            
            try
            {
                //获取记录
                var reader = new AppSettingsReader();
                var username = reader.GetValue("Username", typeof(string));
                var password = reader.GetValue("Password", typeof(string));
                //获取输入
                string inputUsername = UserNameTextbox.Text;
                string inputPassword = PasswordTextbox.Text;
                if (inputUsername == string.Empty)
                {
                    MessageBox.Show("用户名不能为空","Error");
                    return;
                }
                else if (inputPassword == String.Empty)
                {
                    MessageBox.Show("密码不能为空","Error");
                }
                else if (inputUsername == username.ToString() &&
                         inputPassword == password.ToString())
                {
                    var startup = new StartupWindow();
                    startup.Closed +=
                        (object senderObject, EventArgs eventArgs) => this.Close();
                    startup.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("用户名或密码错误","Error");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("error: " + exception.Message,"Error");
            }

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
