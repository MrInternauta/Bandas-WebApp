using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcBandas.Models
{
    public class Concierto
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El lugar es requerido")]
        public string Lugar { get; set; }
        [Required(ErrorMessage = "El Id de la banda es requerido")]
        public int BandaId { get; set; } 
        public virtual Banda Banda { get; set; }
        [Required(ErrorMessage = "La fecha es requerida")]
        public DateTime Fecha { get; set; }
    }
}
