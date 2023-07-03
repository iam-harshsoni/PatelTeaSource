using PatelTeaSource.Repository.NewUserRegisterRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        public AdminMaster()
          : this(new NewUserRegisterRepository())
        {
        }

        private INewUserRegisterRepository _iNewUserRegisterRepository;
        public AdminMaster(NewUserRegisterRepository newUserRegisterRepository)
        {
            _iNewUserRegisterRepository = newUserRegisterRepository;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["u_id"] != null)
            {
                var passedId = Convert.ToInt32(Session["u_id"]);
                var userNames = _iNewUserRegisterRepository.SelectById(passedId).username;

                lblUname.Text = userNames;
            }
            else
            {
                Response.Redirect("Login.aspx", true);
            }
        }
    }
}