using PatelTeaSource.Repository.NewUserRegisterRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class Login : System.Web.UI.Page
    {

        public Login()
          : this(new NewUserRegisterRepository())
        {
        }

        private INewUserRegisterRepository _iNewUserRegisterRepository;
        public Login(NewUserRegisterRepository newUserRegisterRepository)
        {
            _iNewUserRegisterRepository = newUserRegisterRepository;
        }
        int passedId = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var codessss = Request.QueryString["codeNull"];

                    if (codessss != null)
                    {
                        if (codessss == "2")
                        { 
                            errorDiv.Visible = true; 
                            lblError.Text = "Password recovery link has been expired.Click on Forget Password to generate new link.";
                            return;
                        }
                    }
                }
            }
            catch(Exception x)
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var data = _iNewUserRegisterRepository.SelectByUserNamePwd(txtUserName.Text.Trim().ToString(), txtPassword.Text.Trim().ToString());

                if (data != null)
                {
                    var type = _iNewUserRegisterRepository.SelectById(data.userId);

                    if (type.userType == "AdminSide")
                    {
                        if (type.status == 1)
                        { 
                                Session.Add("u_id", data.userId);

                                Response.Redirect("Dashboard.aspx"); 
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
            catch(Exception x)
            {
                Response.Write("<script>alert('" + x.ToString() + "')</script>");
            }
        }
    }
}