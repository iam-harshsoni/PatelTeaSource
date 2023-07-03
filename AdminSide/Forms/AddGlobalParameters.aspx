<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/Forms/AdminMaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AddGlobalParameters.aspx.cs" Inherits="PatelTeaSource.AdminSide.Forms.AddGlobalParameters" %>
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
                    <h2 class="content-header-title">Global Parameters</h2>
                </div>
                <div class="content-header-right breadcrumbs-right breadcrumbs-top col-md-6 col-xs-12">
                    <div class="breadcrumb-wrapper col-xs-12">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a>
                            </li>
                            <li class="breadcrumb-item"><a href="GlobalParamList.aspx">Global Parameters</a>
                            </li>
                            <li class="breadcrumb-item active"><a href="#">Add Global Parameters</a>
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
                                <h4 class="card-title" id="basic-layout-round-controls">Add Global Parameters</h4>
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
                                                 
                                                <label for="complaintinput1">Parameter Key:</label>
                                                <asp:TextBox ID="txtParamkey" Height="30" CssClass="form-control" placeholder="Param key" runat="server" required></asp:TextBox>

                                            </div>
                                            <div class="form-group">
                                                 
                                                <label for="complaintinput1">Parameter Value:</label>
                                                <asp:TextBox ID="txtParamValue" Height="30" CssClass="form-control" placeholder="Param value" runat="server" required></asp:TextBox>
 

                                            </div>
                                            <div class="form-group">
                                                 
                                                <label for="complaintinput1">Description:</label>
                                                <asp:TextBox ID="txtDesc" TextMode="MultiLine" Rows="5" CssClass="form-control" placeholder="Description" runat="server"></asp:TextBox>
 

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

            var txtParamValue = $("#" + "<%= txtParamValue.ClientID %>");
            var txtParamkey = $("#" + "<%= txtParamkey.ClientID %>");
          

            txtParamValue.val("");
            txtParamkey.val("");
           
            
        }
    </script>
</asp:Content>
