using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PatelTeaSource.Repository.CartDetailsRepo;
using PatelTeaSource.Repository.CartRepo;
using PatelTeaSource.Repository.ProductMasterRepo;
using PatelTeaSource.Repository.ProductPriceRepo;
using PatelTeaSource.Repository.OrderMasterRepo;
using PatelTeaSource.Repository.OrderMasterDetailsRepo;
using PatelTeaSource.Repository.OrderMasterPaymentRepo;
using PatelTeaSource.Repository.OrderHistoryRepo;
using PatelTeaSource.Repository.OrderHistoryDetailsRepo;
using PatelTeaSource.Repository.ShippingAddressRepo;
using PatelTeaSource.Repository.UserMasterRepo;
using PatelTeaSource.Repository.GlobalParameterRepo;

using PatelTeaSource.Classes;
using PatelTeaSource.Model;
using PatelTeaSource.Repository.UserLoginRepo;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Configuration;
using System.Text;

namespace PatelTeaSource.CS
{
    public partial class OrderSuccessful : System.Web.UI.Page
    {
        decimal? subtotal = 0, shippingRate = 0, totalAmt = 0, tax = 0, sgst = 0, cgst = 0, prate = 0;
        int proTax = 0;

        public OrderSuccessful()
          : this(new CartRepository(), new CartDetailsRepo(), new ProductMasterRepository(), new ProductPriceRepository(), new OrderMasterRepository(), new OrderMasterDetailsRepository(), new OrderMasterPaymentRepository(), new OrderHistoryRepository(), new OrderHistoryDetailsRepository(), new UserMasterRepository(), new UserLoginRepository(), new ShippingAddressRepository(), new GlobalParametersRepository())
        {
        }

        private IProductMasterRepository _iProductMasterRepository;
        private IProductPriceRepository _iProductPriceRepository;
        private ICartRepository _iCartRepository;
        private ICartDetailsRepo _iCartDetailsRepo;
        private IOrderMasterRepository _iOrderMasterRepository;
        private IOrderMasterDetailsRepository _iOrderMasterDetailsRepository;
        private IOrderMasterPaymentRepository _iOrderMasterPaymentRepository;
        private IOrderHistoryRepository _iOrderHistoryRepository;
        private IOrderHistoryDetailsRepository _iOrderHistoryDetailsRepository;
        private IUserMasterRepository _iUserMasterRepository;
        private IUserLoginRepository _iUserLoginRepository;
        private IShippingAddressRepository _iShippingAddressRepository;
        private IGlobalParametersRepository _iGlobalParametersRepository;
        public OrderSuccessful(CartRepository cartRepository, CartDetailsRepo cartDetailsRepo, ProductMasterRepository productMasterRepository, ProductPriceRepository productPriceRepository, OrderMasterRepository orderMasterRepository, OrderMasterDetailsRepository orderMasterDetailsRepository, OrderMasterPaymentRepository orderMasterPaymentRepository, OrderHistoryRepository orderHistoryRepository, OrderHistoryDetailsRepository orderHistoryDetailsRepository, UserMasterRepository userMasterRepository, UserLoginRepository userLoginRepository, ShippingAddressRepository shippingAddressRepository, GlobalParametersRepository globalParametersRepository)
        {
            _iCartRepository = cartRepository;
            _iCartDetailsRepo = cartDetailsRepo;
            _iProductMasterRepository = productMasterRepository;
            _iProductPriceRepository = productPriceRepository;
            _iOrderMasterRepository = orderMasterRepository;
            _iOrderHistoryRepository = orderHistoryRepository;
            _iOrderMasterDetailsRepository = orderMasterDetailsRepository;
            _iOrderHistoryDetailsRepository = orderHistoryDetailsRepository;
            _iOrderMasterPaymentRepository = orderMasterPaymentRepository;
            _iUserLoginRepository = userLoginRepository;
            _iUserMasterRepository = userMasterRepository;
            _iShippingAddressRepository = shippingAddressRepository;
            _iGlobalParametersRepository = globalParametersRepository;
        }

        private long passedUserId, orderNumberForMail = 0, totalItemsForMail = 0;
        private string recieverMobileNumberForMail = "", apiKey = "", token = "", senderSMS = "";
        string fromEmail = "", pwds = "", userMail = "";
        protected void btnClickHere_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("MyAccount.aspx");
            }
            catch (Exception x)
            {

            }

        }

        string cck, orderidSess;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                //  if (Request.Cookies["userIdCookie"] != null || Request.Cookies["surlCookie"] != null)
                {
                    orderidSess = Request.QueryString["Orid"].ToString();

                    passedUserId = Convert.ToInt32(Request.QueryString["UdId"]);

                    //if (Request.Cookies["userIdCookie"] != null)
                    //{
                    //    cck = Request.Cookies["userIdCookie"].Value;
                    //}
                    //passedUserId = Convert.ToInt32(cck);


                    //if(Request.Cookies["orderIdSession"]!=null)
                    //{
                    //    orderidSess = Request.Cookies["orderIdSession"].Value;
                    //}

                    //lblOrderNumber.Text = "Transaction ID :" + Request.Form["txnid"] + " has been successfully Completed";
                    //Response.Write("First Name: " + Request.Form["firstname"] + "<br />");
                    //lblOrderNumber.Text = Request.Form["txnid"]+ "  -- This is id";
                    //lblCustomerNumber.Text = Request.Form["firstname"].ToString();
                    //lblEmail.Text = Request.Form["email"].ToString();
                    //lblMobile.Text = Session["mobile"].ToString();

                    #region Remove From Cart


                    var cartIdFromOrderId = _iOrderMasterRepository.SelectById(Convert.ToInt32(orderidSess));

                    if (cartIdFromOrderId != null)
                    {
                        var cartDetailData = _iCartDetailsRepo.SelectByCartID(Convert.ToInt32(cartIdFromOrderId.cartIdTemp)).ToList();

                        foreach (var item in cartDetailData)
                        {
                            _iCartDetailsRepo.Delete(Convert.ToInt32(item.cart_detail_id));
                        }

                        _iCartRepository.Delete(Convert.ToInt32(cartIdFromOrderId.cartIdTemp));
                    }

                    #endregion

                    #region Update Payment in Order

                    long orId = Convert.ToInt32(orderidSess.ToString());
                    var dataOrderMaster = _iOrderMasterRepository.SelectById(orId);
                    if (dataOrderMaster != null)
                    {
                        dataOrderMaster.order_status = 1;
                        _iOrderMasterRepository.Update(dataOrderMaster);

                    }

                    #endregion

                    #region sms Send
                    orderNumberForMail = _iOrderMasterRepository.SelectAll().OrderByDescending(x => x.order_id).FirstOrDefault().order_id;

                    recieverMobileNumberForMail = _iUserMasterRepository.SelectById(passedUserId).mobile;

                    var dateofOrder = _iOrderMasterRepository.SelectById(Convert.ToInt32(orderidSess)).order_datetime;

                    DateTime sData = Convert.ToDateTime(dateofOrder).Date;
                    DateTime eData = sData.AddDays(3);

                    int orderIdd = Convert.ToInt32(orderidSess);

                    var orderDetailsData = _iOrderMasterDetailsRepository.SelectAll().Where(x => x.order_id == orderIdd).ToList();

                    foreach (var item in orderDetailsData)
                    {
                        totalItemsForMail++;
                    }

                    HttpCookie aCookie;
                    string cookieName;
                    int limit = Request.Cookies.Count;
                    for (int i = 0; i < limit; i++)
                    {
                        cookieName = Request.Cookies[i].Name;
                        aCookie = new HttpCookie(cookieName);
                        aCookie.Expires = DateTime.Now.AddDays(-3); // make it expire yesterday
                        Response.Cookies.Add(aCookie); // overwrite it
                    }

                    if ((Request.Cookies["ipAdd"] != null))
                    {
                        Response.Cookies["ipAdd"].Expires = DateTime.Now.AddDays(-30);
                    }


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

                        receiver = recieverMobileNumberForMail,

                        msgtype = "1",

                        sms = "Order Confirmend: Your order for " + totalItemsForMail + " item(s) (Order No.:" + orderNumberForMail + ") has been successfully placed. Complete order is expected to be delivered by " + eData.ToString("dd-MMM-yyyy") + ". Track your order at http://pateltea.co.in/CS/MyAccount",

                    };

                     post_values.sendSmS(post_values);

                    #endregion

                    #region send sms to kishan for acknoledment of new order received
                    post_values.sendSmS(post_values);

                    post_values = new model_messge
                    {

                        api_key = apiKey,

                        api_token = token,

                        sender = senderSMS,

                        receiver = "9426875331",

                        msgtype = "1",

                        sms = "New Order received from website (PATEL TEA PACKERS) visit admin panel for more information."

                    };

                   post_values.sendSmS(post_values);

                    //---------------------------------------------------------------



                    post_values = new model_messge
                    {

                        api_key = apiKey,

                        api_token = token,

                        sender = senderSMS,

                        receiver = "9429012623",

                        msgtype = "1",

                        sms = "New Order received from website (PATEL TEA PACKERS) visit admin panel for more information."

                    };

                    post_values.sendSmS(post_values);

                    #endregion

                    #region invoiceMail

                    userMail = _iUserMasterRepository.SelectById(passedUserId).email;

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
                        mm.Subject = "Success! Your Patel Tea Order is confirmed";
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

                    //    LinkedResource LinkedImage = new LinkedResource(@"E:\Projects\PatelTeaUnja\PatelTeaSource\PatelTeaSource\Template\17.png");
                    //    LinkedImage.ContentId = "MyPic";

                    //    LinkedResource fbIcon = new LinkedResource(@"E:\Projects\PatelTeaUnja\PatelTeaSource\PatelTeaSource\Template\images\Download\fbIcon.png");
                    //    fbIcon.ContentId = "MyFBIcon";

                    //    LinkedResource instaIcon = new LinkedResource(@"E:\Projects\PatelTeaUnja\PatelTeaSource\PatelTeaSource\Template\images\Download\instaIcon.png");
                    //    instaIcon.ContentId = "MyInstaIcon";

                    //    LinkedResource twitterIcon = new LinkedResource(@"E:\Projects\PatelTeaUnja\PatelTeaSource\PatelTeaSource\Template\images\Download\twitterIcon.png");
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
                //else
                //{
                //    Response.Redirect("Checkout.aspx");
                //}
            }

        }


        //this is the Invoice body to be send as mail after payment done
        DecimalFormat dcFormat = new DecimalFormat();
        private string bodytoSend()
        {
            tax = 0;
            subtotal = 0;
            totalAmt = 0;
            string body = string.Empty;

            int rowNo = 1;
            orderidSess = Request.QueryString["Orid"].ToString();
            int oId = Convert.ToInt32(orderidSess);
            var orderMasterData = _iOrderMasterRepository.SelectById(oId);

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
            body += "<h2 class='name' style='text-align: right;'>Order Confirmed</h2>";
            body += "</td>";
            body += "</tr>";
            body += "</table>";

            body += "<hr />";

            body += "<div style='padding:20px;background-color:green;'>";
            body += "<span style='color: white;font-size: 20px;'> Success! Your Patel Tea Order with ID:#" + oId + " is confirmed </span>";
            body += "</div>";
            body += "<div style='padding: 25px;'>";
            body += "Hey <b>" + custData.fname + " " + custData.lname + "</b>,<br />";
            body += "Thank you for shopping with Patel Tea Packers! <br />";
            body += "We are doing our best to get you your purchase as soon as possible.";


            DateTime dt = Convert.ToDateTime(orderMasterData.order_datetime).AddDays(3);

            body += "You order with <b> ID: #" + oId + "</b> has been placed successfully We hope to deliver it to you on or before <b>" + dt.ToString("dd-MMM-yyyy") + "</b>.<br />";
            body += "We promise to keep you updated on the delivery date via SMS and e-mail.";

            body += "</div>";
            body += "<div style='text-align:center'>";
            body += "The details of your order are given below: ";
            body += "</div>";
            body += "<br />";
            body += "<div style=''>";

            body += "<table style='width:100%;border-spacing:0;border-collapse:collapse;'>";

            body += "<thead style='height:40px;background:#f0efef;'>";

            body += "<tr>";
            body += "<td style='width:40px;text-align:center;'>#</td>";

            body += "<td style='width:530px;'>Product Name</td>";
            body += "<td style='width:100px;'>GST %</td>";
            body += "<td style='width:100px;text-align:center'>Rate</td>";
            body += "<td style='width:100px;text-align:center'>Qty</td>";
            body += "<td style='width:100px;'>Amount(Incl. Tax)</td>";
            body += "</tr>";
            body += "</thead>";
            body += "<tbody>";

            var orderMasterDetailsData = _iOrderMasterDetailsRepository.SelectAll().Where(x => x.order_id == oId).ToList();
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


                prate = (Convert.ToDecimal(item.amount) * Convert.ToInt32(productMasterData.taxPer)) / (100 + Convert.ToInt32(productMasterData.taxPer));

//                prate = Convert.ToDecimal(item.rate) - prate;

                body += "<td style='font-size:14px;color:gray;text-align:center'>&#8377;" + dcFormat.DoFormat(Convert.ToDecimal(item.rate)) + "</td>";
                body += "<td style='font-size:14px;color:gray;text-align:center'>";
                body += item.qty;
                body += "</td>";
                body += "<td style='font-size:14px;color:gray;text-align:center'>&#8377;" + dcFormat.DoFormat(item.amount) + ".00</td>";

                subtotal += Convert.ToDecimal(item.amount) - prate;
                proTax += Convert.ToInt32(productMasterData.taxPer);

                tax += prate;

                totalAmt += Convert.ToDecimal(item.amount);

                body += "</tr>";
                rowNo++;
            }
          //  totalAmt = subtotal;

            sgst = Convert.ToDecimal(tax / 2);
            cgst = Convert.ToDecimal(tax / 2);

            #region subtotal
            body += "<tr style='border-bottom:1px solid lightgray;'>";
            body += "<td colspan='5' style='text-align:left; font-size:15px;color:gray;padding-top: 40px;'>";
            body += "<span>Sub Total:</span>";
            body += "</td>";
            body += "<td style='text-align:left;font-size:15px;color: gray;vertical-align: bottom;padding-bottom:10px; '>";
            body += "<span>&#8377; " + dcFormat.DoFormat(Convert.ToDecimal(subtotal)).ToString() + "</span>";
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
            body += "<span>&#8377; " + dcFormat.DoFormat( Convert.ToDecimal(tax)).ToString() + "</span>";
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
                body += "<span>&#8377; " + dcFormat.DoFormat(Convert.ToDecimal(totalAmt)).ToString() + ".00 </span>";
            }
            else
            {
                totalAmt += shippingRate;
                body += "<span>&#8377; " + dcFormat.DoFormat(Convert.ToDecimal(totalAmt)).ToString() + "</span>";
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
            body += "Have any feedback on how we can improve your shopping experience or just want to say hi? Give us a buzz on (+91)-2767-247936 or email at pateltea@ymail.com. Our Team Champs would love to help you out. Any time.";

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