using PatelTeaSource.Repository.BlogRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.CS
{
    public partial class Blog : System.Web.UI.Page
    {
        StringBuilder html;
        public Blog()
          : this(new BlogRepository())
        {
        }

        private IBlogRepository _iBlogRepository;
        public Blog(BlogRepository blogRepository)
        {
            _iBlogRepository = blogRepository;
        }
        //int passedId = 0;
        //long passedUserId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    var data = _iBlogRepository.SelectAll().OrderByDescending(x=>x.date);

                    foreach (var item in data)
                    {
                        html = new StringBuilder();

                        html.Append("<article class='post'>");
                        html.Append("<div class='row'>");
                        html.Append("<div class='col-md-6'>");
                        html.Append("<figure class='post-thumbnail'>");

                        string imagename = "../AdminSide/AdminSideData/BlogImages/" + item.image.ToString();


                        html.Append("<img style='width: 100%;' src='" + imagename + "'/>");
                        html.Append("<a href='#'></a>");
                        html.Append("</figure>");
                        html.Append("</div>");
                        html.Append("<div class='col-md-6'>");
                        html.Append("<div class='entry'>");

                        var dateMonth = Convert.ToDateTime(item.date).ToString("MMM");
                        var dataYear= Convert.ToDateTime(item.date).ToString("yyyy");

                        html.Append("<div class='entry-date'>"+ dateMonth + "<small>/"+ dataYear + "</small></div>");
                        html.Append("<h3 class='title entry-title'><a href='#'>"+item.title+"</a></h3>");
                        html.Append("<div class='entry-content'>"+item.description+"</div>");
                        html.Append("<div class='entry-meta'>");
                        html.Append("Post by<a href='https://www.pateltea.co.in' class='entry-meta-author'> Patel Tea Packers</a> / 7 comments");
                         html.Append("</div>");
                        html.Append("</div>");
                        html.Append("</div>");
                        html.Append("</div>");

                        html.Append("</article>");
                        
                
                        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
 

                    }
                }
            }
            catch (Exception x)
            {

            }
        }
    }
}