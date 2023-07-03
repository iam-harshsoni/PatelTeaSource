<%@ Page Title="" Language="C#" MasterPageFile="~/CS/Client.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="MyAccount.aspx.cs" Inherits="PatelTeaSource.CS.MyAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        * {
            box-sizing: border-box;
        }
        .header {
	margin-top:0 !important;
	width:100%;
	text-align:center;
}
        .txtBoxStyle {
            font-size: 15px;
            height: 40px;
        }

        body {
            font-family: "Lato", sans-serif;
        }

        /* Style the tab */
        .tab {
            float: left;
            border: 1px solid #ccc;
            background-color: #f1f1f1;
            width: 30%;
            height: 300px;
        }

            /* Style the buttons inside the tab */
            .tab button {
                display: block;
                background-color: inherit;
                color: black;
                padding: 22px 16px;
                width: 100%;
                border: none;
                outline: none;
                text-align: left;
                cursor: pointer;
                transition: 0.3s;
                font-size: 17px;
            }

                /* Change background color of buttons on hover */
                .tab button:hover {
                    background-color: #ddd;
                }

                /* Create an active/current "tab button" class */
                .tab button.active {
                    background-color: #ccc;
                }

        /* Style the tab content */
        .tabcontent {
            float: left;
            padding: 0px 12px;
            border: 1px solid #ccc;
            width: 70%;
            border-left: none;
            height: 300px;
        }
    </style>

    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <link href='//fonts.googleapis.com/css?family=Open+Sans:400,300,300italic,400italic,600,600italic,700,700italic,800,800italic' rel='stylesheet' type='text/css' />

    <link href="../Template/assets/css/styleShipment.css" rel="stylesheet" />
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
                <span class="line-title">My Account<i class="fa">&#xf111;</i></span>
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

                    <div class="row" id="loginRow" runat="server">

                        <div class="col-md-6">

                            <div class="section" id="loginThis" style="width: 100%; padding: 20px; padding-top: 20px;">
                                <div id="logThis" runat="server">
                                    <h3 class="title">
                                        <span class="line-title">Login<i class="fa">&#xf111;</i></span>
                                    </h3>

                                    <asp:TextBox ID="txtEmailUsername" MaxLength="30" TextMode="Email" runat="server" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="Your Email Address*"></asp:TextBox>
                                    <span style="color: red" id="errorEmailUserNameSpan" runat="server" visible="false">Enter Email Address*.</span>
                                    <br />
                                    <asp:TextBox ID="txtPasswordLogin" MaxLength="16"  TextMode="Password" runat="server" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="Your Password*"></asp:TextBox>
                                    <span style="color: red" id="errorUserPwdSpan" runat="server" visible="false">Enter Password*.</span>
                                    <br />
                                    <a id="ancForgetPwd" style="cursor: pointer" onclick="showData()">Forgot Password?</a>

                                    <br />
                                    <br />
                                    <asp:Button ID="btnLogin" OnClick="btnLogin_Click" CssClass="hvr-rectangle-out btnCss" runat="server" Text="Login" />
                                </div>
                            </div>

                             <div id="recoverPWDThis" runat="server">
                            <div class="section" id="forgetPasswordThis" style="width: 100%; padding: 20px; padding-top: 20px">
                               
                                    <h3 class="title">
                                        <span class="line-title">Recover Password<i class="fa">&#xf111;</i></span>
                                    </h3>

                                    <asp:TextBox ID="txtEmailRecover" MaxLength="30" runat="server" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="Your Email*"></asp:TextBox>
                                    <span style="color: red" id="errorEmailRecoverSpan" runat="server" visible="false">Enter Email Address*.</span>
                                    <br />

                                    <asp:Button ID="btnRecoverPassword"  OnClick="btnRecoverPassword_Click" CssClass="hvr-rectangle-out btnCss" runat="server" Text="Reset Password" />
                                    <br />
                                    <br />
                                    <a id="ancLogin" style="cursor: pointer" onclick="showDataToLogin()">Go back to Login</a>

                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="section" id="registerThis" style="width: 100%; padding: 20px; padding-top: 20px;">
                                <h3 class="title">
                                    <span class="line-title">Sign Up<i class="fa">&#xf111;</i></span>
                                </h3>

                                <asp:TextBox ID="txtEmailRegister" MaxLength="30" TextMode="Email" runat="server" class=" txtBoxStyle form-control form-control-lg input-lg" placeholder="Your Email Address*"></asp:TextBox>
                                <span style="color: red" id="errorEmailRegisterSpan" runat="server" visible="false">Enter Email Address*.</span>
                                <br />
                                <asp:TextBox ID="txtPwdRegister" MaxLength="16" TextMode="Password" runat="server" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="Your Password*"></asp:TextBox>
                                <span style="color: red" id="errorPwdRegisterspan" runat="server" visible="false">Enter Password*.</span>
                                <br />
                                <asp:TextBox ID="txtConfirmPwdRegister" MaxLength="16" TextMode="Password" runat="server" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="Re-Enter Your Password*"></asp:TextBox>
                                <span style="color: red" id="errorConfirmPwdRegisterSpan" runat="server" visible="false">Re-Enter Password*.</span>
                                <span style="color: red" id="errorSpan">Confirm Password Mismatched. Enter Password again.
                                </span>
                                <br />
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:Button ID="btnRegister" OnClick="btnRegister_Click" CssClass="hvr-rectangle-out btnCss" runat="server" Text="Register" />
                                    </div>

                                </div>
                            </div>

                        </div>

                    </div>

                   

                    <div class="row" id="dataRow" runat="server" style="padding: 15px">
                        <ul class="nav nav-tabs" id="myTab" role="tablist">
                            <li class="nav-item ">

                                <a class="nav-link" id="order-tab" data-toggle="tab" href="#order" role="tab" aria-controls="order" aria-selected="true">Orders</a>

                            </li>
                            <li class="nav-item active">
                                <a class="nav-link" id="address-tab" data-toggle="tab" href="#address" role="tab" aria-controls="order" aria-selected="true">Address</a>

                            </li>
                            <li class="nav-item">
                                <a class="nav-link" id="trackOrder-tab" data-toggle="tab" href="#trackOrder" role="tab" aria-controls="trackOrder" aria-selected="true">Track Your Order</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" id="changepassword-tab" data-toggle="tab" href="#changePwd" role="tab" aria-controls="order" aria-selected="true">Change Password</a>
                            </li>
                            <li class="nav-item">

                                <a class="nav-link" id="logout-tab" data-toggle="tab" href="#logout" role="tab" aria-controls="order" aria-selected="true">Logout</a>
                            </li>
                        </ul>
                        <div class="tab-content" id="myTabContent">
                            <div class="tab-pane fade" style="" id="order" role="tabpanel" aria-labelledby="order-tab">

                                <br />
                                <div id="ordersDiv" runat="server">

                                    <h3 class="title">
                                        <span class="line-title">my Orders<i class="fa">&#xf111;</i></span>
                                    </h3>

                                    <div class="table-responsive">
                                        <table class="table table-hover mb-0">
                                            <thead>
                                                <tr>
                                                    <th>Order Number</th>
                                                    <th>Date</th>
                                                    <th>Status</th>
                                                    <th>Items</th>
                                                    <th>Total</th>
                                                    <th>Actions</th>

                                                </tr>
                                            </thead>
                                            <tbody>
                                                <asp:PlaceHolder ID="PlaceHolderOrderTable" runat="server"></asp:PlaceHolder>
                                            </tbody>
                                        </table>
                                    </div>
                                </div> 

                                <div id="orderDetailsDiv" runat="server">
                                    <a class="hvr-rectangle-out btnCss" style="padding: 6px; width: 135px !important; margin-bottom: 20px;" href="MyAccount.aspx"><i class="fa fa-mail-reply"></i>Load all orders</a>

                                    <div class="row">

                                        <div class="col-md-6">

                                            <h3 class="title">
                                                <span class="line-title">Order Details<i class="fa">&#xf111;</i></span>
                                            </h3>
                                            <div>
                                                <table class="table">
                                                    <tbody>
                                                        <asp:PlaceHolder ID="placeHolderOrderStatus" runat="server"></asp:PlaceHolder>
                                                        <asp:PlaceHolder ID="placeHolderProducts" runat="server"></asp:PlaceHolder>
                                                        <asp:PlaceHolder ID="placeHolderProductsDetails" runat="server"></asp:PlaceHolder>
                                                    </tbody>
                                                </table>
                                            </div>



                                            <%-- <label>Subtotal: </label> <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                                            <hr />
                                             <label>Shipping: </label> <asp:Label ID="Label6" runat="server" Text="Free Shipping"></asp:Label>
                                            <hr />
                                             <label>Payment method:: </label> <asp:Label ID="Label7" runat="server" Text="PayUmoney"></asp:Label>
                                            <hr />
                                             <label>Total: </label> <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>--%>
                                        </div>
                                        <div class="col-md-6">
                                            <h3 class="title">
                                                <span class="line-title">Customer Details<i class="fa">&#xf111;</i></span>
                                            </h3>

                                            <table class="table">
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <label>Email: </label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label>Phone: </label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblPhone" runat="server" Text="Label"></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label>Billing Address: </label>
                                                        </td>
                                                        <td>
                                                            <asp:PlaceHolder ID="placeHolderBillingAddress" runat="server"></asp:PlaceHolder>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <label>Shipping Address: </label>
                                                        </td>
                                                        <td>
                                                            <asp:PlaceHolder ID="placeHolderShippingAddress" runat="server"></asp:PlaceHolder>
                                                        </td>
                                                    </tr>

                                                </tbody>
                                            </table>
                                        </div>

                                    </div>

                                </div>

                                <div id="wrongOrderNumberDiv" runat="server">
                                    <asp:Button ID="btnWrongOrderNumber" OnClick="btnWrongOrderNumber_Click" CssClass="hvr-rectangle-out btnCss" runat="server" Text="Load All Orders" />

                                </div>

                                <div id="noOrderExists" runat="server">
                                    <label style="font-size: 20px">No Order Found</label>
                                    <br />
                                    <br />
                                    <a class="hvr-rectangle-out btnCss" style="padding: 6px; width: 170px !important; margin-bottom: 20px;" href="Products.aspx"><i class="fa fa-mail-reply"></i>Continue Shopping</a>
                                </div>
                            </div>

                            <div class="tab-pane fade" id="address" role="tabpanel" aria-labelledby="address-tab">
                                <br />
                                <h3 class="title">
                                    <span class="line-title">Address Details<i class="fa">&#xf111;</i></span>
                                </h3>

                                <p>The following addresses will be used on the checkout page by default.</p>

                                <br />

                                <div class="row">
                                    <div class="col-md-6">
                                        <h3>Billing address</h3>
                                        <hr />
                                        <div id="billingAddressDetails">

                                            <asp:PlaceHolder ID="placeHolderBillingAdd" runat="server"></asp:PlaceHolder>
                                            <br />
                                            <a id="ancBillingAddEdit" onclick="showBillingAdd()" runat="server" style="cursor: pointer"><i class="fa fa-edit"></i>Edit</a>
                                            <a id="ancBillingAdd" onclick="showBillingAdd()" runat="server" style="cursor: pointer" visible="false"><i class="fa fa-plus"></i>Add Billing Address</a>
                                        </div>

                                        <div id="billingAddressChange">
                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <span style="font-size: 15px; letter-spacing: 1px;"><b>First Name *:</b></span>
                                                    <p class="contact-form-author">
                                                        <asp:TextBox ID="txtFirstName" MaxLength="30" runat="server" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="First name*"></asp:TextBox>
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
                                                <asp:TextBox ID="txtStreetAdd2" runat="server" MaxLength="200" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="Apartment, suite, unit etc.(Optional)"></asp:TextBox>

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
                                                <span style="color: red" id="errorPincodeSpan" runat="server" visible="false">Enter Pincode*.</span>
                                            </p>

                                            <br />
                                            <span style="font-size: 17px; letter-spacing: 1px;"><b>Phone / Mobile *:</b></span>
                                            <p class="contact-form-author">
                                                <asp:TextBox ID="txtMobile" runat="server" MaxLength="10" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="0*"></asp:TextBox>
                                                <span style="color: red" id="errorPhoneSpan" runat="server" visible="false">Enter Phone / Mobile Number*.</span>
                                            </p>

                                            <hr />
                                            <asp:Button ID="btnBilling" OnClick="btnBilling_Click" runat="server" CssClass="hvr-rectangle-out btnCss" Text="Save" />
                                             <a id="a1" onclick="hideBillingAdd()"  class="hvr-rectangle-out btnCss"  runat="server" style="cursor: pointer;padding: 7px 30px;">Cancel</a>
                                  
                                        </div>
                                    </div>

                                    <div class="col-md-6">
                                        <div id="shipAdd" runat="server">
                                            <h3>Shipping address</h3>
                                            <hr />
                                                                                                                                                                                                                                                    
                                            <div id="shippingAddressDetails">

                                                <asp:PlaceHolder ID="placeHolderShippingAdd" runat="server"></asp:PlaceHolder>
                                                <br />
                                                <a id="ancShippingAddressEdit" runat="server" onclick="showShippingAdd()" style="cursor: pointer"><i class="fa fa-edit"></i>Edit</a>
                                            </div>
                                        </div>
                                        <div id="shippingAddressChange">
                                            <div class="row">
                                                <div class="col-sm-6">
                                                    <span style="font-size: 15px; letter-spacing: 1px;"><b>First Name *:</b></span>
                                                    <p class="contact-form-author">
                                                        <asp:TextBox ID="txtFirstNameShipping" runat="server" MaxLength="30" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="First name*"></asp:TextBox>
                                                        <span style="color: red" id="errorFirstNameShippingSpan" runat="server" visible="false">Enter First Name.</span>
                                                    </p>
                                                </div>

                                                <div class="col-sm-6">
                                                    <span style="font-size: 15px; letter-spacing: 1px;"><b>Last Name *:</b></span>
                                                    <p class="contact-form-author">
                                                        <asp:TextBox ID="txtLastNameShipping" MaxLength="30" runat="server" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="Last name*"></asp:TextBox>
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
                                                <asp:TextBox ID="txtStreedAddressShipping2" runat="server" MaxLength="200" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="Apartment, suite, unit etc.(Optional)"></asp:TextBox>
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
                                                <span style="color: red" id="errorPincodeShippingSpan" runat="server" visible="false">Enter Pincode*.</span>
                                            </p>

                                            <br />
                                            <span style="font-size: 15px; letter-spacing: 1px;"><b>Phone / Mobile *:</b></span>
                                            <p class="contact-form-author">
                                                <asp:TextBox ID="txtMobileShipping" runat="server" MaxLength="10" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="0*"></asp:TextBox>
                                                <span style="color: red" id="errorPhoneShippingSpan" runat="server" visible="false">Enter Phone / Mobile Number*.</span>
                                            </p>
                                            <hr />
                                            <asp:Button ID="btnShipping" OnClick="btnShipping_Click" runat="server" CssClass="hvr-rectangle-out btnCss" Text="Save" />
                                               <a id="a2" onclick="hideShippingAdd()"  class="hvr-rectangle-out btnCss"  runat="server" style="cursor: pointer;padding: 7px 30px;">Cancel</a>
           
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="tab-pane fade" style="" id="trackOrder" role="tabpanel" aria-labelledby="trackOrder-tab">
                                <br />
                                <h3 class="title">
                                    <span class="line-title">Order Tracking<i class="fa">&#xf111;</i></span>
                                </h3>

                                <div runat="server" id="enterOrderNumberTrackingDiv">
                                    <label>Order Number: </label>
                                    <asp:TextBox ID="txtEnterOrderNumber" MaxLength="20" runat="server" class=" txtBoxStyle form-control form-control-lg input-lg" placeholder="Enter Order Number*"></asp:TextBox>

                                    <span style="color: gray;">Note: Do no include '#'.Enter only order number found in your order confirmation mail.</span>
                                    <br />
                                    <span style="color: red" id="errorOrderNumberTrackerSpan" runat="server" visible="false">
                                        <asp:Label ID="lblOrderNuError" runat="server" Text="Label"></asp:Label></span>
                                    <br />
                                    <label>Enter Billing Email: </label>
                                    <asp:TextBox ID="txtBillingEmail" runat="server" class=" txtBoxStyle form-control form-control-lg input-lg" placeholder="Enter Billing Email*"></asp:TextBox>
                                    <br />
                                    <span style="color: red" id="errorBillingEmalSpan" runat="server" visible="false">Enter Email Address*.</span>

                                    <asp:Button ID="btnTrackOrder" OnClick="btnTrackOrder_Click" CssClass="hvr-rectangle-out btnCss" runat="server" Text="Track Order" />

                                </div>

                                <div class="content3" id="TrackingOrderDetails" runat="server" visible="false">
                                    <table class="table" style="border: none; width: 500px">
                                        <tbody>
                                            <tr style="border-top: 2px solid white; border-bottom: 1px solid lightgray;">
                                                <td style="vertical-align: middle;">
                                                    <label>Order Number: </label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblOrderNumberTracking" Style="font-size: 20px" runat="server" Text="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: middle;">
                                                    <label>Shipped Via:</label></td>
                                                <td>
                                                    <asp:Label ID="Label1" Style="font-size: 20px" runat="server" Text="Patel Tea Packers"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: middle;">
                                                    <label>Status:</label></td>
                                                <td>
                                                    <asp:Label ID="lblOrderTrackingStatus" Style="font-size: 20px" runat="server" Text="Status"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="vertical-align: middle;">
                                                    <label>Expected Date:</label>
                                                    <td>
                                                        <asp:Label ID="lblExpectedDate" Style="font-size: 20px" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                            </tr>
                                        </tbody>
                                    </table>


                                    <div class="shipment" runat="server" id="shipmentDiv" style="margin-left: 5%">
                                        <div class="confirm" id="div1" runat="server">
                                            <div class="imgcircle">
                                                <img src="../Template/images/confirm.png" alt="confirm order" />
                                            </div>
                                            <span class="line"></span>
                                            <p>Pending Payment</p>
                                        </div>
                                        <div class="confirm" id="divConfirm" runat="server">
                                            <div class="imgcircle">
                                                <img src="../Template/images/confirm.png" alt="confirm order" />
                                            </div>
                                            <span class="line"></span>
                                            <p>Confirmed Order</p>
                                        </div>
                                        <%-- <div class="process" id="divPackedAndDispached" runat="server">
                                            <div class="imgcircle">
                                                <img src="../Template/images/process.png" alt="process order">
                                            </div>
                                            <span class="line"></span>
                                            <p>Processing Order</p>
                                        </div>
                                        <div class="quality" id="divQuality" runat="server">
                                            <div class="imgcircle">
                                                <img src="../Template/images/quality.png" alt="quality check">
                                            </div>
                                            <span class="line"></span>
                                            <p>Quality Check</p>
                                        </div>--%>
                                        <div class="process" runat="server" id="divPackedAndDispatch">
                                            <div class="imgcircle">
                                                <img src="../Template/images/dispatch.png" alt="dispatch product">
                                            </div>
                                            <span class="line"></span>
                                            <p>Packed And Dispached</p>
                                        </div>

                                        <div class="process" runat="server" id="divDelivery">
                                            <div class="imgcircle">
                                                <img src="../Template/images/delivery.png" alt="delivery">
                                            </div>
                                            <span class="line"></span>
                                            <p>Out For Delivery</p>
                                        </div>

                                        <div class="dispatch" id="divDelivered" runat="server">
                                            <div class="imgcircle">
                                                <img src="../Template/images/delivery.png" alt="delivery">
                                            </div>

                                            <p>Product Delivered</p>
                                        </div>
                                        <div class="clear"></div>

                                    </div>


                                </div>
                            </div>

                            <div class="tab-pane fade" id="changePwd" role="tabpanel" aria-labelledby="changePwd-tab">
                                <br />
                                <h3 class="title">
                                    <span class="line-title">Change Password<i class="fa">&#xf111;</i></span>
                                </h3>

                                <asp:TextBox ID="txtCurrentPwd" MaxLength="16" TextMode="Password" runat="server" class=" txtBoxStyle form-control form-control-lg input-lg" placeholder="Your Current Password*"></asp:TextBox>
                                <span style="color: red" id="errorCurrentPwdSpan" runat="server" visible="false">Enter Current Password*.</span>
                                <br />
                                <asp:TextBox ID="txtPwdChange" TextMode="Password" MaxLength="16"  runat="server" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="Your New Password*"></asp:TextBox>
                                <span style="color: red" id="errorPwdChangeSpan" runat="server" visible="false">Enter New Password*.</span>
                                <br />
                                <asp:TextBox ID="txtConfirmPwdChange" MaxLength="16" TextMode="Password" runat="server" class="txtBoxStyle form-control form-control-lg input-lg" placeholder="Re-Enter New Password*"></asp:TextBox>
                                <span style="color: red" id="errorConfirmPwdChangeSpan" runat="server" visible="false">Re-Enter New Password*.</span>
                                <span style="color: red" id="errorSpans">Confirm Password Mismatched. Enter Password again.
                                </span>
                                <br />
                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:Button ID="btnChangePwd" OnClick="btnChangePwd_Click" CssClass="hvr-rectangle-out btnCss" runat="server" Text="Register" />
                                    </div>

                                </div>
                            </div>

                            <div class="tab-pane fade" id="logout" role="tabpanel" aria-labelledby="logout-tab">
                                <br />
                                <label style="font-size: 20px">Click the below button to logout.</label>
                                <br />
                                <br />
                                <asp:Button ID="btnLogout" OnClick="btnLogout_Click" runat="server" CssClass="hvr-rectangle-out btnCss" Text="Logout" />

                            </div>
                        </div>
                        <br />
                        <br />


                    </div>
                </div>
            </div>

        </section>
    </div>
    <br />
    <br />
    <asp:HiddenField ID="TabName" runat="server" />
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
        var txtConfirmPass = $("#" + "<%= txtConfirmPwdRegister.ClientID %>");
        var txtPwd = $("#" + "<%= txtPwdRegister.ClientID %>");

        var txtCurrentPwd = $("#" + "<%= txtCurrentPwd.ClientID %>");
        var txtConfirmPassChange = $("#" + "<%= txtConfirmPwdChange.ClientID %>");
        var txtPwdChange = $("#" + "<%= txtPwdChange.ClientID %>");
        //shipping address another

        var txtFirstNameShipping = $("#" + "<%= txtFirstNameShipping.ClientID %>");
        var txtLastNameShipping = $("#" + "<%= txtLastNameShipping.ClientID %>");
        var txtCompanyNameShipping = $("#" + "<%= txtCompanyNameShipping.ClientID %>");
        var txtStreetAddressShipping = $("#" + "<%= txtStreetAddressShipping.ClientID %>");
        var txtStreedAddressShipping2 = $("#" + "<%= txtStreedAddressShipping2.ClientID %>");
        var txtCityShipping = $("#" + "<%= txtCityShipping.ClientID %>");

        var txtPincodeShipping = $("#" + "<%= txtPincodeShipping.ClientID %>");
        var txtMobileShipping = $("#" + "<%= txtMobileShipping.ClientID %>");


        var txtEmailUsername = $("#" + "<%= txtEmailUsername.ClientID %>");
        var txtEmailRecover = $("#" + "<%= txtEmailRecover.ClientID %>");
        $(function () {

            var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "order";
            $('#myTab a[href="#' + tabName + '"]').tab('show');
            $("#myTab a").click(function () {
                $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
            });
        });


        $(document).ready(function () {
            $("#forgetPasswordThis").hide();
            $("#errorSpan").hide();
            $("#errorSpans").hide();

            //    $('#myTab a[href="#order"]').tab('show')
            $("#billingAddressChange").hide();
            $("#shippingAddressChange").hide();

            window.history.pushState(null, "", window.location.href);
            window.onpopstate = function () {
                window.history.pushState(null, "", window.location.href);
            };

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

            txtConfirmPassChange.change(function () {
                if (txtConfirmPassChange.val() != txtPwdChange.val()) {
                    txtConfirmPassChange.focus();
                    txtConfirmPassChange.val("");
                    $("#errorSpans").show();
                }
                else {
                    $("#errorSpans").hide();
                }
            });

        });

        txtPincode.on('keypress', function (event) {
            var regex = new RegExp("^[0-9\b\u0000]+$");
            var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
            if (!regex.test(key)) {
                console.log(key);
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

        function hideOrder() {
            $('#address').tab('show')
        }



        function showData() {
            txtEmailUsername.val("");
            $("#loginThis").hide();
            $("#forgetPasswordThis").show();
        }

        function showDataToLogin() {
            txtEmailRecover.val("");
            $("#loginThis").show();
            $("#forgetPasswordThis").hide();
            $("#resetPwdThis").hide();

        }

        function showBillingAdd() {

            $("#billingAddressDetails").hide();
            $("#billingAddressChange").show();

        }

        function showShippingAdd() {
            $("#shippingAddressDetails").hide();
            $("#shippingAddressChange").show();
        }

        function hideBillingAdd() {

            $("#billingAddressDetails").show();
            $("#billingAddressChange").hide();

        }

        function hideShippingAdd() {
            $("#shippingAddressDetails").show();
            $("#shippingAddressChange").hide();
        }


    </script>
</asp:Content>

