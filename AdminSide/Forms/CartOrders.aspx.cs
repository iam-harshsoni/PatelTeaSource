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
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class CartOrders : System.Web.UI.Page
    {
        StringBuilder html;
        long PassedOrderMasterID = 0, PassedUserId = 0, feedCode = 0;

        decimal? subtotal = 0, shippingRate = 0, totalAmt = 0, tax = 0, sgst = 0, cgst = 0, prate = 0;
        int proTax = 0;
        public CartOrders()
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
        DecimalFormat dcFormat = new DecimalFormat();
        public CartOrders(ProductMasterRepository productMasterRepository, ProductPriceRepository productPriceRepository, OrderMasterRepository orderMasterRepository, OrderMasterDetailsRepository orderMasterDetailsRepository, OrderMasterPaymentRepository orderMasterPaymentRepository, UserMasterRepository userMasterRepository, UserLoginRepository userLoginRepository, ShippingAddressRepository shippingAddressRepository, FeedbackRepository feedbackRepository, GlobalParametersRepository globalParametersRepository)
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
            try
            {
                if (!IsPostBack)
                {
                    passedUserId = Convert.ToInt32(Session["u_id"]);

                    if (passedUserId != 0)
                    {

                        orderDetailsDiv.Visible = false;
                        customerDetailsDiv.Visible = false;

                        #region OrderMaster List

                        var dataOrder = _iOrderMasterRepository.SelectAll().OrderByDescending(x => x.order_id);
                        if (dataOrder.Count() > 0)
                        {
                            foreach (var item in dataOrder)
                            {
                                html = new StringBuilder();

                                html.Append("<tr>");

                                var hrefOrder = "CartOrders.aspx?ordId=" + item.order_id;

                                html.Append("<td>"); html.Append("<a href='" + hrefOrder + "'># " + item.order_id + "</a>"); html.Append("</td>");

                                var customerName = _iUserMasterRepository.SelectById(item.user_id);
                                if (customerName != null)
                                {
                                    var custHref = "CartOrders.aspx?CustId=" + customerName.user_id;

                                    html.Append("<td>"); html.Append("<a href='" + custHref + "' >" + customerName.fname + " " + customerName.lname + "</a>"); html.Append("</td>");
                                }
                                else
                                {
                                    html.Append("<td>"); html.Append(" -- "); html.Append("</td>");
                                }

                                html.Append("<td>"); html.Append(Convert.ToDateTime(item.order_datetime).ToString("dd-MM-yyyy HH:mm:ss")); html.Append("</td>");

                                if (item.order_status == 0)
                                {
                                    // 0:Pending Payment
                                    // Disable tracking and only show status 
                                    html.Append("<td style='color:red'>"); html.Append("<b>Pending Payment</b>"); html.Append("</td>");
                                }
                                else if (item.order_status == 1)
                                {
                                    //1:Ordered
                                    html.Append("<td>"); html.Append("Order Confirmed"); html.Append("</td>");
                                }
                                else if (item.order_status == 2)
                                {
                                    // 2:Packed And Dispached 
                                    html.Append("<td>"); html.Append("Packed And Dispached "); html.Append("</td>");
                                }
                                else if (item.order_status == 3)
                                {
                                    //3:Out For Delivery
                                    html.Append("<td>"); html.Append("Out For Delivery"); html.Append("</td>");

                                }
                                else if (item.order_status == 4)
                                {
                                    //4:Delivered
                                    html.Append("<td style='color:green'>"); html.Append("Delivered"); html.Append("</td>");

                                }
                                else
                                {
                                    //5:Canceled
                                    html.Append("<td style='color:red'>"); html.Append("Canceled"); html.Append("</td>");

                                }
                                html.Append("<td style='padding:0;vertical-align: middle;text-align: center;'>"); html.Append("&#8377; " + item.gtotal); html.Append("</td>");

                                html.Append("<td>"); html.Append(Convert.ToDateTime(item.cdate).ToString("dd-MM-yyyy HH:mm:ss")); html.Append("</td>");

                                if (item.udate == null)
                                {
                                    html.Append("<td style='text-align:center'>"); html.Append("--"); html.Append("</td>");

                                }
                                else
                                {
                                    html.Append("<td>"); html.Append(Convert.ToDateTime(item.udate).ToString("dd-MM-yyyy HH:mm:ss")); html.Append("</td>");
                                }
                                html.Append("<td>");
                                string hrfEdit = "CartOrder.aspx?id=" + item.order_id;
                                if (item.order_status != 5 && item.order_status != 0 && item.order_status != 4)
                                {
                                    html.Append("<a href='" + hrfEdit + "' data-toggle='modal' data-backdrop='false' data-target='#backdrop' class='icon-pencil2' style='font-size:large' onclick='orderDetails(" + item.order_id + "," + item.order_status + ")'></a> | ");
                                    //html.Append("<a href='" + hrfDelete + "' class='icon-remove' style='font-size:large'></a>  ");

                                }

                                string hrfEdits = "PrintMainReceipt.aspx?oId=" + item.order_id;

                                html.Append("<a href='" + hrfEdits + "' class='icon-print' style='font-size:large'></a>");

                                html.Append("</td>");
                                html.Append("</tr>");


                                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
                            }
                        }
                        else
                        {
                            html = new StringBuilder();

                            html.Append("<tr>");
                            html.Append("<td colspan='8' style='text-align:center'>"); html.Append("<b>No records found.</b>"); html.Append("</td>");
                            html.Append("</tr>");
                            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
                        }
                        #endregion

                        #region OrderDetails

                        PassedOrderMasterID = Convert.ToInt32(Request.QueryString["ordId"]);

                        if (PassedOrderMasterID > 0)
                        {
                            orderDetailsDiv.Visible = true;
                            customerDetailsDiv.Visible = false;

                            var dataOrderDetails = _iOrderMasterDetailsRepository.SelectAll().Where(x => x.order_id == PassedOrderMasterID).ToList();
                            int rowNo = 1;
                            foreach (var item in dataOrderDetails)
                            {
                                html = new StringBuilder();

                                html.Append("<tr>");
                                html.Append("<td style='padding: 0;text-align:center;vertical-align: middle;'>"); html.Append(rowNo); html.Append("</td>");

                                var pImgName = _iProductMasterRepository.SelectById(item.pid);

                                string imagename = "../AdminSideData/ProductsImages/" + pImgName.photo.ToString();
                                //Image1.ImageUrl = "~/AdminSide/AdminSideData/BannerImages/" + imagename;
                                html.Append("<td style='padding: 0;text-align:center;vertical-align: middle;'>"); html.Append("<img style='width: 65%;' alt='' src='" + imagename + "'/>"); html.Append("</td>");

                                html.Append("<td style='padding: 0;text-align:center;vertical-align: middle;'>"); html.Append(pImgName.pname + "<br /> <span style='color:orange'>(" + Convert.ToInt32(pImgName.weight) + " " + pImgName.unit.Trim() + ")</span> "); html.Append("</td>");

                                html.Append("<td style='padding: 0;text-align:center;vertical-align: middle;'>"); html.Append(item.qty); html.Append("</td>");
                                html.Append("<td style='padding: 0;text-align:center;vertical-align: middle;'>"); html.Append(Convert.ToInt32(pImgName.taxPer) +" %"); html.Append("</td>");

                                //prate = (Convert.ToDecimal(item.rate) * Convert.ToInt32(pImgName.taxPer)) / (100 + Convert.ToInt32(pImgName.taxPer));


                                prate = Convert.ToDecimal(item.rate);

                                html.Append("<td style='padding: 0;text-align:center;vertical-align: middle;'>"); html.Append("&#8377; " + dcFormat.DoFormat(prate)); html.Append("</td>");
                                html.Append("<td style='padding: 0;text-align:center;vertical-align: middle;'>"); html.Append("&#8377; " + dcFormat.DoFormat(item.amount)); html.Append("</td>");
                                html.Append("<td style='padding: 0;text-align:center;vertical-align: middle;'>"); html.Append(Convert.ToDateTime(item.cdate).ToString("dd-MM-yyyy HH:mm:ss")); html.Append("</td>");

                                if (item.udate == null)
                                {
                                    html.Append("<td style='padding: 0;text-align:center;vertical-align: middle;'>"); html.Append("--"); html.Append("</td>");

                                }
                                else
                                {
                                    html.Append("<td style='padding: 0;text-align:center;vertical-align: middle;'>"); html.Append(Convert.ToDateTime(item.udate).ToString("dd-MM-yyyy HH:mm:ss")); html.Append("</td>");
                                }

                                html.Append("</tr>");

                                rowNo++;
                                PlaceHolder2.Controls.Add(new Literal { Text = html.ToString() });
                            }
                        }

                        #endregion

                        #region Customer Details

                        PassedUserId = Convert.ToInt32(Request.QueryString["CustId"]);

                        if (PassedUserId > 0)
                        {
                            orderDetailsDiv.Visible = false;
                            customerDetailsDiv.Visible = true;

                            var billingAddData = _iUserMasterRepository.SelectByUserID(PassedUserId).FirstOrDefault();
                            var shippingAddData = _iShippingAddressRepository.SelectAll().Where(x => x.user_id == PassedUserId).FirstOrDefault();

                            billingAndShippingAddress(billingAddData, shippingAddData);
                        }

                        #endregion

                        #region billInvoice
                        PassedOrderMasterID = Convert.ToInt32(Request.QueryString["idSt"]);

                        if (PassedOrderMasterID > 0)
                        {
                            orderDetailsDiv.Visible = false;
                            customerDetailsDiv.Visible = false;

                            printInvoiceDiv.Visible = true;


                        }
                        #endregion


                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
            }
            catch (Exception x)
            {

            }
        }

        private void billingAndShippingAddress(user_master billingAddData, shipping_address_master shippingAddData)
        {
            #region Billing And Shipping Address Code

            #region Billing Address

            html = new StringBuilder();

            if (billingAddData.addLine1 != null)
            {
                lblCustomerName.Text = billingAddData.fname + " " + billingAddData.lname;
                if (billingAddData.company_name != null)
                {
                    html.Append("<label>" + billingAddData.company_name + "</label>");
                }
                html.Append("<br/>");
                html.Append("<label>" + billingAddData.fname + " " + billingAddData.lname + "</label>");
                html.Append("<br/>");
                html.Append("<label>" + billingAddData.addLine1 + "</label>");
                html.Append("<br/>");
                if (billingAddData.addLine2 != null)
                {
                    html.Append("<label>" + billingAddData.addLine2 + "</label>");
                    html.Append("<br/>");
                }
                html.Append("<label>" + billingAddData.city + " - " + billingAddData.pincode + "</label>");
                html.Append("<br/>");
                html.Append("<label>" + "Mob.: " + billingAddData.mobile + "</label>");
                html.Append("<br/>");
                html.Append("<label>" + billingAddData.state + ", India</label>");

                placeHolderBillingAdd.Controls.Add(new Literal { Text = html.ToString() });

                #endregion

                #region Shipping Address

                if (shippingAddData == null)
                {
                    html = new StringBuilder();
                    if (billingAddData.company_name != null)
                    {
                        html.Append("<label>" + billingAddData.company_name + "</label><br/>");
                    }
                    html.Append("<label>" + billingAddData.fname + " " + billingAddData.lname + "</label><br/>");
                    html.Append("<label>" + billingAddData.addLine1 + "</label><br/>");
                    if (billingAddData.addLine2 != null)
                    {
                        html.Append("<label>" + billingAddData.addLine2 + "</label>");
                        html.Append("<br/>");
                    }
                    html.Append("<label>" + billingAddData.city + " - " + billingAddData.pincode + "</label><br/>");
                    html.Append("<label>" + "Mob.: " + billingAddData.mobile + "</label><br/>");
                    html.Append("<label>" + billingAddData.state + ", India</label>");

                    placeHolderShippingAdd.Controls.Add(new Literal { Text = html.ToString() });


                }
                else
                {
                    html = new StringBuilder();
                    if (shippingAddData.companyName != null)

                    { html.Append("<label>" + shippingAddData.companyName + "</label><br/>"); }

                    html.Append("<label>" + shippingAddData.fname + " " + shippingAddData.lname + "</label><br/>");
                    html.Append("<label>" + shippingAddData.line1 + "</label><br/>");
                    if (shippingAddData.line2 != null)
                    {
                        html.Append("<label>" + shippingAddData.line2 + "</label><br/>");
                    }
                    html.Append("<label>" + shippingAddData.city + " - " + shippingAddData.pincode + "</label><br/>");
                    html.Append("<label>" + "Mob.: " + shippingAddData.mobile + "</label><br/>");
                    html.Append("<label>" + shippingAddData.state + ", India</label>");

                    placeHolderShippingAdd.Controls.Add(new Literal { Text = html.ToString() });

                }
                #endregion

            }
            else
            {
                html = new StringBuilder();
                html.Append("<label>No Address Added.</label>");
                placeHolderBillingAdd.Controls.Add(new Literal { Text = html.ToString() });

                // txtEmailAddress.Text = billingAddData.email.Trim().ToString();


            }
            #endregion
        }

        int totalItemsForMail = 0;
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string recieverMobileNumberForMail;
                long orderId = Convert.ToInt32(hdnLblValue.Value);
                passedUserId = Convert.ToInt32(Session["u_id"]);

                var dataOrderStatus = _iOrderMasterRepository.SelectById(orderId);
                if (dataOrderStatus != null)
                {
                    if (Convert.ToInt32(drp_Status.SelectedValue) != dataOrderStatus.order_status)
                    {
                        dataOrderStatus.order_status = Convert.ToInt32(drp_Status.SelectedValue);
                        _iOrderMasterRepository.Update(dataOrderStatus);

                    }
                    else
                    {
                        errorDiv.Visible = true;
                        lblError.Text = "Cannot select the same order status. Select another status for better indication to customers.";
                        return;
                    }
                }


                var dateofOrder = _iOrderMasterRepository.SelectById(orderId);

                recieverMobileNumberForMail = _iUserMasterRepository.SelectById(dateofOrder.user_id).mobile;


                #region customerName
                var dataOfUser = _iUserMasterRepository.SelectById(dateofOrder.user_id);
                var custName = dataOfUser.fname + " " + dataOfUser.lname;
                var custEmail = dataOfUser.email;
                #endregion

                var orderDetailsData = _iOrderMasterDetailsRepository.SelectAll().Where(x => x.order_id == orderId).ToList();

                foreach (var item in orderDetailsData)
                {
                    totalItemsForMail++;
                }

                if (Convert.ToInt32(drp_Status.SelectedValue) == 2)
                {
                    //Packed And Dispatched Status in msg 
                    #region expectedDateTime
                    DateTime sData = Convert.ToDateTime(dateofOrder.order_datetime).Date;
                    DateTime eData = sData.AddDays(2);
                    #endregion

                    msg = "Hello, " + custName + "! Your order for " + totalItemsForMail + " items(s) (Order No.:" + orderId + ") has been Packed and Dispatched, and ready to delivered. Complete order is expected to be delivered by " + eData.ToString("dd-MMM-yyyy") + ". Track your order at http://www.pateltea.co.in/CS/MyAccount";
                }
                else if (Convert.ToInt32(drp_Status.SelectedValue) == 3)
                {
                    //Out for delivery status in msg

                    #region expectedDateTime
                    DateTime sData = Convert.ToDateTime(dateofOrder.order_datetime).Date;
                    DateTime eData = sData.AddDays(1);
                    #endregion

                    msg = "Hello, " + custName + "! Your order for " + totalItemsForMail + " items(s) (Order No.:" + orderId + ") is out for delievery. Complete order is expected to be delivered by " + eData.ToString("dd-MMM-yyyy") + ". Track your order at http://www.pateltea.co.in/CS/MyAccount";
                }
                else
                {

                    var dataFeed = _iFeedbackRepository.SelectAll().OrderByDescending(x => x.feed_id).FirstOrDefault();
                    if (dataFeed != null)
                    {
                        feedCode = Convert.ToInt32(dataFeed.code + 1);
                    }
                    else
                    {
                        feedCode = 1234;
                    }

                    feedback_master feedMaster = new feedback_master();
                    feedMaster.fname = custName;
                    feedMaster.email = custEmail;
                    feedMaster.code = feedCode;
                    feedMaster.cdate = DateTime.Now;
                    _iFeedbackRepository.Add(feedMaster);

                    msg = "Congratulations, " + custName + "! We have successfully delievered your order for " + totalItemsForMail + " items(s) (Order No.:" + orderId + ").Click http://pateltea.co.in/CS/FeedBack?fcd=" + feedCode + " to give feedback.";


                    //Send mail
                    #region invoiceMail

                    userMail = custEmail;

                    var fEmail = _iGlobalParametersRepository.SelectAll().Where(x => x.globalParamKey == "EmailAddress").FirstOrDefault();

                    if (fEmail != null)
                    {
                        fromEmail = fEmail.globalParamValue;
                    }


                    var fPwd = _iGlobalParametersRepository.SelectAll().Where(x => x.globalParamKey == "EmailPassword").FirstOrDefault();

                    if (fPwd != null)
                    {
                        pwds = fPwd.globalParamValue;
                    }

                    using (MailMessage mm = new MailMessage(fromEmail, userMail))
                    {
                        mm.Subject = "We delivered your Patel Tea Order";
                        mm.Body = bodytoSend();

                        mm.IsBodyHtml = true;

                        //LinkedResource LinkedImage = new LinkedResource(@"D:\Projects\PatelTeaUnja\PatelTeaSource\PatelTeaSource\Template\17.png");
                        //LinkedImage.ContentId = "MyPic";

                        //LinkedResource fbIcon = new LinkedResource(@"D:\Projects\PatelTeaUnja\PatelTeaSource\PatelTeaSource\Template\images\Download\fbIcon.png");
                        //fbIcon.ContentId = "MyFBIcon";

                        //LinkedResource instaIcon = new LinkedResource(@"D:\Projects\PatelTeaUnja\PatelTeaSource\PatelTeaSource\Template\images\Download\instaIcon.png");
                        //instaIcon.ContentId = "MyInstaIcon";

                        //LinkedResource twitterIcon = new LinkedResource(@"D:\Projects\PatelTeaUnja\PatelTeaSource\PatelTeaSource\Template\images\Download\twitterIcon.png");
                        //twitterIcon.ContentId = "MytwitterIcon";


                        LinkedResource LinkedImage = new LinkedResource(@"E:/Inetpub/vhosts/msuaresolutions.com/pateltea.co.in/Template/17.png");
                        LinkedImage.ContentId = "MyPic";

                        LinkedResource fbIcon = new LinkedResource(@"E:/Inetpub/vhosts/msuaresolutions.com/pateltea.co.in/Template/images/Download/fbIcon.png");
                        fbIcon.ContentId = "MyFBIcon";

                        LinkedResource instaIcon = new LinkedResource(@"E:/Inetpub/vhosts/msuaresolutions.com/pateltea.co.in/Template/images/Download/instaIcon.png");
                        instaIcon.ContentId = "MyInstaIcon";

                        LinkedResource twitterIcon = new LinkedResource(@"E:/Inetpub/vhosts/msuaresolutions.com/pateltea.co.in/Template/images/Download/twitterIcon.png");
                        twitterIcon.ContentId = "MytwitterIcon";


                        //Added the patch for Thunderbird as suggested by Jorge
                        LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);
                        fbIcon.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);
                        instaIcon.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);
                        twitterIcon.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);


                        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                            bodytoSend(),
                          null, "text/html");


                        htmlView.LinkedResources.Add(LinkedImage);
                        htmlView.LinkedResources.Add(fbIcon);
                        htmlView.LinkedResources.Add(instaIcon);
                        htmlView.LinkedResources.Add(twitterIcon);

                        mm.AlternateViews.Add(htmlView);

                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential(fromEmail, pwds);
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                        smtp.Send(mm);
                        // ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
                    }

                    //Send mail to owner

                    //using (MailMessage mm = new MailMessage(fromEmail, "pateltea1954@gmail.com"))
                    //{
                    //    mm.Subject = "We delivered your Patel Tea Order";
                    //    mm.Body = bodytoSend();

                    //    mm.IsBodyHtml = true;

                    //    LinkedResource LinkedImage = new LinkedResource(@"D:\Projects\PatelTeaUnja\PatelTeaSource\PatelTeaSource\Template\17.png");
                    //    LinkedImage.ContentId = "MyPic";

                    //    LinkedResource fbIcon = new LinkedResource(@"D:\Projects\PatelTeaUnja\PatelTeaSource\PatelTeaSource\Template\images\Download\fbIcon.png");
                    //    fbIcon.ContentId = "MyFBIcon";

                    //    LinkedResource instaIcon = new LinkedResource(@"D:\Projects\PatelTeaUnja\PatelTeaSource\PatelTeaSource\Template\images\Download\instaIcon.png");
                    //    instaIcon.ContentId = "MyInstaIcon";

                    //    LinkedResource twitterIcon = new LinkedResource(@"D:\Projects\PatelTeaUnja\PatelTeaSource\PatelTeaSource\Template\images\Download\twitterIcon.png");
                    //    twitterIcon.ContentId = "MytwitterIcon";


                    //    //Added the patch for Thunderbird as suggested by Jorge
                    //    LinkedImage.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);
                    //    fbIcon.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);
                    //    instaIcon.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);
                    //    twitterIcon.ContentType = new ContentType(MediaTypeNames.Image.Jpeg);


                    //    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                    //        bodytoSend(),
                    //      null, "text/html");


                    //    htmlView.LinkedResources.Add(LinkedImage);
                    //    htmlView.LinkedResources.Add(fbIcon);
                    //    htmlView.LinkedResources.Add(instaIcon);
                    //    htmlView.LinkedResources.Add(twitterIcon);

                    //    mm.AlternateViews.Add(htmlView);

                    //    SmtpClient smtp = new SmtpClient();
                    //    smtp.Host = "smtp.gmail.com";
                    //    smtp.EnableSsl = true;
                    //    NetworkCredential NetworkCred = new NetworkCredential(fromEmail, pwds);
                    //    smtp.UseDefaultCredentials = true;
                    //    smtp.Credentials = NetworkCred;
                    //    smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                    //    smtp.Send(mm);
                    //    // ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
                    //}

                    #endregion

                }

                sendMes(msg, recieverMobileNumberForMail);

                Response.Redirect("CartOrders.aspx");
            }
            catch (Exception x)
            {

            }
        }

        private void sendMes(string msg, string mob)
        {
            #region sms Send

            //HttpCookie aCookie;
            //string cookieName;
            //int limit = Request.Cookies.Count;
            //for (int i = 0; i < limit; i++)
            //{
            //    cookieName = Request.Cookies[i].Name;
            //    aCookie = new HttpCookie(cookieName);
            //    aCookie.Expires = DateTime.Now.AddDays(-3); // make it expire yesterday
            //    Response.Cookies.Add(aCookie); // overwrite it
            //}

            var apiKeyByID = _iGlobalParametersRepository.SelectAll().Where(x => x.globalParamKey == "APIKey").FirstOrDefault();

            if (apiKeyByID != null)
            {
                apiKey = apiKeyByID.globalParamValue;
            }

            var apiTokenByID = _iGlobalParametersRepository.SelectAll().Where(x => x.globalParamKey == "APIToken").FirstOrDefault();

            if (apiKeyByID != null)
            {
                token = apiTokenByID.globalParamValue;
            }

            var senderByID = _iGlobalParametersRepository.SelectAll().Where(x => x.globalParamKey == "SMSSender").FirstOrDefault();

            if (apiKeyByID != null)
            {
                senderSMS = senderByID.globalParamValue;
            }

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            model_messge post_values = new model_messge
            {

                api_key = apiKey,

                api_token = token,

                sender = senderSMS,

                receiver = mob,

                msgtype = "1",

                sms = msg,

            };

            post_values.sendSmS(post_values);

            #endregion
        }

        //this is the Invoice body to be send as mail after payment done
        private string bodytoSend()
        {
            long orderId = Convert.ToInt32(hdnLblValue.Value);
            tax = 0;
            subtotal = 0;
            string body = string.Empty;

            int rowNo = 1;
            //int oId = Convert.ToInt32(Session["txnId"]);
            var orderMasterData = _iOrderMasterRepository.SelectById(orderId);

            var custData = _iUserMasterRepository.SelectById(orderMasterData.user_id);

            StringBuilder html = new StringBuilder();

            body = "<body>";
            body += "<div>";
            body += "<div style='border:7px solid lightgray;'>";
            body += "<div class='col-md-12'>";
            body += "<div class='row' style='padding: 20px 26px 24px 20px;'>";

            body += "<table style='width:100%'>";
            body += "<tr>";
            body += "<td colspan='3'>";
            body += "<a href='www.pateltea.co.in'><img style='width:100px; margin-bottom:-35px;' alt='Patel Tea Packers' src='cid:MyPic'/></a>";
            body += "<br />";
            body += "<span><b>GSTIN : </b>24AARFP4652Q1ZF</span>";
            body += "</td>";
            body += "<td>";
            body += "<h2 class='name' style='text-align: right;'>Invoice</h2>";
            body += "</td>";
            body += "</tr>";
            body += "</table>";

            body += "<hr />";

            body += "<div style='padding:20px;background-color:green;'>";
            body += "<span style='color: white;font-size: 20px;'> We delivered your Patel Tea Order with ID: #" + orderId + "</span>";
            body += "</div>";
            body += "<div style='padding: 25px;'>";
            body += "Hey " + custData.fname + " " + custData.lname + ",<br />";
            body += "Time to celebrate! <br />";
            body += "You order with ID: #" + orderId + " has been successfully delivered at the given address.<br />";
            body += "</div>";
            body += "<div style='text-align:center'>";
            body += "Contents of the package:";
            body += "</div>";
            body += "<br />";
            body += "<div style=''>";

            body += "<table style='width:100%;border-spacing:0;border-collapse:collapse;'>";

            body += "<thead style='height:40px;background:#f0efef;'>";

            body += "<tr>";
            body += "<td style='width:40px;text-align:center;'>#</td>";

            body += "<td style='width:530px;'>Product Name</td>";
            body += "<td style='width:100px;'>GST %</td>";
            body += "<td style='width:100px;'>Rate</td>";
            body += "<td style='width:70px;'>Qty</td>";
            body += "<td style='width:100px;'>Amount(Incl. Tax)</td>";
            body += "</tr>";
            body += "</thead>";
            body += "<tbody>";

            var orderMasterDetailsData = _iOrderMasterDetailsRepository.SelectAll().Where(x => x.order_id == orderId).ToList();
            shippingRate = 0;
            foreach (var item in orderMasterDetailsData)
            {
                body += "<tr style='border-bottom:1px solid lightgray;'>";
                body += "<td style='font-size:12px;color:gray;text-align:center;padding:10px;'>" + rowNo + "</td>";

                var productMasterData = _iProductMasterRepository.SelectById(item.pid);

                var productData = _iProductMasterRepository.SelectById(item.pid);

                if (productMasterData.shippingCharge > 0)
                {
                    shippingRate += Convert.ToDecimal(productMasterData.shippingCharge);
                }

                body += "<td style='font-size:14px;color:gray;>";

                body += "<span>" + productData.pname + "</span>";
                body += productData.pname;
                body += "<span style='color:orange'>";
                body += productData.pname + " (" + productData.weight + " " + productData.unit + ")";
                body += "</span>";
                body += "</td>";

                body += "<td style='font-size:14px;color:gray;'>" + Convert.ToInt32(productData.taxPer) + "%</td>";

                prate = (Convert.ToDecimal(item.rate) * Convert.ToInt32(productMasterData.taxPer)) / (100 + Convert.ToInt32(productMasterData.taxPer));

                DecimalFormat dcFormat = new DecimalFormat();

                prate = Convert.ToDecimal(item.rate) - prate;

                body += "<td style='font-size:14px;color:gray;text-align:center'>&#8377;" + dcFormat.DoFormat(prate) + "</td>";
                body += "<td style='font-size:14px;color:gray;text-align:center'>";
                body += item.qty;
                body += "</td>";
                body += "<td style='font-size:14px;color:gray;text-align:center'>&#8377;" + dcFormat.DoFormat(item.amount) + ".00</td>";

                subtotal += Convert.ToDecimal(item.amount);
                proTax += Convert.ToInt32(productMasterData.taxPer);

                tax += Convert.ToDecimal(item.amount) - prate;

                body += "</tr>";
                rowNo++;
            }
            totalAmt = subtotal;

            sgst = Convert.ToDecimal(tax / 2);
            cgst = Convert.ToDecimal(tax / 2);

            #region subtotal
            body += "<tr style='border-bottom:1px solid lightgray;'>";
            body += "<td colspan='5' style='text-align:left; font-size:15px;color:gray;padding-top: 40px;'>";
            body += "<span>Sub Total:</span>";
            body += "</td>";
            body += "<td style='text-align:left;font-size:15px;color: gray;vertical-align: bottom;padding-bottom:10px; '>";
            body += "<span>&#8377; " + dcFormat.DoFormat(Convert.ToDecimal(totalAmt)).ToString() + "</span>";
            body += "</td>";
            body += "</tr>";
            #endregion

            #region CGST
            body += "<tr style='border-bottom:1px solid lightgray;'>";
            body += "<td colspan='5' style='text-align:left; font-size:15px;color:gray;padding:10px;'>";
            body += "<span>CGST:</span>";
            body += "</td>";
            body += "<td style='text-align:left;font-size:15px;color: gray;'>";
            body += "<span>" + dcFormat.DoFormat(cgst).ToString() + "</span>";
            body += "</td>";
            body += "</tr>";
            #endregion

            #region SGST
            body += "<tr style='border-bottom:1px solid lightgray;'>";
            body += "<td colspan='5' style='text-align:left; font-size:15px;color:gray;padding:10px;'>";
            body += "<span>SGST:</span>";
            body += "</td>";
            body += "<td style='text-align:left;font-size:15px;color: gray;'>";
            body += "<span>" + dcFormat.DoFormat(sgst).ToString() + "</span>";
            body += "</td>";
            body += "</tr>";
            #endregion

            #region TotalTaxable Amt
            body += "<tr style='border-bottom:1px solid lightgray;'>";
            body += "<td colspan='5' style='text-align:left; font-size:15px;color:gray;padding:10px;'>";
            body += "<span>Total Taxable Amount:</span>";
            body += "</td>";
            body += "<td style='text-align:left;font-size:15px;color: gray;'>";
            body += "<span>&#8377; " + dcFormat.DoFormat(Convert.ToDecimal(tax)).ToString() + "</span>";
            body += "</td>";
            body += "</tr>";
            #endregion

            #region shipping
            body += "<tr style='border-bottom:1px solid lightgray;'>";
            body += "<td colspan='5' style='text-align:left; font-size:15px;color:gray;padding:10px;'>";
            body += "<span>Shipping:</span>";
            body += "</td>";
            body += "<td style='text-align:left;font-size:15px;color: gray;'>";

            //Shipping amount if
            if (shippingRate == 0)
            {
                body += "<span>Free Shipping</span>";
            }
            else
            {
                totalAmt += shippingRate;
                body += "<span>&#8377; " + shippingRate + "</span>";
            }

            body += "</td>";
            body += "</tr>";
            #endregion

            #region totalAmt
            body += "<tr style='border-bottom:1px solid lightgray;'>";
            body += "<td colspan='5' style='text-align:left; font-size:18px;color:gray;padding:10px;'>";
            body += "<span>Order Total :</span>";
            body += "</td>";
            body += "<td style='text-align:left;font-size:18px;color: gray;'>";

            if (shippingRate == 0)
            {
                body += "<span>&#8377; " + totalAmt + ".00 </span>";
            }
            else
            {
                totalAmt += shippingRate;
                body += "<span>&#8377; " + totalAmt + "</span>";
            }

            body += "</td>";
            body += "</tr>";
            #endregion

            body += "<tr style='border-bottom:1px solid lightgray;'>";
            body += "<td colspan='6' style='text-align:center;padding-top:40px;padding-bottom:40px;'>";
            body += "<a href='https://www.pateltea.co.in/CS/MyAccount' style='border:1px solid lightgray;padding:20px;background:orange;text-decoration:none;color:white;font-size:20px;'>View Order</a>";
            body += "</td>";
            body += "</tr>";

            body += "<tr style='border-bottom:1px solid lightgray;'>";
            body += "<td colspan='6' style='text-align:left; font-size:15px;color:gray;padding:13px;'>";
            body += "<span><b> DELIVERY ADDRESS </b> <br /><br />";

            //Address from db
            #region Shipping Address
            var shippingAddressDetails = _iShippingAddressRepository.SelectAll().Where(x => x.user_id == orderMasterData.user_id).FirstOrDefault();

            if (shippingAddressDetails == null)
            {
                body += "<b>" + custData.company_name + "</b><br />";
                body += "<b>" + custData.fname + " " + custData.lname + "</b><br />";
                body += custData.addLine1 + "<br />";
                body += custData.addLine2 + "<br />";
                body += custData.city + " - " + custData.pincode + "<br />";
                body += "Mob.:" + custData.mobile + "<br />";
                body += "Gujarat, India<br />";
            }
            else
            {
                body += "<b>" + shippingAddressDetails.companyName + "</b><br />";
                body += "<b>" + shippingAddressDetails.fname + " " + shippingAddressDetails.lname + "</b><br />";
                body += shippingAddressDetails.line1 + "<br />";
                body += shippingAddressDetails.line2 + "<br />";
                body += shippingAddressDetails.city + " - " + shippingAddressDetails.pincode + "<br />";
                body += "Mob.:" + shippingAddressDetails.mobile + "<br />";
                body += "Gujarat, India<br />";
            }
            body += "</span>";
            body += "</td>";
            body += "</tr>";
            #endregion

            body += "<tr style='border-bottom:1px solid lightgray;'>";
            body += "<td colspan='6' style='text-align:left; font-size:15px;black:gray;padding:13px;'>";
            body += "<p style='text-align:justify'>";
            body += "<b> Just in case you were wondering:</b> <br /><br />If there are multiple shipments, you will be receiving the packages separately.<br /><br />We hope you are happy with your purchase and shop again with Patel Tea Packers.<span style='font-size:25px;margin-left:-6px;'>&#9786;</span><br /><br />Have any feedback on how we can improve your shopping experience or just want to say hi? Give us a feedback by <a href='https://pateltea.co.in/CS/FeedBack'>clicking here</a> or email at pateltea@ymail.com. Our Customer Care Champs would love to help you out. Any time.<br /><br />Thanks for shopping with us!<br /><b> Team, Patel Tea Packers</b>";
            body += "</p>";
            body += "</td>";
            body += "</tr>";

            body += "<tr style='border-bottom:1px solid lightgray;'>";
            body += "<td colspan='6' style='text-align:left; font-size:15px;black:gray;padding:13px;'>";
            body += "<p style='text-align:justify;color:gray;font-size: 13px;'>";
            body += "<b>Note: We do not demand your banking and credit card details verbally or telephonically. Please do not divulge your details to fraudsters and imposters falsely claiming to be calling on Patel Tea Packers's behalf.";
            body += "</p>";
            body += "</td>";
            body += "</tr>";

            body += "<tr style='border-bottom:1px solid lightgray;'>";
            body += "<td colspan='6' style='text-align:center; font-size:15px;black:gray;padding:13px;'>";
            body += "<p style='text-align:center;color:black;font-size:20px;'>FOLLOW US</p>";
            body += "<a href='https://www.facebook.com/patelteapackers/'><img src='cid:MyFBIcon'/></a>  ";
            body += "<a href='https://www.instagram.com/patelteapackers/'><img src='cid:MyInstaIcon'/></a>  ";
            body += "<a href='#'><img src='cid:MytwitterIcon'/></a> ";
            body += "</td>";
            body += "</tr>";

            body += "</tbody>";
            body += "</table>";
            body += "</div>";
            body += "</div>";
            body += "</div>";
            body += "</div>";
            body += "</<body>";
            return body;



        }
    }
}