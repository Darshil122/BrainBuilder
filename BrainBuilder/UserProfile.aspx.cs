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
            if (Session["UserEmail"] == null)  
            {
                Response.Redirect("Account/Login.aspx");
                return;
            }

            string userId = Session["UserID"]?.ToString();  

            List<string> certificatePaths = new List<string>();  
            string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Certificates WHERE UserId = @userId";  

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId); 

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
