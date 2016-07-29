using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemocracyMobile.Cells
{
  public  class VotingCell : ViewCell
    {
        public VotingCell()
        {
            var photoImage = new Image
            {
                HeightRequest = 150,
                WidthRequest = 150,
            };

            photoImage.SetBinding(Image.SourceProperty, new Binding("User.PhotoFullPath"));

            var fullNameLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
            };

            fullNameLabel.SetBinding(Label.TextProperty, new Binding("User.FullName"));

            var gradeLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            gradeLabel.SetBinding(Label.TextProperty, new Binding("User.GradeEdited"));

            var groupLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            groupLabel.SetBinding(Label.TextProperty, new Binding("User.GroupEdited"));

            var left = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = {
                    photoImage,
                },
            };

            var right = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    fullNameLabel, gradeLabel, groupLabel,
                },
            };

            View = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    left, right,
                },
            };


        }
    }
}
