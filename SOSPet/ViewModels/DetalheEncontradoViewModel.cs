using System;
using System.Collections.Generic;
using System.Text;

namespace SOSPet.ViewModels
{
    public class DetalheEncontradoViewModel
    {

        public string nome { get; set; }

        public DetalheEncontradoViewModel(string Nome)
        {
            this.nome = Nome;
        }
    }
}
