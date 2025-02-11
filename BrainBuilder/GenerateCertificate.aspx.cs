using System;
using System.Data.SqlClient;  // For database operations
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Web;
using System.Configuration;  // For connection string

namespace BrainBuilder
{
    public partial class GenerateCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string studentName = Request.QueryString["name"] ?? "Student";
            string courseName = Request.QueryString["course"] ?? "Unknown Course"; // Fetch course name
            string score = Request.QueryString["score"] ?? "80";

            string templatePath = Server.MapPath("~/assets/img/certificate_template.jpg");
            string fontPath = Server.MapPath("~/assets/fonts/Bugaki.ttf");
            string outputPath = Server.MapPath($"~/certificates/{studentName}_Certificate.png");

            if (!File.Exists(fontPath))
            {
                Response.Write("Font file not found!");
                Response.End();
                return;
            }

            using (Image image = Image.FromFile(templatePath))
            using (Graphics graphics = Graphics.FromImage(image))
            using (PrivateFontCollection pfc = new PrivateFontCollection())
            {
                pfc.AddFontFile(fontPath);

                Font font = new Font(pfc.Families[0], 50, FontStyle.Bold);
                Brush brush = new SolidBrush(Color.Black);

                // Draw student name
                graphics.DrawString(studentName, font, brush, new PointF(750, 600)); // Adjust position

                // Draw course name
                Font courseFont = new Font(pfc.Families[0], 40, FontStyle.Bold);
                graphics.DrawString(courseName, courseFont, brush, new PointF(750, 700)); // Adjust position

                // Save the final certificate
                image.Save(outputPath, ImageFormat.Png);
            }

            // Save to database
            SaveCertificateToDatabase(studentName, courseName, Convert.ToDecimal(score), $"~/certificates/{studentName}_Certificate.png");

            // Serve the file to the user for download
            Response.ContentType = "image/png";
            Response.AppendHeader("Content-Disposition", $"attachment; filename={studentName}_Certificate.png");
            Response.TransmitFile(outputPath);
            Response.End();
        }

        private void SaveCertificateToDatabase(string studentName, string courseName, decimal score, string certificatePath)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Certificates (StudentName, CourseName, Score, CertificatePath) VALUES (@StudentName, @CourseName, @Score, @CertificatePath)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentName", studentName);
                    cmd.Parameters.AddWithValue("@CourseName", courseName);
                    cmd.Parameters.AddWithValue("@Score", score);
                    cmd.Parameters.AddWithValue("@CertificatePath", certificatePath);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
