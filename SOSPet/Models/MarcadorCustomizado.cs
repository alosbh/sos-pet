using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Maps;

namespace SOSPet.Models
{
    class MarcadorCustomizado : Pin
    {
        
        public string Animal { get; set; }
        public string Url { get; set; }
    }
}
