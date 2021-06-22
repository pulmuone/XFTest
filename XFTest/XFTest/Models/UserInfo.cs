using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XFTest.Models
{
    public class UserInfo
    {

        [JsonProperty("user_code")]
        public string UserCode { get; set; }

        [JsonProperty("user_name")]
        public string UserName { get; set; }


        [JsonProperty("user_phone")]
        public string UserPhone { get; set; }

        [JsonProperty("user_car_num", NullValueHandling = NullValueHandling.Ignore)]
        public string UserCarNum { get; set; }

        [JsonProperty("plt_code")]
        public string PltCode { get; set; }

        [JsonProperty("plt_name")]
        public string PltName { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }


        [JsonProperty("listCnt")]
        public string ListCnt { get; set; }
    }
}
