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
        public float localizacao_lat { get; set; }
        public float localizacao_long { get; set; }
        public DateTime data_ocorrencia { get; set; }

    }
}
