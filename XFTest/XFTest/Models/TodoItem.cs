using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace XFTest.Models
{
    public class TodoItem
	{
		[JsonProperty("access_token")]
		public string AccessToken { get; set; }

		[JsonProperty("order_code")]
		public string OrderCode { get; set; }

		[JsonProperty("order_item_num")]
		public string OrderItemNum { get; set; }

		[JsonProperty("prod_code ")]
		public string prod_code{ get; set; }

		[JsonProperty("barcode ")]
		public string Barcode { get; set; }

		[JsonProperty("item_cnt ")]
		public int ItemCnt { get; set; }
	}
}
