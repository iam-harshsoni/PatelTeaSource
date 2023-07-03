using PatelTeaSource.Model;
using PatelTeaSource.Repository.ProductMasterRepo;
using PatelTeaSource.Repository.ProductPriceRepo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class AddProducts : System.Web.UI.Page
    {
        public AddProducts()
          : this(new ProductMasterRepository(), new ProductPriceRepository())
        {
        }

        long passedUserId = 0;

        private IProductMasterRepository _iProductMasterRepository;
        private IProductPriceRepository _iProductPriceRepository;
        public AddProducts(ProductMasterRepository productMasterRepository, ProductPriceRepository productPriceRepository)
        {
            _iProductMasterRepository = productMasterRepository;
            _iProductPriceRepository = productPriceRepository;
        }
        int passedId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            if (!IsPostBack)
            {
                passedUserId = Convert.ToInt32(Session["u_id"]);

                if (passedUserId != 0)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        passedId = Convert.ToInt32(Request.QueryString["id"].ToString());

                        if (passedId >= 0)
                        {
                            var databyid = _iProductMasterRepository.SelectById(passedId);
                            if (databyid != null)
                            {
                                txtProductName.Text = databyid.pname.Trim().ToString();
                                txtDesc.Text = databyid.description.Trim().ToString();
                                txtWeight.Text = databyid.weight.ToString();

                                if (databyid.unit.Trim() == "Gram")

                                    drpUnit.SelectedIndex = 0;
                            }
                            else if (databyid.unit.Trim() == "Kg")
                            {
                                drpUnit.SelectedIndex = 1;
                            }

                            else
                            {
                                drpUnit.SelectedIndex = -1;
                            }
                            txtShippingCharges.Text = databyid.shippingCharge.ToString();
                            txtPrice.Text = _iProductPriceRepository.SelectAll().Where(x => x.pId == databyid.p_id).OrderByDescending(x => x.priceId).FirstOrDefault().price.ToString();
                            txtTax.Text = databyid.taxPer.ToString();
                            txtDisc.Text = databyid.offerDisc.ToString();
                            btnSubmit.Text = "Update";
                        }

                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }

            //}
            //catch (Exception x)
            //{

            //}
        }

        public bool isFileValidProduct()
        {
            Bitmap bitmp = new Bitmap(FileUpload1.PostedFile.InputStream);
            decimal size = Math.Round(((decimal)FileUpload1.PostedFile.ContentLength / (decimal)1024), 2);
            if (size > 150)
            {
                Label1.Text = "Image is not in proper size";
                Label1.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            if (bitmp.Width > 300 || bitmp.Height > 510)
            {
                Label1.Text = "Image is not in proper dimension";
                Label1.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool isFileValidNutrition()
        {
            Bitmap bitmp = new Bitmap(FileUpload2.PostedFile.InputStream);
            decimal size = Math.Round(((decimal)FileUpload2.PostedFile.ContentLength / (decimal)1024), 2);
            if (size > 100)
            {
                Label2.Text = "Image is not in proper size";
                Label2.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            if (bitmp.Width > 1280 || bitmp.Height > 967)
            {
                Label2.Text = "Image is not in proper dimension";
                Label2.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool isFileValidOfferImg()
        {
            Bitmap bitmp = new Bitmap(FileUpload3.PostedFile.InputStream);
            decimal size = Math.Round(((decimal)FileUpload3.PostedFile.ContentLength / (decimal)1024), 2);
            if (size > 100)
            {
                Label3.Text = "Image is not in proper size";
                Label3.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            if (bitmp.Width > 660 || bitmp.Height > 350)
            {
                Label3.Text = "Image is not in proper dimension";
                Label3.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else
            {
                return true;
            }
        }

        string ImageNut, ImageProduct, ImageOffer, strProduct, strNut, strOffer;
         
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (FileUpload1.HasFile)
            {
                strProduct = FileUpload1.FileName;
                ImageProduct = strProduct.ToString();
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/AdminSide/AdminSideData/ProductsImages/" + strProduct));
                FileUpload1.PostedFile.SaveAs("E:/Inetpub/vhosts/msuaresolutions.com/pateltea.co.in/AdminSide/AdminSideData/ProductsImages/" + strProduct);


            }
            if (FileUpload2.HasFile)
            {
                strNut = FileUpload2.FileName;
                ImageNut = strNut.ToString();
                FileUpload2.PostedFile.SaveAs(Server.MapPath("~/AdminSide/AdminSideData/ProductsImages/" + strNut));

                FileUpload2.PostedFile.SaveAs("E:/Inetpub/vhosts/msuaresolutions.com/pateltea.co.in/AdminSide/AdminSideData/ProductsImages/" + strNut);
            }
            if (FileUpload3.HasFile)
            {
                strOffer = FileUpload3.FileName;
                ImageOffer = strOffer.ToString();
                FileUpload3.PostedFile.SaveAs(Server.MapPath("~/AdminSide/AdminSideData/ProductsImages/" + strOffer));
                FileUpload3.PostedFile.SaveAs("E:/Inetpub/vhosts/msuaresolutions.com/pateltea.co.in/AdminSide/AdminSideData/ProductsImages/" + strProduct);
                 
            }


            if (btnSubmit.Text == "Submit")
            {
                if (FileUpload1.HasFile)
                {
                    if (!isFileValidProduct())
                    {
                        return;
                    }
                    else
                    {
                        product_master master = new product_master();

                        master.pname = txtProductName.Text.Trim().ToString();
                        master.weight = Convert.ToDecimal(txtWeight.Text.Trim());
                        master.unit = drpUnit.SelectedItem.Text.ToString();

                        if (FileUpload2.HasFile)
                        {
                            if (!isFileValidNutrition())
                            {
                                return;
                            }
                            else
                            {
                                master.nutritionImg = ImageNut;
                            }
                        }
                        if (FileUpload3.HasFile)
                        {
                            if (!isFileValidOfferImg())
                            {
                                return;
                            }
                            else
                            {
                                master.offerImg = ImageOffer;
                            }
                        }

                        master.photo = ImageProduct;
                        master.description = txtDesc.Text.Trim().ToString();
                        master.shippingCharge = Convert.ToDecimal(txtShippingCharges.Text.Trim().ToString());
                        master.cDate = DateTime.Now;
                        master.taxPer = Convert.ToDecimal(txtTax.Text);
                        master.offerDisc = Convert.ToInt32(txtDisc.Text);
                        _iProductMasterRepository.Add(master);


                        ProductPrice price = new ProductPrice();
                        price.pId = _iProductMasterRepository.SelectAll().OrderByDescending(x => x.p_id).FirstOrDefault().p_id;
                        price.price = Convert.ToDecimal(txtPrice.Text);
                        price.cDate = DateTime.Now;

                        _iProductPriceRepository.Add(price);
                    }
                }

            }
            else
            {
                passedId = Convert.ToInt32(Request.QueryString["id"].ToString());
                var databyid = _iProductMasterRepository.SelectById(passedId);
                if (databyid != null)
                {
                    databyid.pname = txtProductName.Text.Trim().ToString();
                    databyid.weight = Convert.ToDecimal(txtWeight.Text.Trim());
                    databyid.unit = drpUnit.SelectedItem.Text.ToString();

                    if (databyid.photo != ImageProduct && ImageProduct != null)
                    {
                        if (!isFileValidProduct())
                        {
                            return;
                        }
                        else
                        {
                            databyid.photo = ImageProduct;
                        }
                    }

                    if (databyid.nutritionImg != ImageNut && ImageNut != null)
                    {
                        if (!isFileValidNutrition())
                        {
                            return;
                        }
                        else
                        {
                            databyid.nutritionImg = ImageNut;
                        }
                    }

                    if (databyid.offerImg != ImageOffer && ImageOffer!= null)
                    {
                        if (!isFileValidOfferImg())
                        {
                            return;
                        }
                        else
                        {
                            databyid.offerImg = ImageOffer;
                        }
                    }


                    databyid.description = txtDesc.Text.Trim().ToString();
                    databyid.shippingCharge = Convert.ToDecimal(txtShippingCharges.Text.Trim().ToString());
                    databyid.uDate = DateTime.Now;
                    databyid.taxPer = Convert.ToDecimal(txtTax.Text);
                    databyid.offerDisc = Convert.ToInt32(txtDisc.Text);

                    _iProductMasterRepository.Update(databyid);

                    ProductPrice price = new ProductPrice();
                    price.pId = passedId;
                    price.price = Convert.ToDecimal(txtPrice.Text);
                    price.cDate = DateTime.Now;

                    _iProductPriceRepository.Add(price);


                }
            }
            Response.Redirect("ProductsList.aspx");

            //}
            //catch (Exception x)
            //{
            //    Response.Write("<script> alert('" + x.ToString() + "')</script>");
            //}
        }
    }
}