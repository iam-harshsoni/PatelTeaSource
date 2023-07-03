using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PatelTeaSource.Repository.OrderMasterRepo;
using PatelTeaSource.Repository.OrderMasterDetailsRepo;
using PatelTeaSource.Repository.OrderMasterPaymentRepo;
using PatelTeaSource.Repository.UserLoginRepo;
using PatelTeaSource.Repository.UserMasterRepo;
using PatelTeaSource.Repository.ProductMasterRepo;
using PatelTeaSource.Repository.ProductPriceRepo;
using PatelTeaSource.Repository.ShippingAddressRepo;
using PatelTeaSource.Repository.FeedBackRepo;
using PatelTeaSource.Repository.GlobalParameterRepo;
using System.Text;
using PatelTeaSource.Model;
using System.Net;
using PatelTeaSource.Classes;
using System.Net.Mail;
using System.Configuration;
using System.Net.Mime;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class printInvoice : System.Web.UI.Page
    {
        StringBuilder html;
        long PassedOrderMasterID = 0, PassedUserId = 0, feedCode = 0;

        decimal? subtotal = 0, shippingRate = 0, totalAmt = 0, tax = 0, sgst = 0, cgst = 0, prate = 0;
        int proTax = 0;
        public printInvoice()
          : this(new ProductMasterRepository(), new ProductPriceRepository(), new OrderMasterRepository(), new OrderMasterDetailsRepository(), new OrderMasterPaymentRepository(), new UserMasterRepository(), new UserLoginRepository(), new ShippingAddressRepository(), new FeedbackRepository(), new GlobalParametersRepository())
        {
        }

        private IProductMasterRepository _iProductMasterRepository;
        private IProductPriceRepository _iProductPriceRepository;

        private IOrderMasterRepository _iOrderMasterRepository;
        private IOrderMasterDetailsRepository _iOrderMasterDetailsRepository;
        private IOrderMasterPaymentRepository _iOrderMasterPaymentRepository;

        private IUserMasterRepository _iUserMasterRepository;
        private IUserLoginRepository _iUserLoginRepository;
        private IShippingAddressRepository _iShippingAddressRepository;

        private IFeedbackRepository _iFeedbackRepository;
        private IGlobalParametersRepository _iGlobalParametersRepository;
        long passedUserId = 0;
        string msg = "";
        string apiKey = "", token = "", senderSMS = "";

        string fromEmail = "", pwds = "", userMail = "";
        public printInvoice(ProductMasterRepository productMasterRepository, ProductPriceRepository productPriceRepository, OrderMasterRepository orderMasterRepository, OrderMasterDetailsRepository orderMasterDetailsRepository, OrderMasterPaymentRepository orderMasterPaymentRepository, UserMasterRepository userMasterRepository, UserLoginRepository userLoginRepository, ShippingAddressRepository shippingAddressRepository, FeedbackRepository feedbackRepository, GlobalParametersRepository globalParametersRepository)
        {

            _iProductMasterRepository = productMasterRepository;
            _iProductPriceRepository = productPriceRepository;
            _iOrderMasterRepository = orderMasterRepository;
            _iOrderMasterDetailsRepository = orderMasterDetailsRepository;
            _iOrderMasterPaymentRepository = orderMasterPaymentRepository;
            _iUserLoginRepository = userLoginRepository;
            _iUserMasterRepository = userMasterRepository;
            _iShippingAddressRepository = shippingAddressRepository;
            _iFeedbackRepository = feedbackRepository;
            _iGlobalParametersRepository = globalParametersRepository;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
          
          PassedOrderMasterID = Convert.ToInt32(Request.QueryString["oId"]); 
                if (PassedOrderMasterID > 0)
                {
                    StringBuilder html = new StringBuilder();

                    printBody();
                    //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "hello();", true);
                    ////   ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "Confirm();", true);

                    //Response.ContentType = "application/pdf";
                    //Response.AddHeader("content-disposition", "attachment;filename=TestPage.pdf");
                    //Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    //StringWriter sw = new StringWriter();
                    //HtmlTextWriter hw = new HtmlTextWriter(sw);
                    //Panel1.RenderControl(hw);
                    //StringReader sr = new StringReader(sw.ToString());
                    //Document pdfDoc = new Document(PageSize.A4, 80f, 80f, -2f, 35f);
                    //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    //PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    //pdfDoc.Open();
                    //htmlparser.Parse(sr);
                    //pdfDoc.Close();
                    //Response.Write(pdfDoc);
                    //Response.End();
                }
                else
                {
                    return;
                }

          
        }

        private void printBody()
        {

            long orderId = Convert.ToInt32(Request.QueryString["oId"]);
            tax = 0;
            subtotal = 0;
            string body = string.Empty;

            int rowNo = 1;
            //int oId = Convert.ToInt32(Session["txnId"]);
            var orderMasterData = _iOrderMasterRepository.SelectById(orderId);

            var custData = _iUserMasterRepository.SelectById(orderMasterData.user_id);

            StringBuilder html = new StringBuilder();

           // html.Append("<body>");
            html.Append("<div>");
            html.Append("<div style='border:7px solid lightgray;'>");

            html.Append("<div class='col-md-12'>");
            html.Append("<div class='row' style='padding: 20px 26px 24px 20px;'>");
            html.Append("<table style='width:100%'>");
            html.Append("<tr>");
            html.Append("<td colspan='3'>");
            html.Append("<a href='www.pateltea.co.in'><img style='width:100px; margin-bottom:-35px;' alt='Patel Tea Packers' src='../../Template/17.png'/></a>");
            html.Append("<br />");
            html.Append("<br />");
            html.Append("<br />");
            html.Append("<span>PATEL TEA PACKERS</span>");
            html.Append("<br />");
            html.Append("<span>UNJHA - UNAVA HIGHWAY,</span>");
            html.Append("<br />");
            html.Append("<span>UNAVA</span>");
            html.Append("<br />");
            html.Append("<span><b>GSTIN : </b>24AARFP4652Q1ZF</span>");
            html.Append("<br />");
            html.Append("<span>State Name : Gujarat, Code : 24</span>");
            html.Append("<br />");
            html.Append("<span>Contact : (+91)-2767-247936</span>");
            html.Append("<br />");
            html.Append("<span>Email : pateltea@ymail.com</span>");
            html.Append("<br />");
            html.Append("<span>www.pateltea.co.in</span>");
            html.Append("<br />");

            html.Append("</td>");
            html.Append("<td>");
            html.Append("<h2 class='name' style='text-align: right;'>Tax Invoice</h2>");
            html.Append("<br />");
            html.Append("<div style='text-align: right;'>Invoice No : "+((orderMasterData.order_id) + 18)+"</div>");

            //txtinvoiceNo.Text = orderMasterData.order_id.ToString();

            html.Append("</td>");
            html.Append("</tr>");
            html.Append("</table>");
            html.Append("<hr />");
            html.Append("<div style='padding:20px;background-color:green;'>");
            html.Append("<span style='color: white;font-size: 20px;'> We delivered your Patel Tea Order with ID: #" + orderId + "</span>");
            html.Append("</div>");
            html.Append("<div style='padding: 25px;'>");
            html.Append("Hey " + custData.fname + " " + custData.lname + ",<br />");
            html.Append("Time to celebrate! <br />");
            html.Append("You order with ID: #" + orderId + " has been successfully delivered at the given address.<br />");



            html.Append("</div>");
            html.Append("<div style='text-align:center'>");
            html.Append("Contents of the package:");
            html.Append("</div>");
            html.Append("<br />");
            html.Append("<div style=''>");
            html.Append("<table style='width:100%;border-spacing:0;border-collapse:collapse;'>");
            html.Append("<thead style='height:40px;background:#f0efef;'>");
            html.Append("<tr>");

            html.Append("<td style='width:40px;text-align:center;'>#</td>");
            html.Append("<td style='width:530px;'>Product Name</td>");
            html.Append("<td style='width:100px;'>GST %</td>");
            html.Append("<td style='width:100px;'>Rate</td>");
            html.Append("<td style='width:70px;'>Qty</td>");
            html.Append("<td style='width:100px;'>Amount(Incl. Tax)</td>");
            html.Append("</tr>");
            html.Append("</thead>");
            html.Append("<tbody>"); 
           
       

            var orderMasterDetailsData = _iOrderMasterDetailsRepository.SelectAll().Where(x => x.order_id == orderId).ToList();
            shippingRate = 0;
            foreach (var item in orderMasterDetailsData)
            {

                html.Append("<tr style='border-bottom:1px solid lightgray;'>");
                html.Append("<td style='font-size:12px;color:gray;text-align:center;padding:10px;'>" + rowNo + "</td>");
               
                 

               
                var productData = _iProductMasterRepository.SelectById(item.pid);

                if (productData.shippingCharge > 0)
                {
                    shippingRate += Convert.ToDecimal(productData.shippingCharge);
                }

                html.Append("<td style='font-size:14px;color:gray;>");
                html.Append("<span>" + productData.pname + "</span>");
                html.Append(productData.pname);
                html.Append("<span style='color:orange'>");
                html.Append(productData.pname + " (" + productData.weight + " " + productData.unit + ")");
                html.Append("</span>");
                html.Append("</td>");


                html.Append("<td style='font-size:14px;color:gray;'>" + Convert.ToInt32(productData.taxPer) + "%</td>");
              

                prate = (Convert.ToDecimal(item.rate) * Convert.ToInt32(productData.taxPer)) / 100;

                prate = Convert.ToDecimal(item.rate) - prate;

                html.Append("<td style='font-size:14px;color:gray;'>&#8377;" + prate + "</td>");
                html.Append("<td style='font-size:14px;color:gray;'>");
                html.Append(item.qty);
                html.Append("</td>");
                html.Append("<td style='font-size:14px;color:gray;'>&#8377;" + item.amount + ".00</td>");
               

                subtotal += Convert.ToDecimal(item.amount);
                proTax += Convert.ToInt32(productData.taxPer);

                tax += Convert.ToDecimal(item.amount) - prate;
                html.Append("</tr>");
                
                rowNo++;
            }
            totalAmt = subtotal;

            sgst = Convert.ToDecimal(tax / 2);
            cgst = Convert.ToDecimal(tax / 2);

            #region subtotal

            html.Append("<tr style='border-bottom:1px solid lightgray;'>");
            html.Append("<td colspan='5' style='text-align:left; font-size:15px;color:gray;padding-top: 40px;'>");
            html.Append("<span>Sub Total:</span>");
            html.Append("</td>");
            html.Append("<td style='text-align:left;font-size:15px;color: gray;vertical-align: bottom;padding-bottom:10px; '>");
            html.Append("<span>&#8377; " + Convert.ToDecimal(totalAmt).ToString() + "</span>");
            html.Append("</td>");
            html.Append("</tr>");

            #endregion

            #region CGST
            html.Append("<tr style='border-bottom:1px solid lightgray;'>");
            html.Append("<td colspan='5' style='text-align:left; font-size:15px;color:gray;padding:10px;'>");
            html.Append("<span>CGST:</span>");
            html.Append("</td>");
            html.Append("<td style='text-align:left;font-size:15px;color: gray;'>");
            html.Append("<span>" + cgst.ToString() + "</span>");
            html.Append("</td>");
            html.Append("</tr>");


            #endregion

            #region SGST
            html.Append("<tr style='border-bottom:1px solid lightgray;'>");
            html.Append("<td colspan='5' style='text-align:left; font-size:15px;color:gray;padding:10px;'>");
            html.Append("<span>SGST:</span>");
            html.Append("</td>");
            html.Append("<td style='text-align:left;font-size:15px;color: gray;'>");
            html.Append("<span>" + sgst.ToString() + "</span>");
            html.Append("</td>");
            html.Append("</tr>");


            #endregion

            #region TotalTaxable Amt

            html.Append("<tr style='border-bottom:1px solid lightgray;'>");
            html.Append("<td colspan='5' style='text-align:left; font-size:15px;color:gray;padding:10px;'>");
            html.Append("<span>Total Taxable Amount:</span>");
            html.Append("</td>");
            html.Append("<td style='text-align:left;font-size:15px;color: gray;'>");
            html.Append("<span>&#8377; " + Convert.ToDecimal(tax).ToString() + "</span>");
            html.Append("</td>");
            html.Append("</tr>");



            #endregion

            #region shipping
            html.Append("<tr style='border-bottom:1px solid lightgray;'>");
            html.Append("<td colspan='5' style='text-align:left; font-size:15px;color:gray;padding:10px;'>");
            html.Append("<span>Shipping:</span>");
            html.Append("</td>");
            html.Append("<td style='text-align:left;font-size:15px;color: gray;'>");
           
            //Shipping amount if
            if (shippingRate == 0)
            {
                html.Append("<span>Free Shipping</span>");
            }
            else
            {
                totalAmt += shippingRate;
                html.Append("<span>&#8377; " + shippingRate + "</span>");
               
            }

         
            html.Append("</td>");
            html.Append("</tr>");

            #endregion

            #region totalAmt

            html.Append("<tr style='border-bottom:1px solid lightgray;'>");
            html.Append("<td colspan='5' style='text-align:left; font-size:18px;color:gray;padding:10px;'>");
            html.Append("<span>Order Total :</span>");
            html.Append("</td>");
            html.Append("<td style='text-align:left;font-size:18px;color: gray;'>");
            

            if (shippingRate == 0)
            {
                html.Append("<span>&#8377; " + totalAmt + ".00 </span>");
             
            }
            else
            {
                totalAmt += shippingRate;
                html.Append("<span>&#8377; " + totalAmt + "</span>");
                
               
            }
            html.Append("</td>");
            html.Append("</tr>");

            #endregion
            html.Append("<tr style='border-bottom:1px solid lightgray;'>");
            html.Append("<td colspan='6' style='text-align:center;padding-top:40px;padding-bottom:40px;'>");
            html.Append("<a href='https://www.pateltea.co.in/CS/MyAccount' style='border:1px solid lightgray;padding:20px;background:orange;text-decoration:none;color:white;font-size:20px;'>View Order</a>");
            html.Append("</td>");
            html.Append("</tr>");
            html.Append("<tr style='border-bottom:1px solid lightgray;'>");

            html.Append("<td colspan='6' style='text-align:left; font-size:15px;color:gray;padding:13px;'>");
            html.Append("<span><b> DELIVERY ADDRESS </b> <br /><br />");
            

             

            //Address from db
            #region Shipping Address
            var shippingAddressDetails = _iShippingAddressRepository.SelectAll().Where(x => x.user_id == orderMasterData.user_id).FirstOrDefault();

            if (shippingAddressDetails == null)
            {
                html.Append("<b>" + custData.company_name + "</b><br />");
                html.Append("<b>" + custData.fname + " " + custData.lname + "</b><br />");
                html.Append(custData.addLine1 + "<br />");
                html.Append(custData.addLine2 + "<br />");
                html.Append(custData.city + " - " + custData.pincode + "<br />");
                html.Append("Mob.:" + custData.mobile + "<br />");
                html.Append("Gujarat, India<br />");
               
               
            }
            else
            {
                html.Append("<b>" + shippingAddressDetails.companyName + "</b><br />");
                html.Append("<b>" + shippingAddressDetails.fname + " " + shippingAddressDetails.lname + "</b><br />");
                html.Append(shippingAddressDetails.line1 + "<br />");
                html.Append(shippingAddressDetails.line2 + "<br />");
                html.Append(shippingAddressDetails.city + " - " + shippingAddressDetails.pincode + "<br />");
                html.Append("Mob.:" + shippingAddressDetails.mobile + "<br />");
                html.Append("Gujarat, India<br />");
            
            }
            html.Append("</span>");
            html.Append("</td>");
            html.Append("</tr>");



            #endregion

            html.Append("<tr style='border-bottom:1px solid lightgray;'>");
            html.Append("<td colspan='6' style='text-align:left; font-size:15px;black:gray;padding:13px;'>");
            html.Append("<p style='text-align:justify'>");
            html.Append("<b> Just in case you were wondering:</b> <br /><br />If there are multiple shipments, you will be receiving the packages separately.<br /><br />We hope you are happy with your purchase and shop again with Patel Tea Packers.<span style='font-size:25px;margin-left:-6px;'>&#9786;</span><br /><br />Thanks for shopping with us!<br /><b> Team, Patel Tea Packers</b>");
            html.Append("</p>");
            html.Append("</td>");
            html.Append("</tr>");

            html.Append("<tr style='border-bottom:1px solid lightgray;'>");
            html.Append("<td colspan='6' style='text-align:left; font-size:15px;black:gray;padding:13px;'>");
            html.Append("<p style='text-align:justify;color:gray;font-size: 13px;'>");
            html.Append("<b>Note: We do not demand your banking and credit card details verbally or telephonically. Please do not divulge your details to fraudsters and imposters falsely claiming to be calling on Patel Tea Packers's behalf.");
            html.Append("</p>");
            html.Append("</td>");
            html.Append("</tr>");
            html.Append("</tbody>");
            html.Append("</table>");

            html.Append("</div>");
            html.Append("</div>");
            html.Append("</div>");
            html.Append("</div>");
           // html.Append("</<body>");

            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
        }
    }
}