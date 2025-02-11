using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace BrainBuilder
{
    public partial class Result : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Result"] != null)
            {
                var result = Session["Result"] as dynamic;
                int correctCount = result.CorrectCount;
                int totalQuestions = result.TotalQuestions;
                double percentageScore = result.PercentageScore;
                string studentName = Session["UserName"]?.ToString() ?? "Student"; // Get student name from session
                string courseName = GetCourseName(); // Fetch Course Name

                // Display the result with course name
                resultText.InnerText = $"Course: {courseName} - You answered {correctCount} out of {totalQuestions} questions correctly. Your score is {percentageScore:F2}%.";

                if (percentageScore >= 80)
                {
                    certificateLinkElement.InnerText = "Download Certificate";
                    certificateLinkElement.HRef = $"GenerateCertificate.aspx?name={HttpUtility.UrlEncode(studentName)}&course={HttpUtility.UrlEncode(courseName)}&score={percentageScore}";
                    certificateSection.Visible = true;
                }
                else
                {
                    certificateSection.Visible = false; // Hide if score < 80%
                }
            }
            else
            {
                resultText.InnerText = "No result found. Please complete the quiz first.";
                certificateSection.Visible = false;
            }
        }

        private string GetCourseName()
        {
            string courseName = "Unknown Course"; // Default value
            if (Session["courseID"] != null)
            {
                int courseID = Convert.ToInt32(Session["courseID"]);
                string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT CourseName FROM Course WHERE CourseID = @CourseID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@CourseID", courseID);

                    try
                    {
                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            courseName = result.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log error (you can replace this with proper error logging)
                        Console.WriteLine("Database Error: " + ex.Message);
                    }
                }
            }
            return courseName;
        }


    }
}
