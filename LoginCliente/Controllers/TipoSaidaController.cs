using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoginCliente.Models;

namespace LoginCliente.Controllers
{
    public class TipoSaidaController : Controller
    {
        private readonly Contexto _context;

        public TipoSaidaController(Contexto context)
        {
            _context = context;
        }

        // GET: TipoSaida
        public async Task<IActionResult> Index()
        {
              return _context.TipoSaida != null ? 
                          View(await _context.TipoSaida.ToListAsync()) :
                          Problem("Entity set 'Contexto.TipoSaida'  is null.");
        }

        // GET: TipoSaida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipoSaida == null)
            {
                return NotFound();
            }

            var tipoSaida = await _context.TipoSaida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoSaida == null)
            {
                return NotFound();
            }

            return View(tipoSaida);
        }

        // GET: TipoSaida/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoSaida/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoSaidaDescricao")] TipoSaida tipoSaida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoSaida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoSaida);
        }

        // GET: TipoSaida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipoSaida == null)
            {
                return NotFound();
            }

            var tipoSaida = await _context.TipoSaida.FindAsync(id);
            if (tipoSaida == null)
            {
                return NotFound();
            }
            return View(tipoSaida);
        }

        // POST: TipoSaida/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoSaidaDescricao")] TipoSaida tipoSaida)
        {
            if (id != tipoSaida.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoSaida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoSaidaExists(tipoSaida.Id))
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
            return View(tipoSaida);
        }

        // GET: TipoSaida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipoSaida == null)
            {
                return NotFound();
            }

            var tipoSaida = await _context.TipoSaida
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoSaida == null)
            {
                return NotFound();
            }

            return View(tipoSaida);
        }

        // POST: TipoSaida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipoSaida == null)
            {
                return Problem("Entity set 'Contexto.TipoSaida'  is null.");
            }
            var tipoSaida = await _context.TipoSaida.FindAsync(id);
            if (tipoSaida != null)
            {
                _context.TipoSaida.Remove(tipoSaida);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoSaidaExists(int id)
        {
          return (_context.TipoSaida?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
