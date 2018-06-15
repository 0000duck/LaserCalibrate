using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace Preview
{
    public partial class DebugWindow : Form
    {
        private ControlClass _control;
        private bool relaySwitch = false;
        private int axis=0;
        public DebugWindow()
        {
            InitializeComponent();
            _control=ControlClass.GetInstance();
            _control.StartPreview(AngleImg,ShiftImg);
            updateTimer.Interval = (40);
            updateTimer.Tick+= (o,e) => _control.DrawCross();

        }

        private void StartMove_Click(object sender, EventArgs e)
        {
            if (Angle.Text==string.Empty)
            {
                MessageBox.Show("请输入运动角度");
                return;
            }
            else
            {
                try
                {
                    float angle = float.Parse(Angle.Text);
                    _control.motorController.SingleAxisMove(axis, angle);
                }
                catch (Exception)
                {
                    MessageBox.Show("请输入合法的数值");
                }
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            updateTimer.Stop();
            updateTimer.Dispose();
            _control.StopPreview();
            this.Close();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            _control.StopPreview();
            updateTimer.Stop();
            updateTimer.Dispose();
            this.Close();
        }

        private void StopMoveButton_Click(object sender, EventArgs e)
        {
            _control.motorController.StopMove();
        }

        private void xAxis_CheckedChanged(object sender, EventArgs e)
        {
            axis = 0;
        }

        private void yAxis_CheckedChanged(object sender, EventArgs e)
        {
            axis = 1;
        }

        private void zAxis_CheckedChanged(object sender, EventArgs e)
        {
            axis = 3;
        }

        private void rAxis_CheckedChanged(object sender, EventArgs e)
        {
            axis = 4;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (relaySwitch)
            {
                _control.Relay2.TurnOn();
                button3.Text = "指示激光：已开启";
                relaySwitch = true;
            }
            else
            {
                _control.Relay2.TurnOff();
                button3.Text = "指示激光：已关闭关";
                relaySwitch = false;
            }
                
            
        }

    }
}
