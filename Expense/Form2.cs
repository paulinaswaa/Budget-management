using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expense
{
    public partial class Form2 : Form
    {
        
                
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            main.Show();
            this.Hide();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-HR20LU4;Initial Catalog=Expenses;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
       
        private void Clear()
        { 
            incomename.Text = " ";
            incomeamount.Text = " ";
            incomedescription.Text = " ";
            incomecategories.SelectedIndex= 0;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (incomename.Text == " " || incomeamount.Text == " " || incomecategories.SelectedIndex == -1 || incomedescription.Text == "")
            {
                MessageBox.Show("Complete the data!");
            }
            else
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("insert into tbl_Income(Income_name, Income_Amount, Income_Category, Income_Date, Income_Description, Income_User)values (@IncomeName, @IncomeAmount, @IncomeCategory, @IncomeDate, @IncomeDescription, @IncomeUser)", connection);
                    command.Parameters.AddWithValue("@IncomeName", incomename.Text);
                    command.Parameters.AddWithValue("@IncomeAmount", incomeamount.Text);
                    command.Parameters.AddWithValue("@IncomeCategory", incomecategories.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@IncomeDate", incomedate.Value.Date);
                    command.Parameters.AddWithValue("@IncomeDescription", incomedescription.Text);
                    command.Parameters.AddWithValue("@IncomeUser", Form6.User);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Income added correctly!");
                    connection.Close();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }
    }
}
