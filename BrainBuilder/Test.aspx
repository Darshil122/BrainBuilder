<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="BrainBuilder.Test" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <!--? slider Area Start-->
        <section class="slider-area slider-area2">
            <div class="slider-active">
                <!-- Single Slider -->
                <div class="single-slider slider-height2">
                    <div class="container">
                        <div class="row">
                            <div class="col-xl-8 col-lg-11 col-md-12">
                                <div class="hero__caption hero__caption2">
                                    <h1 data-animation="bounceIn" data-delay="0.2s">Test</h1>
                                    <!-- breadcrumb Start-->
                                    <nav aria-label="breadcrumb">
                                        <ol class="breadcrumb">
                                            <li class="breadcrumb-item"><a href="Default.aspx">Home</a></li>
                                            <li class="breadcrumb-item"><a href="Courses.aspx">Courses</a></li>
                                        </ol>
                                    </nav>
                                    <!-- breadcrumb End -->
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <!-- Courses area start -->
        <div class="courses-area section-padding35 fix">
            <div class="container mt-5 p-5 bg-white rounded shadow position-relative">
                <!-- Question Section -->
                <div id="question-section" class="d-flex justify-content-between align-items-center mb-4">
                    <asp:Label ID="questionTitle" runat="server" Text="Question"></asp:Label>
                    <div class="text-danger fw-bold" id="timer">
                        Time Left:
                        <%--<asp:Literal ID="timerLiteral" runat="server"></asp:Literal>--%>
                    </div>
                </div>
                <asp:Label ID="questionText" runat="server" Text="Question Text"></asp:Label>

                <br />
<asp:RadioButtonList ID="answerOptions" runat="server">
    <asp:ListItem Text="A. Option 1" Value="1"></asp:ListItem>
    <asp:ListItem Text="B. Option 2" Value="2"></asp:ListItem>
    <asp:ListItem Text="C. Option 3" Value="3"></asp:ListItem>
    <asp:ListItem Text="D. Option 4" Value="4"></asp:ListItem>
</asp:RadioButtonList>

                <div class="mt-3">
                    <%--<asp:Button ID="previousButton" runat="server" Text="Previous" CssClass="btn" OnClick="PreviousButton_Click" />--%>
                    <asp:Button ID="nextButton" runat="server" Text="Next" CssClass="btn" OnClick="NextButton_Click" />

                    <!-- Submit Button -->
                    <asp:Button ID="submitButton" runat="server" class="btn" Text="Submit Answer" OnClick="SubmitButton_Click" />

                    <%--Finish Button--%>
                    <asp:Button ID="finishButton" runat="server" Text="Finish" OnClick="FinishButton_Click" CssClass="btn btn-primary" />
                </div>

            </div>
        </div>

        <!-- Courses area End -->

        <!-- ? services-area -->
        <div class="services-area services-area2 section-padding40">
            <div class="container">
                <div class="row justify-content-sm-center">
                    <div class="col-lg-4 col-md-6 col-sm-8">
                        <div class="single-services mb-30">
                            <div class="features-icon">
                                <img src="assets/img/icon/icon1.svg" alt="">
                            </div>
                            <div class="features-caption">
                                <h3>60+ UX courses</h3>
                                <p>The automated process all your website tasks.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6 col-sm-8">
                        <div class="single-services mb-30">
                            <div class="features-icon">
                                <img src="assets/img/icon/icon2.svg" alt="">
                            </div>
                            <div class="features-caption">
                                <h3>Expert instructors</h3>
                                <p>The automated process all your website tasks.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6 col-sm-8">
                        <div class="single-services mb-30">
                            <div class="features-icon">
                                <img src="assets/img/icon/icon3.svg" alt="">
                            </div>
                            <div class="features-caption">
                                <h3>Life time access</h3>
                                <p>The automated process all your website tasks.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
