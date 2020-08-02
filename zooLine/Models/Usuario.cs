using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace zooLine.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }

        public string Nombre { get; set; }
        [Display(Name = "Segundo nombre")]
        public string segundoNombre { get; set; }
        [Display(Name = "Primer Apellido")]
        public string primerApellido { get; set; }
        [Display(Name = "Segundo Apellido")]
        public string segundoApellido { get; set; }
        [Display(Name = "Cedula de Identidad")]
        public string   CI { get; set; }
        public string email { get; set; }
        public string contraseña { get; set; }
        public string telefono { get; set; }
       
    }
}
