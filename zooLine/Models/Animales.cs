using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zooLine.Models
{
    public class Animales
    {
        public  Guid Id {get; set; }
        public string Nombre { get; set; }
        public string NombreCientifico { get; set; }
        public int año_nacimiento { get; set; }
        public int año_muerte { get; set; }
        public decimal estatura { get; set; }
        public decimal ancho { get; set; }

    }
}
