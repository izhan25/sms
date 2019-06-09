using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
            
        }

        //following code will set Connection String for all forms
        public static string SqlConnectString()
        {
            string conString = "Data Source=.;Initial Catalog=sms;Persist Security Info=True;User ID=sa;Password=izhan";
            return conString;
        }

        //following code will check the input is a number or not
        public static string numCheck(string n)
        {
            string num = n;
            string checkedNum = "" ;
            foreach (char c in num)
            {
                if (c >= '0' && c <= '9' || c == '.')
                {
                    checkedNum += c;
                }
            }

            return checkedNum;
        }

        //following code will set form size half that of screen
        void setFormSize()
        {
           

            // StartPosition was set to FormStartPosition.Manual in the properties window.
            Rectangle screen = Screen.PrimaryScreen.WorkingArea;
            int w = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
            int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
            this.Location = new Point((screen.Width - w) / 2, (screen.Height - h) / 2);
            this.Size = new Size(w, h);
        }
       
        private void Teacher_Click(object sender, EventArgs e)
        {
            Teacher teach = new Teacher();
            teach.ShowDialog();
            
        }

        private void Student_Click(object sender, EventArgs e)
        {
            Student std = new Student();
            std.ShowDialog();
           
        }

        private void FeeManagement_Click(object sender, EventArgs e)
        {
            FeeManagement fee = new FeeManagement();
            fee.ShowDialog();
            
        }

        private void StdManagement_Click(object sender, EventArgs e)
        {
            StudentManagement stdManagement = new StudentManagement();
            stdManagement.ShowDialog();
            
        }

        private void StaffManagement_Click(object sender, EventArgs e)
        {
            StaffManagement staff = new StaffManagement();
            staff.ShowDialog();
           
        }


        private void Exit_CLick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Exit_Hover(object sender, EventArgs e)
        {
            this.Exit.BackColor = Color.AntiqueWhite;
        }

        private void Exit_Hoverclose(object sender, EventArgs e)
        {
            this.Exit.BackColor = Color.Transparent;
        }

        private void Admin_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();

            admin.ShowDialog();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
           
        }

        private void About_CLick(object sender, EventArgs e)
        {
            AboutMe aboutMe = new AboutMe();
            aboutMe.ShowDialog();
        }

        private void Abt_Hover(object sender, EventArgs e)
        {
            this.About.BackColor = Color.AntiqueWhite;
        }

        private void Abt_Hoverclose(object sender, EventArgs e)
        {
            this.About.BackColor = Color.Transparent;
        }

        
       
    }
}
