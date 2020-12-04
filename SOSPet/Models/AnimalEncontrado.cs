using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms.Maps;

namespace SOSPet.Models
{
    class AnimalEncontrado
    {
        public int id { get; set; }
        public string especie { get; set; }
        public string porte { get; set; }
        public string raca { get; set; }
        public string foto { get; set; }
    }

    class OcorrenciaAnimalEncontrado
    {
        public int idocorr { get; set; }
        public string status { get; set; }
        public string tipo { get; set; }
        public string descricao { get; set; }
        public Position localizacao { get; set; }
        public DateTime data_ocorrencia { get; set; }
        public AnimalEncontrado IDanimal { get; set; }
        public Usuario IDusuario { get; set; }
    }
}
