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
    public partial class Expenses : Form
    {
        public Expenses()
        {
            InitializeComponent();
            TotExp();
        }

        //Get Total Expenses

        private void TotExp()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(ExpAmt) from ExpensesTable where ExpUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Exp = Convert.ToInt32(dt.Rows[0][0].ToString());
                TotExpenses.Text = "Rs." + dt.Rows[0][0].ToString() + ".00";
                Con.Close();
            }catch(Exception )
            {
                Con.Close();
            }

        }
        int Exp;

        private void Expenses_Load(object sender, EventArgs e)
        {

        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        //Close button

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        //Navigation Bar

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

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {
            ViewExpenses Obj = new ViewExpenses();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ViewExpenses Obj = new ViewExpenses();
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
        
        //Enter vlues to the Table
        
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Kavinda De Silva\Desktop\VProject\DayToDayExpences\Wallet.mdf;Integrated Security = True");
        private void Clear()
        {
            ExpNameTb.Text = "";
            ExpAmtTb.Text = "";
            ExpDescTb.Text = "";
            ExpCatTb.SelectedIndex = 0;
        }
        private void SaveExpBtn_Click(object sender, EventArgs e)
        {
            if (ExpNameTb.Text == "" || ExpAmtTb.Text == "" || ExpDescTb.Text == "" || ExpCatTb.SelectedIndex == -1)
            {
                //Exception Handling

                MessageBox.Show("Missing information", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into ExpensesTable(ExpName,ExpAmt,ExpCat,ExpDate,ExpDesc,ExpUser)values(@XN,@XA,@XC,@XD,@XDE,@XU)", Con);
                    cmd.Parameters.AddWithValue("@XN", ExpNameTb.Text);
                    cmd.Parameters.AddWithValue("@XA", ExpAmtTb.Text);
                    cmd.Parameters.AddWithValue("@XC", ExpCatTb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@XD", ExpDate.Value.Date);
                    cmd.Parameters.AddWithValue("@XDE", ExpDescTb.Text);
                    cmd.Parameters.AddWithValue("@XU", Login.User);
                    cmd.ExecuteNonQuery();

                    //Exception Handling

                    MessageBox.Show("Data has been added Succesfully!", "Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    TotExp();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            {
               
            }
        }

        private void IncCatTb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TotExpenses_Click(object sender, EventArgs e)
        {

        }
    }
}
