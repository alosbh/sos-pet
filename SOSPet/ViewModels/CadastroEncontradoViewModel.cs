using SOSPet.Models;
using SOSPet.Services;
using SOSPet.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms.Maps;

namespace SOSPet.ViewModels
{
    public class CadastroEncontradoViewModel : BaseViewModel
    {
        private AnimalEncontrado animalencontrado;
        private OcorrenciaAnimalEncontrado ocorrenciaanimalencontrado;

        public string Especie
        {
            get
            {
                return animalencontrado.especie;
            }
            set
            {
                animalencontrado.especie = value;
            }
        }
        public string Porte
        {
            get
            {
                return animalencontrado.porte;
            }
            set
            {
                animalencontrado.porte = value;
            }
        }
        public string Raca
        {
            get
            {
                return animalencontrado.raca;
            }
            set
            {
                animalencontrado.raca = value;
            }
        }
        public string Status
        {
            get
            {
                return ocorrenciaanimalencontrado.status;
            }
            set
            {
                ocorrenciaanimalencontrado.status = "Aberto";
            }
        }
        public string Tipo
        {
            get
            {
                return ocorrenciaanimalencontrado.tipo;
            }
            set
            {
                ocorrenciaanimalencontrado.tipo = "Encontrado";
            }
        }
        public string Descricao
        {
            get
            {
                return ocorrenciaanimalencontrado.descricao;
            }
            set
            {
                ocorrenciaanimalencontrado.descricao = value;
            }
        }
        public Position Localizacao
        {
            get
            {
                return ocorrenciaanimalencontrado.localizacao;
            }
            set
            {
                ocorrenciaanimalencontrado.localizacao = value;
            }
        }
        public DateTime Data_Ocorrencia
        {
            get
            {
                return ocorrenciaanimalencontrado.data_ocorrencia;
            }
            set
            {
                ocorrenciaanimalencontrado.data_ocorrencia = value;
            }
        }
        public ICommand ConcluirCadastroEncontradoCommand { get; private set; }
        public CadastroEncontradoViewModel()
        {

            this.animalencontrado = new AnimalEncontrado();
            this.ocorrenciaanimalencontrado = new OcorrenciaAnimalEncontrado();

            ConcluirCadastroEncontradoCommand = new Xamarin.Forms.Command(async () => {

                var cadastroencontradoservice = new CadastroEncontradoService();
                await cadastroencontradoservice.FazerCadastro(animalencontrado, ocorrenciaanimalencontrado);

            }, () => {
                return true;
            });
        }
    }
}
