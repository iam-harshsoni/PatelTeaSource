using PatelTeaSource.Repository.NewUserRegisterRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class RegisteredUsers : System.Web.UI.Page
    {
        StringBuilder html;
        long passedUserId = 0;
        public RegisteredUsers()
          : this(new NewUserRegisterRepository())
        {
        }

        private INewUserRegisterRepository _iNewUserRegisterRepository;
        public RegisteredUsers(NewUserRegisterRepository newUserRegisterRepository)
        {
            _iNewUserRegisterRepository = newUserRegisterRepository;
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
                        var data = _iNewUserRegisterRepository.SelectAll();

                        foreach (var allusers in data)
                        {
                            html = new StringBuilder();

                            html.Append("<tr>");
                            html.Append("<td>"); html.Append(allusers.username); html.Append("</td>");
                            html.Append("<td>"); html.Append(allusers.fullName); html.Append("</td>");
                            html.Append("<td>"); html.Append(allusers.emailId); html.Append("</td>");

                            if (allusers.status == 0)
                            {
                                html.Append("<td>"); html.Append("Disabled"); html.Append("</td>");
                            }
                            else
                            {
                                html.Append("<td>"); html.Append("Enabled"); html.Append("</td>");
                            }
                            html.Append("<td>"); html.Append(allusers.role); html.Append("</td>");

                            html.Append("<td>");
                            string hrfEdit = "AddNewUserRegistration.aspx?id=" + allusers.userId;
                            string hrfDelete = "DeleteUser.aspx?id=" + allusers.userId;

                            html.Append("<a href='" + hrfEdit + "' class='icon-pencil2' style='font-size:large'></a> | ");
                            //html.Append("<a href='" + hrfDelete + "' class='icon-remove' style='font-size:large'></a>  ");
                            html.Append("<a class='icon-close2' style='font-size:large' onclick='deleteThis(" + allusers.userId + ")'></a>  ");

                            html.Append("</td>");

                            html.Append("</tr>");

                            rowNo++;
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