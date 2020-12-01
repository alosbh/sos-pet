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
    public partial class MenuLateralView : ContentPage
    {
        public MenuLateralView()
        {
            InitializeComponent();            
        }        
        private void IrTelaEncontrados(object sender, EventArgs e)
        {
             Navigation.PushAsync(new EncontradosView());
        }
        private void IrTelaHome(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MasterDetailView());
        }
        private void IrTelaSobre(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SobreView());
        }
        private void IrTelaOcorrencias(object sender, EventArgs e)
        {
            Navigation.PushAsync(new OcorrenciasView());
        }
        private void IrTelaDados(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DadosView());
        }
    }
}