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
    public partial class StaffManagement : Form
    {
        public StaffManagement()
        {
            InitializeComponent();
        }

        //connecting with database
        SqlConnection con = new SqlConnection(Main_Form.SqlConnectString());
        //end of connecting with database

        string userNAme, password;
        string id, name, fname, contact, cnic, birthdate, address, gender, email, designation, depart, departid, pay;
        Boolean status = false;

        void fillCombo()
        {
            // fills up every combo that needs to be auto filled

            string sql = "select * from Staff_Management where Designation = 'Teacher' ;";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader read;

            con.Open();

            read = cmd.ExecuteReader();
            while (read.Read())
            {
                string sName = read.GetString(1);
                string sId = read.GetInt32(0).ToString();
                TM_AC_SelectTeacher.Items.Add(sName);  // fills comboBox with Teacher's name
                TM_AC_SelectId.Items.Add(sId); // fills comboBox with Teacher's Id in TM Assign Class panel
                TM_Update_SelectId.Items.Add(sId); // fill comboBox with Teacher's Id in TM's update panel
                comboBox1.Items.Add(sName); // fills comboBox with Teacher's name
                comboBox2.Items.Add(sId);// fills comboBox with Teacher's Id in TM Assign Class panel
                TM_Remove_SelectId.Items.Add(sId); // fill comboBox with Teacher's Id in TM's Remove panel

            }

            con.Close();

            //for Assign Class Table
            string sql1 = "select * from Assign_Class ;";
            SqlCommand cmd1 = new SqlCommand(sql1, con);
            SqlDataReader read1;

            con.Open();

            read1 = cmd1.ExecuteReader();
            while (read1.Read())
            {
                string sName1 = read1.GetString(1);
                TM_AC_SelectSubject.Text = sName1; //fills up subject comboBox in Assign class panel
            }

            con.Close();

            // for all staff
            string sql2 = "select * from Staff_Management;";
            SqlCommand cmd2 = new SqlCommand(sql2, con);
            SqlDataReader read2;

            con.Open();

            read2 = cmd2.ExecuteReader();
            while (read2.Read())
            {
                string sName = read2.GetString(1);
                string sId = read2.GetInt32(0).ToString();
                SM_Remove_SelectId.Items.Add(sId);  //fills up Id comboBox in Remove staff panel
                SM_Update_SelectId.Items.Add(sId); //fills up Id comboBox in update staff panel

            }

            con.Close();


        }

        void nullAll()
        {
            //for TM add panel
            TM_Add_EmpId.Text = null;
            TM_Add_EmpName.Text = null;
            TM_Add_FName.Text = null;
            TM_Add_Contact.Text = null;
            TM_Add_CNIC.Text = null;
            TM_Add_BirthDate.Value = DateTime.Now;
            TM_Add_Gender.SelectedIndex = -1;
            TM_Add_StaffAddress.Text = null;
            TM_Add_Email.Text = null;
            TM_Add_UserName.Text = null;
            TM_Add_Password.Text = null;
            TM_Add_MonthlyPay.Text = null;

            //for TM remove panel
            TM_Remove_SelectId.SelectedIndex = -1;
            TM_Remove_EmpName.Text = null;
            TM_Remove_FName.Text = null;
            TM_Remove_Contact.Text = null;
            TM_Remove_CNIC.Text = null;
            TM_Remove_BirthDate.Value = DateTime.Now;
            TM_Remove_Gender.SelectedIndex = -1;
            TM_Remove_staffAddress.Text = null;
            TM_Remove_Email.Text = null;
            TM_Remove_UserName.Text = null;
            TM_Remove_Password.Text = null;
            TM_Remove_MonthlyPay.Text = null;

            TM_Remove_SelectId.Items.Clear();

            //for TM update panel
            TM_Update_SelectId.SelectedIndex = -1;
            TM_Update_EmpName.Text = null;
            TM_Update_FName.Text = null;
            TM_Update_Contact.Text = null;
            TM_Update_CNIC.Text = null;
            TM_Update_BirthDate.Value = DateTime.Now;
            TM_Update_Gender.SelectedIndex = -1;
            TM_Update_StaffAddress.Text = null;
            TM_Update_Email.Text = null;
            TM_Update_UserName.Text = null;
            TM_Update_Password.Text = null;
            TM_Update_MonthlyPay.Text = null;

            TM_Update_SelectId.Items.Clear();

            

            //for TM assign class panel
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            TM_AC_SelectTeacher.Items.Clear();
            TM_AC_SelectId.Items.Clear();
            comboBox_TeacherManagement_ActiveClasses_SelectClass.SelectedIndex = 0;

            //for SM add panel
            SM_Add_EmpId.Text = null;
            SM_Add_EmpName.Text = null;
            SM_Add_FName.Text = null;
            SM_Add_Contact.Text = null;
            SM_Add_CNIC.Text = null;
            SM_Add_BirthDate.Value = DateTime.Now;
            SM_Add_Gender.SelectedIndex = -1;
            SM_Add_StaffAddress.Text = null;
            SM_Add_Email.Text = null;
            SM_Add_UserName.Text = null;
            SM_Add_Password.Text = null;
            SM_Add_MonthlyPay.Text = null;
            SM_Add_Department.SelectedIndex = -1;
            SM_Add_DepartId.Text = null;
            SM_Add_Designation.SelectedIndex = -1;

            //for SM update panel
            SM_Update_SelectId.SelectedIndex = -1;
            SM_Update_EmpName.Text = null;
            SM_Update_FName.Text = null;
            SM_Update_Contact.Text = null;
            SM_Update_CNIC.Text = null;
            SM_Update_BirthDate.Value = DateTime.Now;
            SM_Update_Gender.SelectedIndex = -1;
            SM_Update_staffAddress.Text = null;
            SM_Update_Email.Text = null;
            SM_Update_UserName.Text = null;
            SM_Update_Password.Text = null;
            SM_Update_MonthlyPay.Text = null;
            SM_Update_Department.Text = null;
            SM_Update_DepartId.Text = null;
            SM_Update_Designation.Text = null;

            //for SM Remove panel
            SM_Remove_SelectId.SelectedIndex = -1;
            SM_Remove_EmpName.Text = null;
            SM_Remove_FName.Text = null;
            SM_Remove_Contact.Text = null;
            SM_Remove_CNIC.Text = null;
            SM_Remove_BirthDate.Value = DateTime.Now;
            SM_Remove_Gender.SelectedIndex = -1;
            SM_Remove_staffAddress.Text = null;
            SM_Remove_Email.Text = null;
            SM_Remove_UserName.Text = null;
            SM_Remove_Password.Text = null;
            SM_Remove_MonthlyPay.Text = null;
            SM_Remove_Department.Text = null;
            SM_Remove_DepartId.Text = null;
            SM_Remove_Designation.Text = null;

            //for SM remove panel
            SM_Remove_SelectId.Items.Clear();

            //for SM update panel
            SM_Update_SelectId.Items.Clear();

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

            panel_TeacherManagement.Visible = false;
            panelStaffManagement.Visible = false;
            panel_ShowAll.Visible = false;

            nullAll();
        }

        private void btn_TM_Click(object sender, EventArgs e)
        {
            setSidePanel(btn_TM.Height, btn_TM.Top);

            Logged_Panel.Visible = false;
            Login_Panel.Visible = false;
            panel_TeacherManagement.Visible = true;
            panelStaffManagement.Visible = false;
            panel_ShowAll.Visible = false;

            nullAll();
        }

        private void btn_SM_Click(object sender, EventArgs e)
        {
            setSidePanel(btn_SM.Height, btn_SM.Top);

            Logged_Panel.Visible = false;
            Login_Panel.Visible = false;
            panel_TeacherManagement.Visible = false;
            panelStaffManagement.Visible = true;
            panel_ShowAll.Visible = false;

            nullAll();
        }

        private void btn_VA_Click(object sender, EventArgs e)
        {
            setSidePanel(btn_VA.Height, btn_VA.Top);

            Logged_Panel.Visible = false;
            Login_Panel.Visible = false;
            panel_TeacherManagement.Visible = false;
            panelStaffManagement.Visible = false;
            panel_ShowAll.Visible = true;

            nullAll();
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

        private void label4_Click(object sender, EventArgs e)
        {
            forgotPassword forgot = new forgotPassword();
            forgot.ShowDialog();
        }

        private void btn_Logout_Click(object sender, EventArgs e)
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

            panel_TeacherManagement.Visible = false;
            panelStaffManagement.Visible = false;
            panel_ShowAll.Visible = false;

            SM_DataView.DataSource = null;
            TM_ShowAll.DataSource = null;
            dataGridView_TM_ActiveClasses.DataSource = null;
            dataGridView_ShowAll.DataSource = null;
        }

        private void button_TeacherManagement_Add_Click(object sender, EventArgs e)
        {
            panel_TeacherManagement_Add.Visible = true;
            panel_TeacherManagement_Remove.Visible = false;
            panel_TeacherManagement_Update.Visible = false;
            panel_TeacherManagement_ShowAll.Visible = false;
            panel_TeacherManagement_AssignClass.Visible = false;
            panel_TeacherManagement_ActiveClasses.Visible = false;

            nullAll();
        }

        private void button_TeacherManagement_Update_Click(object sender, EventArgs e)
        {
            panel_TeacherManagement_Add.Visible = false;
            panel_TeacherManagement_Remove.Visible = false;
            panel_TeacherManagement_Update.Visible = true;
            panel_TeacherManagement_ShowAll.Visible = false;
            panel_TeacherManagement_AssignClass.Visible = false;
            panel_TeacherManagement_ActiveClasses.Visible = false;


            nullAll();
            fillCombo();
        }

        private void button_TeacherManagement_Remove_Click(object sender, EventArgs e)
        {
            panel_TeacherManagement_Add.Visible = false;
            panel_TeacherManagement_Remove.Visible = true;
            panel_TeacherManagement_Update.Visible = false;
            panel_TeacherManagement_ShowAll.Visible = false;
            panel_TeacherManagement_AssignClass.Visible = false;
            panel_TeacherManagement_ActiveClasses.Visible = false;

            nullAll();
            fillCombo();
        }

        private void button_TeacherManagement_ShowAll_Click(object sender, EventArgs e)
        {
            panel_TeacherManagement_Add.Visible = false;
            panel_TeacherManagement_Remove.Visible = false;
            panel_TeacherManagement_Update.Visible = false;
            panel_TeacherManagement_ShowAll.Visible = true;
            panel_TeacherManagement_AssignClass.Visible = false;
            panel_TeacherManagement_ActiveClasses.Visible = false;



            nullAll();
        }

        private void button_TeacherManagement_AssignClass_Click(object sender, EventArgs e)
        {
            panel_TeacherManagement_Add.Visible = false;
            panel_TeacherManagement_Remove.Visible = false;
            panel_TeacherManagement_Update.Visible = false;
            panel_TeacherManagement_ShowAll.Visible = false;
            panel_TeacherManagement_AssignClass.Visible = true;
            panel_TeacherManagement_ActiveClasses.Visible = false;

            nullAll();
            fillCombo();
        }

        private void button_TeacherManagement_ActiveClasses_Click(object sender, EventArgs e)
        {
            panel_TeacherManagement_Add.Visible = false;
            panel_TeacherManagement_Remove.Visible = false;
            panel_TeacherManagement_Update.Visible = false;
            panel_TeacherManagement_ShowAll.Visible = false;
            panel_TeacherManagement_AssignClass.Visible = false;
            panel_TeacherManagement_ActiveClasses.Visible = true;

            nullAll();
        }

        private void AutoFill_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                TM_Add_EmpId.Text = "001";
                TM_Add_EmpName.Text = "Izhan Yameen";
                TM_Add_FName.Text = "Yameen Baig";
                TM_Add_Contact.Text = "03323032154";
                TM_Add_CNIC.Text = "4210184211268";
                TM_Add_BirthDate.Value = new DateTime(1996, 04, 25);
                TM_Add_Gender.SelectedIndex = 0;
                TM_Add_StaffAddress.Text = "8/12 Liaquatabad karachi";
                TM_Add_Email.Text = "izhan.yamen@gmail.com";
                TM_Add_UserName.Text = "izhan";
                TM_Add_Password.Text = "karachi";
                TM_Add_MonthlyPay.Text = "15000";
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void button_TeacherManagement_Add_Save_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                //saving values in database here

                try
                {

                    con.Open();
                    string sql = "insert into Staff_Management values( '" + int.Parse(TM_Add_EmpId.Text) + "' , '" + TM_Add_EmpName.Text + "' , '" + TM_Add_FName.Text + "' , '" + TM_Add_Contact.Text + "' , '" + TM_Add_CNIC.Text + "' , '" + TM_Add_BirthDate.Value.ToString() + "' , '" + TM_Add_StaffAddress.Text + "' , '" + TM_Add_Gender.SelectedItem.ToString() + "' , '" + TM_Add_Email.Text + "' , '" + TM_Add_UserName.Text + "' , '" + TM_Add_Password.Text + "' , '" + TM_Add_Designation.Text + "' , '" + TM_Add_Department.Text + "' , '" + int.Parse(TM_Add_DepartId.Text) + "' , '" + int.Parse(TM_Add_MonthlyPay.Text) + "')";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Data saved successfully");
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Error 001 (Can't save values in Database)");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void button_TeacherManagement_Update_Search_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                //searching record in database
                try
                {
                    con.Open();
                    string sql = "select * from Staff_Management where Emp_Id = " + TM_Update_SelectId.Text + ";";
                    SqlCommand cmd = new SqlCommand(sql, con);

                    SqlDataReader read = cmd.ExecuteReader();

                    if (read.Read())
                    {
                        TM_Update_EmpName.Text = read.GetString(1);
                        TM_Update_FName.Text = read.GetString(2);
                        TM_Update_Contact.Text = read.GetString(3);
                        TM_Update_CNIC.Text = read.GetString(4);
                        TM_Update_BirthDate.Text = read.GetValue(5).ToString();
                        TM_Update_StaffAddress.Text = read.GetString(6);
                        TM_Update_Gender.Text = read.GetValue(7).ToString();
                        TM_Update_Email.Text = read.GetString(8);
                        TM_Update_UserName.Text = read.GetString(9);
                        TM_Update_Password.Text = read.GetString(10);
                        TM_Update_Designation.Text = read.GetString(11);
                        TM_Update_Department.Text = read.GetString(12);
                        TM_Update_DepartId.Text = read.GetInt32(13).ToString();
                        TM_Update_MonthlyPay.Text = read.GetInt32(14).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Error 003 (Can't read the id number of " + TM_Update_SelectId.Text + ")");
                    }

                    con.Close();
                }
                catch (Exception ex3)
                {
                    MessageBox.Show("Eror 004 ( Can't Fetch the id number of " + TM_Update_SelectId.Text + ")");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void button_TeacherManagement_Update_Update_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                //updating the searched record here
                try
                {

                    con.Open();
                    string sql = "Update Staff_Management set Emp_Name =  '" + TM_Update_EmpName.Text + "' , F_Name = '" + TM_Update_FName.Text + "' , contact =  '" + TM_Update_Contact.Text + "' , CNIC =  '" + TM_Update_CNIC.Text + "' , BirthDate = '" + TM_Update_BirthDate.Value.ToString() + "' , Staff_Address = '" + TM_Update_StaffAddress.Text + "' , Gender =  '" + TM_Update_Gender.SelectedItem.ToString() + "' , Email = '" + TM_Update_Email.Text + "' , userName = '" + TM_Update_UserName.Text + "' , pass = '" + TM_Update_Password.Text + "' , Designation =  '" + TM_Update_Designation.Text + "' , Department =  '" + TM_Update_Department.Text + "' , Depart_Id =  '" + int.Parse(TM_Update_DepartId.Text) + "' , Monthly_Pay = '" + int.Parse(TM_Update_MonthlyPay.Text) + "'  where Emp_Id = '" + int.Parse(TM_Update_SelectId.SelectedItem.ToString()) + "' ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Data Updated successfully");
                }
                catch (Exception ex2)
                {
                    MessageBox.Show("Error 002 (Can't Update values in Database)");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void button_TeacherManagement_Remove_Search_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                //searching record in database
                try
                {
                    con.Open();
                    string sql = "select * from Staff_Management where Emp_Id = " + TM_Remove_SelectId.SelectedItem.ToString() + ";";
                    SqlCommand cmd = new SqlCommand(sql, con);

                    SqlDataReader read = cmd.ExecuteReader();

                    if (read.Read())
                    {
                        TM_Remove_EmpName.Text = read.GetString(1);
                        TM_Remove_FName.Text = read.GetString(2);
                        TM_Remove_Contact.Text = read.GetString(3);
                        TM_Remove_CNIC.Text = read.GetString(4);
                        TM_Remove_BirthDate.Text = read.GetValue(5).ToString();
                        TM_Remove_staffAddress.Text = read.GetString(6);
                        TM_Remove_Gender.Text = read.GetValue(7).ToString();
                        TM_Remove_Email.Text = read.GetString(8);
                        TM_Remove_UserName.Text = read.GetString(9);
                        TM_Remove_Password.Text = read.GetString(10);
                        TM_Remove_Designation.Text = read.GetString(11);
                        TM_Remove_Department.Text = read.GetString(12);
                        TM_Remove_DepartId.Text = read.GetInt32(13).ToString();
                        TM_Remove_MonthlyPay.Text = read.GetInt32(14).ToString();



                    }
                    else
                    {
                        MessageBox.Show("Error 005 (Can't read the id number of " + TM_Remove_SelectId.SelectedItem.ToString() + " FOR REMOVE)");
                    }

                    con.Close();
                }
                catch (Exception ex4)
                {
                    MessageBox.Show("Error 006 ( Can't Fetch the id number of " + TM_Remove_SelectId.SelectedItem.ToString() + " FOR REMOVE)");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void button_TeacherManagement_Remove_Remove_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                //removing record from database
                try
                {

                    con.Open();
                    string sql = "delete from Staff_Management where Emp_Id = " + TM_Remove_SelectId.SelectedItem.ToString() + "; ";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Data Deleted successfully");
                }
                catch (Exception ex5)
                {

                    MessageBox.Show("Error 007 (Can't Delete values from Database)");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void button_TeacherManagement_Search_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                try
                {
                    SM_DataView.DataSource = null;
                    con.Open();
                    string sql = "select * from Staff_Management where " + TM_ShowAll_allColumns.Text + " = '" + TM_ShowAll_Search.Text + "' ";


                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    TM_ShowAll.DataSource = dt;

                    con.Close();
                }
                catch (Exception ex8)
                {
                    MessageBox.Show("Error 014 , cant search");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void button_TM_ShowAll_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                try
                {
                    con.Open();
                    string sql = "select * from Staff_Management where Designation = 'Teacher' ";

                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    TM_ShowAll.DataSource = dt;

                    con.Close();
                }
                catch (Exception ex13)
                {
                    MessageBox.Show("Error");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
            nullAll();
        }
        int x = 0; //creates a int to use for toggle
        private void btn_Toggle_Emp_Click(object sender, EventArgs e)
        {
            //toggling the EmpName and EmpId
            if (x == 0)
            {
                TM_AC_SelectId.Enabled = true;
                TM_AC_SelectTeacher.Enabled = false;
                x = 1;
            }
            else if (x == 1)
            {
                TM_AC_SelectId.Enabled = false;
                TM_AC_SelectTeacher.Enabled = true;
                x = 0;
            }
            else
            {
                MessageBox.Show("Error 008 , Can't toggle the Emp comboBox");
            }
        }

        private void btn_AssignClass_Save_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                //assigning classes to teacher
                try
                {
                    con.Open();

                    string sql = "insert into Assign_Class values ( " + TM_AS_SelectClass.Text + " , '" + TM_AC_SelectBatchNo.Text + "' , '" + TM_AC_SelectSubject.Text + "' , '" + comboBox2.Text + "' , '" + comboBox1.Text + "' ) ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Saved");

                    TM_AC_SelectSubject_SelectedIndexChanged(TM_AC_SelectSubject, EventArgs.Empty);
 
                }
                catch (Exception ex4)
                {
                    MessageBox.Show("Error 004 (Can't Assign Class)");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void btn_AssignClass_Update_Click(object sender, EventArgs e)
        {
            //assigning classes to teacher
            try
            {
                //updating record in assign class table
                con.Open();
                string sql = "update Assign_Class set Emp_Id = " + TM_AC_SelectId.Text + ", Emp_Name = '" + TM_AC_SelectTeacher.Text + "'  where Class = " + TM_AS_SelectClass.Text + " and Batch_No = '" + TM_AC_SelectBatchNo.Text + "' and Sub = '" + TM_AC_SelectSubject.Text + "'";
                
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
                
                con.Close();

                //showing results after updating in labels
                con.Open();
                string sql1 = "select * from Assign_Class where Class = " + TM_AS_SelectClass.Text + " and Sub = '" + TM_AC_SelectSubject.Text + "' and Batch_No ='" + TM_AC_SelectBatchNo.Text + "'; ";
                SqlCommand cmd1 = new SqlCommand(sql1, con);
                SqlDataReader read = cmd1.ExecuteReader();
                if (read.Read())
                {
                    string sName = read.GetString(4);
                    int sid = read.GetInt32(3);
                    TeacherName.Text = sName;
                    TeacherId.Text = sid.ToString();
                    

                    panel_AssignTo.Visible = false;
                    panel_AssignedTo.Visible = true;

                    button2.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Error 011 ( Can't read the data from Assign class  )");
                }

                con.Close();

                MessageBox.Show("Record Updated 2");

                panel_AssignTo.Visible = false;
                panel_Update_subAssign.Visible = false;
                panel_AssignedTo.Visible = true;

                button2.Visible = true;
                btn_AssignClass_Update.Visible = false;

            }
            catch (Exception ex4)
            {
                MessageBox.Show("Error 004 (Can't Assign Class)");
                con.Close(); 
            }
        }

        
        private void TM_AC_SelectSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (status == true)
            {
                con.Open();
                string sql = "select * from Assign_Class where Class = " + TM_AS_SelectClass.Text + " and Sub = '" + TM_AC_SelectSubject.Text + "' and Batch_No ='" + TM_AC_SelectBatchNo.Text + "'; ";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader read = cmd.ExecuteReader();


                if (read.Read())
                {
                    string sName = read.GetString(4);
                    int sid = read.GetInt32(3);
                    TeacherName.Text = sName;
                    TeacherId.Text = sid.ToString();

                    panel_AssignTo.Visible = false;
                    panel_AssignedTo.Visible = true;

                    button2.Visible = true;
                }
                else
                {
                    panel_AssignTo.Visible = true;
                    panel_AssignedTo.Visible = false;
                    button2.Visible = false;
                }


                con.Close();
            }
            else 
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void TM_AC_SelectTeacher_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sName = TM_AC_SelectTeacher.Text;
            try
            {
                con.Open();
                string sql = "select * from Staff_Management where Emp_Name = '" + sName + "'; ";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader read = cmd.ExecuteReader();

                if (read.Read())
                {

                    string sid = read.GetInt32(0).ToString();
                    TM_AC_SelectId.Text = sid;

                }
                else
                {
                    MessageBox.Show("Error 009 ( Can't read the teacher's id from Staff Management )");
                }
                con.Close();
            }
            catch (Exception ex6)
            {
                MessageBox.Show("Error 012 ,in autofilling the id comboBox ");
                con.Close();
            }
        }

        private void button_TeacherManagement_ActiveClasses_Submit_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                if (comboBox_TeacherManagement_ActiveClasses_SelectClass.SelectedIndex != 0)
                {
                    try
                    {
                        con.Open();
                        string sql = "select * from Assign_Class where Class = '" + comboBox_TeacherManagement_ActiveClasses_SelectClass.SelectedItem.ToString() + "' ";

                        SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView_TM_ActiveClasses.DataSource = dt;

                        con.Close();
                    }
                    catch (Exception ex11)
                    {
                        MessageBox.Show("Error cant find result");
                        con.Close();
                    }
                }
                else if (comboBox_TeacherManagement_ActiveClasses_SelectClass.SelectedIndex == 0)
                {
                    dataGridView_TM_ActiveClasses.DataSource = null;
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void button_TeacherManagement_ActiveClasses_ShowAllClasses_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                try
                {
                    con.Open();
                    string sql = "select * from Assign_Class";

                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView_TM_ActiveClasses.DataSource = dt;

                    con.Close();
                }
                catch (Exception ex12)
                {
                    MessageBox.Show("Error cant find result");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void buttonAddStaff_Click(object sender, EventArgs e)
        {
            panel_Add_Staff.Visible = true;
            panel_Staff_Search.Visible = false;
            panel_Staff_Update.Visible = false;
            panel_Staff_Remove.Visible = false;

            nullAll();
        }

        private void buttonUpdateStaff_Click(object sender, EventArgs e)
        {
            panel_Add_Staff.Visible = false;
            panel_Staff_Search.Visible = false;
            panel_Staff_Update.Visible = true;
            panel_Staff_Remove.Visible = false;

            nullAll();
            fillCombo();
        }

        private void buttonRemoveStaff_Click(object sender, EventArgs e)
        {
            panel_Add_Staff.Visible = false;
            panel_Staff_Search.Visible = false;
            panel_Staff_Update.Visible = false;
            panel_Staff_Remove.Visible = true;

            nullAll();
            fillCombo();
        }

        private void buttonSearchStaff_Click(object sender, EventArgs e)
        {
            panel_Add_Staff.Visible = false;
            panel_Staff_Search.Visible = true;
            panel_Staff_Update.Visible = false;
            panel_Staff_Remove.Visible = false;

            nullAll();
        }

        private void buttonDoneAdd_Click(object sender, EventArgs e)
        {
            if (status == true)
            {//saving values of staff Panel in database here 

                try
                {

                    con.Open();
                    string sql = "insert into Staff_Management values( " + SM_Add_EmpId.Text + " , '" + SM_Add_EmpName.Text + "' , '" + SM_Add_FName.Text + "' , '" + SM_Add_Contact.Text + "' , '" + SM_Add_CNIC.Text + "' , '" + SM_Add_BirthDate.Text + "' , '" + SM_Add_StaffAddress.Text + "' , '" + SM_Add_Gender.Text + "' , '" + SM_Add_Email.Text + "' , '" + SM_Add_UserName.Text + "' , '" + SM_Add_Password.Text + "' , '" + SM_Add_Designation.Text + "' , '" + SM_Add_Department.Text + "' , " + SM_Add_DepartId.Text + " , " + SM_Add_MonthlyPay.Text + ")";
                    
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Data saved successfully");
                    
                }
                catch (Exception ex1)
                {
                    MessageBox.Show("Error 001 (Can't save values in Database)");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void btn_SM_UpdateSearch_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                //searching record in database
                try
                {
                    con.Open();
                    string sql = "select * from Staff_Management where Emp_Id = " + SM_Update_SelectId.Text + ";";
                    SqlCommand cmd = new SqlCommand(sql, con);

                    SqlDataReader read = cmd.ExecuteReader();

                    if (read.Read())
                    {
                        SM_Update_EmpName.Text = read.GetString(1);
                        SM_Update_FName.Text = read.GetString(2);
                        SM_Update_Contact.Text = read.GetString(3);
                        SM_Update_CNIC.Text = read.GetString(4);
                        SM_Update_BirthDate.Text = read.GetValue(5).ToString();
                        SM_Update_staffAddress.Text = read.GetString(6);
                        SM_Update_Gender.Text = read.GetValue(7).ToString();
                        SM_Update_Email.Text = read.GetString(8);
                        SM_Update_UserName.Text = read.GetString(9);
                        SM_Update_Password.Text = read.GetString(10);
                        SM_Update_Designation.Text = read.GetString(11);
                        SM_Update_Department.Text = read.GetString(12);
                        SM_Update_DepartId.Text = read.GetInt32(13).ToString();
                        SM_Update_MonthlyPay.Text = read.GetInt32(14).ToString();
                    }
                    else
                    {
                        MessageBox.Show("Error 005 (Can't read the id number of " + TM_Update_SelectId.SelectedItem.ToString() + " FOR update)");
                    }

                    con.Close();
                }
                catch (Exception ex4)
                {
                    MessageBox.Show("Error 006 ( Can't Fetch the id number of " + TM_Update_SelectId.Text + " FOR update)");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void btn_SM_Update_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                //Staff Management
                //updating the searched record here
                try
                {

                    con.Open();
                    string sql = "Update Staff_Management set Emp_Name =  '" + SM_Update_EmpName.Text + "' , F_Name = '" + SM_Update_FName.Text + "' , contact =  '" + SM_Update_Contact.Text + "' , CNIC =  '" + SM_Update_CNIC.Text + "' , BirthDate = '" + SM_Update_BirthDate.Value.ToString() + "' , Staff_Address = '" + SM_Update_staffAddress.Text + "' , Gender =  '" + SM_Update_Gender.SelectedItem.ToString() + "' , Email = '" + SM_Update_Email.Text + "' , userName = '" + SM_Update_UserName.Text + "' , pass = '" + SM_Update_Password.Text + "' , Designation =  '" + SM_Update_Designation.Text + "' , Department =  '" + SM_Update_Department.Text + "' , Depart_Id =  '" + int.Parse(SM_Update_DepartId.Text) + "' , Monthly_Pay = '" + int.Parse(SM_Update_MonthlyPay.Text) + "'  where Emp_Id = '" + int.Parse(SM_Update_SelectId.SelectedItem.ToString()) + "' ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Data Updated successfully");
                }
                catch (Exception ex2)
                {
                    MessageBox.Show("Error 002 (Can't Update values in Database)");
                    con.Close();
                }
            }
            else 
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void btn_SM_RemoveSearch_Click(object sender, EventArgs e)
        {
            if (status == true)
            {//searching record in database
                try
                {
                    con.Open();
                    string sql = "select * from Staff_Management where Emp_Id = '" + SM_Remove_SelectId.SelectedItem.ToString() + "'";
                    SqlCommand cmd = new SqlCommand(sql, con);

                    SqlDataReader read = cmd.ExecuteReader();

                    if (read.Read())
                    {
                        SM_Remove_EmpName.Text = read.GetString(1);
                        SM_Remove_FName.Text = read.GetString(2);
                        SM_Remove_Contact.Text = read.GetString(3);
                        SM_Remove_CNIC.Text = read.GetString(4);
                        SM_Remove_BirthDate.Text = read.GetValue(5).ToString();
                        SM_Remove_staffAddress.Text = read.GetString(6);
                        SM_Remove_Gender.Text = read.GetValue(7).ToString();
                        SM_Remove_Email.Text = read.GetString(8);
                        SM_Remove_UserName.Text = read.GetString(9);
                        SM_Remove_Password.Text = read.GetString(10);
                        SM_Remove_Designation.Text = read.GetString(11);
                        SM_Remove_Department.Text = read.GetString(12);
                        SM_Remove_DepartId.Text = read.GetInt32(13).ToString();
                        SM_Remove_MonthlyPay.Text = read.GetInt32(14).ToString();



                    }
                    else
                    {
                        MessageBox.Show("Error 005 (Can't read the id number of " + TM_Remove_SelectId.SelectedItem.ToString() + " FOR REMOVE)");
                    }

                    con.Close();
                }
                catch (Exception ex4)
                {
                    MessageBox.Show("Error 006 ( Can't Fetch the id number of " + TM_Remove_SelectId.SelectedItem.ToString() + " FOR REMOVE)");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void btn_SM_Remove_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                //Staff Management
                //removing record from database
                try
                {

                    con.Open();
                    string sql = "delete from Staff_Management where Emp_Id = '" + int.Parse(SM_Remove_SelectId.SelectedItem.ToString()) + "' ";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Data of " + SM_Remove_SelectId.SelectedItem.ToString() + " Deleted successfully");
                }
                catch (Exception ex5)
                {
                    MessageBox.Show("Error 007 (Can't Delete values from Database)");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void btn_SM_Search_Click(object sender, EventArgs e)
        {
            if (status == true)
            {//searching all staff in show all panel
                try
                {
                    con.Open();
                    string sql = "select * from Staff_Management where " + SM_SearchBy.Text + " = '" + SM_Search.Text + "'";

                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    SM_DataView.DataSource = dt;

                    con.Close();
                }
                catch (Exception ex7)
                {
                    MessageBox.Show("Error 013 , cant search");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void btn_SM_ShowAll_Click(object sender, EventArgs e)
        {
            if (status == true)
            {//showing all staff in show all panel
                try
                {
                    con.Open();
                    string sql = "select * from Staff_Management";

                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    SM_DataView.DataSource = dt;

                    con.Close();
                }
                catch (Exception ex7)
                {
                    MessageBox.Show("Error 013 , cant search");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }

            nullAll();
        }

        private void button_ShowAll_Search_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                //searching all staff in show all panel
                try
                {
                    con.Open();
                    string sql = "select * from Staff_Management where " + comboBox_ShowAll_SearchIn.Text + " = '" + textBox_ShowAll_Search.Text + "' ";

                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView_ShowAll.DataSource = dt;

                    con.Close();
                }
                catch (Exception ex8)
                {
                    MessageBox.Show("Error 014 , cant search");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
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
                MessageBox.Show("You Must Login First");
            }

            nullAll();
        }

        private void SM_Add_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
            string depart = SM_Add_Department.Text;

            switch (depart)
            {
                case "Faculty":
                    SM_Add_Designation.Items.Clear();
                    SM_Add_DepartId.Text = "001";
                    SM_Add_Designation.Items.Add("Teacher");
                    break;
                case "Co-ordination":
                    SM_Add_Designation.Items.Clear();
                    SM_Add_DepartId.Text = "002";
                    SM_Add_Designation.Items.Add("Junior Co-ordinator");
                    SM_Add_Designation.Items.Add("Senior Co-ordinator");
                    break;
                case "Reception":
                    SM_Add_Designation.Items.Clear();
                    SM_Add_DepartId.Text = "003";
                    SM_Add_Designation.Items.Add("Senior Receptionist");
                    SM_Add_Designation.Items.Add("Junior Receptionist");
                    break;
                case "Marketing":
                    SM_Add_Designation.Items.Clear();
                    SM_Add_DepartId.Text = "004";
                    SM_Add_Designation.Items.Add("Director");
                    SM_Add_Designation.Items.Add("Manager");
                    SM_Add_Designation.Items.Add("Consultant");
                    break;
                case "Management":
                    SM_Add_Designation.Items.Clear();
                    SM_Add_DepartId.Text = "005";
                    SM_Add_Designation.Items.Add("Incharge");
                    SM_Add_Designation.Items.Add("Vice Principle");
                    break;
                default:
                    SM_Add_Designation.Items.Clear();
                    SM_Add_DepartId.Text = null;
                    break;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel_Update_subAssign.Visible = true;
            panel_AssignedTo.Visible = false;
            panel_AssignTo.Visible = false;

            button2.Visible = false;
            btn_AssignClass_Update.Visible = true;
        }
        int a = 0; //creates a int to use for toggle
        private void button1_Click(object sender, EventArgs e)
        {
            //toggling the EmpName and EmpId
            if (a == 0)
            {
                comboBox2.Enabled = true;
                comboBox1.Enabled = false;
                a = 1;
            }
            else if (a == 1)
            {
                comboBox2.Enabled = false;
                comboBox1.Enabled = true;
                a = 0;
            }
            else
            {
                MessageBox.Show("Error 008 , Can't toggle the Emp comboBox");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sName = comboBox1.Text;
            try
            {
                con.Open();
                string sql = "select * from Staff_Management where Emp_Name = '" + sName + "'; ";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader read = cmd.ExecuteReader();

                if (read.Read())
                {

                    string sid = read.GetInt32(0).ToString();
                    comboBox2.Text = sid;

                }
                else
                {
                    MessageBox.Show("Error 009 ( Can't read the teacher's id from Staff Management )");
                }
                con.Close();
            }
            catch (Exception ex6)
            {
                MessageBox.Show("Error 012 ,in autofilling the id comboBox " + sName + " id = " + id);
                con.Close();
            }
        }

        

        private void Min_Hover(object sender, EventArgs e)
        {
            this.Min.BackColor = Color.Gray;
        }

        private void Min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Min_MouseLeave(object sender, EventArgs e)
        {
            this.Min.BackColor = Color.Transparent;
        }

        private void TM_AC_SelectId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string sId = TM_AC_SelectId.Text;
            //try
            //{
            //    con.Open();
            //    string sql = "select * from Staff_Management where Emp_Id = " + sId + "; ";
            //    SqlCommand cmd = new SqlCommand(sql, con);
            //    SqlDataReader read = cmd.ExecuteReader();

            //    if (read.Read())
            //    {

            //        string sName = read.GetString(1);
            //        TM_AC_SelectTeacher.Text = sName;

            //    }
            //    else
            //    {
            //        MessageBox.Show("Error 009 ( Can't read the teacher's id from Staff Management )");
            //    }
            //    con.Close();
            //}
            //catch (Exception ex6)
            //{
            //    MessageBox.Show("Error 012 ,in autofilling the id comboBox ");
            //    con.Close();
            //}
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string sId = comboBox2.Text;
            //try
            //{
            //    con.Open();
            //    string sql = "select * from Staff_Management where Emp_Id = " + sId + "; ";
            //    SqlCommand cmd = new SqlCommand(sql, con);
            //    SqlDataReader read = cmd.ExecuteReader();

            //    if (read.Read())
            //    {

            //        string sName = read.GetString(1);
            //        comboBox2.Text = sName;

            //    }
            //    else
            //    {
            //        MessageBox.Show("Error 009 ( Can't read the teacher's id from Staff Management )");
            //    }
            //    con.Close();
            //}
            //catch (Exception ex6)
            //{
            //    MessageBox.Show("Error 012 ,in autofilling the id comboBox ");
            //    con.Close();
            //}
        }

        private void TM_AS_SelectClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            TM_AC_SelectSubject_SelectedIndexChanged(TM_AC_SelectSubject, EventArgs.Empty);
        }

        private void TM_AC_SelectBatchNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TM_AC_SelectSubject_SelectedIndexChanged(TM_AC_SelectSubject, EventArgs.Empty);
        }

        private void comboBox_TeacherManagement_ActiveClasses_SelectClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (status == true)
            {
                if (comboBox_TeacherManagement_ActiveClasses_SelectClass.SelectedIndex != 0)
                {
                    try
                    {
                        if (comboBox_TeacherManagement_ActiveClasses_SelectClass.SelectedIndex != 0)
                        {
                            con.Open();
                            string sql = "select * from Assign_Class where Class = '" + comboBox_TeacherManagement_ActiveClasses_SelectClass.SelectedItem.ToString() + "' ";

                            SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            dataGridView_TM_ActiveClasses.DataSource = dt;

                            con.Close();
                        }
                        else
                        {
                            dataGridView_TM_ActiveClasses.DataSource = null;
                        }
                    }
                    catch (Exception ex11)
                    {
                        MessageBox.Show("Error cant find result");
                        con.Close();
                    }
                }
                else if (comboBox_TeacherManagement_ActiveClasses_SelectClass.SelectedIndex == 0)
                {
                    dataGridView_TM_ActiveClasses.DataSource = null;
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void btn_AutoFill_Click(object sender, EventArgs e)
        {
            SM_Add_EmpId.Text = "001";
            SM_Add_EmpName.Text = "Zainab Ahmed";
            SM_Add_FName.Text = "Ahmed Sarfaraz";
            SM_Add_Contact.Text = "03127896541";
            SM_Add_CNIC.Text = "4215638741213";
            SM_Add_BirthDate.Value = new DateTime(1996, 04, 25);
            SM_Add_StaffAddress.Text = "karachi";
            SM_Add_Gender.SelectedIndex = 1;
            SM_Add_Email.Text = "zainab.ahmed@gmail.com";
            SM_Add_UserName.Text = "zainab";
            SM_Add_Password.Text = "pass";
            SM_Add_Designation.Text = "Junior Receptionist";
            SM_Add_Department.Text = "Reception";
            SM_Add_DepartId.Text = "003";
            SM_Add_MonthlyPay.Text = "15000";
        }

        private void SM_Add_Contact_TextChanged(object sender, EventArgs e)
        {
            SM_Add_Contact.Text = Main_Form.numCheck(SM_Add_Contact.Text);
        }

        private void SM_Add_CNIC_TextChanged(object sender, EventArgs e)
        {
            SM_Add_CNIC.Text = Main_Form.numCheck(SM_Add_CNIC.Text);
        }

        private void SM_Add_DepartId_TextChanged(object sender, EventArgs e)
        {
            SM_Add_DepartId.Text = Main_Form.numCheck(SM_Add_DepartId.Text);
        }

        private void SM_Add_MonthlyPay_TextChanged(object sender, EventArgs e)
        {
            SM_Add_MonthlyPay.Text = Main_Form.numCheck(SM_Add_MonthlyPay.Text);
        }

        private void SM_Add_EmpId_TextChanged(object sender, EventArgs e)
        {
            SM_Add_EmpId.Text = Main_Form.numCheck(SM_Add_EmpId.Text);
        }

        private void SM_Update_Contact_TextChanged(object sender, EventArgs e)
        {
            SM_Update_Contact.Text = Main_Form.numCheck(SM_Update_Contact.Text);
        }

        private void SM_Update_CNIC_TextChanged(object sender, EventArgs e)
        {
            SM_Update_CNIC.Text = Main_Form.numCheck(SM_Update_CNIC.Text);
        }

        private void SM_Update_MonthlyPay_TextChanged(object sender, EventArgs e)
        {
            SM_Update_MonthlyPay.Text = Main_Form.numCheck(SM_Update_MonthlyPay.Text);
        }

        private void SM_Update_DepartId_TextChanged(object sender, EventArgs e)
        {
            SM_Update_DepartId.Text = Main_Form.numCheck(SM_Update_DepartId.Text);
        }

        private void TM_Add_Contact_TextChanged(object sender, EventArgs e)
        {
            TM_Add_Contact.Text = Main_Form.numCheck(TM_Add_Contact.Text);
        }

        private void TM_Add_CNIC_TextChanged(object sender, EventArgs e)
        {
            TM_Add_CNIC.Text = Main_Form.numCheck(TM_Add_CNIC.Text);
        }

        private void TM_Add_MonthlyPay_TextChanged(object sender, EventArgs e)
        {
            TM_Add_MonthlyPay.Text = Main_Form.numCheck(TM_Add_MonthlyPay.Text);
        }

        private void TM_Add_EmpId_TextChanged(object sender, EventArgs e)
        {
            TM_Add_EmpId.Text = Main_Form.numCheck(TM_Add_EmpId.Text);
        }

        private void TM_Update_Contact_TextChanged(object sender, EventArgs e)
        {
            TM_Update_Contact.Text = Main_Form.numCheck(TM_Update_Contact.Text);
        }

        private void TM_Update_CNIC_TextChanged(object sender, EventArgs e)
        {
            TM_Update_CNIC.Text = Main_Form.numCheck(TM_Update_CNIC.Text);
        }

        private void TM_Update_MonthlyPay_TextChanged(object sender, EventArgs e)
        {
            TM_Update_MonthlyPay.Text = Main_Form.numCheck(TM_Update_MonthlyPay.Text);
        }
    }
}
