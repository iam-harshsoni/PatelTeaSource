<%@ Page Title="" Language="C#" MasterPageFile="~/AdminSide/Forms/AdminMaster.Master" EnableEventValidation="false"  AutoEventWireup="true" CodeBehind="BlogList.aspx.cs" Inherits="PatelTeaSource.AdminSide.Forms.BlogList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.css" />
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
     <div class="app-content content container-fluid">
        <div class="content-wrapper">
            <div class="content-header row">
                <div class="content-header-left col-md-6 col-xs-12 mb-1">
                    <h2 class="content-header-title">Blog</h2>
                </div>
                <div class="content-header-right breadcrumbs-right breadcrumbs-top col-md-6 col-xs-12">
                    <div class="breadcrumb-wrapper col-xs-12">
                        <ol class="breadcrumb">
                            <li class="breadcrumb-item"><a href="Dashboard.aspx">Home</a>
                            </li> 
                            <li class="breadcrumb-item active"><a href="#">Blog</a>
                            </li>
                        </ol>
                    </div>
                </div>
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
                                <div class="card-block card-dashboard">
                                    <a href="AddBlog.aspx" class="btn btn-warning mr-1"><i class="icon-plus-circle"></i> Add Blog</a>
                                </div>
                              <div class="table-responsive" style="padding: 15px;"> 
                                <table id="table_id"  class="table table-hover mb-0">
                                        <thead>
                                            <tr>

                                                <th style="width: 4%">#</th> 
                                                 
                                                <th style="width: 25%;">Image</th>
                                                <th>Date</th>
                                                <th>Title</th>
                                                 <th>Description</th>
                                                <th>Created Date</th>
                                                <th>Updated Date</th>
                                                <th style="width:10%">Action</th>
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
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="foter" runat="server">
       <script src="../AdminSideTemplate/app-assets/js/core/libraries/jquery.min.js"></script>
       
<script type="text/javascript" charset="utf8" src="https://cdn.datatables.net/1.10.19/js/jquery.dataTables.js"></script>

    <script>
        function deleteThis(id) {

            if (confirm("Are you sure you want to delete this?")) {
                window.location.href = "DeleteBlog.aspx?id=" + id;
            }
            else {
                return false;
            }
        }

        $(document).ready(function () {
            var oTable = $('#table_id').dataTable({
                "aoColumnDefs": [{ "bSortable": false, "aTargets": [1,4,7] },
                                { "bSearchable": false, "aTargets": [1,4,7] }]
            });
        });
    </script>
</asp:Content>
