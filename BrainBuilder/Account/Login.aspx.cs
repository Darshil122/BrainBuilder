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
                if (Session["UserEmail"] != null)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        protected void LoginUser(object sender, EventArgs e)
        {
            Emailerror.Visible = false;
            Passerror.Visible = false;

            string userEmail = email.Text.Trim();
            string userPassword = password.Text.Trim();

            bool isValid = true;

            if (string.IsNullOrWhiteSpace(userEmail))
            {
                Emailerror.Visible = true;
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(userPassword))
            {
                Passerror.Visible = true;
                isValid = false;
            }

            if (!isValid)
            {
                return;
            }

            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (userEmail == "admin@gmail.com" && userPassword == "Admin123")
                    {
                        Response.Redirect("../Admin/Dashboard.aspx");
                    }
                    else
                    {
                        string query = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Email", userEmail);
                            cmd.Parameters.AddWithValue("@Password", userPassword);

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    int userID = reader.GetInt32(0);
                                    string userName = reader.GetString(1);

                                    Session["UserID"] = userID;
                                    Session["UserName"] = userName;
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
            lblError.Text = message;
            lblError.Visible = true;
        }

    }
}