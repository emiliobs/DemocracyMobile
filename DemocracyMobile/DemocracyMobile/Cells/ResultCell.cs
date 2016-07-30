using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemocracyMobile.Cells
{
   public class ResultCell : ViewCell
    {
        public ResultCell()
        {
            var photoImage = new Image
            {
                HeightRequest = 150,
                WidthRequest = 150,
            };

            photoImage.SetBinding(Image.SourceProperty, new Binding("Winner.PhotoFullPath"));

            var descriptionLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
            };

            descriptionLabel.SetBinding(Label.TextProperty, new Binding("Description"));

            var remarksLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
            };

            remarksLabel.SetBinding(Label.TextProperty, new Binding("Remarks"));

            var winnerLabel = new Label
            {
                Text = "Winner",
                HorizontalOptions = LayoutOptions.StartAndExpand,
            };

            var fullNameLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                FontSize = 20,
                FontAttributes = FontAttributes.Bold,
            };

            fullNameLabel.SetBinding(Label.TextProperty, new Binding("Winner.FullName"));

            var gradeLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            gradeLabel.SetBinding(Label.TextProperty, new Binding("Winner.GradeEdited"));

            var groupLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            groupLabel.SetBinding(Label.TextProperty, new Binding("Winner.GroupEdited"));

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
                    descriptionLabel, remarksLabel, winnerLabel, fullNameLabel, gradeLabel, groupLabel,
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
