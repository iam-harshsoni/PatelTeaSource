<%@ Page Title="" Language="C#" MasterPageFile="~/CS/Client.Master" AutoEventWireup="true" CodeBehind="AwardsCertificate.aspx.cs" Inherits="PatelTeaSource.CS.AwardsCertificate" %>

<%--<asp:Content ID="Content5" ContentPlaceHolderID="menu" runat="server">
  <div id="navbar" class="navbar-collapse collapse">
        <ul class="nav navbar-nav">
            <li id="li_Home"><a href="Default.aspx">Home</a></li>
            <li id="li_Abt"><a href="AboutUs.aspx" id="abt">About Us</a>
               
            </li>
            <li id="li_Products"><a href="Products.aspx">Shop</a></li>
             <li id="li_Awards"  class="active" ><a href="AwardsCertificate.aspx">Awards</a></li>
                        <li><a href="Contactus.aspx">Contact Us</a> </li>
            <li><a href="WhereToBuy.aspx">Locate Us</a> </li>
              <li id="li_MyAcc"><a href="MyAccount.aspx" >My Account</a>
            </li> 
        </ul>
    </div>
</asp:Content>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- <style>
        img {
            cursor: zoom-in;
        }
    </style>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="banner" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div id="wrap">
        <div></div>
        <div class="page-header">
           <figure class="post-thumbnail">
                <img alt="" src="../Template/backGG.jpg" style="width: 100%;height: 140%;margin-top: 0%;"/>

            </figure>

            <h1 class="title">

                <span class="line-title">Certificates<i class="fa">&#xf111;</i></span>

            </h1>

        </div>
        <section id="latest" class="section latest">
            <div class="container">
                <div class="row" style="margin-right:0;margin-left:0">
                    <div class="col-sm-12">
                        <h3 style="font-size: 14px;" class="title line-title">If you feel drinking a cup of tea is the best part of your day, shouldn't you be drinking only the best tea? If your answer is a resounding ‘YES’, then you have come to the right place.<i class="fa">&#xf111;</i>
                        </h3>


                    </div>
                    <div class="row" >
                   
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                         
                    </div>
                    </div>
                </div>
        </section>


        <%--<div class="modal fade" id="enlargeImageModal" tabindex="-1" role="dialog" aria-labelledby="enlargeImageModal" aria-hidden="true">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header" style="padding:18px 18px 0px 15px !important">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">×</span></button>
                    </div>
                    <br />
                    <div class="modal-body">
                        <img src="" class="enlargeImageModalSource" style="width: 100%;">
                    </div>
                </div>
            </div>
        </div>--%>
        
    </div>


</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footers" runat="server">
   <%-- <script src="../Template/assets/js/vendor/bootstrap.min.js"></script>--%>
  <%--  <script>
        $(function () {
            $('img').on('click', function () {
                $('.enlargeImageModalSource').attr('src', $(this).attr('src'));
                $('#enlargeImageModal').modal('show');
            });
        });
    </script>--%>
</asp:Content>
