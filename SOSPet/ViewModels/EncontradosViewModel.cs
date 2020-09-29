using SOSPet.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SOSPet.ViewModels
{
    class EncontradosViewModel : BaseViewModel
    {
        public ICommand CadastrarEncontrado;

        public CadastroEncontrado telaCadastro;
        public EncontradosViewModel()
        {
            telaCadastro = new CadastroEncontrado();
            CadastrarEncontrado = new Command(() => {

                MessagingCenter.Send<CadastroEncontrado>(telaCadastro, "irCadastroEncontrado");
            });


        }
    }
}
