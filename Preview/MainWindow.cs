using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using cszmcaux;

namespace Preview
{
    public partial class MainWindow : Form
    {
        private Form _lastForm;
        private PowerMode _mode;
        public MainWindow(PowerMode mode,Form powerModeWindow)
        {
            InitializeComponent();
            _mode = mode;
            _lastForm = powerModeWindow;
            switch (_mode)
            {
                case PowerMode.High:PowerModeLabel.Text="工作模式：高功率";break;
                case PowerMode.Medium: PowerModeLabel.Text = "工作模式：中功率"; break;
                case PowerMode.Low: PowerModeLabel.Text = "工作模式：低功率"; break;
            }
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            _lastForm.Show();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            _lastForm.Close();
            this.Close();
        }
    }

}
