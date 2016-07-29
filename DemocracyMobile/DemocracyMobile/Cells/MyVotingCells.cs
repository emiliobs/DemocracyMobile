using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemocracyMobile.Cells
{
    public class MyVotingCells : ViewCell
    {
        public MyVotingCells()
        {
            var descriptionLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand,
                FontSize = 20,
                BackgroundColor = Color.White,
                TextColor = Color.Navy,
                FontAttributes = FontAttributes.Bold,
            };

            descriptionLabel.SetBinding(Label.TextProperty, new Binding("Description"));

            var remarksLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            remarksLabel.SetBinding(Label.TextProperty, new Binding("Remarks"));

            var dateTimeStartLabel = new Label
            {
                HorizontalOptions = LayoutOptions.StartAndExpand
            };

            dateTimeStartLabel.SetBinding(Label.TextProperty, new Binding("DateTimeStartEdited"));

            var dateTimeEndLabel = new Label
            {
                HorizontalOptions = LayoutOptions.EndAndExpand
            };

            dateTimeEndLabel.SetBinding(Label.TextProperty, new Binding("DateTimeEndEdited"));

            var line1 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = {
                    descriptionLabel,
                },
            };

            var line2 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = {
                    remarksLabel,
                },
            };

            var line3 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Children = {
                    dateTimeStartLabel, dateTimeEndLabel,
                },
            };

            View = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Children = {
                    line1, line2, line3,
                },
            };

        }
    }
}
