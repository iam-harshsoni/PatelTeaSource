using PatelTeaSource.Repository.GlobalParameterRepo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace PatelTeaSource.Classes
{
    public class MailClass
    {
        public MailClass()
          : this( new GlobalParametersRepository())
        {
        }

      
        private IGlobalParametersRepository _iGlobalParametersRepository;
        public MailClass( GlobalParametersRepository globalParametersRepository)
        {
            _iGlobalParametersRepository = globalParametersRepository;
        }

        string fromEmail = "", pwds = "";

        public void sendMails(string toEmail, string sub, string msg,bool isBody)
        {

            var fEmail = _iGlobalParametersRepository.SelectAll().Where(x => x.globalParamKey == "EmailAddress").FirstOrDefault();

            if (fEmail != null)
            {
                fromEmail = fEmail.globalParamValue; 
            }
            

            var fPwd = _iGlobalParametersRepository.SelectAll().Where(x => x.globalParamKey == "EmailPassword").FirstOrDefault();

            if (fPwd != null)
            {
                pwds = fPwd.globalParamValue;
            }
            

            using (MailMessage mm = new MailMessage(fromEmail, toEmail))
            {
                mm.Subject = sub;
                mm.Body = msg;

                mm.IsBodyHtml = isBody;
                 
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred =  new NetworkCredential(fromEmail, pwds);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["Port"]);
                smtp.Send(mm);
                // ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
            }

        }
    }
}