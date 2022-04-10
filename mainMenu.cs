using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            avtoreg avtoreg = new avtoreg();
            avtoreg.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            stuff stuff = new stuff();
            stuff.Show();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            label4.Text = prof.loginname;
            label7.Text = prof.balls;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            korzina korzina = new korzina();
            korzina.Show();
        }
    }
}
