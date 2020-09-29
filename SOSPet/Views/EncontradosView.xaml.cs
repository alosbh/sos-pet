using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SOSPet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EncontradosView : ContentPage
    {
        public EncontradosView()
        {
            InitializeComponent();
            Mapa.MoveToRegion(MapSpan.FromCenterAndRadius(
                             new Position(-19.947316, -43.971500),
                             Distance.FromKilometers(5)));


            var pin = new Pin
            {
                Type = PinType.Place,
                Position = new Position(-19.947316, -43.971500),
                Label = "Teste1 Marcador",

            };

            Mapa.Pins.Add(pin);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<CadastroEncontrado>(this, "irCadastroEncontrado", (tela) =>
            {
                Navigation.PushAsync(tela);
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<CadastroEncontrado>(this, "irCadastroEncontrado");
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastroEncontrado());
        }
    }
}