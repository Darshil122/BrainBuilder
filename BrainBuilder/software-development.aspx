<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="software-development.aspx.cs" Inherits="BrainBuilder.software_development" %>

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
                                    <h1 data-animation="bounceIn" data-delay="0.2s">Software Development</h1>
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
        <div class="d-flex justify-content-center p-5">
            <img src="assets/img/gallery/softwareDev.png" class="img-fluid" />
        </div>
        <div class="mt-3">
            <p>Software development is at the heart of modern innovation, transforming ideas into functional, user-friendly applications that drive businesses and enhance lives. From creating small-scale solutions to developing enterprise-level systems, software development fuels the digital revolution.</p>
            <h2 class="font-weight-bold">What is Software Development?</h2>
            <p>Software development is the process of designing, coding, testing, and maintaining software applications to meet specific requirements. It involves a combination of creativity, problem-solving, and technical expertise to build tools that address real-world challenges and create value for users.</p>
            <h3 class="font-weight-bold">Key Aspects of Software Development</h3>
            <ul>
                <li><p>Requirement Analysis</p></li>
                <li><p>Design and Architecture</p></li>
                <li><p>Coding and Development</p></li>
                <li><p>Testing and Debugging</p></li>
                <li><p>Deployment and Maintenance</p></li>
            </ul>
            <h3 class="font-weight-bold mb">Why is Software Development Important?</h3>
            <div class="single-features">
                <div class="features-icon">
                    <img src="assets/img/icon/right-icon.svg" alt=""/>
                </div>
                <div class="features-caption">
                    <p>Enables companies to automate processes, enhance productivity, and offer innovative solutions.</p>
                </div>
            </div>
            <div class="single-features">
                <div class="features-icon">
                    <img src="assets/img/icon/right-icon.svg" alt=""/>
                </div>
                <div class="features-caption">
                    <p> Builds applications that make life easier, from mobile apps to web platforms.</p>
                </div>
            </div>
            <div class="single-features">
                <div class="features-icon">
                    <img src="assets/img/icon/right-icon.svg" alt=""/>
                </div>
                <div class="features-caption">
                    <p>Pushes boundaries in areas like AI, blockchain, IoT, and cloud computing.</p>
                </div>
            </div>
            <h3 class="font-weight-bold">Start Your Software Journey Today!</h3>
            <p>At Brain Builder, we specialize in delivering tailored software solutions that cater to diverse industries. Our team of skilled developers focuses on creating robust, scalable, and secure applications that align with your goals.</p>
        </div>
        <div>
            <a href='Test.aspx?CourseID=1' class='btn'>Start Test</a>
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
