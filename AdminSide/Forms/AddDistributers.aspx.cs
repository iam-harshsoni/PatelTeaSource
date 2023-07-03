using PatelTeaSource.Model;
using PatelTeaSource.Repository.DistributerMasterRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class AddDistributers : System.Web.UI.Page
    {
        long passedUserId = 0;
        int passedId = 0;

        public AddDistributers()
            : this(new DistributerMasterRepository())
        {
        }

        private IDistributerMasterRepository _iDistributerMasterRepository;
        public AddDistributers(DistributerMasterRepository DistributerMasterRepository)
        {
            _iDistributerMasterRepository = DistributerMasterRepository;
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
                                var databyid = _iDistributerMasterRepository.SelectById(passedId);
                                if (databyid != null)
                                {
                                    txtFirmName.Text = databyid.name.Trim().ToString();
                                    txtOwnerName.Text = databyid.ownername.Trim().ToString();
                                    txtFullAdd.Text = databyid.name.Trim().ToString();
                                    txtPincode.Text = databyid.pincode.Trim().ToString();
                                    txtEmail.Text = databyid.email.Trim();
                                    txtContact.Text = databyid.contactno.Trim().ToString();
                                    txtCity.Text = databyid.city.Trim().ToString();
                                    txtLat.Text = databyid.locLat.ToString();
                                    txtLong.Text = databyid.locLong.ToString();
                                    txtState.Text = databyid.state.ToString();
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

                    distibuter_master distMaster = new distibuter_master();

                    distMaster.name = txtFirmName.Text.Trim().ToString();
                    distMaster.ownername = txtOwnerName.Text.Trim().ToString();
                    distMaster.contactno = txtContact.Text.Trim();
                    distMaster.fulladdress = txtFullAdd.Text.Trim().ToString();
                    distMaster.pincode = txtPincode.Text.Trim();
                    distMaster.email = txtEmail.Text.Trim().ToString();
                    distMaster.city = txtCity.Text.Trim().ToString();
                    distMaster.cdate = DateTime.Now;
                    distMaster.locLat = txtLat.Text.Trim().ToString();
                    distMaster.locLong= txtLong.Text.Trim().ToString();
                    distMaster.state = txtState.Text.Trim().ToString();

                    _iDistributerMasterRepository.Add(distMaster);
                }
                else
                {
                    passedId = Convert.ToInt32(Request.QueryString["id"].ToString());
                    var databyid = _iDistributerMasterRepository.SelectById(passedId);
                    if (databyid != null)
                    {
                        databyid.name = txtFirmName.Text.Trim().ToString();
                        databyid.ownername = txtOwnerName.Text.Trim().ToString();
                        databyid.contactno = txtContact.Text.Trim();
                        databyid.fulladdress = txtFullAdd.Text.Trim().ToString();
                        databyid.pincode = txtPincode.Text.Trim();
                        databyid.email = txtEmail.Text.Trim().ToString();
                        databyid.udate = DateTime.Now;
                        databyid.city = txtCity.Text.Trim().ToString();
                        databyid.locLat = txtLat.Text.Trim().ToString();
                        databyid.locLong = txtLong.Text.Trim().ToString();
                        databyid.state = txtState.Text.Trim().ToString();

                        _iDistributerMasterRepository.Update(databyid);
                    }
                }
                Response.Redirect("DistributerLst.aspx");
            }
            catch (Exception x)
            {
                //Response.Write("<script>alert('" + x.ToString() + "')</script>");
            }
        }
    }
}