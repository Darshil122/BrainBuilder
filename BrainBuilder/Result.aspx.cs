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
            var result = Session["Result"] as dynamic;
            if (Session["Result"] != null)
            {
                int correctCount = result.CorrectCount;
                int totalQuestions = result.TotalQuestions;
                double percentageScore = result.PercentageScore;
                string studentName = Session["UserName"]?.ToString() ?? "Student";
                string courseName = GetCourseName();

                // Display the result with course name
                //resultText.InnerText = $"Course: {courseName} - You answered {correctCount} out of {totalQuestions} questions correctly. Your score is {percentageScore:F2}%.";
                resultText.InnerText = $"Course: {courseName} - You are pass download your certificate";


                if (percentageScore >= 80)
                {
                    certificateLinkElement.InnerText = "Download Certificate";
                    certificateLinkElement.HRef = $"GenerateCertificate.aspx?name={HttpUtility.UrlEncode(studentName)}&course={HttpUtility.UrlEncode(courseName)}&score={percentageScore}";
                    certificateSection.Visible = true;
                }
                else
                {
                    certificateSection.Visible = false;
                    failsection.Visible = true;
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
            string courseName = "Information Technology";
            if (Session["courseID"] != null)
            {
                int courseID = Convert.ToInt32(Session["courseID"]);
                string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT CourseName FROM Courses WHERE CourseID = @CourseID";
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
                        Console.WriteLine("Database Error: " + ex.Message);
                    }
                }
            }
            return courseName;
        }
    }
}
