using System;
using System.IO;
using System.Web;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

namespace BrainBuilder
{
    public partial class GenerateCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Result"] != null)
            {
                var result = Session["Result"] as dynamic;
                string userName = Session["UserName"] != null ? Session["UserName"].ToString() : "Participant";
                double percentageScore = result.PercentageScore;

                if (percentageScore >= 80)
                {
                    GenerateCertificatePDF(userName);
                }
                else
                {
                    Response.Write("You are not eligible for a certificate.");
                }
            }
            else
            {
                Response.Write("No result data found.");
            }
        }

        private void GenerateCertificatePDF(string userName)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Certificate.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                PdfWriter writer = new PdfWriter(memoryStream);
                PdfDocument pdfDoc = new PdfDocument(writer);
                Document doc = new Document(pdfDoc);

                doc.Add(new Paragraph("Certificate of Achievement")
                            .SetFontSize(24)
                            .SetBold()
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                doc.Add(new Paragraph($"Presented to: {userName}")
                            .SetFontSize(18)
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                doc.Add(new Paragraph("For outstanding performance in the Brain Builder Exam.")
                            .SetFontSize(14)
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                doc.Add(new Paragraph("Congratulations!")
                            .SetFontSize(16)
                            .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));

                doc.Close();

                Response.BinaryWrite(memoryStream.ToArray());
                Response.End();
            }
        }
    }
}
