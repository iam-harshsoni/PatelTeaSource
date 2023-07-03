using PatelTeaSource.Repository.BannerMasterRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.AdminSide
{
    public partial class MainBannerLst : System.Web.UI.Page
    {
        StringBuilder html;
        long passedUserId = 0;
        public MainBannerLst()
          : this(new BannerMasterRepository())
        {
        }

        private IBannerMasterRepository _iBannerMasterRepository;
        public MainBannerLst(BannerMasterRepository bannerMasterRepository)
        {
            _iBannerMasterRepository = bannerMasterRepository;
        }
        int passedId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    passedUserId = Convert.ToInt32(Session["u_id"]);

                    if (passedUserId != 0)
                    {
                        int rowNo = 1;
                        var data = _iBannerMasterRepository.SelectAll();
                        if (data.Count() > 0)
                        {
                            foreach (var item in data)
                            {
                                html = new StringBuilder();

                                html.Append("<tr>");
                                html.Append("<td>"); html.Append(rowNo); html.Append("</td>");
                                html.Append("<td>"); html.Append(item.bannerHeader); html.Append("</td>");
                                html.Append("<td>"); html.Append(item.bannerDesc); html.Append("</td>");

                                string imagename = "../AdminSideData/BannerImages/" + item.bannerImg.ToString();
                                //Image1.ImageUrl = "~/AdminSide/AdminSideData/BannerImages/" + imagename;

                                html.Append("<td>"); html.Append("<img style='width: 100%;' alt='' src='" + imagename + "'/>"); html.Append("</td>");
                                html.Append("<td>"); html.Append(Convert.ToDateTime(item.cdate).ToString("dd-MM-yyyy HH:mm:ss")); html.Append("</td>");

                                if (item.udate == null)
                                {
                                    html.Append("<td style='text-align:center'>"); html.Append("--"); html.Append("</td>");

                                }
                                else
                                {
                                    html.Append("<td>"); html.Append(Convert.ToDateTime(item.udate).ToString("dd-MM-yyyy HH:mm:ss")); html.Append("</td>");
                                }
                                html.Append("<td>");
                                string hrfEdit = "AddBanner.aspx?id=" + item.banner_id;
                                string hrfDelete = "DeleteMainBanner.aspx?id=" + item.banner_id;

                                html.Append("<a href='" + hrfEdit + "' class='icon-pencil2' style='font-size:large'></a> | ");
                                //html.Append("<a href='" + hrfDelete + "' class='icon-remove' style='font-size:large'></a>  ");
                                html.Append("<a class='icon-close2' style='font-size:large' onclick='deleteThis(" + item.banner_id + ")'></a>  ");

                                html.Append("</td>");
                                html.Append("</tr>");

                                rowNo++;
                                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
                            }
                        }
                        else
                        {
                            html = new StringBuilder();

                            html.Append("<tr>");
                            html.Append("<td colspan='4' style='text-align:center'>"); html.Append("<b>No records found.</b>"); html.Append("</td>");
                            html.Append("</tr>");
                            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
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