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
    public class EntradaProdutoController : Controller
    {
        private readonly Contexto _context;

        public EntradaProdutoController(Contexto context)
        {
            _context = context;
        }

        // GET: EntradaProduto
        public async Task<IActionResult> Index()
        {
            var contexto = _context.EntradaProduto.Include(e => e.Produto);
            return View(await contexto.ToListAsync());
        }

        // GET: EntradaProduto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EntradaProduto == null)
            {
                return NotFound();
            }

            var entradaProduto = await _context.EntradaProduto
                .Include(e => e.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entradaProduto == null)
            {
                return NotFound();
            }

            return View(entradaProduto);
        }

        // GET: EntradaProduto/Create
        public IActionResult Create()
        {
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "ProdutoNome");
            return View();
        }

        // POST: EntradaProduto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProdutoId,EntradaProdutoEstoque,DataEntrada")] EntradaProduto entradaProduto)
        {
            if (ModelState.IsValid)
            {
                var produto = await _context.Produto.Where(p => p.Id == entradaProduto.ProdutoId).FirstOrDefaultAsync();
                produto.ProdutoEstoque = produto.ProdutoEstoque + entradaProduto.EntradaProdutoEstoque;
                _context.Update(produto);
                _context.Add(entradaProduto);
                _context.Add(entradaProduto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "ProdutoNome", entradaProduto.ProdutoId);
            return View(entradaProduto);
        }

        // GET: EntradaProduto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EntradaProduto == null)
            {
                return NotFound();
            }

            var entradaProduto = await _context.EntradaProduto.FindAsync(id);
            if (entradaProduto == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "ProdutoNome", entradaProduto.ProdutoId);
            return View(entradaProduto);
        }

        // POST: EntradaProduto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProdutoId,EntradaProdutoEstoque,DataEntrada")] EntradaProduto entradaProduto)
        {
            if (id != entradaProduto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entradaProduto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntradaProdutoExists(entradaProduto.Id))
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
            ViewData["ProdutoId"] = new SelectList(_context.Produto, "Id", "ProdutoNome", entradaProduto.ProdutoId);
            return View(entradaProduto);
        }

        // GET: EntradaProduto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EntradaProduto == null)
            {
                return NotFound();
            }

            var entradaProduto = await _context.EntradaProduto
                .Include(e => e.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entradaProduto == null)
            {
                return NotFound();
            }

            return View(entradaProduto);
        }

        // POST: EntradaProduto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EntradaProduto == null)
            {
                return Problem("Entity set 'Contexto.EntradaProduto'  is null.");
            }
            var entradaProduto = await _context.EntradaProduto.FindAsync(id);
            if (entradaProduto != null)
            {
                _context.EntradaProduto.Remove(entradaProduto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntradaProdutoExists(int id)
        {
          return (_context.EntradaProduto?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
