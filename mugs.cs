using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project.katalog
{
    public partial class mugs : Form
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
        public mugs()
        {
            InitializeComponent();
        }

        private void mugs_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            stuff stuff = new stuff();
            stuff.Show();
        }

        private void mugs_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();
            label5.Text = prof.loginname;
            label6.Text = prof.balls;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex != -1)
            {
                visible();
                if (comboBox2.SelectedIndex == 0)
                {
                    label9.Text = "20";
                    label12.Text = "21";
                    label16.Text = "22";

                    label10.Text = "50";
                    label11.Text = "50";
                    label15.Text = "50";
                }
                else if (comboBox2.SelectedIndex == 1)
                {
                    label9.Text = "23";
                    label12.Text = "24";
                    label16.Text = "25";

                    label10.Text = "50";
                    label11.Text = "50";
                    label15.Text = "50";
                }
                else if (comboBox2.SelectedIndex == 2)
                {
                    label9.Text = "26";
                    label12.Text = "27";
                    label16.Text = "28";

                    label10.Text = "50";
                    label11.Text = "50";
                    label15.Text = "50";
                }
            }
            else
            {
                MessageBox.Show("Необходимо указать все параметры поиска!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void visible()
        {
            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;

            pictureBox1.Visible = true;
            label3.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            pictureBox2.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            pictureBox3.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
            label18.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                string cod = label9.Text;
                SqlCommand sqlCommand = new SqlCommand($"INSERT INTO bucket (Type,Size,Price,Collection, Cod) values (N'Кружка', N'',N'50',N'Весна 2021', N'{cod}')", sqlConnection);
                if (sqlCommand.ExecuteNonQuery() >= 1)
                {
                    MessageBox.Show("Товар успешно добавлен в корзину!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                string cod = label9.Text;
                SqlCommand sqlCommand = new SqlCommand($"INSERT INTO bucket (Type,Size,Price,Collection, Cod) values (N'Кружка', N'',N'50',N'Лето 2021', N'{cod}')", sqlConnection);
                if (sqlCommand.ExecuteNonQuery() >= 1)
                {
                    MessageBox.Show("Товар успешно добавлен в корзину!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                string cod = label9.Text;
                SqlCommand sqlCommand = new SqlCommand($"INSERT INTO bucket (Type,Size,Price,Collection, Cod) values (N'Кружка', N'',N'50',N'Осень 2021', N'{cod}')", sqlConnection);
                if (sqlCommand.ExecuteNonQuery() >= 1)
                {
                    MessageBox.Show("Товар успешно добавлен в корзину!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                string cod = label12.Text;
                SqlCommand sqlCommand = new SqlCommand($"INSERT INTO bucket (Type,Size,Price,Collection, Cod) values (N'Кружка', N'',N'50',N'Весна 2021', N'{cod}')", sqlConnection);
                if (sqlCommand.ExecuteNonQuery() >= 1)
                {
                    MessageBox.Show("Товар успешно добавлен в корзину!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                string cod = label12.Text;
                SqlCommand sqlCommand = new SqlCommand($"INSERT INTO bucket (Type,Size,Price,Collection, Cod) values (N'Кружка', N'',N'50',N'Лето 2021', N'{cod}')", sqlConnection);
                if (sqlCommand.ExecuteNonQuery() >= 1)
                {
                    MessageBox.Show("Товар успешно добавлен в корзину!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                string cod = label12.Text;
                SqlCommand sqlCommand = new SqlCommand($"INSERT INTO bucket (Type,Size,Price,Collection, Cod) values (N'Кружка', N'',N'50',N'Осень 2021', N'{cod}')", sqlConnection);
                if (sqlCommand.ExecuteNonQuery() >= 1)
                {
                    MessageBox.Show("Товар успешно добавлен в корзину!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                string cod = label16.Text;
                SqlCommand sqlCommand = new SqlCommand($"INSERT INTO bucket (Type,Size,Price,Collection, Cod) values (N'Кружка', N'',N'50',N'Весна 2021', N'{cod}')", sqlConnection);
                if (sqlCommand.ExecuteNonQuery() >= 1)
                {
                    MessageBox.Show("Товар успешно добавлен в корзину!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (comboBox2.SelectedIndex == 1)
            {
                string cod = label16.Text;
                SqlCommand sqlCommand = new SqlCommand($"INSERT INTO bucket (Type,Size,Price,Collection, Cod) values (N'Кружка', N'',N'50',N'Лето 2021', N'{cod}')", sqlConnection);
                if (sqlCommand.ExecuteNonQuery() >= 1)
                {
                    MessageBox.Show("Товар успешно добавлен в корзину!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (comboBox2.SelectedIndex == 2)
            {
                string cod = label16.Text;
                SqlCommand sqlCommand = new SqlCommand($"INSERT INTO bucket (Type,Size,Price,Collection, Cod) values (N'Кружка', N'',N'50',N'Осень 2021', N'{cod}')", sqlConnection);
                if (sqlCommand.ExecuteNonQuery() >= 1)
                {
                    MessageBox.Show("Товар успешно добавлен в корзину!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
