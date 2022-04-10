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

namespace project
{
    public partial class redkatalog : Form
    {
        SqlConnection SqlConnection = null;
        SqlDataReader SqlDataReader = null;
        public redkatalog()
        {
            InitializeComponent();
        }

        private void deltovar_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            katalogcontol katalogcontol = new katalogcontol();
            katalogcontol.Show();
        }

        private void deltovar_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
                SqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM katalog ", SqlConnection);
                SqlDataReader = sqlCommand.ExecuteReader();

                ListViewItem item = null;
                while (SqlDataReader.Read())
                {
                    comboBox1.Items.Add(Convert.ToString(SqlDataReader["Cod"]));
                    item = new ListViewItem(new string[] { Convert.ToString(SqlDataReader["Type"]), Convert.ToString(SqlDataReader["Size"]), Convert.ToString(SqlDataReader["Price"]), Convert.ToString(SqlDataReader["Cod"]), Convert.ToString(SqlDataReader["Quantity"]), Convert.ToString(SqlDataReader["Collection"]) });
                    listView1.Items.Add(item);
                }
            }
            catch
            {
                MessageBox.Show("Возникла ошибка заполнения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (SqlDataReader != null && !SqlDataReader.IsClosed)
                {
                    SqlDataReader.Close();
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            try
            {
                SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
                SqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM katalog ", SqlConnection);
                SqlDataReader = sqlCommand.ExecuteReader();

                ListViewItem item = null;
                while (SqlDataReader.Read())
                {
                    item = new ListViewItem(new string[] { Convert.ToString(SqlDataReader["Type"]), Convert.ToString(SqlDataReader["Size"]), Convert.ToString(SqlDataReader["Price"]), Convert.ToString(SqlDataReader["Cod"]), Convert.ToString(SqlDataReader["Quantity"]), Convert.ToString(SqlDataReader["Collection"]) });
                    listView1.Items.Add(item);
                }
            }
            catch
            {
                MessageBox.Show("Возникла ошибка заполнения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (SqlDataReader != null && !SqlDataReader.IsClosed)
                {
                    SqlDataReader.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Необходимо выбрать код товара!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult res = MessageBox.Show("Вы действительно хотите Удалить товар?", "Удаление товара", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    string cod = Convert.ToString(comboBox1.Text);
                    SqlCommand sqlCommand = new SqlCommand($"DELETE FROM katalog WHERE katalog.Cod LIKE (N'{cod}')", SqlConnection);
                    if (sqlCommand.ExecuteNonQuery() >= 1)
                    {
                        MessageBox.Show("Товар успешно удален!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBox1.Items.Remove(@comboBox1.Text);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1 && textBox1.Text != "")
            {

                DialogResult result = MessageBox.Show("Вы уверены, что хотите изменить цену товара?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string price = textBox1.Text;
                    string cod = Convert.ToString(comboBox1.Text);
                    SqlCommand sqlCommand = new SqlCommand($"UPDATE katalog SET Price = N'{price}' FROM katalog WHERE katalog.Cod LIKE (N'{cod}') ", SqlConnection);
                    if (sqlCommand.ExecuteNonQuery() >= 1)
                    {
                        MessageBox.Show("Цена товара успешно изменина!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Text = "";
                        comboBox1.SelectedIndex = -1;
                    }
                }
            }
            else
            {
                MessageBox.Show("Для изменения цены необходимо указать все параметры!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1 && textBox2.Text != "" && textBox2.Text != "0") 
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите изменить цену товара?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string quantity = textBox2.Text;
                    string cod = Convert.ToString(comboBox1.Text);
                    SqlCommand sqlCommand = new SqlCommand($"UPDATE katalog SET Quantity = N'{quantity}' FROM katalog WHERE katalog.Cod LIKE (N'{cod}') ", SqlConnection);
                    if (sqlCommand.ExecuteNonQuery() >= 1)
                    {
                        MessageBox.Show("Количество товара успешно изменина!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox2.Text = "";
                        comboBox1.SelectedIndex = -1;
                    }
                }        
            }
            else
            {
                MessageBox.Show("Для изменения количества товара необходимо указать все параметры верно!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
