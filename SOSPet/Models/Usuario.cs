﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SOSPet.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        //public string foto { get; set; }
    }
}
