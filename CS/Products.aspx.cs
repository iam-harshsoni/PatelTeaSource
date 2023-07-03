using PatelTeaSource.Repository.ProductMasterRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace PatelTeaSource.CS
{
    public partial class Products : System.Web.UI.Page
    {
        StringBuilder html;

        public Products()
          : this(new ProductMasterRepository())
        {
        }

        private IProductMasterRepository _iProductMasterRepository;
        public Products(ProductMasterRepository productMasterRepository)
        {
            _iProductMasterRepository = productMasterRepository;
        }
        int passedId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var data = _iProductMasterRepository.SelectAll();

                    foreach (var item in data)
                    {
                        html = new StringBuilder();

                        string url = "ProductDetails.aspx?idp=" + item.p_id;

                        //html.Append("<div class='col-md-4 gallery-item coffee milk tea'>");
                        //html.Append("<div style='text-align:center;'>");
                        //html.Append("<figure>");
                        //string imagename = "../AdminSide/AdminSideData/ProductsImages/" + item.photo.ToString();
                         
                        //html.Append("<img style='width:150px;height:280px' src='" + imagename + "' />");
                        //html.Append("</figure>");
                        //html.Append("<br />");
                        //html.Append("<p style='font-weight: bold;color: black;font-size:17px;'>" + item.pname + " <b style='color: green;'>( " + item.weight + " " + item.unit + " )</b>" + "</p>");
                        ////html.Append("<br />");
                        
                        //html.Append("<a class='hvr-rectangle-out btnCss' style='padding: 5px;' href='"+ url + "'>Shop Now</a>");
                        //// html.Append("<asp:LinkButton ID='LinkButton1' runat='server' class='hvr-rectangle-out btnCss' style='padding: 5px;' OnClick='LinkButton1_Click'>Shop Now</ asp:LinkButton >");
                        //html.Append("<br />");
                        //html.Append("</div>");
                        //html.Append("</div>");



                        html.Append("<div class='col-md-4 gallery-item coffee milk tea'>");
                        html.Append("<div class='inner'>");
                        html.Append("<figure>");

                        string imagename = "../AdminSide/AdminSideData/ProductsImages/" + item.photo.ToString();

                        html.Append("<img style='width:150px;height:230px' src='" + imagename + "' />");
                        html.Append("</figure>");
                        html.Append("<br />");
                        html.Append("<h4 class='title'>" + item.pname + "</h4>");
                        html.Append("<br />");
                        html.Append("<h5 style='color: green;margin-top: -25px;font-size: large;'>( " + Convert.ToInt32(item.weight) + " " + item.unit + " )</h5>");
                        html.Append("<br />");
                        html.Append("<a class='hvr-rectangle-out btnCss' style='padding: 5px;' href='" + url + "'>Shop Now</a>");
                        html.Append("<hr />");
                        html.Append("</div>");
                        html.Append("</div>");

                        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

                        //HtmlAnchor a = new HtmlAnchor();
                        //a.InnerText = "select";
                        //a.ServerClick += LinkButton1_Click;
                        //a.ServerClick += delegate (object sender, EventArgs e) { LinkButton1_Click(sender, e, "This is   From Button1"); };

                        //a.Attributes.Add("class", "hvr-rectangle-out btnCss");
                        //PlaceHolder1.Controls.Add(a);

                        //html = new StringBuilder();
                        //html.Append("</div>");
                        //html.Append("</div>");

                        //PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

                    }
                }
            }
            catch (Exception x)
            {

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e, string m)
        {
            Response.Redirect("ProductDetails.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductDetails.aspx");
        }
    }
}