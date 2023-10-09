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
    public partial class Income : Form
    {
        public Income()
        {
            InitializeComponent();
            TotInc();
        }

        //Get total income

        private void TotInc()
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select Sum(IncAmt) from IncomeTable where IncUser='" + Login.User + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                Inc = Convert.ToInt32(dt.Rows[0][0].ToString());
                TotIncome.Text = "Rs." + dt.Rows[0][0].ToString() + ".00";
                Con.Close();
            }
            catch(Exception)
            {
                Con.Close();
                
            }

        }
        int Inc;
        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel11_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel5_Click(object sender, EventArgs e)
        {

        }

        //Close button

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {
            DashBoard Obj = new DashBoard();
            Obj.Show();
            this.Hide();
        }

        private void bunifuLabel14_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            DashBoard Obj = new DashBoard();
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
SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Kavinda De Silva\Desktop\VProject\DayToDayExpences\Wallet.mdf;Integrated Security = True");
        private void Clear()
        {
            IncNameTb.Text = "";
            IncAmtTb.Text = "";
            IncDescTb.Text = "";
            IncCatTb.SelectedIndex = 0;
        }

        //Exception Handling

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (IncNameTb.Text == "" || IncAmtTb.Text == "" || IncDescTb.Text == "" || IncCatTb.SelectedIndex == -1)
            {
                MessageBox.Show( "Missing information", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into IncomeTable(IncName,IncAmt,IncCat,IncDate,IncDesc,IncUser)values(@IN,@IA,@IC,@ID,@IDE,@IU)", Con);
                    cmd.Parameters.AddWithValue("@IN", IncNameTb.Text);
                    cmd.Parameters.AddWithValue("@IA", IncAmtTb.Text);
                    cmd.Parameters.AddWithValue("@IC", IncCatTb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@ID", Date.Value.Date);
                    cmd.Parameters.AddWithValue("@IDE", IncDescTb.Text);
                    cmd.Parameters.AddWithValue("@IU", Login.User);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data has been added Succesfully!", "Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Con.Close();
                    TotInc();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void bunifuLabel12_Click(object sender, EventArgs e)
        {

        }

        private void Income_Load(object sender, EventArgs e)
        {

        }

        private void IncCatTb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void IncAmtTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuLabel7_Click(object sender, EventArgs e)
        {

        }
    }
}
