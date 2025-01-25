using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Configuration;

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
                UpdateButtonVisibility();
            }
        }

        private void LoadQuestion(int questionID)
        {
            // Define your connection string
            string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;

            // SQL Query to fetch a question by QuestionID
            string query = "SELECT * FROM Questions WHERE QuestionID = @QuestionID";

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
                    // Handle exceptions
                    Response.Write($"<script>alert('Error: {ex.Message}')</script>");
                }
            }
        }

        private int GetTotalQuestions()
        {
            int totalQuestions = 0;

            // Define your connection string
            string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;

            string query = "SELECT COUNT(*) FROM Questions";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    totalQuestions = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    // Handle exceptions (e.g., log error, show message to user)
                    Response.Write($"<script>alert('Error: {ex.Message}')</script>");
                }
            }

            return totalQuestions;
        }

        private void UpdateButtonVisibility()
        {
            int currentQuestionID = Convert.ToInt32(ViewState["CurrentQuestionID"] ?? "1");
            int totalQuestions = GetTotalQuestions();

            // Hide "Previous" button if it's the first question
            previousButton.Visible = currentQuestionID > 1;

            // Hide "Next" button if it's the last question
            nextButton.Visible = currentQuestionID < totalQuestions;
        }

        protected void NextButton_Click(object sender, EventArgs e)
        {
            int currentQuestionID = Convert.ToInt32(ViewState["CurrentQuestionID"] ?? "1");
            currentQuestionID++;
            ViewState["CurrentQuestionID"] = currentQuestionID;

            LoadQuestion(currentQuestionID);
            UpdateButtonVisibility();
        }

        protected void PreviousButton_Click(object sender, EventArgs e)
        {
            int currentQuestionID = Convert.ToInt32(ViewState["CurrentQuestionID"] ?? "1");

            if (currentQuestionID > 1)
            {
                currentQuestionID--;
                ViewState["CurrentQuestionID"] = currentQuestionID;

                LoadQuestion(currentQuestionID);
            }

            UpdateButtonVisibility();
        }
    }
}
