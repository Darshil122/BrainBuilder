<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/AdminMaster.Master" CodeBehind="UserData.aspx.cs" Inherits="BrainBuilder.Admin.UserData" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="animated fadeIn">
            <div class="row">

                <div class="col-md-12">
                    <div class="card mt-5">
                        <div class="card-header">
                            <strong class="card-title">User Table</strong>
                        </div>
                        <div class="card-body">
                            <table id="bootstrap-data-table" class="table table-striped table-bordered">
                                <thead>
                                    <tr>
                                        <th>ID</th>
                                        <th>Name</th>
                                        <th>Email</th>
                                        <%--<th>Phone</th>--%>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptUsers" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td><%# Eval("UserID") %></td>
                                                <td><%# Eval("FullName") %></td>
                                                <td><%# Eval("Email") %></td>
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
