using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcBandas.ViewModels
{
    public class ConciertoDetailsViewModel
    {
        public int Id { get; set; }
        public string Lugar { get; set; }
        public string Banda { get; set; }
        public DateTime Fecha { get; set; }
    }
}
