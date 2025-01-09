<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="machine-learning.aspx.cs" Inherits="BrainBuilder.machine_learning" %>

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
                                    <h1 data-animation="bounceIn" data-delay="0.2s">Machine Learning</h1>
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
<div class="courses-area section-padding25 fix">
    <div class="container mt-5 p-5 bg-white rounded shadow position-relative">
        <!-- Question Section -->
        <div id="question-section" class="d-flex justify-content-between align-items-center mb-4">
            <h3 class="fw-bold" id="question-title">Question 1</h3>
            <div class="text-danger fw-bold" id="timer">
                Time Left: 0:30
            </div>
        </div>
            <p id="question-text">
                The arithmetic mean of the 5 consecutive integers starting with 's' is 'a'. 
                What is the arithmetic mean of 9 consecutive integers that start with s + 2?
            </p>
        

        <!-- Options Section -->
        <div id="options-section">
            <div class="form-check mb-3">
                <input class="form-check-input" type="radio" name="answer" id="option1" value="78">
                <label class="form-check-label" for="option1">A. 78</label>
            </div>
            <div class="form-check mb-3">
                <input class="form-check-input" type="radio" name="answer" id="option2" value="58">
                <label class="form-check-label" for="option2">B. 58</label>
            </div>
            <div class="form-check mb-3">
                <input class="form-check-input" type="radio" name="answer" id="option3" value="68">
                <label class="form-check-label" for="option3">C. 68</label>
            </div>
            <div class="form-check mb-3">
                <input class="form-check-input" type="radio" name="answer" id="option4" value="98">
                <label class="form-check-label" for="option4">D. 98</label>
            </div>
        </div>

        <!-- Navigation Button -->
        <button class="btn mt-3" id="next-button">Next</button>
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
