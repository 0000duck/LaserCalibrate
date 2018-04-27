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
    public partial class DebugWindow : Form
    {
        public DebugWindow()
        {
            InitializeComponent();
        }

        private void StartMove_Click(object sender, EventArgs e)
        {
            
        }

        private void BackBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
