<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="printInvoice.aspx.cs" Inherits="PatelTeaSource.AdminSide.Forms.printInvoice" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <%-- <div style="text-align: center">
            <button id="cmd">generate PDF</button>
        </div>
        
        <div id="editor"></div>--%>
        <asp:Panel ID="Panel1" runat="server">
        <div id="content">
             <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder> 
          
        </div>
        </asp:Panel>
    </form>
</body>
</html>
<script src="../AdminSideTemplate/app-assets/js/core/libraries/jquery.min.js"></script>

<script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.4.1/jspdf.debug.js" integrity="sha384-THVO/sM0mFD9h7dfSndI6TS0PgAGavwKvB5hAxRRvc0o9cPLohB0wb/PTA7LdUHs" crossorigin="anonymous"></script>
<script>


    
</script>
