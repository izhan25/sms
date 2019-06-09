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
    public partial class FeeManagement : Form
    {
        public FeeManagement()
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

        string userNAme, password;
        string id, name, fname, contact, cnic, birthdate, address, gender, email, designation, depart, departid, pay;
        Boolean status = false;
        string mySql = null;
        string sid="", sname, mfee, efee, ayear, date, ftype, amount, month;
        Boolean trig = false; 


        void autoFill()
        {
            FM_EmpName.Text = name;
            FM_EmpId.Text = id;
        }

        void fetchFee()
        {
            string sql = "select * from Fee_Management where Std_Id = " + sid.ToString() + " and Dated = (select MAX(Dated) from Fee_Management);";
            Console.WriteLine("\n\n"+sql);
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader read;

                try
                {
                    con.Open();
                    read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        date = read.GetValue(0).ToString().Substring(0, 9);
                        amount = read.GetInt32(5).ToString();
                        ftype = read.GetString(6);
                        month = read.GetString(7);
                    }

                    con.Close();

                    showDetails();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\n\n Error in fetching information of id = " + id.ToString() + "\n");
                    con.Close();
                }
            
            
        }


        

        void showDetails()
        {
            if (trig == true)
            {
                sName.Text = sname;
                mFee.Text = mfee;
                eFee.Text = efee;
                Ayear.Text = ayear;

                Dated.Text = date;
                Amount.Text = amount;
                FeeType.Text = ftype;
                Month.Text = month;
            }
            else if(trig == false)
            {
                sName.Text = null;
                mFee.Text = null;
                eFee.Text = null;
                Ayear.Text = null;

                Dated.Text = null;
                Amount.Text = null;
                FeeType.Text = null;
                Month.Text = null;
            }
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
            panel_FM_SubmitFee.Visible = false;
            panel_FM_ViewAll.Visible = false;
        }

        private void button_FM_SubmitFee_Click(object sender, EventArgs e)
        {
            setSidePanel(button_FM_SubmitFee.Height, button_FM_SubmitFee.Top);

            panel_FM_SubmitFee.Visible = true;
            panel_FM_ViewAll.Visible = false;
            Logged_Panel.Visible = false;
            Login_Panel.Visible = false;

            autoFill();
        }

        private void button_FM_ViewAll_Click(object sender, EventArgs e)
        {
            setSidePanel(button_FM_ViewAll.Height, button_FM_ViewAll.Top);

            panel_FM_SubmitFee.Visible = false;
            panel_FM_ViewAll.Visible = true;
            Logged_Panel.Visible = false;
            Login_Panel.Visible = false;
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            userNAme = textBox_LogIn_UserName.Text;
            password = textBox_LogIn_Password.Text;

            string sql = "select * from Staff_Management where userName = '" + userNAme + "' and pass = '" + password + "' ";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            SqlDataReader read = cmd.ExecuteReader();

            if (userNAme == "admin" && password == "admin")
            {

                MessageBox.Show("Log in successfull");
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
                birthdate = read.GetValue(5).ToString();
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
            Login_Panel.Visible = true;
            Logged_Panel.Visible = false;

            panel_FM_SubmitFee.Visible = false;
            panel_FM_ViewAll.Visible = false;
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

        

        

        private void button4_Click(object sender, EventArgs e)
        {
            FM_Class.SelectedIndex = -1;
            FM_Batch.SelectedIndex = -1;
            Fee.SelectedIndex = -1;
            FM_Id.Text = null;
            FM_Name.Text = null;
            FM_Fee.Text = null;
            FM_EmpId.Text = null;
            FM_EmpName.Text = null;
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            if(status == true)
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
                MessageBox.Show("You Must login First");
            }
        }

        private void btn_FM_search_Click(object sender, EventArgs e)
        {
            if(status == true)
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

            Login_Panel.Visible = true;
            Logged_Panel.Visible = false;

            panel_FM_SubmitFee.Visible = false;
            panel_FM_ViewAll.Visible = false;
        }

        private void btn_ShowAll_Click(object sender, EventArgs e)
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

        private void FM_Id_TextChanged(object sender, EventArgs e)
        {
            if (status == true)
            {
                if(FM_Id.Text.Length != 0)
                {
                    string sql = "select * from Std_Management where Std_Id = " + FM_Id.Text + " and Class = " + FM_Class.Text + " and Batch_No = '"+FM_Batch.Text+"' ;";
                    
                    SqlCommand cmd = new SqlCommand(sql, con);

                    try
                    {
                        con.Open();
                        SqlDataReader read = cmd.ExecuteReader();
                        if (read.Read())
                        {
                            FM_Name.Text = read.GetString(1);

                            sid = read.GetInt32(0).ToString();
                            sname = read.GetString(1);
                            mfee = read.GetInt32(10).ToString();
                            efee = read.GetInt32(11).ToString();
                            ayear = read.GetInt32(12).ToString();

                            trig = true;

                            label_AllClear.Visible = true;
                            label_NotFound.Visible = false;
                        }
                        else
                        {
                            Console.WriteLine("\n\n  Error in Reading Std Name from Std_Management  \n\n");
                            label_AllClear.Visible = false;
                            label_NotFound.Visible = true;
                            FM_Name.Text = null;

                            trig = false;
                        }
                        con.Close();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("\n\n  Error in Reading Std Name from Std_Management  \n\n");
                        label_AllClear.Visible = false;
                        label_NotFound.Visible = true;

                        trig = false;
                    }

                    fetchFee();
                }
                else
                {
                    Console.WriteLine("\n\n  Student Id Field Is Empty \n\n");
                }
            }
            else
            {
                MessageBox.Show("You Must login First");
            }
        }

        private void FM_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            FM_Id_TextChanged(FM_Id, EventArgs.Empty);
        }

        private void FM_Batch_SelectedIndexChanged(object sender, EventArgs e)
        {
            FM_Id_TextChanged(FM_Id, EventArgs.Empty);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                string sql = "insert into Fee_Management values('" + FM_Date.Text + "' , " + FM_Id.Text + ", '" + FM_Name.Text + "' , " + FM_Class.Text + ", '" + FM_Batch.Text + "' , " + FM_Fee.Text + ", '" + Fee.Text + "', '" + FeeMonth.Text + "', " + FM_EmpId.Text + ", '" + FM_EmpName.Text + "');";
                
                SqlCommand cmd = new SqlCommand(sql, con);
                
                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Fee Submited Successfully");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error in Submition of Fee");
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("You Must login First");
            }
        }

        private void FM_View_Search_TextChanged(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void FM_View_Column_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        
    }
}
