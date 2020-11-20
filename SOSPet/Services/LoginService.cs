using Json.Net;
using Newtonsoft.Json;
using Flurl;
using SOSPet.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Security.Cryptography.X509Certificates;

namespace SOSPet.Services
{
    public class LoginService
    {
        private readonly string baseUrl = "http://192.168.0.6:5000";
        public async Task FazerLogin(Login login)
        {
            

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var cliente = new HttpClient(clientHandler))

            {

                string jsonObj = JsonNet.Serialize(login);
                var httpContent = new StringContent(jsonObj, Encoding.UTF8, "application/json");

                cliente.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage response = null;
                string textoresponse;
                try
                {
                    response = await cliente.PostAsync("/api/login", httpContent);
                    

                }
                catch
                {

                    MessagingCenter.Send<LoginException>(new LoginException("Erro de comunicação"), "FalhaLogin");
                }
                if (response.IsSuccessStatusCode)
                    MessagingCenter.Send<Login>(login, "SucessoLogin");
                else
                {
                    textoresponse = await response.Content.ReadAsStringAsync();
                    
                    LoginError resJ = JsonConvert.DeserializeObject<LoginError>(textoresponse);
                    
                    
                    MessagingCenter.Send<LoginException>(new LoginException(resJ.message), "FalhaLogin");
                }
                   


            }



        }

        public async Task FazerCadastro(Usuario usuario)
        {

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var cliente = new HttpClient(clientHandler))

            {
                string jsonObj = JsonNet.Serialize(usuario);
                var httpContent = new StringContent(jsonObj, Encoding.UTF8, "application/json");
               
                cliente.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage response = null;
                try
                {
                    
                   
                    response = await cliente.PostAsync("/api/usuarios",httpContent);
                }
                catch (System.Exception e)
                {
                   System.Exception erro = e.InnerException;
                    MessagingCenter.Send<LoginException>(new LoginException("Erro de comunicação"), "FalhaCadastro");
                }
                var resCode = (int)response.StatusCode;
                if (response.IsSuccessStatusCode)
                    MessagingCenter.Send<Usuario>(usuario, "SucessoCadastro");
                else if(resCode == 409)
                {
                    MessagingCenter.Send<LoginException>(new LoginException("Email ja cadastrado no sistema."), "FalhaCadastro");
                }
                else
                {
                    MessagingCenter.Send<LoginException>(new LoginException("Erro Desconhecido"), "FalhaCadastro");
                }
                    


            }



        }
    }

    public class LoginException : Exception
    {
        
        public LoginException(string message) : base(message)
        {
            
        }
    }

    public class LoginError
    {
        public string message { get; set; }
        public LoginError(string msg="default")
        {
            this.message = msg;
        }
    }
}

