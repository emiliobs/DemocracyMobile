
using DemocracyApp.Classes;
using DemocracyMobile.Classes;
using DemocracyMobile.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace DemocracyMobile
{
    public class App : Application
    {
        public App()
        {

            //Aqui pregunto si hay o no usuario en la BD:
            //utilizo el using para que cierre la conexion de forma automatica:

            // The root page of your application
            using (var db = new DataAccess())
            {
                var user = db.First<UserPassword>(false);

                if (user == null)
                {
                    MainPage = new NavigationPage(new LoginPage());
                }
                else
                {
                    MainPage = new NavigationPage(new HomePage(user));
                }
            }

           
         
          
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
