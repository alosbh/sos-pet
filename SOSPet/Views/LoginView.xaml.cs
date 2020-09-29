using SOSPet.Models;
using SOSPet.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SOSPet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<LoginException>(this, "FalhaLogin", async (exc) =>
            {
                await DisplayAlert("Login", exc.Message, "ok");
            });

            MessagingCenter.Subscribe<Login>(this, "SucessoLogin", (login) =>
            {
                DisplayAlert("Login", String.Format(
                   @"Usuario:{0}
Senha:{1}
", login.email, login.senha), "ok");

                MessagingCenter.Send<Login>(login, "NavegarInicial");

            });

            MessagingCenter.Subscribe<CadastroView>(this, "irCadastro", (tela) =>
            {
                Navigation.PushAsync(tela);
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Login>(this, "SucessoLogin");
            MessagingCenter.Unsubscribe<LoginException>(this, "FalhaLogin");
            MessagingCenter.Unsubscribe<CadastroView>(this, "irCadastro");
        }
    }
}