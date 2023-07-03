<%@ Page Title="" Language="C#" MasterPageFile="~/CS/Client.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="PatelTeaSource.CS.RecoverPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<%--<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
     <div id="navbar" class="navbar-collapse collapse">
        <ul class="nav navbar-nav">
            <li id="li_Home"><a href="Default.aspx">Home</a></li>
            <li id="li_Abt"><a href="AboutUs.aspx" onclick="makeChange(2)" id="abt">About Us</a>
               
            </li>
            <li id="li_Products"><a href="Products.aspx" onclick="makeChange(3)">Shop</a></li>
            <li id="li_Awards"><a href="AwardsCertificate.aspx" onclick="makeChange(5)">Awards</a></li>
                        <li><a href="Contactus.aspx" onclick="makeChange(6)">Contact Us</a> </li>
            <li><a href="WhereToBuy.aspx" onclick="makeChange(7)">Locate Us</a> </li>
             <li id="li_MyAcc" class="active"><a href="MyAccount.aspx">My Account</a>
            </li>

        </ul>
    </div>
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="banner" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="main" runat="server">
  <div id="wrap">
        <div></div>
        <div class="page-header">
              <figure class="post-thumbnail">
                <img alt="" src="../Template/backGG.jpg" style="width: 100%;height: 140%;margin-top: 0%;"/>

            </figure>


            <h1 class="title">
                <span class="line-title">Recover Password<i class="fa">&#xf111;</i></span>
            </h1>

        </div>

        <section class="design-process-section" id="process-tab">

            <div class="container">
                <div>
                    <br />
                    <div class="alert alert-danger mb-2" id="errorDiv" visible="false" role="alert" runat="server">
                        <strong>Oh snap!</strong>
                        <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
                        <a href="MyAccount.aspx" runat="server" id="ancError" visible="false">Click Here to go back</a>
                    </div>

                    <div class="alert alert-success mb-2" id="successDiv" visible="false" role="alert" runat="server">
                        <strong>Success!</strong>
                        <asp:Label ID="lblSuccess" runat="server" Text="Label"></asp:Label>

                    </div>
                     <div class="row" id="resetPassword" runat="server">
                        <div class="col-md-3"></div>
                        <div class="col-md-6">
                            <div class="section" id="resetPwdThis" style="width: 100%; padding: 20px; padding-top: 20px; visibility: visible">

                                <h3 class="title">
                                    <span class="line-title">Reset Password<i class="fa">&#xf111;</i></span>
                                </h3>
                                

                                <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="Your New Password*"></asp:TextBox>
                                <span style="color: red" id="errorNewPasswordSpan" runat="server" visible="false">Enter Password*.</span>
                                <br />

                                <asp:TextBox ID="txtConfirmPwdReset" runat="server" TextMode="Password" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="Your Password Again*"></asp:TextBox>
                                <span style="color: red" id="errorConfirmPwdResetSpan" runat="server" visible="false">Enter Password Again*.</span>
                                 <span style="color: red" id="errorSpans">Confirm Password Mismatched. Enter Password again. </span>
                           
                                <br />
                                <asp:Button ID="btnResetPassword" OnClick="btnResetPassword_Click" CssClass="hvr-rectangle-out btnCss" runat="server" Text="Reset Password" />
                                <br />
                                <br />
                                <a id="ancLoginBack" style="cursor: pointer" href="MyAccount.aspx">Go back to Login</a>
                            </div>

                        </div>
                        <div class="col-md-3"></div>
                    </div>
                    </div>
                </div>
            </section>
      </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="footers" runat="server">
    <script>
        var txtNewPassword = $("#" + "<%= txtNewPassword.ClientID %>");
        var txtConfirmPwdReset = $("#" + "<%= txtConfirmPwdReset.ClientID %>");
        var btnResetPassword = $("#" + "<%= btnResetPassword.ClientID %>");

        $(document).ready(function () {
            $("#errorSpans").hide();
            txtConfirmPwdReset.change(function () {
                
                if (txtConfirmPwdReset.val() != txtNewPassword.val()) {
                    txtConfirmPwdReset.focus();
                    txtConfirmPwdReset.val("");
                    $("#errorSpans").show();
                   // btnResetPassword.attr("disabled", "disabled");
                    }
                    else {
                        $("#errorSpans").hide();
                    }
             
            });

        });
    </script>
</asp:Content>
