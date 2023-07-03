using PatelTeaSource.Model;
using PatelTeaSource.Repository.GlobalParameterRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class AddGlobalParameters : System.Web.UI.Page
    {

        StringBuilder html;
        long passedUserId = 0;
        int passedId = 0;
        public AddGlobalParameters()
          : this(new GlobalParametersRepository())
        {
        }

        private IGlobalParametersRepository _iGlobalParametersRepository;

        public AddGlobalParameters(GlobalParametersRepository globalParametersRepository)
        {
            _iGlobalParametersRepository = globalParametersRepository;
        }

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
                                var databyid = _iGlobalParametersRepository.SelectById(passedId);
                                if (databyid != null)
                                {
                                    txtParamkey.Text = databyid.globalParamKey.Trim().ToString();
                                    txtParamValue.Text = databyid.globalParamValue.Trim().ToString();

                                    if (databyid.description != null)
                                    {
                                        txtDesc.Text = databyid.description.Trim().ToString();
                                    }
                                    txtParamkey.Enabled = false;

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

                    GlobalParameter distMaster = new GlobalParameter();

                    distMaster.globalParamKey = txtParamkey.Text.Trim().ToString();
                    distMaster.globalParamValue = txtParamValue.Text.Trim().ToString();
                    distMaster.description = txtDesc.Text.Trim().ToString();
                    distMaster.cDate = DateTime.Now;

                    _iGlobalParametersRepository.Add(distMaster);
                }
                else
                {
                    passedId = Convert.ToInt32(Request.QueryString["id"].ToString());
                    var databyid = _iGlobalParametersRepository.SelectById(passedId);
                    if (databyid != null)
                    {
                        databyid.globalParamKey = txtParamkey.Text.Trim().ToString();
                        databyid.globalParamValue = txtParamValue.Text.Trim().ToString();
                        databyid.description = txtDesc.Text.Trim().ToString();
                        databyid.uDate = DateTime.Now;
                         
                        _iGlobalParametersRepository.Update(databyid);
                    }
                }
                Response.Redirect("GlobalParamList.aspx");
            }
            catch (Exception x)
            {
                Response.Write("<script>alert('" + x.ToString() + "')</script>");
            }
        }
         
    }
}