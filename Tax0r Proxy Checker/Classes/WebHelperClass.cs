using System;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace Tax0r_Proxy_Checker.Classes
{
    class WebHelperClass
    {

        public bool PingProxy(string proxy, int timeout)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://api.ipify.org?format=json");
            WebProxy webProxy = new WebProxy(proxy);

            webRequest.Proxy = webProxy;
            webRequest.Timeout = timeout;
            try
            {
                WebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                string resp = webResponse.GetResponseStream().ToString();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
