<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin/AdminMaster.Master" CodeBehind="AddQuestion.aspx.cs" Inherits="BrainBuilder.Admin.AddQuestion" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="animated fadeIn">
            <div class="row">
                <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 class="card-title">Add a New Question</h4>
                        </div>
                        <div class="card-body">
                            <form id="addQuestionForm" runat="server">
                                <!-- Course Dropdown -->
                                <%--<div class="mb-3">
                                    <label for="ddlCourses" class="form-label">Select Course</label>
                                    <asp:DropDownList ID="ddlCourses" runat="server" CssClass="form-control"></asp:DropDownList>
                                    <asp:Label ID="lblCourseError" runat="server" CssClass="text-danger" Visible="false" Text="Please select a course."></asp:Label>
                                </div>--%>

                                <!-- Question Text -->
                                <div class="mb-3">
                                    <label for="questionText" class="form-label">Question Text</label>
                                    <textarea class="form-control" id="questionText" runat="server" rows="4"></textarea>
                                    <asp:Label ID="lblQuestionError" runat="server" CssClass="text-danger" Visible="false" Text="Please enter the question text."></asp:Label>
                                </div>

                                <!-- Options in Two Columns -->
                                <div class="row mb-3">
                                    <div class="col-md-6">
                                        <label for="option1" class="form-label">Option A</label>
                                        <input type="text" class="form-control" id="option1" runat="server" />
                                        <asp:Label ID="lblOption1Error" runat="server" CssClass="text-danger" Visible="false" Text="Please enter Option A."></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <label for="option2" class="form-label">Option B</label>
                                        <input type="text" class="form-control" id="option2" runat="server" />
                                        <asp:Label ID="lblOption2Error" runat="server" CssClass="text-danger" Visible="false" Text="Please enter Option B."></asp:Label>
                                    </div>
                                </div>
                                <div class="row mb-3">
                                    <div class="col-md-6">
                                        <label for="option3" class="form-label">Option C</label>
                                        <input type="text" class="form-control" id="option3" runat="server" />
                                        <asp:Label ID="lblOption3Error" runat="server" CssClass="text-danger" Visible="false" Text="Please enter Option C."></asp:Label>
                                    </div>
                                    <div class="col-md-6">
                                        <label for="option4" class="form-label">Option D</label>
                                        <input type="text" class="form-control" id="option4" runat="server" />
                                        <asp:Label ID="lblOption4Error" runat="server" CssClass="text-danger" Visible="false" Text="Please enter Option D."></asp:Label>
                                    </div>
                                </div>

                                <!-- Correct Option -->
                                <div class="mb-3">
                                    <label for="correctOption" class="form-label">Correct Option (A/B/C/D)</label>
                                    <select class="form-select" id="correctOption" runat="server">
                                        <option value="A">A</option>
                                        <option value="B">B</option>
                                        <option value="C">C</option>
                                        <option value="D">D</option>
                                    </select>
                                    <asp:Label ID="lblCorrectOptionError" runat="server" CssClass="text-danger" Visible="false" Text="Please select the correct option."></asp:Label>
                                </div>

                                <!-- Submit Button -->
                                <div class="text-center">
                                    <button type="submit" class="btn btn-primary" runat="server" onserverclick="AddQuestion_Click">Submit</button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>