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

namespace DayToDayExpences
{
    public partial class ViewExpenses : Form
    {
        public ViewExpenses()
        {
            InitializeComponent();
            DisplayExpenses();
        }
        private void Clear()
        {
            ViewExpName.Text = "";
            ExpNameTab.Text = "";
            ExpAmtTab.Text = "";
            ExpCatTab.SelectedItem = 0;

        }
        private void DisplayExpenses()
        {
            Con.Open();
            string Query = "select * from ExpensesTable where ExpUser='" + Login.User + "'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpensesDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        //SearchByName From ExpensesTable

        private void SearchByName()
        {
            try
            {
                Con.Open();
                string Query = "select * from ExpensesTable where ExpUser='" + Login.User + "' and ExpName = '" + ViewExpName.Text + "'";
                SqlDataAdapter sda3 = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda3);
                var ds1 = new DataSet();
                sda3.Fill(ds1);
                ExpensesDGV.DataSource = ds1.Tables[0];
                Con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Missing Information!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Con.Close();
            }

        }
        private void SearchByCat()
        {
            try
            {
                Con.Open();
                string Query = "select * from ExpensesTable where ExpUser='" + Login.User + "' and ExpCat ='" + ViewExpCat.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                ExpensesDGV.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch (Exception)
            {
                Con.Close();
            }

        }
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Kavinda De Silva\Desktop\VProject\DayToDayExpences\Wallet.mdf;Integrated Security = True");

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {
            DashBoard Obj = new DashBoard();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DashBoard Obj = new DashBoard();
            Obj.Show();
            this.Hide();
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {
            Income Obj = new Income();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Income Obj = new Income();
            Obj.Show();
            this.Hide();
        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {
            Expenses Obj = new Expenses();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Expenses Obj = new Expenses();
            Obj.Show();
            this.Hide();
        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void bunifuLabel6_Click(object sender, EventArgs e)
        {
            ViewIncomes Obj = new ViewIncomes();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            ViewIncomes Obj = new ViewIncomes();
            Obj.Show();
            this.Hide();
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int key = 0;
        private void IncomeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                ExpNameTab.Text = ExpensesDGV.SelectedRows[0].Cells[1].Value.ToString();
                ExpAmtTab.Text = ExpensesDGV.SelectedRows[0].Cells[2].Value.ToString();
                ExpCatTab.SelectedItem = ExpensesDGV.SelectedRows[0].Cells[3].Value.ToString();

                if (ExpNameTab.Text == "")
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(ExpensesDGV.SelectedRows[0].Cells[0].Value.ToString());
                }


            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }



        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            DisplayExpenses();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            SearchByCat();
        }

        private void GoBtn_Click(object sender, EventArgs e)
        {
            SearchByName();
            Clear();
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {


        }


        private void ViewExpenses_Load(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void DeleteBtn_Click_1(object sender, EventArgs e)
        {
            if (key == 0)
            {
                //Exception Handling

                MessageBox.Show("Missing Information!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from ExpensesTable where ExpId=@ekey", Con);
                    cmd.Parameters.AddWithValue("@ekey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data has been deleted Succesfully!", "Data deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Con.Close();
                    DisplayExpenses();
                    Clear();

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void ExpCatTab_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
