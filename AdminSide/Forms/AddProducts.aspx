<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/Forms/AdminMaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AddProducts.aspx.cs" Inherits="PatelTeaSource.AdminSide.Forms.AddProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <div class="app-content content container-fluid">
        <div class="content-wrapper">
            <div class="content-header row">
                <div class="content-header-left col-md-6 col-xs-12 mb-1">
                    <h2 class="content-header-title">Add Products</h2>
                </div>
                <div class="content-header-right breadcrumbs-right breadcrumbs-top col-md-6 col-xs-12">
                    <div class="breadcrumb-wrapper col-xs-12">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a>
                            </li>
                            <li class="breadcrumb-item"><a href="ProductsList.aspx">Products</a>
                            </li>
                            <li class="breadcrumb-item active"><a href="#">Add Products</a>
                            </li>
                        </ol>
                    </div>
                </div>
            </div>
            <div class="content-body">
                <div class="row match-height">
                    <div class="col-md-12">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title" id="basic-layout-round-controls">Add Products</h4>
                                <a class="heading-elements-toggle"><i class="icon-ellipsis font-medium-3"></i></a>
                                <div class="heading-elements">
                                    <ul class="list-inline mb-0">
                                        <li><a data-action="collapse"><i class="icon-minus4"></i></a></li>
                                        <li><a data-action="reload"><i class="icon-reload"></i></a></li>
                                        <li><a data-action="expand"><i class="icon-expand2"></i></a></li>
                                        <li><a data-action="close"><i class="icon-cross2"></i></a></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="card-body collapse in">
                                <div class="card-block">

                                    <form class="form">
                                        <div class="form-body">

                                            <div class="form-group">
                                                <label for="complaintinput1">Product Name:</label>
                                                <asp:textbox id="txtProductName" height="30" cssclass="form-control" placeholder="Product Name" runat="server" required></asp:textbox>

                                            </div>
                                            <div class="form-group">

                                                <label for="complaintinput3">Upload Product Image (300x510):</label>

                                                <asp:fileupload id="FileUpload1" runat="server" />
                                                <br />
                                                <asp:label id="Label1" runat="server"></asp:label>


                                            </div>
                                            <div class="form-group">
                                                <label for="complaintinput2">Product Description:</label>

                                                <asp:textbox id="txtDesc" cssclass="form-control" rows="5" placeholder="description" textmode="MultiLine" columns="5" runat="server"></asp:textbox>
                                            </div>

                                            <div class="row">
                                                <div class="col-md-4 col-4">
                                                    <div class="form-group">
                                                        <label for="complaintinput1">Weight:</label>
                                                        <asp:textbox id="txtWeight" height="30" cssclass="form-control" placeholder="weight" runat="server" required></asp:textbox>

                                                    </div>

                                                </div>
                                                <div class="col-md-2 col-2">
                                                    <label for="complaintinput1">Unit</label>
                                                    <asp:dropdownlist id="drpUnit" cssclass="form-control" runat="server">
                                                       
                                                        <asp:ListItem>Gram</asp:ListItem>
                                                        <asp:ListItem>Kg</asp:ListItem>
                                                    </asp:dropdownlist>
                                                </div>
                                            </div>
                                            <div class="form-group">

                                                <label for="complaintinput3">Upload Nutrition Image (1280x967):</label>

                                                <asp:fileupload id="FileUpload2" runat="server" />
                                                <br />
                                                <asp:label id="Label2" runat="server"></asp:label>

                                            </div>

                                            <div class="form-group">
                                                <label for="complaintinput1">Shipping Charges:</label>
                                                <asp:textbox id="txtShippingCharges" height="30" cssclass="form-control" placeholder="0.00" runat="server" required></asp:textbox>

                                            </div>

                                            <div class="form-group">
                                                <label for="complaintinput1">Tax %:</label>
                                                <asp:textbox id="txtTax" height="30" cssclass="form-control" placeholder="0" runat="server" required></asp:textbox>
                                                
                                            </div>
                                            <div class="form-group">
                                                <label for="complaintinput1">Discount %:</label>
                                                <asp:textbox id="txtDisc" height="30" cssclass="form-control" placeholder="0" runat="server" required></asp:textbox>
                                            </div>
                                            <span style="color:red">Note: Add Discount in % only if there is any offer</span>

                                              <div class="form-group">

                                                <label for="complaintinput3">Upload Offer Image (1280x967):</label>

                                                <asp:fileupload id="FileUpload3" runat="server" />
                                                <br />
                                                <asp:label id="Label3" runat="server"></asp:label>

                                            </div>


                                            <div class="form-group">
                                                <label for="complaintinput1">Price:</label>
                                                <asp:textbox id="txtPrice" height="30" cssclass="form-control" placeholder="0.00" runat="server" required></asp:textbox>

                                            </div>

                                        </div>


                                        <div class="form-actions"> 
                                            <asp:button id="btnSubmit" onclick="btnSubmit_Click" runat="server" text="Submit" class="btn btn-primary" />

                                            <a onclick="clr()" class="btn btn-warning mr-1">Clear</a>
                                        </div>
                                    </form>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foter" runat="server">
    <script src="../AdminSideTemplate/app-assets/js/core/libraries/jquery.min.js"></script>
    <script>

        function clr() {


            var txtProductName = $("#" + "<%= txtProductName.ClientID %>");
            var txtPrice = $("#" + "<%= txtPrice.ClientID %>");
            var txtShippingCharges = $("#" + "<%= txtShippingCharges.ClientID %>");
            var txtTax = $("#" + "<%= txtTax.ClientID %>");
            var txtWeight = $("#" + "<%= txtWeight.ClientID %>");
            var txtDesc = $("#" + "<%= txtDesc.ClientID %>");
            //      txtBannerHead.val("");

            txtProductName.val("");
            txtPrice.val("");
            txtShippingCharges.val("");
            txtTax.val("");
            txtWeight.val("");
            txtDesc.val("");

        }
    </script>

</asp:Content>
