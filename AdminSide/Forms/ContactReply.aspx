<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/Forms/AdminMaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ContactReply.aspx.cs" Inherits="PatelTeaSource.AdminSide.ContactReply" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="app-content content container-fluid">
        <div class="content-wrapper">
            <div class="content-header row">
                <div class="content-header-left col-md-6 col-xs-12 mb-1">
                    <h2 class="content-header-title">Reply Contacts</h2>
                </div>
                <div class="content-header-right breadcrumbs-right breadcrumbs-top col-md-6 col-xs-12">
                    <div class="breadcrumb-wrapper col-xs-12">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a>
                            </li>
                            <li class="breadcrumb-item"><a href="ProductsList.aspx">Contacted</a>
                            </li>
                            <li class="breadcrumb-item active"><a href="#">Reply Contacts</a>
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
                                <h4 class="card-title" id="basic-layout-round-controls">Reply Contacts</h4>
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
                                                <label for="complaintinput1">Full Name:</label>
                                                <asp:TextBox ID="txtFullName" Enabled="false" Height="30" CssClass="form-control" placeholder="Full Name" runat="server" required></asp:TextBox>

                                            </div>
                                            <div class="form-group">
                                                <label for="complaintinput1">Email Address:</label>
                                                <asp:TextBox ID="txtEmailAddress" Enabled="false" Height="30" CssClass="form-control" placeholder="Email" runat="server" required></asp:TextBox>

                                            </div>
                                            <div class="form-group">
                                                <label for="complaintinput1">Subject:</label>
                                                <asp:TextBox ID="txtSub" Enabled="false" Height="30" CssClass="form-control" placeholder="Subject" runat="server" required></asp:TextBox>

                                            </div>

                                            <div class="form-group">
                                                <label for="complaintinput1">Message:</label>
                                                <asp:TextBox ID="txtMsg" Enabled="false" TextMode="MultiLine" Rows="5" CssClass="form-control" placeholder="Message" runat="server" required></asp:TextBox>

                                            </div>
                                                <div class="form-group">
                                                <label for="complaintinput1">Reply:</label>
                                                <asp:TextBox ID="txtReply" Enabled="true" TextMode="MultiLine" Rows="5" CssClass="form-control" placeholder="Reply" runat="server" required></asp:TextBox>

                                            </div>
                                             
                                        </div>

                                        <div class="form-actions">

                                            <asp:Button ID="btnReply" OnClick="btnReply_Click" runat="server" Text="Reply" class="btn btn-primary" />

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


            var txtReply = $("#" + "<%= txtReply.ClientID %>");

            //      txtBannerHead.val("");
            txtReply.val("");

        }
    </script>

</asp:Content>
