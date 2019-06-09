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
    public partial class Teacher : Form
    {
        public Teacher()
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

        void fillCombo()
        {
            // fills up every combo that needs to be auto filled

            string sql = "select * from Std_Management;";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader read;

            con.Open();

            read = cmd.ExecuteReader();
            while (read.Read())
            {
                string sId = read.GetInt32(0).ToString();
                //Rcard_Test_SelectId.Items.Add(sId);  // fills comboBox with student's id in Test Rcard panel
                Rcard_Exam_SelectId.Items.Add(sId); // fills comboBox with student's id in Exam Rcard panel
            }

            con.Close();

           
            //for test Rcard panel
            try
            {
                string sql1 = "select * from Assign_Class where Emp_Id = " + id.ToString() + ";";
                SqlCommand cmd1 = new SqlCommand(sql1, con);
                SqlDataReader read1;

                con.Open();

                read1 = cmd1.ExecuteReader();

                while (read1.Read())
                {
                    string sub = read1.GetString(2);
                    if (Rcard_Test_Sub.Items.Contains(sub))
                    {
                        Console.WriteLine("\n\nid = " + id + " contains Subject = " + sub + " in Assign Class Table");
                    }
                    else
                    {
                        Rcard_Test_Sub.Items.Add(sub);  // fills comboBox with teacher's subject
                    }
                }

                con.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("\n\nemp id is empty");
            }
        }

        void nullAll()
        {
            //for Test Rcard panel
            Rcard_Test_Class.SelectedIndex = -1;
            Rcard_Test_BatchNo.SelectedIndex = -1;
            Rcard_Test_SelectId.SelectedIndex = -1;
            Rcard_Test_SelectId.Items.Clear();  // Empty comboBox of student's id in test panel 
            Rcard_Test_Month.SelectedIndex = -1;
            Rcard_Test_Sub.Items.Clear();
            Rcard_Test_Tcode.Text = null;
            Rcard_Test_Tmarks.Text = null;
            Rcard_Test_Omarks.Text = null;
            Rcard_Test_Remarks.Text = null;
            Rcard_Test_Percent.Text = null;
            Remarks.SelectedIndex = -1;

            //for Exam Rcard Panel
            Rcard_Exam_Class.SelectedIndex = -1;
            Rcard_Exam_Batch.SelectedIndex = -1;
            Rcard_Exam_SelectId.Items.Clear();
            Rcard_Exam_StdName.Text = null;
            Rcard_Exam_Table.SelectedIndex = -1;
            Eng.Text = null;
            Urdu.Text = null;
            Math.Text = null;
            Sci.Text = null;
            sst.Text = null;
            Arts.Text = null;
            Com.Text = null;
            Isl.Text = null;
            Rcard_Exam_OTotal.Text = null;
            Rcard_Exam_Total.Text = null;
            Rcard_Exam_Percent.Text = null;
            Rcard_Exam_Grade.Text = null;
            Rcard_Exam_Remarks.Text = null;

            //for show all panel
            panel_Delete.Visible = false;
            GridView_Rcard_ShowAll.DataSource = null;


            //for delete Recoerd Panel
            StdId.Text = null;
            TestId.Text = null;

            Rcard_ShowAll_SelectClass.SelectedIndex = -1;
            Rcard_ShowAll_SelectBatch.SelectedIndex = -1;
            Rcard_ShowAll_SelectTable.SelectedIndex = -1;
           
        }

        string userNAme, password;
        string id, name, fname, contact, cnic, birthdate, address, gender, email, designation, depart, departid, pay;
        Boolean status = false;

        private void Exit_Hover(object sender, EventArgs e)
        {
            this.Exit.BackColor = Color.Gray;
        }

        private void Exit_MouseLeave(object sender, EventArgs e)
        {
            this.Exit.BackColor = Color.Transparent;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
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
            
            panel_Rcard.Visible = false;
            panel_Aclasses.Visible = false;

            nullAll();
        }

        private void btn_Rcard_Click(object sender, EventArgs e)
        {
            setSidePanel(btn_Rcard.Height, btn_Rcard.Top);

            Logged_Panel.Visible = false;
            Login_Panel.Visible = false;
            panel_Rcard.Visible = true;
            panel_Aclasses.Visible = false;

            nullAll();
            fillCombo();
        }

        

        private void btn_Aclasses_Click(object sender, EventArgs e)
        {
            setSidePanel(btn_Aclasses.Height, btn_Aclasses.Top);

            Logged_Panel.Visible = false;
            Login_Panel.Visible = false;
            panel_Rcard.Visible = false;
            panel_Aclasses.Visible = true;
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

            panel_Rcard.Visible = false;
            panel_Aclasses.Visible = false;
        }

        private void Rcard_Test_SelectId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (status == true)
            {
                try
                {
                    string sql = "select * from Std_Management where Std_Id = " + Rcard_Test_SelectId.Text + ";";
                    
                    SqlCommand cmd = new SqlCommand(sql, con);
                    
                    con.Open();
                    SqlDataReader read = cmd.ExecuteReader();

                    if (read.Read())
                    {
                        Rcard_Test_Name.Text = read.GetString(1);
                        con.Close();
                        Rcard_Test_Tcode_TextChanged(Rcard_Test_Tcode, EventArgs.Empty);
                    }
                    else
                    {
                        Rcard_Test_Name.Text = null ;
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    Rcard_Test_Name.Text = "not a valid id";
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Log in First");
            }
        }

        private void button_Teacher_Test_Click(object sender, EventArgs e)
        {
            panel_Teacher_Rcard_Exam.Visible = false;
            panel_Teacher_Rcard_Test.Visible = true;
            panel_Teacher_Rcard_ShowAll.Visible = false;

            nullAll();
            fillCombo();
        }

        private void button_Teacher_Exam_Click(object sender, EventArgs e)
        {
            panel_Teacher_Rcard_Exam.Visible = true;
            panel_Teacher_Rcard_Test.Visible = false;
            panel_Teacher_Rcard_ShowAll.Visible = false;

            nullAll();
            fillCombo();
        }

        private void button_Teacher_ShowAll_Click(object sender, EventArgs e)
        {
            panel_Teacher_Rcard_ShowAll.Visible = true;
            panel_Teacher_Rcard_Exam.Visible = false;
            panel_Teacher_Rcard_Test.Visible = false;

            nullAll();
        }

        private void Rcard_Test_Tcode_TextChanged(object sender, EventArgs e)
        {
            if (status == true)
            {
                if (Rcard_Test_Tcode.Text.Length != 0)
                {
                    Rcard_Test_Tcode.Text = Main_Form.numCheck(Rcard_Test_Tcode.Text);

                    try
                    {
                        string sql = "select * from Test_Rcard where Test_Id = " + Rcard_Test_Tcode.Text + " and Std_Id= " + Rcard_Test_SelectId.Text + " and Sub = '" + Rcard_Test_Sub.Text + "' ;";
                        SqlCommand cmd = new SqlCommand(sql, con);
                        con.Open();
                        SqlDataReader read = cmd.ExecuteReader();

                        if (read.Read())
                        {
                            label6.Visible = true;
                            btn_Rcard_Update.Visible = true;
                            btn_Rcard_TSave.Visible = false;
                            con.Close();
                        }
                        else
                        {
                            label6.Visible = false;
                            btn_Rcard_Update.Visible = false;
                            btn_Rcard_TSave.Visible = true;
                            con.Close();
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Error in loading previous test code");
                    }
                    
                }
                
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        

        private void btn_Rcard_Percent_Click(object sender, EventArgs e)
        {

        }

        private void Rcard_Test_Percent_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button_Teacher_ActiveClasses_Submit_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                if (comboBox_Teacher_ActiveClasses_SelectClass.SelectedIndex != 0)
                {
                    try
                    {
                        con.Open();
                        string sql = "select * from Assign_Class where Class = " + comboBox_Teacher_ActiveClasses_SelectClass.Text + " and Emp_Id = "+ id.ToString() +";";

                        SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView_Teacher_AClasses.DataSource = dt;

                        con.Close();
                    }
                    catch (Exception ex11)
                    {
                        MessageBox.Show("Error cant find result");
                        con.Close();
                    }
                }
                else if (comboBox_Teacher_ActiveClasses_SelectClass.SelectedIndex == 0)
                {
                    dataGridView_Teacher_AClasses.DataSource = null;
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void button_Teacher_ActiveClasses_ShowAllClasses_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                try
                {
                    con.Open();
                    string sql = "select * from Assign_Class where Emp_Id = "+ id.ToString() +";";

                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView_Teacher_AClasses.DataSource = dt;

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

        private void btn_show_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                try
                {
                    con.Open();
                    string sql = "select * from " + Rcard_ShowAll_SelectTable.Text + " where Class = " + Rcard_ShowAll_SelectClass.Text + " and Batch_No = '" + Rcard_ShowAll_SelectBatch.Text + "';";
                    
                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridView_Rcard_ShowAll.DataSource = dt;

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

        private void ShowAll_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (status == true)
            {
                if (ShowAll.SelectedIndex != 0)
                {
                    if(ShowAll.Text == "Exam_Rcard")
                    {
                        btn_showLess.Visible = false;
                        btn_showLess2.Visible = true;
                    }
                    else
                    {
                        btn_showLess.Visible = false;
                        btn_showLess2.Visible = false;
                    }
                    try
                    {
                        con.Open();
                        string sql = "select * from " + ShowAll.Text + ";";
                        
                        SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        GridView_Rcard_ShowAll.DataSource = dt;

                        con.Close();
                    }
                    catch (Exception ex12)
                    {
                        MessageBox.Show("Error cant find result");
                        con.Close();
                    }
                }
                else if (ShowAll.SelectedIndex == 0)
                {
                    GridView_Rcard_ShowAll.DataSource = null;
                }

            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }
        double total, obt, percent;//creates variables to use to calculate percentage
        private void Rcard_Test_Omarks_TextChanged(object sender, EventArgs e)
        {
            Rcard_Test_Omarks.Text = Main_Form.numCheck(Rcard_Test_Omarks.Text);
            if (Rcard_Test_Omarks.TextLength != 0 && Rcard_Test_Omarks.Text != ".")
            {
                try
                {
                    total = double.Parse(Rcard_Test_Tmarks.Text);
                    obt = double.Parse(Rcard_Test_Omarks.Text);
                    percent = (obt / total) * 100.00;
                    Rcard_Test_Percent.Text = percent.ToString();
                }
                catch(Exception ex)
                {
                    Console.WriteLine("\n error in calculating percentage from obtained marks field");
                }
                
            }
            else
            {
                Rcard_Test_Percent.Text = null;
            }
        }

        private void Rcard_Test_Tmarks_TextChanged(object sender, EventArgs e)
        {
            Rcard_Test_Tmarks.Text = Main_Form.numCheck(Rcard_Test_Tmarks.Text);
            total = 0.0;
        }
        string sql1;
        private void btn_Rcard_TSave_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                Remarks_SelectedIndexChanged(Remarks, EventArgs.Empty);

                //saving test record in database
                try
                {
                    con.Open();

                    string sql = "insert into Test_Rcard values(" + Rcard_Test_SelectId.Text + ",'" + Rcard_Test_Name.Text + "' , " + Rcard_Test_Class.Text + " ,'" + Rcard_Test_BatchNo.Text + "' ,  '" + Rcard_Test_Month.Text + "' , '" + Rcard_Test_Sub.Text + "', " + Rcard_Test_Tcode.Text + " , " + Rcard_Test_Tmarks.Text + " , " + Rcard_Test_Omarks.Text + " , " + Rcard_Test_Percent.Text.Substring(0, 2) + ", '" + Rcard_Test_Remarks.Text + "' , '"+name+"' , "+id+"); ";
                    sql1 = sql;
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Saved");
                    nullAll();

                }
                catch (Exception ex4)
                {
                    MessageBox.Show("Error Can't insert record");
                    MessageBox.Show(sql1);
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        

        private void Remarks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Remarks.SelectedIndex != 0)
            {
                Rcard_Test_Remarks.Text = Remarks.Text;
            }
            else if(Remarks.SelectedIndex == 0)
            {
                Rcard_Test_Remarks.Text = "Not Given";
            }
        }

        private void btn_Rcard_Update_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                Remarks_SelectedIndexChanged(Remarks, EventArgs.Empty);

                //updating test record in database
                try
                {
                    con.Open();

                    string sql = "update Test_Rcard set Total = " + Rcard_Test_Tmarks.Text + " , Obtained = " + Rcard_Test_Omarks.Text + " , Percentage = " + Rcard_Test_Percent.Text.Substring(0, 2) + " , Remarks = '" + Rcard_Test_Remarks.Text + "' , Teacher = '" + name + "' , Emp_Id = " + id + " where Test_Id = " + Rcard_Test_Tcode.Text + " ;";
                    sql1 = sql;
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Updated");

                    btn_Rcard_TSave.Visible = true;
                    btn_Rcard_Update.Visible = false;
                    label6.Visible = false;

                    nullAll();

                }
                catch (Exception ex4)
                {
                    MessageBox.Show("Error Can't update record");
                    MessageBox.Show(sql1);
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void Rcard_Test_Sub_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rcard_Test_Tcode_TextChanged(Rcard_Test_Tcode, EventArgs.Empty);
        }

        private void Rcard_Exam_SelectId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (status == true)
            {
                try
                {
                    string sql = "select * from Std_Management where Std_Id = " + Rcard_Exam_SelectId.Text + ";";

                    SqlCommand cmd = new SqlCommand(sql, con);

                    con.Open();
                    SqlDataReader read = cmd.ExecuteReader();

                    if (read.Read())
                    {
                        Rcard_Exam_StdName.Text = read.GetString(1);
                        con.Close();
                    }
                    else
                    {
                        Rcard_Exam_StdName.Text = "";
                        con.Close();
                    }
                }
                catch (Exception ex)
                {
                    Rcard_Exam_StdName.Text = "";
                    con.Close();
                }

            }
            else
            {
                MessageBox.Show("You Must Log in First");
            }
        }

        private void btn_Exam_Done_Click(object sender, EventArgs e)
        {
            try
            {
                //taking input in subject variables from textboxxes in exam panel
                double eng, urdu, math, sci, st, arts, comp, isl;
                eng = double.Parse(Eng.Text);
                urdu = double.Parse(Urdu.Text);
                math = double.Parse(Math.Text);
                sci = double.Parse(Sci.Text);
                st = double.Parse(sst.Text);
                arts = double.Parse(Arts.Text);
                comp = double.Parse(Com.Text);
                isl = double.Parse(Isl.Text);

                //showing obtained total
                double obt = eng + urdu + math + sci + st + arts + comp + isl;
                Rcard_Exam_OTotal.Text = obt.ToString();

                //showing total marks
                double total = 800.0;
                Rcard_Exam_Total.Text = total.ToString();

                //shoiwng percantage
                double percent = (obt / total) * 100.0;
                Rcard_Exam_Percent.Text = percent.ToString();

                //showing Grade and Remarks
                string grade = "F";
                string remarks = "Poor";
                if (percent >= 60.0 && percent < 70.0)
                {
                    grade = "B";
                    remarks = "Fair";
                }
                else if (percent >= 70.0 && percent < 80.0)
                {
                    grade = "A";
                    remarks = "Good";
                }
                else if (percent >= 80.0 && percent < 100.0)
                {
                    grade = "A+";
                    remarks = "Excellent";
                }
                Rcard_Exam_Grade.Text = grade.ToString();
                Rcard_Exam_Remarks.Text = remarks;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please Provide Appropriate Input in Text Fields");
            }
        }
        
        private void Btn_Exam_Submit_Click(object sender, EventArgs e)
        {
            if(status == true)
            {
                try
                {
                    string sql = "insert into Exam_Rcard values(" + Rcard_Exam_SelectId.Text + " , '" + Rcard_Exam_StdName.Text + "' , " + Rcard_Exam_Class.Text + ", '" + Rcard_Exam_Batch.Text + "', '" + Rcard_Exam_Table.Text + "', " + Eng.Text + ", " + Urdu.Text + ", " + Math.Text + ", " + Sci.Text + ", " + sst.Text + ", " + Arts.Text + ", " + Com.Text + ", " + Isl.Text + ", " + Rcard_Exam_Total.Text + ", " + Rcard_Exam_OTotal.Text + ", " + Rcard_Exam_Percent.Text.Substring(0, 2) + ", '" + Rcard_Exam_Grade.Text + "', '" + Rcard_Exam_Remarks.Text + "', '" + name + "', " + id.ToString() + ");";
                    
                    SqlCommand cmd = new SqlCommand(sql,con);
                   
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Inserted");
                       
                }catch(Exception ex)
                {   
                    MessageBox.Show("Cant insert record in database");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void btn_showLess_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                try
                {
                    con.Open();
                    string sql = "select Std_Id, Name, Class, Batch_No, Exam, Total, Obtained, Percentage, Grade, Remarks, Teacher, Emp_Id  from  Exam_Rcard where Class = " + Rcard_ShowAll_SelectClass.Text + " and Batch_No = '" + Rcard_ShowAll_SelectBatch.Text + "';";

                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridView_Rcard_ShowAll.DataSource = dt;

                    con.Close();
                }
                catch (Exception ex12)
                {
                    Console.WriteLine("please select class and batch first");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void Rcard_ShowAll_SelectTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Rcard_ShowAll_SelectTable.Text == "Exam_Rcard")
            {
                btn_showLess.Visible = true;
                btn_showLess2.Visible = false;
            }
            else
            {
                btn_showLess.Visible = false;
                btn_showLess2.Visible = false;
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            panel_Delete.Visible = true;
            btn_Delete.Visible = false;
        }

        private void btn_deleteRecord_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // user clicked yes
                    string sql = "delete from Exam_Rcard where Std_Id = " + StdId.Text + ";";
                    SqlCommand cmd = new SqlCommand(sql,con);

                    try 
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Record Deleted Successfully");

                        btn_show_Click(btn_show, EventArgs.Empty);

                        panel_Delete.Visible = false;
                        btn_Delete.Visible = true;

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error in Deleting Record");
                        con.Close();
                        panel_Delete.Visible = false;
                        btn_Delete.Visible = true;
                    }
                }
                else
                {
                    // user clicked no
                    panel_Delete.Visible = false;
                    btn_Delete.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void Eng_TextChanged(object sender, EventArgs e)
        {
            Eng.Text = Main_Form.numCheck(Eng.Text);
        }

        private void Urdu_TextChanged(object sender, EventArgs e)
        {
            Urdu.Text = Main_Form.numCheck(Urdu.Text);
        }

        private void Math_TextChanged(object sender, EventArgs e)
        {
            Math.Text = Main_Form.numCheck(Math.Text);
        }

        private void Sci_TextChanged(object sender, EventArgs e)
        {
            Sci.Text = Main_Form.numCheck(Sci.Text);
        }

        private void sst_TextChanged(object sender, EventArgs e)
        {
            sst.Text = Main_Form.numCheck(sst.Text);
        }

        private void Arts_TextChanged(object sender, EventArgs e)
        {
            Arts.Text = Main_Form.numCheck(Arts.Text);
        }

        private void Com_TextChanged(object sender, EventArgs e)
        {
            Com.Text = Main_Form.numCheck(Com.Text);
        }

        private void Isl_TextChanged(object sender, EventArgs e)
        {
            Isl.Text = Main_Form.numCheck(Isl.Text);
        }

        private void Rcard_Test_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (status == true)
            {
                Rcard_Test_BatchNo.Items.Clear(); // clears previous batch from batch comboBox in test card panel
                Rcard_Test_SelectId.Items.Clear(); //clears previous ids from std_id comboBox in test Exam card panel
                Rcard_Test_Name.Text = ""; //clears previous std name from std_name label in test Exam card panel

                try
                {
                    string sql = "select * from Std_Management where Class = " + Rcard_Test_Class.Text + ";";

                    SqlCommand cmd = new SqlCommand(sql, con);

                    con.Open();
                    SqlDataReader read = cmd.ExecuteReader();

                    while (read.Read())
                    {
                        string sBatch = read.GetString(9);
                        if (Rcard_Test_BatchNo.Items.Contains(sBatch))
                        {
                            Console.WriteLine("\n\n Class = " + Rcard_Test_Class.Text + " contains Batch = " + sBatch + " in Std_Management Table");
                        }
                        else
                        {
                            Rcard_Test_BatchNo.Items.Add(sBatch);  // fills comboBox with Batch
                        }

                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                    Rcard_Test_Name.Text = "";
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Log in First");
            }
        }

        private void Rcard_Exam_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (status == true)
            {
                Rcard_Exam_Batch.Items.Clear(); // clears previous batch from batch comboBox in Exam card panel
                Rcard_Exam_SelectId.Items.Clear(); //clears previous ids from std_id comboBox in test Exam card panel
                Rcard_Exam_StdName.Text = ""; //clears previous std name from std_name label in test Exam card panel
                
                try
                {
                    string sql = "select * from Std_Management where Class = " + Rcard_Exam_Class.Text + ";";

                    SqlCommand cmd = new SqlCommand(sql, con);

                    con.Open();
                    SqlDataReader read = cmd.ExecuteReader();

                    while (read.Read())
                    {
                        string sBatch = read.GetString(9);
                        if (Rcard_Exam_Batch.Items.Contains(sBatch))
                        {
                            Console.WriteLine("\n\n Class = " + Rcard_Exam_Class.Text + " contains Batch = " + sBatch + " in Std_Management Table");
                        }
                        else
                        {
                            Rcard_Exam_Batch.Items.Add(sBatch);  // fills comboBox with Batch
                        }

                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                    Rcard_Test_Name.Text = "";
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Log in First");
            }
        }

        private void Rcard_Exam_Batch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (status == true)
            {
                Rcard_Exam_SelectId.Items.Clear(); //clears previous ids from std_id comboBox in Exam card panel
                Rcard_Exam_StdName.Text = ""; //clears previous std name from std_name label in Exam card panel

                try
                {
                    string sql = "select * from Std_Management where Class = " + Rcard_Exam_Class.Text + " and Batch_No = '" + Rcard_Exam_Batch.Text + "' ;";

                    SqlCommand cmd = new SqlCommand(sql, con);

                    con.Open();
                    SqlDataReader read = cmd.ExecuteReader();

                    while (read.Read())
                    {
                        string sId = read.GetInt32(0).ToString();
                        Rcard_Exam_SelectId.Items.Add(sId);  // fills comboBox with std id
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Log in First");
            }
        }

        private void Rcard_Test_BatchNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (status == true)
            {
                Rcard_Test_SelectId.Items.Clear(); //clears previous ids from std_id comboBox in test card panel
                Rcard_Test_Name.Text = ""; //clears previous std name from std_name label in test card panel

                try
                {
                    string sql = "select * from Std_Management where Class = " + Rcard_Test_Class.Text + " and Batch_No = '" + Rcard_Test_BatchNo.Text + "' ;";

                    SqlCommand cmd = new SqlCommand(sql, con);

                    con.Open();
                    SqlDataReader read = cmd.ExecuteReader();

                    while (read.Read())
                    {
                        string sId = read.GetInt32(0).ToString();
                        Rcard_Test_SelectId.Items.Add(sId);  // fills comboBox with std id
                    }
                    con.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Log in First");
            }
        }

        private void Rcard_Exam_Table_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (status == true)
            {
                try
                {
                    string sql = "select * from Exam_Rcard where Std_Id = " + Rcard_Exam_SelectId.Text + " and Exam = '" + Rcard_Exam_Table.Text + "';";

                    SqlCommand cmd = new SqlCommand(sql, con);
                    SqlDataReader read;

                    con.Open();

                    read = cmd.ExecuteReader();

                    if (read.Read())
                    {
                        label15.Visible = true;
                        panel3.Enabled = false;
                        panel4.Enabled = false;
                    }
                    else
                    {
                        label15.Visible = false;
                        panel3.Enabled = true;
                        panel4.Enabled = true;
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Log in First");
            }
        }

        private void Table_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(Table.Text)
            {
                case "Exam_Rcard":
                    label49.Visible = false;
                    TestId.Visible = false;
                    btn_DeleteRecord.Visible = true;
                    btn_DeleteTest.Visible = false;
                    break;
                case "Test_Rcard":
                    label49.Visible = true;
                    TestId.Visible = true;
                    btn_DeleteRecord.Visible = false;
                    btn_DeleteTest.Visible = true;
                    break;
                default:
                    label49.Visible = false;
                    TestId.Visible = false;
                    btn_DeleteRecord.Visible = true;
                    btn_DeleteTest.Visible = false;
                    break;
            }
        }

        private void btn_deleteTest_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // user clicked yes
                    string sql = "delete from Test_Rcard where Std_Id = " + StdId.Text + " and Test_Id = " + TestId.Text + ";";
                    SqlCommand cmd = new SqlCommand(sql, con);

                    try
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Record Deleted Successfully");

                        btn_show_Click(btn_show, EventArgs.Empty);

                        panel_Delete.Visible = false;
                        btn_Delete.Visible = true;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in Deleting Record");
                        con.Close();
                        panel_Delete.Visible = false;
                        btn_Delete.Visible = true;
                    }
                }
                else
                {
                    // user clicked no
                    panel_Delete.Visible = false;
                    btn_Delete.Visible = true;
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        private void btn_showLess2_Click(object sender, EventArgs e)
        {
            if (status == true)
            {
                try
                {
                    con.Open();
                    string sql = "select Std_Id, Name, Class, Batch_No, Exam, Total, Obtained, Percentage, Grade, Remarks, Teacher, Emp_Id  from  Exam_Rcard;";

                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);

                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    GridView_Rcard_ShowAll.DataSource = dt;

                    con.Close();
                }
                catch (Exception ex12)
                {
                    Console.WriteLine("please select class and batch first");
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("You Must Login First");
            }
        }

        

        
    }
}
