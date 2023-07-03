<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintMainReceipt.aspx.cs" Inherits="PatelTeaSource.AdminSide.Forms.PrintMainReceipt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        .fnts {
            font-size: 10px;
        }

        .auto-style5 {
            width: 951px;
            height: 23px;
        }

        .auto-style6 {
            width: 951px;
        }

        .auto-style7 {
            width: 998px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server">

                <div style='border: 7px solid lightgray;'>

                    <div class='col-md-12'>

                        <div class='row'>


                            <table style='width: 100%'>

                                <tr>
                                    <td>
                                        <%--<img style='width: 100px; margin-bottom: -35px;' alt='Patel Tea Packers' src='E:/Projects/PatelTeaUnja/PatelTeaSource/PatelTeaSource/Template/17 - Copy.png' />--%>
                                        <br />

                                        <span class="fnts"><b>PATEL TEA PACKERS</b></span>
                                        <br />
                                        <span class="fnts">UNJHA - UNAVA HIGHWAY,</span>
                                        <br />
                                        <span class="fnts">UNAVA</span>
                                        <br />

                                        <span class="fnts">State Name : Gujarat, Code : 24</span>
                                        <br />
                                        <span class="fnts">Contact : (+91)-2767-256254 </span>
                                        <br />
                                        <span class="fnts">Email : pateltea@ymail.com</span>
                                        <br />
                                        <span class="fnts">www.pateltea.co.in</span>
                                        <br />
                                    </td>

                                    <td style="vertical-align: top;">
                                        <h4 class='fnts' style='text-align: right;'><b>Tax Invoice/Bill of Supply/Cash Memo</b></h4>

                                        <div style='text-align: right;' class="fnts">
                                            <span class="fnts"><b>PAN No : </b>AARFP4652Q</span>
                                            <br />
                                            <span class="fnts"><b>GSTIN : </b>24AARFP4652Q1ZF</span>
                                            <br />
                                        </div>
                                    </td>
                                </tr>
                                <tr border="1">
                                    <td>

                                        <b>Billing Address: </b>
                                        <br />
                                        <span class="fnts">
                                            <asp:Label ID="lblCompanyName" runat="server" Text="Label"></asp:Label></span>
                                        <br />
                                        <span class="fnts">
                                            <b>
                                                <asp:Label ID="lblCustName" runat="server" Text="Label"></asp:Label></b>,</span>
                                        <br />
                                        <span class="fnts">
                                            <asp:Label ID="lblLine1" runat="server" Text="Label"></asp:Label></span>
                                        <br />
                                        <span class="fnts">
                                            <asp:Label ID="lblLine2" runat="server" Text="Label"></asp:Label></span>
                                        <br />
                                        <span class="fnts">
                                            <asp:Label ID="lblCity" runat="server" Text="Label"></asp:Label>
                                            -
                                            <asp:Label ID="lblPincode" runat="server" Text="Label"></asp:Label>

                                        </span>
                                        <br />
                                        <span class="fnts">Contact :
                                            <asp:Label ID="lblContact" runat="server" Text="Label"></asp:Label></span>
                                        <br />
                                        <span class="fnts">Gujarat, India</span>
                                        <br />

                                    </td>

                                    <td>
                                        <br />

                                        <div style="text-align: right">
                                            <b>Shipping Address: </b>
                                            <br />
                                            <span class="fnts">
                                                <asp:Label ID="lblCompanyNameShipping" runat="server" Text="Label"></asp:Label></span>
                                            <br />
                                            <span class="fnts">
                                                <b>
                                                    <asp:Label ID="lblCustNameshipping" runat="server" Text="Label"></asp:Label></b>,</span>
                                            <br />
                                            <span class="fnts">
                                                <asp:Label ID="lblLine1Shipping" runat="server" Text="Label"></asp:Label></span>
                                            <br />
                                            <span class="fnts">
                                                <asp:Label ID="lblLine2Shipping" runat="server" Text="Label"></asp:Label></span>
                                            <br />
                                            <span class="fnts">
                                                <asp:Label ID="lblCityShipping" runat="server" Text="Label"></asp:Label>
                                                -
                                                <asp:Label ID="lblPincodeSHipping" runat="server" Text="Label"></asp:Label>

                                            </span>
                                            <br />
                                            <span class="fnts">Contact :
                                                <asp:Label ID="lblContactShipping" runat="server" Text="Label"></asp:Label></span>
                                            <br />
                                            <span class="fnts">Gujarat, India</span>
                                            <br />

                                        </div>
                                    </td>

                                </tr>

                                <tr>
                                    <td>

                                        <br />
                                        <b>Order Number: </b><span class="fnts">
                                            <asp:Label ID="lblOrderNo" runat="server" Text="Label"></asp:Label></span>
                                        <br />
                                        <b>Order Date: </b><span class="fnts">
                                            <asp:Label ID="lblOrderDate" runat="server" Text="Label"></asp:Label></span>
                                        <br />
                                    </td>

                                    <td style="vertical-align: top; text-align: left">
                                        <br />

                                        <div style="text-align: right">
                                            <b>Invoice Number: </b><span class="fnts">
                                                <asp:Label ID="lblInvoiceNo" runat="server" Text="Label"></asp:Label></span>
                                            <br />

                                            <b>Invoice Date: </b><span class="fnts">
                                                <asp:Label ID="lblInvoiceDate" runat="server" Text="Label"></asp:Label></span>
                                            <br />
                                        </div>
                                    </td>
                                </tr>
                            </table>


                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" border="1">
                                <Columns>
                                    <asp:BoundField HeaderText="ID" DataField="rowNo" />
                                     <asp:BoundField HeaderText="Product Name" DataField="productName" />
                                     <asp:BoundField HeaderText="Rate" DataField="rate" />
                                     <asp:BoundField HeaderText="Gst%" DataField="taxRate" />
                                     <asp:BoundField HeaderText="Qty" DataField="qty" />
                                    <asp:BoundField HeaderText="Amount (Incl. All Taxes)" DataField="amount" />
                                </Columns>
                            </asp:GridView>



                            <br />
                            <table style="width: 100%" border="1">
                                <tr>
                                    <td class="auto-style6" style="text-align: right"><span>Sub Total:</span> </td>
                                    <td style="text-align: center"><span>&#8360;
                                        <asp:Label ID="lblSubTotal" runat="server" Text="Label"></asp:Label></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style5" style="text-align: right"><span>CGST:</span> </td>
                                    <td style="text-align: center"><span>₹ 
                                        <asp:Label ID="lblCGST" runat="server" Text="Label"></asp:Label></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style6" style="text-align: right"><span>SGST:</span> </td>
                                    <td style="text-align: center"><span>₹ 
                                        <asp:Label ID="lblSGST" runat="server" Text="Label"></asp:Label></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style6" style="text-align: right"><span>Total Taxable Amount:</span> </td>
                                    <td style="text-align: center"><span>₹ 
                                        <asp:Label ID="lblTotalTaxable" runat="server" Text="Label"></asp:Label></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style6" style="text-align: right"><span>Shipping:</span> </td>
                                    <td style="text-align: center"><span>₹ 
                                        <asp:Label ID="lblShipping" runat="server" Text="Label"></asp:Label></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="auto-style6" style="text-align: right"><span>Total Amount:</span> </td>
                                    <td style="text-align: center"><span>₹ 
                                        <asp:Label ID="lblAmount" runat="server" Text="Label"></asp:Label></span>
                                    </td>
                                </tr>
                            </table>

                            <table border="1">
                                <tr>
                                    <td>
                                        <div style="text-align: right" class="auto-style7">
                                            <b>For Patel Tea Packers:</b>
                                            <br />
                                            <br />
                                            <br />
                                            <br />
                                            <b>Authorized Signatory</b>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>

            </asp:Panel>
        </div>
    </form>
</body>
</html>
