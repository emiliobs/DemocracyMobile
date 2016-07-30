using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemocracyMobile.Cells
{
  public  class CandidateCell : ViewCell
    {
        public CandidateCell()
        {
            var candidateNameLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
            };

            candidateNameLabel.SetBinding(Label.TextProperty, new Binding("User.FullName"));

            var candidateVotesLabel = new Label
            {
                HorizontalOptions = LayoutOptions.End
            };

            candidateVotesLabel.SetBinding(Label.TextProperty, new Binding("QuantityVotes"));

            View = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    candidateNameLabel, candidateVotesLabel,
                },
            };

        }
    }
}
