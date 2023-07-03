using PatelTeaSource.Repository.ProductMasterRepo;
using PatelTeaSource.Repository.ProductPriceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class ProductsList : System.Web.UI.Page
    {

        StringBuilder html;
        long passedUserId = 0;

        public ProductsList()
          : this(new ProductMasterRepository(), new ProductPriceRepository())
        {
        }

        private IProductMasterRepository _iProductMasterRepository;
        private IProductPriceRepository _iProductPriceRepository;
        public ProductsList(ProductMasterRepository productMasterRepository, ProductPriceRepository productPriceRepository)
        {
            _iProductMasterRepository = productMasterRepository;
            _iProductPriceRepository = productPriceRepository;
        }
        int passedId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (!IsPostBack)
                {
                    passedUserId = Convert.ToInt32(Session["u_id"]);

                    if (passedUserId != 0)
                    {
                        int rowNo = 1;
                        var data = _iProductMasterRepository.SelectAll();
                        if (data.Count() > 0)
                        {
                            foreach (var item in data)
                            {
                                html = new StringBuilder();

                                html.Append("<tr>");
                                html.Append("<td>"); html.Append(rowNo); html.Append("</td>");
                                html.Append("<td>"); html.Append(item.pname); html.Append("</td>");

                                string imagename = "../AdminSideData/ProductsImages/" + item.photo.ToString();
                                //Image1.ImageUrl = "~/AdminSide/AdminSideData/BannerImages/" + imagename;

                                html.Append("<td>"); html.Append("<img style='width: 100%;' alt='' src='" + imagename + "'/>"); html.Append("</td>");

                                html.Append("<td>"); html.Append(Convert.ToInt32(item.weight) + " " + item.unit); html.Append("</td>");

                                var price = _iProductPriceRepository.SelectAll().Where(x => x.pId == item.p_id).OrderByDescending(x => x.priceId).FirstOrDefault().price;

                                html.Append("<td>"); html.Append(price); html.Append("</td>");

                                html.Append("<td>"); html.Append(Convert.ToDateTime(item.cDate).ToString("dd-MM-yyyy HH:mm:ss")); html.Append("</td>");
                                if (item.uDate == null)
                                {
                                    html.Append("<td style='text-align:center'>"); html.Append("--"); html.Append("</td>");

                                }
                                else
                                {
                                    html.Append("<td>"); html.Append(Convert.ToDateTime(item.uDate).ToString("dd-MM-yyyy HH:mm:ss")); html.Append("</td>");
                                }
                                html.Append("<td>");

                                string hrfEdit = "AddProducts.aspx?id=" + item.p_id;
                                string hrfDelete = "DeleteProducts.aspx?id=" + item.p_id;


                                html.Append("<a href='" + hrfEdit + "' class='icon-pencil2' style='font-size:large'></a> | ");
                                //html.Append("<a href='" + hrfDelete + "' class='icon-remove' style='font-size:large'></a>  ");
                                html.Append("<a class='icon-close2' style='font-size:large' onclick='deleteThis(" + item.p_id + ")'></a>");

                                html.Append("</tr>");

                                rowNo++;
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
                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
           
        }
    }
}