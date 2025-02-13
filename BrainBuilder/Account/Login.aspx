<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BrainBuilder.Account.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login page</title>
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
</head>
<body>
    <main class="login-body bg-">  
        <!-- Login Admin -->
        <form id="loginForm" runat="server">
            <div class="login-form">
                <h2>Login Here</h2>
                <div class="form-input">
                    <label for="email">Email</label>
                    <asp:TextBox ID="email" name="email" runat="server" Class="form-control" placeholder="Email"></asp:TextBox>
                    <asp:Label ID="Emailerror" runat="server" CssClass="text-danger" Visible="false" Text="Please enter valid email."></asp:Label>
                </div>
                <div class="form-input">
                    <label for="password">Password</label>
                    <asp:TextBox ID="password" name="password" runat="server" TextMode="Password" Class="form-control" placeholder="Password"></asp:TextBox>
                    <asp:Label ID="Passerror" runat="server" CssClass="text-danger" Visible="false" Text="Please enter valid password"></asp:Label>
                </div>
                <div class="form-input">
                    <asp:Button ID="btnLogin" runat="server" Class="btn btn-primary" Text="Log in" OnClick="LoginUser"/>
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>

                </div>
                <!-- Forget Password -->
                <a href="../Default.aspx" class="forget">Forget Password</a>
                <!-- Registration -->
                <a href="Register.aspx" class="registration">Registration</a>
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
