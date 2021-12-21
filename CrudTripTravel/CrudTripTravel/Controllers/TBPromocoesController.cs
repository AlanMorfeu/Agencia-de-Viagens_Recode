using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudTripTravel.Models;
using CrudTripTravel.Models.NovaPasta;

namespace CrudTripTravel.Controllers
{
    public class TBPromocoesController : Controller
    {
        private readonly Context _context;

        public TBPromocoesController(Context context)
        {
            _context = context;
        }

        // GET: TBPromocoes
        public async Task<IActionResult> Index()
        {
            var context = _context.promocoes.Include(t => t.TBClientes).Include(t => t.TBDestinos);
            return View(await context.ToListAsync());
        }

        // GET: TBPromocoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBPromocoes = await _context.promocoes
                .Include(t => t.TBClientes)
                .Include(t => t.TBDestinos)
                .FirstOrDefaultAsync(m => m.id_promocoes == id);
            if (tBPromocoes == null)
            {
                return NotFound();
            }

            return View(tBPromocoes);
        }

        // GET: TBPromocoes/Create
        public IActionResult Create()
        {
            ViewData["id_clientes"] = new SelectList(_context.clientes, "id_clientes", "id_clientes");
            ViewData["id_destinos"] = new SelectList(_context.destinos, "id_destinos", "id_destinos");
            return View();
        }

        // POST: TBPromocoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_promocoes,id_clientes,id_destinos,promocao")] TBPromocoes tBPromocoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tBPromocoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["id_clientes"] = new SelectList(_context.clientes, "id_clientes", "id_clientes", tBPromocoes.id_clientes);
            ViewData["id_destinos"] = new SelectList(_context.destinos, "id_destinos", "id_destinos", tBPromocoes.id_destinos);
            return View(tBPromocoes);
        }

        // GET: TBPromocoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBPromocoes = await _context.promocoes.FindAsync(id);
            if (tBPromocoes == null)
            {
                return NotFound();
            }
            ViewData["id_clientes"] = new SelectList(_context.clientes, "id_clientes", "id_clientes", tBPromocoes.id_clientes);
            ViewData["id_destinos"] = new SelectList(_context.destinos, "id_destinos", "id_destinos", tBPromocoes.id_destinos);
            return View(tBPromocoes);
        }

        // POST: TBPromocoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_promocoes,id_clientes,id_destinos,promocao")] TBPromocoes tBPromocoes)
        {
            if (id != tBPromocoes.id_promocoes)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tBPromocoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TBPromocoesExists(tBPromocoes.id_promocoes))
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
            ViewData["id_clientes"] = new SelectList(_context.clientes, "id_clientes", "id_clientes", tBPromocoes.id_clientes);
            ViewData["id_destinos"] = new SelectList(_context.destinos, "id_destinos", "id_destinos", tBPromocoes.id_destinos);
            return View(tBPromocoes);
        }

        // GET: TBPromocoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBPromocoes = await _context.promocoes
                .Include(t => t.TBClientes)
                .Include(t => t.TBDestinos)
                .FirstOrDefaultAsync(m => m.id_promocoes == id);
            if (tBPromocoes == null)
            {
                return NotFound();
            }

            return View(tBPromocoes);
        }

        // POST: TBPromocoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tBPromocoes = await _context.promocoes.FindAsync(id);
            _context.promocoes.Remove(tBPromocoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TBPromocoesExists(int id)
        {
            return _context.promocoes.Any(e => e.id_promocoes == id);
        }
    }
}
