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
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace SOSPet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroEncontrado : ContentPage
    {
        

        public CadastroEncontrado()
        {
            InitializeComponent();

            taper.Tapped += async (sender, args) =>
            {

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    AllowCropping = true,
                    Directory = "Test",
                    SaveToAlbum = true,
                    CompressionQuality = 75,
                    CustomPhotoSize = 50,
                    PhotoSize = PhotoSize.MaxWidthHeight,
                    MaxWidthHeight = 400,
                    DefaultCamera = CameraDevice.Front
                });

                if (file == null)
                    return;
                var newframe = new Frame() { CornerRadius = 8 , Padding=0};


                var fotografia = new Image() {

                    Source = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        file.Dispose();
                        return stream;
                    })

                 };
                newframe.Content = fotografia;
                
                imgs_layout.Children.Add(newframe);

                scroller.ScrollToAsync(icone_camera, ScrollToPosition.MakeVisible, false);





            };

            
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

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            //BindingContext should not be null at this point
            // and you may add your code here.
        }
    }
}