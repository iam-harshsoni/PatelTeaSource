<%@ Page Title="" Language="C#" MasterPageFile="~/CS/Client.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="PatelTeaSource.CS.Products" %>

<%--<asp:Content ID="Content5" ContentPlaceHolderID="menu" runat="server">
  <div id="navbar" class="navbar-collapse collapse">
        <ul class="nav navbar-nav">
            <li id="li_Home"><a href="Default.aspx">Home</a></li>
            <li id="li_Abt"><a href="AboutUs.aspx" onclick="makeChange(2)" id="abt">About Us</a>
               
            </li>
            <li id="li_Products"  class="active"><a href="Products.aspx" onclick="makeChange(3)">Shop</a></li>
             <li id="li_Awards" ><a href="AwardsCertificate.aspx" onclick="makeChange(5)">Awards</a></li>
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
        <div class="page-header">
           <figure class="post-thumbnail">
                <img alt="" src="../Template/backGG.jpg" style="width: 100%;height: 140%;margin-top: 0%;"/>

            </figure>

            <h1 class="title">
                <span class="line-title">Our Teas<i class="fa">&#xf111;</i></span>
            </h1>
        </div>
       

          <section id="latest" class="section latest" style="margin-top: -50px;">
          
          <div class="container">
                <div class="row" style="margin-right:0;margin-left:0">
                    <div class="col-sm-12">
                        <h2 style="color:orange">Black Tea</h2>
                        <h3 style="font-size: 14px;" class="title line-title">If you feel drinking a cup of tea is the best part of your day, shouldn't you be drinking only the best tea? If your answer is a resounding ‘YES’, then you have come to the right place.<i class="fa">&#xf111;</i>
                        </h3>


                    </div>
                    <div class="row" >
                   
                       <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                         
                    </div>
                    </div>
                </div>
              </section>

     
    </div>
    
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footers" runat="server"></asp:Content>
