<%@ Page Title="" Language="C#" MasterPageFile="~/CS/Client.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="PayUMoneyPayment.aspx.cs" Inherits="PatelTeaSource.CS.PayUMoneyPayment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="https://code.jquery.com/jquery-latest.min.js" type="text/javascript"></script>
    <!-- this meta viewport is required for BOLT //-->
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">
    <!-- BOLT Sandbox/test //-->
    <%--<script id="bolt" src="https://sboxcheckout-static.citruspay.com/bolt/run/bolt.min.js" bolt-color="e34524" bolt-logo="http://boltiswatching.com/wp-content/uploads/2015/09/Bolt-Logo-e14421724859591.png"></script>--%>
    <!-- BOLT Production/Live //-->
    <script id="bolt" src="https://checkout-static.citruspay.com/bolt/run/bolt.min.js" bolt-color="e34524" bolt-logo="http://boltiswatching.com/wp-content/uploads/2015/09/Bolt-Logo-e14421724859591.png"></script>



    <style>
        span.text {
            float: left;
            width: 180px;
        }

        div.dv {
            margin-bottom: 5px;
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
            <li id="li_MyAcc"><a href="MyAccount.aspx"><i class="fa fa-user"></i> My Account</a></li>
         

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

                <span class="line-title">Order Confirmation<i class="fa">&#xf111;</i></span>

            </h1>

        </div>

        <div style="text-align: center"> 

            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-4">
                    <table class="table" style="margin-top: 25px;">
                        <tbody style="text-align: left">
                            <tr style="border-top: 2px solid white">
                                <td style="width: 250px;">Order Number:</td>
                                <td>
                                    <asp:Label ID="lblOrderNumber" runat="server" Text="Label"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 250px;">Customer Name:</td>
                                <td>
                                    <asp:Label ID="lblCustomerNumber" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 250px;">Mobile Number:</td>
                                <td>
                                    <asp:Label ID="lblMobile" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 250px;">Registered Email Address</td>
                                <td>
                                    <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr>
                                <td style="width: 250px;">Total Amount</td>
                                <td>
                                    <asp:Label ID="lblAmt" runat="server" Text="Label"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="2"><input type="submit" value="Pay Now" style="width: 100%" class="btn btn-danger" onclick="launchBOLT(); return false;" />
         </td> 
                            </tr>

                        </tbody>
                    </table>
                </div>
                <div class="col-md-4"></div>
            </div>

        </div>
        <div style="visibility: hidden">
            <asp:TextBox ID="txtKey" runat="server"></asp:TextBox>

            <asp:TextBox ID="txtSalt" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtTxnid" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtPinfo" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtfname" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
            <asp:TextBox ID="txtHash" runat="server"></asp:TextBox>

            <input type="hidden" id="udf5" name="udf5" value="BOLT_KIT_ASP.NET" />
            <input type="hidden" id="surl" name="surl" value="<%= Session["surl"]%>" />
        </div> 
        <br />
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="footers" runat="server">
    <script type="text/javascript"><!--

    var key = $("#" + "<%= txtKey.ClientID %>");
        var txnid = $("#" + "<%= txtTxnid.ClientID %>");
        var hash = $("#" + "<%= txtHash.ClientID %>");
        var amount = $("#" + "<%= txtAmount.ClientID %>");
        var email = $("#" + "<%= txtEmail.ClientID %>");
        var mobile = $("#" + "<%= txtMobile.ClientID %>");
        var pinfo = $("#" + "<%= txtPinfo.ClientID %>");
        var fname = $("#" + "<%= txtfname.ClientID %>");
        var txtSalt = $("#" + "<%= txtSalt.ClientID %>");

        function launchBOLT() {

            bolt.launch({
                key: key.val(),
                txnid: txnid.val(),
                hash: hash.val(),
                amount: amount.val(),
                firstname: fname.val(),
                email: email.val(),
                phone: mobile.val(),
                productinfo: pinfo.val(),
                udf5: $('#udf5').val(),
                surl: $('#surl').val(),
                furl: $('#surl').val()
            }, {
                responseHandler: function (BOLT) {
                    console.log(BOLT.response.txnStatus);
                    if (BOLT.response.txnStatus != 'CANCEL') {
                        //Salt is passd here for demo purpose only. For practical use keep salt at server side only.
                        var fr = '<form action=\"' + $('#surl').val() + '\" method=\"post\">' +
                '<input type=\"hidden\" name=\"key\" value=\"' + BOLT.response.key + '\" />' +
                '<input type=\"hidden\" name=\"salt\" value=\"' + txtSalt.val() + '\" />' +
                '<input type=\"hidden\" name=\"txnid\" value=\"' + BOLT.response.txnid + '\" />' +
                '<input type=\"hidden\" name=\"amount\" value=\"' + BOLT.response.amount + '\" />' +
                '<input type=\"hidden\" name=\"productinfo\" value=\"' + BOLT.response.productinfo + '\" />' +
                '<input type=\"hidden\" name=\"firstname\" value=\"' + BOLT.response.firstname + '\" />' +
                '<input type=\"hidden\" name=\"email\" value=\"' + BOLT.response.email + '\" />' +
                '<input type=\"hidden\" name=\"udf5\" value=\"' + BOLT.response.udf5 + '\" />' +
                '<input type=\"hidden\" name=\"mihpayid\" value=\"' + BOLT.response.mihpayid + '\" />' +
                '<input type=\"hidden\" name=\"status\" value=\"' + BOLT.response.status + '\" />' +
                '<input type=\"hidden\" name=\"hash\" value=\"' + BOLT.response.hash + '\" />' +
                '</form>';
                        var form = jQuery(fr);
                        jQuery('body').append(form);
                        form.submit();
                    }
                },
                catchException: function (BOLT) {
                    alert(BOLT.message);
                }
            });
        }
    </script>
</asp:Content>
