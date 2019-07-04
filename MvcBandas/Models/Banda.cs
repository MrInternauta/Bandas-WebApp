using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcBandas.Models
{
    public class Banda
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El nombre del Vocalista es requerido")]
        public string Vocalistas { get; set; }
        [Display(Name="Numero de integrantes")]
        [Required(ErrorMessage = "El número de integrantes es requerido")]
        public int NumeroIntegrantes { get; set; }
        [Display(Name = "Años de formación")]
        [Required(ErrorMessage = "El Año de formación es requerido")]
        public int AnioFormacion { get; set; }
        [Display(Name = "Fecha de registro")]
        [Required(ErrorMessage = "La Fecha de registro es requerido")]
        [DataType(DataType.Date)]
        public DateTime FechaRegistro { get; set; }
        [Display(Name = "Genero musical")]
        [Required(ErrorMessage = "El Genero musical es requerido")]
        public string Genero { get; set; }
    }
}
