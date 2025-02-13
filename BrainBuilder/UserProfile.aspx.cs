using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace BrainBuilder
{
    public partial class UserProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserEmail"] == null)  // Ensure user is logged in
            {
                Response.Redirect("Account/Login.aspx");
            }

            string userName = Session["UserName"].ToString();  // Get user name

            List<string> certificatePaths = new List<string>();  // Store multiple certificates

            string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT CertificatePath FROM Certificates WHERE StudentName = @UserName";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@UserName", userName);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            certificatePaths.Add(reader["CertificatePath"].ToString());
                        }
                    }
                    conn.Close();
                }
            }

            // Store the list of certificates in session
            Session["UserCertificates"] = certificatePaths;
        }
    }
}
