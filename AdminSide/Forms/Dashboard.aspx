<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/Forms/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="PatelTeaSource.AdminSide.Forms.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <div class="app-content content container-fluid">
        <div class="content-wrapper">
            <div class="content-header row">
            </div>
            <div class="content-body">
                <!-- Statistics -->
                <div class="row">
                    <div class="col-xl-3 col-lg-6 col-xs-12">
                        <div class="card">
                            <div class="card-body">
                                <a href="ProductsList.aspx">
                                <div class="media">
                                    <div class="p-2 text-xs-center bg-cyan bg-darken-2 media-left media-middle">
                                        <i class="icon-camera7 font-large-2 white"></i>
                                    </div>
                                    <div class="p-2 bg-cyan white media-body">
                                        <h5>New Products</h5>
                                        <h5 class="text-bold-400">
                                            <asp:Label ID="lblTotalProducts" runat="server" Text="0"></asp:Label>
                                            <br />
                                        </h5>
                                    </div>
                                </div>
                                    </a>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-6 col-xs-12">
                        <div class="card">
                            <div class="card-body">
                                <a href="RegisteredUsers.aspx">
                                    <div class="media">
                                        <div class="p-2 text-xs-center bg-deep-orange bg-darken-2 media-left media-middle">
                                            <i class="icon-user1 font-large-2 white"></i>
                                        </div>
                                        <div class="p-2 bg-deep-orange white media-body">
                                            <h5>Users</h5>
                                            <h5 class="text-bold-400">Admin :
                                            <asp:Label ID="lblAdminUsers" runat="server" Text="0"></asp:Label>
                                                <br />
                                                User :
                                            <asp:Label ID="lblClientUser" runat="server" Text="0"></asp:Label></h5>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-6 col-xs-12">
                        <div class="card">
                            <div class="card-body">
                                 <a href="CartOrders.aspx">
                                <div class="media">
                                    <div class="p-2 text-xs-center bg-teal bg-darken-2 media-left media-middle">
                                        <i class="icon-cart font-large-2 white"></i>
                                    </div>
                                    <div class="p-2 bg-teal white media-body">
                                        <h5>New Orders</h5>
                                        <h5 class="text-bold-400">
                                            <asp:Label ID="lblTotalOrders" runat="server" Text="0"></asp:Label></h5>
                                    </div>
                                </div>
                                     </a>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-3 col-lg-6 col-xs-12">
                        <div class="card">
                            <div class="card-body">
                                <a href="ContactUsList.aspx">
                                    <div class="media">
                                        <div class="p-2 text-xs-center bg-pink bg-darken-2 media-left media-middle">
                                            <i class="icon-banknote font-large-2 white"></i>
                                        </div>
                                        <div class="p-2 bg-pink white media-body">
                                            <h5>Contact Us</h5>
                                            <h5 class="text-bold-400">
                                                <asp:Label ID="lblContact" runat="server" Text="0"></asp:Label></h5>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foter" runat="server">
</asp:Content>
