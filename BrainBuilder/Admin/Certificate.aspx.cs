using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace BrainBuilder.Admin
{
    public partial class Certificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserID"] == null)
            //{
            //    Response.Redirect("../Account/Login.aspx");
            //    return;
            //}
            if (!IsPostBack)
            {
                LoadCertificates();
            }
        }

        private void LoadCertificates()
        {
            //string userName = Session["UserName"].ToString(); // Get logged-in user

            string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT c.CertificateId, c.UserId, u.fullname, c.CourseName, c.IssueDate, c.CertificatePath FROM Certificates c JOIN Users u ON c.UserId = u.UserId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    //cmd.Parameters.AddWithValue("@Name", userName);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    rptCertificates.DataSource = reader;
                    rptCertificates.DataBind();
                }
            }
        }
    }
}
