using PatelTeaSource.Repository.DistributerMasterRepo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.CS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public WebForm1()
          : this(new DistributerMasterRepository())
        {
        }

        private IDistributerMasterRepository _iDistributerMasterRepository;
        public WebForm1(DistributerMasterRepository DistributerMasterRepository)
        {
            _iDistributerMasterRepository = DistributerMasterRepository;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //DataTable dt = this.GetData("select * from distributer_master");
            //rptMarkers.DataSource = dt;
            //rptMarkers.DataBind();

            var dt = _iDistributerMasterRepository.SelectAll().ToList();
            rptMarkers.DataSource = dt;
            rptMarkers.DataBind();

        }

        private DataTable GetData(string query)
        {
            string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            SqlCommand cmd = new SqlCommand(query);
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;

                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        return dt;
                    }
                }
            }
        }

    }
}