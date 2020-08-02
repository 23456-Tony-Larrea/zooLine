using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zooLine.ViewModels
{
    public class AnimalesViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = @"El ""nombre"" es obligatorio:")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = @"El ""nombre cientifico"" es obligatorio:")]
        [Display(Name = "Nombre Cientifico")]
        public string NombreCientifico { get; set; }
        [Required(ErrorMessage = @"El ""año de nacimiento"" es obligatorio:")]
        [Display(Name = "Año de nacimiento")]
        public int año_nacimiento { get; set; }
        [Required(ErrorMessage = @"El ""año de muerte"" es obligatorio:")]
        [Display(Name = "Año de muerte")]
        public int año_muerte { get; set; }
        [Required(ErrorMessage = @"La ""estatura"" es obligatoria:")]
        [Display(Name = "Estatura")]
        public decimal estatura { get; set; }
        [Required(ErrorMessage = @"El ""ancho"" es obligatorio:")]
        [Display(Name = "Ancho")]
        public decimal ancho { get; set; }
        [Display(Name = "Foto del animal")]
        public IFormFile fotoAnimal { get; set; }
    }
}
