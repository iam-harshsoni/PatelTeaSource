<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/Forms/AdminMaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AddDistributers.aspx.cs" Inherits="PatelTeaSource.AdminSide.Forms.AddDistributers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .txtCss {
            width: 90%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <div class="app-content content container-fluid">
        <div class="content-wrapper">
            <div class="content-header row">
                <div class="content-header-left col-md-6 col-xs-12 mb-1">
                    <h2 class="content-header-title">Distributor</h2>
                </div>
                <div class="content-header-right breadcrumbs-right breadcrumbs-top col-md-6 col-xs-12">
                    <div class="breadcrumb-wrapper col-xs-12">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a>
                            </li>
                            <li class="breadcrumb-item"><a href="DistributerLst.aspx">Distributors</a>
                            </li>
                            <li class="breadcrumb-item active"><a href="#">Add Distributor</a>
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
                                <h4 class="card-title" id="basic-layout-round-controls">Add Distributor</h4>
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
                                                 
                                                <label for="complaintinput1">Firm Name:</label>
                                                <asp:TextBox ID="txtFirmName" Height="30" CssClass="form-control" placeholder="Firm Name" runat="server" required></asp:TextBox>

                                            </div>
                                            <div class="form-group">
                                                 
                                                <label for="complaintinput1">Owner Name:</label>
                                                <asp:TextBox ID="txtOwnerName" Height="30" CssClass="form-control" placeholder="Owner Name" runat="server" required></asp:TextBox>

                                            </div>
                                            <div class="form-group">

                                                <label for="complaintinput1">Full Address:</label>
                                                <asp:TextBox ID="txtFullAdd" Height="30" CssClass="form-control" placeholder="Address.." runat="server" required></asp:TextBox>

                                            </div>
                                            <div class="form-group">

                                                <label for="complaintinput1">City:</label>
                                                <asp:TextBox ID="txtCity" Height="30" CssClass="form-control" placeholder="City" runat="server" required></asp:TextBox>

                                            </div>
                                            <div class="form-group">

                                                <label for="complaintinput1">State:</label>
                                                <asp:TextBox ID="txtState" Height="30" CssClass="form-control" placeholder="State" runat="server" required></asp:TextBox>

                                            </div>
                                           
                                            <div class="form-group">

                                                <label for="complaintinput1">Pin-Code::</label>
                                                <asp:TextBox ID="txtPincode" Height="30" CssClass="form-control" TextMode="Number" placeholder="0" runat="server" required></asp:TextBox>

                                            </div>
                                            <div class="form-group">

                                                <label for="complaintinput1">Contact Number:</label>
                                                <asp:TextBox ID="txtContact" Height="30" CssClass="form-control" MaxLength="10" TextMode="Number" placeholder="0" runat="server" required></asp:TextBox>

                                            </div>

                                             <div class="form-group">

                                                <label for="complaintinput1">Email:</label>
                                                <asp:TextBox ID="txtEmail" Height="30" CssClass="form-control" TextMode="Email" placeholder="abc@gmail.com" runat="server" required></asp:TextBox>

                                            </div>
                                              <div class="form-group">

                                                <label for="complaintinput1">Latitude:</label>
                                                <asp:TextBox ID="txtLat" Height="30" CssClass="form-control" placeholder="eg. 18.75020" runat="server" required></asp:TextBox>

                                            </div>

                                              <div class="form-group">

                                                <label for="complaintinput1">Longitude:</label>
                                                <asp:TextBox ID="txtLong" Height="30" CssClass="form-control" placeholder="eg. 18.75020" runat="server" required></asp:TextBox>

                                            </div>


                                            
                            <div class="form-actions">
                                     <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Submit" class="btn btn-primary" />
                                <%--<asp:Button ID="btnClear" runat="server" Text="Clear" class="btn btn-danger" OnClick="btnClear_Click" />--%>


                                <a onclick="clr()" class="btn btn-warning mr-1">Clear</a>
                            </div>

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

            var txtFirmName = $("#" + "<%= txtFirmName.ClientID %>");
            var txtFullAdd = $("#" + "<%= txtFullAdd.ClientID %>");
            var txtOwnerName = $("#" + "<%= txtOwnerName.ClientID %>");
            var txtCity = $("#" + "<%= txtCity.ClientID %>");
            var txtPincode = $("#" + "<%= txtPincode.ClientID %>");
            var txtContact = $("#" + "<%= txtContact.ClientID %>");
            var txtEmail = $("#" + "<%= txtEmail.ClientID %>");
            var txtState = $("#" + "<%= txtState.ClientID %>");
            var txtLat = $("#" + "<%= txtLat.ClientID %>");
            var txtLong = $("#" + "<%= txtLong.ClientID %>");

            txtFirmName.val("");
            txtOwnerName.val("");
            txtCity.val("");
            txtPincode.val("");
            txtContact.val("");
            txtEmail.val("");
            txtFullAdd.val("");
            txtState.val("");
            txtLat.val("");
            txtLong.val("");

        }

        txtLat.on('keypress', function (event) {
            var regex = new RegExp("^[0-9\b\u0000]+$");
            var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
            if (!regex.test(key)) {
                event.preventDefault();
                return false;
            }

        });

        txtLong.on('keypress', function (event) {
            var regex = new RegExp("^[0-9\b\u0000]+$");
            var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
            if (!regex.test(key)) {
                event.preventDefault();
                return false;
            }

        });

    </script>


</asp:Content>
