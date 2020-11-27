using SOSPet.Models;
using SOSPet.Views;
using System;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SOSPet
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginView());
        }

        protected override void OnStart()
        {
            MessagingCenter.Subscribe<Login>(this, "NavegarInicial", (login) => {

                MainPage = new NavigationPage(new MasterDetailView());

                Debug.WriteLine("Teste");

            });
        }
        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
