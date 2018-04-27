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
    public partial class StartupWindow : Form
    {
        public StartupWindow()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DebugBtn_Click(object sender, EventArgs e)
        {
            var debugWindow=new DebugWindow();
            debugWindow.Closed += (o, args) => this.Show();
            debugWindow.Show();
            this.Hide();
        }

        private void PowerModeBtn_Click(object sender, EventArgs e)
        {
            var powerModeWindow = new PowerModeWindow();
            powerModeWindow.Closed += (o, args) => this.Close();
            powerModeWindow.Show();
            this.Hide();
        }
    }
}
