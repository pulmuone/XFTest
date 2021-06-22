using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using XFTest.Models;

namespace XFTest.Services
{
    public class HttpService
    {
        private static readonly HttpService instance = new HttpService();

        public static HttpService Instance
        {
            get
            {
                return instance;
            }
        }

        public async Task<string> SendRequest()
        {
            StringBuilder sbUrl = new StringBuilder();
            sbUrl.Append("http://192.168.15.25:8082/appcheck/login.do");
            sbUrl.Append(string.Format("?id={0}", "01039932763"));
            //sbUrl.Append("&optionNo=");
            //sbUrl.Append("&corpNo=");

            WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };
            string result = string.Empty;

            try
            {
                //1. 서비스 데이터 조회
                result = await wc.DownloadStringTaskAsync(sbUrl.ToString()).ConfigureAwait(false);
            }
            catch (Exception e)
            {

            }
            finally
            {
                wc.Dispose();
            }

            return result;
        }


        public async Task<String> SaveDataAsync(FormUrlEncodedContent content, bool isNewItem = false)
        {
            string result = string.Empty;
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            try
            { 
                using (var client = new HttpClient())
                {
                    Uri uri = new Uri("http://192.168.15.25:8082/appcheck/update_item_cnt.do");
                    HttpResponseMessage response = null;

                    if (isNewItem)
                    {
                        response = await client.PostAsync(uri, content);
                    }
                    else
                    {
                        response = await client.PutAsync(uri, content);
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public async Task<UserInfo> GetDataAsync()
        {
            string result = string.Empty;
            UserInfo userInfo = new UserInfo();
            
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            try
            {
                StringBuilder sbUrl = new StringBuilder();
                sbUrl.Append("http://192.168.15.25:8082/appcheck/login.do");
                sbUrl.Append(string.Format("?id={0}", "01039932763"));

                using (var client = new HttpClient())
                {
                    Uri uri = new Uri(sbUrl.ToString());
                    HttpResponseMessage response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        result = await response.Content.ReadAsStringAsync();
                        JObject jo = new JObject();
                        jo = JObject.Parse(result);
                        Console.WriteLine(jo["result"]["user_info"].ToString());

                        userInfo = JsonConvert.DeserializeObject<UserInfo>(jo["result"]["user_info"].ToString(), settings);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return userInfo;
        }
    }

}
