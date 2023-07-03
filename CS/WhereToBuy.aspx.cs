using PatelTeaSource.Repository.DistributerMasterRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.CS
{
    public partial class WhereToBuy : System.Web.UI.Page
    {

        StringBuilder html;
        public WhereToBuy()
          : this(new DistributerMasterRepository())
        {
        }

        private IDistributerMasterRepository _iDistributerMasterRepository;
        public WhereToBuy(DistributerMasterRepository DistributerMasterRepository)
        {
            _iDistributerMasterRepository = DistributerMasterRepository;
        }
        string stateName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    mapValueDynamic();


                    //var datas = _iDistributerMasterRepository.SelectAll().ToList();

                    //foreach (var item in datas)
                    //{
                    //    html = new StringBuilder();

                    //    html.Append("<div class='col-md-4' style='padding:13px 13px 13px 17px;'>");
                    //    html.Append("<div style='border:1px solid lightgray;padding:15px;border-radius:15px;'>");
                    //    html.Append("<label style='font-size:large;'>" + item.name + "</label>");
                    //    html.Append("<br />");
                    //    html.Append("<label style='color: red'>" + item.ownername + "</label>");
                    //    html.Append("<br />");
                    //    html.Append("<b>Address:</b>" + item.fulladdress);
                    //    html.Append("<br />");
                    //    html.Append("<i class='fa fa-phone' style='font-size: 17px'></i><span>" + item.contactno + "</span>");
                    //    html.Append("</div>");

                    //    html.Append("</div>");
                        
                    //    PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
                    //}



                    //DropDownList1.SelectedIndex = -1;
                    //DropDownList2.Items.Clear();
                    //DropDownList2.Items.Add("--Select City--");

                    //var data = _iDistributerMasterRepository.SelectAll().OrderBy(x=>x.state);
                    //DropDownList1.Items.Add("--Select State--");
                    //foreach (var item in data)
                    //{
                    //    if (stateName != item.state)
                    //    {
                    //        DropDownList1.Items.Add(item.state);
                    //        stateName = item.state;
                    //    }
                    //}
                }
            }
            catch (Exception x)
            {

            }
        }

        //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        //{
         
        //    try
        //    {
        //        DropDownList2.Items.Clear();
        //        DropDownList2.Items.Add("--Select State--");

        //        var stateSelected = DropDownList1.SelectedItem.ToString();
        //            var data = _iDistributerMasterRepository.SelectAll().Where(x=>x.state==stateSelected).OrderBy(x=>x.city).ToList();
                    
        //            foreach (var item in data)
        //            {
        //                if (stateName != item.city)
        //                {
                        
        //                    DropDownList2.Items.Add(item.city);
        //                    stateName = item.city;
        //                }
        //            }
               
        //    }
        //    catch (Exception x)
        //    {

        //    }

        //}

        //protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {

               
        //        var stateSelected = DropDownList2.SelectedItem.ToString();
        //        var data = _iDistributerMasterRepository.SelectAll().Where(x => x.city == stateSelected).ToList();

        //        foreach (var item in data)
        //        {
        //            html = new StringBuilder();

        //            html.Append("<div class='col-md-4'>");
        //                html.Append("<div style='border:1px solid lightgray;padding:15px;border-radius:15px;height: 165px;'>");
        //                html.Append("<label style='font-size:large;'>"+item.name+"</label>");
        //                html.Append("<br />");
        //                html.Append("<label style='color: red'>"+item.ownername+"</label>");
        //                html.Append("<br />");
        //                html.Append("<b>Address:</b>" + item.fulladdress);
        //                html.Append("<br />");
        //                html.Append("<i class='fa fa-phone' style='font-size: 17px'></i><span>"+item.contactno+"</span>");
        //                html.Append("</div>");  

        //                html.Append("</div>");
        //            PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
        //        }

              

        //    }
        //    catch(Exception x)
        //    {

        //    }
        //}

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    Response.Write("<script> alert('" + DropDownList1.SelectedItem + "') </script>");
        //}

        //protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        //{
        //    Response.Redirect("Default.aspx");
        //}


        private void mapValueDynamic()
        {
            var data = _iDistributerMasterRepository.SelectAll().ToList();
            rptMarkers.DataSource = data;
            rptMarkers.DataBind();
        }
    }
}