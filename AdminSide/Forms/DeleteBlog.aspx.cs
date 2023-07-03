using PatelTeaSource.Repository.BlogRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class DeleteBlog : System.Web.UI.Page
    {
        public DeleteBlog()
          : this(new BlogRepository())
        {
        }

        private IBlogRepository _iBlogRepository;
        public DeleteBlog(BlogRepository blogRepository)
        {
            _iBlogRepository = blogRepository;
        }
        int passedId = 0;
        long passedUserId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                passedUserId = Convert.ToInt32(Session["u_id"]);

                if (passedUserId != 0)
                {
                    if (!IsPostBack)
                    {
                        passedId = Convert.ToInt32(Request.QueryString["id"].ToString());

                        if (passedId >= 0)
                        {
                            var databyid = _iBlogRepository.SelectById(passedId);
                            if (databyid != null)
                            {

                                _iBlogRepository.Delete(passedId);
                                Response.Redirect("BlogList.aspx");
                            }
                        }
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception x)
            {
                Response.Write("<script>alert('" + x.ToString() + "')</script>");
            }
        }
    }
}