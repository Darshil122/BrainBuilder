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
                return;
            }

            string userId = Session["UserID"]?.ToString();  // Get user email safely

            List<string> certificatePaths = new List<string>();  // Store multiple certificates

            string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Certificates WHERE UserId = @userId";  // Use Email instead of Name

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId); // Parameterized query to prevent SQL injection

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                certificatePaths.Add(reader["CertificatePath"].ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log the error (Optional: You can use a logger)
                        System.Diagnostics.Debug.WriteLine("Error: " + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }

            // Store the list of certificates in session
            Session["UserCertificates"] = certificatePaths;
        }
    }
}
