using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using PatelTeaSource.Model;
using PatelTeaSource.Repository.UserLoginRepo;
using System.Security.Cryptography;
using PatelTeaSource.Classes;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace PatelTeaSource.CS
{
    public partial class Checkout : System.Web.UI.Page
    {
        string ipAdd;
        long passedUserId = 0, orderIdRandom = 0, orderNumberForMail = 0, totalItemForMail = 0;
        int proTax = 0;
        public Checkout()
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

        public Checkout(CartRepository cartRepository, CartDetailsRepo cartDetailsRepo, ProductMasterRepository productMasterRepository, ProductPriceRepository productPriceRepository, OrderMasterRepository orderMasterRepository, OrderMasterDetailsRepository orderMasterDetailsRepository, OrderMasterPaymentRepository orderMasterPaymentRepository, OrderHistoryRepository orderHistoryRepository, OrderHistoryDetailsRepository orderHistoryDetailsRepository, UserMasterRepository userMasterRepository, UserLoginRepository userLoginRepository, ShippingAddressRepository shippingAddressRepository, GlobalParametersRepository globalParametersRepository)
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
        int totalRecords = 0;
        decimal? subtotal = 0, totalAmt = 0, tax = 0, shippingRate = 0;

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                #region validation
                if (txtEmailUsername.Text == string.Empty)
                {
                    txtEmailUsername.Focus();
                    txtEmailUsername.BorderColor = System.Drawing.Color.Red;
                    errorEmailUserNameSpan.Visible = true;
                    return;
                }
                else
                {
                    errorEmailUserNameSpan.Visible = false;
                    txtEmailUsername.BorderColor = System.Drawing.Color.LightGray;
                }

                if (txtPasswordLogin.Text == string.Empty)
                {
                    txtPasswordLogin.Focus();
                    txtPasswordLogin.BorderColor = System.Drawing.Color.Red;
                    errorUserPwdSpan.Visible = true;
                    return;
                }
                else
                {
                    errorUserPwdSpan.Visible = false;
                    txtPasswordLogin.BorderColor = System.Drawing.Color.LightGray;
                }
                #endregion

                var data = _iUserLoginRepository.SelectByUserNamePwd(txtEmailUsername.Text.Trim().ToString(), txtPasswordLogin.Text.Trim().ToString());

                if (data != null)
                {

                    if (data.type == 1)
                    {
                        if (data.status == 1)
                        {
                            Session.Add("user_id_client", data.user_id);

                            Response.Redirect("Checkout.aspx");
                        }
                        else
                        {
                            errorDiv.Visible = true;
                            lblError.Text = "User account is diabled. Please contact your administrator.";
                            return;
                        }
                    }
                }
                else
                {
                    errorDiv.Visible = true;
                    lblError.Text = "Login failed. Please, try again.";
                    return;
                }
            }
            catch (Exception x)
            {

            }
        }

        protected void txtEmailAddress_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            try
            {
                GetIPAddressClass ipAddressCurrentMachine = new GetIPAddressClass();

                //   ipAdd = ipAddressCurrentMachine.GetIP();
                ipAdd = Request.Cookies["ipAdd"].Value.ToString();

                totalAmt = Convert.ToDecimal(Session["Amount"]);
                passedUserId = Convert.ToInt32(Session["user_id_client"]);

                if (passedUserId >= 0)
                {

                    var checkEmail = _iUserMasterRepository.SelectAll().Where(x => x.email == txtEmailAddress.Text.Trim().ToString()).FirstOrDefault();

                    #region validation
                    if (txtFirstName.Text == string.Empty)
                    {
                        txtFirstName.Focus();
                        txtFirstName.BorderColor = System.Drawing.Color.Red;
                        errorFirstNameSpan.Visible = true;
                        return;
                    }
                    else
                    {
                        errorFirstNameSpan.Visible = false;
                        txtFirstName.BorderColor = System.Drawing.Color.LightGray;
                    }

                    if (txtLastName.Text == string.Empty)
                    {
                        txtLastName.Focus();
                        txtLastName.BorderColor = System.Drawing.Color.Red;
                        errorLastNameSpan.Visible = true;
                        return;
                    }
                    else
                    {
                        errorLastNameSpan.Visible = false;
                        txtLastName.BorderColor = System.Drawing.Color.LightGray;
                    }
                    if (txtStreetAdd.Text == string.Empty)
                    {
                        txtStreetAdd.Focus();
                        txtStreetAdd.BorderColor = System.Drawing.Color.Red;
                        errorStreetAddSpan.Visible = true;
                        return;
                    }
                    else
                    {
                        errorStreetAddSpan.Visible = false;
                        txtStreetAdd.BorderColor = System.Drawing.Color.LightGray;
                    }
                    if (txtCity.Text == string.Empty)
                    {
                        txtCity.Focus();
                        txtCity.BorderColor = System.Drawing.Color.Red;
                        errorCitySpan.Visible = true;
                        return;
                    }
                    else
                    {
                        errorCitySpan.Visible = false;
                        txtCity.BorderColor = System.Drawing.Color.LightGray;
                    }
                    if (txtPincode.Text == string.Empty)
                    {
                        txtPincode.Focus();
                        txtPincode.BorderColor = System.Drawing.Color.Red;
                        errorPincodeSpan.Visible = true;
                        lblPinCodeError.Text = "Enter Pincode";
                        return;
                    }
                    else
                    {
                        string pin = txtPincode.Text.Substring(0, 2);

                        if (pin == "36")
                        {
                           
                        }
                        else if (pin == "37")
                        {

                        }
                        else if (pin == "38")
                        {

                        }
                        else if (pin == "39")
                        {

                        }
                        else
                        {
                            txtPincode.Focus();
                            txtPincode.BorderColor = System.Drawing.Color.Red;
                            errorPincodeSpan.Visible = true;
                            lblPinCodeError.Text = "Delivery not available at this pin-code";
                            return;
                        }

                        errorPincodeSpan.Visible = false;
                        txtPincode.BorderColor = System.Drawing.Color.LightGray;
                    }
                    if (txtMobile.Text == string.Empty)
                    {
                        txtMobile.Focus();
                        txtMobile.BorderColor = System.Drawing.Color.Red;
                        errorPhoneSpan.Visible = true;
                        return;
                    }
                    else
                    {
                        errorPhoneSpan.Visible = false;
                        txtMobile.BorderColor = System.Drawing.Color.LightGray;
                    }
                    if (txtEmailAddress.Text == string.Empty)
                    {
                        txtEmailAddress.Focus();
                        txtEmailAddress.BorderColor = System.Drawing.Color.Red;
                        errorSpanEmail.Visible = true;
                        return;
                    }
                    else
                    {
                        errorSpanEmail.Visible = false;
                        txtEmailAddress.BorderColor = System.Drawing.Color.LightGray;
                    }

                    if (passedUserId == 0)
                    {
                        if (txtPwd.Text == string.Empty)
                        {
                            txtPwd.Focus();
                            txtPwd.BorderColor = System.Drawing.Color.Red;
                            errorPwdSpan.Visible = true;
                            return;
                        }
                        else
                        {
                            errorPwdSpan.Visible = false;
                            txtPwd.BorderColor = System.Drawing.Color.LightGray;
                        }
                        if (txtConfirmPass.Text == string.Empty)
                        {
                            txtConfirmPass.Focus();
                            txtConfirmPass.BorderColor = System.Drawing.Color.Red;
                            errorConfirmPwdSpan.Visible = true;
                            return;
                        }
                        else
                        {
                            errorConfirmPwdSpan.Visible = false;
                            txtConfirmPass.BorderColor = System.Drawing.Color.LightGray;
                        }


                        if (checkEmail != null)
                        {
                            txtEmailAddress.Focus();
                            txtEmailAddress.BorderColor = System.Drawing.Color.Red;
                            errorSpanEmail.Visible = true;
                        }
                        else
                        {
                            errorSpanEmail.Visible = false;
                            txtEmailAddress.BorderColor = System.Drawing.Color.LightGray;
                        }
                    }
                    if (!chkShipping.Checked)
                    {
                        if (txtFirstNameShipping.Text == string.Empty)
                        {
                            txtFirstNameShipping.Focus();
                            txtFirstNameShipping.BorderColor = System.Drawing.Color.Red;
                            errorFirstNameShippingSpan.Visible = true;
                            return;
                        }
                        else
                        {
                            errorFirstNameShippingSpan.Visible = false;
                            txtFirstNameShipping.BorderColor = System.Drawing.Color.LightGray;
                        }
                        if (txtLastNameShipping.Text == string.Empty)
                        {
                            txtLastNameShipping.Focus();
                            txtLastNameShipping.BorderColor = System.Drawing.Color.Red;
                            errorLastNameShippingSpan.Visible = true;
                            return;
                        }
                        else
                        {
                            errorLastNameShippingSpan.Visible = false;
                            txtLastNameShipping.BorderColor = System.Drawing.Color.LightGray;
                        }
                        if (txtStreetAddressShipping.Text == string.Empty)
                        {
                            txtStreetAddressShipping.Focus();
                            txtStreetAddressShipping.BorderColor = System.Drawing.Color.Red;
                            errorStreetAddShippingSpan.Visible = true;
                            return;
                        }
                        else
                        {
                            errorStreetAddShippingSpan.Visible = false;
                            txtStreetAddressShipping.BorderColor = System.Drawing.Color.LightGray;
                        }

                        if (txtCityShipping.Text == string.Empty)
                        {
                            txtCityShipping.Focus();
                            txtCityShipping.BorderColor = System.Drawing.Color.Red;
                            errorCitySpinningSpan.Visible = true;
                            return;
                        }
                        else
                        {
                            errorCitySpinningSpan.Visible = false;
                            txtCityShipping.BorderColor = System.Drawing.Color.LightGray;
                        }
                        if (txtPincodeShipping.Text == string.Empty)
                        {
                            txtPincodeShipping.Focus();
                            txtPincodeShipping.BorderColor = System.Drawing.Color.Red;
                            errorPincodeShippingSpan.Visible = true;
                            return;
                        }
                        else
                        {
                            string pin = txtPincodeShipping.Text.Substring(0, 2);

                             
                            if (pin == "36")
                            {

                            }
                            else if (pin == "37")
                            {

                            }
                            else if (pin == "38")
                            {

                            }
                            else if (pin == "39")
                            {

                            }
                            else
                            {
                                txtPincodeShipping.Focus();
                                txtPincodeShipping.BorderColor = System.Drawing.Color.Red;
                                errorPincodeSpan.Visible = true;
                                lblShippiNGPinCodeError.Text = "Delivery not available at this pin-code";
                                return;
                            }

                            errorPincodeShippingSpan.Visible = false;
                            txtPincodeShipping.BorderColor = System.Drawing.Color.LightGray;
                        }
                        if (txtMobileShipping.Text == string.Empty)
                        {
                            txtMobileShipping.Focus();
                            txtMobileShipping.BorderColor = System.Drawing.Color.Red;
                            errorPhoneShippingSpan.Visible = true;
                            return;
                        }
                        else
                        {
                            errorPhoneShippingSpan.Visible = false;
                            txtMobileShipping.BorderColor = System.Drawing.Color.LightGray;
                        }
                    }
                    #endregion

                    if (passedUserId == 0)
                    {
                        if (checkEmail != null)
                        {
                            txtEmailAddress.Focus();
                            txtEmailAddress.BorderColor = System.Drawing.Color.Red;
                            errorSpanEmail.Visible = true;
                            return;
                        }
                        else
                        {
                            errorSpanEmail.Visible = false;
                            txtEmailAddress.BorderColor = System.Drawing.Color.LightGray;
                        }
                    }
                    if (!chkTermsConditions.Checked)
                    {
                        errorDiv.Visible = true;
                        lblError.Text = "Please read and accept the terms and conditions to proceed with your order.";
                        return;
                    }
                    else
                    {
                        errorDiv.Visible = false;

                        if (passedUserId == 0)
                        {
                            addUserMasterData();
                        }
                        else
                        {

                            var userMasterData = _iUserMasterRepository.SelectAll().OrderByDescending(x => x.user_id).FirstOrDefault();

                            if (userMasterData == null)
                            {
                                addUserMasterData();
                            }
                            else
                            {
                                userMasterData.fname = txtFirstName.Text.Trim().ToString();
                                userMasterData.lname = txtLastName.Text.Trim().ToString();
                                userMasterData.company_name = txtCompanyName.Text.Trim().ToString();
                                userMasterData.addLine1 = txtStreetAdd.Text.Trim().ToString();
                                userMasterData.addLine2 = txtStreetAdd2.Text.Trim().ToString();
                                userMasterData.city = txtCity.Text.Trim().ToString();
                                userMasterData.state = "Gujarat";
                                userMasterData.pincode = txtPincode.Text.Trim().ToString();
                                userMasterData.email = txtEmailAddress.Text.Trim().ToString();
                                userMasterData.mobile = txtMobile.Text.Trim().ToString();
                                userMasterData.udate = DateTime.Now;

                                _iUserMasterRepository.Update(userMasterData);

                                //Update Username in user login if email address is changed
                                var userLoginEmail = _iUserLoginRepository.SelectAll().Where(x => x.user_id == passedUserId).FirstOrDefault();

                                if (userLoginEmail != null)
                                {
                                    userLoginEmail.username = txtEmailAddress.Text.Trim().ToString();
                                    _iUserLoginRepository.Update(userLoginEmail);
                                }
                            }
                        }

                        var userMasterId = _iUserMasterRepository.SelectAll().OrderByDescending(x => x.user_id).FirstOrDefault().user_id;

                        if (passedUserId == 0)
                        {

                            login_master modelLoginMaster = new login_master();
                            modelLoginMaster.user_id = userMasterId;
                            modelLoginMaster.username = txtEmailAddress.Text.Trim().ToString();
                            modelLoginMaster.password = txtPwd.Text.Trim().ToString();
                            modelLoginMaster.type = 1;
                            modelLoginMaster.status = 1;
                            modelLoginMaster.cdate = DateTime.Now;
                            _iUserLoginRepository.Add(modelLoginMaster);
                        }


                        if (passedUserId == 0)
                        {
                            addShippingAddressMaster(userMasterId);
                        }
                        else
                        {
                            var shippingData = _iShippingAddressRepository.SelectAll().Where(x => x.user_id == passedUserId).FirstOrDefault();

                            if (shippingData == null)
                            {
                                addShippingAddressMaster(userMasterId);
                            }
                            else
                            {
                                if (!chkShipping.Checked)
                                {
                                    shippingData.fname = txtFirstNameShipping.Text.Trim().ToString();
                                    shippingData.lname = txtLastNameShipping.Text.Trim().ToString();
                                    shippingData.line1 = txtStreetAddressShipping.Text.Trim().ToString();
                                    shippingData.line2 = txtStreedAddressShipping2.Text.Trim().ToString();
                                    shippingData.city = txtCityShipping.Text.Trim().ToString();
                                    shippingData.companyName = txtCompanyNameShipping.Text.Trim().ToString();
                                    shippingData.pincode = txtPincodeShipping.Text.Trim().ToString();
                                    shippingData.state = "Gujarat";
                                    shippingData.country = "India";
                                    shippingData.mobile = Convert.ToDecimal(txtMobileShipping.Text.Trim());

                                }
                                else
                                {
                                    shippingData.fname = txtFirstName.Text.Trim().ToString();
                                    shippingData.lname = txtLastName.Text.Trim().ToString();
                                    shippingData.line1 = txtStreetAdd.Text.Trim().ToString();
                                    shippingData.line2 = txtStreetAdd2.Text.Trim().ToString();
                                    shippingData.city = txtCity.Text.Trim().ToString();
                                    shippingData.companyName = txtCompanyName.Text.Trim().ToString();
                                    shippingData.pincode = txtPincode.Text.Trim().ToString();
                                    shippingData.state = "Gujarat";
                                    shippingData.country = "India";
                                    shippingData.mobile = Convert.ToDecimal(txtMobile.Text.Trim());
                                }
                                _iShippingAddressRepository.Update(shippingData);
                            }
                        }
                        //}
                        //else
                        //{
                        //    // chkShipping.Checked = true;

                        //    var shippingData = _iShippingAddressRepository.SelectAll().Where(x => x.user_id == passedUserId).FirstOrDefault();

                        //    shippingData.fname = txtFirstName.Text.Trim().ToString();
                        //    shippingData.lname = txtLastName.Text.Trim().ToString();
                        //    shippingData.line1 = txtStreetAdd.Text.Trim().ToString();
                        //    shippingData.line2 = txtStreetAdd2.Text.Trim().ToString();
                        //    shippingData.city = txtCity.Text.Trim().ToString();
                        //    shippingData.country = txtCompanyNameShipping.Text.Trim().ToString();
                        //    shippingData.pincode = txtPincodeShipping.Text.Trim().ToString();
                        //    shippingData.state = "Gujarat";
                        //    shippingData.country = "India";
                        //    shippingData.mobile = Convert.ToDecimal(txtMobile.Text.Trim());

                        //    _iShippingAddressRepository.Update(shippingData);
                        //}


                        //Order Table & order detials table entry
                        #region Order table entry

                        //Current Users last cart number thats to be entered in order master table
                        var cartMasterId = _iCartRepository.SelectAll().Where(x => x.user_id == passedUserId || x.ipAdd == ipAdd).OrderByDescending(x => x.cart_id).FirstOrDefault().cart_id;

                        var checkOrderByCart = _iOrderMasterRepository.SelectAll().Where(x => x.user_id == passedUserId && x.cartIdTemp == cartMasterId).OrderByDescending(x => x.order_id).FirstOrDefault();

                        if (checkOrderByCart == null)
                        {

                            //Last order id to increment and get new id for new order master record


                            //New Record in Order Mater and order Details
                            EnterNewRecordInOrder(cartMasterId, totalAmt, userMasterId);


                        }
                        else
                        {
                            if (checkOrderByCart.order_status != 0)
                            {
                                //New Record in Order Mater and order Details
                                EnterNewRecordInOrder(cartMasterId, totalAmt, userMasterId);
                            }
                            else
                            {
                                // Edit Same Order

                                var modelOrderMaster = _iOrderMasterRepository.SelectAll().Where(x => x.order_status == 0 && x.user_id == passedUserId).OrderByDescending(x => x.order_id).FirstOrDefault();

                                if (passedUserId == 0)
                                {
                                    passedUserId = userMasterId;
                                }
                                modelOrderMaster.user_id = passedUserId;
                                //    modelOrderMaster.order_id = orderIdRandom;
                                modelOrderMaster.order_datetime = DateTime.Now;
                                modelOrderMaster.order_status = 0;
                                modelOrderMaster.udate = DateTime.Now;
                                modelOrderMaster.gtotal = Convert.ToDecimal(totalAmt);
                                // modelOrderMaster.cartIdTemp = cartMasterId;

                                _iOrderMasterRepository.Update(modelOrderMaster);

                                #endregion

                                #region order details table entry

                                var orderMasterId = _iOrderMasterRepository.SelectAll().Where(x => x.user_id == passedUserId).OrderByDescending(x => x.order_id).FirstOrDefault();

                                // long cartMasterId= _iCartRepository.SelectAll().Where(x => x.user_id == passedUserId).FirstOrDefault().cart_id;

                                var modelOrderMasterDetailss = _iOrderMasterDetailsRepository.SelectAll().Where(x => x.order_id == modelOrderMaster.order_id).ToList();

                                foreach (var item in modelOrderMasterDetailss)
                                {
                                    _iOrderMasterDetailsRepository.Delete(Convert.ToInt32(item.order_detail_id));

                                }

                                var dataCartDetails = _iCartDetailsRepo.SelectAll().Where(x => x.cart_id == cartMasterId).ToList();


                                foreach (var item in dataCartDetails)
                                {
                                    //  order_master_details modelOrderMasterDetails = new order_master_details();

                                    order_master_details modelOrderMasterDetails = new order_master_details();
                                    modelOrderMasterDetails.order_id = orderMasterId.order_id;
                                    modelOrderMasterDetails.pid = item.pid;
                                    modelOrderMasterDetails.qty = item.qty;
                                    modelOrderMasterDetails.rate = item.rate;
                                    modelOrderMasterDetails.amount = item.amount;
                                    modelOrderMasterDetails.cdate = DateTime.Now;

                                    _iOrderMasterDetailsRepository.Add(modelOrderMasterDetails);

                                    totalItemForMail++;
                                }

                            }

                        }
                        #endregion

                        #region MakePayment
                        passedUserId = Convert.ToInt32(Session["user_id_client"]);

                        if (passedUserId == 0)
                        {
                            passedUserId = userMasterId;
                        }

                        var orderMasterIds = _iOrderMasterRepository.SelectAll().Where(x => x.user_id == passedUserId).OrderByDescending(x => x.order_id).FirstOrDefault();
                        var pInfo = string.Join(",", _iOrderMasterDetailsRepository.SelectAll().Where(x => x.order_id == orderMasterIds.order_id).Select(x => x.pid));

                        Response.Write("<script> alert('" + pInfo + "')</script>");

                        Double amount = Convert.ToDouble("6.00");
                        totalAmt = Convert.ToDecimal(Session["Amount"]);
                        // String text = key.Value.ToString() + "|" + txnid.Value.ToString() + "|" + amount + "|" + "Women Tops" + "|" +"Harsh Soni" + "|" + "harshsoni6011@gmail.com"+ "|" + "1" + "|" + "1" + "|" + "1" + "|" + "1" + "|" + "1" + "||||||" + salt.Value.ToString();
                        string text = key.Value.ToString() + "|" + orderMasterIds.order_id.ToString() + "|" + totalAmt + "|" + pInfo.ToString() + "|" + txtFirstName.Text.Trim().ToString() + "|" + txtEmailAddress.Text.Trim().ToString() + "|||||" + "BOLT_KIT_ASP.NET" + "||||||" + salt.Value.ToString();

                        //Response.Write(text);
                        //byte[] message = Encoding.UTF8.GetBytes(text);

                        //UnicodeEncoding UE = new UnicodeEncoding();
                        //byte[] hashValue;
                        //SHA512Managed hashString = new SHA512Managed();
                        //string hex = "";
                        //hashValue = hashString.ComputeHash(message);
                        //foreach (byte x in hashValue)
                        //{
                        //    hex += String.Format("{0:x2}", x);
                        //}
                        //hash.Value = hex;


                        byte[] hashs;
                        var datab = Encoding.UTF8.GetBytes(text);
                        using (SHA512 shaM = new SHA512Managed())
                        {
                            hashs = shaM.ComputeHash(datab);
                        }

                        Session.Add("mKey", key.Value.ToString());
                        Session.Add("saltKey", salt.Value.ToString());
                        Session.Add("txnId", orderMasterIds.order_id);  //order Id
                                                                        // Session.Add("amount", totalAmt);
                        Session.Add("pInfo", pInfo);  //Product Ids
                        Session.Add("fName", txtFirstName.Text.Trim().ToString());
                        Session.Add("emailId", txtEmailAddress.Text.Trim().ToString());
                        Session.Add("mobile", txtMobile.Text.Trim().ToString());
                        Session.Add("hash", GetStringFromHash(hashs));

                        Response.Redirect("PayUMoneyPayment.aspx");
                        #endregion

                    }
                }
                else
                {
                    errorDiv.Visible = true;
                    lblError.Text = "You must have to login before checkout.";
                    return;
                }


            }

            catch (Exception x)
            {

            }
        }

        public class model_messges
        {

            public string api_key
            {

                get;

                set;

            }

            public string api_token
            {

                get;

                set;

            }

            public string sender
            {

                get;

                set;

            }

            public string receiver
            {

                get;

                set;

            }

            public string msgtype
            {

                get;

                set;

            }

            public string sms
            {

                get;

                set;

            }

        }


        private void addUserMasterData()
        {
            user_master model = new user_master();
            model.fname = txtFirstName.Text.Trim().ToString();
            model.lname = txtLastName.Text.Trim().ToString();
            model.company_name = txtCompanyName.Text.Trim().ToString();
            model.addLine1 = txtStreetAdd.Text.Trim().ToString();
            model.addLine2 = txtStreetAdd2.Text.Trim().ToString();
            model.city = txtCity.Text.Trim().ToString();
            model.state = "Gujarat";
            model.pincode = txtPincode.Text.Trim().ToString();
            model.email = txtEmailAddress.Text.Trim().ToString();
            model.mobile = txtMobile.Text.Trim().ToString();
            model.cdate = DateTime.Now;

            _iUserMasterRepository.Add(model);
        }


        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2").ToLower());
            }
            return result.ToString();
        }
        private string PreparePOSTForm(string url, System.Collections.Hashtable data)      // post form
        {
            //Set a name for the form
            string formID = "PostForm";
            //Build the form using the specified data to be posted.
            StringBuilder strForm = new StringBuilder();
            strForm.Append("<form id=\"" + formID + "\" name=\"" +
                           formID + "\" action=\"" + url +
                           "\" method=\"POST\">");

            foreach (System.Collections.DictionaryEntry key in data)
            {

                strForm.Append("<input type=\"hidden\" name=\"" + key.Key +
                               "\" value=\"" + key.Value + "\">");
            }


            strForm.Append("</form>");
            //Build the JavaScript which will do the Posting operation.
            StringBuilder strScript = new StringBuilder();
            strScript.Append("<script language='javascript'>");
            strScript.Append("var v" + formID + " = document." +
                             formID + ";");
            strScript.Append("v" + formID + ".submit();");
            strScript.Append("</script>");
            //Return the form and the script concatenated.
            //(The order is important, Form then JavaScript)
            return strForm.ToString() + strScript.ToString();
        }



        private void addShippingAddressMaster(long userMasterId)
        {
            shipping_address_master modelShipping = new shipping_address_master();
            if (!chkShipping.Checked)
            {
                modelShipping.fname = txtFirstNameShipping.Text.Trim().ToString();
                modelShipping.lname = txtLastNameShipping.Text.Trim().ToString();
                modelShipping.line1 = txtStreetAddressShipping.Text.Trim().ToString();
                modelShipping.line2 = txtStreedAddressShipping2.Text.Trim().ToString();
                modelShipping.city = txtCityShipping.Text.Trim().ToString();
                modelShipping.companyName = txtCompanyNameShipping.Text.Trim().ToString();
                modelShipping.pincode = txtPincodeShipping.Text.Trim().ToString();
                modelShipping.state = "Gujarat";
                modelShipping.country = "India";
                modelShipping.mobile = Convert.ToDecimal(txtMobileShipping.Text.Trim());
                modelShipping.user_id = userMasterId;
                modelShipping.status = 1;

            }
            else
            {
                modelShipping.fname = txtFirstName.Text.Trim().ToString();
                modelShipping.lname = txtLastName.Text.Trim().ToString();
                modelShipping.line1 = txtStreetAdd.Text.Trim().ToString();
                modelShipping.line2 = txtStreetAdd2.Text.Trim().ToString();
                modelShipping.city = txtCity.Text.Trim().ToString();
                modelShipping.companyName = txtCompanyName.Text.Trim().ToString();
                modelShipping.pincode = txtPincode.Text.Trim().ToString();
                modelShipping.state = "Gujarat";
                modelShipping.country = "India";
                modelShipping.mobile = Convert.ToDecimal(txtMobile.Text.Trim());
                modelShipping.user_id = userMasterId;
                modelShipping.status = 1;
            }
            _iShippingAddressRepository.Add(modelShipping);
        }
        private void EnterNewRecordInOrder(long cartMasterIds, decimal? ttlAmt, long userId)
        {

            #region Order master table entry

            if (passedUserId == 0)
            {
                passedUserId = userId;
            }

            var lastOrderId = _iOrderMasterRepository.SelectAll().OrderByDescending(x => x.order_id).FirstOrDefault();

            if (lastOrderId != null)
            {
                orderIdRandom = lastOrderId.order_id + 1;
            }
            else
            {
                orderIdRandom = 100;
            }

            order_master modelOrderMaster = new order_master();

            modelOrderMaster.user_id = passedUserId;
            modelOrderMaster.order_id = orderIdRandom;
            modelOrderMaster.order_datetime = DateTime.Now;
            modelOrderMaster.order_status = 0;
            modelOrderMaster.cdate = DateTime.Now;
            modelOrderMaster.gtotal = ttlAmt;
            modelOrderMaster.cartIdTemp = cartMasterIds;

            _iOrderMasterRepository.Add(modelOrderMaster);

            #endregion

            #region order details table entry

            var orderMasterId = _iOrderMasterRepository.SelectAll().OrderByDescending(x => x.order_id).FirstOrDefault();

            // long cartMasterId= _iCartRepository.SelectAll().Where(x => x.user_id == passedUserId).FirstOrDefault().cart_id;

            var dataCartDetails = _iCartDetailsRepo.SelectAll().Where(x => x.cart_id == cartMasterIds).ToList();

            foreach (var item in dataCartDetails)
            {
                order_master_details modelOrderMasterDetails = new order_master_details();
                modelOrderMasterDetails.order_id = orderMasterId.order_id;
                modelOrderMasterDetails.pid = item.pid;
                modelOrderMasterDetails.qty = item.qty;
                modelOrderMasterDetails.rate = item.rate;
                modelOrderMasterDetails.amount = item.amount;
                modelOrderMasterDetails.cdate = DateTime.Now;

                _iOrderMasterDetailsRepository.Add(modelOrderMasterDetails);
            }
            #endregion
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    //----------------------------------------------------------------------

                    var dataG = _iGlobalParametersRepository.SelectAll().Where(x => x.globalParamKey == "Merchantkey").FirstOrDefault();

                    if (dataG != null)
                    {
                        key.Value = dataG.globalParamValue;
                    }
                    var dataGs = _iGlobalParametersRepository.SelectAll().Where(x => x.globalParamKey == "MerchantSalt").FirstOrDefault();

                    if (dataG != null)
                    {
                        salt.Value = dataGs.globalParamValue;
                    }


                    //Random r = new Random();
                    //string txnids = "Txn" + r.Next(100, 9999);
                    //txnid.Value =txnids;

                    //Random r = new Random();
                    //string txnid = "Txn" + r.Next(100, 9999);
                    //txnid.Value = (Convert.ToString(random.Next(10000, 20000)));
                    //txnid.Value = (Convert.ToString(random.Next(10000, 20000)));
                    //txnid.Value = "Hariti" + txnid.Value.ToString();

                    //----------------------------------------------------------------------

                    GetIPAddressClass GetIp = new GetIPAddressClass();

                    passedUserId = Convert.ToInt32(Session["user_id_client"]);

                    // var ipAddress = GetIp.GetIP();

                    if (Request.Cookies["ipAdd"] == null)
                    {
                        Response.Redirect("Products.aspx");
                        return;
                    }

                    var ipAddress = Request.Cookies["ipAdd"].Value.ToString();
                    List<cart_master> checkData = new List<cart_master>();

                    if (passedUserId == 0)
                    {
                        checkData = _iCartRepository.SelectAll().Where(x => x.ipAdd == ipAddress).ToList();
                    }

                    else
                    {
                        checkData = _iCartRepository.SelectAll().Where(x => x.ipAdd == ipAddress || x.user_id == passedUserId).ToList();
                    }
                    if (checkData.Count() == 0)
                    {
                        Response.Redirect("Products.aspx");
                    }

                    passedUserId = Convert.ToInt32(Session["user_id_client"]);
                    if (passedUserId >= 0)
                    {
                        if (passedUserId > 0)
                        {
                            loginPart.Visible = false;

                            pwdDiv.Visible = false;

                            var userData = _iUserMasterRepository.SelectById(passedUserId);

                            txtEmailUsername.Text = userData.email;

                            var shippingData = _iShippingAddressRepository.SelectAll().Where(x => x.user_id == passedUserId).FirstOrDefault();

                            if (userData.fname != null)
                                txtFirstName.Text = userData.fname.Trim().ToString();

                            if (userData.lname != null)
                                txtLastName.Text = userData.lname.Trim().ToString();

                            if (userData.company_name != null)
                                txtCompanyName.Text = userData.company_name.Trim().ToString();

                            if (userData.addLine1 != null)
                                txtStreetAdd.Text = userData.addLine1.Trim().ToString();

                            if (userData.addLine2 != null)
                                txtStreetAdd2.Text = userData.addLine2.Trim().ToString();

                            if (userData.city != null)
                                txtCity.Text = userData.city.Trim().ToString();

                            if (userData.pincode != null)
                                txtPincode.Text = userData.pincode.Trim().ToString();

                            if (userData.mobile != null)
                                txtMobile.Text = userData.mobile.Trim().ToString();

                            if (userData.email != null)
                                txtEmailAddress.Text = userData.email.Trim().ToString();

                            if (shippingData != null)
                            {
                                if (shippingData.fname != null)
                                    txtFirstNameShipping.Text = shippingData.fname.Trim().ToString();

                                if (shippingData.lname != null)
                                    txtLastNameShipping.Text = shippingData.lname.Trim().ToString();

                                if (shippingData.companyName != null)
                                    txtCompanyNameShipping.Text = shippingData.companyName.ToString();

                                if (shippingData.line1 != null)
                                    txtStreetAddressShipping.Text = shippingData.line1.Trim().ToString();

                                if (shippingData.line2 != null)
                                    txtStreedAddressShipping2.Text = shippingData.line2.Trim().ToString();

                                if (shippingData.city != null)
                                    txtCityShipping.Text = shippingData.city.Trim().ToString();

                                if (shippingData.pincode != null)
                                    txtPincodeShipping.Text = shippingData.pincode.Trim().ToString();

                                if (shippingData.mobile != null)
                                    txtMobileShipping.Text = shippingData.mobile.ToString();
                            }
                            else
                            {
                                chkShipping.Checked = true;

                                if (userData.fname != null)
                                    txtFirstNameShipping.Text = userData.fname.Trim().ToString();

                                if (userData.lname != null)
                                    txtLastNameShipping.Text = userData.lname.Trim().ToString();

                                if (userData.company_name != null)
                                    txtCompanyNameShipping.Text = userData.company_name.Trim().ToString();

                                if (userData.addLine1 != null)
                                    txtStreetAddressShipping.Text = userData.addLine1.Trim().ToString();

                                if (userData.addLine2 != null)
                                    txtStreedAddressShipping2.Text = userData.addLine2.Trim().ToString();

                                if (userData.city != null)
                                    txtCityShipping.Text = userData.city.Trim().ToString();

                                if (userData.pincode != null)
                                    txtPincodeShipping.Text = userData.pincode.Trim().ToString();

                                if (userData.mobile != null)
                                    txtMobileShipping.Text = userData.mobile.ToString();
                            }
                        }
                    }


                    // ipAdd = GetIp.GetIP();
                    ipAdd = Request.Cookies["ipAdd"].Value.ToString();
                    cart_master dataCartId;

                    if (passedUserId > 0)
                    {
                        dataCartId = _iCartRepository.SelectAll().Where(x => x.user_id == passedUserId).FirstOrDefault();
                        if (dataCartId == null)
                        {
                            dataCartId = _iCartRepository.SelectAll().Where(x => x.ipAdd == ipAdd).FirstOrDefault();
                        }

                    }
                    else
                    {
                        dataCartId = _iCartRepository.SelectAll().Where(x => x.ipAdd == ipAdd).FirstOrDefault();
                    }

                    var data = _iCartDetailsRepo.SelectByCartID(dataCartId.cart_id);

                    totalRecords = data.Count();

                    foreach (var item in data)
                    {
                        var productMasterData = _iProductMasterRepository.SelectById(item.pid);

                        if (productMasterData != null)
                        {
                            subtotal += Convert.ToDecimal(item.amount);
                            proTax += Convert.ToInt32(productMasterData.taxPer);

                            tax += (Convert.ToDecimal(item.amount) * Convert.ToInt32(productMasterData.taxPer)) / (100 + Convert.ToInt32(productMasterData.taxPer));

                            if (productMasterData.shippingCharge > 0)
                            {
                                shippingRate += Convert.ToDecimal(productMasterData.shippingCharge);
                            }
                        }

                    }

                    //tax = (subtotal * proTax) / 105;

                    totalAmt = subtotal;

                    lblSubTotal.Text = "₹ " + subtotal.ToString() + ".00";

                    DecimalFormat dcFormat = new DecimalFormat();
                    lblTax.Text = "₹ " + dcFormat.DoFormat(tax);

                    if (shippingRate == 0)
                    {
                        lblShippingRate.Text = "Free Shipping";
                        lblTotal.Text = "₹ " + totalAmt + ".00";
                        Session.Add("Amount", totalAmt);
                    }
                    else
                    {
                        lblShippingRate.Text = shippingRate.ToString();
                        totalAmt += shippingRate;
                        lblTotal.Text = "₹ " + totalAmt;
                        Session.Add("Amount", totalAmt);
                    }
                }

            }
            catch (Exception x)
            {
                Response.Write("<script> alert('" + x.ToString() + "') </script>");
            }
        }
    }
}