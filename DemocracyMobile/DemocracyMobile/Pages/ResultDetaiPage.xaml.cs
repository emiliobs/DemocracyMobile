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
    public partial class ResultDetaiPage : ContentPage
    {
        private Voting voting;
        public ResultDetaiPage(Voting voting)
        {
            InitializeComponent();

            this.voting = voting;

            this.Padding = Device.OnPlatform(new Thickness(10,20,10,10), new Thickness(10), new Thickness(10));

            candidatesListView.ItemTemplate = new DataTemplate(typeof(CandidateCell));
            candidatesListView.RowHeight = 30;

            winnerPhotoImage.Source = voting.Winner.PhotoFullPath;
            winnerPhotoImage.HeightRequest = 180;
            winnerPhotoImage.WidthRequest = 180;
            winnerNameLabel.Text = voting.Winner.FullName;
            winnerGradeLabel.Text = voting.Winner.GradeEdited;
            winnerGroupLabel.Text = voting.Winner.GroupEdited;
            descriptionLabel.Text = voting.Description;
            remarksLabel.Text = voting.Remarks;
            dateTimeStartLabel.Text = voting.DateTimeStartEdited;
            dateTimeEndLabel.Text = voting.DateTimeEndEdited;
            quantityVotesLabel.Text = voting.QuantityVotesEdited;
            candidatesListView.ItemsSource = voting.Candidates.OrderByDescending(c => c.QuantityVotes).ToList();


        }
    }
}
