using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Services;

namespace PatelTeaSource.Classes
{

    public class model_messge
    {

        public string api_key
        {

            get;

            set;

        }

        public string api_token
        {

            get;

            set;

        }

        public string sender
        {

            get;

            set;

        }

        public string receiver
        {

            get;

            set;

        }

        public string msgtype
        {

            get;

            set;

        }

        public string sms
        {

            get;

            set;

        }
        
        public void sendSmS(model_messge postValue)
        {
           

            HttpWebRequest request;

            //string url = "https://www.bulksmsplans.com/Restapis/send_sms";
            string url = "http://www.bulksmsplans.com/api/send_sms";

            string responseBody = string.Empty;

            string requestBody = string.Empty;

            request = (HttpWebRequest)HttpWebRequest.Create(url);

            requestBody = JsonConvert.SerializeObject(postValue);

            request.Accept = "application/json";

            request.ContentType = "application/json;charset=utf-8";

            byte[] byteData = UTF8Encoding.UTF8.GetBytes(requestBody.ToString());



            request.Method = "POST";

            request.ContentLength = byteData.Length;

            using (Stream postStream = request.GetRequestStream())
            {

                postStream.Write(byteData, 0, byteData.Length);

            }



            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {

                using (var reader = new

                    StreamReader(response.GetResponseStream()))
                {

                    responseBody = reader.ReadToEnd();

                }

            }
            //error from this code
        }


        public string getMethodSMS(string rec, string mes)
        {
            string url = "https://www.bulksmsplans.com/Restapis/send_sms?api_key=Kishanunjha9393@gmail.com&api_token=04b5290921dd7c64547f7afdd41682ee1541424839&sender=DEMOSM&receiver=" + rec + "&msgtype=1&sms=" + mes;

            return url;

            
        }

       // string _respose = GetResponse(_url);

        [WebMethod]
        public string GetResponse(string sURL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL); request.MaximumAutomaticRedirections = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse(); Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8); string sResponse = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                return sResponse;
            }
            catch
            {
                //lblMsg.Text = "There might be an Internet connection issue..";
                return "";
            }
        }

    }

}