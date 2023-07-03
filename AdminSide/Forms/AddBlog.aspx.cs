using PatelTeaSource.Model;
using PatelTeaSource.Repository.BlogRepo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class AddBlog : System.Web.UI.Page
    {
        public AddBlog()
          : this(new BlogRepository())
        {
        }

        private IBlogRepository _iBlogRepository;
        public AddBlog(BlogRepository blogRepository)
        {
            _iBlogRepository = blogRepository;
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
                                var databyid = _iBlogRepository.SelectById(passedId);
                                if (databyid != null)
                                {
                                    txtTitle.Text = databyid.title.Trim().ToString();
                                    txtDesc.Text = databyid.description.Trim().ToString();
                                    txtYear.Text = databyid.date.ToString();

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
            if (bitmp.Width > 1200 || bitmp.Height > 970)
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
                    FileUpload1.PostedFile.SaveAs(Server.MapPath("~/AdminSide/AdminSideData/BlogImages/" + str));
                    FileUpload1.PostedFile.SaveAs("E:/Inetpub/vhosts/msuaresolutions.com/pateltea.co.in/AdminSide/AdminSideData/BlogImages/" + str);

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
                            blog_master blog = new blog_master();
                            blog.title = txtTitle.Text.Trim().ToString();
                            blog.description = txtDesc.Text.Trim().ToString();
                            blog.date = txtYear.Text.ToString();
                            blog.image = image;
                            blog.cdate = DateTime.Now;

                            _iBlogRepository.Add(blog);
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
                    var databyid = _iBlogRepository.SelectById(passedId);
                    if (databyid != null)
                    {
                        databyid.title = txtTitle.Text.Trim().ToString();
                        databyid.description = txtDesc.Text.Trim().ToString();
                        databyid.date = txtYear.Text.ToString();

                        if (databyid.image != image && image != null)
                        {
                            if (!isFileValid())
                            {
                                return;
                            }
                            else
                            {
                                databyid.image = image;
                            }
                        }
                        databyid.udate = DateTime.Now;

                        _iBlogRepository.Update(databyid);
                    }
                }
                Response.Redirect("BlogList.aspx");
            }


            catch (Exception x)
            {
                Response.Write("<script>alert('" + x.ToString() + "')</script>");
            }
        }
    }
}