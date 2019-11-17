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
    public partial class Login : System.Web.UI.Page
    {
        const string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Sem 10\ATP2\AttendanceManagementSystem\db\LocalDB.mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(TextBox1.Text, out id))
            {
                ErrorLabel.Text = "Incorrect Id or Password";
            }
            else
            {
                string qr = "SELECT * FROM Faculty WHERE FacultyId= '" + TextBox1.Text + "' AND FacultyPassword = '" + TextBox2.Text + "'";

                SqlDataAdapter adapter = new SqlDataAdapter(qr, connStr);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    if (dt.Rows[0]["FacultyId"].ToString() != "3")
                    {
                        string isd = dt.Rows[0]["FacultyId"].ToString();
                        string name = dt.Rows[0]["FacultyName"].ToString();
                        Response.Redirect("/Faculty.aspx?id=" + isd + "&name=" + name);
                        

                    }
                    else
                    {
                        Response.Redirect("~/Admin.aspx");
                    }
                }
                else
                    ErrorLabel.Text = "Incorrect Id or Password";
            }
        }
    }
}