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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            users Obj = new users();
            Obj.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }
 SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Kavinda De Silva\Desktop\VProject\DayToDayExpences\Wallet.mdf;Integrated Security = True");
        public static string User;
        private void LoginBtn_Click(object sender, EventArgs e)
        {

            if(UsernameTB.Text == "")
            {

                //Exception Handling

                MessageBox.Show("Enter your Username!", "Please fill this field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(PasswordTB.Text == "")
            {

                //Exception Handling

                MessageBox.Show("Enter your Password!", "Please fill this field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*)from UserTable where UName = '" + UsernameTB.Text + "'and UPassword ='" + PasswordTB.Text + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    User = UsernameTB.Text;
                    DashBoard obj = new DashBoard();
                    obj.Show();
                    this.Hide();
                    Con.Close();
                }
                else
                {
                    //Exception Handling

                    MessageBox.Show("Wrong UserName or Password!!!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UsernameTB.Text = "";
                    PasswordTB.Text = "";
                }
                Con.Close();
            }

        }

        private void UsernameTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
