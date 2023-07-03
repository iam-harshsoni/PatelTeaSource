using System;
using System.Collections.Generic;
using PatelTeaSource.Repository.CartDetailsRepo;
using PatelTeaSource.Repository.CartRepo;
using PatelTeaSource.Repository.ProductMasterRepo;
using PatelTeaSource.Repository.ProductPriceRepo;
using PatelTeaSource.Repository.OrderMasterRepo;
using PatelTeaSource.Repository.OrderMasterDetailsRepo;
using PatelTeaSource.Repository.UserMasterRepo;
using PatelTeaSource.Repository.ShippingAddressRepo;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.CS
{
    public partial class PayUMoneyPayment : System.Web.UI.Page
    {
        long passedUserId;
       
        public PayUMoneyPayment()
          : this(new CartRepository(), new CartDetailsRepo(), new ProductMasterRepository(), new ProductPriceRepository(), new OrderMasterRepository(), new OrderMasterDetailsRepository(), new UserMasterRepository(), new ShippingAddressRepository())
        {
        }

        private IProductMasterRepository _iProductMasterRepository;
        private IProductPriceRepository _iProductPriceRepository;
        private ICartRepository _iCartRepository;
        private ICartDetailsRepo _iCartDetailsRepo;
        private IOrderMasterRepository _iOrderMasterRepository;
        private IOrderMasterDetailsRepository _iOrderMasterDetailsRepository;
        private IUserMasterRepository _iUserMasterRepository;
        private IShippingAddressRepository _iShippingAddressRepository;
        public PayUMoneyPayment(CartRepository cartRepository, CartDetailsRepo cartDetailsRepo, ProductMasterRepository productMasterRepository, ProductPriceRepository productPriceRepository, OrderMasterRepository orderMasterRepository, OrderMasterDetailsRepository orderMasterDetailsRepository, UserMasterRepository userMasterRepository, ShippingAddressRepository shippingAddressRepository)
        {
            _iCartRepository = cartRepository;
            _iCartDetailsRepo = cartDetailsRepo;
            _iProductMasterRepository = productMasterRepository;
            _iProductPriceRepository = productPriceRepository;
            _iOrderMasterRepository = orderMasterRepository;
            _iOrderMasterDetailsRepository = orderMasterDetailsRepository;
            _iUserMasterRepository = userMasterRepository;
            _iShippingAddressRepository = shippingAddressRepository;
        }

        decimal? subtotal = 0, shippingRate = 0, totalAmt = 0, tax = 0, sgst = 0, cgst = 0, prate = 0;
        int proTax = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Session["user_id_client"] != null || Session["txnId"] != null)
                    {
                        passedUserId = Convert.ToInt32(Session["user_id_client"]);
                        lblOrderNumber.Text = "Transaction ID :" + Request.Form["txnId"] + " has been successfully Completed";

                        lblOrderNumber.Text = "# " + Session["txnId"].ToString();
                        lblCustomerNumber.Text = Session["fname"].ToString();
                        lblEmail.Text = Session["emailId"].ToString();
                        lblMobile.Text = Session["mobile"].ToString();
                        lblAmt.Text = "&#8377; " + Session["Amount"].ToString();


                    string surl = "https://pateltea.co.in/CS/OrderSuccessful.aspx?Orid=" + Session["txnId"].ToString() + "&UdId=" + passedUserId;
                        //string surl = "http://localhost:63048/CS/OrderSuccessful?Orid="+ Session["txnId"].ToString() + "&UdId="+passedUserId;

                        //  string surl = "http://beta.pateltea.co.in/CS/OrderSuccessful";


                        //string surl = ((HttpContext.Current.Request.ServerVariables["HTTPS"] != "" && HttpContext.Current.Request.ServerVariables["HTTP_HOST"] != "off") || HttpContext.Current.Request.ServerVariables["SERVER_PORT"] == "443") ? "https://" : "http://";
                        //  surl += HttpContext.Current.Request.ServerVariables["HTTP_HOST"] + HttpContext.Current.Request.ServerVariables["REQUEST_URI"] + "/OrderSuccessful.aspx";

                        Session.Add("surl", surl);


                        HttpCookie yourListCookie = new HttpCookie("userIdCookie", Session["user_id_client"].ToString());

                      //  The cookie will exist for 7 days

                       yourListCookie.Expires = DateTime.Now.AddDays(1);

                       // Write the Cookie to your Response

                       Response.Cookies.Add(yourListCookie);


                        //order No

                        yourListCookie = new HttpCookie("orderIdSession", Session["txnId"].ToString());

                        //  The cookie will exist for 7 days

                        yourListCookie.Expires = DateTime.Now.AddDays(1);

                        // Write the Cookie to your Response

                        Response.Cookies.Add(yourListCookie);


                        if (Session["mKey"] != null)
                        {
                            txtKey.Text = Session["mKey"].ToString();

                        }
                        if (Session["saltKey"] != null)
                        {
                            txtSalt.Text = Session["saltKey"].ToString();
                        }
                        if (Session["txnId"] != null)
                        {
                            txtTxnid.Text = Session["txnId"].ToString();
                        }
                        if (Session["amount"] != null)
                        {
                            txtAmount.Text = Session["Amount"].ToString();
                        }
                        if (Session["pInfo"] != null)
                        {
                            txtPinfo.Text = Session["pInfo"].ToString();
                        }
                        if (Session["fName"] != null)
                        {
                            txtfname.Text = Session["fName"].ToString();
                        }
                        if (Session["emailId"] != null)
                        {
                            txtEmail.Text = Session["emailId"].ToString();
                        }
                        if (Session["mobile"] != null)
                        {
                            txtMobile.Text = Session["mobile"].ToString();
                        }
                        if (Session["hash"] != null)
                        {
                            txtHash.Text = Session["hash"].ToString();
                        }
                         
                    }
                    else
                    {
                        Response.Redirect("Checkout.aspx");
                    }
                }

            }
            catch (Exception x)
            {

            }
        }
      

    }
}