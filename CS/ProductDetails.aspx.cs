using PatelTeaSource.Model;
using PatelTeaSource.Repository.CartDetailsRepo;
using PatelTeaSource.Repository.CartRepo;
using PatelTeaSource.Repository.ProductMasterRepo;
using PatelTeaSource.Repository.ProductPriceRepo;
using PatelTeaSource.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.CS
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        StringBuilder html;

        public ProductDetails()
          : this(new CartRepository(), new CartDetailsRepo(), new ProductMasterRepository(), new ProductPriceRepository())
        {
        }

        private IProductMasterRepository _iProductMasterRepository;
        private IProductPriceRepository _iProductPriceRepository;
        private ICartRepository _iCartRepository;
        private ICartDetailsRepo _iCartDetailsRepo;
        public ProductDetails(CartRepository cartRepository, CartDetailsRepo cartDetailsRepo, ProductMasterRepository productMasterRepository, ProductPriceRepository productPriceRepository)
        {
            _iCartRepository = cartRepository;
            _iCartDetailsRepo = cartDetailsRepo;
            _iProductMasterRepository = productMasterRepository;
            _iProductPriceRepository = productPriceRepository;
        }
        int passedId = 0;
        decimal? discPrice = 0, offerPer = 0, finalAmt = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["idp"] != null)
                {
                    passedId = Convert.ToInt32(Request.QueryString["idp"].ToString());

                    if (passedId >= 0)
                    {
                        var databyid = _iProductMasterRepository.SelectById(passedId);
                        if (databyid != null)
                        {
                            lblProductName.Text = databyid.pname + " (" + Convert.ToInt32(databyid.weight) + " " + databyid.unit.Trim() + ") ";
                           
                            if (databyid.offerDisc != null)
                            { 
                                discPrice= _iProductPriceRepository.SelectAll().Where(x => x.pId == databyid.p_id).OrderByDescending(x => x.priceId).FirstOrDefault().price;
                                offerPer = databyid.offerDisc;

                                if (databyid.offerDisc != 0)
                                {
                                    finalAmt = (discPrice * offerPer) / 100;
                                    finalAmt = discPrice - finalAmt;
                                    lblPrice.Text = finalAmt.ToString();
                                    lblOfferDisc.Text = discPrice.ToString();
                                    offerMRP.Visible = true;
                                }
                                else
                                {

                                    lblPrice.Text = discPrice.ToString();
                                    offerMRP.Visible = false;
                                } 
                            }
                            else
                            {
                                discPrice = _iProductPriceRepository.SelectAll().Where(x => x.pId == databyid.p_id).OrderByDescending(x => x.priceId).FirstOrDefault().price;

                                lblPrice.Text = discPrice.ToString();
                                offerMRP.Visible = false;

                            }
                             

                            if (databyid.offerImg != null)
                            {
                                string Offimagename = "../AdminSide/AdminSideData/ProductsImages/" + databyid.offerImg.ToString();

                                oImg.Src = Offimagename;
                            }
                            else
                            {
                                oImg.Visible = false;
                                offerSaleImg.Visible = false;
                            }
                             
                            string imagename = "../AdminSide/AdminSideData/ProductsImages/" + databyid.photo.ToString();
                              
                            pImg.Src = imagename;

                            if (databyid.nutritionImg == null)
                            {
                                nutDIV.Visible = false;
                            }
                            else
                            {
                                nutDIV.Visible = true;
                                string nutname = "../AdminSide/AdminSideData/ProductsImages/" + databyid.nutritionImg.ToString();
                                nutImgs.Src = nutname;
                            }


                            //Dexcription

                        

                            string s = databyid.description;
                            string[] values = s.Split(',');
                            for (int i = 0; i < values.Length; i++)
                            {
                                html = new StringBuilder();
                                html.Append("<li>");
                                html.Append(values[i].Trim());
                                html.Append("</li>");

                                //values[i] = ; 
                                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
                            }

                        }
                        else
                        {
                            Response.Redirect("Products.aspx");
                        }
                    }
                }

            }
        }

        int count = 0, countCart = 0;
        int passedUserId = 0;
        long cartNo = 0;
        long ipAddress;
        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["idp"] != null)
                {
                    GetIPAddressClass GetIp = new GetIPAddressClass();


                    passedId = Convert.ToInt32(Request.QueryString["idp"].ToString());
                    passedUserId = Convert.ToInt32(Session["uId"]);

                    //var pIdToCheckEntry = _iCartDetailsRepo.SelectAll();

                    //foreach (var item in pIdToCheckEntry)
                    //{
                    //    if (item.pid == passedId)
                    //    {
                    //        countP = 1;
                    //        break;
                    //    }
                    //}


                    if (passedId >= 0 || passedUserId > 0)
                    {
                         
                        //---------------------------------------------------------------
                        #region addCookie
                        //var ipAddress = GetIp.GetIP();

                        if (Request.Cookies["ipAdd"] != null)
                        {
                            ipAddress = checkRandomNumberDB(Request.Cookies["ipAdd"].Value.ToString());
                        }
                        else
                        {
                            ipAddress = checkRandomNumberDB("0");
                        }
                        //if ((Request.Cookies["ipAdd"] != null))
                        //{
                        //    Response.Cookies["ipAdd"].Expires = DateTime.Now.AddDays(-30);
                        //}
                         
                        // Create a cookie
                        HttpCookie yourListCookie = new HttpCookie("ipAdd", ipAddress.ToString());

                        // The cookie will exist for 7 days
                         yourListCookie.Expires = DateTime.Now.AddDays(1);
                            
                        // Write the Cookie to your Response
                        Response.Cookies.Add(yourListCookie);
                        #endregion
                        //---------------------------------------------------------------

                        var dataForIp = _iCartRepository.SelectAll();

                        foreach (var item in dataForIp)
                        {
                            if (item.ipAdd == Request.Cookies["ipAdd"].Value.ToString() || item.user_id == passedUserId)
                            {
                                countCart = 1;
                                cartNo = item.cart_id;
                            }
                        }

                        var dataForProductId = _iCartDetailsRepo.SelectByCartID(cartNo);

                        foreach (var item in dataForProductId)
                        {
                            if (passedId == item.pid)
                            {
                                count = 1;
                            }
                        }

                        if (countCart != 1)
                        {

                            cart_master cartMaster = new cart_master();
                            //cartMaster.user_id = "";
                            cartMaster.cdate = DateTime.Now;
                            cartMaster.ipAdd = Request.Cookies["ipAdd"].Value.ToString();
                            _iCartRepository.Add(cartMaster);

                            countCart = 0;
                        }


                        if (count == 1)
                        {
                            var cId = _iCartRepository.SelectAll().Where(x => x.user_id == passedUserId || x.ipAdd == ipAddress.ToString()).FirstOrDefault().cart_id;

                            var data = _iCartDetailsRepo.SelectAll().Where(x => x.cart_id == cId && x.pid == passedId).FirstOrDefault();

                            int? qty = data.qty;
                            decimal? rate = data.rate;

                            data.qty = qty + 1;
                            data.amount = rate * (data.qty);
                            data.udate = DateTime.Now;

                            _iCartDetailsRepo.Update(data);
                        }
                        else
                        {

                            cart_master_details cartDetails = new cart_master_details();
                            cartDetails.cart_id = _iCartRepository.SelectAll().OrderByDescending(x => x.cart_id).FirstOrDefault().cart_id;
                            cartDetails.pid = passedId;
                            //cartDetails.offerId = "";
                            cartDetails.qty = 1;
                            cartDetails.amount = cartDetails.rate = _iProductPriceRepository.SelectByProductID(passedId).OrderByDescending(x => x.priceId).FirstOrDefault().price;
                            cartDetails.cdate = DateTime.Now;

                            _iCartDetailsRepo.Add(cartDetails);
                            count = 0;
                        }
                        Response.Redirect("Products.aspx");
                    }
                }
            }
            catch (Exception x)
            {

            }
        }

        public long checkRandomNumberDB(string cookieValue)
        {
              
            int newRandomNumber = 0;

            var checkRandomNumber = _iCartRepository.SelectAll().Where(x => x.ipAdd == cookieValue.ToString()).FirstOrDefault();

            if (checkRandomNumber != null)
            {
                if (checkRandomNumber.ipAdd == cookieValue)
                {
                    newRandomNumber = Convert.ToInt32(cookieValue);
                }
            }
            else
            {
                var checkRandomNumbers = _iCartRepository.SelectAll().OrderByDescending(x => x.cart_id).FirstOrDefault();
                if (checkRandomNumber == null)
                {
                    Random rnd = new Random();
                    int card = rnd.Next(0487654745);

                    newRandomNumber = card;
                }
                else
                {
                    newRandomNumber = Convert.ToInt32(checkRandomNumber.ipAdd) + 1;
                }
            }


            return newRandomNumber;
        }
    }
}