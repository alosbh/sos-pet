using System;
using System.Collections.Generic;
using System.Text;

namespace SOSPet.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string foto { get; set; }
    }
}
