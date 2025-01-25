using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrainBuilder.Admin
{
    public partial class AddQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCourses();
            }
        }

        private void LoadCourses()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;

            string query = "SELECT CourseID, CourseName FROM Courses";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                try
                {
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    ddlCourses.DataSource = reader;
                    ddlCourses.DataTextField = "CourseName"; // Display course names
                    ddlCourses.DataValueField = "CourseID"; // Use CourseID as the value
                    ddlCourses.DataBind();

                    // Optionally add a default "Select a course" option
                    ddlCourses.Items.Insert(0, new ListItem("-- Select a Course --", ""));
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error loading courses: {ex.Message}');</script>");
                }
            }
        }

        protected void AddQuestion_Click(object sender, EventArgs e)
        {
            // Fetch the inputs
            string question = questionText.Value;
            string opt1 = option1.Value;
            string opt2 = option2.Value;
            string opt3 = option3.Value;
            string opt4 = option4.Value;
            string correctOpt = correctOption.Value;
            string courseID = ddlCourses.SelectedValue;

            // Validate the inputs
            if (string.IsNullOrWhiteSpace(question) || string.IsNullOrWhiteSpace(opt1) ||
                string.IsNullOrWhiteSpace(opt2) || string.IsNullOrWhiteSpace(opt3) || string.IsNullOrWhiteSpace(opt4) ||
                string.IsNullOrWhiteSpace(correctOpt) || string.IsNullOrWhiteSpace(courseID))
            {
                Response.Write("<script>alert('Please fill in all fields and select a course.');</script>");
                return;
            }

            // Define your connection string
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;

            // SQL query to insert the question
            string query = @"INSERT INTO Questions (QuestionText, Option1, Option2, Option3, Option4, CorrectOption, CourseID) 
                     VALUES (@QuestionText, @Option1, @Option2, @Option3, @Option4, @CorrectOption, @CourseID)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@QuestionText", question);
                cmd.Parameters.AddWithValue("@Option1", opt1);
                cmd.Parameters.AddWithValue("@Option2", opt2);
                cmd.Parameters.AddWithValue("@Option3", opt3);
                cmd.Parameters.AddWithValue("@Option4", opt4);
                cmd.Parameters.AddWithValue("@CorrectOption", correctOpt);
                cmd.Parameters.AddWithValue("@CourseID", courseID);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Question added successfully!');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                }
            }
        }

    }
}