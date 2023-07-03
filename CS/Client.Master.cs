using PatelTeaSource.Repository.CartRepo;
using PatelTeaSource.Repository.CartDetailsRepo;
using PatelTeaSource.Repository.ProductMasterRepo;
using PatelTeaSource.Repository.ProductPriceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PatelTeaSource.Classes;

namespace PatelTeaSource.CS
{
    public partial class Client : System.Web.UI.MasterPage
    {
        StringBuilder html;

        public Client()
          : this(new CartRepository(), new CartDetailsRepo(), new ProductMasterRepository(), new ProductPriceRepository())
        {
        }

        private ICartRepository _iCartRepository;
        private ICartDetailsRepo _iCartDetailsRepo;
        private IProductMasterRepository _iProductMasterRepository;
        private IProductPriceRepository _iProductPriceRepository;
        public Client(CartRepository cartRepository, CartDetailsRepo cartDetailsRepo, ProductMasterRepository productMasterRepository, ProductPriceRepository productPriceRepository)
        {
            _iCartRepository = cartRepository;
            _iCartDetailsRepo = cartDetailsRepo;
            _iProductMasterRepository = productMasterRepository;
            _iProductPriceRepository = productPriceRepository;
        }

        string ipAdd;
        int passedUserId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            // if (!IsPostBack)
            //  {
            try
            {
                if (!IsPostBack)
                {
                    passedUserId = Convert.ToInt32(Session["user_id_client"]);
                    if (passedUserId >= 0)
                    {
                        int userIdSession = Convert.ToInt32(Session["user_id_client"]);
                        //var data = _iCartRepository.SelectByUserID(userIdSession);


                        //GetIPAddressClass GetIp = new GetIPAddressClass();
                        //ipAdd = GetIp.GetIP();

                        if (Request.Cookies["ipAdd"] != null)
                        {
                            ipAdd = Request.Cookies["ipAdd"].Value.ToString(); 

                            var dataCartId = _iCartRepository.SelectAll().Where(x => x.user_id == passedUserId || x.ipAdd == ipAdd).FirstOrDefault();
                            if (dataCartId != null)
                            {
                                var data = _iCartDetailsRepo.SelectByCartID(dataCartId.cart_id);

                                if (data != null)
                                {
                                    lblProducts.Text = data.Count().ToString();
                                }
                                else
                                {
                                    lblProducts.Text = "0";
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception x)
            {

            }
            //<div class="row checkout">
            //                    <h4>Items : 5</h4>
            //                    <h4>Amount : 2000 Rs</h4>
            //                </div>
            //                <div class="row checkout">
            //                    <span>
            //                        <a class="checkout-button" href="#">View Cart</a>
            //                    </span>
            //                    <span class="checkout-button">Checkout</span>
            //                  </div>
        }
        //}

        private void makeActive()
        {
            Response.Write("<script> alert('Active') </script>");
        }
    }
}