using System;
using System.Configuration;
using System.Data.SqlClient;

namespace BrainBuilder.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Any initialization code if needed
        }

        protected void LoginUser(object sender, EventArgs e)
        {
            string userEmail = email.Text.Trim();
            string userPassword = password.Text.Trim();

            string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT COUNT(1) FROM Users WHERE Email = @Email AND Password = @Password";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@Email", userEmail);
                    cmd.Parameters.AddWithValue("@Password", userPassword);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {
                        // Login successful
                        Session["UserEmail"] = userEmail;
                        Response.Redirect("~/Home.aspx");
                    }
                    else
                    {
                        // Invalid credentials
                        Response.Write("<script>alert('Invalid email or password.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    // Log or display error
                    Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
                }
            }
        }
    }
}
