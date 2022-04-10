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
    public partial class stuff : Form
    {
        public stuff()
        {
            InitializeComponent();
        }

        private void katalog_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            avtoreg avtoreg = new avtoreg();
            avtoreg.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            katalog.tshirts tshirts = new katalog.tshirts();
            tshirts.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            katalog.sweathirts sweathirts = new katalog.sweathirts();
            sweathirts.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            katalog.mugs mugs = new katalog.mugs();
            mugs.Show();
        }

        private void katalog_Load(object sender, EventArgs e)
        {
            label5.Text = prof.loginname;
            label6.Text = prof.balls;
        }
    }
}
