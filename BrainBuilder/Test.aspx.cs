using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace BrainBuilder
{
    public partial class Test : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["CurrentQuestionID"] = 1;
                LoadQuestion(Convert.ToInt32(ViewState["CurrentQuestionID"]));
                //LoadQuestion();
            }
        }

        private void LoadQuestion(int questionID)
        {
            // Define your connection string
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;

            // SQL Query to fetch a question (for example, the first question)
            string query = "SELECT TOP 1 * FROM Questions ORDER BY QuestionID";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@QuestionID", questionID);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Assign the question text and options to the UI
                        questionTitle.Text = "Question " + reader["QuestionID"].ToString();
                        questionText.Text = reader["QuestionText"].ToString();
                        option1Label.Text = "A. " + reader["Option1"].ToString();
                        option2Label.Text = "B. " + reader["Option2"].ToString();
                        option3Label.Text = "C. " + reader["Option3"].ToString();
                        option4Label.Text = "D. " + reader["Option4"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., log error, show message to user)
                    Response.Write($"<script>alert('Error: {ex.Message}')</script>");
                }
            }
        }
        protected void NextButton_Click(object sender, EventArgs e)
        {
            // Update ViewState/Session to track question progress
            int currentQuestionID = Convert.ToInt32(ViewState["CurrentQuestionID"] ?? "1");
            currentQuestionID++;
            ViewState["CurrentQuestionID"] = currentQuestionID;

            LoadQuestion(currentQuestionID);
        }

        //private void LoadQuestion(int questionID)
        //{
        //    // Modify the SQL query to fetch a specific question by ID
        //    string query = "SELECT * FROM Questions WHERE QuestionID = @QuestionID";
        //    // (Same implementation as above, with parameterized query for @QuestionID)
        //}

    }
}