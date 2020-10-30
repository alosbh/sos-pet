using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using Xamarin.Forms.Maps;
using System.Windows.Input;
using SOSPet.Services;

namespace SOSPet.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroEncontrado : ContentPage
    {
        public CadastroEncontrado()
        {
            InitializeComponent();
            GetActualLocationCommand = new Command(async () => await GetActualLocation());

        }
        //Center map in actual location 
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetActualLocationCommand.Execute(null);
        }

        public static readonly BindableProperty GetActualLocationCommandProperty =
            BindableProperty.Create(nameof(GetActualLocationCommand), typeof(ICommand), typeof(MainPage), null, BindingMode.TwoWay);

        public ICommand GetActualLocationCommand
        {
            get { return (ICommand)GetValue(GetActualLocationCommandProperty); }
            set { SetValue(GetActualLocationCommandProperty, value); }
        }

        async Task GetActualLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.High);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                     Mapa.MoveToRegion(MapSpan.FromCenterAndRadius(
                     new Position(location.Latitude, location.Longitude), Distance.FromMiles(0.3)));

                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", "Não foi possível localizar", "Ok");
            }
        }
    }
}