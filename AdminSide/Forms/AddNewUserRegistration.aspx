<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/Forms/AdminMaster.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="AddNewUserRegistration.aspx.cs" Inherits="PatelTeaSource.AdminSide.Forms.AddNewUserRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                            <li class="breadcrumb-item"><a href="RegisteredUsers.aspx">Manage Users</a>
                            </li>
                            <li class="breadcrumb-item active"><a href="#">Add New User</a>
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
                                                <label for="exampleInputEmail1">User Name</label>
                                                <asp:TextBox ID="txtUserName" runat="server" class="form-control" placeholder="Enter User Name" required></asp:TextBox>
                                            </div>

                                            <asp:Panel ID="Panel1" runat="server">
                                                <div class="form-group">
                                                    <label for="exampleInputPassword1">Password</label>
                                                    <asp:TextBox ID="txtPassword" runat="server" type="password" class="form-control" placeholder="Password" required></asp:TextBox>

                                                </div>


                                                <div class="form-group">
                                                    <label for="exampleInputPassword1">Confirm Password</label>
                                                    <asp:TextBox ID="txtConfirmPassword" runat="server" type="password" class="form-control" placeholder="Re-Enter Password"></asp:TextBox>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password Miss-match" ControlToCompare="txtPassword" ControlToValidate="txtConfirmPassword" Font-Names="Cambria" ForeColor="Red" SetFocusOnError="True"></asp:CompareValidator>
                                                </div>
                                            </asp:Panel>
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Full Name</label>
                                                <asp:TextBox ID="txtFullName" runat="server" class="form-control" placeholder="Enter Full Name" required></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Email address</label>
                                                <asp:TextBox ID="txtEmail" runat="server" type="email" class="form-control" placeholder="Enter Email" required></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please Enter Valid Email Address" ControlToValidate="txtEmail" Font-Names="Cambria" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            </div>
                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Status</label>
                                                <asp:DropDownList ID="drp_Status" CssClass="form-control" runat="server">
                                                    <asp:ListItem Selected>Disabled</asp:ListItem>
                                                    <asp:ListItem>Enabled</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <label for="exampleInputEmail1">Role</label>
                                                <asp:DropDownList ID="drp_Role" CssClass="form-control" runat="server">
                                                    <asp:ListItem Selected>Administrator</asp:ListItem>
                                                    <asp:ListItem>Manager</asp:ListItem>
                                                    <asp:ListItem>Data Entry Operator</asp:ListItem>
                                                    <asp:ListItem>Guest</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                            <div class="form-actions">
                                                <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Submit" class="btn btn-primary" />

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

            var txtUserName = $("#" + "<%= txtUserName.ClientID %>");
            var txtPassword = $("#" + "<%= txtPassword.ClientID %>");
            var txtFullName = $("#" + "<%= txtFullName.ClientID %>");
            var txtEmail = $("#" + "<%= txtEmail.ClientID %>");
            var txtConfirmPassword = $("#" + "<%= txtConfirmPassword.ClientID %>");
            var drp_Status = $("#" + "<%= drp_Status.ClientID %>");
            var drp_Role = $("#" + "<%= drp_Role.ClientID %>");
         
            txtUserName.val("");
            txtPassword.val("");
            txtFullName.val("");
            txtEmail.val("");
            txtConfirmPassword.val("");
           

            $('select[id="drp_Role"] option[value="Administrator"]').attr("selected", "Administrator");
            $('select[id="drp_Status"] option:selected').attr("selected", "1");
        }
    </script>



</asp:Content>
