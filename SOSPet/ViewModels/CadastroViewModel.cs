using SOSPet.Models;
using SOSPet.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace SOSPet.ViewModels
{

    public class CadastroViewModel : BaseViewModel
    {

        private Usuario usuario;

        public string Email
        {
            get
            {
                return usuario.Email;
            }
            set
            {
                usuario.Email = value;
            }
        }
        public string Nome
        {
            get
            {
                return usuario.Nome;
            }
            set
            {
                usuario.Nome = value;
            }
        }
        public string Telefone
        {
            get
            {
                return usuario.Telefone;
            }
            set
            {
                usuario.Telefone = value;
            }
        }
        public string Senha
        {
            get
            {
                return usuario.Senha;
            }
            set
            {
                usuario.Senha = value;
            }
        }
        public ICommand ConcluirCadastroCommand { get; private set; }
        public CadastroViewModel()
        {


            this.usuario = new Usuario();

            ConcluirCadastroCommand = new Xamarin.Forms.Command(async () => {


                var loginService = new LoginService();
                await loginService.FazerCadastro(usuario);



            }, () => {
                return true;
                //return !string.IsNullOrEmpty(usuario.email)
                //&& !string.IsNullOrEmpty(usuario.nome)
                // && !string.IsNullOrEmpty(usuario.telefone)
                //  && !string.IsNullOrEmpty(usuario.senha);
            });
        }

    }
}
