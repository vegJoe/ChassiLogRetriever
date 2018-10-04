using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace RetriveChassiLogs
{
    class JSonCreater : Form1
    {
        private int _vehicleNumber = 0;

        public void createJson(string post, string user, string cookie, ref int statusReturn, ref int vehicleNumberReturn)
        {
            HttpWebRequest req = null;
            HttpWebResponse res = null;
            HttpStatusCode responseCode;
            ASCIIEncoding encoding = new ASCIIEncoding();
            int vehicleNumber = _vehicleNumber;
                try
                {
                    Uri uri = new Uri(post);
                    req = (HttpWebRequest)WebRequest.Create(uri);
                    byte[] bytePost = encoding.GetBytes(post);
                    req.ContentLength = bytePost.Length;
                    req.Method = "POST";

                    req.Accept = "application/json,application/xml,text/xml,application/*xml";
                    req.ContentType = "application/json";
                    req.Headers.Add("Accept-Language", "sv-SE");
                    req.Headers.Add("Accept-Encoding", "gzip,deflate");
                    req.Headers.Add("userID", user);
                    req.Headers.Add("Cookie", cookie);
                    req.Host = "vida-prod.volvocars.biz";
                    req.AllowAutoRedirect = false;

                    Stream newStream = req.GetRequestStream();
                    newStream.Write(bytePost, 0, bytePost.Length);
                    newStream.Close();

                    res = (HttpWebResponse)req.GetResponse();
                    responseCode = res.StatusCode;
                    int statusCode = (int)res.StatusCode;
                    string contenttype = res.ContentType;
                    res.Close();

                    statusReturn = statusCode;
                    vehicleNumberReturn = vehicleNumber;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Something went wrong when sending POST string.\n Error: " + e.ToString());
                    throw;
                }
                _vehicleNumber++;
        }
        public string formatCookie(string cookie)
        {
            if (cookie.StartsWith("Cookie: "))
            {
                cookie = cookie.Remove(0, 8);
            }
            return cookie;
        }
    }
}
