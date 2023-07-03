<%@ Page Title="" Language="C#" MasterPageFile="~/CS/Client.Master" AutoEventWireup="true" CodeBehind="EmptyCart.aspx.cs" Inherits="PatelTeaSource.CS.EmptyCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <div id="wrap">
        <div></div>
        <div class="page-header">
          <figure class="post-thumbnail">
                <img alt="" src="../Template/backGG.jpg" style="width: 100%;height: 140%;margin-top: 0%;"/>

            </figure>

            <h1 class="title">

                <span class="line-title">Empty Cart <i class="fa">&#xf111;</i></span>

            </h1>

        </div>

        <section class="design-process-section" id="process-tab">
            <div class="container" style="text-align:center">
                <img style="width: 235px;margin-top: 20px;margin-bottom: 20px;" src="../Template/images/Download/EmptyCart.png" />
                <br />
                <h3 style="font-family: century gothic;">
                    Unfortunately, Your Cart Is Empty
                </h3>
                <span style="font-family: century gothic;">Please add some item in your cart.</span>
                <br />
                <br />
                       <a class="hvr-rectangle-out btnCss" style="padding: 6px; width: 170px !important;margin-bottom: 20px;" href="Products.aspx"><i class="fa fa-mail-reply"></i>  Continue Shopping</a>
                            
            </div>

        </section>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footers" runat="server">
</asp:Content>
