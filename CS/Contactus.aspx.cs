using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PatelTeaSource.Model;
using PatelTeaSource.ViewModel;
using PatelTeaSource.Repository.ContactMasterRepo;
using PatelTeaSource.Repository.GlobalParameterRepo;
using System.Net.Mail;
using System.Net;
using PatelTeaSource.Classes;

namespace PatelTeaSource.CS
{
    public partial class Contactus : System.Web.UI.Page
    {
        public Contactus()
          : this(new ContactMasterRepository(), new GlobalParametersRepository())
        {
        }

        private IContactMasterRepository _IContactMasterRepository;
        private IGlobalParametersRepository _iGlobalParametersRepository;
        public Contactus(ContactMasterRepository contactMasterRepository, GlobalParametersRepository globalParametersRepository)
        {
            _IContactMasterRepository = contactMasterRepository;
            _iGlobalParametersRepository = globalParametersRepository;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void submits_Click(object sender, EventArgs e)
        {
            MailClass sendm = new MailClass();
            sendm.sendMails(txtEmail.Text.Trim().ToString(), "Patel Tea Packers Customer Service.", "Thanks for showing your interest in Patel Tea Packers. One of our team memeber will contact you soon.", false);
            addToContact();
            AfterSendMail.Visible = true;
            sendMail.Visible = false;
        }

        private string  apiKey = "", token = "", senderSMS = "";
        string fromEmail = "", pwds = "", userMail = "";
        public void addToContact()
        {
            try
            {
                contact_master contact = new contact_master();
                contact.fname = txtName.Text.Trim().ToString();
                contact.email = txtEmail.Text.Trim().ToString();
                contact.subject = txtSub.Text.Trim().ToString();
                contact.message = txtMessage.Text.Trim().ToString();
                contact.mobile = txtMob.Text.ToString();
                contact.cdate = DateTime.Now;
                contact.status = 0;
                _IContactMasterRepository.Add(contact);

                #region sms Send


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


                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                model_messge post_values = new model_messge
                {

                    api_key = apiKey,

                    api_token = token,

                    sender = senderSMS,

                    receiver = txtMob.Text.ToString(),

                    msgtype = "1",

                    sms = "Thanks for showing your interest in Patel Tea Packers. One of our team member will contact you soon."

                };


                //Send sms to kishan patel and its brother

                post_values.sendSmS(post_values);

                post_values = new model_messge
                {

                    api_key = apiKey,

                    api_token = token,

                    sender = senderSMS,

                    receiver = "9879186082",

                    msgtype = "1",

                    sms = "Name: " + txtName.Text.Trim() + " and Mob.:" + txtMob.Text.ToString() + ". contacted you from website (PATEL TEA PACKERS) visit admin panel for reply."
                };

                post_values.sendSmS(post_values);

                //-------------------------------------------------------------------------------------------

              
                post_values = new model_messge
                {

                    api_key = apiKey,

                    api_token = token,

                    sender = senderSMS,

                    receiver = "9429012623",

                    msgtype = "1",

                    sms = "Name: "+ txtName.Text.Trim() + " and Mob.:"+txtMob.Text.ToString()+". contacted you from website (PATEL TEA PACKERS) visit admin panel for reply."

                };

                post_values.sendSmS(post_values);


                #endregion
            }
            catch (Exception x)
            {

            }
        }
    }
}