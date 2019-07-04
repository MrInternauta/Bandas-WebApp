using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcBandas.ViewModels
{
    public class ConciertoCreateViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El lugar es requerido")]
        public string Lugar { get; set; }
        [Required(ErrorMessage = "El Id de la banda es requerido")]
        public int BandaId { get; set; }
        [Required(ErrorMessage = "La fecha es requerida")]
        public DateTime Fecha { get; set; }
        public List<SelectListItem> Bandas { get; set; }
        public string Banda { get; set; } =  "";
    }
}
