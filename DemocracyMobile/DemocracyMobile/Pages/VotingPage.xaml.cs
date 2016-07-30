using DemocracyApp.Classes;
using DemocracyMobile.Cells;
using DemocracyMobile.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DemocracyMobile.Pages
{
    public partial class VotingPage : ContentPage
    {
        private UserPassword user;
        private Voting voting;
        public VotingPage(UserPassword user, Voting voting)
        {
            InitializeComponent();

            this.user = user;
            this.voting = voting;

            this.Padding = Device.OnPlatform
                (
                    new Thickness(10,20,10,10),
                    new Thickness(10),
                    new Thickness(10)
                );


            candidatesListView.ItemTemplate = new DataTemplate(typeof(VotingCell));
            candidatesListView.RowHeight=160;
            candidatesListView.ItemsSource = voting.Candidates;
            candidatesListView.ItemSelected += CandidatesListView_ItemSelected;

            
        }

        private async void CandidatesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var candidate = (Candidate)e.SelectedItem;
            var answer = await DisplayAlert("Confirm",$"Are you sure to vote for: {candidate.User.FullName}","Yes","No");

            if (!answer)
            {
                return;
            }

            waitActivityIndicator.IsRunning = true;

            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://zulu-software.com");
                var url = $"/Democracy/api/Votings/{this.user.UserId}/{candidate.CandidateId}/{this.voting.VotingId}";

                var response = await client.PostAsync(url, null);

                if (!response.IsSuccessStatusCode)
                {
                    waitActivityIndicator.IsRunning = false;
                    await DisplayAlert("Error","Error trying to vote","Acept");
                    return;
                }
            }
            catch (Exception ex)
            {

                waitActivityIndicator.IsRunning = false;
                await DisplayAlert("Error", ex.Message,"Acept");
                return;
            }

            waitActivityIndicator.IsRunning = false;

            await DisplayAlert("Confirm", "You Vote was taken Successfully", "Acept");
            await Navigation.PopAsync();
        }
    }
}
