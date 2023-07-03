using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace PatelTeaSource.Classes
{
    public class PaymentGatewayMain
    {
        private string CreateToken(string message, string secret)
        {
            secret = secret ?? "";
            var encoding = new System.Text.ASCIIEncoding();
            byte[] keyByte = encoding.GetBytes(secret);
            byte[] messageBytes = encoding.GetBytes(message);

            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                return Convert.ToBase64String(hashmessage);
            }
        }
        public static void Main(string[] args)
        {

            string secret = "<your_secret_key>";
            string data = "";

            SortedDictionary<string, string> formParams = new SortedDictionary<string, string>();
            formParams.Add("appId", "<your_app_id>");
            formParams.Add("orderId", "FEX101");
            formParams.Add("orderAmount", "10.00");
            formParams.Add("orderCurrency", "INR");
            formParams.Add("orderNote", "Test payment");
            formParams.Add("customerName", "Customer Name");
            formParams.Add("customerPhone", "9900000085");
            formParams.Add("customerEmail", "test@cashfree.com");
            formParams.Add("returnUrl", "http://example.com");
            formParams.Add("notifyUrl", "http://example.com");
            foreach (var kvp in formParams)
            {
                data = data + kvp.Key + kvp.Value;
            }

            PaymentGatewayMain n = new PaymentGatewayMain();
            string signature = n.CreateToken(data, secret);
            Console.WriteLine(signature);
        }
    }

}