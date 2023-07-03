using System;
using System.Collections.Generic;
using System.Linq;
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
using PatelTeaSource.Repository.PasswordRecoveryRepo;
using PatelTeaSource.Classes;
using PatelTeaSource.Model;
using PatelTeaSource.Repository.UserLoginRepo;
using System.Text;
using System.Web.Security;
using System.IO;

namespace PatelTeaSource.CS
{
    public partial class MyAccount : System.Web.UI.Page
    {
        StringBuilder html;
        int passedUserId = 0, registeredUser = 0, passedOrderId = 0;

        public MyAccount()
          : this(new CartRepository(), new CartDetailsRepo(), new ProductMasterRepository(), new ProductPriceRepository(), new OrderMasterRepository(), new OrderMasterDetailsRepository(), new OrderMasterPaymentRepository(), new OrderHistoryRepository(), new OrderHistoryDetailsRepository(), new UserMasterRepository(), new UserLoginRepository(), new ShippingAddressRepository(), new PasswordRecoveryRepository())
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
        private IPasswordRecoveryRepository _iPasswordRecoveryRepository;

        public MyAccount(CartRepository cartRepository, CartDetailsRepo cartDetailsRepo, ProductMasterRepository productMasterRepository, ProductPriceRepository productPriceRepository, OrderMasterRepository orderMasterRepository, OrderMasterDetailsRepository orderMasterDetailsRepository, OrderMasterPaymentRepository orderMasterPaymentRepository, OrderHistoryRepository orderHistoryRepository, OrderHistoryDetailsRepository orderHistoryDetailsRepository, UserMasterRepository userMasterRepository, UserLoginRepository userLoginRepository, ShippingAddressRepository shippingAddressRepository, PasswordRecoveryRepository passwordRecoveryRepository)
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
            _iPasswordRecoveryRepository = passwordRecoveryRepository;
        }
        int totalRecords = 0;
        decimal? subtotal = 0, totalAmt = 0, tax = 0;

        protected void btnShipping_Click(object sender, EventArgs e)
        {
            try
            {


                //  var checkEmail = _iUserMasterRepository.SelectAll().Where(x => x.email == txtEmailAddress.Text.Trim().ToString()).FirstOrDefault();
                #region Validation for shipping address
                if (txtFirstNameShipping.Text == string.Empty)
                {
                    txtFirstNameShipping.Focus();
                    txtFirstNameShipping.BorderColor = System.Drawing.Color.Red;
                    errorFirstNameShippingSpan.Visible = true;
                    TabName.Value = "address";
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
                    TabName.Value = "address";
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
                    TabName.Value = "address";
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
                    TabName.Value = "address";
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
                    TabName.Value = "address";
                    return;
                }
                else
                {
                    errorPincodeShippingSpan.Visible = false;
                    txtPincodeShipping.BorderColor = System.Drawing.Color.LightGray;
                }
                if (txtMobileShipping.Text == string.Empty)
                {
                    txtMobileShipping.Focus();
                    txtMobileShipping.BorderColor = System.Drawing.Color.Red;
                    errorPhoneShippingSpan.Visible = true;
                    TabName.Value = "address";
                    return;
                }
                else
                {
                    errorPhoneShippingSpan.Visible = false;
                    txtMobileShipping.BorderColor = System.Drawing.Color.LightGray;
                }

                #endregion
                //save code

                #region Shipping Address Save Code
                passedUserId = Convert.ToInt32(Session["user_id_client"]);

                if (passedUserId != 0)
                {

                    var shippingAddData = _iShippingAddressRepository.SelectAll().Where(x => x.user_id == passedUserId).FirstOrDefault();
                    if (shippingAddData != null)
                    {
                        shippingAddData.fname = txtFirstNameShipping.Text.Trim().ToString();
                        shippingAddData.lname = txtLastNameShipping.Text.Trim().ToString();
                        shippingAddData.line1 = txtStreetAddressShipping.Text.Trim().ToString();
                        shippingAddData.line2 = txtStreedAddressShipping2.Text.Trim().ToString();
                        shippingAddData.city = txtCityShipping.Text.Trim().ToString();
                        shippingAddData.companyName = txtCompanyNameShipping.Text.Trim().ToString();
                        shippingAddData.pincode = txtPincodeShipping.Text.Trim().ToString();
                        shippingAddData.state = "Gujarat";
                        shippingAddData.country = "India";
                        shippingAddData.mobile = Convert.ToDecimal(txtMobileShipping.Text.Trim());

                        shippingAddData.status = 1;

                        _iShippingAddressRepository.Update(shippingAddData);
                    }
                    else
                    {
                        shipping_address_master modelShippingAddressAdd = new shipping_address_master();

                        modelShippingAddressAdd.fname = txtFirstNameShipping.Text.Trim().ToString();
                        modelShippingAddressAdd.lname = txtLastNameShipping.Text.Trim().ToString();
                        modelShippingAddressAdd.line1 = txtStreetAddressShipping.Text.Trim().ToString();
                        modelShippingAddressAdd.line2 = txtStreedAddressShipping2.Text.Trim().ToString();
                        modelShippingAddressAdd.city = txtCityShipping.Text.Trim().ToString();
                        modelShippingAddressAdd.companyName = txtCompanyNameShipping.Text.Trim().ToString();
                        modelShippingAddressAdd.pincode = txtPincodeShipping.Text.Trim().ToString();
                        modelShippingAddressAdd.state = "Gujarat";
                        modelShippingAddressAdd.country = "India";
                        modelShippingAddressAdd.user_id = passedUserId;
                        modelShippingAddressAdd.mobile = Convert.ToDecimal(txtMobileShipping.Text.Trim());

                        modelShippingAddressAdd.status = 1;

                        _iShippingAddressRepository.Add(modelShippingAddressAdd);
                    }
                    Response.Redirect("MyAccount.aspx");

                    #endregion
                }
                else
                {
                    Response.Redirect("MyAccount.aspx");
                }


            }
            catch (Exception x)
            {
                Response.Write("<script> alert('" + x.ToString() + "') </script>");
            }
        }

        protected void btnBilling_Click(object sender, EventArgs e)
        {
            try
            {

                #region validation for Billing Address
                if (txtFirstName.Text == string.Empty)
                {
                    txtFirstName.Focus();
                    txtFirstName.BorderColor = System.Drawing.Color.Red;
                    errorFirstNameSpan.Visible = true;
                    TabName.Value = "address";
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
                    TabName.Value = "address";
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
                    TabName.Value = "address";
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
                    TabName.Value = "address";
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
                    TabName.Value = "address";
                    return;
                }
                else
                {
                    errorPincodeSpan.Visible = false;
                    txtPincode.BorderColor = System.Drawing.Color.LightGray;
                }
                if (txtMobile.Text == string.Empty)
                {
                    txtMobile.Focus();
                    txtMobile.BorderColor = System.Drawing.Color.Red;
                    errorPhoneSpan.Visible = true;
                    TabName.Value = "address";
                    return;
                }
                else
                {
                    errorPhoneSpan.Visible = false;
                    txtMobile.BorderColor = System.Drawing.Color.LightGray;
                }
                //if (txtEmailAddress.Text == string.Empty)
                //{
                //    txtEmailAddress.Focus();
                //    txtEmailAddress.BorderColor = System.Drawing.Color.Red;
                //    errorSpanEmail.Visible = true;
                //    return;
                //}
                //else
                //{
                //    errorSpanEmail.Visible = false;
                //    txtEmailAddress.BorderColor = System.Drawing.Color.LightGray;
                //}


                #endregion 

                #region Code to Save billing Address
                passedUserId = Convert.ToInt32(Session["user_id_client"]);
                //save code here

                if (passedUserId != 0)
                {
                    var billingAddData = _iUserMasterRepository.SelectByUserID(passedUserId).FirstOrDefault();

                    billingAddData.fname = txtFirstName.Text.Trim().ToString();
                    billingAddData.lname = txtLastName.Text.Trim().ToString();
                    billingAddData.company_name = txtCompanyName.Text.Trim().ToString();
                    billingAddData.addLine1 = txtStreetAdd.Text.Trim().ToString();
                    billingAddData.addLine2 = txtStreetAdd2.Text.Trim().ToString();
                    billingAddData.city = txtCity.Text.Trim().ToString();
                    billingAddData.state = "Gujarat";
                    billingAddData.pincode = txtPincode.Text.Trim().ToString();

                    billingAddData.mobile = txtMobile.Text.Trim().ToString();
                    billingAddData.udate = DateTime.Now;

                    _iUserMasterRepository.Update(billingAddData);
                    Response.Redirect("MyAccount.aspx");
                }
                else
                {
                    Response.Redirect("MyAccount.aspx");
                }
                #endregion

            }
            catch (Exception x)
            {
                Response.Write("<script> alert('" + x.ToString() + "') </script>");
            }
        }

        private void removeAllSessions()
        {
            #region Logout Code

            Session.Abandon();
            Request.Cookies.Clear();
            Session.Clear();
            Session["u_id"] = "";
            Session["user_id_client"] = "";
            Session["userRegistered"] = "";
            Session.RemoveAll();
            Session.Remove("u_id");
            Session.Remove("user_id_client");
            Session.Remove("userRegistered");
            FormsAuthentication.SignOut();

            #endregion
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            try
            { 
                removeAllSessions();
                Response.Redirect("MyAccount.aspx");
            }

            catch (Exception x)
            {


            }

        }

        protected void btnChangePwd_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validation Change Password
                if (txtCurrentPwd.Text == string.Empty)
                {
                    txtCurrentPwd.Focus();
                    txtCurrentPwd.BorderColor = System.Drawing.Color.Red;
                    errorCurrentPwdSpan.Visible = true;
                    TabName.Value = "changePwd";
                    return;
                }
                else
                {
                    errorCurrentPwdSpan.Visible = false;
                    txtCurrentPwd.BorderColor = System.Drawing.Color.LightGray;
                }

                if (txtPwdChange.Text == string.Empty)
                {
                    txtPwdChange.Focus();
                    txtPwdChange.BorderColor = System.Drawing.Color.Red;
                    errorPwdChangeSpan.Visible = true;
                    TabName.Value = "changePwd";
                    return;
                }
                else
                {
                    errorPwdChangeSpan.Visible = false;
                    txtPwdChange.BorderColor = System.Drawing.Color.LightGray;
                }

                if (txtConfirmPwdChange.Text == string.Empty)
                {
                    txtConfirmPwdChange.Focus();
                    txtConfirmPwdChange.BorderColor = System.Drawing.Color.Red;
                    errorConfirmPwdChangeSpan.Visible = true;
                    TabName.Value = "changePwd";
                    return;
                }
                else
                {
                    errorConfirmPwdChangeSpan.Visible = false;
                    txtConfirmPwdChange.BorderColor = System.Drawing.Color.LightGray;
                }

                #endregion

                #region Code To Change Password
                var loginData = _iUserLoginRepository.SelectAll().Where(x => x.password == txtCurrentPwd.Text.Trim().ToString()).FirstOrDefault();

                if (loginData != null)
                {
                    loginData.password = txtPwdChange.Text.Trim().ToString();

                    _iUserLoginRepository.Update(loginData);
                }

                removeAllSessions();
                Response.Redirect("MyAccount.aspx");

                #endregion
            }
            catch (Exception x)
            {

            }
        }

        protected void btnWrongOrderNumber_Click(object sender, EventArgs e)
        {
            Response.Redirect("MyAccount.aspx");
        }

        protected void btnTrackOrder_Click(object sender, EventArgs e)
        {
            try
            {
                #region validation

                passedUserId = Convert.ToInt32(Session["user_id_client"]);

                if (txtEnterOrderNumber.Text == string.Empty)
                {
                    txtEnterOrderNumber.Focus();
                    txtEnterOrderNumber.BorderColor = System.Drawing.Color.Red;
                    errorOrderNumberTrackerSpan.Visible = true;
                    lblOrderNuError.Text = "Enter Order Number*.";

                    TabName.Value = "trackOrder";
                    return;
                }
                else
                {
                    errorOrderNumberTrackerSpan.Visible = false;
                    txtEnterOrderNumber.BorderColor = System.Drawing.Color.LightGray;
                }
                if (txtBillingEmail.Text == string.Empty)
                {
                    txtBillingEmail.Focus();
                    txtBillingEmail.BorderColor = System.Drawing.Color.Red;
                    errorBillingEmalSpan.Visible = true;
                    TabName.Value = "trackOrder";
                    return;
                }
                else
                {
                    errorBillingEmalSpan.Visible = false;
                    txtBillingEmail.BorderColor = System.Drawing.Color.LightGray;
                }
                var checkEmail = _iUserMasterRepository.SelectAll().Where(x => x.email == txtBillingEmail.Text.Trim().ToString()).FirstOrDefault();
                var userMail = _iUserMasterRepository.SelectAll().Where(x => x.user_id == passedUserId).FirstOrDefault();
                 
                if (checkEmail.email != userMail.email)
                {
                    txtBillingEmail.Focus();
                    txtBillingEmail.BorderColor = System.Drawing.Color.Red;
                    errorBillingEmalSpan.Visible = true;
                    TabName.Value = "trackOrder";
                    return;
                }
                else
                {
                    long orderNum = Convert.ToInt32(txtEnterOrderNumber.Text.Trim().ToString());
                    var dataToTrackOrder = _iOrderMasterRepository.SelectAll().Where(x => x.order_id == orderNum && x.order_status != 5).FirstOrDefault();

                    if (dataToTrackOrder == null)
                    {
                        txtEnterOrderNumber.Focus();
                        txtEnterOrderNumber.BorderColor = System.Drawing.Color.Red;
                        errorOrderNumberTrackerSpan.Visible = true;
                        lblOrderNuError.Text = "Invalid Order Number or Order has been canceled.Enter Valid order number";
                        return;
                    }
                    else
                    { 
                        enterOrderNumberTrackingDiv.Visible = false;
                        TrackingOrderDetails.Visible = true;
                        lblOrderNumberTracking.Text = "# " + dataToTrackOrder.order_id;

                        DateTime sData = Convert.ToDateTime(dataToTrackOrder.order_datetime).Date;
                        DateTime eData = sData.AddDays(3);

                        lblExpectedDate.Text ="Will be delivered by <span style='color:orange'>("+ eData.ToString("dd-MMM-yyyy") + ")</span>";

                        if (dataToTrackOrder.order_status == 0)
                        {
                            // 0:Pending Payment
                            // Disable tracking and only show status

                            divConfirm.Attributes.Add("class", "dispatch");
                            divPackedAndDispatch.Attributes.Add("class", "dispatch");
                            divDelivery.Attributes.Add("class", "dispatch");
                            divDelivered.Attributes.Add("class", "dispatch");


                            lblOrderTrackingStatus.Text = "Pending Payment.";

                        }
                        else if (dataToTrackOrder.order_status == 1)
                        {
                            //1:Ordered
                            divConfirm.Attributes.Add("class", "process");
                            divPackedAndDispatch.Attributes.Add("class", "dispatch");
                            divDelivery.Attributes.Add("class", "dispatch");
                            divDelivered.Attributes.Add("class", "dispatch");

                            lblOrderTrackingStatus.Text = "Order Confirmed.";
                        }
                        else if (dataToTrackOrder.order_status == 2)
                        {
                            // 2:Packed And Dispached 
                            divConfirm.Attributes.Add("class", "process");
                            divPackedAndDispatch.Attributes.Add("class", "process");
                            divDelivery.Attributes.Add("class", "dispatch");
                            divDelivered.Attributes.Add("class", "dispatch");

                            lblOrderTrackingStatus.Text = "Packed And Dispached.";
                        }
                        else if (dataToTrackOrder.order_status == 3)
                        {
                            //3:Out For Delivery
                            divConfirm.Attributes.Add("class", "process");
                            divPackedAndDispatch.Attributes.Add("class", "process");
                            divDelivery.Attributes.Add("class", "process");
                            divDelivered.Attributes.Add("class", "dispatch");

                            lblOrderTrackingStatus.Text = "Out For Delivery";
                        }
                        else if (dataToTrackOrder.order_status == 4)
                        {
                            //4:Delivered
                            divConfirm.Attributes.Add("class", "process");
                            divPackedAndDispatch.Attributes.Add("class", "process");
                            divDelivery.Attributes.Add("class", "process");
                            divDelivered.Attributes.Add("class", "process");

                            lblOrderTrackingStatus.Text = "Delivered";
                            lblOrderTrackingStatus.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            //5:Canceled

                            shipmentDiv.Visible = false;
                            lblOrderTrackingStatus.Text = "Canceled";
                            lblOrderTrackingStatus.ForeColor = System.Drawing.Color.Red;
                        }

                        TabName.Value = "trackOrder";
                        //Response.Redirect("MyAccount.aspx");
                    }
                }
                #endregion
            }
            catch (Exception x)
            {

            }
        }

        protected void btnResetPassword_Click(object sender, EventArgs e)
        {

        }

        protected void btnRecoverPassword_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtEmailRecover.Text == string.Empty)
                {
                    //logThis.Visible = false;
                    //recoverPWDThis.Visible = true;
                    //txtEmailRecover.Focus();
                    //txtEmailRecover.BorderColor = System.Drawing.Color.Red;
                    //errorEmailRecoverSpan.Visible = true;


                    errorDiv.Visible = true;
                    lblError.Text = "Enter Emal Address to recover the password";
                    return;
                }
                else
                {
                    int randomPwdCode;

                    MailClass mailForPass = new MailClass();

                    var lastCode = _iPasswordRecoveryRepository.SelectAll().OrderByDescending(x => x.Id).FirstOrDefault();

                    if (lastCode == null)
                    {
                        randomPwdCode = 21;
                    }
                    else
                    {
                        randomPwdCode = Convert.ToInt32(lastCode.conf_code) + 1;
                    }

                    var em = txtEmailRecover.Text.Trim().ToString();

                    var checkMail = _iUserMasterRepository.SelectAll().Where(x => x.email == em).FirstOrDefault();
                    if (checkMail == null)
                    {
                        errorDiv.Visible = true;

                        lblError.Text = "Invalid Email Address. Enter Valid Email Address To Recover Your Password";

                        return;
                    }
                    else
                    {
                        errorDiv.Visible = false;
                        txtEmailRecover.BorderColor = System.Drawing.Color.LightGray;
                        errorEmailRecoverSpan.Visible = false;

                        var sub = "Password Recover Mail";
                        var lnk = "http://pateltea.co.in/CS/RecoverPassword?pwdRecovery=" + randomPwdCode + "&email=" + txtEmailRecover.Text.Trim().ToString();
                        //var lnk = "http://pateltea.co.in/CS/MyAccount";
                        string body = this.PopulateBody(lnk);

                        mailForPass.sendMails(em, sub, body, true);

                        //Save the code in the PwdRecovery table

                        pwd_Recovery modelPwd = new pwd_Recovery();
                        modelPwd.email_add = txtEmailRecover.Text.Trim().ToString();
                        modelPwd.conf_code = randomPwdCode.ToString();
                        modelPwd.cDate = DateTime.Now.ToString();

                        _iPasswordRecoveryRepository.Add(modelPwd);

                        Response.Redirect("MyAccount.aspx");
                    }
                }
            }
            catch (Exception c)
            {

            }
        }


        private string PopulateBody(string resetLnk)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("ResetPasswordEmailTemplate.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{{resetPasswordLink}}", resetLnk);
            return body;
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validation Register User

                if (txtEmailRegister.Text == string.Empty)
                {
                    txtEmailRegister.Focus();
                    txtEmailRegister.BorderColor = System.Drawing.Color.Red;
                    errorEmailRegisterSpan.Visible = true;

                    return;
                }
                else
                {
                    errorEmailRegisterSpan.Visible = false;
                    txtEmailRegister.BorderColor = System.Drawing.Color.LightGray;
                }

                if (txtPwdRegister.Text == string.Empty)
                {
                    txtPwdRegister.Focus();
                    txtPwdRegister.BorderColor = System.Drawing.Color.Red;
                    errorPwdRegisterspan.Visible = true;
                    return;
                }
                else
                {
                    errorPwdRegisterspan.Visible = false;
                    txtPwdRegister.BorderColor = System.Drawing.Color.LightGray;
                }

                if (txtConfirmPwdRegister.Text == string.Empty)
                {
                    txtConfirmPwdRegister.Focus();
                    txtConfirmPwdRegister.BorderColor = System.Drawing.Color.Red;
                    errorConfirmPwdRegisterSpan.Visible = true;
                    return;
                }
                else
                {
                    errorConfirmPwdRegisterSpan.Visible = false;
                    txtConfirmPwdRegister.BorderColor = System.Drawing.Color.LightGray;
                }
                #endregion

                #region Register User To Db Code
                var checkEmail = _iUserMasterRepository.SelectAll().Where(x => x.email == txtEmailRegister.Text.Trim().ToString()).FirstOrDefault();


                if (checkEmail != null)
                {
                    successDiv.Visible = false;
                    errorDiv.Visible = true;
                    lblError.Text = "Email Already Exists. Enter Different Email Address";
                    return;
                }
                else
                {
                    user_master modeUserMaster = new user_master();
                    modeUserMaster.email = txtEmailRegister.Text.Trim().ToString();
                    modeUserMaster.cdate = DateTime.Now;

                    _iUserMasterRepository.Add(modeUserMaster);

                    var userMasterId = _iUserMasterRepository.SelectAll().OrderByDescending(x => x.user_id).FirstOrDefault().user_id;

                    login_master modelLoginMaster = new login_master();
                    modelLoginMaster.user_id = userMasterId;
                    modelLoginMaster.username = txtEmailRegister.Text.Trim().ToString();
                    modelLoginMaster.password = txtPwdRegister.Text.Trim().ToString();
                    modelLoginMaster.type = 1;
                    modelLoginMaster.status = 1;
                    modelLoginMaster.cdate = DateTime.Now;
                    _iUserLoginRepository.Add(modelLoginMaster);


                 

                    Session.Add("userRegistered", 1);

                    Response.Redirect("MyAccount.aspx");
                }
                #endregion

            }
            catch (Exception x)
            {
                Response.Write("<script> alert('" + x.ToString() + "') </script>");
            }
        }

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

                GetIPAddressClass ipAddressCurrentDevice = new GetIPAddressClass();

                var data = _iUserLoginRepository.SelectByUserNamePwd(txtEmailUsername.Text.Trim().ToString(), txtPasswordLogin.Text.Trim().ToString());

                if (data != null)
                {

                    if (data.type == 1)
                    {
                        if (data.status == 1)
                        {
                            Session.Add("user_id_client", data.user_id);

                            var ipAddCurr = ipAddressCurrentDevice.GetIP();

                            var cartData = _iCartRepository.SelectAll().Where(x => x.ipAdd == ipAddCurr).FirstOrDefault();
                            if (cartData != null)
                            {
                                cartData.user_id = data.user_id;
                                cartData.udate = DateTime.Now;
                                _iCartRepository.Update(cartData);
                            }


                            Response.Redirect("MyAccount.aspx");
                        }
                        else
                        {
                            successDiv.Visible = false;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //if (this.IsPostBack)
                //{
                //    TabName.Value = Request.Form[TabName.UniqueID];
                //}

                passedUserId = Convert.ToInt32(Session["user_id_client"]);
                registeredUser = Convert.ToInt32(Session["userRegistered"]);
                passedOrderId = Convert.ToInt32(Request.QueryString["order"]);

                var codessss = Request.QueryString["codeNull"];

                if (codessss != null)
                {
                    if (codessss == "2")
                    {

                        errorDiv.Visible = true;
                        orderDetailsDiv.Visible = false;
                        ordersDiv.Visible = false;
                        wrongOrderNumberDiv.Visible = false;
                        noOrderExists.Visible = false;
                        dataRow.Visible = false;
                        lblError.Text = "Password recovery link has been expired.Click on Forget Password to generate new link.";
                        return;
                    }
                }

                    if (!IsPostBack)
                {

                    if (registeredUser == 1)
                    {
                        errorDiv.Visible = false;
                        successDiv.Visible = true;
                        lblSuccess.Text = "Registration Successfull. Login here with registered credentials";
                        Session["userRegistered"] = 0;
                    }

                    if (passedUserId > 0)
                    {


                        var billingAddData = _iUserMasterRepository.SelectByUserID(passedUserId).FirstOrDefault();
                        var shippingAddData = _iShippingAddressRepository.SelectAll().Where(x => x.user_id == passedUserId).FirstOrDefault();

                        if (passedOrderId > 0)
                        {
                            loginRow.Visible = false;
                            btnWrongOrderNumber.Visible = false;
                            orderDetailsDiv.Visible = true;
                            ordersDiv.Visible = false;

                            #region OrderDetails
                            var orderMasterDataById = _iOrderMasterRepository.SelectById(passedOrderId);
                            var orderDataById = _iOrderMasterDetailsRepository.SelectAll().Where(x => x.order_id == passedOrderId).ToList();

                            if (orderMasterDataById == null)
                            {
                                btnWrongOrderNumber.Visible = true;
                                dataRow.Visible = false;
                                orderDetailsDiv.Visible = false;

                                errorDiv.Visible = true;
                                lblError.Text = "Invalid order number";
                                ancError.Visible = true;
                            }
                            else
                            {
                                noOrderExists.Visible = false;

                                html = new StringBuilder();

                                html.Append("<tr>");
                                html.Append("<td>"); html.Append("<label>Order Number: </label> <b><lable style='font-size:20px'> #" + passedOrderId + "</label></b>"); html.Append("</td>");
                                html.Append("<td>"); html.Append("</td>");


                                if (orderMasterDataById.order_status == 0)
                                {
                                    // 0:Pending Payment
                                    html.Append("<td style='text-align:right;color:red;vertical-align: middle;'>"); html.Append("<label>Order Status: </label> <b><lable style='font-size:15px'>Pending Payment</label></b>"); html.Append("</td>");
                                }
                                else if (orderMasterDataById.order_status == 1)
                                {
                                    //1:Ordered
                                    html.Append("<td style='text-align:right;vertical-align: middle;'>"); html.Append("<label>Order Status: </label> <b><lable style='font-size:15px'> 	Order Confirmed.</label></b>"); html.Append("</td>");
                                }
                                else if (orderMasterDataById.order_status == 2)
                                {
                                    // 2:Packed And Dispached 
                                    html.Append("<td style='text-align:right;vertical-align: middle;'>"); html.Append("<label>Order Status: </label> <b><lable style='font-size:15px'>Packed And Dispached </label></b>"); html.Append("</td>");
                                }
                                else if (orderMasterDataById.order_status == 3)
                                {
                                    //3:Out For Delivery
                                    html.Append("<td style='text-align:right;vertical-align: middle;'>"); html.Append("<label>Order Status: </label> <b><lable style='font-size:15px'>Out For Delivery </label></b>"); html.Append("</td>");
                                }
                                else if (orderMasterDataById.order_status == 4)
                                {
                                    //4:Delivered
                                    html.Append("<td style='color:Green;vertical-align: middle;'>"); html.Append("Delivered"); html.Append("</td>");
                                }
                                else
                                {
                                    //5:Canceled
                                    html.Append("<td style='text-align:right;color:red;vertical-align: middle;'>"); html.Append("<label>Order Status: </label> <b><lable style='font-size:15px'>Canceled</label></b>"); html.Append("</td>");
                                }


                                html.Append("</tr>");
                                placeHolderOrderStatus.Controls.Add(new Literal { Text = html.ToString() });

                                // lblOrderNumber.Text = " #" + passedOrderId;
                                foreach (var item in orderDataById)
                                {
                                    html = new StringBuilder();
                                    string url = "ProductDetails.aspx?idp=" + item.pid;
                                    var imageNameProduct = _iProductMasterRepository.SelectById(item.pid).photo;

                                    string imagename = "../AdminSide/AdminSideData/ProductsImages/" + imageNameProduct.ToString();

                                     var productMasterData = _iProductMasterRepository.SelectById(item.pid);  
                                    string productWeight = Convert.ToInt32(_iProductMasterRepository.SelectById(item.pid).weight) + " " + _iProductMasterRepository.SelectById(item.pid).unit;
                                    html.Append("<tr>");
                                    // html.Append("<td>"); html.Append("<img style='width:100px' src='" + imagename + "' />"); html.Append("</td>");
                                    html.Append("<td style='width:320px'>"); html.Append("<a href='" + url + "'>" + productMasterData.pname + " (" + productWeight + ") </a>"); html.Append("</td>");
                                    html.Append("<td style='font-size:16px;width:70px'>"); html.Append("<label>x " + item.qty + "</label>"); html.Append("</td>");
                                    html.Append("<td style='font-size:17px'>"); html.Append("<b>&#8377; " + item.amount + "</b>"); html.Append("</td>");
                                    html.Append("</tr>");

                                    subtotal += item.amount;
                                    tax += (Convert.ToDecimal(item.amount) * Convert.ToInt32(productMasterData.taxPer)) / (100 + Convert.ToInt32(productMasterData.taxPer));

                                    placeHolderProducts.Controls.Add(new Literal { Text = html.ToString() });
                                }

                              //  tax = (subtotal * 5) / 105;

                                totalAmt = subtotal;

                                html = new StringBuilder();

                                html.Append("<tr>");
                                html.Append("<td>"); html.Append("<label>Subtotal: </label>"); html.Append("</td>");
                                html.Append("<td>"); html.Append("</td>");
                                html.Append("<td>"); html.Append("<b><lable style='font-size:17px'> &#8377; " + subtotal + "</label></b>"); html.Append("</td>");
                                html.Append("</tr>");


                                html.Append("<tr>");
                                html.Append("<td>"); html.Append("<label>Shipping: </label>"); html.Append("</td>");
                                html.Append("<td>"); html.Append("</td>");
                                html.Append("<td>"); html.Append("<label>Free Shipping</label>"); html.Append("</td>");
                                html.Append("</tr>");


                                html.Append("<tr>");
                                html.Append("<td>"); html.Append("<label>Payment Mode: </label>"); html.Append("</td>");
                                html.Append("<td>"); html.Append("</td>");
                                html.Append("<td>"); html.Append("<label> PayUMoney </label>"); html.Append("</td>");
                                html.Append("</tr>");


                                html.Append("<tr>");
                                html.Append("<td>"); html.Append("<label>Total: </label>"); html.Append("</td>");

                                DecimalFormat dcFormat = new DecimalFormat();

                                html.Append("<td>"); html.Append("</td>");
                                html.Append("<td>"); html.Append("<b><lable style='font-size:17px'> &#8377; " + subtotal + "</label></b> (includes <b>&#8377; " + dcFormat.DoFormat(tax) + "</b> Tax)"); html.Append("</td>");
                                html.Append("</tr>");

                                placeHolderProductsDetails.Controls.Add(new Literal { Text = html.ToString() });

                                #endregion

                                #region customerDetails

                                if (billingAddData.addLine1 != null)
                                {
                                    html = new StringBuilder();
                                    shipAdd.Visible = true;
                                    ancBillingAdd.Visible = false;
                                    ancBillingAddEdit.Visible = true;

                                    lblEmail.Text = billingAddData.email.Trim().ToString();
                                    lblPhone.Text = billingAddData.mobile.ToString();

                                    if (billingAddData.company_name != null)
                                    {
                                        html.Append("<label>" + billingAddData.company_name + "</label>");
                                    }
                                    html.Append("<br/>");
                                    html.Append("<label>" + billingAddData.fname + " " + billingAddData.lname + "</label>");
                                    html.Append("<br/>");
                                    html.Append("<label>" + billingAddData.addLine1 + "</label>");
                                    html.Append("<br/>");
                                    if (billingAddData.addLine2 != null)
                                    {
                                        html.Append("<label>" + billingAddData.addLine2 + "</label>");
                                        html.Append("<br/>");
                                    }
                                    html.Append("<label>" + billingAddData.city + " - " + billingAddData.pincode + "</label>");
                                    html.Append("<br/>");

                                    html.Append("<label>" + billingAddData.state + ", India</label>");

                                    placeHolderBillingAddress.Controls.Add(new Literal { Text = html.ToString() });

                                    #endregion

                                    #region Shipping Address

                                    if (shippingAddData == null)
                                    {
                                        html = new StringBuilder();
                                        if (billingAddData.company_name != null)
                                        {
                                            html.Append("<label>" + billingAddData.company_name + "</label><br/>");
                                        }
                                        html.Append("<label>" + billingAddData.fname + " " + billingAddData.lname + "</label><br/>");
                                        html.Append("<label>" + billingAddData.addLine1 + "</label><br/>");
                                        if (billingAddData.addLine2 != null)
                                        {
                                            html.Append("<label>" + billingAddData.addLine2 + "</label>");
                                            html.Append("<br/>");
                                        }
                                        html.Append("<label>" + billingAddData.city + " - " + billingAddData.pincode + "</label><br/>");
                                        html.Append("<label>" + "Mob.: " + billingAddData.mobile + "</label><br/>");
                                        html.Append("<label>" + billingAddData.state + ", India</label>");

                                        placeHolderShippingAddress.Controls.Add(new Literal { Text = html.ToString() });

                                    }
                                    else
                                    {
                                        html = new StringBuilder();
                                        if (shippingAddData.companyName != null)

                                        { html.Append("<label>" + shippingAddData.companyName + "</label><br/>"); }

                                        html.Append("<label>" + shippingAddData.fname + " " + shippingAddData.lname + "</label><br/>");
                                        html.Append("<label>" + shippingAddData.line1 + "</label><br/>");
                                        if (shippingAddData.line2 != null)
                                        {
                                            html.Append("<label>" + shippingAddData.line2 + "</label><br/>");
                                        }
                                        html.Append("<label>" + shippingAddData.city + " - " + shippingAddData.pincode + "</label><br/>");
                                        html.Append("<label>" + "Mob.: " + shippingAddData.mobile + "</label><br/>");
                                        html.Append("<label>" + shippingAddData.state + ", India</label>");

                                        placeHolderShippingAddress.Controls.Add(new Literal { Text = html.ToString() });


                                    }
                                    #endregion

                                }
                            }
                            //----------------------------------Billing And Shipping Address Code---------------------------------

                            billingAndShippingAddress(billingAddData, shippingAddData);


                        }
                        else
                        {
                            loginRow.Visible = false;
                            dataRow.Visible = true;
                            successDiv.Visible = false;
                            errorDiv.Visible = false;
                            //Address Details
                            // txtEmailAddress.Enabled = false;

                            //----------------------------------Billing And Shipping Address Code---------------------------------

                            billingAndShippingAddress(billingAddData, shippingAddData);

                            //----------------------------------Order Code---------------------------------

                            var checkOrder = _iOrderMasterRepository.SelectAll().Where(x => x.user_id == passedUserId).OrderByDescending(x => x.order_id).ToList();

                            if (checkOrder.Count == 0)
                            {
                                ordersDiv.Visible = false;
                                orderDetailsDiv.Visible = false;
                                wrongOrderNumberDiv.Visible = false;

                                noOrderExists.Visible = true;
                            }
                            else
                            {
                                orderDetailsDiv.Visible = false;
                                wrongOrderNumberDiv.Visible = false;
                                noOrderExists.Visible = false;


                                foreach (var item in checkOrder)
                                {
                                    html = new StringBuilder();
                                    var hrefOrderNo = "MyAccount.aspx?order=" + item.order_id;

                                    html.Append("<tr>");
                                    html.Append("<td>"); html.Append("<a href='" + hrefOrderNo + "'> #" + item.order_id + "</a>"); html.Append("</td>");
                                    html.Append("<td>"); html.Append(Convert.ToDateTime(item.order_datetime).ToString("dd-MM-yyyy")); html.Append("</td>");

                                    /*  
                                     0:Pending Payment
                                     1:Ordered
                                     2:Packed And Dispached 
                                     3:Out For Delivery
                                     4:Delivered
                                     5:Canceled
                                     */

                                    if (item.order_status == 0)
                                    {
                                        // 0:Pending Payment
                                        html.Append("<td style='color:Red'>"); html.Append("Pending Payment"); html.Append("</td>");
                                    }
                                    else if (item.order_status == 1)
                                    {
                                        //1:Ordered
                                        html.Append("<td>"); html.Append("Order Confirmed"); html.Append("</td>");
                                    }
                                    else if (item.order_status == 2)
                                    {
                                        // 2:Packed And Dispached 
                                        html.Append("<td>"); html.Append("Packed And Dispached"); html.Append("</td>");
                                    }
                                    else if (item.order_status == 3)
                                    {
                                        //3:Out For Delivery
                                        html.Append("<td>"); html.Append("Out For Delivery"); html.Append("</td>");
                                    }
                                    else if (item.order_status == 4)
                                    {
                                        //4:Delivered
                                        html.Append("<td style='color:Green'>"); html.Append("Delivered"); html.Append("</td>");
                                    }
                                    else
                                    {
                                        //5:Canceled
                                        html.Append("<td style='color:Red'>"); html.Append("Canceled"); html.Append("</td>");
                                    }
                                    int? totalItems = 0;
                                    var orderQty = _iOrderMasterDetailsRepository.SelectAll().Where(x => x.order_id == item.order_id).ToList();
                                    foreach (var itemOrderDetails in orderQty)
                                    {
                                        totalItems += itemOrderDetails.qty;
                                    }

                                    html.Append("<td>"); html.Append(totalItems); html.Append("</td>");
                                    html.Append("<td>"); html.Append("&#8377; " + item.gtotal + " /-"); html.Append("</td>");

                                    //Actions

                                    html.Append("<td>");

                                    //var hrefViewOrder= "MyAccount.aspx?order="+

                                    html.Append("<a href='" + hrefOrderNo + "' class='fa fa-eye'> View </a>");

                                    var cancelOrderUrl = "CancelOrder.aspx?cancelOrder=" + item.order_id;
                                    if (item.order_status == 0)
                                        html.Append(" | <a href='Checkout.aspx' class='fa fa-money btn btn-success'> Make Payment</a>");

                                    if (item.order_status == 0)
                                        html.Append(" | <a href='" + cancelOrderUrl + "' class='fa fa-remove btn btn-danger'> Cancel Order </a>");


                                    html.Append("</td>");
                                    html.Append("</tr>");

                                    PlaceHolderOrderTable.Controls.Add(new Literal { Text = html.ToString() });
                                }
                            }

                        }
                    }
                    else
                    {

                        loginRow.Visible = true;
                        dataRow.Visible = false;
                        //   Response.Redirect("MyAccount.aspx");
                    }
                }
            }
            catch (Exception x)
            {

            }

        }

        private void billingAndShippingAddress(user_master billingAddData, shipping_address_master shippingAddData)
        {
            #region Billing And Shipping Address Code

            #region Billing Address

            html = new StringBuilder();

            if (billingAddData.addLine1 != null)
            {
                shipAdd.Visible = true;
                ancBillingAdd.Visible = false;
                ancBillingAddEdit.Visible = true;

                if (billingAddData.company_name != null)
                {
                    html.Append("<label>" + billingAddData.company_name + "</label>");
                }
                html.Append("<br/>");
                html.Append("<label>" + billingAddData.fname + " " + billingAddData.lname + "</label>");
                html.Append("<br/>");
                html.Append("<label>" + billingAddData.addLine1 + "</label>");
                html.Append("<br/>");
                if (billingAddData.addLine2 != null)
                {
                    html.Append("<label>" + billingAddData.addLine2 + "</label>");
                    html.Append("<br/>");
                }
                html.Append("<label>" + billingAddData.city + " - " + billingAddData.pincode + "</label>");
                html.Append("<br/>");
                html.Append("<label>" + "Mob.: " + billingAddData.mobile + "</label>");
                html.Append("<br/>");
                html.Append("<label>" + billingAddData.state + ", India</label>");

                placeHolderBillingAdd.Controls.Add(new Literal { Text = html.ToString() });

                txtFirstName.Text = billingAddData.fname.Trim().ToString();
                txtLastName.Text = billingAddData.lname.Trim().ToString();
                txtCompanyName.Text = billingAddData.company_name.Trim().ToString();
                txtStreetAdd.Text = billingAddData.addLine1.Trim().ToString();
                txtStreetAdd2.Text = billingAddData.addLine2.Trim().ToString();
                txtCity.Text = billingAddData.city.Trim().ToString();
                txtPincode.Text = billingAddData.pincode.Trim().ToString();
                txtMobile.Text = billingAddData.mobile.Trim().ToString();
                #endregion

                #region Shipping Address

                if (shippingAddData == null)
                {
                    html = new StringBuilder();
                    if (billingAddData.company_name != null)
                    {
                        html.Append("<label>" + billingAddData.company_name + "</label><br/>");
                    }
                    html.Append("<label>" + billingAddData.fname + " " + billingAddData.lname + "</label><br/>");
                    html.Append("<label>" + billingAddData.addLine1 + "</label><br/>");
                    if (billingAddData.addLine2 != null)
                    {
                        html.Append("<label>" + billingAddData.addLine2 + "</label>");
                        html.Append("<br/>");
                    }
                    html.Append("<label>" + billingAddData.city + " - " + billingAddData.pincode + "</label><br/>");
                    html.Append("<label>" + "Mob.: " + billingAddData.mobile + "</label><br/>");
                    html.Append("<label>" + billingAddData.state + ", India</label>");

                    placeHolderShippingAdd.Controls.Add(new Literal { Text = html.ToString() });

                    txtFirstNameShipping.Text = billingAddData.fname.Trim().ToString();
                    txtLastNameShipping.Text = billingAddData.lname.Trim().ToString(); ;
                    txtCompanyNameShipping.Text = billingAddData.company_name.Trim().ToString();
                    txtStreetAddressShipping.Text = billingAddData.addLine1.Trim().ToString();
                    txtStreedAddressShipping2.Text = billingAddData.addLine2.Trim().ToString();
                    txtCityShipping.Text = billingAddData.city.Trim().ToString();
                    txtPincodeShipping.Text = billingAddData.pincode.Trim().ToString();
                    txtMobileShipping.Text = billingAddData.mobile.ToString();

                }
                else
                {
                    html = new StringBuilder();
                    if (shippingAddData.companyName != null)

                    { html.Append("<label>" + shippingAddData.companyName + "</label><br/>"); }

                    html.Append("<label>" + shippingAddData.fname + " " + shippingAddData.lname + "</label><br/>");
                    html.Append("<label>" + shippingAddData.line1 + "</label><br/>");
                    if (shippingAddData.line2 != null)
                    {
                        html.Append("<label>" + shippingAddData.line2 + "</label><br/>");
                    }
                    html.Append("<label>" + shippingAddData.city + " - " + shippingAddData.pincode + "</label><br/>");
                    html.Append("<label>" + "Mob.: " + shippingAddData.mobile + "</label><br/>");
                    html.Append("<label>" + shippingAddData.state + ", India</label>");

                    placeHolderShippingAdd.Controls.Add(new Literal { Text = html.ToString() });

                    txtFirstNameShipping.Text = shippingAddData.fname.Trim().ToString();
                    txtLastNameShipping.Text = shippingAddData.lname.Trim().ToString(); ;
                    txtCompanyNameShipping.Text = shippingAddData.companyName.Trim().ToString();
                    txtStreetAddressShipping.Text = shippingAddData.line1.Trim().ToString();
                    txtStreedAddressShipping2.Text = shippingAddData.line2.Trim().ToString();
                    txtCityShipping.Text = shippingAddData.city.Trim().ToString();
                    txtPincodeShipping.Text = shippingAddData.pincode.Trim().ToString();
                    txtMobileShipping.Text = shippingAddData.mobile.ToString();
                }
                #endregion

            }
            else
            {
                html = new StringBuilder();
                html.Append("<label>No Address Added.</label>");
                placeHolderBillingAdd.Controls.Add(new Literal { Text = html.ToString() });

                // txtEmailAddress.Text = billingAddData.email.Trim().ToString();

                ancBillingAdd.Visible = true;
                ancBillingAddEdit.Visible = false;
                shipAdd.Visible = false;
            }
            #endregion
        }

    }
}