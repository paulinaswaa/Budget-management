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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            Display_Incomes();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form2 income = new Form2();
            income.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            expensename expense = new expensename();
            expense.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form5 viewExpense = new Form5();
            viewExpense.Show();
            this.Hide();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-HR20LU4;Initial Catalog=Expenses;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


        private void Display_Incomes()
        {
            connection.Open();
            SqlDataAdapter adapter= new SqlDataAdapter("select * from tbl_Income", connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var display1 = new DataSet();
            adapter.Fill(display1);
            IncomeDatagridview.DataSource= display1.Tables[0];
            connection.Close();

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            main.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && comboBox1.SelectedIndex == -1)
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tbl_Income WHERE Income_Name LIKE '%' + @incomeName + '%'", connection);
                adapter.SelectCommand.Parameters.AddWithValue("@incomeName", textBox1.Text);
                var display1 = new DataTable();
                adapter.Fill(display1);
                IncomeDatagridview.DataSource = display1;
                connection.Close();
            }
            
        
            else if(string.IsNullOrEmpty(textBox1.Text) && comboBox1.SelectedIndex != -1)
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tbl_Income WHERE Income_Category = @incomeCategory ", connection);
                adapter.SelectCommand.Parameters.AddWithValue("@incomeCategory", comboBox1.SelectedItem);
                var display1 = new DataTable();
                adapter.Fill(display1);
                IncomeDatagridview.DataSource = display1;
                connection.Close();

            }

            else if(!string.IsNullOrEmpty(textBox1.Text) && comboBox1.SelectedIndex != -1)
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tbl_Income WHERE Income_Category = @incomeCategory AND Income_Name LIKE '%' + @incomeName + '%'", connection);
                adapter.SelectCommand.Parameters.AddWithValue("@incomeCategory", comboBox1.SelectedItem);
                adapter.SelectCommand.Parameters.AddWithValue("@incomeName", textBox1.Text);
                var display1 = new DataTable();
                adapter.Fill(display1);
                IncomeDatagridview.DataSource = display1;
                connection.Close();
            }

            else
            {
                MessageBox.Show("Choose how you want to filter data!");
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Display_Incomes();
            textBox1.Text= string.Empty;
            comboBox1.SelectedIndex = -1;
        }
    }
}
