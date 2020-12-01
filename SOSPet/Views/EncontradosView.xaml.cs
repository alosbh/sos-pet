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

            MessagingCenter.Subscribe<Ocorrencia[]>(this, "SucessoListaOcorrencias", (ocorrencias) =>
            {

                foreach (var ocorr in ocorrencias)
                {
                    var pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(ocorr.latitude, ocorr.longitude),
                        Label = ocorr.descricao,
                        BindingContext = ocorr
                    };
                    pin.MarkerClicked += (sender, e) => {

                        Navigation.PushAsync(new DetalheEncontrado((Ocorrencia)pin.BindingContext));
                    };
                    Mapa.Pins.Add(pin);
                }
                ContagemOcorrencia.Text = ocorrencias.Length.ToString();



            });



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
                        Position = new Position(ocorr.latitude, ocorr.longitude),
                        Label = ocorr.descricao,
                        BindingContext = ocorr
                    };
                    pin.MarkerClicked += (sender, e) => {

                        Navigation.PushAsync(new DetalheEncontrado((Ocorrencia)pin.BindingContext));
                    };
                    Mapa.Pins.Add(pin);
                }
                ContagemOcorrencia.Text = ocorrencias.Length.ToString();


                
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