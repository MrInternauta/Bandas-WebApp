using MvcBandas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcBandas.ViewModels
{
    public class ConciertoDeleteViewModel
    {
        public int Id { get; set; }
        public string Lugar { get; set; }
        public Banda Banda { get; set; }
        public DateTime Fecha { get; set; }
    }
}
