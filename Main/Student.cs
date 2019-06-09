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

namespace Main
{
    public partial class Student : Form
    {
        public Student()
        {
            InitializeComponent();
        }
        //connecting with database
        SqlConnection con = new SqlConnection(Main_Form.SqlConnectString());
        //end of connecting with database

        string userNAme, password;
        string id, name, fname, birthdate, age, gender, contact, address, sclass, batch, mfee, efee, admityear, userName, pass, email;
        Boolean status = false;
        string mySql = null;

        void show()
        {
            // shoiwng id deatils in labels
            Id.Text = id;
            Name1.Text = name;
            FName.Text = fname;
            BirthDate.Text = birthdate;
            Age1.Text = age;
            Gender.Text = gender;
            Contact.Text = contact;
            Address.Text = address;
            Class.Text = sclass;
            Batch1.Text = batch;
            MFee1.Text = mfee;
            EFee1.Text = efee;
            Ayear1.Text = admityear;
            Email1.Text = email;
        }
        void setSidePanel(int h, int top)
        {
            // Sets up SidePanel to side of selected button
            SidePanel.Height = h;
            SidePanel.Top = top;
        }
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Exit_Hover(object sender, EventArgs e)
        {
            this.Exit.BackColor = Color.Gray;
        }

        private void Exit_MouseLeave(object sender, EventArgs e)
        {
            this.Exit.BackColor = Color.Transparent;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            setSidePanel(Login.Height, Login.Top);

            if (status == true)
            {
                Logged_Panel.Visible = true;
                Login_Panel.Visible = false;
            }
            else if (status == false)
            {
                Logged_Panel.Visible = false;
                Login_Panel.Visible = true;
            }
            panel_ReportCard.Visible = false;
            
        }

        private void btn_Rcard_Click(object sender, EventArgs e)
        {
            setSidePanel(btn_Rcard.Height, btn_Rcard.Top);

            Logged_Panel.Visible = false;
            Login_Panel.Visible = false;
            panel_ReportCard.Visible = true;
            
        }

        

        

        private void btn_Login_Click(object sender, EventArgs e)
        {
            userName = textBox_LogIn_UserName.Text;
            pass = textBox_LogIn_Password.Text;

            string sql = "select * from Std_Management where userName = '" + userName + "' and pass = '" + pass + "' ";
            
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader read = cmd.ExecuteReader();

            if (userNAme == "admin" && password == "admin")
            {
                status = true;
                Login_Panel.Visible = false;
                Logged_Panel.Visible = true;

                con.Close();
            }
            else if (read.Read())
            {
                id = read.GetInt32(0).ToString();
                name = read.GetString(1);
                fname = read.GetString(2);
                birthdate = read.GetValue(3).ToString().Substring(0,9);
                age = read.GetInt32(4).ToString();
                gender = read.GetString(5);
                contact = read.GetString(6);
                address = read.GetString(7);
                sclass = read.GetInt32(8).ToString();
                batch = read.GetString(9);
                mfee = read.GetInt32(10).ToString();
                efee = read.GetInt32(11).ToString();
                admityear = read.GetInt32(12).ToString();
                email = read.GetString(15);
                
                textBox_LogIn_UserName.Text = null;
                textBox_LogIn_Password.Text = null;

                Login_Panel.Visible = false;
                Logged_Panel.Visible = true;

                show();

                status = true;
                con.Close();
            }
            else
            {
                MessageBox.Show("Wrong User Name or Password \n Please CLick On Forgot Password");
                con.Close();
            }
        }

        private void btn_Guest_Click(object sender, EventArgs e)
        {
            userNAme = "admin";
            password = "admin";

            if (userNAme == "admin" && password == "admin")
            {
                status = true;
                Login_Panel.Visible = false;
                Logged_Panel.Visible = true;
            }
            else
            {
                MessageBox.Show("Wrong User Name or Password \n Please CLick On Forgot Password");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            forgotPassword forgot = new forgotPassword();
            forgot.ShowDialog();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            status = false;

            // Removing id deatils from labels
            Id.Text = null;
            Name1.Text = null;
            FName.Text = null;
            Contact.Text = null;
            Class.Text = null;
            BirthDate.Text = null;
            Address.Text = null;
            Gender.Text = null;
            Batch1.Text = null;
            Email1.Text = null;
            MFee1.Text = null;
            EFee1.Text = null;
            Ayear1.Text = null;

            Login_Panel.Visible = true;
            Logged_Panel.Visible = false;

            panel_ReportCard.Visible = false;
            
        }

        private void btn_Test_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                try
                {
                    con.Open();
                    string sql = "select * from Test_Rcard where Class = " + sclass + " and Batch_No = '" + batch + "' and Std_Id = " + id.ToString() + ";";
                    mySql = sql;
                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridView_Report.DataSource = dt;

                    con.Close();
                    Console.WriteLine("\n\n" + mySql);
                    mySql = null;
                }
                catch (Exception ex12)
                {
                    MessageBox.Show("Error cant find result");
                    Console.WriteLine("\n\n" +mySql);
                    con.Close();
                    
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void btn_Exam_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                try
                {
                    con.Open();
                    string sql = "select * from Exam_Rcard where Class = " + sclass + " and Batch_No = '" + batch + "' and Std_Id = " + id.ToString() + ";";
                    mySql = sql;
                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridView_Report.DataSource = dt;

                    con.Close();
                }
                catch (Exception ex12)
                {
                    MessageBox.Show("Error cant find result");
                    Console.WriteLine("\n\n" + mySql);
                    con.Close();
                    mySql = null;
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }
    }
}
