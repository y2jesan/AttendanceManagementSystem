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
    public partial class Faculty : System.Web.UI.Page
    {
        const string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Sem 10\ATP2\AttendanceManagementSystem\db\LocalDB.mdf;Integrated Security=True;Connect Timeout=30";
        string s;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                s = Request.QueryString["id"];
                string name = Request.QueryString["name"];
                if (s == null || name == null)
                {
                    Response.Redirect("/Login.aspx");
                }
                else
                {
                    WelcomeLabel.Text = "Welcome " + name;
                    string qr = "SELECT Sections.CourseId, Courses.CourseName, FacultySectionRelation.SectionId, Sections.SectionName FROM FacultySectionRelation INNER JOIN Sections ON FacultySectionRelation.SectionID = Sections.SectionID INNER JOIN Courses ON Courses.CourseId= Sections.CourseId WHERE FacultySectionRelation.FacultyId='" + s + "'";

                    SqlDataAdapter adapter = new SqlDataAdapter(qr, connStr);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                }
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShowList") {
                int index = Convert.ToInt32(e.CommandArgument);
                string id = GridView1.Rows[index].Cells[3].Text;

                Response.Write("<script>alert('"+id+"');</script>");
                Response.Redirect("/Attendence.aspx?Sectionid=" + id + "&FacultyId=" + s);
            }
        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Login.aspx");
        }
    }
}