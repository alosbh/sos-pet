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
    }
}