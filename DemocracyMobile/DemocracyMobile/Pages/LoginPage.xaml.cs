using DemocracyApp.Classes;
using DemocracyMobile.Classes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DemocracyMobile.Pages
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            this.Padding = Device.OnPlatform
                (
                   new Thickness(10, 20, 10, 10),
                   new Thickness(10),
                   new Thickness(10)
                );
            loginButton.Clicked += LoginButton_Clicked;
            registerButton.Clicked += RegisterButton_Clicked;
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(emailEntry.Text))
            {
                await DisplayAlert("Error", "You must enter an Email", "Acept");
                emailEntry.Focus();
                return;
            }

            if (!Utilities.IsValidEmail(emailEntry.Text))
            {
                await DisplayAlert("Error", "You must enter a Valid Email", "Acept");
                emailEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(passwordEntry.Text))
            {
                await DisplayAlert("Error", "You must enter a Password", "Acept");
                passwordEntry.Focus();
                return;
            }

            this.Login();
        }

        private async void Login()
        {
            waitActivityIndicator.IsRunning = true;

            //emvio una peticion de login si es valido em envia una respuesta:
            var loginRequest = new LoginRequest
            {
                Email = emailEntry.Text,
                Password = passwordEntry.Text,
            };

            var result = string.Empty;

            try
            {
                var jsonRequest = JsonConvert.SerializeObject(loginRequest);
                var httpContent = new StringContent(jsonRequest, System.Text.Encoding.UTF8, "application/json");
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://zulu-software.com");
                var url = "/Democracy/api/Users/Login";

                var response = await client.PostAsync(url, httpContent);
                if (!response.IsSuccessStatusCode)
                {
                    waitActivityIndicator.IsRunning = false;
                    await DisplayAlert("Error", "Wrong user or password ", "Acept");
                    passwordEntry.Text = string.Empty;
                    passwordEntry.Focus();
                    return;
                }
                result = await response.Content.ReadAsStringAsync();

            }
            catch (Exception ex)
            {
                waitActivityIndicator.IsRunning = false;
                await DisplayAlert("Error", ex.Message, "Acept");
                return;
            }

            waitActivityIndicator.IsRunning = false;
            var user = JsonConvert.DeserializeObject<User>(result);
            var userPassword = new UserPassword
            {
                CurrentPassword = passwordEntry.Text,
                Address = user.Address,
                FirstName = user.FirstName,
                Grade = user.Grade,
                Group = user.Group,
                LastName = user.LastName,
                Phone = user.Phone,
                Photo = user.Photo,
                UserId = user.UserId,
                UserName = user.UserName,
            };


            if (remembermeSwitch.IsToggled)
            {
                using (var db = new DataAccess())
                {
                    //la clase generica dataAccess con metodo insert pregunsta igresar que???-> un suerpassword class:
                    db.Insert<UserPassword>(userPassword);
                }
            }

            await Navigation.PushAsync(new HomePage(userPassword));
           // await DisplayAlert("OK","Welcome: " +user.FullName, "Acept");

        }
    }
}
