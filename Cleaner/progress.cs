using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Cleaner
{
    public partial class progress : Form
    {
        public static bool complete = false;
        Thread t;
        int cur;

        public progress(string state,int value)
        {
            InitializeComponent();
            label1.Text = state;
           // cur = value;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Interval = 1000;
            cleaning.Maximum = 10;
        }

        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(cleaning.Value != 10)
            {
                cleaning.Value++;
            }else
            {
                timer1.Stop();
                //this.DialogResult = DialogResult.OK;
                complete = true;
                //this.Hide();
            }
        }
    }
}
