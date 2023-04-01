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

namespace Expense
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-HR20LU4;Initial Catalog=Expenses;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        private void Clear()
        {
            usernameadd.Text = string.Empty;
            passwordadd.Text = string.Empty;
            adressadd.Text = string.Empty;
            phoneadd.Text = string.Empty;
        }
        private void addbutton_Click(object sender, EventArgs e)
        {
            if(usernameadd.Text==" " || phoneadd.Text==" " || passwordadd.Text=="" || adressadd.Text=="")
            {
                MessageBox.Show("Complete the data!");
            }
            else
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("insert into tbl_User(User_Name, User_Date, User_Phone, User_Password, User_Adress)values (@USERN, @USERD, @USERP, @USERPW, @USERA)", connection);
                    command.Parameters.AddWithValue("@USERN", usernameadd.Text);
                    command.Parameters.AddWithValue("@USERD", dateadd.Value.Date);
                    command.Parameters.AddWithValue("@USERP", phoneadd.Text);
                    command.Parameters.AddWithValue("@USERPW", passwordadd.Text);
                    command.Parameters.AddWithValue("@USERA", adressadd.Text);
                    command.ExecuteNonQuery();
                    MessageBox.Show("User added correctly!");
                    connection.Close();
                    Clear();

                } catch(Exception Ex) { 
                    MessageBox.Show(Ex.Message);
                   
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form6 main = new Form6();
            main.Show();
            this.Hide();
        }
    }
}
