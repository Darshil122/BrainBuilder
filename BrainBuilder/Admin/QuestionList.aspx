<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="QuestionList.aspx.cs" Inherits="BrainBuilder.Admin.QuestionList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
    <div class="animated fadeIn">
        <div class="row">
            <div class="col-md-12">
                <div class="card mt-5">
                    <div class="card-header">
                        <strong class="card-title">Questions Table</strong>
                    </div>
                    <div class="card-body">
                        <table id="bootstrap-data-table" class="table table-striped table-bordered">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Question</th>
                                    <th>Option A</th>
                                    <th>Option B</th>
                                    <th>Option C</th>
                                    <th>Option D</th>
                                    <th>Correct Option</th>
                                    <th>Action</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptQuestions" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("QuestionID") %></td>
                                            <td><%# Eval("QuestionText") %></td>
                                            <td><%# Eval("Option1") %></td>
                                            <td><%# Eval("Option2") %></td>
                                            <td><%# Eval("Option3") %></td>
                                            <td><%# Eval("Option4") %></td>
                                            <td><%# Eval("CorrectOption") %></td>
                                            <td>
                                                <a href='EditQuestion.aspx?ID=<%# Eval("QuestionID") %>' class="btn btn-warning">Edit</a>
                                                <a href='DeleteQuestion.aspx?ID=<%# Eval("QuestionID") %>' class="btn btn-danger">Delete</a>
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
