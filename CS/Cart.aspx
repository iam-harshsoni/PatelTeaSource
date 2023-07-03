<%@ Page Title="" Language="C#" MasterPageFile="~/CS/Client.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="PatelTeaSource.CS.Cart" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Template/assets/css/cartStyle.css" rel="stylesheet" />

    <style>
        .textBoxCSS {
            width: 100%;
            font-size: 20px;
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
               <li id="li_MyAcc"><a href="MyAccount.aspx" >My Account</a>
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

                <span class="line-title">Cart <i class="fa">&#xf111;</i></span>

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
                            <li role="presentation"><a href="Checkout.aspx" id="ancCheckOut" onclick="checkIt()" aria-controls="checkOut" role="tab"><i class="fa fa-credit-card " aria-hidden="true"></i>
                                <p>Checkout</p>
                            </a></li>
                            <li role="presentation"><a href="#" id="ancCompleted" aria-controls="optimization" role="tab"><i class="fa fa-check-square-o " aria-hidden="true"></i>
                                <p>Completed</p>
                            </a></li>

                        </ul>
                        <!-- end design process steps-->
                        <!-- Tab panes -->

                        
                        <div class="row">
                            <div class="col-md-8">
                                <div class="table-responsive" style="border: 0;">
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="hvr-rectangle-out btnCss" Style="font-size: 17px;padding: 6px 8px;width: 100%;text-align: center;" OnClick="LinkButton1_Click"><i class="fa fa-refresh"></i>  Update Cart  </asp:LinkButton>
                                    <br />
                                     <br />
                                    <asp:GridView ID="grvTransaction" runat="server" ShowFooter="false" AutoGenerateColumns="False"
                                        CellPadding="4" ForeColor="Black" GridLines="Horizontal" CssClass="table table-hover"
                                        Width="100%" Style="text-align: left" BackColor="White" BorderStyle="None" BorderWidth="1px" OnRowDeleting="grvStudentDetails_RowDeleting">
                                        <Columns>
                                            <asp:BoundField DataField="RowNumber" HeaderText="#" />
                                            <asp:TemplateField HeaderText="">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" Visible="false" Style="font-size: 5px; padding-left: 0; padding-right: 0" runat="server" Text="Label"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Image">
                                                <ItemTemplate>
                                                    <asp:Image ID="imgProductImg" Width="77px" runat="server" />
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Product Name">
                                                <ItemTemplate>
                                                    <div style="margin-top: 0; width: 310px;">
                                                       
                                                        <asp:Label ID="lnlProductName" runat="server" Text="Label"></asp:Label>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRate" runat="server" Text="Label"></asp:Label>

                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qty" HeaderStyle-Width="95px">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtQty" MaxLength="5" CssClass="textBoxCSS" Style="width: 70px; font-size: 15px" Text="0" AutoPostBack="false" OnTextChanged="txtQty_TextChanged" runat="server"></asp:TextBox>
                                                </ItemTemplate>

                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAmt" runat="server" Text="Label"></asp:Label>

                                                </ItemTemplate>

                                            </asp:TemplateField>

                                            <asp:CommandField ButtonType="Image" HeaderStyle-Width="55px" ControlStyle-Width="20px" DeleteImageUrl="~/Template/Images/Download/delete-icon.png" ShowDeleteButton="True" />
                                        </Columns>
                                        <%--  <FooterStyle BackColor="#cccccc" ForeColor="Black" />--%>
                                        <%--   <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />--%>
                                        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                        <%-- <HeaderStyle BackColor="#3c8dbc" Font-Bold="True" ForeColor="White" BorderColor="Black" />--%>
                                        <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                        <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                                        <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                        <SortedDescendingHeaderStyle BackColor="#242121" />
                                    </asp:GridView>

                                    <a class="hvr-rectangle-out btnCss" style="padding: 6px; width: 170px !important;margin-bottom: 20px;" href="Products.aspx"><i class="fa fa-mail-reply"></i>  Continue Shopping</a>
                                    <br />
                                </div>
                            </div>
                            <div class="col-md-4 section info-recipe" style="padding: 0;">
                                <div style="padding: 33px;">
                                    <h2 style="text-align:center"><strong>Cart Total</strong></h2>
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
                                        <asp:Label ID="lblTotal" Style="color: black; font-size: 18px;" runat="server" Text="₹540.00"></asp:Label>

                                        (includes
                                        <asp:Label ID="lblTax" runat="server" Style="color: black; font-size: 18px;" Text="Label"></asp:Label>
                                        Tax)


                                    </strong>

                                    <br />
                                    <br />
                                      <asp:Button ID="btnProceedToCart" OnClick="btnProceedToCart_Click" runat="server" CssClass="hvr-rectangle-out btnCss" Style="padding: 0; height: 50px; width: 100%; font-size: 22px;" Text="Proceed to checkout" />
                                </div>
                            </div>
                        </div>
                        <br />

                        <hr />

                        <div class="row" runat="server" id="interestedDiv">

                            <h2 class="title">
                                <span class="line-title">You may be interested in..<i class="fa">&#xf111;</i></span>
                            </h2>
                            <div class="row">
                                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                            </div>
                        </div>
                        <br />
                        <br />

                    </div>
                </div>
            </div>
        </section>
      
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="footers" runat="server">
    <script src="../AdminSide/AdminSideTemplate/app-assets/js/core/libraries/jquery.min.js"></script>

    <script>
        $('input').on('keypress', function (event) {
            var regex = new RegExp("^[0-9\b]+$");
            var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
            if (!regex.test(key)) {
                event.preventDefault();
                return false;
            }

        });

        function networkInfo() {
            alert("hell");
            var wmi = new ActiveXObject("WbemScripting.SWbemLocator");
            var service = wmi.ConnectServer(".");


            e = new Enumerator(service.ExecQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = True"));


            for (; !e.atEnd() ; e.moveNext()) {
                var s = e.item();
                var macAddress = unescape(s.MACAddress);

            }
            alert(macAddress);
            return macAddress;
        }
    </script>
</asp:Content>
