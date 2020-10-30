using SOSPet.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SOSPet.Services
{
    class CadastroEncontradoService
    {
        public async Task FazerCadastro(AnimalEncontrado animalencontrado, OcorrenciaAnimalEncontrado ocorrenciaanimalencontrado)
        {

            using (var cliente = new HttpClient())

            {

                var camposFormulario = new FormUrlEncodedContent(new[] {

                    new KeyValuePair<string,string>("especie", animalencontrado.especie),
                    new KeyValuePair<string,string>("porte", animalencontrado.porte),
                    new KeyValuePair<string,string>("raca", animalencontrado.raca),

                    new KeyValuePair<string,string>("status", ocorrenciaanimalencontrado.status),
                    new KeyValuePair<string,string>("tipo", ocorrenciaanimalencontrado.tipo),
                    new KeyValuePair<string,string>("descricao", ocorrenciaanimalencontrado.descricao),
                    //new KeyValuePair<string,Location>("localizacao", ocorrenciaanimalencontrado.localizacao),
                    //new KeyValuePair<string,DateTime>("data_ocorrencia", ocorrenciaanimalencontrado.data_ocorrencia)

                });
                cliente.BaseAddress = new Uri("https://localhost:3015");
                HttpResponseMessage response = null;
                MessagingCenter.Send<AnimalEncontrado>(animalencontrado, "SucessoCadastro");


            }
        }
    }
}
