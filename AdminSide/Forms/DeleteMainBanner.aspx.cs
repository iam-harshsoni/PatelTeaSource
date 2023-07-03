using PatelTeaSource.Repository.BannerMasterRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class DeleteMainBanner : System.Web.UI.Page
    {
        public DeleteMainBanner()
          : this(new BannerMasterRepository())
        {
        }

        private IBannerMasterRepository _iBannerMasterRepository;
        public DeleteMainBanner(BannerMasterRepository bannerMasterRepository)
        {
            _iBannerMasterRepository = bannerMasterRepository;
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
                        passedId = Convert.ToInt32(Request.QueryString["id"].ToString());

                        if (passedId >= 0)
                        {
                            var databyid = _iBannerMasterRepository.SelectById(passedId);
                            if (databyid != null)
                            {


                                _iBannerMasterRepository.Delete(passedId);
                                Response.Redirect("MainBannerLst.aspx");
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
    }
}