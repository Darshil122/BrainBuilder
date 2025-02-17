using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace BrainBuilder
{
    public partial class Certificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCertificates();
            }
        }

        private void LoadCertificates()
        {
            string userName = Session["UserName"].ToString(); // Get logged-in user

            string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT ID, StudentName, CourseName, GeneratedAt, CertificatePath FROM Certificates WHERE StudentName = @Name";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", userName);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    rptCertificates.DataSource = reader;
                    rptCertificates.DataBind();
                }
            }
        }
    }
}
