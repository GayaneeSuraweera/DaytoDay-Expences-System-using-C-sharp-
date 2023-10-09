using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DayToDayExpences
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void bunifuProgressBar1_ProgressChanged(object sender, Bunifu.UI.WinForms.BunifuProgressBar.ProgressChangedEventArgs e)
        {

        }
        int startP = 0;



        private void Splash_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            {
                startP += 1;
                progress.Value = startP;
                Precentage.Text = startP + "%";
                if (progress.Value == 100)
                {
                    progress.Value = 0;
                    timer1.Stop();
                    Login Obj = new Login();
                    Obj.Show();
                    this.Hide();
                    

                }
            }
        }
    }
}
