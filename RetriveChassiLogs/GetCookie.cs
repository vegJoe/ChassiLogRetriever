using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Windows.Forms;

namespace RetriveChassiLogs
{
    class GetCookie
    {
        private string _userID;
        private string _password;
        public string ltpaToken2;
        private string _deviceID;
        private string _computerName;

        public GetCookie(string userID, string password, string deviceID, string computerName)
        {
            _userID = userID;
            _password = password;
            _deviceID = deviceID;
            _computerName = computerName;

            volvoLogin();
        }

        private void getSubscriptions()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://vida-prod.volvocars.biz/VidaAPI-0.1/rest/user/v1/subscriptions");
            request.Host = "vida-prod.volvocars.biz";
            request.KeepAlive = true;

            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
        }

        private void volvoLogin()
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;

            try
            {
                var postData = "Ecom_User_ID=" + _userID;
                postData += "&Ecom_Password=" + _password;
                postData += "&portletlogin=Login";
                var data = Encoding.ASCII.GetBytes(postData);

                request =  (HttpWebRequest)WebRequest.Create("https://vcamlogin.volvocars.biz/nidp/saml2/sso");
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Host = "vcamlogin.volvocars.biz";
                request.ContentLength = data.Length;
                request.AllowAutoRedirect = false;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                response = (HttpWebResponse)request.GetResponse();
                HttpStatusCode statuscode = response.StatusCode;
                string header = response.GetResponseHeader("Set-Cookie");

                string[] headers = header.Split(';',',');

                vidaLoginStepTwo(headers[0], headers[4]);
            }
            catch(WebException e)
            {

            }
        }

        private void vidaLoginStepTwo(string stringOne, string stringTwo)
        {
            try
            {
                string webRequest = "https://vcamlogin.volvocars.biz/nidp/saml2/idpsend?PID=https://vida-prod.volvocars.biz/samlsps&TARGET=https://vida-prod.volvocars.biz";
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(webRequest);
                request.Host = "vcamlogin.volvocars.biz";
                request.KeepAlive = true;
                request.Headers.Add("Cookie", stringOne + "; " + stringTwo);

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                
                int indexOfSAMLResponse = responseString.IndexOf("name=\"SAMLResponse\" value=") + 27;
                int indexOfSAMLResponseEnd = responseString.IndexOf("\n", indexOfSAMLResponse) - 4;
                string samlResponse = responseString.Substring(indexOfSAMLResponse, indexOfSAMLResponseEnd - indexOfSAMLResponse);

                int indexOfRelayState = responseString.IndexOf("RelayState") + 19;
                int indexOfRelayStateEnd = responseString.IndexOf("/>", indexOfRelayState) - 1;
                string relayState = responseString.Substring(indexOfRelayState, indexOfRelayStateEnd - indexOfRelayState);

                samlResponse = samlResponse.Replace("+", "%2b");                
                relayState = relayState.Replace(":", "%3a");
                relayState = relayState.Replace("/", "%2f");

                vidaLoginStepThree(samlResponse, relayState);
            }
            catch (WebException e)
            {                
                throw;
            }
            catch(Exception e)
            {
                MessageBox.Show("Could not get cookie. Check the password. Error: " + e);
            }
        }

        private void vidaLoginStepThree(string samlResponse, string relayState)
        {
            HttpWebRequest request = null;
            HttpWebResponse response = null;

            try
            {
                var postData = "SAMLResponse=" + samlResponse + "%3d&SAMLRequest=&RelayState=" + relayState;                
                var data = Encoding.ASCII.GetBytes(postData);

                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls |
                                                       SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

                request = (HttpWebRequest)WebRequest.Create("https://vida-prod.volvocars.biz/samlsps");
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Host = "vida-prod.volvocars.biz";
                request.ContentLength = data.Length;
                request.AllowAutoRedirect = false;

                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
                
                request = SetRequestHeader(request);
                response = (HttpWebResponse)request.GetResponse();
                HttpStatusCode statuscode = response.StatusCode;

                ltpaToken2 = response.Headers["Set-Cookie"];
            }
            catch (WebException e)
            {

                throw;
            }
            vidaLoginStepThree(ltpaToken2);
        }

        private void vidaLoginStepThree(string cookie)
        {
            try
            {
                string webRequest = "https://vida-prod.volvocars.biz/VidaAPI-0.1/rest/user/v1/subscriptions?";
                string jSessionID;

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{webRequest}deviceid={_deviceID}computername={_computerName}");
                request.AllowAutoRedirect = false;
                request.Host = "vida-prod.volvocars.biz";
                request.Accept = "application/json,application/xml,text/xml,application/*+xml";
                request.Headers.Add("Accept-Language: sv-SE");
                request.Headers.Add("Accept-Encoding: gzip,deflate");
                request.Headers.Add("UserID", _userID);
                request.Headers.Add("deviceid", _deviceID);
                request.Headers.Add("Cookie", cookie);
                request.Headers.Add("ischinasetup: N");
                request.Headers.Add("servertype: V15");

                var response = (HttpWebResponse)request.GetResponse();
                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                jSessionID = response.Headers["Set-Cookie"];                
                ltpaToken2 = ltpaToken2.Remove(ltpaToken2.IndexOf("==;") + 3);
                ltpaToken2 += ";" + jSessionID;                
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public HttpWebRequest SetRequestHeader(HttpWebRequest request)
        {
            request.UserAgent = "User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/43.0.2357.124 Safari/537.36";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
            request.Headers.Add("Accept-Encoding", "gzip, deflate");
            request.Headers.Add("Accept-Language", "en-US,en;q=0.8");
            request.Headers.Add("Cache-Control: max-age=0");
            return request;
        }
    }
}
