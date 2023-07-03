<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Epage.aspx.cs" Inherits="PatelTeaSource.Epage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server">
                Harsh Soni
            </asp:Panel>
        </div>


        <div id="content">
            <h3>Hello, this is a H3 tag</h3>

            <p>A paragraph</p>
        </div>
        <div id="editor"></div>
        <button id="cmd">generate PDF</button>
    </form>
</body>



</html>
<script src="../AdminSide/AdminSideTemplate/app-assets/js/core/libraries/jquery.min.js"></script>

<script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.4.1/jspdf.debug.js" integrity="sha384-THVO/sM0mFD9h7dfSndI6TS0PgAGavwKvB5hAxRRvc0o9cPLohB0wb/PTA7LdUHs" crossorigin="anonymous"></script>

