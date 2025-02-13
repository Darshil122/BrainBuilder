<%@ Page Title="Profile Page" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="BrainBuilder.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>
        <section class="slider-area slider-area2">
            <div class="slider-active">
                <div class="single-slider slider-height2">
                    <div class="container">
                        <div class="row">
                            <div class="col-xl-8 col-lg-11 col-md-12">
                                <div class="hero__caption hero__caption2">
                                    <h1 data-animation="bounceIn" data-delay="0.2s">My Profile</h1>
                                    <nav aria-label="breadcrumb">
                                        <ol class="breadcrumb">
                                            <li class="breadcrumb-item"><a href="Default.aspx">Home</a></li>
                                            <li class="breadcrumb-item"><a href="Courses.aspx">Courses</a></li>
                                            <li class="breadcrumb-item"><a href="Profile.aspx">Profile</a></li>
                                        </ol>
                                    </nav>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <section class="profile-section">
            <div class="container">
                <div class="row">
                    <div class="col-lg-4">
                        <div class="profile-card text-center">
                            <img src="assets/img/profile/std.jpg" alt="Profile Picture" class="profile-img">
                        </div>
                    </div>
                    <div class="col-lg-8">
                        <div class="profile-details mt-50">
                            <h2>Profile Information</h2>
                            <div class="mt-5">
                                <th>Name</th>
                                <h3><%= Session["UserName"] %></h3>
                                <th>Email</th>
                                <p><%= Session["UserEmail"] %></p>
                            </div>

                            <div class="container mt-5">
                                <h2 class="text-center">Your Certificates</h2>
                                <div class="row">
                                    <% 
                                        if (Session["UserCertificates"] != null)
                                        {
                                            List<string> certificates = (List<string>)Session["UserCertificates"];
                                            foreach (string certPath in certificates)
                                            { %>
                                    <div class="col-md-4 text-center">
                                        <div class="card p-3 shadow-lg">
                                            <img src="<%= certPath %>" class="img-fluid rounded" alt="Certificate">
                                        </div>
                                    </div>
                                    <% }
                                         }
                                         else
                                         { %>
                                    <div class="col-12 text-center">
                                        <p>No certificates found.</p>
                                    </div>
                                    <% } %>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </section>

    </main>
</asp:Content>
