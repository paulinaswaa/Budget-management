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
