<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="BrainBuilder.Result" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Result</title>
</head>
<body>
    <div class="container mt-5">
        <h1 class="text-center">Quiz Result</h1>
        <div class="card mt-4">
            <div class="card-body">
                <h4 class="card-title">Your Score</h4>
                <p class="card-text" id="resultText" runat="server"></p>
            </div>
        </div>
    </div>
</body>
</html>
