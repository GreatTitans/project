using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace project
{
    public partial class adminmenu : Form
    {
        public adminmenu()
        {
            InitializeComponent();
        }

        private void adminmenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            authorization authorization = new authorization();
            authorization.Show();
        }

        private void adminmenu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            balls balls = new balls();
            balls.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            katalogcontol katalogcontol = new katalogcontol();
            katalogcontol.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
        }
    }
}
