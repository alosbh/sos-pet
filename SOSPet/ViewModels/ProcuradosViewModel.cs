using SOSPet.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SOSPet.ViewModels
{
    class ProcuradosViewModel : BaseViewModel
    {
        public ICommand CadastrarProcurado;

        public CadastroProcurado telaCadastro;
        public ProcuradosViewModel()
        {
            telaCadastro = new CadastroProcurado();
            CadastrarProcurado = new Command(() => {

                MessagingCenter.Send<CadastroProcurado>(telaCadastro, "irCadastroProcurado");
            });


        }
    }
}
