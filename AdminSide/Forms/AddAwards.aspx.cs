using PatelTeaSource.Model;
using PatelTeaSource.Repository.AwardsRepo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class AddAwards : System.Web.UI.Page
    {
        public AddAwards()
          : this(new AwardsRepository())
        {
        }

        private IAwardsRepository _iAwardsRepository;
        public AddAwards(AwardsRepository awardsRepository)
        {
            _iAwardsRepository = awardsRepository;
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
                                var databyid = _iAwardsRepository.SelectById(passedId);
                                if (databyid != null)
                                {

                                    txtDesc.Text = databyid.description.Trim().ToString();
                                    txtYear.Text = databyid.year.ToString();

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
            decimal size = Math.Round(((decimal)FileUpload1.PostedFile.ContentLength / (decimal)1024), 2);
            if (size > 300)
            {
                Label1.Text = "Image is not in proper size";
                Label1.ForeColor = System.Drawing.Color.Red;
                return false;
            }
            if (bitmp.Width >2000 || bitmp.Height > 3000)
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
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/AdminSide/AdminSideData/AwardImages/" + str));
                    FileUpload1.PostedFile.SaveAs("E:/Inetpub/vhosts/msuaresolutions.com/pateltea.co.in/AdminSide/AdminSideData/AwardImages/" + str);

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
                            awardsCertificate awards = new awardsCertificate();
                            awards.description = txtDesc.Text.Trim().ToString();
                            awards.year = txtYear.Text.ToString();
                            awards.awardImg = image;
                            awards.cdate = DateTime.Now;

                            _iAwardsRepository.Add(awards);
                        }
                    }
                    else
                    {
                        Response.Write("<script> alert('No Image Selected.Select Image!')</script>");
                    }

                }
                else
                {
                    passedId = Convert.ToInt32(Request.QueryString["id"].ToString());
                    var databyid = _iAwardsRepository.SelectById(passedId);
                    if (databyid != null)
                    {
                        databyid.description = txtDesc.Text.Trim().ToString();
                        databyid.year = txtYear.Text.ToString();

                        if (databyid.awardImg != image && image != null)
                        {
                            if (!isFileValid())
                            {
                                return;
                            }
                            else
                            {
                                databyid.awardImg = image;
                            }
                        }
                        databyid.udate = DateTime.Now;

                        _iAwardsRepository.Update(databyid);
                    }
                }
                Response.Redirect("AwardsLst.aspx");
            }


            catch (Exception x)
            {
                Response.Write("<script>alert('" + x.ToString() + "')</script>");
            }
        }
    }
}