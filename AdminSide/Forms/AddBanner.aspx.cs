using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PatelTeaSource.Model;
using PatelTeaSource.ViewModel;
using PatelTeaSource.Repository.BannerMasterRepo;

namespace PatelTeaSource.AdminSide
{
    public partial class AddBanner : System.Web.UI.Page
    {

        int passedId = 0;
        public AddBanner()
          : this(new BannerMasterRepository())
        {
        }

        private IBannerMasterRepository _iBannerMasterRepository;
        public AddBanner(BannerMasterRepository bannerMasterRepository)
        {
            _iBannerMasterRepository = bannerMasterRepository;
        }
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
                                var databyid = _iBannerMasterRepository.SelectById(passedId);
                                if (databyid != null)
                                {
                                    txtBannerHead.Text = databyid.bannerHeader.Trim().ToString();
                                    txtDesc.Text = databyid.bannerDesc.Trim().ToString();

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


        public bool isFileValid()
        {
            Bitmap bitmp = new Bitmap(FileUpload1.PostedFile.InputStream);
            if (bitmp.Width > 1920 || bitmp.Height > 675)
            {
                Label1.Text = "Image is not in proper dimension";
                Label1.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            else
            {
                return true;
            }
        }
        string str, image;
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.HasFile)
                {
                    str = FileUpload1.FileName;
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/AdminSide/AdminSideData/BannerImages/" + str));
                    FileUpload1.PostedFile.SaveAs("E:/Inetpub/vhosts/msuaresolutions.com/pateltea.co.in/AdminSide/AdminSideData/BannerImages/" + str);

                    image = str.ToString();
                }

                Label1.Visible = false;

                if (btnSubmit.Text == "Submit")
                {
                    if (FileUpload1.HasFile)
                    {
                        if (!isFileValid())
                        {
                            return;
                        }
                        else
                        {

                            banner_master banner = new banner_master();
                            banner.bannerHeader = txtBannerHead.Text.Trim().ToString();
                            banner.bannerDesc = txtDesc.Text.Trim().ToString();
                            banner.bannerImg = image;
                            banner.cdate = DateTime.Now;

                            _iBannerMasterRepository.Add(banner);
                        }
                    }
                }
                else
                {
                    passedId = Convert.ToInt32(Request.QueryString["id"].ToString());
                    var databyid = _iBannerMasterRepository.SelectById(passedId);
                    if (databyid != null)
                    {
                        databyid.bannerHeader = txtBannerHead.Text.Trim().ToString();
                        databyid.bannerDesc = txtDesc.Text.Trim().ToString();
                        if (databyid.bannerImg != image && image != null)
                        {
                            if (!isFileValid())
                            {
                                return;
                            }
                            else
                            {
                                databyid.bannerImg = image;
                            }
                        }
                        databyid.udate = DateTime.Now;

                        _iBannerMasterRepository.Update(databyid);
                    }
                }
                Response.Redirect("MainBannerLst.aspx");


            }
            catch (Exception x)
            {
                Response.Write("<script>alert('" + x.ToString() + "')</script>");
            }
        }

        void clearData()
        {
            txtBannerHead.Text = "";
            txtDesc.Text = "";
            btnSubmit.Text = "Submit";
        }

     

        protected void btnClear_Click(object sender, EventArgs e)
        {
            clearData();
        }
    }
}