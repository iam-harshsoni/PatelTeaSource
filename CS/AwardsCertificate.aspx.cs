using PatelTeaSource.Repository.AwardsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.CS
{
    public partial class AwardsCertificate : System.Web.UI.Page
    {
        StringBuilder html;

        public AwardsCertificate()
          : this(new AwardsRepository())
        {
        }

        private IAwardsRepository _iAwardsRepository;
        public AwardsCertificate(AwardsRepository awardsRepository)
        {
            _iAwardsRepository = awardsRepository;
        }
        int passedId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    var data = _iAwardsRepository.SelectAll();

                    foreach (var item in data)
                    {
                        html = new StringBuilder();

                        html.Append("<div class='col-md-4 gallery-item coffee milk tea'>");
                        html.Append("<div class='inner'>");
                        html.Append("<figure>");

                        string imagename = "../AdminSide/AdminSideData/AwardImages/" + item.awardImg.ToString();
 
                        html.Append("<img alt= '' width='200' height='280px' src='"+imagename+"'>");
                        html.Append("</figure>");
                        html.Append("<br />");
                        html.Append(" <h4 class='title'>"+item.description+"</h4>");
                        html.Append("<hr />");
                        html.Append("</div>");
                        html.Append("</div>");

                        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
                    }
                }
                catch (Exception x)
                {
                   // Response.Write("<script>alert('" + x.ToString() + "')</script>");
                }

                 
            }
        }
    }
}