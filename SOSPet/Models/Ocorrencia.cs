using System;
using System.Collections.Generic;
using System.Text;

namespace SOSPet.Models
{
    public class Ocorrencia
    {
        public string status { get; set; }
        public string tipo { get; set; }
        public string descricao { get; set; }
       
        public double latitude { get; set; }
        public double longitude { get; set; }
       
        public DateTime data_ocorrencia { get; set; }

        public Animal animal;
        public Localizacao posicao;

    }
}
