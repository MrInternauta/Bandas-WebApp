using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcBandas.Models;
using MvcBandas.Servicios;
using MvcBandas.ViewModels;

namespace MvcBandas.Controllers
{
    [Authorize]
    public class ConciertoController : Controller
    {
        private readonly MvcBandasContext _context;
        private readonly ServicioConcierto _serviciosConciertos;

        public ConciertoController(MvcBandasContext context, Servicios.ServicioConcierto servicioConcierto)
        {
            _context = context;
            _serviciosConciertos = servicioConcierto;
        }

        // GET: Conciertoes
        public async Task<IActionResult> Index()
        {
            var mvcBandasContext = _context.Concierto.Include(c => c.Banda);
            return View(await mvcBandasContext.ToListAsync());
        }

        // GET: Conciertoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concierto = await _serviciosConciertos.ObtenerConciertoConBandaPorId(id.Value);
            if (concierto == null)
            {
                return NotFound();
            }
            ConciertoDetailsViewModel conciertovm = new ConciertoDetailsViewModel
            {
                Id = concierto.Id,
                Banda = concierto.Banda.Nombre,
                Fecha = concierto.Fecha,
                Lugar = concierto.Lugar
            };
            return View(conciertovm);
        }

        // GET: Conciertoes/Create
        public IActionResult Create()
        {
            ConciertoCreateViewModel conciertovm = new ConciertoCreateViewModel();
            conciertovm.Fecha = DateTime.Now;
            conciertovm.Bandas = ObtenerListaBadas();
            return View(conciertovm);
        }
        public List<SelectListItem> ObtenerListaBadas()
        {
            return _context.Banda.OrderBy(u => u.Nombre).Select(u => new SelectListItem
            {
                Value = u.Id.ToString(),
                Text = u.Nombre
            }).ToList();
        }
        // POST: Conciertoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Lugar,BandaId,Fecha")] ConciertoCreateViewModel conciertovm)
        {
            if (ModelState.IsValid)
            {
                Concierto concierto = new Concierto
                {
                    BandaId = conciertovm.BandaId,
                    Fecha = conciertovm.Fecha,
                    Lugar = conciertovm.Lugar
                };
                _context.Add(concierto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            conciertovm.Bandas = ObtenerListaBadas();
            return View(conciertovm);
        }

        // GET: Conciertoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var concierto = await _serviciosConciertos.ObtenerConciertoConBandaPorId(id.Value);
            if (concierto == null)
            {
                return NotFound();
            }
            ConciertoCreateViewModel vm = new ConciertoCreateViewModel();
            vm.Id = concierto.Id;
            vm.Fecha = concierto.Fecha;
            vm.BandaId = concierto.BandaId;
            vm.Lugar = concierto.Lugar;
            vm.Bandas = ObtenerListaBadas();
            vm.Banda = concierto.Banda.Nombre;

            
            return View(vm);
        }

        // POST: Conciertoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Lugar,BandaId,Fecha")] ConciertoCreateViewModel vm)
        {
            if (id != vm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                try
                {
                    var conciertobd = await _serviciosConciertos.ObtenerConciertoPorId(id);
                    conciertobd.BandaId = vm.BandaId;
                    conciertobd.Fecha = vm.Fecha;
                    conciertobd.Lugar = vm.Lugar;
                    _context.Update(conciertobd);

                    await _context.SaveChangesAsync();
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConciertoExists(vm.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
               

                return RedirectToAction(nameof(Index));
            }
            vm.Bandas = ObtenerListaBadas();
            return View(vm);
        }

        // GET: Conciertoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var concierto = await _serviciosConciertos.ObtenerConciertoConBandaPorId(id.Value);
            if (concierto == null)
            {
                return NotFound();
            }
            ConciertoDeleteViewModel conciertoVM = new ConciertoDeleteViewModel();
            conciertoVM.Id = concierto.Id;
            conciertoVM.Lugar = concierto.Lugar;
            conciertoVM.Fecha = concierto.Fecha;
            conciertoVM.Banda = concierto.Banda;
            return View(conciertoVM);
        }

        // POST: Conciertoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var concierto = await _serviciosConciertos.ObtenerConciertoPorId(id);
            _context.Concierto.Remove(concierto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConciertoExists(int id)
        {
            return _context.Concierto.Any(e => e.Id == id);
        }
    }
}
