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

        private void button2_Click(object sender, EventArgs e)
        {
            var mainWindow=new MainWindow();
            mainWindow.Closed += (o, a) => this.Close();
            mainWindow.Show();
            this.Hide();
        }
    }
}
