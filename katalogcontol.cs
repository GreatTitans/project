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
    public partial class katalogcontol : Form
    {
        SqlConnection SqlConnection = null;
        SqlDataReader SqlDataReader = null;
        public katalogcontol()
        {
            InitializeComponent();
        }

        private void katalogcontol_Load(object sender, EventArgs e)
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
                    item = new ListViewItem( new string[] {Convert.ToString(SqlDataReader["Type"]), Convert.ToString(SqlDataReader["Size"]), Convert.ToString(SqlDataReader["Price"]), Convert.ToString(SqlDataReader["Cod"]), Convert.ToString(SqlDataReader["Quantity"]), Convert.ToString(SqlDataReader["Collection"]) });
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
            string price = textBox1.Text;
            string cod = textBox2.Text;
            string nowcod = null;
            string Quantity = textBox3.Text;
            if (comboBox1.SelectedIndex > -1 && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                try
                {
                    SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
                    SqlConnection.Open();

                    SqlCommand sqlCommand = new SqlCommand($"SELECT katalog.Cod FROM katalog WHERE katalog.Cod like (N'{cod}')", SqlConnection);
                    SqlDataReader = sqlCommand.ExecuteReader();

                    while (SqlDataReader.Read())
                    {
                        nowcod = Convert.ToString(SqlDataReader["Cod"]);
                    }
                    if (nowcod != cod)
                    {
                        string Type = Convert.ToString(comboBox1.Text);
                        string Size = Convert.ToString(comboBox2.Text);
                        string Collection = Convert.ToString(comboBox3.Text);
                        SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
                        SqlConnection.Open();

                        SqlCommand sqlCommandMain = new SqlCommand($"INSERT INTO katalog (Type,Size,Price,Cod,Quantity, Collection) VALUES (N'{Type}',N'{Size}',N'{price}',N'{cod}',N'{Quantity}',N'{Collection}')", SqlConnection);
                        if (sqlCommandMain.ExecuteNonQuery() >= 1)
                        {
                            DialogResult result = MessageBox.Show("Товар добавлен в каталог!", "Успех!!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            if (result == DialogResult.OK)
                            {
                                //textBox1.Text = "";
                                //textBox2.Text = "";
                                //textBox3.Text = "";
                                //comboBox1.SelectedIndex = -1;
                                //comboBox2.SelectedIndex = -1;
                                //comboBox3.SelectedIndex = -1;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Данный код товара уже существует!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            else
            {
                MessageBox.Show("Заполните все параметры товара!","Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void katalogcontol_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            adminmenu adminmenu = new adminmenu();
            adminmenu.Show();
        }
        private void katalogcontol_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            redkatalog deltovar = new redkatalog();
            deltovar.Show();
        }
    }
}
