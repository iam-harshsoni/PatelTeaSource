using PatelTeaSource.Model;
using PatelTeaSource.Repository.NewUserRegisterRepo;
using PatelTeaSource.Repository.PasswordRecoveryRepo;
using PatelTeaSource.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        public ForgetPassword()
          : this(new NewUserRegisterRepository(),new PasswordRecoveryRepository())
        {
        }

        private INewUserRegisterRepository _iNewUserRegisterRepository;
        private IPasswordRecoveryRepository _iPasswordRecoveryRepository;
        public ForgetPassword(NewUserRegisterRepository newUserRegisterRepository,PasswordRecoveryRepository passwordRecoveryRepository)
        {
            _iNewUserRegisterRepository = newUserRegisterRepository;
            _iPasswordRecoveryRepository = passwordRecoveryRepository;
        }
        int passedId = 0;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRecoverpassword_Click(object sender, EventArgs e)
        {
           // try
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

                var em = txtEmail.Text.Trim().ToString();

                var checkMail = _iNewUserRegisterRepository.SelectAll().Where(x => x.emailId == em).FirstOrDefault();
                if (checkMail == null)
                {
                    errorDiv.Visible = true;

                    lblError.Text = "Invalid Email Address. Enter Valid Email Address To Recover Your Password";

                    return;
                }
                else
                {
                    errorDiv.Visible = false;

                    var sub = "Password Recover Mail";
                    var lnk = "http://pateltea.co.in/AdminSide/Forms/RecoverPassword.aspx?pwdRecovery=" + randomPwdCode + "&email=" + txtEmail.Text.Trim().ToString();
                    //var lnk = "http://pateltea.co.in/01/MyAccount";
                    string body = this.PopulateBody(lnk);

                    mailForPass.sendMails(em, sub, body, true);

                    //Save the code in the PwdRecovery table

                    pwd_Recovery modelPwd = new pwd_Recovery();
                    modelPwd.email_add = txtEmail.Text.Trim().ToString();
                    modelPwd.conf_code = randomPwdCode.ToString();
                    modelPwd.cDate = DateTime.Now.ToString();

                    _iPasswordRecoveryRepository.Add(modelPwd);

                    Response.Redirect("Login.aspx");
                }

                }
          //  catch(Exception x)
            {

            }
        }
        private string PopulateBody(string resetLnk)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Server.MapPath("~/01/ResetPasswordEmailTemplate.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{{resetPasswordLink}}", resetLnk);
            return body;
        }
    }
}