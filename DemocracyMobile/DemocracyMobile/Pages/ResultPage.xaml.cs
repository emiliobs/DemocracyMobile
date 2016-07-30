using DemocracyMobile.Cells;
using DemocracyMobile.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DemocracyMobile.Pages
{
    public partial class ResultPage : ContentPage
    {
        public ResultPage()
        {
            InitializeComponent();

            this.Padding = Device.OnPlatform( new Thickness(10,20,10,10), new Thickness(10),new  Thickness(10));

            this.LoadResult();

            resultListView.ItemTemplate = new DataTemplate(typeof(ResultCell));
            resultListView.RowHeight = 160;

            resultListView.ItemSelected += ResultListView_ItemSelected;

        }

        private async void ResultListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new ResultDetaiPage((Voting)e.SelectedItem));
        }

        private async void LoadResult()
        {
            waitActivityIndicator.IsRunning = true;
            var result = string.Empty; ;
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://zulu-software.com");
                var url ="/Democracy/api/Votings";
                var response = await client.GetAsync(url);
                 result = response.Content.ReadAsStringAsync().Result;

                if (string.IsNullOrEmpty(result))
                {
                    waitActivityIndicator.IsRunning = false;
                    await DisplayAlert("Error", "No Response Form Server.","Acept");
                    return; 
                }
            }
            catch (Exception ex)
            {
                waitActivityIndicator.IsRunning = false;
                await DisplayAlert("Error",ex.Message,"Result");
                return;
            }


            var results = JsonConvert.DeserializeObject<List<Voting>>(result);
            resultListView.ItemsSource = results;
            waitActivityIndicator.IsRunning = false;
        }
    }
}
