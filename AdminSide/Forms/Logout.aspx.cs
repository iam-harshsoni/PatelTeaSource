using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session.Abandon();
                Request.Cookies.Clear();
                Session.Clear();
                Session["u_id"] = "";
                Session.RemoveAll();
                Session.Remove("u_id");
                FormsAuthentication.SignOut();

                Response.Redirect("Login.aspx", true);


            }

            catch (Exception x)
            {


            }
        }
    }
}