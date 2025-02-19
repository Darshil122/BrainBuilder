using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Web;
using System.Configuration;

namespace BrainBuilder
{
    public partial class GenerateCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Ensure user is logged in
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/Account/Login.aspx");
                return;
            }

            int userId = Convert.ToInt32(Session["UserId"]);
            string studentName = Session["UserName"]?.ToString() ?? "John Doe";
            string courseName = Request.QueryString["course"] ?? "Azure Data Engineer";
            string score = Request.QueryString["score"] ?? "80";

            string templatePath = Server.MapPath("~/assets/img/certificate_template.jpg");
            string fontPath = Server.MapPath("~/assets/fonts/Bugaki.ttf");
            string latoFont = Server.MapPath("~/assets/fonts/Lato-Regular.ttf");

            // Ensure the certificates folder exists
            string certificatesFolder = Server.MapPath("~/certificates/");
            if (!Directory.Exists(certificatesFolder))
            {
                Directory.CreateDirectory(certificatesFolder);
            }

            // Define output file path
            string outputPath = Path.Combine(certificatesFolder, $"{courseName}_Certificate.png");

            using (Image image = Image.FromFile(templatePath))
            using (Graphics graphics = Graphics.FromImage(image))
            using (PrivateFontCollection pfc = new PrivateFontCollection())
            {
                pfc.AddFontFile(fontPath);
                pfc.AddFontFile(latoFont);

                Font studentFont = new Font(pfc.Families[0], 50, FontStyle.Bold);
                Font courseFont = new Font(pfc.Families[1], 30, FontStyle.Bold | FontStyle.Underline);

                Brush brush = new SolidBrush(Color.Black);

                int imageWidth = image.Width;
                SizeF studentNameSize = graphics.MeasureString(studentName, studentFont);
                SizeF courseNameSize = graphics.MeasureString(courseName, courseFont);

                float studentNameX = (imageWidth - studentNameSize.Width) / 2;
                float courseNameX = (imageWidth - courseNameSize.Width) / 2;

                graphics.DrawString(studentName, studentFont, brush, new PointF(studentNameX, 625));
                graphics.DrawString(courseName, courseFont, brush, new PointF(courseNameX, 400));

                image.Save(outputPath, ImageFormat.Png);
            }

            // Save the relative path in the database
            string dbPath = $"/certificates/{courseName}_Certificate.png";
            SaveCertificateToDatabase(userId, courseName, Convert.ToDecimal(score), dbPath);

            // Serve the file for download
            Response.ContentType = "image/png";
            Response.AppendHeader("Content-Disposition", $"attachment; filename={courseName}_Certificate.png");
            Response.TransmitFile(outputPath);
            Response.End();
        }

        private void SaveCertificateToDatabase(int userId, string courseName, decimal score, string certificatePath)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Certificates (UserId, CourseName, Score, CertificatePath) VALUES (@UserId, @CourseName, @Score, @CertificatePath)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@CourseName", courseName);
                    cmd.Parameters.AddWithValue("@Score", score);
                    cmd.Parameters.AddWithValue("@CertificatePath", certificatePath);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
