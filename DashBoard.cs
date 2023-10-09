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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
            GetTotInc();
            GetTotExp();
            GetNumExp();
            GetNumInc();
            GetDateInc();
            GetDateExp();
            GetMaxInc();
            GetMinInc();
            GetMinExp();
            GetMaxExp();
            GetExpDate();
            GetIncDate();
            GetBalance();
            GetMaxExpCat();
            GetMaxIncCat();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            ViewIncomes Obj = new ViewIncomes();
            Obj.Show();
            this.Hide();
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel11_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel5_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Kavinda De Silva\Desktop\VProject\DayToDayExpences\Wallet.mdf;Integrated Security = True");
        private void GetTotInc()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(IncAmt) from IncomeTable where IncUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Inc = Convert.ToInt32(dt.Rows[0][0].ToString());
                Totlnc.Text = "Rs." + dt.Rows[0][0].ToString() + ".00";
                Con.Close();
            }catch(Exception)
            {
                Con.Close();
            }
        }
        private void GetTotExp()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(ExpAmt) from ExpensesTable where ExpUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Exp = Convert.ToInt32(dt.Rows[0][0].ToString());
                TotExpLbl.Text = "Rs." + dt.Rows[0][0].ToString() + ".00";
                Con.Close();
            }
            catch (Exception)
            {
                Con.Close();
            }

        }
        int Inc, Exp;
        private void GetBalance()
        {
            Double Balance = Inc - Exp;
            BalanceLbl.Text = "Rs." + Balance+ ".00";
        }
        private void GetNumExp()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from ExpensesTable where ExpUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                NumExpLbl.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch (Exception)
            {
                Con.Close();
            }

        }
        private void GetNumInc()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from IncomeTable where IncUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                NumIncLbl.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch (Exception)
            {
                Con.Close();
            }

        }
        private void GetDateInc()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Max(IncDate) from IncomeTable where IncUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DateIncLbl.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch (Exception)
            {
                Con.Close();
            }

        }
        private void GetDateExp()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Max(ExpDate) from ExpensesTable where ExpUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                DateExpLbl.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch (Exception)
            {
                Con.Close();
            }

        }
        private void GetMaxInc()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Max(IncAmt) from IncomeTable where IncUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MaxIncLbl.Text = "Rs " + dt.Rows[0][0].ToString() + ".00";
                Con.Close();
            }
            catch (Exception)
            {
                Con.Close();
            }

        }
        private void GetMinInc()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Min(IncAmt) from IncomeTable where IncUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MinIncLbl.Text = "Rs " + dt.Rows[0][0].ToString() + ".00";
                Con.Close();
            }
            catch (Exception)
            {
                Con.Close();
            }

        }
        private void GetMaxExp()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Max(ExpAmt) from ExpensesTable where ExpUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MaxExpLbl.Text = "Rs." + dt.Rows[0][0].ToString() + ".00";
                Con.Close();
            }
            catch (Exception)
            {
                Con.Close();
            }

        }
        private void GetMinExp()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Min(ExpAmt) from ExpensesTable where ExpUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                MinExpLbl.Text = "Rs." + dt.Rows[0][0].ToString() + ".00";
                Con.Close();
            }
            catch (Exception)
            {
                Con.Close();
            }

        }
        private void GetExpDate()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Max(ExpDate) from ExpensesTable where ExpUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                LastExpLbl.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch (Exception)
            {
                Con.Close();
            }

        }
        private void GetIncDate()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Max(IncDate) from IncomeTable where IncUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                LastIncLbl.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch (Exception)
            {
                Con.Close();
            }

        }
        private void GetMaxExpCat()
        {
            try
            {
                Con.Open();
                string InnerQuery = "select Max(ExpAmt) from ExpensesTable";
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, Con);
                sda1.Fill(dt1);
                string Query = "select ExpCat from ExpensesTable where ExpAmt = '" + dt1.Rows[0][0].ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                BestExpCat.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch (Exception)
            {
                Con.Close();
            }

        }
        private void GetMaxIncCat()
        {
            try
            {
                Con.Open();
                string InnerQuery = "select Max(IncAmt) from IncomeTable";
                DataTable dt1 = new DataTable();
                SqlDataAdapter sda1 = new SqlDataAdapter(InnerQuery, Con);
                sda1.Fill(dt1);
                string Query = "select IncCat from IncomeTable where IncAmt = '" + dt1.Rows[0][0].ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                BestIncCat.Text = dt.Rows[0][0].ToString();
                Con.Close();
            }
            catch (Exception)
            {
                Con.Close();
            }

        }
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void IncLbl_Click(object sender, EventArgs e)
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

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

        private void bunifuLabel6_Click(object sender, EventArgs e)
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

        private void bunifuLabel12_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel16_Click(object sender, EventArgs e)
        {

        }

        private void Totlnc_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel6_Click(object sender, EventArgs e)
        {

        }
    }
}
