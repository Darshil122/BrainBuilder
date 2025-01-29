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
            // Clear previous selection
            answerOptions.ClearSelection();

            string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;
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
                        questionTitle.Text = "Question " + reader["QuestionID"].ToString();
                        questionText.Text = reader["QuestionText"].ToString();
                        answerOptions.Items[0].Text = "A. " + reader["Option1"].ToString();
                        answerOptions.Items[1].Text = "B. " + reader["Option2"].ToString();
                        answerOptions.Items[2].Text = "C. " + reader["Option3"].ToString();
                        answerOptions.Items[3].Text = "D. " + reader["Option4"].ToString();
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
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;

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
            //submitButton.Visible = true;
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

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            int currentQuestionID = Convert.ToInt32(ViewState["CurrentQuestionID"] ?? "1");
            string selectedAnswer = answerOptions.SelectedValue;

            if (!string.IsNullOrEmpty(selectedAnswer))
            {
                SaveAnswer(currentQuestionID, selectedAnswer);
                Response.Write("<script>alert('Answer submitted successfully!')</script>");
            }
            else
            {
                Response.Write("<script>alert('Please select an answer!')</script>");
            }
        }

        private void SaveAnswer(int questionID, string selectedAnswer)
        {
            // Fetch UserID from session
            if (Session["UserID"] == null)
            {
                //Response.Write("<script>alert('User not logged in.')</script>");
                Response.Redirect("~/Account/Login.aspx");
                //return;
            }

            int userID = Convert.ToInt32(Session["UserID"]);

            string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;
            string query = "INSERT INTO UserSubmissions (UserID, QuestionID, SelectedOption) VALUES (@UserID, @QuestionID, @SelectedAnswer)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserID", userID); // Add UserID parameter
                cmd.Parameters.AddWithValue("@QuestionID", questionID);
                cmd.Parameters.AddWithValue("@SelectedAnswer", selectedAnswer);

                try
                {
                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Response.Write("<script>alert('Answer saved successfully!')</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('Failed to save answer.')</script>");
                    }
                }
                catch (Exception ex)
                {
                    // Log the error and display a user-friendly message
                    Response.Write($"<script>alert('Error: {ex.Message}')</script>");
                    // Log the exception for debugging
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }
}
