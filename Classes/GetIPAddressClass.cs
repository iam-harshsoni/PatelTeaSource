using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets; 
using System.Web.UI.WebControls;
using System.Web;

namespace PatelTeaSource.Classes
{
    public class GetIPAddressClass
    { 

        public string GetIP()
        {
            string ipaddress;
            ipaddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (ipaddress == "" || ipaddress == null)
                ipaddress =
                    HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            return ipaddress;



             
        }
    }
}