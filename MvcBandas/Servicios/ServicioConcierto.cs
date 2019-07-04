using Microsoft.EntityFrameworkCore;
using MvcBandas.Models;
using MvcBandas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcBandas.Servicios
{
    public class ServicioConcierto
    {
        private readonly MvcBandasContext _context;
        public ServicioConcierto(MvcBandasContext context)
        {
            _context = context;
        }
        public async Task<Concierto> ObtenerConciertoPorId ( int id)
        {
            return await _context.Concierto.FindAsync(id);
        }
        public async Task<Concierto> ObtenerConciertoConBandaPorId(int id)
        {
            return await _context.Concierto
               .Include(c => c.Banda)
               .FirstOrDefaultAsync(m => m.Id == id);
        }
        public ConciertoCreateViewModel CrearconciertoVM (Concierto concierto)
        {
            ConciertoCreateViewModel con = new ConciertoCreateViewModel();
            con.Id = concierto.Id;
            con.Banda = concierto.Banda.Nombre;
            con.BandaId = concierto.BandaId;
            con.Fecha = concierto.Fecha;
            con.Lugar = concierto.Lugar;            
            return con;
        }

        public  Concierto CrearConcierto( ConciertoCreateViewModel  con )
        {
            Concierto concierto = new Concierto();
            concierto.Id = con.Id;
            concierto.BandaId = con.BandaId;
            concierto.Fecha = con.Fecha;
            concierto.Lugar = con.Lugar;
            return concierto;
        }
    }
}
