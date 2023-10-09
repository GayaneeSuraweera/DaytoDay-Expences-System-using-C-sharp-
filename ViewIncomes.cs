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
    public partial class ViewIncomes : Form
    {
        public ViewIncomes()
        {
            InitializeComponent();
            DisplayIncomes();

        }
        private void Clear()
        {
            ViewIncName.Text = "";
            IncNameTab.Text = "";
            IncAmtTab.Text = "";
            IncCatTab.SelectedItem = 0;


        }

        //Display Income Table

        private void DisplayIncomes()
        {
            Con.Open();
            string Query = "select * from IncomeTable where IncUser='" + Login.User + "'";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncomeDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        
        //SearchByName From IncomeTable

        private void SearchByName()
        {
            try
            {
                Con.Open();
                string Query = "select * from IncomeTable where IncUser='" + Login.User + "' and IncName = '" + ViewIncName.Text + "'";
                SqlDataAdapter sda3 = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda3);
                var ds1 = new DataSet();
                sda3.Fill(ds1);
                IncomeDGV.DataSource = ds1.Tables[0];
                Con.Close();
            }
            catch(Exception)
            {
                Con.Close();
            }

        }
        private void SearchByCat()
        {
            try
            {
                Con.Open();
                string Query = "select * from IncomeTable where IncUser='" + Login.User + "' and IncCat ='" + ViewIncCat.Text+ "'";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder builder = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                IncomeDGV.DataSource = ds.Tables[0];
                Con.Close();
            }
            catch (Exception)
            {
                Con.Close();
            }

        }
        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Kavinda De Silva\Desktop\VProject\DayToDayExpences\Wallet.mdf;Integrated Security = True");

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {
            DashBoard Obj = new DashBoard();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

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
        int key = 0;
        private void IncomeDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                IncNameTab.Text = IncomeDGV.SelectedRows[0].Cells[1].Value.ToString();
                IncAmtTab.Text = IncomeDGV.SelectedRows[0].Cells[2].Value.ToString();
                IncCatTab.SelectedItem = IncomeDGV.SelectedRows[0].Cells[3].Value.ToString();

                if (IncNameTab.Text == "")
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(IncomeDGV.SelectedRows[0].Cells[0].Value.ToString());
                }
               

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
//Search by Income Name

private void GoBtn_Click(object sender, EventArgs e)
        {
            SearchByName();
            Clear();
        }



        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            SearchByCat();
         

        }

        private void ViewIncCat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            DisplayIncomes();
        }


        private void ViewIncCat_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void ViewIncomes_Load(object sender, EventArgs e)
        {

        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if(key == 0)
            {
                MessageBox.Show("Please select the record!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Delete from IncomeTable where IncId=@ikey", Con);
                    cmd.Parameters.AddWithValue("@ikey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data has been deleted Succesfully!", "Data deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Con.Close();
                    DisplayIncomes();
                    Clear();

                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
