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
    public partial class forgotPassword : Form
    {
        public forgotPassword()
        {
            InitializeComponent();
        }

        //connecting with database
        SqlConnection con = new SqlConnection(Main_Form.SqlConnectString());
        //end of connecting with database

        string mytable = "";
        string myId = "";
        string myName = "";
        string myContact = "";

        private void FP_id_OnValueChanged(object sender, EventArgs e)
        {
            FP_id.Text = Main_Form.numCheck(FP_id.Text);
        }

        private void FP_Contact_OnValueChanged(object sender, EventArgs e)
        {
            FP_Contact.Text = Main_Form.numCheck(FP_Contact.Text);
        }

        private void FP_Table_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (FP_Table.Text)
            {
                case "Admin":
                    mytable = "tab_Admin";
                    myId = "Emp_Id";
                    myName = "Emp_Name";
                    myContact = "contact";
                    break;
                case "Staff":
                    mytable = "Staff_Management";
                    myId = "Emp_Id";
                    myName = "Emp_Name";
                    myContact = "contact";
                    break;
                case "Student":
                    mytable = "Std_Management";
                    myId = "Std_Id";
                    myName = "name";
                    myContact = "H_Contact";
                    break;
                default:
                    mytable = "";
                    myId = "";
                    myName = "";
                    myContact = "";
                    break;
            }
        }

        private void btn_FP_Submit_Click(object sender, EventArgs e)
        {
            string sql = "select userName , pass from "+mytable+" where "+myId+" = "+FP_id.Text+" and "+myName+" = '"+FP_name.Text+"' and "+myContact+" like '%"+FP_Contact.Text+"%';";
            Console.WriteLine("\n"+sql);
            SqlCommand cmd = new SqlCommand(sql,con);
            SqlDataReader read;

            con.Open();
            try
            {
                read = cmd.ExecuteReader();

                if(read.Read())
                {
                    msg.Text = "Record Found";
                    panel1.BackColor = Color.LawnGreen;

                    FP_UserName.Text = read.GetString(0);
                    FP_Password.Text = read.GetString(1);
                }
                else
                {
                    msg.Text = "Record Not Foound Please Contact Admin";
                    panel1.BackColor = Color.DarkRed;

                    FP_UserName.Text = "";
                    FP_Password.Text = "";
                }
            }
            catch(Exception ex)
            {
                msg.Text = "Please Fill All Input Fields";
                panel1.BackColor = Color.DarkRed;
            }
            con.Close();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Exit_Hover(object sender, EventArgs e)
        {
            this.Exit.BackColor = Color.AntiqueWhite;
        }

        private void Exit_MouseLeave(object sender, EventArgs e)
        {
            this.Exit.BackColor = Color.Transparent;
        }
    }
}
