using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expense
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 users = new Form7();
            users.Show();

        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-HR20LU4;Initial Catalog=Expenses;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public static string User;
        private void loginbutton_Click(object sender, EventArgs e)
        {
            connection.Open();
            //SqlDataAdapter adapter = new SqlDataAdapter("select count(*) from tbl_User where User_Name= " + username.Text + " and User_Password " + password.Text + " ", connection);
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT COUNT(*) FROM tbl_User WHERE User_Name = @username AND User_Password = @password", connection);
            adapter.SelectCommand.Parameters.AddWithValue("@username", username.Text);
            adapter.SelectCommand.Parameters.AddWithValue("@password", password.Text);

            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            if (datatable.Rows[0][0].ToString()=="1")
            {
                User = username.Text;
                Form1 main = new Form1();
                main.Show();
                this.Hide();
                connection.Close();

            }
            else
            {
                MessageBox.Show("Wrong Username or password!");
                username.Text = " ";
                password.Text = " ";
            }


            connection.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
