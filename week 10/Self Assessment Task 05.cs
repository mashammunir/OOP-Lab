using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAT5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked && checkBox2.Checked)
            {
                label1.Text = "Both Options Selected!";
            }
            else if (checkBox1.Checked)
            {
                label1.Text = "Option 1 Selected!";
            }
            else if (checkBox2.Checked)
            {
                label1.Text = "Option 2 Selected!";
            }
            else
            {
                label1.Text = "No Option Selected!";
            }
        }
    }
}
