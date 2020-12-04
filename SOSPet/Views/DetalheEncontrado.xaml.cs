using SOSPet.Models;
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
        public DetalheEncontradoViewModel ViewModel { get; set; }
        public Ocorrencia Ocorr;
        public DetalheEncontrado(Ocorrencia ocorrencia)
        {
            InitializeComponent();
            this.Ocorr = ocorrencia;

            this.ViewModel = new DetalheEncontradoViewModel(ocorrencia);
            this.BindingContext = this.ViewModel;
        }
    }
}