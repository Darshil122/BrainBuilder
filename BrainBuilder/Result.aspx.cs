using System;
using System.IO;

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

                // Display the result
                resultText.InnerText = $"You answered {correctCount} out of {totalQuestions} questions correctly. Your score is {percentageScore:F2}%.";

                // Check if the score is 80% or higher
                if (percentageScore >= 80)
                {
                    // Generate and display the certificate
                    //string certificateLink = GenerateCertificate(correctCount, totalQuestions, percentageScore);
                    //certificateSection.Visible = true;
                    //certificateLinkElement.HRef = certificateLink;
                    certificateLinkElement.InnerText = "Download Certificate";
                }
                else
                {
                    // Hide the certificate section if the score is below 80%
                    certificateSection.Visible = false;
                }
            }
            else
            {
                resultText.InnerText = "No result found. Please complete the quiz first.";
                certificateSection.Visible = false;
            }
        }

        //private string GenerateCertificate(int correctCount, int totalQuestions, double percentageScore)
        //{
        //    // Ensure the Certificates directory exists
        //    string certificatesPath = Server.MapPath("~/Certificates/");
        //    if (!Directory.Exists(certificatesPath))
        //    {
        //        Directory.CreateDirectory(certificatesPath);
        //    }

        //    // Generate a unique certificate file name
        //    string fileName = $"Certificate_{Session["UserID"]}_{DateTime.Now:yyyyMMddHHmmss}.pdf";
        //    string filePath = Path.Combine(certificatesPath, fileName);

        //    // Create PDF document using iText 7
        //    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
        //    {
        //        using (PdfWriter writer = new PdfWriter(fs))
        //        {
        //            using (PdfDocument pdfDoc = new PdfDocument(writer))
        //            {
        //                Document document = new Document(pdfDoc);

        //                // Add certificate content
        //                document.Add(new Paragraph("Certificate of Achievement")
        //                    .SetTextAlignment(TextAlignment.CENTER)
        //                    .SetFontSize(24)
        //                    .SetBold());

        //                document.Add(new Paragraph("This certificate is awarded to:")
        //                    .SetTextAlignment(TextAlignment.CENTER)
        //                    .SetFontSize(18));

        //                document.Add(new Paragraph(Session["UserName"].ToString())
        //                    .SetTextAlignment(TextAlignment.CENTER)
        //                    .SetFontSize(22)
        //                    .SetBold());

        //                document.Add(new Paragraph($"For scoring {percentageScore:F2}% in the quiz.")
        //                    .SetTextAlignment(TextAlignment.CENTER)
        //                    .SetFontSize(16));

        //                document.Add(new Paragraph($"Date: {DateTime.Now:MMMM dd, yyyy}")
        //                    .SetTextAlignment(TextAlignment.CENTER)
        //                    .SetFontSize(14));

        //                document.Close();
        //            }
        //        }
        //    }

        //    // Return the relative file path for download
        //    return $"~/Certificates/{fileName}";
        //}
    }
}