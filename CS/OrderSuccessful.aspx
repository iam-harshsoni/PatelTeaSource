<%@ Page Title="" Language="C#" MasterPageFile="~/CS/Client.Master" AutoEventWireup="true" CodeBehind="OrderSuccessful.aspx.cs" Inherits="PatelTeaSource.CS.OrderSuccessful" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Template/assets/css/cartStyle.css" rel="stylesheet" />
    <style>
        .txtBoxStyle {
            font-size: 15px;
            height: 40px;
        }
    </style>

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
             <li id="li_MyAcc"><a href="MyAccount.aspx">My Account</a>
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

                <span class="line-title">Order Placed<i class="fa">&#xf111;</i></span>

            </h1>

        </div>

        <section class="design-process-section" id="process-tab">
            <div class="container">
                <div class="row">
                    <div class="col-xs-12">
                        <!-- design process steps-->
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs process-model more-icon-preocess" style="text-align: center !important; max-width: 100% !important" role="tablist">
                            <li role="presentation" class="active">

                                <a href="#" id="ancCart" aria-controls="strategy" role="tab"><i class="fa fa-credit-card " aria-hidden="true"></i>
                                    <p>Your Cart</p>
                                </a>

                            </li>
                            <li role="presentation" class="active"><a href="#" id="ancCheckOut" onclick="checkIt()" aria-controls="checkOut" role="tab"><i class="fa fa-credit-card " aria-hidden="true"></i>
                                <p>Checkout</p>
                            </a></li>
                            <li role="presentation" class="active"><a href="OrderSuccessful.aspx" id="ancCompleted" aria-controls="optimization" role="tab"><i class="fa fa-check-square-o " aria-hidden="true"></i>
                                <p>Completed</p>
                            </a></li>

                        </ul>

                        <!-- end design process steps-->
                        <!-- Tab panes -->
                        <div style="text-align: center">


                            <div class="row">
                                <div class="col-md-12">
                                    <img style="width:150px;" src="../Template/checkCircle.gif" />
                                    <br />
                                    <span style="color: green; font-size: xx-large">Congratulations!</span>

                                    <br />
                                     <br />
                                    <h3 style="font-family: century gothic;">
                  Your Order Has been Successfully Placed. Click below button to view details
                </h3>
              
 
                                 
                                    <br />
                                    <asp:Button ID="btnClickHere"  OnClick="btnClickHere_Click" style="padding: 6px; width: 170px !important;margin-bottom: 20px;" runat="server" CssClass="hvr-rectangle-out btnCss" Text="My Accounts" />
                                </div>


                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </section>

    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="footers" runat="server">
</asp:Content>
