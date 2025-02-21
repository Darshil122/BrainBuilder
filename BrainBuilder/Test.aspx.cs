using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Configuration;
using System.Data;

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

            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
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
                    Response.Write($"<script>alert('Error: {ex.Message}')</script>");
                }
            }

            return totalQuestions;
        }

        private void UpdateButtonVisibility()
        {
            int currentQuestionID = Convert.ToInt32(ViewState["CurrentQuestionID"] ?? "1");
            int totalQuestions = GetTotalQuestions();

            nextButton.Visible = currentQuestionID < totalQuestions;

            finishButton.Visible = currentQuestionID == totalQuestions;

            submitButton.Visible = true;
        }

        protected void NextButton_Click(object sender, EventArgs e)
        {
            int currentQuestionID = Convert.ToInt32(ViewState["CurrentQuestionID"] ?? "1");
            currentQuestionID++;
            ViewState["CurrentQuestionID"] = currentQuestionID;

            LoadQuestion(currentQuestionID);
            UpdateButtonVisibility();
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            int currentQuestionID = Convert.ToInt32(ViewState["CurrentQuestionID"] ?? "1");
            string selectedAnswer = answerOptions.SelectedValue;

            if (!string.IsNullOrEmpty(selectedAnswer))
            {
                SaveAnswer(currentQuestionID, selectedAnswer);
            }
            else
            {
                // Show Bootstrap alert
                Response.Write("<script>alert('Failed to save answer.')</script>");

            }
        }

        private void SaveAnswer(int questionID, string selectedAnswer)
        {
            // Fetch UserID from session
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
                return;
            }

            int userID = Convert.ToInt32(Session["UserID"]);

            // Fetch CourseID from query string
            if (string.IsNullOrEmpty(Request.QueryString["CourseID"]))
            {
                Response.Write("<script>alert('CourseID is missing in the query string.')</script>");
                return;
            }

            int courseID = Convert.ToInt32(Request.QueryString["CourseID"]);
            Session["courseID"] = courseID;

            string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;
            string query = "INSERT INTO UserSubmissions (UserID, CourseID, QuestionID, SelectedOption) VALUES (@UserID, @CourseID, @QuestionID, @SelectedAnswer)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserID", userID);
                cmd.Parameters.AddWithValue("@CourseID", courseID);
                cmd.Parameters.AddWithValue("@QuestionID", questionID);
                cmd.Parameters.AddWithValue("@SelectedAnswer", selectedAnswer);

                //Response.Write($"<script>alert('Debug: UserID={Session["UserID"]}, CourseID={Request.QueryString["CourseID"]}, QuestionID={ViewState["CurrentQuestionID"]}, Answer={answerOptions.SelectedValue}')</script>");
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
                    Response.Write($"<script>alert('Error: {ex.Message}')</script>");
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        protected void FinishButton_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(Session["UserID"]);

            // Fetch all user submissions from the database
            DataTable userSubmissions = GetUserSubmissions(userID);

            // Fetch all correct answers from the database
            DataTable correctAnswers = GetCorrectAnswers();

            // Calculate the score
            int totalQuestions = correctAnswers.Rows.Count;
            int correctCount = 0;

            foreach (DataRow userRow in userSubmissions.Rows)
            {
                int questionID = Convert.ToInt32(userRow["QuestionID"]);
                string selectedAnswer = userRow["SelectedOption"].ToString();

                DataRow[] correctRow = correctAnswers.Select($"QuestionID = {questionID}");
                if (correctRow.Length > 0)
                {
                    string correctAnswer = correctRow[0]["CorrectOption"].ToString();
                    if (selectedAnswer.Equals(correctAnswer, StringComparison.OrdinalIgnoreCase))
                    {
                        correctCount++;
                    }
                }
            }

            // Calculate the percentage score
            double percentageScore = (double)correctCount / totalQuestions * 100;

            // Redirect to the result page or display the result
            Session["Result"] = new
            {
                CorrectCount = correctCount,
                TotalQuestions = totalQuestions,
                PercentageScore = percentageScore
            };
            Response.Redirect("Result.aspx");
        }

        private DataTable GetUserSubmissions(int userID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;
            string query = "SELECT QuestionID, SelectedOption FROM UserSubmissions WHERE UserID = @UserID";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserID", userID);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        private DataTable GetCorrectAnswers()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;
            string query = "SELECT QuestionID, CorrectOption FROM Questions";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

    }
}
