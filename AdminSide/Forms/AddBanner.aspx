<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/Forms/AdminMaster.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="AddBanner.aspx.cs" Inherits="PatelTeaSource.AdminSide.AddBanner" %>


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
                    <h2 class="content-header-title">Main Banner</h2>
                </div>
                <div class="content-header-right breadcrumbs-right breadcrumbs-top col-md-6 col-xs-12">
                    <div class="breadcrumb-wrapper col-xs-12">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a>
                            </li>
                            <li class="breadcrumb-item"><a href="MainBannerLst.aspx">Main Banners</a>
                            </li>
                            <li class="breadcrumb-item active"><a href="#">Add Banner</a>
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
                                <h4 class="card-title" id="basic-layout-round-controls">Add Banner</h4>
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
                                                <label for="complaintinput1">Banner Header:</label>
                                                <asp:TextBox ID="txtBannerHead" Height="30" CssClass="form-control" placeholder="Banner Header" runat="server"></asp:TextBox>

                                            </div>

                                            <div class="form-group">
                                                <label for="complaintinput2">Header Description:</label>

                                                <asp:TextBox ID="txtDesc" CssClass="form-control" Rows="5" placeholder="description" TextMode="MultiLine" Columns="5" runat="server"></asp:TextBox>
                                            </div>

                                            <div class="form-group">

                                                <label for="complaintinput3">Upload Banner (1920x675):</label>

                                                <asp:FileUpload ID="FileUpload1" runat="server"/>
                                                <br />
                                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                                <asp:Label ID="Label2" runat="server"></asp:Label>

                                            </div>
                                        </div>

                                        <div class="form-actions"> 

                                            <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Submit" class="btn btn-primary" />
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

            var txtBannerHead = $("#" + "<%= txtBannerHead.ClientID %>");
            var txtDesc = $("#" + "<%= txtDesc.ClientID %>");

            txtBannerHead.val("");
            txtDesc.val("");

        }
    </script>


</asp:Content>

