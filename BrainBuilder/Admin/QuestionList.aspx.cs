using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace BrainBuilder.Admin
{
    public partial class QuestionList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadQuestions();
            }
        }

        private void LoadQuestions()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Questions";  // Fetch all questions
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rptQuestions.DataSource = dt;
                rptQuestions.DataBind();
            }
        }
    }
}
