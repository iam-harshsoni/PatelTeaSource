using PatelTeaSource.Classes;
using PatelTeaSource.Model;
using PatelTeaSource.Repository.FeedBackRepo;
using PatelTeaSource.Repository.GlobalParameterRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PatelTeaSource.CS
{
    public partial class FeedBack : System.Web.UI.Page
    {
        public FeedBack()
          : this(new FeedbackRepository(),new GlobalParametersRepository())
        {
        }

        private IFeedbackRepository _iFeedbackRepository;
        
        public FeedBack(FeedbackRepository feedbackRepository,GlobalParametersRepository globalParametersRepository)
        {
            _iFeedbackRepository =feedbackRepository;
        }

        int passCode = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                passCode = Convert.ToInt32(Request.QueryString["fcd"]);
                if (passCode != 0)
                {


                    if (Convert.ToInt32(Request.Cookies["feed"]) == passCode)
                    {
                        feedBackAlreadyDone.Visible = true;
                        sendFeedBack.Visible = false;
                        feedbackDone.Visible = false;
                    }
                    else
                    {

                        var data = _iFeedbackRepository.SelectAll();

                        if (data != null)
                        {
                            foreach (var item in data)
                            {
                                if (item.code == passCode)
                                {
                                    txtName.Text = item.fname;
                                    txtEmail.Text = item.email;

                                    txtName.Enabled = false;
                                    txtEmail.Enabled = false;

                                    txtNotes.Focus();

                                    feedbackDone.Visible = false;
                                    sendFeedBack.Visible = true;
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void submits_Click(object sender, EventArgs e)
        {
            MailClass sendm = new MailClass();
            sendm.sendMails(txtEmail.Text.Trim().ToString(), "For Contacting Patel Tea Packers", "Thanks for showing your interest in Patel Tea Packers. One of our team memeber will contact you soon.", false);
            addToFeed();
            feedBackAlreadyDone.Visible = false;
            sendFeedBack.Visible = false;
            feedbackDone.Visible = true;

        }

        public void addToFeed()
        {
            try
            {
                passCode = Convert.ToInt32(Request.QueryString["fcd"]);

                var databtId = _iFeedbackRepository.SelectAll().Where(x => x.code == passCode).FirstOrDefault();

                databtId.fname = txtName.Text.Trim().ToString();
                databtId.email = txtEmail.Text.Trim().ToString();
                databtId.msg = txtNotes.Text.Trim().ToString();
                databtId.udate = DateTime.Now;
                databtId.status = 0;

                _iFeedbackRepository.Add(databtId);

                #region Create Cookie
                HttpCookie yourListCookie = new HttpCookie("feed", passCode.ToString());

                // The cookie will exist for 7 days
                yourListCookie.Expires = DateTime.Now.AddDays(1);

                // Write the Cookie to your Response
                Response.Cookies.Add(yourListCookie);

                #endregion


            }
            catch (Exception x)
            {

            }
        }
    }
}