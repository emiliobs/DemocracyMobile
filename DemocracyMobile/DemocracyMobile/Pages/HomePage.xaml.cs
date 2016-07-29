using DemocracyApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DemocracyMobile.Pages
{
    public partial class HomePage : ContentPage
    {
        private UserPassword user;
        
        public HomePage(UserPassword user)
        {
            InitializeComponent();

            this.Padding = Device.OnPlatform
               (
                  new Thickness(10, 20, 10, 10),
                  new Thickness(10),
                  new Thickness(10)
               );

            this.user= user;
            mySettingsButton.Clicked += MySettingsButton_Clicked;
            myVotingsButton.Clicked += MyVotingsButton_Clicked;

        }

        private async void MyVotingsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MyVotingPage(this.user));
        }

        private async void MySettingsButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MySettingPage(this.user));
        }

        protected override void OnAppearing()
        {
            userNameLabel.Text = user.FullName;

            photoImage.Source = user.PhotoFullPath;          

            photoImage.HeightRequest = 280;
            photoImage.WidthRequest = 280;

           
        }
    }
}
