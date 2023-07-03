using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PatelTeaSource.Repository.UserMasterRepo;
using PatelTeaSource.Repository.PasswordRecoveryRepo;
using PatelTeaSource.Classes;
using PatelTeaSource.Model;
using PatelTeaSource.Repository.UserLoginRepo;

namespace PatelTeaSource.CS
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        public RecoverPassword()
          : this(new UserMasterRepository(), new UserLoginRepository(), new PasswordRecoveryRepository())
        {
        }


        private IUserMasterRepository _iUserMasterRepository;
        private IUserLoginRepository _iUserLoginRepository; 
        private IPasswordRecoveryRepository _iPasswordRecoveryRepository;

        public RecoverPassword(UserMasterRepository userMasterRepository, UserLoginRepository userLoginRepository, PasswordRecoveryRepository passwordRecoveryRepository)
        {

            _iUserLoginRepository = userLoginRepository;
            _iUserMasterRepository = userMasterRepository;

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
                                Response.Redirect("MyAccount.aspx?codeNull=2");
                                return;
                            }
                            else
                            {

                                //code here

                            }
                        }

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
            try
            {

                if (txtNewPassword.Text == string.Empty)
                {
                    txtNewPassword.Focus();
                    txtNewPassword.BorderColor = System.Drawing.Color.Red;
                    errorNewPasswordSpan.Visible = true;

                    return;
                }
                else
                {
                    errorNewPasswordSpan.Visible = false;
                    txtNewPassword.BorderColor = System.Drawing.Color.LightGray;
                }

                if (txtConfirmPwdReset.Text == string.Empty)
                {
                    txtConfirmPwdReset.Focus();
                    txtConfirmPwdReset.BorderColor = System.Drawing.Color.Red;
                    errorConfirmPwdResetSpan.Visible = true;

                    return;
                }
                else
                {
                    errorConfirmPwdResetSpan.Visible = false;
                    txtConfirmPwdReset.BorderColor = System.Drawing.Color.LightGray;
                }

                if (txtNewPassword.Text != txtConfirmPwdReset.Text)
                {
                    errorDiv.Visible = true;
                    lblError.Text = "Confirm Password Doest Not Matched.";
                    return;
                }
                else
                {
                    var emailPassed = Request.QueryString["email"];
                    var codePassed = Request.QueryString["pwdRecovery"];


                    var getData = _iUserLoginRepository.SelectAll().Where(x => x.username == emailPassed).FirstOrDefault();

                    if (getData != null)
                    {
                        getData.password = txtNewPassword.Text.Trim().ToString();

                        _iUserLoginRepository.Update(getData);


                        var pwdRecoveryData = _iPasswordRecoveryRepository.SelectAll().Where(x => x.email_add == emailPassed && x.conf_code == codePassed).FirstOrDefault();

                        if (pwdRecoveryData != null)
                        {
                            pwdRecoveryData.status = 1;

                            _iPasswordRecoveryRepository.Update(pwdRecoveryData);
                        }

                        Response.Redirect("MyAccount.aspx");
                    }
                    else
                    {
                        Response.Redirect("MyAccount.aspx?codeNull=2");
                    }
                }

            }
            catch (Exception x)
            {

            }
        }
    }
}