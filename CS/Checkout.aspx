<%@ Page Title="" Language="C#" MasterPageFile="~/CS/Client.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Checkout.aspx.cs" Inherits="PatelTeaSource.CS.Checkout" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Template/assets/css/cartStyle.css" rel="stylesheet" />

    <style>
        .txtBoxStyle {
            font-size: 15px;
            height: 40px;
        }
    </style>

    <script src="http://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>
    <!-- this meta viewport is required for BOLT //-->
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">
    <!-- BOLT Sandbox/test //-->
    <script id="bolt" src="https://sboxcheckout-static.citruspay.com/bolt/run/bolt.min.js" bolt-color="e34524" bolt-logo="../Template/17.png"></script>
    <!-- BOLT Production/Live //-->
    <%--<script id="bolt" src="https://checkout-static.citruspay.com/bolt/run/bolt.min.js" bolt-color="e34524" bolt-logo="../Template/17.png"></script>--%>
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
            <li id="li_MyAcc" class="active"><a href="MyAccount.aspx"><i class="fa fa-user"></i> My Account</a></li>
         

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

                <span class="line-title">Checkout<i class="fa">&#xf111;</i></span>

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

                                <a href="Cart.aspx" id="ancCart" aria-controls="strategy" role="tab"><i class="fa fa-credit-card " aria-hidden="true"></i>
                                    <p>Your Cart</p>
                                </a>

                            </li>
                            <li role="presentation" class="active"><a href="Checkout.aspx" id="ancCheckOut" onclick="checkIt()" aria-controls="checkOut" role="tab"><i class="fa fa-credit-card " aria-hidden="true"></i>
                                <p>Checkout</p>
                            </a></li>
                            <li role="presentation"><a href="#" id="ancCompleted" aria-controls="optimization" role="tab"><i class="fa fa-check-square-o " aria-hidden="true"></i>
                                <p>Completed</p>
                            </a></li>

                        </ul>
                        <!-- end design process steps-->
                        <!-- Tab panes -->
                        <br />
                       
                        <div class="alert alert-danger mb-2" id="errorDiv" visible="false" role="alert" runat="server">
                            <strong>Oh snap!</strong>
                            <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>

                        </div>
                        <p style="text-align: center; font-size: 20px; margin-bottom: 15px;" runat="server" id="loginPart">
                            Already a member?
                          
                            <a data-toggle="collapse" onclick="hideForgetpwd()" style="color: orange" href="#multiCollapseExample2" role="button" aria-expanded="false" aria-controls="collapseExample">Click here to login
                            </a>
                        </p>

                    </div>

                </div>

                <div class="row">
                    <div class="col-md-3">
                        <div class="collapse multi-collapse" id="multiCollapseExample1">
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="collapse multi-collapse" id="multiCollapseExample2">
                            <div class="section info-recipe" id="loginThis" style="width: 100%; padding: 20px; padding-top: 20px;">
                                <span>If you have shopped with us before, please enter your details below. If you are a new customer, please proceed to the Billing & Shipping section.</span>
                                <br />
                                <br />
                                <asp:TextBox ID="txtEmailUsername" MaxLength="30" TextMode="Email" runat="server" class="form-control form-control-lg input-lg" placeholder="Your Email Address"></asp:TextBox>
                                <span style="color: red" id="errorEmailUserNameSpan" runat="server" visible="false">Enter Email Address*.</span>
                                <br />
                                <asp:TextBox ID="txtPasswordLogin" MaxLength="16" TextMode="Password" runat="server" class="form-control form-control-lg input-lg" placeholder="Your Password"></asp:TextBox>
                                <span style="color: red" id="errorUserPwdSpan" runat="server" visible="false">Enter Password*.</span>
                                <br />
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:Button ID="btnLogin" OnClick="btnLogin_Click" CssClass="hvr-rectangle-out btnCss" runat="server" Text="Login" />
                                    </div>
                                    <div class="col-md-6" style="text-align: right">
                                        <a id="ancForgetPwd" style="cursor: pointer" onclick="showData()">Forgot Password?</a>
                                    </div>
                                </div>
                            </div>

                            <div class="section info-recipe" id="forgetPasswordThis" style="width: 100%; padding: 20px; padding-top: 20px">
                                <h3 style="margin-bottom: 20px">Recover your password.</h3>

                                <asp:TextBox ID="txtEmailRecover" runat="server" MaxLength="16" class="form-control form-control-lg input-lg" placeholder="Your Email Address"></asp:TextBox>
                                <span style="color: red" id="errorEmailRecoverSpan" runat="server" visible="false">Enter Email Address*.</span>
                                <br />
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:Button ID="Button1" CssClass="hvr-rectangle-out btnCss" runat="server" Text="Reset Password" />
                                    </div>
                                    <div class="col-md-6" style="text-align: right">
                                        <a id="ancLogin" style="cursor: pointer" onclick="showDataToLogin()">Go back to Login</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="collapse multi-collapse" id="collapseExamples">
                        </div>
                    </div>
                </div>

                <div class="collapse" id="collapseExample">
                    <div class="card card-body">
                    </div>
                </div>

                <br />

                <div class="row" style="margin-bottom: 15px; margin-right: 0; margin-left: 0">
                    <div class="col-md-8 ">
                        <h3 class="" style="text-align: left">
                                <span class="line-title">Billing & Shipping<i class="fa">&#xf111;</i></span>
                                
                            </h3> 
                        <div class="row" style="margin-right: -15px; margin-left: -15px;">
                            <div class="col-sm-6">
                                <span style="font-size: 15px; letter-spacing: 1px;"><b>First Name *:</b></span>
                                <p class="contact-form-author">
                                    <asp:TextBox ID="txtFirstName" runat="server" MaxLength="30" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="First name*"></asp:TextBox>
                                    <span style="color: red" id="errorFirstNameSpan" runat="server" visible="false">Enter First Name.</span>
                                </p>
                            </div>

                            <div class="col-sm-6">
                                <span style="font-size: 15px; letter-spacing: 1px;"><b>Last Name *:</b></span>
                                <p class="contact-form-author">
                                    <asp:TextBox ID="txtLastName" runat="server" MaxLength="30" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="Last name*"></asp:TextBox>
                                    <span style="color: red" id="errorLastNameSpan" runat="server" visible="false">Enter Last Name.</span>
                                </p>
                            </div>
                        </div>
                        <span style="font-size: 15px; letter-spacing: 1px;"><b>Company Name :</b></span>
                        <p class="contact-form-author">
                            <asp:TextBox ID="txtCompanyName" runat="server" MaxLength="30" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="Company name (Optional)"></asp:TextBox>

                        </p>
                        <br />
                        <p class="contact-form-author">
                            <span style="font-size: 20px;"><b>Country : India</b></span>
                        </p>
                        <br />
                        <span style="font-size: 15px; letter-spacing: 1px;"><b>Street Address *:</b></span>
                        <p class="contact-form-author">
                            <asp:TextBox ID="txtStreetAdd" runat="server" MaxLength="200" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="House number and street name*"></asp:TextBox>
                            <span style="color: red" id="errorStreetAddSpan" runat="server" visible="false">Enter House number and street name*.</span>
                        </p>
                        <p class="contact-form-author">
                            <asp:TextBox ID="txtStreetAdd2" MaxLength="200" runat="server" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="Apartment, suite, unit etc.(Optional)"></asp:TextBox>

                        </p>
                        <br />
                        <span style="font-size: 15px; letter-spacing: 1px;"><b>Town / City *:</b></span>
                        <p class="contact-form-author">
                            <asp:TextBox ID="txtCity" runat="server" MaxLength="30" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="City*"></asp:TextBox>
                            <span style="color: red" id="errorCitySpan" runat="server" visible="false">Enter City Name*.</span>
                        </p>

                        <br />
                        <%-- <span style="font-size: 15px; letter-spacing: 1px;"><b>State *:</b></span>
                                <p class="contact-form-author">
                                    <asp:DropDownList ID="drpState" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="State*" runat="server" required></asp:DropDownList>
                                </p>--%>

                        <p class="contact-form-author">
                            <span id="stateSpan" style="font-size: 20px;"><b>State : Gujarat</b></span>
                        </p>

                        <br />
                        <span style="font-size: 15px; letter-spacing: 1px;"><b>Postcode / ZIP *:</b></span>
                        <p class="contact-form-author">
                            <asp:TextBox ID="txtPincode" runat="server" MaxLength="7" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="0*"></asp:TextBox>
                            <span style="color: red" id="errorPincodeSpan" runat="server" visible="false">
                                <asp:Label ID="lblPinCodeError" runat="server" Text="Label"></asp:Label>*.</span>
                        </p>

                        <br />
                        <span style="font-size: 17px; letter-spacing: 1px;"><b>Phone / Mobile *:</b></span>
                        <p class="contact-form-author">
                            <asp:TextBox ID="txtMobile" runat="server" class="txtBoxStyle form-control form-control-lg input-lg" MaxLength="10" placeholder="0*"></asp:TextBox>
                            <span style="color: red" id="errorPhoneSpan" runat="server" visible="false">Enter Phone / Mobile Number*.</span>
                        </p>

                        <br />
                        <span style="font-size: 15px; letter-spacing: 1px;"><b>Email Address *:</b></span>
                        <p class="contact-form-author">
                            <asp:TextBox ID="txtEmailAddress" AutoPostBack="false" MaxLength="50" OnTextChanged="txtEmailAddress_TextChanged" TextMode="Email" runat="server" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="abc@gmail.com*"></asp:TextBox>
                            <span style="color: red" id="errorSpanEmail" runat="server" visible="false">Email Already exists. Enter different email address. </span>
                        </p>

                        <br />
                        <div runat="server" id="pwdDiv">
                            <span style="font-size: 15px; letter-spacing: 1px;"><b>Create account password *:</b></span>
                            <p class="contact-form-author">
                                <asp:TextBox ID="txtPwd" TextMode="Password" runat="server" MaxLength="16" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="*"></asp:TextBox>
                                <span style="color: red" id="errorPwdSpan" runat="server" visible="false">Enter Password*.</span>
                            </p>

                            <br />
                            <span style="font-size: 15px; letter-spacing: 1px;"><b>Confirm account password *:</b></span>
                            <p class="contact-form-author">
                                <asp:TextBox ID="txtConfirmPass" TextMode="Password" runat="server" MaxLength="16" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="*"></asp:TextBox>
                                <span style="color: red" id="errorSpan">Confirm Password Mismatched. Enter Password again.
                                </span>
                                <span style="color: red" id="errorConfirmPwdSpan" runat="server" visible="false">Enter Confirm Password*.</span>
                            </p>

                        </div>
                        <br />
                        <span style="font-size: 20px">
                            <asp:CheckBox ID="chkShipping" runat="server" onclick="disableControls()" />
                            <i class="fa fa-truck" aria-hidden="true"></i>Shipping Details Same As Above</span>
                        <br />

                        <br />
                        <div id="shippingAddress">
                            <div class="row">
                                <div class="col-sm-6">
                                    <span style="font-size: 15px; letter-spacing: 1px;"><b>First Name *:</b></span>
                                    <p class="contact-form-author">
                                        <asp:TextBox ID="txtFirstNameShipping" MaxLength="30" runat="server" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="First name*"></asp:TextBox>
                                        <span style="color: red" id="errorFirstNameShippingSpan" runat="server" visible="false">Enter First Name.</span>
                                    </p>
                                </div>

                                <div class="col-sm-6">
                                    <span style="font-size: 15px; letter-spacing: 1px;"><b>Last Name *:</b></span>
                                    <p class="contact-form-author">
                                        <asp:TextBox ID="txtLastNameShipping" runat="server" MaxLength="30" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="Last name*"></asp:TextBox>
                                        <span style="color: red" id="errorLastNameShippingSpan" runat="server" visible="false">Enter Last Name.</span>
                                    </p>
                                </div>
                            </div>
                            <span style="font-size: 15px; letter-spacing: 1px;"><b>Company Name :</b></span>
                            <p class="contact-form-author">
                                <asp:TextBox ID="txtCompanyNameShipping" runat="server" MaxLength="30" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="Company name (Optional)"></asp:TextBox>
                            </p>
                            <br />
                            <p class="contact-form-author">
                                <span id="countryNameSpan" style="font-size: 20px;"><b>Country : India</b></span>
                            </p>
                            <br />
                            <span style="font-size: 15px; letter-spacing: 1px;"><b>Street Address *:</b></span>
                            <p class="contact-form-author">
                                <asp:TextBox ID="txtStreetAddressShipping" runat="server" MaxLength="200" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="House number and street name*"></asp:TextBox>
                                <span style="color: red" id="errorStreetAddShippingSpan" runat="server" visible="false">Enter House number and street name*.</span>
                            </p>
                            <p class="contact-form-author">
                                <asp:TextBox ID="txtStreedAddressShipping2" MaxLength="200" runat="server" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="Apartment, suite, unit etc.(Optional)"></asp:TextBox>
                            </p>
                            <br />
                            <span style="font-size: 15px; letter-spacing: 1px;"><b>Town / City *:</b></span>
                            <p class="contact-form-author">
                                <asp:TextBox ID="txtCityShipping" runat="server" MaxLength="30" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="City*"></asp:TextBox>
                                <span style="color: red" id="errorCitySpinningSpan" runat="server" visible="false">Enter City Name*.</span>
                            </p>

                            <br />
                            <%--<span style="font-size: 15px; letter-spacing: 1px;"><b>State *:</b></span>
                                    <p class="contact-form-author">
                                        <asp:DropDownList ID="drpStatesShipping" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="State*" runat="server" required></asp:DropDownList>
                                    </p>--%>

                            <p class="contact-form-author">
                                <span id="stateSpanShipping" style="font-size: 20px;"><b>State : Gujarat</b></span>
                            </p>

                            <br />
                            <span style="font-size: 15px; letter-spacing: 1px;"><b>Postcode / ZIP *:</b></span>
                            <p class="contact-form-author">
                                <asp:TextBox ID="txtPincodeShipping" runat="server" MaxLength="7" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="0*"></asp:TextBox>
                                <span style="color: red" id="errorPincodeShippingSpan" runat="server" visible="false">
                                    <asp:Label ID="lblShippiNGPinCodeError" runat="server" Text="Label"></asp:Label>*.</span>
                            </p>

                            <br />
                            <span style="font-size: 15px; letter-spacing: 1px;"><b>Phone / Mobile *:</b></span>
                            <p class="contact-form-author">
                                <asp:TextBox ID="txtMobileShipping" runat="server" MaxLength="10" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="0*"></asp:TextBox>
                                <span style="color: red" id="errorPhoneShippingSpan" runat="server" visible="false">Enter Phone / Mobile Number*.</span>
                            </p>

                        </div>


                    </div>

                    <div class="col-md-4  section info-recipe" style="padding: 0;">

                        <div style="padding: 33px">
                            <h2 style="text-align: center"><strong>Your Order</strong></h2>
                            <hr style="margin-top: 10px; border: 1px solid lightgrey;" />
                            <span>SubTotal: </span>
                            <br />

                            <strong>
                                <asp:Label ID="lblSubTotal" Style="color: black; font-size: 18px;" runat="server" Text="500.00"></asp:Label>
                            </strong>
                            <hr style="margin-top: 10px; margin-bottom: -14px; border: 1px solid lightgrey;" />
                            <br />
                            <span>Shipping: </span>
                            <br />

                            <strong>
                                <asp:Label ID="lblShippingRate" Style="color: black; font-size: 18px;" runat="server" Text="Flat Rate:₹40.00"></asp:Label>
                            </strong>
                            <hr style="margin-top: 10px; margin-bottom: -14px; border: 1px solid lightgrey;" />
                            <br />
                            <span>Total: </span>
                            <br />

                            <strong>
                                <asp:Label ID="lblTotal" Style="color: black; font-size: 18px;" runat="server" Text=""></asp:Label>

                                (includes
                                        <asp:Label ID="lblTax" runat="server" Style="color: black; font-size: 18px;" Text="Label"></asp:Label>
                                Tax)
                                         
                            </strong>
                            <hr style="margin-top: 10px; margin-bottom: -14px; border: 1px solid lightgrey;" />
                            <br />
                            <img src="../Template/images/Download/payumoney.png" />
                            <br />
                            <hr style="margin-top: 10px; margin-bottom: -14px; border: 1px solid lightgrey;" />
                            <br />
                            <div class="collapse multi-collapse" id="termsConditions">
                                <div style="overflow-y: scroll; height: 230px !important;">
                                    <div style="text-align: center">
                                        <a href="Default.aspx">
                                            <img alt="Patel Tea Packers" style="width: 20%;" src="../Template/17.png" /></a>
                                        <br />
                                    </div>
                                    <h4 style="text-align: center">Terms and Conditions of Web Site Use*</h4>
                                    <p style="text-align: justify">
                                        This page states the Terms and Conditions under which you (Visitor) may visit this Web site ( www.pateltea.co.in ) . Please read this page carefully. If you do not accept the Terms and Conditions stated here, we would request you to exit this site. The business, any of its business divisions and / or its subsidiaries, associate companies or subsidiaries to subsidiaries or such other investment companies (in India or abroad) reserve their respective rights to revise these Terms and Conditions at any time by updating this posting. You should visit this page periodically to re-appraise yourself of the Terms and Conditions, because they are binding on all users of this Web Site.

                                                <br />
                                        <b>Website Availability</b>
                                        <br />

                                        The Patel Tea Packers may suspend the Website for any reason whatsoever, including but not limited to repairs, planned maintenance or upgrades, and shall not be liable to you for any such suspension. The Patel Tea Packers reserves the right to make any changes to the Website or to discontinue any aspect or feature of the Website without notice.

                                                <b>Use of Content</b>

                                        All logos, brands, marks headings, labels, names, signatures, numerals, shapes or any combinations thereof, appearing in this site, except as otherwise noted, are properties either owned, or used under licence, by The business and / or its associate entities who feature on this website. The use of these properties or any other content on this site, except as provided in these terms and conditions or in the site content, is strictly prohibited.
                                                <br />
                                        You may not sell or modify the content of this Web Site or reproduce, display, publicly perform, distribute, or otherwise use the materials in any way for any public or commercial purpose without the respective organisation’s written permission.
                                                <br />
                                        <b>Acceptable Site Use</b>
                                        <br />
                                        (A) <b>Security Rules</b>
                                        Visitors are prohibited from violating or attempting to violate the security of the Web site, including, without limitation, (1) accessing data not intended for such user or logging into a server or account which the user is not authorised to access, (2) attempting to probe, scan or test the vulnerability of a system or network or to breach security or authentication measures without proper authorisation, (3) attempting to interfere with service to any user, host or network, including, without limitation, via means of submitting a virus or “Trojan horse” to the Web site, overloading, “flooding”, “mail bombing” or “crashing”, or (4) sending unsolicited electronic mail, including promotions and/or advertising of products or services. Violations of system or network security may result in civil or criminal liability. The business and / or its associate entities will have the right to investigate occurrences that they suspect as involving such violations and will have the right to involve, and cooperate with, law enforcement authorities in prosecuting users who are involved in such violations.
                                                <br />
                                        (B) <b>General Rules</b>
                                        Visitors may not use the Web Site in order to transmit, distribute, store or destroy material (a) that could constitute or encourage conduct that would be considered a criminal offence or violate any applicable law or regulation, (b) in a manner that will infringe the copyright, trademark, trade secret or other intellectual property rights of others or violate the privacy or publicity of other personal rights of others, or (c) that is libellous, defamatory, pornographic, profane, obscene, threatening, abusive or hateful.
Links to/from other Web Sites
                                                <br />
                                        This Web site contains links to other Web Sites. These links are provided solely as a convenience to you. Wherever such link/s lead to sites which do not belong to The business and / or its associate entities, The business is not responsible for the content of linked sites and does not make any representations regarding the correctness or accuracy of the content on such Web Sites. If you decide to access such linked Web Sites, you do so at your own risk.
                                                <br />
                                        Similarly, this Web site can be made accessible through a link created by other Web sites. Access to this Web site through such link/s shall not mean or be deemed to mean that the objectives, aims, purposes, ideas, concepts of such other Web sites or their aim or purpose in establishing such link/s to this Web site are necessarily the same or similar to the idea, concept, aim or purpose of our web site or that such links have been authorised by The business and / or its associate entities. We are not responsible for any representation/s of such other Web sites while affording such link and no liability can arise upon The business and / or its associate entities consequent to such representation, its correctness or accuracy. In the event that any link/s afforded by any other Web site/s derogatory in nature to the objectives, aims, purposes, ideas and concepts of this Web site is utilised to visit this Web site and such event is brought to the notice or is within the knowledge of The business and / or its associate entities, civil or criminal remedies as may be appropriate shall be invoked.
                                                <br />
                                        <b>Indemnity</b>
                                        <br />
                                        You agree to defend, indemnify, and hold harmless The business and/ or its associate entities, their officers, directors, employees and agents, from and against any claims, actions or demands, including without limitation reasonable legal and accounting fees, alleging or resulting from your use of the Web site material or your breach of these terms and conditions of Web Site use.
                                                <br />
                                        <b>Prices</b>
                                        <br />
                                        All prices listed on our website are subject to change, but the changes will not affect orders that have already been accepted by us. The prices on our website exclude shipping costs, which will be added during checkout. The prices of our products have been computed carefully and listed on our website. However, due to unintentional errors, if the product purchased by you has been incorrectly priced, we will notify you via email or phone before accepting your order for instructions. You will then have the option to cancel your order if you desire or pay the difference.
                                                <br />
                                        <b>Credit Card Payment</b>
                                        <br />
                                        In a credit/debit card transaction, you must use your own credit/debit card. We will not be liable for any credit/debit card fraud. The liability to use a card fraudulently will be on the user and the onus to ‘prove otherwise’ shall be exclusively on the user
                                                <br />
                                        <b>Liability</b>
                                        <br />
                                        While all reasonable care has been taken in providing the content on this Web Site, The business. and / or its associate entities shall not be responsible or liable as to the completeness or correctness of such information and any or all consequential liabilities arising out of use of any information or contents on this Web Site.
                                                <br />
                                        No warranty is given that the Web Site will operate error-free or that this Web Site and its server are free of computer viruses or other harmful mechanisms. If your use of the Web site results in the need for servicing or replacing equipment or data, The business and / or its associate entities are not responsible for those costs.
                                                <br />
                                        The web site is provided on an ‘as is’ basis without any warranties either express or implied whatsoever. The business. and / or its associate entities, to the fullest extent permitted by law, disclaims all warranties, including non-infringement of third parties rights, and the warranty of fitness for a particular purpose and makes no warranties about the accuracy, reliability, completeness, or timeliness of the content, services, software, text, graphics, and links.
                                                <br />

                                        <b>Disclaimer of Consequential Damages</b>
                                        <br />
                                        In no event shall The business, or any parties, organisations or entities associated with the corporate brand name us or otherwise, mentioned at this Web Site be liable for any damages whatsoever (including, without limitations, incidental and consequential damages, lost profits, or damage to computer hardware or loss of data information or business interruption) resulting from the use or inability to use the Web Site and the Web site material, whether based on warranty, contract, tort, or any other legal theory, and whether or not, such organisations or entities were advised of the possibility of such damages.
                                                <br />
                                        *If you have any query about this policy or if you have any suggestion to improve this policy, please contact us using the contact us form.
                                    </p>
                                </div>
                            </div>
                            <br />
                            <asp:CheckBox ID="chkTermsConditions" runat="server" Text=" I have read and agree to the website" required />
                            <a href="#termsConditions" data-toggle="collapse" onclick="hideForgetpwd()">TERMS AND CONDITIONS *</a>
                            <br />
                            <br />
                            <asp:Button ID="btnPlaceOrder" OnClick="btnPlaceOrder_Click" runat="server" CssClass="hvr-rectangle-out btnCss" Style="padding: 0; height: 50px; width: 100%; font-size: 22px;" Text="Place Order" />

                         </div>

                    </div>
                </div>

            </div>
        </section>

    </div>

    <input type="hidden" runat="server" id="key" name="key" value="" />
    <input type="hidden" runat="server" id="salt" name="salt" value="" />
    <input type="hidden" runat="server" id="hash" name="hash" value="" />
    <input type="hidden" id="udf5" runat="server" name="udf5" value="BOLT_KIT_ASP.NET" />
    <input type="hidden" id="surl" name="surl" value="<%= Session["surl"]%>" />



</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="footers" runat="server">

    <script>

        var txtFirstName = $("#" + "<%= txtFirstName.ClientID %>");
        var txtLastName = $("#" + "<%= txtLastName.ClientID %>");
        var txtCompanyName = $("#" + "<%= txtCompanyName.ClientID %>");
        var txtStreetAdd = $("#" + "<%= txtStreetAdd.ClientID %>");
        var txtStreedAdd2 = $("#" + "<%= txtStreetAdd2.ClientID %>");
        var txtCity = $("#" + "<%= txtCity.ClientID %>");
        var txtPincode = $("#" + "<%= txtPincode.ClientID %>");
        var txtMobile = $("#" + "<%= txtMobile.ClientID %>");
        var txtConfirmPass = $("#" + "<%= txtConfirmPass.ClientID %>");
        var txtPwd = $("#" + "<%= txtPwd.ClientID %>");
        //shipping address another

        var txtFirstNameShipping = $("#" + "<%= txtFirstNameShipping.ClientID %>");
        var txtLastNameShipping = $("#" + "<%= txtLastNameShipping.ClientID %>");
        var txtCompanyNameShipping = $("#" + "<%= txtCompanyNameShipping.ClientID %>");
        var txtStreetAddressShipping = $("#" + "<%= txtStreetAddressShipping.ClientID %>");
        var txtStreedAddressShipping2 = $("#" + "<%= txtStreedAddressShipping2.ClientID %>");
        var txtCityShipping = $("#" + "<%= txtCityShipping.ClientID %>");

        var txtPincodeShipping = $("#" + "<%= txtPincodeShipping.ClientID %>");
        var txtMobileShipping = $("#" + "<%= txtMobileShipping.ClientID %>");


        $(document).ready(function () {
            $("#forgetPasswordThis").hide();
            $("#errorSpan").hide();

        });

        txtPincode.on('keypress', function (event) {
            var regex = new RegExp("^[0-9\b\u0000]+$");
            var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
            if (!regex.test(key)) {
                event.preventDefault();
                return false;
            }

        });

        txtMobile.on('keypress', function (event) {
            var regex = new RegExp("^[0-9\b\u0000]+$");
            var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
            if (!regex.test(key)) {
                event.preventDefault();
                return false;
            }

        });

        txtPincodeShipping.on('keypress', function (event) {
            var regex = new RegExp("^[0-9\b\u0000]+$");
            var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
            if (!regex.test(key)) {
                event.preventDefault();
                return false;
            }

        });

        txtMobileShipping.on('keypress', function (event) {
            var regex = new RegExp("^[0-9\b\u0000]+$");
            var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
            if (!regex.test(key)) {
                event.preventDefault();
                return false;
            }

        });


        $(document).ready(function () {

            txtConfirmPass.change(function () {
                if (txtConfirmPass.val() != txtPwd.val()) {
                    txtConfirmPass.focus();
                    txtConfirmPass.val("");
                    $("#errorSpan").show();
                }
                else {
                    $("#errorSpan").hide();
                }
            });

            var checkBoxCheck = $('#<%= chkShipping.ClientID %>');

            checkBoxCheck.prop("checked", false);
            if (checkBoxCheck.is(':checked')) {

                txtFirstNameShipping.attr("disabled", "disabled");
                txtLastNameShipping.attr("disabled", "disabled");
                txtCompanyNameShipping.attr("disabled", "disabled");
                txtStreetAddressShipping.attr("disabled", "disabled");
                txtStreedAddressShipping2.attr("disabled", "disabled");
                txtCityShipping.attr("disabled", "disabled");

                txtPincodeShipping.attr("disabled", "disabled");
                txtMobileShipping.attr("disabled", "disabled");

                txtFirstNameShipping.val(txtFirstName.val());
                txtLastNameShipping.val(txtLastName.val());
                txtCompanyNameShipping.val(txtCompanyName.val());
                txtStreetAddressShipping.val(txtStreetAdd.val());
                txtStreedAddressShipping2.val(txtStreedAddressShipping2.val());
                txtCityShipping.val(txtCity.val());
                txtPincodeShipping.val(txtPincode.val());
                txtMobileShipping.val(txtMobile.val());
            }

            //--------------------------------------------------------------------

            //Payment Gateway

            //$('#payment_form').keyup(function () {
            //    $.ajax({
            //        url: 'Hash.aspx',
            //        type: 'post',
            //        data: JSON.stringify({
            //            key: $('#key').val(),
            //            salt: $('#salt').val(),
            //            txnid: $('#txnid').val(),
            //            amount: $('#amount').val(),
            //            pinfo: $('#pinfo').val(),
            //            fname: $('#fname').val(),
            //            email: $('#email').val(),
            //            mobile: $('#mobile').val(),
            //            udf5: $('#udf5').val()
            //        }),
            //        contentType: "application/json",
            //        dataType: 'json',
            //        success: function (json) {
            //            if (json['error']) {
            //                $('#alertinfo').html('<i class="fa fa-info-circle"></i>' + json['error']);
            //            }
            //            else if (json['success']) {
            //                $('#hash').val(json['success']);
            //            }
            //        }
            //    });
            //});

            //--------------------------------------------------------------------

        });


        function hideForgetpwd() {

        }


        function showData() {
            debugger;
            //
            $("#loginThis").hide();
            $("#forgetPasswordThis").show();
        }

        function showDataToLogin() {
            $("#loginThis").show();
            $("#forgetPasswordThis").hide();
        }
        function disableControls() {





            if ($('#<%= chkShipping.ClientID %>').is(':checked')) {
                $("#shippingAddress").hide();

                //txtFirstNameShipping.attr("disabled", "disabled");
                //txtLastNameShipping.attr("disabled", "disabled");
                //txtCompanyNameShipping.attr("disabled", "disabled");
                //txtStreetAddressShipping.attr("disabled", "disabled");
                //txtStreedAddressShipping2.attr("disabled", "disabled");
                //txtCityShipping.attr("disabled", "disabled");

                //txtPincodeShipping.attr("disabled", "disabled");
                //txtMobileShipping.attr("disabled", "disabled");

                //txtFirstNameShipping.val(txtFirstName.val());
                //txtLastNameShipping.val(txtLastName.val());
                //txtCompanyNameShipping.val(txtCompanyName.val());
                //txtStreetAddressShipping.val(txtStreetAdd.val());
                //txtStreedAddressShipping2.val(txtStreedAddressShipping2.val());
                //txtCityShipping.val(txtCity.val());
                //txtPincodeShipping.val(txtPincode.val());
                //txtMobileShipping.val(txtMobile.val());

            }
            else {
                $("#shippingAddress").show();

                //txtFirstNameShipping.attr("disabled", false);
                //txtLastNameShipping.attr("disabled", false);
                //txtCompanyNameShipping.attr("disabled", false);
                //txtStreetAddressShipping.attr("disabled", false);
                //txtStreedAddressShipping2.attr("disabled", false);
                //txtCityShipping.attr("disabled", false);

                //txtPincodeShipping.attr("disabled", false);
                //txtMobileShipping.attr("disabled", false);

                //txtFirstNameShipping.val("");
                //txtLastNameShipping.val("");
                //txtCompanyNameShipping.val("");
                //txtStreetAddressShipping.val("");
                //txtStreedAddressShipping2.val("");
                //txtCityShipping.val("");
                //txtPincodeShipping.val("");
                //txtMobileShipping.val("");
            }
        }
    </script>
</asp:Content>
