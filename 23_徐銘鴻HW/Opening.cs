using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using _23_徐銘鴻HW.Properties;

namespace _23_徐銘鴻HW
{
    public partial class Opening : Form
    {
        public Opening()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.Default.LogInConnectString))
                {
                    string username = textBox1.Text;
                    string password = textBox2.Text;


                    SqlCommand com = new SqlCommand();
                    com.CommandText = $"select*from LogInTable where UserName='{username}'and Password='{password}'";
                    com.Connection = conn;
                    conn.Open();
                    SqlDataReader dataReader = com.ExecuteReader();
                    if (dataReader.HasRows)
                    {
                        MessageBox.Show("登入成功");
                        Main main = new Main();
                        main.Show();
                        Opening opening = new Opening();
                        opening.Close();
                    }
                    else
                    {
                        MessageBox.Show("登入失敗");
                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.Default.LogInConnectString))
                {
                    string username = textBox1.Text;
                    string password = textBox2.Text;


                    SqlCommand com = new SqlCommand();
                    com.CommandText = "insert into LogInTable(UserName,Password) values(@username,@password)";
                    com.Connection = conn;
                    com.Parameters.Add("@username", SqlDbType.NVarChar, 16).Value = username;
                    com.Parameters.Add("@password", SqlDbType.NVarChar, 40).Value = password;
                    conn.Open();
                    com.ExecuteNonQuery();
                    MessageBox.Show("創建成功");

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
