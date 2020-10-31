using SOSPet.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOSPet.ViewModels
{
    public class DetalheEncontradoViewModel : BaseViewModel
    {
        public Ocorrencia ocorrencia { get; set; }

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
                ocorrencia.animal.porte = value;
            }
        }
        public DetalheEncontradoViewModel(Ocorrencia oc)
        {

            this.ocorrencia = oc;
            //this.Especie = oc.animal.especie;
            
        }
    }
}
