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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        //connecting with database
        SqlConnection con = new SqlConnection(Main_Form.SqlConnectString());
        //end of connecting with database

        void setSidePanel(int h, int top)
        {
            // Sets up SidePanel to side of selected button
            SidePanel.Height = h;
            SidePanel.Top = top;
        }
        void reset()
        {
            GridView_ShowAll.DataSource = null;
            GridView_FM.DataSource = null;
            dataGridView_ShowAll.DataSource = null;
        }

        string userNAme, password;
        string id, name, fname, contact, cnic, birthdate, address, gender, email, designation, depart, departid, pay;
        Boolean status = false;

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
            Staff_Panel.Visible = false;
            Student_Panel.Visible = false;
            Account_Panel.Visible = false;
        }

        private void staff_Click(object sender, EventArgs e)
        {
            setSidePanel(staff.Height, staff.Top);
            Login_Panel.Visible = false;
            Logged_Panel.Visible = false;

            Staff_Panel.Visible = true;
            Student_Panel.Visible = false;
            Account_Panel.Visible = false;

            reset();
        }

        private void student_Click(object sender, EventArgs e)
        {
            setSidePanel(student.Height, student.Top);
            Login_Panel.Visible = false;
            Logged_Panel.Visible = false;

            Staff_Panel.Visible = false;
            Student_Panel.Visible = true;
            Account_Panel.Visible = false;

            reset();
        }

        private void Accounts_Click(object sender, EventArgs e)
        {
            setSidePanel(Accounts.Height, Accounts.Top);
            Login_Panel.Visible = false;
            Logged_Panel.Visible = false;

            Staff_Panel.Visible = false;
            Student_Panel.Visible = false;
            Account_Panel.Visible = true;

            reset();
        }

        

        private void btn_Guest_Click(object sender, EventArgs e)
        {
            userNAme = "admin";
            password = "admin";

            if (userNAme == "admin" && password == "admin")
            {

                MessageBox.Show("Log in successfull");
                status = true;
                Login_Panel.Visible = false;
                Logged_Panel.Visible = true;
            }
            else
            {
                MessageBox.Show("Wrong User Name or Password \n Please CLick On Forgot Password");
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            userNAme = textBox_LogIn_UserName.Text;
            password = textBox_LogIn_Password.Text;

            string sql = "select * from tab_Admin where userName = '" + userNAme + "' and pass = '" + password + "' ";
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
                contact = read.GetString(3);
                cnic = read.GetString(4);
                birthdate = read.GetValue(5).ToString().Substring(0,9);
                address = read.GetString(6);
                gender = read.GetString(7);
                email = read.GetString(8);
                designation = read.GetString(11);
                depart = read.GetString(12);
                departid = read.GetInt32(13).ToString();
                pay = read.GetInt32(14).ToString();

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

        void show()
        {
            // shoiwng id deatils in labels
            Id.Text = id;
            Name1.Text = name;
            FName.Text = fname;
            Contact.Text = contact;
            CNIC.Text = cnic;
            BirthDate.Text = birthdate;
            Address.Text = address;
            Gender.Text = gender;
            Email.Text = email;
            Designation.Text = designation;
            Department.Text = depart;
            DepartId.Text = departid;
            MonthlyPay.Text = pay;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            forgotPassword forgot = new forgotPassword();
            forgot.ShowDialog();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            status = false;
            Login_Panel.Visible = true;
            Logged_Panel.Visible = false;

            Staff_Panel.Visible = false;
            Student_Panel.Visible = false;
            Account_Panel.Visible = false;
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                try
                {
                    con.Open();
                    string sql = "select * from Fee_Management where Class = " + FM_View_Class.Text + " and Batch_No = '" + FM_View_Batch.Text + "' ;";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridView_FM.DataSource = dt;

                    con.Close();
                }
                catch (Exception ex9)
                {
                    MessageBox.Show("Error 015, can't load the class and batch");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Log in First");

            }
        }

        private void btn_ShowAll_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                try
                {
                    con.Open();
                    string sql = "select * from Std_Management where Class = " + ShowAll_Class.Text + " and Batch_No = '" + ShowAll_Batch.Text + "' ;";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridView_ShowAll.DataSource = dt;

                    con.Close();
                }
                catch (Exception ex9)
                {
                    MessageBox.Show("Error 015, can't load the class and batch");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Log in First");

            }
        }

        private void btn_ShowAllStd_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                try
                {
                    con.Open();
                    string sql = "select * from Std_Management;";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridView_ShowAll.DataSource = dt;

                    con.Close();
                }
                catch (Exception ex9)
                {
                    MessageBox.Show("Error 015, can't load");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Log in First");

            }
        }

        private void button_ShowAll_ShowAll_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                //showing all staff in show all panel
                con.Open();
                string sql = "select * from Staff_Management";

                SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView_ShowAll.DataSource = dt;

                con.Close();
            }
            else
            {
                MessageBox.Show("You Must Log in First");

            }
        }

        private void button_ShowAll_Search_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                try
                {
                    string sql = "select * from Staff_Management where " + comboBox_ShowAll_SearchIn.Text + " like '%" + textBox_ShowAll_Search.Text + "%';";

                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView_ShowAll.DataSource = dt;
                    con.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error");
                }
            }
            else
            {
                MessageBox.Show("You Must Log in First");
            }
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

        private void btn_Logout_Click_1(object sender, EventArgs e)
        {
            status = false;

            // Removing id deatils in labels
            Id.Text = null;
            Name1.Text = null;
            FName.Text = null;
            Contact.Text = null;
            CNIC.Text = null;
            BirthDate.Text = null;
            Address.Text = null;
            Gender.Text = null;
            Email.Text = null;
            Designation.Text = null;
            Department.Text = null;
            DepartId.Text = null;
            MonthlyPay.Text = null;
            //shoiwng login panel
            Login_Panel.Visible = true;
            Logged_Panel.Visible = false;
            Staff_Panel.Visible = false;
            Student_Panel.Visible = false;
            Account_Panel.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                try
                {
                    con.Open();
                    string sql = "select * from Fee_Management;";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridView_FM.DataSource = dt;

                    con.Close();
                }
                catch (Exception ex9)
                {
                    MessageBox.Show("Error 015, can't load the class and batch");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must login First");
            }
        }

        private void btn_FM_search_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                try
                {
                    con.Open();
                    string sql = "select * from Fee_Management where " + FM_View_Column.Text + " like  '%" + FM_View_Search.Text + "%' ;";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridView_FM.DataSource = dt;

                    con.Close();
                }
                catch (Exception ex9)
                {
                    GridView_FM.DataSource = null;
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must login First");
            }
        }
    }
}
