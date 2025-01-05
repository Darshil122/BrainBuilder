using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace BrainBuilder.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if the user is already logged in
                if (Session["UserEmail"] != null)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        protected void LoginUser(object sender, EventArgs e)
        {
            // Get email and password from TextBox inputs
            string userEmail = email.Text.Trim();
            string userPassword = password.Text.Trim();

            // Validate inputs
            if (string.IsNullOrEmpty(userEmail) || string.IsNullOrEmpty(userPassword))
            {
                ShowError("Email and Password cannot be empty.");
                return;
            }

            try
            {
                // Get connection string from Web.config
                string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Query to check if the user exists and credentials match
                    string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email AND Password = @Password";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    { 
                        cmd.Parameters.AddWithValue("@Email", userEmail);
                        cmd.Parameters.AddWithValue("@Password", userPassword); // Assuming passwords are stored as plain text; consider hashing them

                        int userExists = (int)cmd.ExecuteScalar();

                        if (userExists > 0)
                        {
                            // Login successful
                            Session["UserEmail"] = userEmail;
                            FormsAuthentication.RedirectFromLoginPage(userEmail, false);
                        }
                        else
                        {
                            ShowError("Invalid email or password.");
                        }
                    }
                }
            }
            catch (Exception ex)
            { 
                ShowError("An error occurred while processing your request. Please try again later.");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void ShowError(string message)
        {
            Response.Write($"<script>alert('{message}');</script>");
        }
    }
}
