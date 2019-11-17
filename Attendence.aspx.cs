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
    public partial class Attendence : System.Web.UI.Page
    {
        const string connStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\Sem 10\ATP2\AttendanceManagementSystem\db\LocalDB.mdf;Integrated Security=True;Connect Timeout=30";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                this.LoadDb();
            }
        }

        private void LoadDb() {
            string SId = Request.QueryString["Sectionid"];
            string FId = Request.QueryString["FacultyId"];
            if (SId == null || FId == null)
            {
                Response.Redirect("/Login.aspx");
            }
            else
            {

               // string qr = "SELECT StudentSectionRelation.StudentId, Students.StudentName, Students.CGPA, Attendence.present, StudentSectionRelation.SectionId, Attendence.AttendenceCount, Attendence.Date FROM StudentSectionRelation INNER JOIN Students ON StudentSectionRelation.StudentId = Students.StudentId INNER JOIN Attendence On StudentSectionRelation.StudentId = Attendence.StudentId";
               // string qr = "SELECT StudentSectionRelation.StudentId, Students.StudentName, Students.CGPA, Attendence.present, StudentSectionRelation.SectionId, Attendence.AttendenceCount, Attendence.Date FROM Attendence INNER JOIN StudentSectionRelation on Attendence.SectionId = StudentSectionRelation.SectionId INNER JOIN Students On StudentSectionRelation.StudentID = Students.StudentId WHERE StudentSectionRelation.SectionId='" + SId + "'";
                string qr = "SELECT Students.StudentId, Students.StudentName, Students.StudentCGPA, Attendence.SectionId, Attendence.AttendenceCount, Attendence.present, Attendence.Date FROM Attendence INNER JOIN Students on Attendence.StudentId = Students.StudentId WHERE Attendence.SectionId='" + SId +"'";
                SqlDataAdapter adapter = new SqlDataAdapter(qr, connStr);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                Session["table"] = dt;
                GridView1.DataSource = dt;
                GridView1.DataBind();
                

            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "present")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                DataTable dt = new DataTable();
                dt = (DataTable)Session["table"];
                dt.Rows[index]["present"] = 1;
                Session["table"] = dt;
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (e.CommandName == "absent")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                DataTable dt = new DataTable();
                dt = (DataTable)Session["table"];
                dt.Rows[index]["present"] = 0;
                Session["table"] = dt;
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else if (e.CommandName == "drop")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                DataTable dt = new DataTable();
                dt = (DataTable)Session["table"];
                string id = dt.Rows[index]["StudentId"].ToString();
                string Secid = dt.Rows[index]["SectionId"].ToString();

                string qr = "DELETE FROM Attendence WHERE StudentId='"+id+"' and SectionId='"+Secid+"'";
                SqlDataAdapter adapter = new SqlDataAdapter(qr, connStr);
                DataTable dt1 = new DataTable();
                adapter.Fill(dt1);
                string qr2 = "DELETE FROM StudentSectionRelation WHERE StudentId='" + id + "' and SectionId='" + Secid + "'";
                SqlDataAdapter adapter1 = new SqlDataAdapter(qr2, connStr);
                DataTable dt2 = new DataTable();
                adapter.Fill(dt2);
                this.LoadDb();
            }

        }

        protected void ButtonRef_Click(object sender, EventArgs e)
        {
            this.LoadDb();
        }

        protected void ButtonLock_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = (DataTable)Session["table"];
            foreach (DataRow r in dt.Rows){
                if ((int)r["present"] == 1) {
                    int c = (int)r["AttendenceCount"];
                    c++;
                    string qr = "UPDATE Attendence SET AttendenceCount='" + c + "' , Date='" + DateTime.Now.ToString("dd.MM.yyy") + "' WHERE StudentID='" + r["StudentId"].ToString() + "' and SectionId='" + r["SectionId"].ToString() + "'";
                    SqlDataAdapter adapter = new SqlDataAdapter(qr, connStr);
                    DataTable da = new DataTable();
                    adapter.Fill(da);

                }
            }
        }

        protected void ButtonLogOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Login.aspx");
        }






    }
}