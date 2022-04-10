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

    public partial class sweathirts : Form
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);

        public sweathirts()
        {
            InitializeComponent();
        }

        private void sweathirts_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            stuff stuff = new stuff();
            stuff.Show();
        }

        private void sweathirts_Load(object sender, EventArgs e)
        {
            sqlConnection.Open();
            label5.Text = prof.loginname;
            label6.Text = prof.balls;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                visible();
                if (comboBox2.SelectedIndex == 1 && comboBox1.SelectedIndex == 0)
                {
                    label9.Text = "10";
                    label12.Text = "11";
                    label16.Text = "12";

                    label10.Text = "150";
                    label11.Text = "150";
                    label15.Text = "150";

                }
                else if (comboBox2.SelectedIndex == 1 && comboBox1.SelectedIndex == 1)
                {
                    label9.Text = "13";
                    label12.Text = "14";
                    label16.Text = "15";

                    label10.Text = "150";
                    label11.Text = "150";
                    label15.Text = "150";
                }
                else if (comboBox2.SelectedIndex == 0 && comboBox1.SelectedIndex == 0)
                {
                    label9.Text = "16";
                    label12.Text = "17";
                    label16.Text = "18";

                    label10.Text = "100";
                    label11.Text = "100";
                    label15.Text = "100";
                }
                else if (comboBox2.SelectedIndex == 0 && comboBox1.SelectedIndex == 1)
                {
                    MessageBox.Show("Сейчас нет такого размера в этой коллекции!", "Уведомление", MessageBoxButtons.OK,MessageBoxIcon.Information);
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 1 && comboBox1.SelectedIndex == 0)
            {
                string cod = label9.Text;
                SqlCommand sqlCommand = new SqlCommand($"INSERT INTO bucket (Type,Size,Price,Collection, Cod) values (N'Кофта', N'XXL',N'150',N'Зима 2021', N'{cod}')", sqlConnection);
                if (sqlCommand.ExecuteNonQuery() >= 1)
                {
                    MessageBox.Show("Товар успешно добавлен в корзину!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (comboBox2.SelectedIndex == 1 && comboBox1.SelectedIndex == 1)
            {
                string cod = label9.Text;
                SqlCommand sqlCommand = new SqlCommand($"INSERT INTO bucket (Type,Size,Price,Collection, Cod) values (N'Кофта', N'XXL',N'150',N'Зима 2021', N'{cod}')", sqlConnection);
                if (sqlCommand.ExecuteNonQuery() >= 1)
                {
                    MessageBox.Show("Товар успешно добавлен в корзину!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (comboBox2.SelectedIndex == 0 && comboBox1.SelectedIndex == 0)
            {
                string cod = label9.Text;
                SqlCommand sqlCommand = new SqlCommand($"INSERT INTO bucket (Type,Size,Price,Collection, Cod) values (N'Кофта', N'XL',N'150',N'Осень 2021', N'{cod}')", sqlConnection);
                if (sqlCommand.ExecuteNonQuery() >= 1)
                {
                    MessageBox.Show("Товар успешно добавлен в корзину!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (comboBox2.SelectedIndex == 0 && comboBox1.SelectedIndex == 1)
            {
                    MessageBox.Show("Нет подходящего размера!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 1 && comboBox1.SelectedIndex == 0)
            {
                string cod = label12.Text;
                SqlCommand sqlCommand = new SqlCommand($"INSERT INTO bucket (Type,Size,Price,Collection, Cod) values (N'Кофта', N'XXL',N'150',N'Зима 2021', N'{cod}')", sqlConnection);
                if (sqlCommand.ExecuteNonQuery() >= 1)
                {
                    MessageBox.Show("Товар успешно добавлен в корзину!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (comboBox2.SelectedIndex == 1 && comboBox1.SelectedIndex == 1)
            {
                string cod = label12.Text;
                SqlCommand sqlCommand = new SqlCommand($"INSERT INTO bucket (Type,Size,Price,Collection, Cod) values (N'Кофта', N'XXL',N'150',N'Зима 2021', N'{cod}')", sqlConnection);
                if (sqlCommand.ExecuteNonQuery() >= 1)
                {
                    MessageBox.Show("Товар успешно добавлен в корзину!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (comboBox2.SelectedIndex == 0 && comboBox1.SelectedIndex == 0)
            {
                string cod = label12.Text;
                SqlCommand sqlCommand = new SqlCommand($"INSERT INTO bucket (Type,Size,Price,Collection, Cod) values (N'Кофта', N'XL',N'150',N'Осень 2021', N'{cod}')", sqlConnection);
                if (sqlCommand.ExecuteNonQuery() >= 1)
                {
                    MessageBox.Show("Товар успешно добавлен в корзину!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (comboBox2.SelectedIndex == 0 && comboBox1.SelectedIndex == 1)
            {
                MessageBox.Show("Нет подходящего размера!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 1 && comboBox1.SelectedIndex == 0)
            {
                string cod = label16.Text;
                SqlCommand sqlCommand = new SqlCommand($"INSERT INTO bucket (Type,Size,Price,Collection, Cod) values (N'Кофта', N'XXL',N'150',N'Зима 2021', N'{cod}')", sqlConnection);
                if (sqlCommand.ExecuteNonQuery() >= 1)
                {
                    MessageBox.Show("Товар успешно добавлен в корзину!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (comboBox2.SelectedIndex == 1 && comboBox1.SelectedIndex == 1)
            {
                string cod = label16.Text;
                SqlCommand sqlCommand = new SqlCommand($"INSERT INTO bucket (Type,Size,Price,Collection, Cod) values (N'Кофта', N'XXL',N'150',N'Зима 2021', N'{cod}')", sqlConnection);
                if (sqlCommand.ExecuteNonQuery() >= 1)
                {
                    MessageBox.Show("Товар успешно добавлен в корзину!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (comboBox2.SelectedIndex == 0 && comboBox1.SelectedIndex == 0)
            {
                string cod = label16.Text;
                SqlCommand sqlCommand = new SqlCommand($"INSERT INTO bucket (Type,Size,Price,Collection, Cod) values (N'Кофта', N'XL',N'150',N'Осень 2021', N'{cod}')", sqlConnection);
                if (sqlCommand.ExecuteNonQuery() >= 1)
                {
                    MessageBox.Show("Товар успешно добавлен в корзину!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (comboBox2.SelectedIndex == 0 && comboBox1.SelectedIndex == 1)
            {
                MessageBox.Show("Нет подходящего размера!", "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
