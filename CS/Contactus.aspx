<%@ Page Title="" Language="C#" MasterPageFile="~/CS/Client.Master" AutoEventWireup="true" CodeBehind="Contactus.aspx.cs" Inherits="PatelTeaSource.CS.Contactus" EnableEventValidation="False" %>

<%--<asp:Content ID="Content5" ContentPlaceHolderID="menu" runat="server">
    <div id="navbar" class="navbar-collapse collapse">
        <ul class="nav navbar-nav">
            <li id="li_Home"><a href="Default.aspx">Home</a></li>
            <li id="li_Abt"><a href="AboutUs.aspx" onclick="makeChange(2)" id="abt">About Us</a>
                
            </li>
            <li id="li_Products"><a href="Products.aspx" onclick="makeChange(3)">Shop</a></li>
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
        /*.textBoxCSS {
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
            }*/
        .txtBoxStyle {
            font-size: 15px;
            height: 40px;
        }
    </style>
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
                <span class="line-title">Contact Us<i class="fa">&#xf111;</i></span>
            </h1>
        </div>
        <div class="page-content">
            <div class="container" style="font-family: 'Open Sans', sans-serif;">
                     
                <div class="row">

                    <div class="col-md-3 col-md-push-9">
                        <div class="sidebar">
                            <div class="widget">
                                <div class="widget-inner">
                                    <h3 class="title">Contacts Info</h3>
                                    <div class="widget-text">
                                        <p>Interested in carrying our handcrafted specialty estate teas and blends in your fine establishment?</p>
                                        <p>
                                            <p>
                                                <strong>Corporate Address:</strong><br />
                                                PATEL TEA PACKERS
                                                <br />
                                                Unava  Bypass Highway, At. &, Dist. Mehsana,(North Gujarat) INDIA
                                            </p>
                                            <p>
                                                <strong>Factory Address:</strong><br />
                                                PATEL TEA PACKERS
                                                <br />
                                                Unava  Bypass Highway, At. &, Dist. Mehsana,(North Gujarat) INDIA
                                            </p>
                                            <strong>General Inquiries:</strong>	 <a href="mailto:pateltea@ymail.com">pateltea@ymail.com</a><br />
                                            <%--<strong>Sales Inquiries:</strong>	 <a href="mailto:sales@pateltea.co.in">sales@pateltea.co.in</a><br />--%>
                                            <strong>Phone:</strong>	 (+91)-98791-86082
                                            <strong>Customer Care:</strong> (+91)-2767-247936    	
                                        </p>

                                    </div>
                                </div>
                            </div>

                            <div class="widget">
                                <div class="widget-inner">
                                    <h3 class="title">Store Hours</h3>
                                    <div class="widget-text">
                                        <div class="row">
                                            <div class="col-xs-8 col-sm-7">Monday - Saturday</div>
                                            <div class="col-xs-4 col-sm-5">9 am - 7 pm</div>

                                            <%--<div class="col-xs-8 col-sm-7">Friday</div>
												<div class="col-xs-4 col-sm-5">8 am - 6 pm</div>
												
												<div class="col-xs-8 col-sm-7">Saturday</div>
												<div class="col-xs-4 col-sm-5">9 am - 5 pm</div>--%>

                                            <div class="col-xs-8 col-sm-7">Sunday &amp; Holidays</div>
                                            <div class="col-xs-4 col-sm-5">Closed</div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                   <section class="design-process-section" id="process-tab">
                        <div class="col-md-9  col-md-pull-3">
                            <div class="contact-content">
                                <div id="sendMail" runat="server">
                                    <h3 class="title">
                                        <span class="line-title">Say Hello<i class="fa">&#xf111;</i></span>
                                    </h3>
                                    <p class="contact-desc">We hate being all business, despite running one. So whether you had a good experience, a bad one or just want a tea suggestion, do contact us. Or if you'd rather go through our FAQ and save time, please do..</p>

                                    <div class="row">
                                        <div class="col-sm-6">
                                            <p class="contact-form-author">
                                                <asp:TextBox ID="txtName" runat="server" MaxLength="30" CssClass="txtBoxStyle form-control form-control-lg input-lg" placeholder="Name" Font-Size="Larger"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtname"  ErrorMessage="Please enter your name." ForeColor="Red"></asp:RequiredFieldValidator>
                                            </p>
                                        </div>

                                        <div class="col-sm-6">
                                            <p class="contact-form-subject">
                                                <asp:TextBox ID="txtSub" runat="server" CssClass="txtBoxStyle form-control form-control-lg input-lg" placeholder="Subject" Font-Size="Larger"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSub"  ErrorMessage="Please enter subject." ForeColor="Red"></asp:RequiredFieldValidator>
                                            </p>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6">
                                            <p class="contact-form-email">
                                                <asp:TextBox ID="txtEmail" runat="server" CssClass="txtBoxStyle form-control form-control-lg input-lg" placeholder="Email" Font-Size="Larger"></asp:TextBox>

                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail"  ErrorMessage="Please enter your E-Mail address." ForeColor="Red"></asp:RequiredFieldValidator>
                                            </p>
                                        </div>

                                        <div class="col-sm-6">
                                            <p class="contact-form-subject">
                                                <asp:TextBox ID="txtMob" TextMode="Number"  MaxLength="10" runat="server" CssClass="txtBoxStyle form-control form-control-lg input-lg" placeholder="Mobile" Font-Size="Larger"></asp:TextBox>

                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMob"  ErrorMessage="Please enter your mobile number." ForeColor="Red"></asp:RequiredFieldValidator>
                                            </p>
                                        </div>

                                    </div>
                                    <p class="contact-form-message">
                                        <asp:TextBox ID="txtMessage" runat="server" CssClass="txtBoxStyle form-control form-control-lg input-lg" placeholder="Message" TextMode="MultiLine" Rows="5" Style="resize: none;" Font-Size="Larger"></asp:TextBox>

                                        
                                                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtMessage"  ErrorMessage="Please enter your message." ForeColor="Red"></asp:RequiredFieldValidator>
                                    </p>
                                    <p class="form-submit button">
                                        <%--<button class="hvr-rectangle-out btnCss" type="submit" id="submit"
                                        name="submit">
                                        Send Message</button>
                                        <asp:Button ID="submits" runat="server" Text="SEND MESSAGE"  class="hvr-rectangle-out btnCss" style="width: 200px;" />--%>
  <button type="button" class="hvr-rectangle-out btnCss" style="width: 200px;" >SEND MESSAGE</button>


                                    </p>

                                </div>

                                <div id="AfterSendMail" runat="server" visible="false">
                                    <h3 class="title contact-title">Thanks for showing your interest in Patel Tea Packers. Our team member will contact you soon.</h3>
                                </div>
                            </div>

                        </div>
                    </section>
              
                </div>
            </div>


            <div class="mapouter">
                <div class="gmap_canvas">
                    <%--<iframe width="1500" height="500" id="gmap_canvas" src="https://maps.google.com/maps?q=Patel%20Tea%20Packers%20Unava&t=&z=13&ie=UTF8&iwloc=&output=embed" frameborder="0" scrolling="no" marginheight="0" marginwidth="0"></iframe>--%>
                    <a href="https://www.crocothemes.net"></a>

                    <div style="width: 100%">
                        <iframe width="100%" height="600" id="gmap_canvas" src="https://maps.google.com/maps?width=100%&amp;height=600&amp;hl=en&amp;coord=23.770065, 72.369814&amp;q=+(Patel%20Tea%20Packers)&amp;ie=UTF8&amp;t=h&amp;z=18&amp;iwloc=B&amp;output=embed" frameborder="0" scrolling="no" marginheight="0" marginwidth="0"><a href="https://www.maps.ie/create-google-map/">Add map to website</a></iframe>
                    </div>
                    <br />

                </div>
                <style>
                    .mapouter {
                        text-align: right;
                        height: 500px;
                        width: 600px;
                    }

                    .gmap_canvas {
                        overflow: hidden;
                        background: none !important;
                        height: 498px;
                        width: 1339px;
                    }
                </style>
            </div>


        </div>

    </div>


    <script src="https://maps.googleapis.com/maps/api/js"></script>
    <script src="../Template/assets/js/main.js"></script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="footers" runat="server">
   <script>
        var txtMobileShipping = $("#" + "<%= txtMob.ClientID %>");

        txtMobileShipping.on('keypress', function (event) {
            var regex = new RegExp("^[0-9\b\u0000]+$");
            var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
            if (!regex.test(key)) {
                event.preventDefault();
                return false;
            }

        });
        $(document).ready(function () {
            $("button").click(function () {
                location.reload(true);

                $("sendMail").hide();
                $("AfterSendMail").show();

            });
        });
    </script>
</asp:Content>
