using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace BrainBuilder.Admin
{
    public partial class DeleteQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DeleteQuestionFromDB();
            }
        }

        private void DeleteQuestionFromDB()
        {
            // Get QuestionID from URL
            string questionId = Request.QueryString["ID"];

            if (!string.IsNullOrEmpty(questionId))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Questions WHERE QuestionID = @QuestionID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@QuestionID", questionId);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                // Redirect back to question list page
                Response.Redirect("QuestionList.aspx");
            }
            else
            {
                Response.Write("<script>alert('Invalid Question ID');</script>");
            }
        }
    }
}
