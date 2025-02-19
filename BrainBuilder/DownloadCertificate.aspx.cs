using System;
using System.IO;
using System.Web;

namespace BrainBuilder
{
    public partial class DownloadCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["file"] != null)
            {
                string filePath = Server.MapPath(Request.QueryString["file"]); // Convert to physical path

                if (File.Exists(filePath))
                {
                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
                    Response.TransmitFile(filePath);
                    Response.End();
                }
                else
                {
                    Response.Write("<script>alert('File not found!'); window.location='UserProfile.aspx';</script>");
                }
            }
            else
            {
                Response.Redirect("UserProfile.aspx");
            }
        }
    }
}
