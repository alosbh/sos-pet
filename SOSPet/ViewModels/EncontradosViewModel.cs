using SOSPet.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using SOSPet.Services;
using SOSPet.Models;

namespace SOSPet.ViewModels
{
    class EncontradosViewModel : BaseViewModel
    {
        public ICommand CadastrarEncontrado;

        public CadastroEncontrado telaCadastro;

        public EncontradosViewModel()
        {
            telaCadastro = new CadastroEncontrado();

            var ocorrenciasService = new OcorrenciasService();
            CadastrarEncontrado = new Command(() => {

                MessagingCenter.Send<CadastroEncontrado>(telaCadastro, "irCadastroEncontrado");
            });


            ocorrenciasService.getEncontrados();
           
            
        }


    }
}
