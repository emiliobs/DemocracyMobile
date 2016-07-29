using DemocracyApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;

using Xamarin.Forms;
using Newtonsoft.Json;
using DemocracyMobile.Classes;
using DemocracyMobile.Cells;

namespace DemocracyMobile.Pages
{
    public partial class MyVotingPage : ContentPage
    {
        private UserPassword user;
        public MyVotingPage(UserPassword user)
        {
            InitializeComponent();

            this.Padding = Device.OnPlatform
                (
                    new Thickness(10,20,10,10),
                    new Thickness(10),
                    new Thickness(10)
                );

            this.user = user;

            myVotingsListView.ItemTemplate = new DataTemplate(typeof(MyVotingCells));
            myVotingsListView.RowHeight = 80;

            myVotingsListView.ItemSelected += MyVotingsListView_ItemSelected;
           
        }

        private async void MyVotingsListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new VotingPage(this.user,(Voting)e.SelectedItem));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.LoadVotings();
        }

        private async void LoadVotings()
        {
            waitActivityIndicator.IsRunning = true;

            var result = string.Empty;

            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://zulu-software.com");
                var url = $"/Democracy/api/Votings/{this.user.UserId}";
                var response = await client.GetAsync(url);

                result = response.Content.ReadAsStringAsync().Result;

                if (string.IsNullOrEmpty(result))
                {
                    waitActivityIndicator.IsRunning = false;
                    await DisplayAlert("Error","No Response Form Server","Acept");
                    return;
                }

                                
            }
            catch (Exception ex)
            {
                waitActivityIndicator.IsRunning = false;
                await DisplayAlert("Error", ex.Message , "Acept");
                return;

            }


            var myVotings = JsonConvert.DeserializeObject<List<Voting>>(result);
            myVotingsListView.ItemsSource = myVotings;
            waitActivityIndicator.IsRunning = false;
        }
    }
}
