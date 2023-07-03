<%@ Page Title="" Language="C#" MasterPageFile="~/CS/Client.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="WhereToBuy.aspx.cs" Inherits="PatelTeaSource.CS.WhereToBuy" %>

<%--<asp:Content ID="Content5" ContentPlaceHolderID="menu" runat="server">
    <div id="navbar" class="navbar-collapse collapse">
        <ul class="nav navbar-nav">
            <li id="li_Home"><a href="Default.aspx">Home</a></li>
            <li id="li_Abt"><a href="AboutUs.aspx" onclick="makeChange(2)" id="abt">About Us</a>
               
            </li>
            <li id="li_Products" ><a href="Products.aspx" onclick="makeChange(3)">Shop</a></li>
             <li id="li_Awards" ><a href="AwardsCertificate.aspx" onclick="makeChange(5)">Awards</a></li>
                        <li><a href="Contactus.aspx" onclick="makeChange(6)">Contact Us</a> </li>
            <li><a href="WhereToBuy.aspx" onclick="makeChange(7)">Locate Us</a> </li>
              <li id="li_MyAcc"><a href="MyAccount.aspx" >My Account</a>
            </li>
           
        </ul>
    </div>
</asp:Content>--%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <div id="wrap">
        <%--<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script>--%>
        <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCK3ReWUlrRRZj5s2XMHN3dmRhd3ZX7cRA&callback=initMap" async defer></script>

        <div></div>
        <div class="page-header">
          <figure class="post-thumbnail">
                <img alt="" src="../Template/backGG.jpg" style="width: 100%;height: 140%;margin-top: 0%;"/>

            </figure>

            <h1 class="title">
                <span class="line-title">Where To Buy<i class="fa">&#xf111;</i></span>
            </h1>
        </div>
        <div class="page-content">
            <div class="container">
                <div style="text-align: center">

                    <h2 style="color: orange; font-size: 40px">Patel Tea Packers Authorised Stores</h2>
                    <h3 class="title line-title" style="font-size: 17px">
                        <span>Find Patel Tea Packers Authorized Store Near You <i class="fa">&#xf111;</i></span>
                    </h3>
                </div>

                <script type="text/javascript">
                    var markers = [
                    <asp:Repeater ID="rptMarkers" runat="server">
                    <ItemTemplate>
                             {
                                 "title": '<%# Eval("Name") %>',
                                 "lat": '<%# Eval("locLat") %>',
                                 "lng": '<%# Eval("locLong") %>',
                                 "description": '<%# Eval("Name") %>'
                             }
    </ItemTemplate>
    <SeparatorTemplate>
        ,
    </SeparatorTemplate>
                    </asp:Repeater>
                    ];
                </script>
                <script type="text/javascript">

                    window.onload = function () {
                        var mapOptions = {
                            center: new google.maps.LatLng(28.7041, 77.1025),
                            zoom: 5,
                            mapTypeId: google.maps.MapTypeId.ROADMAP,
                            
                        };
                        var infoWindow = new google.maps.InfoWindow();
                        var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);
                        for (i = 0; i < markers.length; i++) {
                            var data = markers[i]
                            var myLatlng = new google.maps.LatLng(data.lat, data.lng);
                            var marker = new google.maps.Marker({
                                position: myLatlng,
                                map: map,
                                title: data.title
                            });
                            (function (marker, data) {
                                google.maps.event.addListener(marker, "click", function (e) {
                                    infoWindow.setContent(data.description);
                                    infoWindow.open(map, marker);
                                });
                            })(marker, data);
                        }
                    }
                </script>
                <div class="row">
                    <div id="dvMap" style="width: 100%; height: 500px">
                    </div>
                </div>
                <br />

                <%-- <div class="row">
                    <div class="col-md-6">
                        State:
                        <asp:DropDownList ID="DropDownList1" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                        </asp:DropDownList>

                    </div>
                    <div class="col-md-6">
                        City:
                        <asp:DropDownList ID="DropDownList2" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>
                    </div>


                </div>
                
                <br />
                <div class="row">
                   

                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </div>--%>
                <br />
                <br />
            </div>
        </div>
    </div>


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footers" runat="server">
</asp:Content>
