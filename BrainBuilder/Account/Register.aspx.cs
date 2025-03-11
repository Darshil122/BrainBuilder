using System;
using System.Data.SqlClient;
using System.Configuration;

namespace BrainBuilder.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void RegisterUser(object sender, EventArgs e)
        {
            // Hide error messages initially
            Namerror.Visible = false;
            Emailerror.Visible = false;
            Passerror.Visible = false;
            cpasserror.Visible = false;
            cppasserror.Visible = false;

            string fullName = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            bool isValid = true;

            if (string.IsNullOrWhiteSpace(fullName))
            {
                Namerror.Visible = true;
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                Emailerror.Visible = true;
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                Passerror.Visible = true;
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                cpasserror.Visible = true;
                isValid = false;
            }
            if (password != confirmPassword)
            {
                cppasserror.Visible = true;
                isValid = false;
            }

            // Stop execution if validation fails
            if (!isValid) return;

            string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (FullName, Email, Password) VALUES (@FullName, @Email, @Password)";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password); // Consider hashing the password

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Registration successful!');</script>");
                    Response.Redirect("Login.aspx");
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                }
            }
        }
    }
}
