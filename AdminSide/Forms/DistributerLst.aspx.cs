using PatelTeaSource.Repository.DistributerMasterRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class DistributerLst : System.Web.UI.Page
    {
        StringBuilder html;
        long passedUserId = 0;
        public DistributerLst()
          : this(new DistributerMasterRepository())
        {
        }

        private IDistributerMasterRepository _iDistributerMasterRepository;
        public DistributerLst(DistributerMasterRepository DistributerMasterRepository)
        {
            _iDistributerMasterRepository = DistributerMasterRepository;
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
                        var data = _iDistributerMasterRepository.SelectAll();

                        if (data.Count() > 0)
                        {
                            foreach (var item in data)
                            {
                                html = new StringBuilder();

                                html.Append("<tr>");
                                html.Append("<td>"); html.Append(rowNo); html.Append("</td>");
                                html.Append("<td>"); html.Append(item.name); html.Append("</td>");
                                html.Append("<td>"); html.Append(item.city); html.Append("</td>");
                                html.Append("<td>"); html.Append(item.contactno); html.Append("</td>");
                                html.Append("<td>"); html.Append(item.locLat); html.Append("</td>");
                                html.Append("<td>"); html.Append(item.locLong); html.Append("</td>");


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

                                string hrfEdit = "AddDistributers.aspx?id=" + item.dis_id;
                                string hrfDelete = "DeleteDistributers.aspx?id=" + item.dis_id;

                                html.Append("<a href='" + hrfEdit + "' class='icon-edit' style='font-size:large'></a> | ");
                                //html.Append("<a href='" + hrfDelete + "' class='icon-remove' style='font-size:large'></a>  ");
                                html.Append("<a class='icon-remove' style='font-size:large' onclick='deleteThis(" + item.dis_id + ")'></a>  ");

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
                            html.Append("<td colspan='9' style='text-align:center'>"); html.Append("<b>No records found.</b>"); html.Append("</td>");
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