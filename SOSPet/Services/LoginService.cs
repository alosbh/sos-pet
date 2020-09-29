using SOSPet.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SOSPet.Services
{
    public class LoginService
    {
        public async Task FazerLogin(Login login)
        {


            using (var cliente = new HttpClient())

            {

                var camposFormulario = new FormUrlEncodedContent(new[] {

                    new KeyValuePair<string,string>("email", login.email),
                    new KeyValuePair<string,string>("senha", login.senha)

                });
                cliente.BaseAddress = new Uri("https://localhost:3015");
                HttpResponseMessage response = null;
                //try
                //{
                //    response = await cliente.PostAsync("/login", camposFormulario);
                //}
                //catch
                //{

                //    MessagingCenter.Send<LoginException>(new LoginException("Erro de comunicação"), "FalhaLogin");
                //}
                //if (response.IsSuccessStatusCode)
                    MessagingCenter.Send<Login>(login, "SucessoLogin");
                //else
                //    MessagingCenter.Send<LoginException>(new LoginException("Usuario ou senha errado"), "FalhaLogin");


            }



        }

        public async Task FazerCadastro(Usuario usuario)
        {


            using (var cliente = new HttpClient())

            {

                var camposFormulario = new FormUrlEncodedContent(new[] {

                    new KeyValuePair<string,string>("email", usuario.email),
                    new KeyValuePair<string,string>("senha", usuario.senha),
                    new KeyValuePair<string,string>("nome", usuario.nome),
                    new KeyValuePair<string,string>("telefone", usuario.telefone)

                });
                cliente.BaseAddress = new Uri("https://localhost:3015");
                HttpResponseMessage response = null;
                //try
                //{
                //    response = await cliente.PostAsync("/cadastro", camposFormulario);
                //}
                //catch
                //{

                //    MessagingCenter.Send<LoginException>(new LoginException("Erro de comunicação"), "FalhaLogin");
                //}
                //if (response.IsSuccessStatusCode)
                MessagingCenter.Send<Usuario>(usuario, "SucessoCadastro");
                //else
                //    MessagingCenter.Send<LoginException>(new LoginException("Usuario ou senha errado"), "FalhaLogin");


            }



        }
    }

    public class LoginException : Exception
    {
        public LoginException(string message) : base(message)
        {

        }
    }
}

