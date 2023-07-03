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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Data;
using PatelTeaSource.ViewModel;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class PrintMainReceipt : System.Web.UI.Page
    {
        StringBuilder html;
        long PassedOrderMasterID = 0, PassedUserId = 0, feedCode = 0;

        decimal? subtotal = 0, shippingRate = 0, totalAmt = 0, tax = 0, sgst = 0, cgst = 0, prate = 0;
        int totalRecords = 0, proTax = 0;
        public PrintMainReceipt()
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

        DecimalFormat dcFormat = new DecimalFormat();

        string fromEmail = "", pwds = "", userMail = "";
        public PrintMainReceipt(ProductMasterRepository productMasterRepository, ProductPriceRepository productPriceRepository, OrderMasterRepository orderMasterRepository, OrderMasterDetailsRepository orderMasterDetailsRepository, OrderMasterPaymentRepository orderMasterPaymentRepository, UserMasterRepository userMasterRepository, UserLoginRepository userLoginRepository, ShippingAddressRepository shippingAddressRepository, FeedbackRepository feedbackRepository, GlobalParametersRepository globalParametersRepository)
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

            PassedOrderMasterID = Convert.ToInt32(Request.QueryString["oId"]);
            if (PassedOrderMasterID > 0)
            {

                //FirstGridViewRow();

                long orderId = Convert.ToInt32(Request.QueryString["oId"]);
                tax = 0;
                subtotal = 0;
                string body = string.Empty;

                int rowNo = 1;
                int oId = Convert.ToInt32(Session["txnId"]);
                var orderMasterData = _iOrderMasterRepository.SelectById(orderId);

                var custData = _iUserMasterRepository.SelectById(orderMasterData.user_id);

                lblInvoiceNo.Text = ((orderMasterData.order_id) + 18).ToString();
                lblInvoiceDate.Text = DateTime.Now.Date.ToString("dd-MMM-yyyy");
                lblOrderNo.Text = (orderMasterData.order_id).ToString();
                lblOrderDate.Text = Convert.ToDateTime(orderMasterData.order_datetime).ToString("dd-MMM-yyyy");

                #region billing Address Details
                lblCustName.Text = custData.fname + " " + custData.lname;
                lblCompanyName.Text = custData.company_name;
                lblLine1.Text = custData.addLine1;
                lblLine2.Text = custData.addLine2;
                lblCity.Text = custData.city;
                lblPincode.Text = custData.pincode;
                lblContact.Text = custData.mobile;
                #endregion


                #region shippinG Address details
                var shippingData = _iShippingAddressRepository.SelectAll().Where(x => x.user_id == orderMasterData.user_id).FirstOrDefault();

                if (shippingData == null)
                {
                    lblCustNameshipping.Text = custData.fname + " " + custData.lname;
                    lblCompanyNameShipping.Text = custData.company_name;
                    lblLine1Shipping.Text = custData.addLine1;
                    lblLine2Shipping.Text = custData.addLine2;
                    lblCityShipping.Text = custData.city;
                    lblPincodeSHipping.Text = custData.pincode;
                    lblContactShipping.Text = custData.mobile;
                }
                else
                {
                    lblCustNameshipping.Text = shippingData.fname + " " + shippingData.lname;
                    lblCompanyNameShipping.Text = shippingData.companyName;
                    lblLine1Shipping.Text = shippingData.line1;
                    lblLine2Shipping.Text = shippingData.line2;
                    lblCityShipping.Text = shippingData.city;
                    lblPincodeSHipping.Text = shippingData.pincode;
                    lblContactShipping.Text = shippingData.mobile.ToString();
                }
                #endregion


                //#region GridData  
                //var orderMasterDetailsData = _iOrderMasterDetailsRepository.SelectAll().Where(x => x.order_id == orderId).ToList();
                //int count = 0;
                //totalRecords = orderMasterDetailsData.Count();
                //foreach (var item in orderMasterDetailsData)
                //{
                //    var rowww = grvTransaction.Rows.Count.ToString();
                //    // var details = _iCartDetailsRepo.SelectByCartID(item.cart_id).FirstOrDefault();
                //    string url = "ProductDetails.aspx?idp=" + item.pid;

                //    var productMasterData = _iProductMasterRepository.SelectById(item.pid);

                //    string imagename = "../AdminSide/AdminSideData/ProductsImages/" + productMasterData.photo.ToString();

                //    string productName = _iProductMasterRepository.SelectById(item.pid).pname;


                //    Label lnlProductName = grvTransaction.Rows[count].Cells[1].FindControl("lnlProductName") as Label;
                //    Label lblRate = grvTransaction.Rows[count].Cells[2].FindControl("lblRate") as Label;

                //    Label lblGst = grvTransaction.Rows[count].Cells[3].FindControl("lblGst") as Label;
                //    Label txtQty = grvTransaction.Rows[count].Cells[4].FindControl("lblQty") as Label;
                //    Label lblAmt = grvTransaction.Rows[count].Cells[5].FindControl("lblAmt") as Label;

                //    var itemWeight = _iProductMasterRepository.SelectByProductID(Convert.ToInt32(item.pid)).FirstOrDefault();

                //    lnlProductName.Text = productName + " (" + Convert.ToInt32(itemWeight.weight) + " " + itemWeight.unit + ") ";

                //    lblGst.Text = Convert.ToInt32(productMasterData.taxPer).ToString() + "%";

                //    prate = (Convert.ToDecimal(item.rate) * Convert.ToInt32(productMasterData.taxPer)) / 100;

                //    prate = Convert.ToDecimal(item.rate) - prate;

                //    lblRate.Text = "₹" + Convert.ToDecimal(prate).ToString() + " /-";
                //    tax += Convert.ToDecimal(item.amount) - prate;

                //    txtQty.Text = item.qty.ToString();
                //    lblAmt.Text = "₹" + Convert.ToDecimal(item.amount).ToString() + " /-";


                //    count++;
                //    AddNewRow();

                //    subtotal += Convert.ToDecimal(item.amount);
                //    proTax += Convert.ToInt32(productMasterData.taxPer);

                //    var getProductShipping = _iProductMasterRepository.SelectById(item.pid);
                //    if (getProductShipping != null)
                //    {
                //        if (getProductShipping.shippingCharge > 0)
                //        {
                //            shippingRate += Convert.ToDecimal(getProductShipping.shippingCharge);
                //        }
                //    }


                //}

                //#endregion

                //-----------------------------------------------------------------------------------

                List<OrderMasterDetailsVm> modelList = new List<OrderMasterDetailsVm>();

                #region GridData  
                var orderMasterDetailsData = _iOrderMasterDetailsRepository.SelectAll().Where(x => x.order_id == orderId).ToList();
                int count = 0;
                totalRecords = orderMasterDetailsData.Count();


                int row = 1;
                foreach (var item in orderMasterDetailsData)
                {
                    OrderMasterDetailsVm model = new OrderMasterDetailsVm();

                    // var rowww = grvTransaction.Rows.Count.ToString();
                    // var details = _iCartDetailsRepo.SelectByCartID(item.cart_id).FirstOrDefault();
                    //string url = "ProductDetails.aspx?idp=" + item.pid;

                    var productMasterData = _iProductMasterRepository.SelectById(item.pid);
                    string productName = _iProductMasterRepository.SelectById(item.pid).pname;
                    var itemWeight = _iProductMasterRepository.SelectByProductID(Convert.ToInt32(item.pid)).FirstOrDefault();

                    model.rowNo = row;
                    model.productName = productName + " (" + Convert.ToInt32(itemWeight.weight) + " " + itemWeight.unit + ") ";
                    model.taxRate = Convert.ToInt32(productMasterData.taxPer).ToString() + "%";



                    prate = (Convert.ToDecimal(item.amount) * Convert.ToInt32(productMasterData.taxPer)) / (100 + Convert.ToInt32(productMasterData.taxPer));

                    // //tax += prate;
                     // prate = Convert.ToDecimal(item.rate) - prate;

                   // prate = Convert.ToDecimal(item.rate);

                    model.rate = "₹" + dcFormat.DoFormat(Convert.ToDecimal(item.rate)).ToString() + " /-";

                    //tax = Convert.ToDecimal(item.amount) - prate;

                    model.qty = item.qty;
                    model.amount = "₹" + dcFormat.DoFormat(item.amount).ToString() + " /-";


                    count++;
               
                    subtotal += Convert.ToDecimal(item.amount)-prate;
                    proTax += Convert.ToInt32(productMasterData.taxPer);

                    var getProductShipping = _iProductMasterRepository.SelectById(item.pid);
                    if (getProductShipping != null)
                    {
                        if (getProductShipping.shippingCharge > 0)
                        {
                            shippingRate += Convert.ToDecimal(getProductShipping.shippingCharge);
                        }
                    }

                    row++;
                    modelList.Add(model);
                    tax += prate;

                    totalAmt += Convert.ToDecimal(item.amount);
                }
                GridView1.DataSource = modelList;
                GridView1.DataBind();
                #endregion


                

                sgst = Convert.ToDecimal(tax /2);
                cgst = Convert.ToDecimal(tax/2);

                lblSubTotal.Text = dcFormat.DoFormat(subtotal).ToString() + "/-";
                lblCGST.Text = dcFormat.DoFormat(cgst).ToString() + "/-";
                lblSGST.Text = dcFormat.DoFormat(sgst).ToString() + "/-";
                lblTotalTaxable.Text = dcFormat.DoFormat(tax).ToString() + "/-";

                if (shippingRate == 0)
                {
                    lblShipping.Text = "Free Shipping";
                    lblAmount.Text = "&#8377; " + dcFormat.DoFormat(totalAmt) + "/-";
                }
                else
                {
                    totalAmt += shippingRate;
                    lblShipping.Text = "&#8377; " + dcFormat.DoFormat(shippingRate) + "/-";
                    lblAmount.Text = "&#8377; " + dcFormat.DoFormat(totalAmt) + "/-";
                }


                //if (shippingRate == 0)
                //{
                   

                //}
                //else
                //{
                //  //  totalAmt = shippingRate;
                  
                     
                //}

                string fileName = "Invoice_" + lblInvoiceNo.Text + ".pdf";

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                form1.RenderControl(hw);
                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A4, 80f, 80f, -2f, 35f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();

                var styles = new StyleSheet();
                styles.LoadTagStyle("GridView1", "border", "1");
                htmlparser.SetStyleSheet(styles);



                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.Write(pdfDoc);
                Response.End();


            }
        }

        //private void FirstGridViewRow()
        //{
        //    DataTable dt = new DataTable();
        //    DataRow dr = null;
        //    dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
        //    dt.Columns.Add(new DataColumn("Col1", typeof(string)));
        //    dt.Columns.Add(new DataColumn("Col2", typeof(string)));
        //    dt.Columns.Add(new DataColumn("Col3", typeof(string)));
        //    dt.Columns.Add(new DataColumn("Col4", typeof(string)));
        //    dt.Columns.Add(new DataColumn("Col5", typeof(string)));

        //    dr = dt.NewRow();
        //    dr["RowNumber"] = 1;
        //    dr["Col1"] = string.Empty;
        //    dr["Col2"] = string.Empty;
        //    dr["Col3"] = string.Empty;
        //    dr["Col4"] = string.Empty;
        //    dr["Col5"] = string.Empty;
        //    dr["Col5"] = string.Empty;

        //    dt.Rows.Add(dr);

        //    ViewState["CurrentTable"] = dt;
        //    grvTransaction.DataSource = dt;
        //    grvTransaction.DataBind();

        //    //Button btnAdd = (Button)grvTransaction.FooterRow.Cells[6].FindControl("ButtonAdd");

        //}

        //private void AddNewRow()
        //{

        //    int rowIndex = 0;

        //    if (ViewState["CurrentTable"] != null)
        //    {
        //        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
        //        DataRow drCurrentRow = null;
        //        if (dtCurrentTable.Rows.Count > 0)
        //        {

        //            for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
        //            {
        //                Label lnlProductName = (Label)grvTransaction.Rows[rowIndex].Cells[1].FindControl("lnlProductName");
        //                Label lblRate = (Label)grvTransaction.Rows[rowIndex].Cells[2].FindControl("lblRate");
        //                Label lblGst = (Label)grvTransaction.Rows[rowIndex].Cells[3].FindControl("lblGst");
        //                Label txtQty = (Label)grvTransaction.Rows[rowIndex].Cells[4].FindControl("lblQty");
        //                Label lblAmt = (Label)grvTransaction.Rows[rowIndex].Cells[5].FindControl("lblAmt");


        //                drCurrentRow = dtCurrentTable.NewRow();
        //                drCurrentRow["RowNumber"] = i + 1;


        //                dtCurrentTable.Rows[i - 1]["Col1"] = lnlProductName.Text;
        //                dtCurrentTable.Rows[i - 1]["Col2"] = lblRate.Text;
        //                dtCurrentTable.Rows[i - 1]["Col3"] = lblGst.Text;
        //                dtCurrentTable.Rows[i - 1]["Col4"] = txtQty.Text;
        //                dtCurrentTable.Rows[i - 1]["Col5"] = lblAmt.Text;

        //                rowIndex++;

        //            }

        //            if (rowIndex != totalRecords)
        //                dtCurrentTable.Rows.Add(drCurrentRow);

        //            ViewState["CurrentTable"] = dtCurrentTable;

        //            grvTransaction.DataSource = dtCurrentTable;
        //            grvTransaction.DataBind();

        //        }
        //    }
        //    else
        //    {
        //        Response.Write("ViewState is null");
        //    }
        //    SetPreviousData();
        //}

        //private void SetPreviousData()
        //{
        //    try
        //    {
        //        int rowIndex = 0;
        //        decimal Drtotal = 0;
        //        decimal Crtotal = 0;
        //        if (ViewState["CurrentTable"] != null)
        //        {
        //            DataTable dt = (DataTable)ViewState["CurrentTable"];
        //            if (dt.Rows.Count > 0)
        //            {
        //                int check = dt.Rows.Count - 1;
        //                for (int i = 0; i < dt.Rows.Count; i++)
        //                {
        //                    Label lnlProductName = (Label)grvTransaction.Rows[rowIndex].Cells[1].FindControl("lnlProductName");
        //                    Label lblRate = (Label)grvTransaction.Rows[rowIndex].Cells[2].FindControl("lblRate");
        //                    Label lblGst = (Label)grvTransaction.Rows[rowIndex].Cells[3].FindControl("lblGst");
        //                    Label txtQty = (Label)grvTransaction.Rows[rowIndex].Cells[4].FindControl("lblQty");
        //                    Label lblAmt = (Label)grvTransaction.Rows[rowIndex].Cells[5].FindControl("lblAmt");

        //                    grvTransaction.Rows[i].Cells[0].Text = Convert.ToString(i + 1);


        //                    lnlProductName.Text = dt.Rows[i]["Col1"].ToString();
        //                    lblRate.Text = dt.Rows[i]["Col2"].ToString();
        //                    lblGst.Text = dt.Rows[i]["Col3"].ToString();
        //                    txtQty.Text = dt.Rows[i]["Col4"].ToString();
        //                    lblAmt.Text = dt.Rows[i]["Col5"].ToString();

        //                    rowIndex++;
        //                }

        //            }
        //        }

        //    }
        //    catch (Exception x)
        //    {

        //    }
        //}

    }
}