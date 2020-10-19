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
    public partial class CadastroView : ContentPage
    {
        public CadastroView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<Usuario>(this, "SucessoCadastro", (user) =>
            {
                DisplayAlert("Sucesso", "Cadastro realizado com sucesso!", "Ok");
                Navigation.PopAsync();
            });

            MessagingCenter.Subscribe<LoginException>(this, "FalhaCadastro", (e) => {

                DisplayAlert("Falha no Cadastro", e.Message, "Ok");
            });


        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Usuario>(this, "SucessoCadastro");
            MessagingCenter.Unsubscribe<LoginException>(this, "FalhaCadastro");
        }
    }
}