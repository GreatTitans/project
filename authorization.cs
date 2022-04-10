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
    public partial class authorization : Form
    {

        SqlConnection SqlConnection = null;
        SqlDataReader sqlDataReader = null;
        public authorization()
        {
            InitializeComponent();
        }

        private void authorization_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            avtoreg avtoreg = new avtoreg();
            avtoreg.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        string login = textBox1.Text;
                        string password = textBox2.Text;
                        string trylogin = null;
                        string trypassword = null;
                        SqlCommand sqlCommand = new SqlCommand($"SELECT admreg.Login, admreg.Password from admreg where admreg.Login like (N'{login}') and admreg.Password like (N'{password}')", SqlConnection);
                        sqlDataReader = sqlCommand.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            trylogin = Convert.ToString(sqlDataReader["Login"]);
                            trypassword = Convert.ToString(sqlDataReader["Password"]);
                        }
                        if (trylogin != null && trypassword != null)
                        {
                            this.Hide();
                            adminmenu adminmenu = new adminmenu();
                            adminmenu.Show();
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Неверный логин или пароль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (result == DialogResult.OK)
                            {

                            }
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Заполните все поля авторизации!", "Предупреждения!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (result == DialogResult.OK)
                        {

                        }
                    }
                }
                else if (radioButton2.Checked)
                {
                    if (textBox1.Text != "" && textBox2.Text != "")
                    {
                        string login = textBox1.Text;
                        string password = textBox2.Text;
                        string trylogin = null;
                        string trypassword = null;
                        SqlCommand sqlCommand = new SqlCommand($"SELECT regbd.Login, regbd.Password, regbd.Balls from regbd where regbd.Login like (N'{login}') and regbd.Password like (N'{password}')", SqlConnection);
                        sqlDataReader = sqlCommand.ExecuteReader();
                        while (sqlDataReader.Read())
                        {
                            prof.loginname = Convert.ToString(sqlDataReader["Login"]);
                            prof.balls = Convert.ToString(sqlDataReader["Balls"]);
                            trylogin = Convert.ToString(sqlDataReader["Login"]);
                            trypassword = Convert.ToString(sqlDataReader["Password"]);
                        }
                        if (trylogin != null && trypassword != null)
                        {
                            this.Hide();
                            MainMenu mainMenu = new MainMenu();
                            mainMenu.Show();
                        }
                        else
                        {
                            DialogResult result = MessageBox.Show("Неверный логин или пароль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (result == DialogResult.OK)
                            {

                            }
                        }
                    }
                    else
                    {
                        DialogResult result = MessageBox.Show("Заполните все поля авторизации!", "Предупреждения!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (result == DialogResult.OK)
                        {

                        }
                    }
                }
                else
                {
                   DialogResult result = MessageBox.Show("Выберите способ входа!", "Предупреждения!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   if (result == DialogResult.OK)
                    {

                    }
                }
            }
            catch
            {
                DialogResult result = MessageBox.Show("Возникла ошибка Авторизации!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (result == DialogResult.OK)
                {

                }    
            }
            finally
            {
                if (sqlDataReader != null && !sqlDataReader.IsClosed)
                {
                    sqlDataReader.Close();
                }
            }  
        }

        private void authorization_Load(object sender, EventArgs e)
        {
            SqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["db"].ConnectionString);
            SqlConnection.Open();
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
