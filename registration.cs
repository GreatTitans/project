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
    public partial class registration : Form
    {
        SqlConnection SqlConnection = null;
        SqlDataReader SqlDataReader = null;
        public registration()
        {
            InitializeComponent();
        }

        private void registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            avtoreg avtoreg = new avtoreg();
            avtoreg.Show();
        }

        private void registration_Load(object sender, EventArgs e)
        {
            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            SqlConnection.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string login = textBox3.Text;
            string trylogin = null;
            string password = textBox4.Text;

            string email = textBox5.Text;
            string tryemail = null;
            string gru = "@gmail.com";
            string gcom = "@gmail.ru";
            int indexofchar1 = email.IndexOf(gru);
            int indexofchar2 = email.IndexOf(gcom);

            if (radioButton1.Checked)
            {
                if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "" || textBox5.Text != "")
                {




                    try
                    {
                        SqlCommand sqlCommand1 = new SqlCommand($"SELECT regbd.Login, regbd.Email FROM regbd WHERE regbd.Login LIKE (N'{login}') AND regbd.Email LIKE (N'{email}') ", SqlConnection);
                        SqlDataReader = sqlCommand1.ExecuteReader();

                        while (SqlDataReader.Read())
                        {
                            tryemail = Convert.ToString(SqlDataReader["Email"]);
                            trylogin = Convert.ToString(SqlDataReader["Login"]);
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


                    if (trylogin != login && tryemail != email)
                    {
                        if (indexofchar1 != -1 || indexofchar2 != -1)
                        {
                            SqlCommand sqlCommand = new SqlCommand($"insert into regbd (Name,Surname,Login,Password, Email, Balls) values (N'{name}',N'{surname}',N'{login}',N'{password}',N'{email}',N'100')", SqlConnection);
                            if (sqlCommand.ExecuteNonQuery() >= 1)
                            {
                                MessageBox.Show("Регистрация успешно завершена!", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Hide();
                                avtoreg avtoreg = new avtoreg();
                                avtoreg.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Почта указана неверно!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Данная почта или логин уже используется!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

















                }
                else
                {
                    MessageBox.Show("Заполните все поля регистрации!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                 MessageBox.Show("Вам необходимо принять согласие на"+ Environment.NewLine+("") +"обработку персональных данных", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
