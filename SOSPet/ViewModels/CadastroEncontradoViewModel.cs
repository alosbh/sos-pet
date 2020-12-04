using SOSPet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SOSPet.ViewModels
{
    public class CadastroEncontradoViewModel : BaseViewModel
    {
        private Ocorrencia ocorrencia;
        
        public string Descricao
        {
            get
            {
                return ocorrencia.descricao;
            }
            set
            {
                ocorrencia.descricao = value;
            }
        }
        public string Especie
        {
            get
            {
                return ocorrencia.animal.especie;
            }
            set
            {
                ocorrencia.animal.especie = value;
            }
        }
        public string Raca
        {
            get
            {
                return ocorrencia.animal.raca;
            }
            set
            {
                ocorrencia.animal.raca = value;
            }
        }
        public string Porte
        {
            get
            {
                return ocorrencia.animal.porte;
            }
            set
            {
                if (value == "0")
                {
                    ocorrencia.animal.porte = "G";
                }
                else if (value == "1")
                {
                    ocorrencia.animal.porte = "M";
                }
                else if (value == "2")
                {
                    ocorrencia.animal.porte = "P";
                }
               
            }
        }
        public double Latitude
        {
            get
            {
                return ocorrencia.posicao.lati;
            }
            set
            {
                ocorrencia.posicao.lati = value;
            }
        }
        public double Longitude
        {
            get
            {
                return ocorrencia.posicao.longi;
            }
            set
            {
                ocorrencia.posicao.longi = value;
            }
        }
        public DateTime Data
        {
            get
            {
                return ocorrencia.data_ocorrencia;
            }
            set
            {
                ocorrencia.data_ocorrencia = value;
            }
        }
        public ICommand ConcluirCadastroCommand { get; private set; }
        public ICommand TirarFoto { get; private set; }
        public ICommand SelecionarGaleria { get; private set; }
        public CadastroEncontradoViewModel()
        {


            
            this.ocorrencia = new Ocorrencia();
            this.ocorrencia.animal = new Animal();
            this.ocorrencia.posicao = new Localizacao();


            MessagingCenter.Subscribe<Pin>(this, "NovoCliquePin", (obj) => {
                this.ocorrencia.latitude = obj.Position.Latitude;
                this.ocorrencia.longitude = obj.Position.Longitude;
            });



            ConcluirCadastroCommand = new Xamarin.Forms.Command(async () => {


                var ocorrenciaService = new OcorrenciasService();
                await ocorrenciaService.FazerCadastro(ocorrencia);
                ocorrenciaService.getEncontrados();



            }, () => {
                return true;
                //return !string.IsNullOrEmpty(usuario.email)
                //&& !string.IsNullOrEmpty(usuario.nome)
                // && !string.IsNullOrEmpty(usuario.telefone)
                //  && !string.IsNullOrEmpty(usuario.senha);
            });

            TirarFoto = new Xamarin.Forms.Command(async () => {

                MessagingCenter.Send<String>("hello", "TirarFoto");
            
            
            });

            SelecionarGaleria = new Xamarin.Forms.Command(async () => {




            });
        }

    }
}
