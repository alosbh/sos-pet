using SOSPet.Models;
using SOSPet.Services;
using SOSPet.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SOSPet.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set
            {

                usuario = value;
                ((Command)EntrarCommand).ChangeCanExecute();
                OnPropertyChanged();

            }
        }

        private string senha;

        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                ((Command)EntrarCommand).ChangeCanExecute();
                OnPropertyChanged();
            }
        }
        public ICommand EntrarCommand { get; private set; }
        public ICommand IrCadastroCommand { get; private set; }

        public CadastroView telaCadastro;
        public LoginViewModel()
        {
            telaCadastro = new CadastroView();
            EntrarCommand = new Xamarin.Forms.Command(async () => {




                var loginService = new LoginService();
                await loginService.FazerLogin(new Login(usuario, senha));

            }, () => {

                return !string.IsNullOrEmpty(usuario)
                && !string.IsNullOrEmpty(senha);
            });


            IrCadastroCommand = new Command(() => {
                
                MessagingCenter.Send<CadastroView>(telaCadastro, "irCadastro");
            });

        }
    }
}
