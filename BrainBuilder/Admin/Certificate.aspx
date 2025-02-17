<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Certificate.aspx.cs" Inherits="BrainBuilder.Admin.Certificate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="animated fadeIn">
            <div class="row">

                <div class="col-md-12">
                    <div class="card mt-5">
                        <div class="card-header">
                            <strong class="card-title">Student Table</strong>
                        </div>
                        <div class="card-body">
                            <asp:Repeater ID="rptCertificates" runat="server">
                                <HeaderTemplate>
                                    <table id="bootstrap-data-table" class="table table-striped table-bordered">
                                        <thead>
                                            <tr>
                                                <th>Certificate ID</th>
                                                <th>Student Name</th>
                                                <th>Course</th>
                                                <th>Completion Date</th>
                                                <th>Certificate</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("ID") %></td>
                                        <td><%# Eval("StudentName") %></td>
                                        <td><%# Eval("CourseName") %></td>
                                        <td><%# Eval("Generated At", "{0:dd/MM/yyyy}") %></td>
                                        <td>
                                            <a href='<%# Eval("CertificatePath") %>' target="_blank" class="btn btn-primary">
                                                <i class="fa fa-download"></i>View Certificate
                                            </a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                                </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
