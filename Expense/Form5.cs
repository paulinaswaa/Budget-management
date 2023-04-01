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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Expense
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            Display_Expenses();
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

        private void label4_Click(object sender, EventArgs e)
        {
            Form4 viewIncome = new Form4();
            viewIncome.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            main.Show();
            this.Hide();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
           
        }

        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-HR20LU4;Initial Catalog=Expenses;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


        private void Display_Expenses()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from tbl_Expense", connection);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            var display1 = new DataSet();
            adapter.Fill(display1);
            ExpensedataGridView.DataSource = display1.Tables[0];
            connection.Close();

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1ex.Text) && comboBox1exp.SelectedIndex == -1)
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tbl_Expense WHERE Expense_Name LIKE '%' + @expenseName + '%'", connection);
                adapter.SelectCommand.Parameters.AddWithValue("@expenseName", textBox1ex.Text);
                var display1 = new DataTable();
                adapter.Fill(display1);
                ExpensedataGridView.DataSource = display1;
                connection.Close();
            }


            else if (string.IsNullOrEmpty(textBox1ex.Text) && comboBox1exp.SelectedIndex != -1)
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tbl_Expense WHERE Expense_Category = @expenseCategory ", connection);
                adapter.SelectCommand.Parameters.AddWithValue("@expenseCategory", comboBox1exp.SelectedItem);
                var display1 = new DataTable();
                adapter.Fill(display1);
                ExpensedataGridView.DataSource = display1;
                connection.Close();

            }

            else if (!string.IsNullOrEmpty(textBox1ex.Text) && comboBox1exp.SelectedIndex != -1)
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tbl_Expense WHERE Expense_Category = @expenseCategory AND Expense_Name LIKE '%' + @expenseName + '%'", connection);
                adapter.SelectCommand.Parameters.AddWithValue("@expenseCategory", comboBox1exp.SelectedItem);
                adapter.SelectCommand.Parameters.AddWithValue("@expenseName", textBox1ex.Text);
                var display1 = new DataTable();
                adapter.Fill(display1);
                ExpensedataGridView.DataSource = display1;
                connection.Close();
            }

            else
            {
                MessageBox.Show("Choose how you want to filter data!");
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Display_Expenses();
            textBox1ex.Text = string.Empty;
            comboBox1exp.SelectedIndex = -1;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form6 main = new Form6();
            main.Show();
            this.Hide();
        }
    }
}
