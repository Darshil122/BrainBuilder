using System;
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

                // Display the result
                resultText.InnerText = $"You answered {correctCount} out of {totalQuestions} questions correctly. Your score is {percentageScore:F2}%.";

                if (percentageScore >= 80)
                {
                    certificateLinkElement.InnerText = "Download Certificate";
                    certificateLinkElement.HRef = $"GenerateCertificate.aspx?name={HttpUtility.UrlEncode(studentName)}&score={percentageScore}";
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
    }
}
