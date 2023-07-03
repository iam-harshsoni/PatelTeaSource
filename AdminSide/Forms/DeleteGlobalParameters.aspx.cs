using PatelTeaSource.Repository.GlobalParameterRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class DeleteGlobalParameters : System.Web.UI.Page
    {
        public DeleteGlobalParameters()
          : this(new GlobalParametersRepository())
        {
        }

        private IGlobalParametersRepository _iGlobalParametersRepository;
        public DeleteGlobalParameters(GlobalParametersRepository globalParametersRepository)
        {
            _iGlobalParametersRepository = globalParametersRepository; 
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
                            var databyid = _iGlobalParametersRepository.SelectById(passedId);
                            if (databyid != null)
                            {

                                _iGlobalParametersRepository.Delete(passedId);
                                Response.Redirect("GlobalParamList.aspx");
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