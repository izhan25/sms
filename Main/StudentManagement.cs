using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Main
{
    public partial class StudentManagement : Form
    {
        public StudentManagement()
        {
            InitializeComponent();
        }
        //connecting with database
        SqlConnection con = new SqlConnection(Main_Form.SqlConnectString());
        //end of connecting with database
        string userNAme, password;
        string id, name, fname, contact, cnic, birthdate, address, gender, email, designation, depart, departid, pay;
        Boolean status = false;
        string mySql = null;


        void fillCombo()
        {
            //fills up every comboBox that needs to be autofilled

            string sql = "select Std_Id from Std_Management;";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader read;

            con.Open();

            read = cmd.ExecuteReader();
            while (read.Read())
            {
                string sId = read.GetInt32(0).ToString();
                Remove_Id.Items.Add(sId);  // fills comboBox with student's id in Remove panel
                Update_Id.Items.Add(sId); // fills comboBox with Student's id in update panel
            }

            con.Close();
        }

        void nullAll()
        {
            //for Add panel
            Add_ID.Text = null;
            Add_Name.Text = null;
            Add_FName.Text = null;
            Add_BirthDate.Value = DateTime.Now;
            Add_Age.Text = null;
            Add_Gender.SelectedIndex = -1;
            Add_Contact.Text = null;
            Add_Address.Text = null;
            Add_Class.Text = null;
            Add_Batch.Text = null;
            Add_MFee.Text = null;
            Add_EFee.Text = null;
            Add_Ayear.Text = null;
            Add_UserName.Text = null;
            Add_Password.Text = null;
            Add_Email.Text = null;

            //for Update panel
            Update_Id.SelectedIndex = -1;
            Update_Name.Text = null;
            Update_FName.Text = null;
            Update_BirthDate.Text = null;
            Update_Age.Text = null;
            Update_Gender.Text = null;
            Update_Contact.Text = null;
            Update_Address.Text = null;
            Update_Class.Text = null;
            Update_Batch.Text = null;
            Update_MFee.Text = null;
            Update_EFee.Text = null;
            Update_Ayear.Text = null;
            Update_UserName.Text = null;
            Update_Password.Text = null;
            Update_Email.Text = null;

            //for Remove panel
            Remove_Id.SelectedIndex = -1;
            Remove_Name.Text = null;
            Remove_FName.Text = null;
            Remove_BirthDate.Text = null;
            Remove_Age.Text = null;
            Remove_Gender.Text = null;
            Remove_Contact.Text = null;
            Remove_Address.Text = null;
            Remove_Class.Text = null;
            Remove_Batch.Text = null;
            Remove_MFee.Text = null;
            Remove_EFee.Text = null;
            Remove_Ayear.Text = null;
            Remove_UserName.Text = null;
            Remove_Password.Text = null;
            Remove_Email.Text = null;

            Remove_Id.Items.Clear();  // unfills comboBox with student's id in Remove panel
            Update_Id.Items.Clear(); // unfills comboBox with Student's id in update panel

            //for show All panel
            ShowAll_Class.SelectedIndex = -1;
            ShowAll_Batch.SelectedIndex = -1;
            GridView_ShowAll.DataSource = null;
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

        void setSidePanel(int h, int top)
        {
            // Sets up SidePanel to side of selected button
            SidePanel.Height = h;
            SidePanel.Top = top;
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

            panel_stdManagement_Add.Visible = false;
            panel_stdManagement_Update.Visible = false;
            panel_stdManagement_Remove.Visible = false;
            panel_stdManagement_ShowAll.Visible = false;
            
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            setSidePanel(btn_update.Height, btn_update.Top);

            Logged_Panel.Visible = false;
            Login_Panel.Visible = false;
            panel_stdManagement_Add.Visible = false;
            panel_stdManagement_Update.Visible = true;
            panel_stdManagement_Remove.Visible = false;
            panel_stdManagement_ShowAll.Visible = false;
           

            nullAll();
            fillCombo();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            setSidePanel(btn_add.Height, btn_add.Top);

            Logged_Panel.Visible = false;
            Login_Panel.Visible = false;
            panel_stdManagement_Add.Visible = true;
            panel_stdManagement_Update.Visible = false;
            panel_stdManagement_Remove.Visible = false;
            panel_stdManagement_ShowAll.Visible = false;
           

            nullAll();
            fillCombo();
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            setSidePanel(btn_remove.Height, btn_remove.Top);

            Logged_Panel.Visible = false;
            Login_Panel.Visible = false;
            panel_stdManagement_Add.Visible = false;
            panel_stdManagement_Update.Visible = false;
            panel_stdManagement_Remove.Visible = true;
            panel_stdManagement_ShowAll.Visible = false;
            
            nullAll();
            fillCombo();
        }

        private void btn_ViewAll_Click(object sender, EventArgs e)
        {
            setSidePanel(btn_ViewAll.Height, btn_ViewAll.Top);

            Logged_Panel.Visible = false;
            Login_Panel.Visible = false;
            panel_stdManagement_Add.Visible = false;
            panel_stdManagement_Update.Visible = false;
            panel_stdManagement_Remove.Visible = false;
            panel_stdManagement_ShowAll.Visible = true;
            

            nullAll();
            fillCombo();
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

            panel_stdManagement_Add.Visible = false;
            panel_stdManagement_Update.Visible = false;
            panel_stdManagement_Remove.Visible = false;
            panel_stdManagement_ShowAll.Visible = false;
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

        private void btn_Add_Save_Click(object sender, EventArgs e)
        {
            if(status == true)
            {
                string sql = "insert into Std_Management values(" + Add_ID.Text + " , '"+Add_Name.Text+"', '"+Add_FName.Text+"' , '"+Add_BirthDate.Text+"' , "+Add_Age.Text+" , '"+Add_Gender.Text+"' , '"+Add_Contact.Text+"' , '"+Add_Address.Text+"' , "+Add_Class.Text+" , '"+Add_Batch.Text+"' , "+Add_MFee.Text+" , "+Add_EFee.Text+" , "+Add_Ayear.Text+" , '"+Add_UserName.Text+"' , '"+Add_Password.Text+"' , '"+Add_Email.Text+"'); ";
                mySql = sql;
                SqlCommand cmd = new SqlCommand(sql, con);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Inserted");
                    con.Close();

                    Console.WriteLine("\n" + mySql+"\n");
                    mySql = null;
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error in Inserting Data");
                    Console.WriteLine("\n" + mySql + "\n");
                    mySql = null;
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void btn_ShowAllStd_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                string sql = "select * from Std_Management;";
                mySql = sql;
                
                try
                {
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridView_ShowAll.DataSource = dt;
                   
                    con.Close();

                    Console.WriteLine("\n" + mySql + "\n");
                    mySql = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in Showing Data");
                    Console.WriteLine("\n" + mySql + "\n");
                    mySql = null;
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void btn_ShowAll_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                string sql = "select * from Std_Management where Class = " + ShowAll_Class.Text + " and Batch_No = '" + ShowAll_Batch.Text + "';";
                mySql = sql;

                try
                {
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridView_ShowAll.DataSource = dt;

                    con.Close();

                    Console.WriteLine("\n" + mySql + "\n");
                    mySql = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in Showing Data");
                    Console.WriteLine("\n" + mySql + "\n");
                    mySql = null;
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void btn_remove_Search_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                //searching record in database
                try
                {
                    con.Open();
                    string sql = "select * from Std_Management where Std_Id = " + Remove_Id.Text + ";";
                    SqlCommand cmd = new SqlCommand(sql, con);

                    SqlDataReader read = cmd.ExecuteReader();

                    if (read.Read())
                    {
                        Remove_Name.Text = read.GetString(1);
                        Remove_FName.Text = read.GetString(2);
                        Remove_BirthDate.Text = read.GetValue(3).ToString().Substring(0,9);
                        Remove_Age.Text = read.GetInt32(4).ToString();
                        Remove_Gender.Text = read.GetString(5);
                        Remove_Contact.Text = read.GetString(6);
                        Remove_Address.Text = read.GetString(7);
                        Remove_Class.Text = read.GetInt32(8).ToString();
                        Remove_Batch.Text = read.GetString(9);
                        Remove_MFee.Text = read.GetInt32(10).ToString();
                        Remove_EFee.Text = read.GetInt32(11).ToString();
                        Remove_Ayear.Text = read.GetInt32(12).ToString();
                        Remove_UserName.Text = read.GetString(13);
                        Remove_Password.Text = read.GetString(14);
                        Remove_Email.Text = read.GetString(15);

                    }
                    else
                    {
                        MessageBox.Show("Error in Searching");
                    }

                    con.Close();
                }
                catch (Exception ex4)
                {
                    MessageBox.Show("Error in Searching");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void btn_RemoveStd_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                //removing record from database
                try
                {

                    con.Open();
                    string sql = "delete from Std_Management where Std_Id = " + Remove_Id.Text + "; ";

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

        private void btn_id_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                //searching record in database
                try
                {
                    con.Open();
                    string sql = "select * from Std_Management where Std_Id = " + Update_Id.Text + ";";
                    
                    SqlCommand cmd = new SqlCommand(sql, con);
                   
                    SqlDataReader read = cmd.ExecuteReader();
                    
                    if (read.Read())
                    {
                        Update_Name.Text = read.GetString(1);
                        Update_FName.Text = read.GetString(2);
                        Update_BirthDate.Text = read.GetValue(3).ToString().Substring(0, 9);
                        Update_Age.Text = read.GetInt32(4).ToString();
                        Update_Gender.Text = read.GetString(5);
                        Update_Contact.Text = read.GetString(6);
                        Update_Address.Text = read.GetString(7);
                        Update_Class.Text = read.GetInt32(8).ToString();
                        Update_Batch.Text = read.GetString(9);
                        Update_MFee.Text = read.GetInt32(10).ToString();
                        Update_EFee.Text = read.GetInt32(11).ToString();
                        Update_Ayear.Text = read.GetInt32(12).ToString();
                        Update_UserName.Text = read.GetString(13);
                        Update_Password.Text = read.GetString(14);
                        Update_Email.Text = read.GetString(15);
                        }
                    else
                    {
                        MessageBox.Show("Error in Searching");
                    }

                    con.Close();
                }
                catch (Exception ex4)
                {
                    MessageBox.Show("Error in Searching");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void btn_UpdateStd_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                //updating the searched record here
                try
                {

                    con.Open();
                    string sql = "Update Std_Management set name = '" + Update_Name.Text + "' , F_Name = '" + Update_FName.Text + "' , BirthDate = '" + Update_BirthDate.Text + "' , Age = " + Update_Age.Text + " , Gender = '" + Update_Gender.Text + "' , H_Contact = '" + Update_Contact.Text + "' , H_Address = '" + Update_Address.Text + "' , Class = " + Update_Class.Text + " , Batch_No = '" + Update_Batch.Text + "' , Monthly_Fee = " + Update_MFee.Text + "  , Exam_Fee = " + Update_EFee.Text + " , Admit_Year =  " + Update_Ayear.Text + " , userName = '" + Update_UserName.Text + "' , pass = '" + Update_Password.Text + "' , Email = '" + Update_Email.Text + "' where Std_Id = " + Update_Id.Text + " ;";
                    mySql = sql;
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Data Updated successfully");
                    Console.WriteLine("\n"+mySql+"\n");
                    mySql = null;
                }
                catch (Exception ex2)
                {
                    MessageBox.Show("Error in updating values in database");
                    con.Close();
                    Console.WriteLine("\n" + mySql + "\n");
                    mySql = null;
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            nullAll();
            fillCombo();
        }

        private void Add_ID_TextChanged(object sender, EventArgs e)
        {
            Add_ID.Text = Main_Form.numCheck(Add_ID.Text);
        }

        private void Add_Contact_TextChanged(object sender, EventArgs e)
        {
            Add_Contact.Text = Main_Form.numCheck(Add_Contact.Text);
        }

        private void Add_Age_TextChanged(object sender, EventArgs e)
        {
            Add_Age.Text = Main_Form.numCheck(Add_Age.Text);
        }

        private void Add_MFee_TextChanged(object sender, EventArgs e)
        {
            Add_MFee.Text = Main_Form.numCheck(Add_MFee.Text);
        }

        private void Add_EFee_TextChanged(object sender, EventArgs e)
        {
            Add_EFee.Text = Main_Form.numCheck(Add_EFee.Text);
        }

        private void Add_Ayear_TextChanged(object sender, EventArgs e)
        {
            Add_Ayear.Text = Main_Form.numCheck(Add_Ayear.Text);
        }

        private void Update_Age_TextChanged(object sender, EventArgs e)
        {
            Update_Age.Text = Main_Form.numCheck(Update_Age.Text);
        }

        private void Update_Contact_TextChanged(object sender, EventArgs e)
        {
            Update_Contact.Text = Main_Form.numCheck(Update_Contact.Text);
        }

        private void Update_MFee_TextChanged(object sender, EventArgs e)
        {
            Update_MFee.Text = Main_Form.numCheck(Update_MFee.Text);
        }

        private void Update_EFee_TextChanged(object sender, EventArgs e)
        {
            Update_EFee.Text = Main_Form.numCheck(Update_EFee.Text);
        }

        private void Update_Ayear_TextChanged(object sender, EventArgs e)
        {
            Update_Ayear.Text = Main_Form.numCheck(Update_Ayear.Text);
        }



        
        
    }
}
