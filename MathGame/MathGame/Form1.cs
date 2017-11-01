using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathGame
{
    public partial class Form1 : Form
    {
        public int timeLeft;
        public int a;
        public int b;
        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timeLeft = 10;
            timerLabel.Text = timeLeft.ToString();
            Random r = new Random();
            a = r.Next(10) + 1;
            b = r.Next(10) + 1;
            aLabel.Text = a.ToString();
            bLabel.Text = b.ToString();

            timer1.Start();

            startButton.Enabled = false;
            doneButton.Enabled = true;

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Stop();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                timerLabel.Text = timeLeft.ToString();
            }

            if(timeLeft == 0)
            {
                doneButton.Enabled = false;
                startButton.Enabled = true;
                timer1.Stop();
                timerLabel.Text = "You ran out of time. Try again. ";
            }
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            doneButton.Enabled = false;
            startButton.Enabled = true;
            timer1.Stop();

            int c = a + b;

            if (answerBox.Text == c.ToString())
            {
                timer1.Stop();
                timerLabel.Text = "Congratulations. You are correct!!!";
            }
            else
            {
                timerLabel.Text = "Incorrect. Play again.";
            }
        }

        private void answerBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                doneButton.Focus();
            }
        }
    }
}
