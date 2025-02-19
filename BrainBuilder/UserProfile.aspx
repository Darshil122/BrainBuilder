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
    <div class="row mt-5 mb-5">
        <!-- Profile Sidebar -->
        <div class="col-lg-4">
            <div class="card text-center p-4 shadow-lg">
                <img src="assets/img/profile/std.jpg" alt="Profile Picture" class="profile-img rounded-circle mb-3" width="150" style="margin-left:100px">
                <h3><%= Session["UserName"] %></h3>
                <p class="text-muted"><%= Session["UserEmail"] %></p>
                <a href="Account/Logout.aspx" class="btn btn-primary btn-sm mt-2">Logout</a>
            </div>
        </div>

        <!-- Profile Details & Certificates -->
        <div class="col-lg-8">
            <div class="card p-4 shadow-lg">
                <h2 class="mb-4">Profile Information</h2>
                <table class="table">
                    <tbody>
                        <tr>
                            <th>Name</th>
                            <td><%= Session["UserName"] %></td>
                        </tr>
                        <tr>
                            <th>Email</th>
                            <td><%= Session["UserEmail"] %></td>
                        </tr>
                    </tbody>
                </table>
            </div>

            <!-- Certificates Section -->
            <div class="card p-4 shadow-lg mt-4">
                <h2>Your Certificates</h2>
                <div class="row mt-3">
                    <% 
                        if (Session["UserCertificates"] != null)
                        {
                            List<string> certificates = (List<string>)Session["UserCertificates"];
                            foreach (string certPath in certificates)
                            { %>
                    <div class="col-md-6 text-center mb-4">
                        <div class="card p-3 shadow-lg border-0">
                            <img src="<%= certPath %>" class="img-fluid rounded" alt="Certificate">
                            <a href='DownloadCertificate.aspx?file=<%= HttpUtility.UrlEncode(certPath) %>'
                                class="btn btn-success mt-3 btn-sm">
                                <i class="fa fa-download"></i> Download
                            </a>
                        </div>
                    </div>
                    <% }
                        }
                        else
                        { %>
                    <div class="col-12 text-center">
                        <p class="text-muted">No certificates found.</p>
                    </div>
                    <% } %>
                </div>
            </div>
        </div>
    </div>
</div>

        </section>

    </main>
</asp:Content>
