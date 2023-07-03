using PatelTeaSource.Repository.AwardsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class AwardsLst : System.Web.UI.Page
    {
        StringBuilder html;

        public AwardsLst()
          : this(new AwardsRepository())
        {
        }

        private IAwardsRepository _iAwardsRepository;
        public AwardsLst(AwardsRepository awardsRepository)
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
                        int rowNo = 1;
                    var data = _iAwardsRepository.SelectAll();
                        if (data.Count() > 0)
                        {
                            foreach (var item in data)
                    {
                        html = new StringBuilder();

                        html.Append("<tr>");
                        html.Append("<td>"); html.Append(rowNo); html.Append("</td>");
                        html.Append("<td>"); html.Append(item.description); html.Append("</td>");

                        string imagename = "../AdminSideData/AwardImages/" + item.awardImg.ToString();
                        //Image1.ImageUrl = "~/AdminSide/AdminSideData/BannerImages/" + imagename;

                        html.Append("<td>"); html.Append("<img style='width: 100%;' alt='' src='" + imagename + "'/>"); html.Append("</td>");
                        html.Append("<td>"); html.Append(Convert.ToDateTime(item.year).ToString("dd-MM-yyyy")); html.Append("</td>");
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
                        string hrfEdit = "AddAwards.aspx?id=" + item.awardId;
                        string hrfDelete = "DeleteAwards.aspx?id=" + item.awardId;

                        html.Append("<a href='" + hrfEdit + "' class='icon-pencil2' style='font-size:large'></a> | ");
                        //html.Append("<a href='" + hrfDelete + "' class='icon-remove' style='font-size:large'></a>  ");
                        html.Append("<a class='icon-close2' style='font-size:large' onclick='deleteThis(" + item.awardId + ")'></a>  ");

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
                            html.Append("<td colspan='7' style='text-align:center'>"); html.Append("<b>No records found.</b>"); html.Append("</td>");
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