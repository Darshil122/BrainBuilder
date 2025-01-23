<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddQuestion.aspx.cs" Inherits="BrainBuilder.Admin.AddQuestion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Question</title>
</head>
<body>
    <div class="container mt-5 p-5 bg-white rounded shadow position-relative">
        <h3 class="fw-bold mb-4">Add a New Question</h3>
        <form id="addQuestionForm" runat="server">
            <div class="mb-3">
                <label for="questionText" class="form-label">Question Text</label>
                <textarea class="form-control" id="questionText" runat="server"></textarea>
            </div>
            <div class="mb-3">
                <label for="option1" class="form-label">Option A</label>
                <input type="text" class="form-control" id="option1" runat="server">
            </div>
            <div class="mb-3">
                <label for="option2" class="form-label">Option B</label>
                <input type="text" class="form-control" id="option2" runat="server">
            </div>
            <div class="mb-3">
                <label for="option3" class="form-label">Option C</label>
                <input type="text" class="form-control" id="option3" runat="server">
            </div>
            <div class="mb-3">
                <label for="option4" class="form-label">Option D</label>
                <input type="text" class="form-control" id="option4" runat="server">
            </div>
            <div class="mb-3">
                <label for="correctOption" class="form-label">Correct Option (A/B/C/D)</label>
                <select class="form-select" id="correctOption" runat="server">
                    <option value="A">A</option>
                    <option value="B">B</option>
                    <option value="C">C</option>
                    <option value="D">D</option>
                </select>
            </div>
            <button type="submit" class="btn btn-primary" runat="server" onserverclick="AddQuestion_Click">Submit</button>
        </form>
    </div>
</body>
</html>
