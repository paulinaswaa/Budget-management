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
    public partial class expensename : Form
    {
        public expensename()
        {
            InitializeComponent();
            totalExpense();
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

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            main.Show();
            this.Hide();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-HR20LU4;Initial Catalog=Expenses;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void Clear()
        {
            expname.Text = " ";
            expenseamount.Text = " ";
            expensedescription.Text = " ";
            expensecategory.SelectedIndex = 0;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (expname.Text == " " || expenseamount.Text == " " || expensecategory.SelectedIndex == -1 || expensedescription.Text == "")
            {
                MessageBox.Show("Complete the data!");
            }
            else
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("insert into tbl_Expense(Expense_name, Expense_Amount, Expense_Category, Expense_Date, Expense_Description, Expense_User)values (@ExpenseName, @ExpenseAmount, @ExpenseCategory, @ExpenseDate, @ExpenseDescription, @ExpenseUser)", connection);
                    command.Parameters.AddWithValue("@ExpenseName", expname.Text);
                    command.Parameters.AddWithValue("@ExpenseAmount", expenseamount.Text);
                    command.Parameters.AddWithValue("@ExpenseCategory", expensecategory.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@ExpenseDate", expensedate.Value.Date);
                    command.Parameters.AddWithValue("@ExpenseDescription", expensedescription.Text);
                    command.Parameters.AddWithValue("@ExpenseUser", Form6.User);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Expense added correctly!");
                    connection.Close();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }

        private void expensename_Load(object sender, EventArgs e)
        {

        }

        private void totalExpense()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select Sum(Income_Amount) from tbl_Income where Income_User= @username", connection);
            adapter.SelectCommand.Parameters.AddWithValue("@username", Form6.User);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);

            label_expense.Text += datatable.Rows[0][0].ToString();

            connection.Close();

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Form6 main = new Form6();
            main.Show();
            this.Hide();
        }
    }
}
