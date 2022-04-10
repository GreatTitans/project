using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Media;

namespace project
{
    public partial class balls : Form
    {
        SqlConnection sqlConnection = null;
        SqlCommand SqlCommand = null;
        SqlDataReader sqlDataReader = null;
        public balls()
        {
            InitializeComponent();
        }

        private void balls_Load(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.Clear();
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("SELECT regbd.Login, regbd.Balls FROM regbd", sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();

                ListViewItem item = null;

                while (sqlDataReader.Read())
                {
                    comboBox1.Items.Add(Convert.ToString(sqlDataReader["Login"]));
                    item = new ListViewItem(new string[] { Convert.ToString(sqlDataReader["Login"]), Convert.ToString(sqlDataReader["Balls"]) });
                    listView1.Items.Add(item);
                }
            }
            catch
            {
                MessageBox.Show("Возникла ошибка пополнения!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (sqlDataReader != null && !sqlDataReader.IsClosed)
            {
                sqlDataReader.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                string login = comboBox1.SelectedItem.ToString();
                string nowballs = null;
                string addballs = textBox1.Text;
                if (textBox1.Text != "")
                {
                    try
                    {
                        sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
                        sqlConnection.Open();

                        SqlCommand sqlCommand = new SqlCommand($"SELECT regbd.Balls FROM regbd WHERE regbd.Login like (N'{login}')", sqlConnection);
                        sqlDataReader = sqlCommand.ExecuteReader();


                        while (sqlDataReader.Read())
                        {
                            nowballs = Convert.ToString(sqlDataReader["Balls"]);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Возникла ошибка пополнения!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (sqlDataReader != null && !sqlDataReader.IsClosed)
                    {
                        sqlDataReader.Close();
                    }
                    int tryaddballs = Convert.ToInt32(nowballs) + Convert.ToInt32(addballs);

                    SqlCommand = new SqlCommand($"UPDATE regbd SET regbd.Balls  = (N'{tryaddballs}') WHERE regbd.Login like (N'{login}')", sqlConnection);
                    if (SqlCommand.ExecuteNonQuery() >= 1)
                    {
                        MessageBox.Show("Баллы были успешно зачислены!", "Успех!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    MessageBox.Show("Введите количество баллов для зачисления!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя!", "Предупреждение!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                listView1.Items.Clear();
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("SELECT regbd.Login, regbd.Balls FROM regbd", sqlConnection);
                sqlDataReader = sqlCommand.ExecuteReader();

                ListViewItem item = null;

                while (sqlDataReader.Read())
                {
                    item = new ListViewItem(new string[] { Convert.ToString(sqlDataReader["Login"]), Convert.ToString(sqlDataReader["Balls"]) });
                    listView1.Items.Add(item);
                }
            }
            catch
            {
                MessageBox.Show("Возникла ошибка пополнения!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (sqlDataReader != null && !sqlDataReader.IsClosed)
            {
                sqlDataReader.Close();
            }
        }

        private void balls_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            adminmenu adminmenu = new adminmenu();
            adminmenu.Show();
        }
    }
}
