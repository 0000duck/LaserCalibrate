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
    public partial class PowerModeWindow : Form
    {
        public PowerModeWindow()
        {
            InitializeComponent();
        }

        private void LowPowerMode_Click(object sender, EventArgs e)
        {
            Start(PowerMode.Low);
        }

        private void MediumPowerMode_Click(object sender, EventArgs e)
        {
            Start(PowerMode.Medium);
        }

        private void HighPowerMode_Click(object sender, EventArgs e)
        {
            Start(PowerMode.High);
        }

        private void Start(PowerMode mode)
        {
            Application.Run(new MainWindow(mode,this));
            this.Hide();
        }
    }
}
