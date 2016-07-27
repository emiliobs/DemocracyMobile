using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DemocracyMobile.Pages
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();

            this.Padding = Device.OnPlatform
                (
                   new Thickness(10, 20, 10, 10),
                   new Thickness(10),
                   new Thickness(10)
                );
            saveButton.Clicked += SaveButton_Clicked;
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
           // voy video 6.!!
        }
    }
}
