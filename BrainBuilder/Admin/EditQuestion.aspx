<%@ Page Title="Edit Question" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EditQuestion.aspx.cs" Inherits="BrainBuilder.Admin.EditQuestion" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container mt-5">
        <h2 class="text-center">Edit Question</h2>
       <form id="pnlEditQuestion" runat="server">
    <div class="card p-4">
        <div class="form-group">
            <label>Question:</label>
            <asp:TextBox ID="txtQuestion" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Option 1:</label>
            <asp:TextBox ID="txtOption1" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Option 2:</label>
            <asp:TextBox ID="txtOption2" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Option 3:</label>
            <asp:TextBox ID="txtOption3" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Option 4:</label>
            <asp:TextBox ID="txtOption4" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label>Correct Answer:</label>
            <asp:DropDownList ID="ddlCorrectAnswer" runat="server" CssClass="form-control">
                <asp:ListItem Value="A">Option 1</asp:ListItem>
                <asp:ListItem Value="B">Option 2</asp:ListItem>
                <asp:ListItem Value="C">Option 3</asp:ListItem>
                <asp:ListItem Value="D">Option 4</asp:ListItem>
            </asp:DropDownList>
        </div>
        <asp:Button ID="btnUpdate" runat="server" Text="Update Question" CssClass="btn btn-success btn-block" OnClick="btnUpdate_Click" />
    </div>
</form>

    </div>
</asp:Content>
