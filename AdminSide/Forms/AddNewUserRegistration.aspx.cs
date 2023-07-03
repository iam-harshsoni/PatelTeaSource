using PatelTeaSource.Model;
using PatelTeaSource.Repository.NewUserRegisterRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class AddNewUserRegistration : System.Web.UI.Page
    {


        public AddNewUserRegistration()
          : this(new NewUserRegisterRepository())
        {
        }

        private INewUserRegisterRepository _iNewUserRegisterRepository;
        public AddNewUserRegistration(NewUserRegisterRepository newUserRegisterRepository)
        {
            _iNewUserRegisterRepository = newUserRegisterRepository;
        }
        int passedId = 0;
        long passedUserId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    passedUserId = Convert.ToInt32(Session["u_id"]);

                    if (passedUserId != 0)
                    {
                        if (Request.QueryString["id"] != null)
                        {
                            passedId = Convert.ToInt32(Request.QueryString["id"].ToString());

                            if (passedId >= 0)
                            {
                                var databyid = _iNewUserRegisterRepository.SelectById(passedId);
                                if (databyid != null)
                                {
                                    txtFullName.Text = databyid.fullName.Trim().ToString();
                                    txtEmail.Text = databyid.emailId.Trim().ToString();

                                    txtUserName.Text = databyid.username.Trim().ToString();

                                    btnSubmit.Text = "Update";
                                }

                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                    }

                }
            }
            catch (Exception x)
            {
                Response.Write("<script>alert('" + x.ToString() + "')</script>");
            }


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text == "Submit")
                {
                    NewUserRegister reg = new NewUserRegister();

                    reg.username = txtUserName.Text.ToString();
                    reg.password = txtPassword.Text.Trim().ToString();
                    reg.fullName = txtFullName.Text.ToString();
                    reg.emailId = txtEmail.Text.ToString();
                    reg.userType = "AdminSide";
                    if (drp_Status.SelectedIndex == 0)
                    {
                        reg.status = 0;
                    }
                    else
                    {
                        reg.status = 1;
                    }


                    reg.role = drp_Role.SelectedItem.Text;
                    _iNewUserRegisterRepository.Add(reg);
                }
                else
                {
                    passedId = Convert.ToInt32(Request.QueryString["id"].ToString());
                    var reg = _iNewUserRegisterRepository.SelectById(passedId);
                    if (reg != null)
                    {

                        reg.username = txtUserName.Text.ToString();
                        reg.password = txtPassword.Text.Trim().ToString();
                        reg.fullName = txtFullName.Text.ToString();
                        reg.emailId = txtEmail.Text.ToString();
                        reg.userType = "AdminSide";
                        if (drp_Status.SelectedIndex == 0)
                        {
                            reg.status = 0;
                        }
                        else
                        {
                            reg.status = 1;
                        }


                        reg.role = drp_Role.SelectedItem.Text;

                        _iNewUserRegisterRepository.Update(reg);
                    }
                }
                Response.Redirect("RegisteredUsers.aspx");
            }
            catch (Exception x)
            {
                Response.Write("<script>alert('" + x.ToString() + "')</script>");
            }

        }
    }
}