using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Web;

namespace BrainBuilder
{
    public partial class GenerateCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string studentName = Request.QueryString["name"] ?? "Student";
            string score = Request.QueryString["score"] ?? "80";

            string templatePath = Server.MapPath("~/assets/img/certificate_template.jpg");
            string fontPath = Server.MapPath("~/assets/fonts/Bugaki.ttf");
            string outputPath = Server.MapPath($"~/certificates/{studentName}_Certificate.png");

            using (Image image = Image.FromFile(templatePath))
            using (Graphics graphics = Graphics.FromImage(image))
            using (PrivateFontCollection pfc = new PrivateFontCollection())
            {
                // Add custom font from file
                pfc.AddFontFile(fontPath);  // FIXED: Using absolute path

                Font font = new Font(pfc.Families[0], 50, FontStyle.Bold);
                Brush brush = new SolidBrush(Color.Black);

                // Draw student name
                graphics.DrawString(studentName, font, brush, new PointF(700, 600));

                // Save the final certificate
                image.Save(outputPath, ImageFormat.Png);
            }

            // Serve the file to the user for download
            Response.ContentType = "image/png";
            Response.AppendHeader("Content-Disposition", $"attachment; filename={studentName}_Certificate.png");
            Response.TransmitFile(outputPath);
            Response.End();
        }
    }
}
