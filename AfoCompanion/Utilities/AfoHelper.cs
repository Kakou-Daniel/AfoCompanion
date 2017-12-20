using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using static AfoCompanion.Utilities.JsonHelperWC;

namespace AfoCompanion.Utilities
{
    public class AfoHelper
    {
        public static List<NWM> GetWcMessages()
        {
            Random rand = new Random();
            int pick = rand.Next(1, 6); //>= 1 and < 6
            string idName = "AfoCompanionSlave" + pick.ToString();
            LoginParams loginParams = new LoginParams(idName, "pantsonfire9");
            var myJson = JsonConvert.SerializeObject(loginParams);

            var myUri = "avafight.appspot.com";
            string ctt = Uri.EscapeUriString(myJson);

            string myUrl = @"http://" + myUri + "/login?ACT=1&CTT=" + ctt;
            var request = WebRequest.Create(myUrl);

            var response = (HttpWebResponse)request.GetResponse();

            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                string text = sr.ReadToEnd();
                var worldMessages = JsonConvert.DeserializeObject<JsonHelperWC.RootObject>(text);
                return worldMessages.HB.NWM;
            }
        }

        public static JsonHelperStats.RootObject GetStats(string target)
        {
            target = target.Replace("#", "%23");

            Random rand = new Random();
            int pick = rand.Next(1, 6); //>= 1 and < 6
            string idName = "AfoCompanionSlave" + pick.ToString();
            LoginParams loginParams = new LoginParams(idName, "pantsonfire9");
            var myJson = JsonConvert.SerializeObject(loginParams);

            var myUri = "avafight.appspot.com";
            string ctt = Uri.EscapeUriString(myJson);

            string myUrl = @"http://" + myUri + "/login?ACT=1&CTT=" + ctt;
            var request = WebRequest.Create(myUrl);
            var temp = (HttpWebResponse)request.GetResponse();

            using (var sr1 = new StreamReader(temp.GetResponseStream()))
            {
                string text1 = sr1.ReadToEnd();
                var test = JsonConvert.DeserializeObject<JsonHelperWC.RootObject>(text1);

                StatParams statParams = new StatParams(test.HB.TS, target);

                var statJson = JsonConvert.SerializeObject(statParams);
                string ctt2 = Uri.EscapeUriString(statJson);

                ctt2 = ctt2.Replace(",", "");

                string myUrl2 = @"http://" + myUri + "/check_avatar?ACT=4&CTT=%7B%22TS%22%3A"+ test.HB.TS.ToString()+"%2C%22NAME%22%3A%22"+target+"%22%7D";
                var request2 = (HttpWebRequest)WebRequest.Create(myUrl2);
                request2.UserAgent = "libwww-perl/6.15";
                request2.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                request2.Headers.Add("Accept-Language", "fr,fr-FR;q=0.8,en-US;q=0.5,en;q=0.3");
                request2.Headers.Add("Accept-Encoding", "gzip, deflate");
                request2.KeepAlive = true;
                request2.Headers.Add("Upgrade-Insecure-Requests", "1");
                request2.Headers["Cookie"] = temp.Headers["Set-Cookie"];

                var temp2 = (HttpWebResponse)request2.GetResponse();
                using (var sr = new StreamReader(temp2.GetResponseStream()))
                    {
                        string text = sr.ReadToEnd();
                        var stats = JsonConvert.DeserializeObject<JsonHelperStats.RootObject>(text);
                        return stats;
                    }
                
                
            }
           
        }

    }
}