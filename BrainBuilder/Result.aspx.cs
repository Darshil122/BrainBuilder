using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

                resultText.InnerText = $"You answered {correctCount} out of {totalQuestions} questions correctly. Your score is {percentageScore:F2}%.";
            }
            else
            {
                resultText.InnerText = "No result found. Please complete the quiz first.";
            }
        }
    }
}