<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" EnableEventValidation="false" Inherits="PatelTeaSource.AdminSide.Forms.ForgetPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
      <title>Forget Password - Patel Tea Packers</title>
     

    <link rel="apple-touch-icon" sizes="60x60" href="../AdminSideTemplate/app-assets/images/ico/apple-icon-60.png">
    <link rel="apple-touch-icon" sizes="76x76" href="../AdminSideTemplate/app-assets/images/ico/apple-icon-76.png">
    <link rel="apple-touch-icon" sizes="120x120" href="../AdminSideTemplate/app-assets/images/ico/apple-icon-120.png">
    <link rel="apple-touch-icon" sizes="152x152" href="../AdminSideTemplate/app-assets/images/ico/apple-icon-152.png">
    <%--<link rel="shortcut icon" type="image/x-icon" href="../AdminSideTemplate/app-assets/images/ico/favicon.ico">--%>
    <%--<link rel="shortcut icon" type="image/png" href="../AdminSideTemplate/app-assets/images/ico/favicon-32.png">--%>
    <link rel="shortcut icon" type="image/png" href="../../Template/images/green-tea-leaf-png-3.png" />
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-touch-fullscreen" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="default">
    <!-- BEGIN VENDOR CSS-->
    <link rel="stylesheet" type="text/css" href="../AdminSideTemplate/app-assets/css/bootstrap.css">
    <!-- font icons-->
    <link rel="stylesheet" type="text/css" href="../AdminSideTemplate/app-assets/fonts/icomoon.css">
    <link rel="stylesheet" type="text/css" href="../AdminSideTemplate/app-assets/fonts/flag-icon-css/css/flag-icon.min.css">
    <link rel="stylesheet" type="text/css" href="../AdminSideTemplate/app-assets/vendors/css/extensions/pace.css">
    <!-- END VENDOR CSS-->
    <!-- BEGIN ROBUST CSS-->
    <link rel="stylesheet" type="text/css" href="../AdminSideTemplate/app-assets/css/bootstrap-extended.css">
    <link rel="stylesheet" type="text/css" href="../AdminSideTemplate/app-assets/css/app.css">
    <link rel="stylesheet" type="text/css" href="../AdminSideTemplate/app-assets/css/colors.css">
    <!-- END ROBUST CSS-->
    <!-- BEGIN Page Level CSS-->
    <link rel="stylesheet" type="text/css" href="../AdminSideTemplate/app-assets/css/core/menu/menu-types/vertical-menu.css">
    <link rel="stylesheet" type="text/css" href="../AdminSideTemplate/app-assets/css/core/menu/menu-types/vertical-overlay-menu.css">
    <link rel="stylesheet" type="text/css" href="../AdminSideTemplate/app-assets/css/pages/login-register.css">
    <!-- END Page Level CSS-->
    <!-- BEGIN Custom CSS-->
    <link rel="stylesheet" type="text/css" href="../AdminSideTemplate/assets/css/style.css">
</head>
<body data-open="click" data-menu="vertical-menu" data-col="1-column" class="vertical-layout vertical-menu 1-column  blank-page blank-page">
    <!-- ////////////////////////////////////////////////////////////////////////////-->

    <form id="form1" runat="server">
        <div class="app-content content container-fluid">
            <div class="content-wrapper">
                <div class="content-header row">
                </div>
                <div class="content-body">
                    <section class="flexbox-container">
                        <div class="col-md-4 offset-md-4 col-xs-10 offset-xs-1  box-shadow-2 p-0">
                            <div class="card border-grey border-lighten-3 m-0">
                                <div class="card-header no-border">
                                    <div class="card-title text-xs-center">
                                        <div class="p-1">
                                            <img src="../../Template/images/green-tea-leaf-png-3.png" alt="branding logo" style="width: 10%;"><span style="font-size: large"> Patel Tea Packers</span>
                                        </div>
                                    </div>
                                           <h6 class="card-subtitle line-on-side text-muted text-xs-center font-small-3 pt-2"><span>We will send you a link to reset your password.</span></h6>
        
                                </div>
                                 
                                <div class="card-body collapse in">

                                    <div class="card-block">
                                        <div class="row">
                                            <div class="alert alert-danger mb-2" id="errorDiv" visible="false" role="alert" runat="server">
                                                <strong>Oh snap!</strong>
                                                <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>

                                            </div>
                                        </div>
                                        <form class="form-horizontal form-simple" action="index.html" novalidate>
                                            <fieldset class="form-group position-relative has-icon-left mb-0">

                                                <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" class="form-control form-control-lg input-lg" placeholder="Your Email Address" required></asp:TextBox>
                                                <div class="form-control-position">
                                                     <i class="icon-mail6"></i>
                                                </div>
                                            </fieldset>
                                              <br />
                                                   <asp:Button ID="btnRecoverpassword" runat="server" OnClick="btnRecoverpassword_Click" class="btn btn-primary btn-lg btn-block" Text="Recover Password" />
                                              <br />
                                          
                                            <fieldset class="form-group row">
                                                <div class="col-md-6 col-xs-12 text-xs-center text-md-left">
                                                </div>
                                                <div class="col-md-6 col-xs-12 text-xs-center text-md-right"><a href="Login.aspx" class="card-link">Login here</a></div>
                                            </fieldset>
                                     
                                        </form>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </section>

                </div>
            </div>
        </div>
    </form>

    <!-- BEGIN VENDOR JS-->
    <script src="../AdminSideTemplate/app-assets/js/core/libraries/jquery.min.js" type="text/javascript"></script>
    <script src="../AdminSideTemplate/app-assets/vendors/js/ui/tether.min.js" type="text/javascript"></script>
    <script src="../AdminSideTemplate/app-assets/js/core/libraries/bootstrap.min.js" type="text/javascript"></script>
    <script src="../AdminSideTemplate/app-assets/vendors/js/ui/perfect-scrollbar.jquery.min.js" type="text/javascript"></script>
    <script src="../AdminSideTemplate/app-assets/vendors/js/ui/unison.min.js" type="text/javascript"></script>
    <script src="../AdminSideTemplate/app-assets/vendors/js/ui/blockUI.min.js" type="text/javascript"></script>
    <script src="../AdminSideTemplate/app-assets/vendors/js/ui/jquery.matchHeight-min.js" type="text/javascript"></script>
    <script src="../AdminSideTemplate/app-assets/vendors/js/ui/screenfull.min.js" type="text/javascript"></script>
    <script src="../AdminSideTemplate/app-assets/vendors/js/extensions/pace.min.js" type="text/javascript"></script>
    <!-- BEGIN VENDOR JS-->
    <!-- BEGIN PAGE VENDOR JS-->
    <!-- END PAGE VENDOR JS-->
    <!-- BEGIN ROBUST JS-->
    <script src="../AdminSideTemplate/app-assets/js/core/app-menu.js" type="text/javascript"></script>
    <script src="../AdminSideTemplate/app-assets/js/core/app.js" type="text/javascript"></script>
    <!-- END ROBUST JS-->
    <!-- BEGIN PAGE LEVEL JS-->
    <!-- END PAGE LEVEL JS-->

    <script type="text/javascript">

        // window.history.forward(1);
        $(document).ready(function () {
            window.history.pushState(null, "", window.location.href);
            window.onpopstate = function () {
                window.history.pushState(null, "", window.location.href);
            };
        });

    </script>


</body>

</html>
