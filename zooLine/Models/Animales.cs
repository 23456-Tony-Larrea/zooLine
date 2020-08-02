using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace zooLine.Models
{
    public class Animales
    {
        public Guid Id { get; set; }
      
       
        public string Nombre { get; set; }
       
        public string NombreCientifico { get; set; }
       
        public int año_nacimiento { get; set; }
        
        public int año_muerte { get; set; }
       
        public decimal estatura { get; set; }
      
        public decimal ancho { get; set; }
     
        public byte[] fotoAnimal { get; set; }
        [NotMapped]
        public string FotografiaBase64 { get; set; }


    }
}
