using PatelTeaSource.Repository.DistributerMasterRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class DeleteDistributers : System.Web.UI.Page
    {
        public DeleteDistributers()
          : this(new DistributerMasterRepository())
        {
        }

        private IDistributerMasterRepository _iDistributerMasterRepository;
        public DeleteDistributers(DistributerMasterRepository DistributerMasterRepository)
        {
            _iDistributerMasterRepository = DistributerMasterRepository;

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
                            var databyid = _iDistributerMasterRepository.SelectById(passedId);
                            if (databyid != null)
                            {

                                _iDistributerMasterRepository.Delete(passedId);
                                Response.Redirect("DistributerLst.aspx");
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