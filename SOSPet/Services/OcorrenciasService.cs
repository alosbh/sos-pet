using Json.Net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SOSPet.Models
{
    class OcorrenciasService
    {
        //private readonly string baseUrl = "http://192.168.0.5:5000";
        private readonly string baseUrl = "http://192.168.43.209:5000";

        public async Task getEncontrados()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var cliente = new HttpClient(clientHandler))

            {
                cliente.BaseAddress = new Uri(baseUrl);
                
                string response = null;
                try
                {


                    response = await cliente.GetStringAsync("/api/ocorrencias");

                    var OcorrenciasJon = JsonConvert.DeserializeObject<Ocorrencia[]>(response);
                    MessagingCenter.Send<Ocorrencia[]>(OcorrenciasJon, "SucessoListaOcorrencias");
                }
                catch (System.Exception e)
                {
                    System.Exception erro = e.InnerException;
                    
                }

                
                //var resCode = (int)response.StatusCode;
                //if (response.IsSuccessStatusCode)
                //    Debug.WriteLine("responsecode");
                ////MessagingCenter.Send<int>(2, "SucessoCadastro");
                //else if (resCode == 409)
                //{
                //    MessagingCenter.Send<LoginException>(new LoginException("Email ja cadastrado no sistema."), "FalhaCadastro");
                //}
                //else
                //{
                //    MessagingCenter.Send<LoginException>(new LoginException("Erro Desconhecido"), "FalhaCadastro");
                //}
            }

        }
        public async Task FazerCadastro(Ocorrencia ocorrencia)
        {

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            using (var cliente = new HttpClient(clientHandler))

            {
                ocorrencia.status = "Aberto";
                ocorrencia.tipo = "Encontrado";
                ocorrencia.data_ocorrencia = DateTime.Today;
                string jsonObj = JsonNet.Serialize(ocorrencia);
                var httpContent = new StringContent(jsonObj, Encoding.UTF8, "application/json");

                cliente.BaseAddress = new Uri(baseUrl);
                HttpResponseMessage response = null;
                try
                {


                    response = await cliente.PostAsync("/api/ocorrencias", httpContent);
                }
                catch (System.Exception e)
                {
                    System.Exception erro = e.InnerException;
                    MessagingCenter.Send<CadastroException>(new CadastroException("Erro de comunicação"), "FalhaCadastro");
                }
                var resCode = (int)response.StatusCode;
                if (response.IsSuccessStatusCode)
                    MessagingCenter.Send<Ocorrencia>(ocorrencia, "SucessoCadastroEncontrado");
                else if (resCode == 409)
                {
                    MessagingCenter.Send<CadastroException>(new CadastroException("Email ja cadastrado no sistema."), "FalhaCadastro");
                }
                else
                {
                    MessagingCenter.Send<CadastroException>(new CadastroException("Erro Desconhecido"), "FalhaCadastro");
                }



            }



        }
    }
    public class CadastroException : Exception
    {

        public CadastroException(string message) : base(message)
        {

        }
    }



}
