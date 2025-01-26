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
                // Get CourseID from the query string
                int courseID = Convert.ToInt32(Request.QueryString["CourseID"]);

                // Set the initial QuestionID and CourseID
                ViewState["CurrentQuestionID"] = 1; // Start with the first question
                ViewState["CourseID"] = courseID;

                // Load the first question for the given CourseID
                LoadQuestion(1, courseID);
            }
        }

        private void LoadQuestion(int questionID, int courseID)
        {
            // Define your connection string
            string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;

            // SQL Query to fetch a question by QuestionID and CourseID
            string query = "SELECT * FROM Questions WHERE QuestionID = @QuestionID AND CourseID = @CourseID";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@QuestionID", questionID);
                cmd.Parameters.AddWithValue("@CourseID", courseID);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        questionTitle.Text = "Question " + reader["QuestionID"].ToString();
                        questionText.Text = reader["QuestionText"].ToString();
                        option1Label.Text = reader["Option1"].ToString();
                        option2Label.Text = reader["Option2"].ToString();
                        option3Label.Text = reader["Option3"].ToString();
                        option4Label.Text = reader["Option4"].ToString();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error: {ex.Message}')</script>");
                }
            }
        }

        private int GetTotalQuestions()
        {
            int totalQuestions = 0;

            // Define your connection string
            string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;

            string query = "SELECT COUNT(*) FROM Questions WHERE CourseID = @CourseID";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@CourseID", Convert.ToInt32(ViewState["CourseID"]));

                try
                {
                    con.Open();
                    totalQuestions = (int)cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    // Log error or show a user-friendly message
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

            // Hide "Next" button and show "Submit" button if it's the last question
            nextButton.Visible = currentQuestionID < totalQuestions;
            submitButton.Visible = currentQuestionID == totalQuestions;
        }

        protected void NextButton_Click(object sender, EventArgs e)
        {
            // Get the selected answer from the form
            string selectedAnswer = Request.Form["answer"];

            // Save the selected answer
            SaveAnswer(Convert.ToInt32(ViewState["CurrentQuestionID"]), selectedAnswer);

            // Proceed to the next question
            int currentQuestionID = Convert.ToInt32(ViewState["CurrentQuestionID"]);
            int nextQuestionID = currentQuestionID + 1;

            int courseID = Convert.ToInt32(ViewState["CourseID"]);
            ViewState["CurrentQuestionID"] = nextQuestionID;

            // Load the next question
            LoadQuestion(nextQuestionID, courseID);
        }

        protected void PreviousButton_Click(object sender, EventArgs e)
        {
            int currentQuestionID = Convert.ToInt32(ViewState["CurrentQuestionID"]);
            int previousQuestionID = currentQuestionID > 1 ? currentQuestionID - 1 : 1;

            int courseID = Convert.ToInt32(ViewState["CourseID"]);

            ViewState["CurrentQuestionID"] = previousQuestionID;
            UpdateButtonVisibility();
            LoadQuestion(previousQuestionID, courseID); // Load the previous question for the course
        }

        private void SaveAnswer(int questionID, string selectedAnswer)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;

            string query = @"
        IF EXISTS (SELECT * FROM UserAnswers WHERE UserID = @UserID AND QuestionID = @QuestionID)
            UPDATE UserAnswers SET SelectedAnswer = @SelectedAnswer WHERE UserID = @UserID AND QuestionID = @QuestionID
        ELSE
            INSERT INTO UserAnswers (UserID, QuestionID, SelectedAnswer) VALUES (@UserID, @QuestionID, @SelectedAnswer)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserID", Session["UserID"]); // Assuming the user is logged in
                cmd.Parameters.AddWithValue("@QuestionID", questionID);
                cmd.Parameters.AddWithValue("@SelectedAnswer", selectedAnswer);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log error or show message
                    Response.Write($"<script>alert('Error saving answer: {ex.Message}')</script>");
                }
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            // Get the selected answer for the last question
            string selectedAnswer = Request.Form["answer"];
            int currentQuestionID = Convert.ToInt32(ViewState["CurrentQuestionID"]);
            int courseID = Convert.ToInt32(ViewState["CourseID"]);

            // Save the last answer
            SaveAnswer(currentQuestionID, selectedAnswer);

            // Redirect to a results or completion page
            Response.Redirect("Result.aspx?CourseID=" + courseID);
        }


    }
}
