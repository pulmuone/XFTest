using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using XFTest.Models;

namespace XFTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            var result = await Services.HttpService.Instance.GetDataAsync();

            Console.WriteLine(result.AccessToken);

            Preferences.Set("AccessToken", result.AccessToken);
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {

            if(!Preferences.ContainsKey("AccessToken"))
            {
                return;
            }


           TodoItem item = new TodoItem
            {
                AccessToken = Preferences.Get("AccessToken", string.Empty),
                //AccessToken = "C5526FECC0F10042E053C0A80F1942B7",
                OrderCode = "8030802980",
                OrderItemNum = "000010",
                prod_code = "100617",
                Barcode = "MF00136648",
                ItemCnt = 99
            };
            //string json = JsonConvert.SerializeObject(item, settings);
            FormUrlEncodedContent request = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string> ("access_token",   Preferences.Get("AccessToken", string.Empty)),
                new KeyValuePair<string, string> ("order_code", "8030802980"),
                new KeyValuePair<string, string> ("order_item_num", "000010"),
                new KeyValuePair<string, string> ("prod_code", "100617"),
                new KeyValuePair<string, string> ("barcode", "MF00136648"),
                new KeyValuePair<string, string> ("item_cnt", "77" )
            });

            var result = await Services.HttpService.Instance.SaveDataAsync(request, true);
            Console.WriteLine(result);
        }
    }
}