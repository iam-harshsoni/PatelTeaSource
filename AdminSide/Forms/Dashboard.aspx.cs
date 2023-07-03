using PatelTeaSource.Repository.NewUserRegisterRepo;
using PatelTeaSource.Repository.ProductMasterRepo;
using PatelTeaSource.Repository.ContactMasterRepo;
using PatelTeaSource.Repository.UserMasterRepo;
using PatelTeaSource.Repository.OrderMasterRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.AdminSide.Forms
{
    public partial class Dashboard : System.Web.UI.Page
    {
        public Dashboard()
          : this(new NewUserRegisterRepository(), new ProductMasterRepository(), new ContactMasterRepository(), new UserMasterRepository(), new OrderMasterRepository())
        {
        }

        private INewUserRegisterRepository _iNewUserRegisterRepository;
        private IProductMasterRepository _iProductMasterRepository;
        private IContactMasterRepository _iContactMasterRepository;
        private IUserMasterRepository _iUserMasterRepository;
        private IOrderMasterRepository _iOrderMasterRepository;
        public Dashboard(NewUserRegisterRepository newUserRegisterRepository, ProductMasterRepository productMasterRepository, ContactMasterRepository contactMasterRepository, UserMasterRepository userMasterRepository, OrderMasterRepository orderMasterRepository)
        {
            _iNewUserRegisterRepository = newUserRegisterRepository;
            _iProductMasterRepository = productMasterRepository;
            _iContactMasterRepository = contactMasterRepository;
            _iUserMasterRepository = userMasterRepository;
            _iOrderMasterRepository = orderMasterRepository;
        }
        int passedId = 0;
        long passedUserId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var totalProductss = _iProductMasterRepository.SelectAll().Count().ToString();
                var totalContactss = _iContactMasterRepository.SelectAll().Count().ToString();
                var totalOrderss = _iOrderMasterRepository.SelectAll().Where(x => x.order_status != 5).Count().ToString();
                var totalUserAdmins = _iNewUserRegisterRepository.SelectAll().Where(x => x.userType == "AdminSide").Count().ToString();
                var totalUserClients = _iUserMasterRepository.SelectAll().Count().ToString();

                lblTotalOrders.Text = totalOrderss;
                lblClientUser.Text = totalUserClients;
                lblAdminUsers.Text = totalUserAdmins;
                lblTotalProducts.Text = totalProductss;
                lblContact.Text = totalContactss;


                if (!IsPostBack)
                {
                    passedUserId = Convert.ToInt32(Session["u_id"]);

                    if (passedUserId != 0)
                    {

                        var totalProducts = _iProductMasterRepository.SelectAll().Count().ToString();
                        var totalContacts = _iContactMasterRepository.SelectAll().Count().ToString();
                       
                        var totalUserAdmin = _iNewUserRegisterRepository.SelectAll().Where(x => x.userType == "AdminSide").Count().ToString();
                        var totalUserClient = _iNewUserRegisterRepository.SelectAll().Where(x => x.userType == "01").Count().ToString();

                        //lblTotalOrders.Text = totalOrders;
                        //lblClientUser.Text = totalUserClient;
                        //lblAdminUsers.Text = totalUserAdmin;
                        //lblTotalProducts.Text = totalProducts;
                        //lblContact.Text = totalContacts;

                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                    }

                }
            }
            catch (Exception x)
            {

            }

        }

    }
}