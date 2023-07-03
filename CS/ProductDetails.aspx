<%@ Page Title="" Language="C#" MasterPageFile="~/CS/Client.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ProductDetails.aspx.cs" Inherits="PatelTeaSource.CS.ProductDetails" %>

<%--<asp:Content ID="Content5" ContentPlaceHolderID="menu" runat="server">
    <div id="navbar" class="navbar-collapse collapse">
        <ul class="nav navbar-nav">
            <li id="li_Home"><a href="Default.aspx">Home</a></li>
            <li id="li_Abt"><a href="AboutUs.aspx" onclick="makeChange(2)" id="abt">About Us</a>
                
            </li>
            <li id="li_Products" class="active"><a href="Products.aspx" onclick="makeChange(3)">Shop</a></li>
             <li id="li_Awards"><a href="AwardsCertificate.aspx" onclick="makeChange(5)">Awards</a></li>
               <li><a href="Contactus.aspx" onclick="makeChange(6)">Contact Us</a> </li>
            <li><a href="WhereToBuy.aspx" onclick="makeChange(7)">Locate Us</a> </li>
            <li id="li_MyAcc"><a href="MyAccount.aspx" >My Account</a>
            </li>
        </ul>
    </div>
</asp:Content>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style>
        .textBoxCSS {
            width: 100%;
            padding: 12px 20px;
            margin: 8px 0;
            display: inline-block;
            border: 1px solid lightgray;
            border-radius: 4px;
            box-sizing: border-box;
        }

            .textBoxCSS:hover {
                border: 1px solid #e27900;
            }
             
         
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <div id="main-content" class="main-content">
        <div class="row" style="margin-top: 50px">
            <div class="col-md-6">
                 
                <div style="margin-top: 60px; text-align: center;">
                  <img runat="server"  id="offerSaleImg" src="../Template/images/Download/sale.png" style="margin-top: -300px;" />
                    <img runat="server" id="pImg" style="width: 210px" src="" />
                    <img runat="server" style="margin-top:20px;width: 280px;" id="oImg" src="../Template/images/Download/bottleOfferOnProduct.png" />
                </div>
            </div>

            <div class="col-md-6">
                <div style="padding: 10px; text-align: justify;">
                    <h2 style="text-align: left">
                        <span style="color: black; font-size: 22px; word-spacing: 7px;">
                             <asp:Label ID="lblProductName" runat="server" Text=""></asp:Label></span>
                            
                        <hr style="border: 1px solid lightgray" />

                    </h2>
                    <label style="font-size: 20px; color: green">Available</label>
                    <br />

                    <br />
                    <label style="font-size: 20px">&#8377; <asp:Label ID="lblPrice" runat="server" Text="250.00/-"></asp:Label></label>
                    <span id="offerMRP" visible="false" runat="server">
                        <del> &#8377; <asp:Label ID="lblOfferDisc" runat="server" Text="250.00/-"></asp:Label></del></span>  
                 
                    <hr />
                    <b>Description:</b>
                    <ul>
                        <li>
                            <img style="width: 19px; margin-top: -5px;" src="../Template/images/Download/veg.svg" />
                            This is a <b style="color:green">Vegetarian</b> product.
                        </li>
                       <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    </ul>
                    <hr />

                    <div>
                        <asp:Button ID="btnAddToCart" class="hvr-rectangle-out btnCss" OnClick="btnAddToCart_Click" runat="server" Text="Add To Cart" />
                    </div>
                </div>


            </div>
        </div>
        <hr />
        <div class="row" id="nutDIV" runat="server">

            <div class="col-md-12" style="text-align: center">

                <h1 class="title line-title">Nutritional Information:<i class="fa">&#xf111;</i>
                </h1>
                <br />
                
                 <img runat="server" id="nutImgs" style="width: 450px"/>
            </div>
        </div>
    </div>
    <br />
    <br />

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footers" runat="server"></asp:Content>
