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
            //if (!IsPostBack)
            //{
            //    LoadCourses();
            //}
        }


        protected void AddQuestion_Click(object sender, EventArgs e)
        {
            // Hide all error messages initially
            lblQuestionError.Visible = false;
            lblOption1Error.Visible = false;
            lblOption2Error.Visible = false;
            lblOption3Error.Visible = false;
            lblOption4Error.Visible = false;
            lblCorrectOptionError.Visible = false;

            // Fetch the inputs
            string question = questionText.Value;
            string opt1 = option1.Value;
            string opt2 = option2.Value;
            string opt3 = option3.Value;
            string opt4 = option4.Value;
            string correctOpt = correctOption.Value;

            // Validate the inputs
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(question))
            {
                lblQuestionError.Visible = true;
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(opt1))
            {
                lblOption1Error.Visible = true;
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(opt2))
            {
                lblOption2Error.Visible = true;
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(opt3))
            {
                lblOption3Error.Visible = true;
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(opt4))
            {
                lblOption4Error.Visible = true;
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(correctOpt))
            {
                lblCorrectOptionError.Visible = true;
                isValid = false;
            }

            // If validation fails, stop further execution
            if (!isValid)
            {
                return;
            }

            // Define your connection string
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["BrainBuilderDB"].ConnectionString;

            // SQL query to insert the question (without CourseID)
            string query = @"INSERT INTO Questions (QuestionText, Option1, Option2, Option3, Option4, CorrectOption) 
                     VALUES (@QuestionText, @Option1, @Option2, @Option3, @Option4, @CorrectOption)";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@QuestionText", question);
                cmd.Parameters.AddWithValue("@Option1", opt1);
                cmd.Parameters.AddWithValue("@Option2", opt2);
                cmd.Parameters.AddWithValue("@Option3", opt3);
                cmd.Parameters.AddWithValue("@Option4", opt4);
                cmd.Parameters.AddWithValue("@CorrectOption", correctOpt);

                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();

                    // Clear the form fields after successful insertion
                    ClearFormFields();

                    // Show success message
                    Response.Write("<script>alert('Question added successfully!');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error: {ex.Message}');</script>");
                }
            }
        }

        // Method to clear form fields
        private void ClearFormFields()
        {
            // Clear the textarea and text inputs
            questionText.Value = string.Empty;
            option1.Value = string.Empty;
            option2.Value = string.Empty;
            option3.Value = string.Empty;
            option4.Value = string.Empty;

            // Reset the correct option dropdown
            correctOption.SelectedIndex = 0;
        }

    }
}