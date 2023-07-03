using PatelTeaSource.Repository.ProductPriceRepo;
using PatelTeaSource.Repository.ProductMasterRepo; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class DeleteProducts : System.Web.UI.Page
    {
        public DeleteProducts()
          : this(new ProductPriceRepository(), new ProductMasterRepository())
        {
        }

        private IProductPriceRepository _iProductPriceRepository;
        private IProductMasterRepository _iProductMasterRepository;

        public DeleteProducts(ProductPriceRepository productPriceRepository, ProductMasterRepository productMasterRepository)
        {
            _iProductPriceRepository =productPriceRepository; 
            _iProductMasterRepository = productMasterRepository;
        }
        int passedId = 0;
        long passedUserId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    passedUserId = Convert.ToInt32(Session["u_id"]);

                    if (passedUserId != 0)
                    {
                        passedId = Convert.ToInt32(Request.QueryString["id"].ToString());

                        if (passedId >= 0)
                        {
                            var data = _iProductPriceRepository.SelectAll().Where(x => x.pId == passedId);
                            if (data != null)
                            {
                                foreach (var item in data.ToList())
                                {
                                    int idd = Convert.ToInt32(item.priceId);
                                    _iProductPriceRepository.Delete(idd);
                                }
                                 
                            }

                            var databyid = _iProductMasterRepository.SelectById(passedId);
                            if (databyid != null)
                            {
                                _iProductMasterRepository.Delete(passedId);
                               
                            }
                            Response.Redirect("ProductsList.aspx"); 
                        }
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
    }
}