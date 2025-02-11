using System;
using System.Data.SqlClient;
using System.Configuration;

namespace BrainBuilder
{
    public partial class software_development : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
                return;
            }

            int userID = Convert.ToInt32(Session["UserID"]);
            int courseID = 1;

            if (HasUserAlreadyTakenExam(userID, courseID))
            {
                Response.Redirect("~/ExamAlreadyTaken.aspx");
            }
        }

        private bool HasUserAlreadyTakenExam(int userID, int courseID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;
            string query = "SELECT COUNT(*) FROM UserSubmissions WHERE UserID = @UserID AND CourseID = @CourseID";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@CourseID", courseID);

                try
                {
                    con.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // If count > 0, user has already taken the exam
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error: {ex.Message}')</script>");
                    return false;
                }
            }
        }
    }
}
