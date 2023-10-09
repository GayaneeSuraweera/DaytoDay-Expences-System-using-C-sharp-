using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
namespace DayToDayExpences
{
    public partial class users : Form
    {
        public users()
        {
            InitializeComponent();
        }
        //Validating Password
        private static Regex PasswordValidation()
        {
            string pattern = "(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{8,15})$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }
        static Regex vaildate_password = PasswordValidation();
        private void users_Load(object sender, EventArgs e)
        {

        }

        private void bunifuAppBar1_IconClick(object sender, EventArgs e)
        {
            this.Close();
        }


        SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Kavinda De Silva\Desktop\VProject\DayToDayExpences\Wallet.mdf;Integrated Security = True");
        private void Clear()
        {
            NameTB.Text = "";
            PhoneTB.Text = "";
            PasswordTB.Text = "";
            AddressTB.Text = "";
        }
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (NameTB.Text == "")
            {
                //Exception Handling

                MessageBox.Show("Enter your name!", "Please fill this field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (PhoneTB.Text == "")
            {
                //Exception Handling

                MessageBox.Show("Enter your Phone number!", "Phone number should contain 10 numbers", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (PasswordTB.Text == "")
            {
                //Exception Handling

                MessageBox.Show("Enter your Password!", "Please fill this field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (AddressTB.Text == "")
            {
                //Exception Handling

                MessageBox.Show("Enter your Address!", "Please fill this field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (PhoneTB.TextLength != 10)
            {
                //Exception Handling

                MessageBox.Show("Invalid Phone number!", "Phone number should contain 10 numbers", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (vaildate_password.IsMatch(PasswordTB.Text) != true)
            {
                MessageBox.Show("Password must be atleast 8 to 15 characters. It contains atleast one Upper case and numbers.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                PasswordTB.Focus();
                return;
            }


            else
            {
                using (SqlConnection Con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\Kavinda De Silva\Desktop\VProject\DayToDayExpences\Wallet.mdf;Integrated Security = True"))
                {
                  
                    //Username validation

                    Con.Open();

                    bool exists = false;

                    // create a command to check if the username exists
                    using (SqlCommand cmd = new SqlCommand("select count(*) from UserTable where UName = @UserName", Con))
                    {
                        cmd.Parameters.AddWithValue("UserName", NameTB.Text);
                        exists = (int)cmd.ExecuteScalar() > 0;
                    }
                    Con.Close();

                    // if exists, show a message error
                    if (exists)
                    {
                        MessageBox.Show("This user name is already exists!", "Please Enter New user name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       
                    }
                        
                   
                    else
                    {
                        try
                        {
                            Con.Open();

                            SqlCommand cmd = new SqlCommand("insert into UserTable(UName,UDOB,UPhone,UPassword,UAddress)values(@UN,@UD,@UP,@UPA,@UA)", Con);
                            cmd.Parameters.AddWithValue("@UN", NameTB.Text);
                            cmd.Parameters.AddWithValue("@UD", DOB.Value.Date);
                            cmd.Parameters.AddWithValue("@UP", PhoneTB.Text);
                            cmd.Parameters.AddWithValue("@UPA", PasswordTB.Text);
                            cmd.Parameters.AddWithValue("@UA", AddressTB.Text);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("User has been added Succesfully!", "Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Con.Close();
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
            private void pictureBox2_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            private void pictureBox3_Click(object sender, EventArgs e)
            {
                this.Close();
            }

        //Phone number  validation

            private void PhoneTB_TextChanged(object sender, EventArgs e)
            {
                if (PhoneTB.TextLength == 10)
                {
                    PhoneTB.ForeColor = Color.Black;
                }
                else
                {
                    PhoneTB.ForeColor = Color.Red;
                }
            }

            private void PasswordTB_TextChanged(object sender, EventArgs e)
            {

            }

        //Phone number  validation

        private void PhoneTB_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show("Error, A phone number can't contain a letter");
                }
            }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {

        }

        private void PasswordTB_TextChange(object sender, EventArgs e)
        {
           
        }
    }
    } 
