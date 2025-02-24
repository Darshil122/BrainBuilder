using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrainBuilder.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDashboardData();
            }
        }

        private void LoadDashboardData()
        {
            string connString = ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT (SELECT COUNT(*) FROM Courses) AS TotalCourses, (SELECT COUNT(*) FROM Users) AS TotalStudents, (SELECT COUNT(*) FROM Certificates) AS TotalCertificates, (SELECT AVG(Score) FROM Certificates) AS SuccessRate", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lblTotalCourses.Text = reader["TotalCourses"].ToString();
                    lblTotalStudents.Text = reader["TotalStudents"].ToString();
                    lblTotalCertificates.Text = reader["TotalCertificates"].ToString();
                    //lblSuccessRate.Text = reader["SuccessRate"].ToString() + "%";
                }
                reader.Close();
            }
        }
    }
}