using System;
using System.Data;
using System.Web.UI;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace BrainBuilder
{
    public partial class GenerateCertificate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateCertificateReport();
            }
        }

        private void GenerateCertificateReport()
        {
            if (Session["Result"] != null && Session["UserName"] != null)
            {
                var result = Session["Result"] as dynamic;
                string userName = Session["UserName"].ToString();

                // Create a DataTable for passing data to the Crystal Report
                DataTable dt = new DataTable();
                dt.Columns.Add("CandidateName", typeof(string));
                dt.Columns.Add("ExamName", typeof(string));
                dt.Columns.Add("Score", typeof(string));
                dt.Columns.Add("CompletionDate", typeof(string));

                dt.Rows.Add(userName, "Brain Builder Exam", $"{result.PercentageScore:F2}%", DateTime.Now.ToString("yyyy-MM-dd"));

                // Load Crystal Report
                ReportDocument rpt = new ReportDocument();
                rpt.Load(Server.MapPath("~/Reports/CertificateReport.rpt"));
                rpt.SetDataSource(dt);

                // Bind report to CrystalReportViewer
                crvCertificate.ReportSource = rpt;
                crvCertificate.DataBind();
            }
            else
            {
                Response.Write("No certificate available. Please complete the quiz.");
            }
        }
    }
}
