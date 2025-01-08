using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrainBuilder.Account
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear all session variables
            Session.Clear();

            // Abandon the session
            Session.Abandon();

            // Optionally, redirect to login page or homepage
            Response.Redirect("../Default.aspx"); // Or "Home.aspx" depending on your requirement
        }
    }
}