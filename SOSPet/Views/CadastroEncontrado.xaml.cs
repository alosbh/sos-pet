using PinClickDemo;
using SOSPet.Models;
using SOSPet.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Markup;
using Xamarin.Forms.Xaml;

namespace SOSPet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroEncontrado : ContentPage
    {
        //private ExtendedMap Mapa;
        //public ViewModels = new CadastroEncontradoViewModel();
        public CadastroEncontrado()
        {
            InitializeComponent();

            //this.BindingContext = new CadastroEncontradoViewModel();
            //Mapa = new ExtendedMap();
            //Mapa.Tap += Mapa_OnTap;
            //Mapa.HeightRequest = 200;
            //Mapa.IsShowingUser = true;

            //Content = Mapa;
        }

        private void Mapa_OnTap(object sender, TapEventArgs e)
        {
            var pin = new Pin
            {
                Type = PinType.Place,
                Position = e.Position,
                Label = "Cliked",
                Address = e.Position.Latitude + " X " + e.Position.Latitude,
            };

            foreach (var p in Mapa.Pins){
                Mapa.Pins.Remove(p);
            }

            Mapa.Pins.Add(pin);

            MessagingCenter.Send<Pin>(pin, "NovoCliquePin");

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
            MessagingCenter.Subscribe<object>(this, "MapaFull", (obj) => {
                irParaLocation();
            });

            MessagingCenter.Subscribe<Ocorrencia>(this, "SucessoCadastroEncontrado", (user) =>
            {
                DisplayAlert("Sucesso", "Cadastro realizado com sucesso!", "Ok");
                Navigation.PopAsync();
            });
        }

        protected override void OnDisappearing()
        {
            MessagingCenter.Unsubscribe<object>(this, "MapaFull");
            MessagingCenter.Unsubscribe<Ocorrencia>(this, "SucessoCadastroEncontrado");
        }

       
    }
}