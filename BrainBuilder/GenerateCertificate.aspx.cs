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
            string studentName = Request.QueryString["name"] ?? "Jaydev Kanzariya";
            string courseName = Request.QueryString["course"] ?? "Azure Data Engineer"; // Fetch course name
            string score = Request.QueryString["score"] ?? "80";

            string templatePath = Server.MapPath("~/assets/img/certificate_template.jpg");
            string fontPath = Server.MapPath("~/assets/fonts/Bugaki.ttf");
            string latoFont = Server.MapPath("~/assets/fonts/Lato-Regular.ttf");
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
                pfc.AddFontFile(latoFont);  

                Font studentFont = new Font(pfc.Families[0], 50, FontStyle.Bold);
                Font courseFont = new Font(pfc.Families[1], 30, FontStyle.Bold | FontStyle.Underline); 

                Brush brush = new SolidBrush(Color.Black);

                // Get image dimensions
                int imageWidth = image.Width;

                // Measure text width
                SizeF studentNameSize = graphics.MeasureString(studentName, studentFont);
                SizeF courseNameSize = graphics.MeasureString(courseName, courseFont);

                // Calculate centered X positions
                float studentNameX = (imageWidth - studentNameSize.Width) / 2;
                float courseNameX = (imageWidth - courseNameSize.Width) / 2;

                // Draw student name (centered)
                graphics.DrawString(studentName, studentFont, brush, new PointF(studentNameX, 625));

                // Draw course name (centered)
                graphics.DrawString(courseName, courseFont, brush, new PointF(courseNameX, 400));

                // Save the final certificate
                image.Save(outputPath, ImageFormat.Png);

                // Save the final certificate
                image.Save(outputPath, ImageFormat.Png);

            }

            // Save to database
            //SaveCertificateToDatabase(studentName, courseName, Convert.ToDecimal(score), $"~/certificates/{studentName}_Certificate.png");

            // Serve the file to the user for download
            Response.ContentType = "image/png";
            Response.AppendHeader("Content-Disposition", $"attachment; filename={studentName}_Certificate.png");
            Response.TransmitFile(outputPath);
            Response.End();
        }

        //private void SaveCertificateToDatabase(string studentName, string courseName, decimal score, string certificatePath)
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;

        //    using (SqlConnection conn = new SqlConnection(connectionString))
        //    {
        //        string query = "INSERT INTO Certificates (StudentName, CourseName, Score, CertificatePath) VALUES (@StudentName, @CourseName, @Score, @CertificatePath)";

        //        using (SqlCommand cmd = new SqlCommand(query, conn))
        //        {
        //            cmd.Parameters.AddWithValue("@StudentName", studentName);
        //            cmd.Parameters.AddWithValue("@CourseName", courseName);
        //            cmd.Parameters.AddWithValue("@Score", score);
        //            cmd.Parameters.AddWithValue("@CertificatePath", certificatePath);

        //            conn.Open();
        //            cmd.ExecuteNonQuery();
        //            conn.Close();
        //        }
        //    }
        //}
    }
}
