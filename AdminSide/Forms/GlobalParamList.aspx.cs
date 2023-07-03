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
    public partial class GlobalParamList : System.Web.UI.Page
    {
        StringBuilder html;
        long passedUserId = 0;

        public GlobalParamList()
          : this(new GlobalParametersRepository())
        {
        }

        private IGlobalParametersRepository _iGlobalParametersRepository;
        
        public GlobalParamList(GlobalParametersRepository globalParametersRepository)
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
                        int rowNo = 1;
                        var data = _iGlobalParametersRepository.SelectAll();

                        if (data.Count() > 0)
                        {

                            foreach (var item in data)
                            {
                                html = new StringBuilder();

                                html.Append("<tr>");
                                html.Append("<td>"); html.Append(rowNo); html.Append("</td>");
                                html.Append("<td>"); html.Append(item.globalParamKey); html.Append("</td>");

                                html.Append("<td>"); html.Append(item.globalParamValue); html.Append("</td>");

                                if (item.description != null)
                                {
                                    html.Append("<td>"); html.Append(item.description); html.Append("</td>");
                                }
                                else
                                {
                                    html.Append("<td>"); html.Append("--"); html.Append("</td>");

                                }

                                html.Append("<td>");

                                string hrfEdit = "AddGlobalParameters.aspx?id=" + item.gId;
                                string hrfDelete = "DeleteGlobalParameters.aspx?id=" + item.gId;

                                html.Append("<a href='" + hrfEdit + "' class='icon-pencil2' style='font-size:large'></a> | ");
                                //html.Append("<a href='" + hrfDelete + "' class='icon-remove' style='font-size:large'></a>  ");
                                html.Append("<a class='icon-close2' style='font-size:large' onclick='deleteThis(" + item.gId + ")'></a>");

                                html.Append("</tr>");

                                rowNo++;
                                PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
                            }
                        }
                        else
                        {
                            html = new StringBuilder();

                            html.Append("<tr>");
                            html.Append("<td colspan='5' style='text-align:center'>"); html.Append("<b>No records found.</b>"); html.Append("</td>");
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