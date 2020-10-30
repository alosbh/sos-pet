using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SOSPet.Services;
using SOSPet.Models;
using System.Diagnostics;

namespace SOSPet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EncontradosView : ContentPage
    {
        public System.Collections.ObjectModel.ObservableCollection<Ocorrencia> Ocorrencias { get; set; }
        public EncontradosView()
        {
            InitializeComponent();

            this.Ocorrencias = new System.Collections.ObjectModel.ObservableCollection<Ocorrencia>();

            irParaLocation();
            


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

        public async void irParaLocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                    Mapa.MoveToRegion(MapSpan.FromCenterAndRadius(
                             new Position(location.Latitude, location.Longitude),
                             Distance.FromKilometers(0.5)));
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<CadastroEncontrado>(this, "irCadastroEncontrado", (tela) =>
            {
                Navigation.PushAsync(tela);
            });

            MessagingCenter.Subscribe<Ocorrencia[]>(this, "SucessoListaOcorrencias", (ocorrencias) =>
            {

                foreach (var ocorr in ocorrencias)
                {
                    var pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(ocorr.localizacao_lat, -ocorr.localizacao_long),
                        Label = ocorr.descricao,

                    };
                    pin.MarkerClicked += (sender, e) => {

                        Navigation.PushAsync(new DetalheEncontrado(pin.Label));
                    };
                    Mapa.Pins.Add(pin);
                }


                
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<CadastroEncontrado>(this, "irCadastroEncontrado");
            MessagingCenter.Unsubscribe<Ocorrencia[]>(this, "SucessoListaOcorrencias");
        }

        
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastroEncontrado());
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProcuradosView());
        }
    }
}