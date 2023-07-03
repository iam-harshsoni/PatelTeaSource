using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PatelTeaSource.Model;
using PatelTeaSource.Repository.OrderMasterRepo;
using PatelTeaSource.Repository.OrderMasterDetailsRepo;
using PatelTeaSource.Repository.UserMasterRepo;
using PatelTeaSource.Repository.GlobalParameterRepo;
using System.Net;
using PatelTeaSource.Classes;

namespace PatelTeaSource.CS
{
    public partial class CancelOrder : System.Web.UI.Page
    {
        public CancelOrder()
          : this( new OrderMasterRepository(), new OrderMasterDetailsRepository(),new UserMasterRepository(),new GlobalParametersRepository())
        {
        }
        private IOrderMasterRepository _iOrderMasterRepository;
        private IOrderMasterDetailsRepository _iOrderMasterDetailsRepository;
        private IUserMasterRepository _iUserMasterRepository;
        private IGlobalParametersRepository _iGlobalParametersRepository;

        public CancelOrder( OrderMasterRepository orderMasterRepository, OrderMasterDetailsRepository orderMasterDetailsRepository,UserMasterRepository userMasterRepository,GlobalParametersRepository globalParametersRepository)
        {
            _iGlobalParametersRepository = globalParametersRepository;
            _iOrderMasterRepository = orderMasterRepository; 
            _iOrderMasterDetailsRepository = orderMasterDetailsRepository;
            _iUserMasterRepository = userMasterRepository;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            { 
                string recieverMobileNumberForMail,apiKey = "", token = "", senderSMS = "";

                int passedOrderId = Convert.ToInt32(Request.QueryString["cancelOrder"]);
                int passedUserId = Convert.ToInt32(Session["user_id_client"]);
                var data = _iOrderMasterRepository.SelectAll().Where(x => x.order_id == passedOrderId);
                int totalItemsForMail=0;

                if (data!=null)
                {
                    var datas = _iOrderMasterRepository.SelectAll().Where(x => x.order_id == passedOrderId).FirstOrDefault();
                    if (datas.order_status != 4)
                    {
                        datas.order_status = 5;
                        _iOrderMasterRepository.Update(datas);
                    }


                    #region sms Send

                     recieverMobileNumberForMail = _iUserMasterRepository.SelectById(passedUserId).mobile;

                    var dateofOrder = _iOrderMasterRepository.SelectById(passedOrderId).order_datetime;

                    DateTime sData = Convert.ToDateTime(dateofOrder).Date;
                    DateTime eData = sData.AddDays(3);

                               
                    HttpCookie aCookie;
                    string cookieName;
                    int limit = Request.Cookies.Count;
                    for (int i = 0; i < limit; i++)
                    {
                        cookieName = Request.Cookies[i].Name;
                        aCookie = new HttpCookie(cookieName);
                        aCookie.Expires = DateTime.Now.AddDays(-3); // make it expire yesterday
                        Response.Cookies.Add(aCookie); // overwrite it
                    }


                    var apiKeyByID = _iGlobalParametersRepository.SelectAll().Where(x => x.globalParamKey == "APIKey").FirstOrDefault();

                    if (apiKeyByID != null)
                    {
                        apiKey = apiKeyByID.globalParamValue;
                    }

                    var apiTokenByID = _iGlobalParametersRepository.SelectAll().Where(x => x.globalParamKey == "APIToken").FirstOrDefault();

                    if (apiKeyByID != null)
                    {
                        token = apiTokenByID.globalParamValue;
                    }

                    var senderByID = _iGlobalParametersRepository.SelectAll().Where(x => x.globalParamKey == "SMSSender").FirstOrDefault();

                    if (apiKeyByID != null)
                    {
                        senderSMS = senderByID.globalParamValue;
                    }

                    var orderDetailsData = _iOrderMasterDetailsRepository.SelectAll().Where(x => x.order_id == passedOrderId).ToList();

                    foreach (var item in orderDetailsData)
                    {
                        totalItemsForMail++;
                    }

                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                    model_messge post_values = new model_messge
                    {

                        api_key = apiKey,

                        api_token = token,

                        sender = senderSMS,

                        receiver = recieverMobileNumberForMail,

                        msgtype = "1",

                        sms = "Order Canceled: Your order for " + totalItemsForMail + " item(s) (Order No.:" + passedOrderId + ") has been successfully canceled.",
                        
                    };

                    post_values.sendSmS(post_values);

                    #endregion
                }
                else
                {
                    Response.Redirect("MyAccount.aspx");
                }
                Response.Redirect("MyAccount.aspx");
            }
            catch(Exception x)
            {

            }
        }
    }
}