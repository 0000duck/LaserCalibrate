using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Preview.Views;

namespace Preview
{
    public partial class StartupWindow : Form
    {
        private ControlClass _controlClass;

        public StartupWindow()
        {
            InitializeComponent();
            _controlClass=ControlClass.GetInstance();
            _controlClass.Relay1.TurnOn();
            PowerSwitch.Text = "电源开";
            this.Closed += (o, args) => _controlClass.Relay1.TurnOff();
        }


        private void Exit_Click(object sender, EventArgs e)
        {
            _controlClass.Relay1.TurnOff();
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
            powerModeWindow.Closed += (o, args) => this.Show();
            powerModeWindow.Show();
            this.Hide();
        }

        private void Power_Click(object sender, EventArgs e)
        {

            if (_controlClass.Relay1.IsOpen)
            {
                _controlClass.Relay1.TurnOff();
            }
            else
            {
                _controlClass.Relay1.TurnOn();
            }
            PowerSwitch.Text = _controlClass.Relay1.IsOpen ? "电源：开" : "电源:关";
        }

        private void Replay_Click(object sender, EventArgs e)
        {
            var playBackWindow = new PlayBack();
            playBackWindow.Closed += (o, args) => this.Show();
            playBackWindow.Show();
            this.Hide();
        }
    }
}
