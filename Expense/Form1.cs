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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Expense
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            sumIncome();
            sumExpense();
            countIncome();
            countExpense();
            dateExpense();
            dateIncome();
            maxExpense();
            minExpense();
            maxIncome();
            minIncome();
            balance();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form2 income= new Form2();
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

        private void label5_Click(object sender, EventArgs e)
        {
            Form5 viewExpense = new Form5();
            viewExpense.Show(); 
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-HR20LU4;Initial Catalog=Expenses;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");


        private void sumIncome()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select Sum(Income_Amount) from tbl_Income where Income_User= @username", connection);
            adapter.SelectCommand.Parameters.AddWithValue("@username", Form6.User);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            
            labelIncomeAmount.Text += datatable.Rows[0][0].ToString();
           
            connection.Close();

        }
        

        private void countIncome()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select Count(*) from tbl_Income where Income_User= @username", connection);
            adapter.SelectCommand.Parameters.AddWithValue("@username", Form6.User);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            labelIncomeTra.Text += datatable.Rows[0][0].ToString();

            connection.Close();

        }

        private void countExpense()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select Count(*) from tbl_Expense where Expense_User= @username", connection);
            adapter.SelectCommand.Parameters.AddWithValue("@username", Form6.User);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            labelExpenseTransa.Text += datatable.Rows[0][0].ToString();

            connection.Close();

        }



        
        private void sumExpense()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select Sum(Expense_Amount) from tbl_Expense where Expense_User= @username", connection);
            adapter.SelectCommand.Parameters.AddWithValue("@username", Form6.User);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            labelExpenseAmount.Text += datatable.Rows[0][0].ToString();

            connection.Close();

        }

        private void dateIncome()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select Max(Income_Date) from tbl_Income where Income_User= @username", connection);
            adapter.SelectCommand.Parameters.AddWithValue("@username", Form6.User);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            labelIncomeDate.Text = datatable.Rows[0][0].ToString();
            labelLastIncome.Text = datatable.Rows[0][0].ToString();

            connection.Close();

        }

        private void dateExpense()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select Max(Expense_Date) from tbl_Expense where Expense_User= @username", connection);
            adapter.SelectCommand.Parameters.AddWithValue("@username", Form6.User);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            labelExpenseDate.Text = datatable.Rows[0][0].ToString();
            labelLastExpense.Text = datatable.Rows[0][0].ToString();

            connection.Close();

        }
        private void maxExpense()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select Max(Expense_Amount) from tbl_Expense where Expense_User= @username", connection);
            adapter.SelectCommand.Parameters.AddWithValue("@username", Form6.User);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            labelMaximumExpense.Text = datatable.Rows[0][0].ToString();

            connection.Close();

        }
        private void minExpense()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select Min(Expense_Amount) from tbl_Expense where Expense_User= @username", connection);
            adapter.SelectCommand.Parameters.AddWithValue("@username", Form6.User);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            labelMinExpense.Text = datatable.Rows[0][0].ToString();

            connection.Close();

        }

        private void maxIncome()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select Max(Income_Amount) from tbl_Income where Income_User= @username", connection);
            adapter.SelectCommand.Parameters.AddWithValue("@username", Form6.User);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            labelMaxIncome.Text = datatable.Rows[0][0].ToString();

            connection.Close();

        }

        private void minIncome()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select Min(Income_Amount) from tbl_Income where Income_User= @username", connection);
            adapter.SelectCommand.Parameters.AddWithValue("@username", Form6.User);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            labelMinIncome.Text = datatable.Rows[0][0].ToString();

            connection.Close();

        }

        private void balance()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT (SELECT SUM(Income_Amount) FROM tbl_Income WHERE Income_User = @username)- (SELECT SUM(Expense_Amount) FROM tbl_Expense WHERE Expense_User = @username)", connection);
            adapter.SelectCommand.Parameters.AddWithValue("@username", Form6.User);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            labelBalance.Text = datatable.Rows[0][0].ToString();

            connection.Close();

        }
    }
}
