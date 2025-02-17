<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Certificate.aspx.cs" Inherits="BrainBuilder.Admin.Certificate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="content">
        <div class="animated fadeIn">
            <div class="row">

                <div class="col-md-12">
                    <h2 class="fw-bold mt-3">Certificate</h2>
                    <div class="card mt-5">
                        <div class="card-header">
                            <strong class="card-title">Certificate Table</strong>
                        </div>
                        <div class="card-body">
                            <table id="bootstrap-data-table" class="table table-striped table-bordered">
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>Name</th>
                                        <th>Course</th>
                                        <th>Completion Date</th>
                                        <th>Certificate issue</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptCertificates" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("ID") %></td>
                                                <td><%# Eval("StudentName") %></td>
                                                <td><%# Eval("CourseName") %></td>
                                                <td><%# Eval("GeneratedAt") %></td>
                                                <td>
                                                    <a href='<%# Eval("CertificatePath") %>' target="_blank" class="btn btn-primary">
                                                        <i class="fa fa-download"></i>View Certificate
                                                    </a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
