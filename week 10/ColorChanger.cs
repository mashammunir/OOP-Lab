using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Color_Changer
{
    public partial class Form1 : Form
    {
        Color[] colors = { Color.Red, Color.Green, Color.Blue };
        int currentIndex = 0;

        public Form1()
        {
            InitializeComponent();
            textBox1.BackColor = colors[currentIndex];
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            currentIndex = (currentIndex + 1) % colors.Length;
            textBox1.BackColor = colors[currentIndex];
        }

        private void previousButton_Click(object sender, EventArgs e)
        {
            currentIndex = (currentIndex - 1 + colors.Length) % colors.Length;
            textBox1.BackColor = colors[currentIndex];
        }
    }
}