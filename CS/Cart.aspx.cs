using PatelTeaSource.Model;
using PatelTeaSource.Repository.CartDetailsRepo;
using PatelTeaSource.Repository.CartRepo;
using PatelTeaSource.Repository.ProductMasterRepo;
using PatelTeaSource.Repository.ProductPriceRepo;
using PatelTeaSource.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.Net.Mime;

namespace PatelTeaSource.CS
{
    public partial class Cart : System.Web.UI.Page
    {

        //string ipAdd;
        int passedUserId = 0;
        StringBuilder html;

        public Cart()
          : this(new CartRepository(), new CartDetailsRepo(), new ProductMasterRepository(), new ProductPriceRepository())
        {
        }

        private IProductMasterRepository _iProductMasterRepository;
        private IProductPriceRepository _iProductPriceRepository;
        private ICartRepository _iCartRepository;
        private ICartDetailsRepo _iCartDetailsRepo;
        public Cart(CartRepository cartRepository, CartDetailsRepo cartDetailsRepo, ProductMasterRepository productMasterRepository, ProductPriceRepository productPriceRepository)
        {
            _iCartRepository = cartRepository;
            _iCartDetailsRepo = cartDetailsRepo;
            _iProductMasterRepository = productMasterRepository;
            _iProductPriceRepository = productPriceRepository;
        }
        int totalRecords = 0,proTax=0;
        decimal? subtotal = 0, shippingRate = 0, totalAmt = 0, tax = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    GetIPAddressClass GetIp = new GetIPAddressClass();

                    passedUserId = Convert.ToInt32(Session["user_id_client"]);

                    //var ipAddress = GetIp.GetIP();

                    if(Request.Cookies["ipAdd"] == null)
                    {
                        Response.Redirect("EmptyCart.aspx");
                        return;
                    }

                    var ipAddress = Request.Cookies["ipAdd"].Value.ToString();
                    List<cart_master> checkData;
 

                    if (passedUserId == 0)
                    {
                        checkData = _iCartRepository.SelectAll().Where(x => x.ipAdd == ipAddress).ToList();

                    }
                    else
                    {
                        checkData = _iCartRepository.SelectAll().Where(x => x.user_id == passedUserId || x.ipAdd==ipAddress).ToList();
                    }

                    if (checkData.Count() == 0)
                    {
                        Response.Redirect("EmptyCart.aspx");
                    }

                    //You Might Be Interested Products
                    InterestedProducts();

                    FirstGridViewRow();
                    passedUserId = Convert.ToInt32(Session["user_id_client"]);
                    if (passedUserId >= 0)
                    {
                       

                        if (ViewState["CurrentTable"] != null)
                        {
                            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                            
                            if (dtCurrentTable.Rows.Count > 0)
                            {
                                 

                                //ipAdd = GetIp.GetIP();

                                long dataCartId;
                                if (passedUserId == 0)
                                {
                                    dataCartId = _iCartRepository.SelectAll().Where(x => x.user_id == passedUserId || x.ipAdd == ipAddress).FirstOrDefault().cart_id;
                                }
                                else
                                {
                                    dataCartId = _iCartRepository.SelectAll().Where(x => x.user_id == passedUserId || x.ipAdd == ipAddress).FirstOrDefault().cart_id;
                                }

                                var data = _iCartDetailsRepo.SelectByCartID(dataCartId);

                                if (data.Count() == 0)
                                {
                                    Response.Redirect("EmptyCart.aspx");
                                }
                                int count = 0;

                                totalRecords = data.Count();

                                foreach (var item in data)
                                {
                                    var rowww = grvTransaction.Rows.Count.ToString();
                                    // var details = _iCartDetailsRepo.SelectByCartID(item.cart_id).FirstOrDefault();
                                    string url = "ProductDetails.aspx?idp=" + item.pid;

                                    var productMasterData = _iProductMasterRepository.SelectById(item.pid);

                                    string imagename = "../AdminSide/AdminSideData/ProductsImages/" + productMasterData.photo.ToString();

                                    string productName = _iProductMasterRepository.SelectById(item.pid).pname;

                                    Label lblId = grvTransaction.Rows[count].Cells[1].FindControl("lblId") as Label;
                                    Image imgProductImg = grvTransaction.Rows[count].Cells[2].FindControl("imgProductImg") as Image;

                                    Label lnlProductName = grvTransaction.Rows[count].Cells[3].FindControl("lnlProductName") as Label;
                                    Label lblRate = grvTransaction.Rows[count].Cells[4].FindControl("lblRate") as Label;
                                    TextBox txtQty = grvTransaction.Rows[count].Cells[5].FindControl("txtQty") as TextBox;
                                    Label lblAmt = grvTransaction.Rows[count].Cells[6].FindControl("lblAmt") as Label;

                                    var itemWeight = _iProductMasterRepository.SelectByProductID(Convert.ToInt32(item.pid)).FirstOrDefault();

                                    lblId.Text = item.cart_detail_id.ToString();
                                    imgProductImg.ImageUrl = imagename;
                                    lnlProductName.Text = productName + " (" + Convert.ToInt32(itemWeight.weight) + " " + itemWeight.unit + ") ";
                                    lblRate.Text = Convert.ToDecimal(item.rate).ToString();
                                    txtQty.Text = item.qty.ToString();
                                    lblAmt.Text = Convert.ToDecimal(item.amount).ToString();

                                    
                                    count++;
                                    AddNewRow();

                                    subtotal += Convert.ToDecimal(item.amount);
                                    proTax += Convert.ToInt32(productMasterData.taxPer);

                                    tax += (Convert.ToDecimal(item.amount) * Convert.ToInt32(productMasterData.taxPer)) / (100 + Convert.ToInt32(productMasterData.taxPer));

                                    var getProductShipping = _iProductMasterRepository.SelectById(item.pid);
                                    if (getProductShipping != null)
                                    {
                                        if (getProductShipping.shippingCharge > 0)
                                        {
                                            shippingRate += Convert.ToDecimal(getProductShipping.shippingCharge);
                                        }
                                    }


                                } 
                               
                                totalAmt = subtotal;
                                //tax = (subtotal* proTax) / (100 + proTax);


                                lblSubTotal.Text = "₹ " + subtotal.ToString() + ".00";

                                DecimalFormat dcFormat = new DecimalFormat();
                                 
                                lblTax.Text = "₹ " + dcFormat.DoFormat(tax);

                                if (shippingRate == 0)
                                {
                                    lblShippingRate.Text = "Free Shipping";
                                    lblTotal.Text = "₹ " + totalAmt + ".00";
                                }
                                else
                                {
                                    lblShippingRate.Text = shippingRate.ToString();
                                    totalAmt += shippingRate;
                                    lblTotal.Text = "₹ " + totalAmt;
                                }  
                            }
                        }
                    }
                }
            }
            catch (Exception x)
            {

            }

            
        }

        private void InterestedProducts()
        {

            int count = 0;
            var data = _iProductMasterRepository.SelectAll();
             
            foreach (var item in data)
            {
                var productInCartDetails = _iCartDetailsRepo.SelectAll();

                foreach (var items in productInCartDetails)
                {
                    if (item.p_id == items.pid)
                    {
                        count = 1;

                    }
                }

                if (count == 0)
                {
                    interestedDiv.Visible = true;
                    html = new StringBuilder();

                    string url = "ProductDetails.aspx?idp=" + item.p_id;

                    html.Append("<div class='col-md-3'>");
                    html.Append("<div class='inner' style='text-align:center;'>");
                    html.Append("<figure>");
                    string imagename = "../AdminSide/AdminSideData/ProductsImages/" + item.photo.ToString();


                    html.Append("<img style='width:100px;height: 135px;' src='" + imagename + "' />");
                    html.Append("</figure>");
                    html.Append("<br />");
                    html.Append("<p style='font-weight: bold;color: black;font-size:17px;'>" + item.pname + " <b style='color: green;'>( " + item.weight + " " + item.unit + " )</b>" + "</p>");
                    //body+=("<br />");

                    html.Append("<a class='hvr-rectangle-out btnCss' style='padding: 5px;' href='" + url + "'>Shop Now</a>");
                    // body+=("<asp:LinkButton ID='LinkButton1' runat='server' class='hvr-rectangle-out btnCss' style='padding: 5px;' OnClick='LinkButton1_Click'>Shop Now</ asp:LinkButton >");
                    html.Append("</div>");
                    html.Append("<hr />");
                    html.Append("</div>");


                    PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });

                }
                else
                {
                    interestedDiv.Visible = false;
                }
                count = 0;
            }
        }
        private void FirstGridViewRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Col1", typeof(string)));
            dt.Columns.Add(new DataColumn("Col2", typeof(string)));
            dt.Columns.Add(new DataColumn("Col3", typeof(string)));
            dt.Columns.Add(new DataColumn("Col4", typeof(string)));
            dt.Columns.Add(new DataColumn("Col5", typeof(string)));
            dt.Columns.Add(new DataColumn("Col6", typeof(string)));

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Col1"] = string.Empty;
            dr["Col2"] = string.Empty;
            dr["Col3"] = string.Empty;
            dr["Col4"] = string.Empty;
            dr["Col5"] = string.Empty;
            dr["Col5"] = string.Empty;
            dr["Col6"] = string.Empty;

            dt.Rows.Add(dr);

            ViewState["CurrentTable"] = dt;
            grvTransaction.DataSource = dt;
            grvTransaction.DataBind();

            //Button btnAdd = (Button)grvTransaction.FooterRow.Cells[6].FindControl("ButtonAdd");

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            decimal? rate, amt;
            int? qty;
            // TextBox txtQty = (TextBox)grvTransaction.Rows[((sender as TextBox).NamingContainer as GridViewRow).RowIndex].Cells[0].FindControl("txtQty");
            //  Label lblId = (Label)grvTransaction.Rows[((sender as TextBox).NamingContainer as GridViewRow).RowIndex].Cells[0].FindControl("lblId");


            foreach (GridViewRow gvRow in grvTransaction.Rows)
            {
                TextBox txtQty = (TextBox)gvRow.FindControl("txtQty") as TextBox;
                Label lblId = (Label)gvRow.FindControl("lblId") as Label;

                var data = _iCartDetailsRepo.SelectByCartDetailsID(Convert.ToInt32(lblId.Text)).FirstOrDefault();

                qty = Convert.ToInt32(txtQty.Text);
                rate = data.rate;
                amt = qty * rate;

                data.qty = Convert.ToInt32(txtQty.Text);
                data.amount = amt;

                _iCartDetailsRepo.Update(data);

            }

            Response.Redirect("Cart.aspx");
        }

        private void AddNewRow()
        {

            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {

                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        Label lblId = (Label)grvTransaction.Rows[rowIndex].Cells[1].FindControl("lblId");
                        Image imgProductImg = ((Image)grvTransaction.Rows[rowIndex].Cells[2].FindControl("imgProductImg"));
                        Label lnlProductName = (Label)grvTransaction.Rows[rowIndex].Cells[3].FindControl("lnlProductName");
                        Label lblRate = (Label)grvTransaction.Rows[rowIndex].Cells[4].FindControl("lblRate");
                        TextBox txtQty = (TextBox)grvTransaction.Rows[rowIndex].Cells[5].FindControl("txtQty");
                        Label lblAmt = (Label)grvTransaction.Rows[rowIndex].Cells[6].FindControl("lblAmt");


                        drCurrentRow = dtCurrentTable.NewRow();
                        drCurrentRow["RowNumber"] = i + 1;

                        dtCurrentTable.Rows[i - 1]["Col1"] = lblId.Text;
                        dtCurrentTable.Rows[i - 1]["Col2"] = imgProductImg.ImageUrl;
                        dtCurrentTable.Rows[i - 1]["Col3"] = lnlProductName.Text;
                        dtCurrentTable.Rows[i - 1]["Col4"] = lblRate.Text;
                        dtCurrentTable.Rows[i - 1]["Col5"] = txtQty.Text;
                        dtCurrentTable.Rows[i - 1]["Col6"] = lblAmt.Text;

                        rowIndex++;

                    }

                    if (rowIndex != totalRecords)
                        dtCurrentTable.Rows.Add(drCurrentRow);

                    ViewState["CurrentTable"] = dtCurrentTable;

                    grvTransaction.DataSource = dtCurrentTable;
                    grvTransaction.DataBind();

                }
            }
            else
            {
                Response.Write("ViewState is null");
            }
            SetPreviousData();
        }

        
      
        protected void btnProceedToCart_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Checkout.aspx");
            }
            catch (Exception x)
            {

            }
        }

        private void SetPreviousData()
        {
            try
            {
                int rowIndex = 0;
                
                if (ViewState["CurrentTable"] != null)
                {
                    DataTable dt = (DataTable)ViewState["CurrentTable"];
                    if (dt.Rows.Count > 0)
                    {
                        int check = dt.Rows.Count - 1;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            Label lblId = (Label)grvTransaction.Rows[rowIndex].Cells[1].FindControl("lblId");
                            Image imgProductImg = ((Image)grvTransaction.Rows[rowIndex].Cells[2].FindControl("imgProductImg"));
                            Label lnlProductName = (Label)grvTransaction.Rows[rowIndex].Cells[3].FindControl("lnlProductName");
                            Label lblRate = (Label)grvTransaction.Rows[rowIndex].Cells[4].FindControl("lblRate");
                            TextBox txtQty = (TextBox)grvTransaction.Rows[rowIndex].Cells[5].FindControl("txtQty");
                            Label lblAmt = (Label)grvTransaction.Rows[rowIndex].Cells[6].FindControl("lblAmt");

                            grvTransaction.Rows[i].Cells[0].Text = Convert.ToString(i + 1);

                            lblId.Text = dt.Rows[i]["Col1"].ToString();
                            imgProductImg.ImageUrl = dt.Rows[i]["Col2"].ToString();
                            lnlProductName.Text = dt.Rows[i]["Col3"].ToString();
                            lblRate.Text = dt.Rows[i]["Col4"].ToString();
                            txtQty.Text = dt.Rows[i]["Col5"].ToString();
                            lblAmt.Text = dt.Rows[i]["Col6"].ToString();

                            rowIndex++;
                        }

                    }
                }

            }
            catch (Exception x)
            {

            }
        }

        protected void txtQty_TextChanged(object sender, EventArgs e)
        {

        }

        protected void grvStudentDetails_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                if (ViewState["CurrentTable"] != null)
                {
                    int a = e.RowIndex;
                    int cartId = 0;
                    Label lblId = (Label)grvTransaction.Rows[e.RowIndex].Cells[1].FindControl("lblId");

                    int cartDetailsId = Convert.ToInt32(lblId.Text);

                    var data = _iCartDetailsRepo.SelectByCartDetailsID(cartDetailsId).FirstOrDefault();

                    if (data != null)
                    {
                        cartId = Convert.ToInt32(data.cart_id);

                        _iCartDetailsRepo.Delete(cartDetailsId);

                        var availCartDetailsData = _iCartDetailsRepo.SelectByCartID(cartId);
                        if (availCartDetailsData.Count() == 0)
                        {
                            _iCartRepository.Delete(cartId);


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
                        }
                        Response.Redirect("Cart.aspx");
                    }
                }
            }
            catch (Exception x)
            {

            }
        }
    }

}
