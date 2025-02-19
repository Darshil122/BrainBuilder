using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace BrainBuilder.Admin
{
    public partial class EditQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadQuestionDetails();
            }
        }

        private void LoadQuestionDetails()
        {
            string questionId = Request.QueryString["ID"];
            if (string.IsNullOrEmpty(questionId))
            {
                Response.Write("<script>alert('Invalid Question ID');</script>");
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT QuestionText, Option1, Option2, Option3, Option4, CorrectOption FROM Questions WHERE QuestionID = @QuestionID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@QuestionID", questionId);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtQuestion.Text = reader["QuestionText"].ToString();
                        txtOption1.Text = reader["Option1"].ToString();
                        txtOption2.Text = reader["Option2"].ToString();
                        txtOption3.Text = reader["Option3"].ToString();
                        txtOption4.Text = reader["Option4"].ToString();
                        ddlCorrectAnswer.SelectedValue = reader["CorrectOption"].ToString();
                    }
                    conn.Close();
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string questionId = Request.QueryString["ID"];
            if (string.IsNullOrEmpty(questionId))
            {
                Response.Write("<script>alert('Invalid Question ID');</script>");
                return;
            }

            string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Questions SET QuestionText = @QuestionText, Option1 = @Option1, Option2 = @Option2, Option3 = @Option3, Option4 = @Option4, CorrectOption = @CorrectOption WHERE QuestionID = @QuestionID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@QuestionText", txtQuestion.Text);
                    cmd.Parameters.AddWithValue("@Option1", txtOption1.Text);
                    cmd.Parameters.AddWithValue("@Option2", txtOption2.Text);
                    cmd.Parameters.AddWithValue("@Option3", txtOption3.Text);
                    cmd.Parameters.AddWithValue("@Option4", txtOption4.Text);
                    cmd.Parameters.AddWithValue("@CorrectOption", ddlCorrectAnswer.SelectedValue);
                    cmd.Parameters.AddWithValue("@QuestionID", questionId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

            // Redirect back to question list page
            Response.Redirect("QuestionList.aspx");
        }
    }
}
