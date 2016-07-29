using DemocracyApp.Classes;
using DemocracyMobile.Cells;
using DemocracyMobile.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
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

            
        }

        
    }
}
