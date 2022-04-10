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

namespace project
{
    public partial class korzina : Form
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
        SqlDataReader SqlDataReader = null;
        public korzina()
        {
            InitializeComponent();
        }

        private void korzina_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            MainMenu mainMenu = new MainMenu();
            mainMenu.Show();
        }

        private void korzina_Load(object sender, EventArgs e)
        {
            label5.Text = prof.loginname;
            label6.Text = prof.balls;
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM bucket", sqlConnection);
            SqlDataReader = sqlCommand.ExecuteReader();

            ListViewItem item = null;
            while(SqlDataReader.Read())
            {
                comboBox1.Items.Add(Convert.ToString(SqlDataReader["Cod"]));
                item = new ListViewItem(new string[] { Convert.ToString(SqlDataReader["Type"]), Convert.ToString(SqlDataReader["Size"]), Convert.ToString(SqlDataReader["Price"]), Convert.ToString(SqlDataReader["Collection"]), Convert.ToString(SqlDataReader["Cod"]) }) ;
                listView1.Items.Add(item);
            }
            SqlDataReader.Close();
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
                    SqlCommand sqlCommand1 = new SqlCommand($"DELETE FROM bucket WHERE bucket.Cod LIKE (N'{cod}')", sqlConnection);
                    if (sqlCommand1.ExecuteNonQuery() >= 1)
                    {
                        MessageBox.Show("Товар успешно удален!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comboBox1.Items.Remove(@comboBox1.Text);
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            try
            {
                SqlCommand sqlCommand2 = new SqlCommand("SELECT * FROM bucket", sqlConnection);
                SqlDataReader = sqlCommand2.ExecuteReader();

                ListViewItem item = null;
                while (SqlDataReader.Read())
                {
                    item = new ListViewItem(new string[] { Convert.ToString(SqlDataReader["Type"]), Convert.ToString(SqlDataReader["Size"]), Convert.ToString(SqlDataReader["Price"]), Convert.ToString(SqlDataReader["Collection"]), Convert.ToString(SqlDataReader["Cod"]) });
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

        private void button2_Click(object sender, EventArgs e)
        {
                int fullprice = 0;
                SqlCommand sqlCommand3 = new SqlCommand("SELECT bucket.Price FROM bucket", sqlConnection);
                SqlDataReader = sqlCommand3.ExecuteReader();

                while (SqlDataReader.Read())
                {
                    fullprice = fullprice + Convert.ToInt32(SqlDataReader["Price"]);
                }
                SqlDataReader.Close();
                if (Convert.ToInt32(prof.balls) >= fullprice)
                {
                    int newballs = Convert.ToInt32(prof.balls) - fullprice;
                    prof.balls = Convert.ToString(newballs);
                    SqlCommand sqlCommand4 = new SqlCommand($"UPDATE regbd SET balls = N'{newballs}' FROM regbd WHERE regbd.Login LIKE (N'{prof.loginname}') ", sqlConnection);
                    sqlCommand4.ExecuteNonQuery();
                    if (sqlCommand4.ExecuteNonQuery() >= 1)
                    {
                        MessageBox.Show("Покупка совершена успешно!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    label5.Text = prof.loginname;
                    label6.Text = prof.balls;
                    SqlCommand sqlCommand5 = new SqlCommand("DELETE bucket FROM bucket", sqlConnection);
                    sqlCommand5.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("У вас недостаточно Баллов!", "Ошибка покупки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
    }
}
