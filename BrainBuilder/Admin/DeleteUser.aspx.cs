using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace BrainBuilder
{
    public partial class DeleteUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int uID = Convert.ToInt32(Request.QueryString["ID"]);
            if(uID != null)
            {
                    string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;
                    SqlConnection con = new SqlConnection(connectionString);
                    SqlCommand cmd = new SqlCommand("delete from Users where UserId = '"+ uID +"'", con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("UserData.aspx");
                }

            }
        }

    }
}