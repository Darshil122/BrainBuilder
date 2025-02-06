<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateCertificate.aspx.cs" Inherits="BrainBuilder.GenerateCertificate" %>
<%@ Register Assembly="CrystalDecisions.Web" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Certificate</title>
</head>
<body>
    <form id="form1" runat="server">
        <CR:CrystalReportViewer ID="crvCertificate" runat="server" AutoDataBind="true" 
            Width="100%" Height="800px"/>
    </form>
</body>
</html>
