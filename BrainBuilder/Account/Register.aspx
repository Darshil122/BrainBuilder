﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BrainBuilder.Account.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register page</title>
     <!-- CSS here -->
    <link rel="stylesheet" href="../assets/css/bootstrap.min.css" />
    <link rel="stylesheet" href="../assets/css/owl.carousel.min.css" />
    <link rel="stylesheet" href="../assets/css/slicknav.css" />
    <link rel="stylesheet" href="../assets/css/flaticon.css" />
    <link rel="stylesheet" href="../assets/css/progressbar_barfiller.css" />
    <link rel="stylesheet" href="../assets/css/gijgo.css" />
    <link rel="stylesheet" href="../assets/css/animate.min.css" />
    <link rel="stylesheet" href="../assets/css/animated-headline.css" />
    <link rel="stylesheet" href="../assets/css/magnific-popup.css" />
    <link rel="stylesheet" href="../assets/css/fontawesome-all.min.css" />
    <link rel="stylesheet" href="../assets/css/themify-icons.css" />
    <link rel="stylesheet" href="../assets/css/slick.css" />
    <link rel="stylesheet" href="../assets/css/nice-select.css" />
    <link rel="stylesheet" href="../assets/css/style.css" />
    <style>
    .bg-img {
    background: url('../assets/img/bg_login.jpg') no-repeat center center fixed;
    background-size: cover;
    height: 100vh;
    display: flex;
    justify-content: center;
    align-items: center;
}

    </style>
</head>
<body>
    <main class="login-body bg-img">
    <!-- Login Admin -->
    <form runat="server" class="form-default" method="post">
        
        <div class="login-form">
            <h2>Registration Here</h2>

            <div class="form-input">
                <label for="name">Full name</label>
                <input  type="text" name="name" placeholder="Full name" id="name" runat="server"/>
                <asp:Label ID="Namerror" runat="server" CssClass="text-danger" Visible="false" Text="Please enter your name."></asp:Label>
            </div>
            <div class="form-input">
                <label for="name">Email Address</label>
                <input type="email" name="email" id="email" placeholder="Email Address" runat="server"/>
                <asp:Label ID="Emailerror" runat="server" CssClass="text-danger" Visible="false" Text="Please enter your email."></asp:Label>
            </div>
            <div class="form-input">
                <label for="name">Password</label>
                <input type="password" name="password" id="password" placeholder="Password" runat="server"/>
                <asp:Label ID="Passerror" runat="server" CssClass="text-danger" Visible="false" Text="Please enter password."></asp:Label>
            </div>
            <div class="form-input">
                <label for="name">Confirm Password</label>
                <input type="password" name="password" id="confirmPassword" placeholder="Confirm Password" runat="server"/>
                <asp:Label ID="cpasserror" runat="server" CssClass="text-danger" Visible="false" Text="Please enter your confirm password."></asp:Label>
                <asp:Label ID="cppasserror" runat="server" CssClass="text-danger" Visible="false" Text="Both password doesn't match."></asp:Label>
            </div>
            <div class="form-input">
                <input type="submit" runat="server" name="submit" OnServerClick="RegisterUser" value="Registration"/>
            </div>
            <a href="Login.aspx" class="text-white">Already you have Registration?</a>
        </div>
    </form>
    <!-- /end login form -->
</main>
     <script src="../assets/js/vendor/modernizr-3.5.0.min.js"></script>
    <!-- Jquery, Popper, Bootstrap -->
    <script src="../assets/js/vendor/jquery-1.12.4.min.js"></script>
    <script src="../assets/js/popper.min.js"></script>
    <script src="../assets/js/bootstrap.min.js"></script>
    <!-- Jquery Mobile Menu -->
    <script src="../assets/js/jquery.slicknav.min.js"></script>

    <!-- Video bg -->
    <script src="../assets/js/jquery.vide.js"></script>

    <!-- Jquery Slick , Owl-Carousel Plugins -->
    <script src="../assets/js/owl.carousel.min.js"></script>
    <script src="../assets/js/slick.min.js"></script>
    <!-- One Page, Animated-HeadLin -->
    <script src="../assets/js/wow.min.js"></script>
    <script src="../assets/js/animated.headline.js"></script>
    <script src="../assets/js/jquery.magnific-popup.js"></script>

    <!-- Date Picker -->
    <script src="../assets/js/gijgo.min.js"></script>
    <!-- Nice-select, sticky -->
    <script src="../assets/js/jquery.nice-select.min.js"></script>
    <script src="../assets/js/jquery.sticky.js"></script>
    <!-- Progress -->
    <script src="../assets/js/jquery.barfiller.js"></script>

    <!-- counter , waypoint,Hover Direction -->
    <script src="../assets/js/jquery.counterup.min.js"></script>
    <script src="../assets/js/waypoints.min.js"></script>
    <script src="../assets/js/jquery.countdown.min.js"></script>
    <script src="../assets/js/hover-direction-snake.min.js"></script>

    <!-- contact js -->
    <script src="../assets/js/contact.js"></script>
    <script src="../assets/js/jquery.form.js"></script>
    <script src="../assets/js/jquery.validate.min.js"></script>
    <script src="../assets/js/mail-script.js"></script>
    <script src="../assets/js/jquery.ajaxchimp.min.js"></script>

    <!-- Jquery Plugins, main Jquery -->
    <script src="../assets/js/plugins.js"></script>
    <script src="../assets/js/main.js"></script>
</body>
</html>
