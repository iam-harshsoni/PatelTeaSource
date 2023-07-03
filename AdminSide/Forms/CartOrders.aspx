<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/Forms/AdminMaster.Master" AutoEventWireup="true" CodeBehind="CartOrders.aspx.cs" Inherits="PatelTeaSource.AdminSide.Forms.CartOrders" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body.modal-open .supreme-container {
            -webkit-filter: blur(1px);
            -moz-filter: blur(1px);
            -o-filter: blur(1px);
            -ms-filter: blur(1px);
            filter: blur(1px);
        }
    </style>

    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="app-content content container-fluid supreme-container">
        <div class="content-wrapper">
            <div class="content-header row">
                <div class="content-header-left col-md-6 col-xs-12 mb-1">
                    <h2 class="content-header-title">Manage Orders</h2>
                </div>
                <div class="content-header-right breadcrumbs-right breadcrumbs-top col-md-6 col-xs-12">
                    <div class="breadcrumb-wrapper col-xs-12">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a>
                            </li>
                            <li class="breadcrumb-item active"><a href="#">Manage Orders</a>
                            </li>
                        </ol>
                    </div>
                </div>
            </div>
            <div class="alert alert-danger mb-2" id="errorDiv" visible="false" role="alert" runat="server">
                <strong>Oh snap!</strong>
                <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
                <a href="MyAccount.aspx" runat="server" id="ancError" visible="false">Click Here to go back</a>
            </div>

            <div class="content-body">

                <div class="row">
                    <div class="col-xs-12">
                        <div class="card">
                            <div class="card-header">
                                <h4 class="card-title">List</h4>
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

                                <div class="table-responsive" style="padding: 15px;" >
                                    <table id="table_id" class="table table-hover mb-0">
                                        <thead>
                                            <tr>
                                                <th># Order Number</th>
                                                <th>Customer Name</th>
                                                <th>Date</th>
                                                <th>Status</th>
                                                <th style="width: 11%; padding: 0; padding-bottom: 12px; text-align: center">Total Amt.</th>
                                                <th>Created Date</th>
                                                <th>Updated Date</th>
                                                <th style="width: 10%;">Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>

                                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                        </tbody>
                                    </table>
                                </div>
                            </div>


                        </div>
                    </div>
                </div>

                <div id="orderDetailsDiv" runat="server">

                    <div class="row">
                        <div class="col-xs-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Order Details</h4>
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

                                    <div class="table-responsive" style="padding: 15px;">
                                        <table id="myTable" class="table table-hover mb-0" >
                                            <thead>
                                                <tr>
                                                    <th>#</th>
                                                    <th>Product Img</th>
                                                    <th style="width: 25%;">Product Name</th>
                                                    <th>Qty</th>
                                                    <th>GST %</th>
                                                    <th>Rate</th>
                                                    <th>Amount</th>
                                                    <th>Created Date</th>
                                                    <th>Updated Date</th>

                                                </tr>
                                            </thead>
                                            <tbody>

                                                <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>

                <div id="customerDetailsDiv" runat="server">
                 
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Customer Details</h4>
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

                                    <h4 class="card-title" style="padding: 23px; padding-bottom: 0; padding-top: 12px;">Customer Name:
                                        <asp:Label ID="lblCustomerName" runat="server" Text="Label"></asp:Label>
                                    </h4>
                                    <hr />
                                    <div class="row" style="padding: 23px; padding-bottom: 0; padding-top: 12px;">
                                        <div class="col-md-6">
                                            <h5 class="card-title">Billing Address</h5>
                                            <br />
                                            <div>

                                                <asp:PlaceHolder ID="placeHolderBillingAdd" runat="server"></asp:PlaceHolder>

                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <h5>Shipping Address</h5>
                                            <br />
                                            <div>

                                                <asp:PlaceHolder ID="placeHolderShippingAdd" runat="server"></asp:PlaceHolder>

                                            </div>
                                        </div>
                                    </div>

                                </div>


                            </div>
                        </div>
                    </div>
                </div>

                <div id="printInvoiceDiv" runat="server" visible="false">
                    <div class="row">
                        <div class="col-xs-12">
                            <div class="card">
                                <div class="card-header">
                                    <h4 class="card-title">Invoice</h4>
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

                            </div>
                        </div>
                    </div>

                </div>
            </div>

        </div>
    </div>
    <div class="form-group">

        <div class="modal fade text-xs-left" id="backdrop" tabindex="-1" role="dialog" aria-labelledby="myModalLabel4" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <h4 class="modal-title" id="myModalLabel4">Order Number
                            <asp:Label ID="lblOrderId" runat="server" Text="Label"></asp:Label></h4>

                    </div>
                    <div class="modal-body">
                        <h5>Update Status</h5>
                        <asp:DropDownList ID="drp_Status" CssClass="form-control" runat="server">

                            <asp:ListItem Selected Value="2">Packed And Dispached </asp:ListItem>
                            <asp:ListItem Value="3">Out For Delivery </asp:ListItem>
                            <asp:ListItem Value="4">Delivered </asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn grey btn-outline-secondary" data-dismiss="modal">Close</button>

                        <asp:Button ID="btnUpdate" class="btn btn-outline-primary" OnClick="btnUpdate_Click" runat="server" Text="Update" />
                    </div>
                </div>
            </div>
        </div>



    </div>

    <asp:HiddenField ID="hdnLblValue" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foter" runat="server">
    <script src="../AdminSideTemplate/app-assets/js/core/libraries/jquery.min.js"></script>
 
   
<script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.js"></script>


    <%-- <script src="../AdminSideTemplate/assets/js/datatables.min.js"></script>--%>

    <script>
        var lblOrderId = $("#" + "<%= lblOrderId.ClientID %>");
        function orderDetails(id, status) {
            lblOrderId.text(id);

            $('#<%=hdnLblValue.ClientID %>').val(id);

            $('#<%=drp_Status.ClientID %>  option[value="' + status + '"]').attr("selected", status);
        }

        $(document).ready(function () {
            var oTable = $('#table_id').dataTable({
                "aoColumnDefs": [{ "bSortable": false, "aTargets": [7] },
                                { "bSearchable": false, "aTargets": [7] }]
            });
        });


    </script>
</asp:Content>
