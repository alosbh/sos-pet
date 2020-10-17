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
            //<meta-data android:name = "com.google.android.geo.API_KEY" android:value = "AIzaSyDeOU95k5fdg54ei2adWxd9WXm8xXEnmlA"/>
                   Mapa.MoveToRegion(MapSpan.FromCenterAndRadius(
                             new Position(-19.947316, -43.971500),
                             Distance.FromKilometers(0.5)));


            var pin = new Pin
            {
                Type = PinType.Place,
                Position = new Position(-19.947316, -43.971500),
                Label = "PRIMEIRO pin",

            };
            pin.MarkerClicked += (sender, e) => {

                Navigation.PushAsync(new DetalheEncontrado(pin.Label));
            };
            Mapa.Pins.Add(pin);
            var pin2 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(-19.944862, -43.974667),
                Label = "SEGUNDO pin",

            };
            pin2.MarkerClicked += (sender, e) => {

                Navigation.PushAsync(new DetalheEncontrado(pin2.Label));
            };
            Mapa.Pins.Add(pin2);

            var pin3 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(-19.947787, -43.968273),
                Label = "TERCEIRO pin",

            };
            pin3.MarkerClicked += (sender, e) => {

                Navigation.PushAsync(new DetalheEncontrado(pin3.Label));
            };
            Mapa.Pins.Add(pin3);
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