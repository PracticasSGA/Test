using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Test.Resources
{
    class Request
    {
        private static String web = "http://192.168.1.7/sga/modules/mobile/test.php";

        public static String get(Dictionary<string, string> parameters)
        {
            String responseFromServer;
            WebRequest request = WebRequest.Create(Request.web);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            responseFromServer = reader.ReadToEnd();
            Console.WriteLine(responseFromServer);
            reader.Close();
            response.Close();

            return responseFromServer;
        }

        public static String post(Dictionary<string, string> parameters)
        {
            WebRequest request = WebRequest.Create(Request.web);
            request.Method = "POST";
            String postData = Request.generateParameters(parameters);
            Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse response = request.GetResponse();
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }

        private static String generateParameters(Dictionary<string, string> parameters)
        {
            if (parameters == null) return ""; 
            String data = "";
            foreach (var parameter in parameters)
            {
                data += (parameter.Key + "=" + parameter.Value + "&");
            }
            data.Remove(data.Length - 1);
            return data;
        }
    }
}
