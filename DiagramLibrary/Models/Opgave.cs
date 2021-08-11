using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramLibrary.Models
{
    public class Opgave
    {
        public int ID { get; set; }

        public string Omschrijving { get; set; } = string.Empty;
        
        public string Oplossing {  get; set; } = string.Empty;

        public int Lengte => Oplossing.Length;
    }
}
