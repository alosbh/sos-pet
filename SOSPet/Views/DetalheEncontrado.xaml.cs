using SOSPet.ViewModels;
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
    public partial class DetalheEncontrado : ContentPage
    {
        public string nome;
        public DetalheEncontrado(string Nome)
        {
            InitializeComponent();
            this.nome = Nome;
            this.BindingContext = new DetalheEncontradoViewModel(Nome);

        }
    }
}