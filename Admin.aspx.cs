using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AttendanceManagementSystem
{
    public partial class Admin : System.Web.UI.Page
    {
        const string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Sem 10\ATP2\AttendanceManagementSystem\db\LocalDB.mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = TextBox1.Text;
            double cgpa;

            if (!Double.TryParse(TextBox3.Text, out cgpa) || TextBox1.Text=="")
            {
                Label1.Text = "Input Error";
                return;
            }
            else
            {
                cgpa = Convert.ToDouble(TextBox3.Text);
                Label1.Text = "";

                string qr = "INSERT INTO STUDENTS VALUES ('"+name+"',"+cgpa+")";
                SqlDataAdapter adapter = new SqlDataAdapter(qr, connStr);
                DataTable dt1 = new DataTable();
                adapter.Fill(dt1);
                Label1.Text = "Successful";

            }

           
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string name = TextBox4.Text;
            string pass = TextBox5.Text;

            if (TextBox4.Text=="" || TextBox5.Text == "")
            {
                Label2.Text = "Input Error";
                return;
            }
            else
            {
                
                Label2.Text = "";

                string qr = "INSERT INTO Faculty VALUES ('" + name + "','" + pass + "')";
                SqlDataAdapter adapter = new SqlDataAdapter(qr, connStr);
                DataTable dt1 = new DataTable();
                adapter.Fill(dt1);
                Label2.Text = "Successful";

            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string id = TextBox6.Text;
            string cid = TextBox7.Text;
            string sid = TextBox8.Text;
            if (id == "" || cid == "" || sid == "")
            {
                Label3.Text = "Input Error";
            }
            else
            {
                string qr = "INSERT INTO StudentSectionRelation VALUES ('" + id + "','" + sid + "')";
                SqlDataAdapter adapter = new SqlDataAdapter(qr, connStr);
                DataTable dt1 = new DataTable();
                adapter.Fill(dt1);
                string qr1 = "INSERT INTO Attendence VALUES ('" + id + "','" + sid + "')";
                SqlDataAdapter adapter1 = new SqlDataAdapter(qr, connStr);
                DataTable dt2 = new DataTable();
                adapter.Fill(dt2);
                Label3.Text = "Successful";
            }
        }
    }
}