using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PatelTeaSource.Model;
using PatelTeaSource.Repository.NewUserRegisterRepo;
using PatelTeaSource.Repository.PasswordRecoveryRepo;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        public RecoverPassword()
          : this(new NewUserRegisterRepository(),new PasswordRecoveryRepository())
        {
        }

        private INewUserRegisterRepository _iNewUserRegisterRepository;
        private IPasswordRecoveryRepository _iPasswordRecoveryRepository;
        public RecoverPassword(NewUserRegisterRepository newUserRegisterRepository, PasswordRecoveryRepository passwordRecoveryRepository)
        {
            _iNewUserRegisterRepository = newUserRegisterRepository;
            _iPasswordRecoveryRepository = passwordRecoveryRepository;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
             
                if (!IsPostBack)
                {
                    var emailPassed = Request.QueryString["email"];
                    var codePassed = Request.QueryString["pwdRecovery"];

                    #region recover forget password
                    if (emailPassed != null && codePassed != null)
                    {

                        var checkStatusOfRecovery = _iPasswordRecoveryRepository.SelectAll().Where(x => x.email_add == emailPassed && x.conf_code == codePassed).FirstOrDefault();

                        if (checkStatusOfRecovery != null)
                        {
                            if (checkStatusOfRecovery.status == 1)
                            {
                                Response.Redirect("Login.aspx?codeNull=2");
                                return;
                            }
                            else
                            {

                                //code here

                            }
                        }

                    }
                    #endregion
                }
            }
            catch (Exception c)
            {

            }
        }

        protected void btnResetpassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    errorDiv.Visible = true;
                    lblError.Text = "Confirm Password Doest Not Matched.";
                    return;
                }
                else
                {
                    var emailPassed = Request.QueryString["email"];
                    var codePassed = Request.QueryString["pwdRecovery"];


                    var getData = _iNewUserRegisterRepository.SelectAll().Where(x => x.emailId == emailPassed).FirstOrDefault();

                    if (getData != null)
                    {
                        getData.password = txtNewPassword.Text.Trim().ToString();

                        _iNewUserRegisterRepository.Update(getData);


                        var pwdRecoveryData = _iPasswordRecoveryRepository.SelectAll().Where(x => x.email_add == emailPassed && x.conf_code == codePassed).FirstOrDefault();

                        if (pwdRecoveryData != null)
                        {
                            pwdRecoveryData.status = 1;

                            _iPasswordRecoveryRepository.Update(pwdRecoveryData);
                        }

                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        Response.Redirect("MyAccount.aspx?codeNull=2");
                    }
                }
            }
            catch(Exception x)
            {

            }
        }
    }
}