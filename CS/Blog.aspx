<%@ Page Title="" Language="C#" MasterPageFile="~/CS/Client.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Blog.aspx.cs" Inherits="PatelTeaSource.CS.Blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="banner" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="main" runat="server">
    <div id="main-content" class="main-content">
        <div class="page-header">
            <figure class="post-thumbnail">
                <img alt="" src="../Template/backGG.jpg" style="width: 100%;height: 140%;margin-top: 0%;"/>

            </figure>
            <h1 class="title"><span class="line-title">Blog<i class="fa">&#xf111;</i></span></h1>
        </div>
        <div class="page-content">
            <div class="container">
                
                <!-- Post -->
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                <!-- End Post -->

            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="footers" runat="server">
  
</asp:Content>
