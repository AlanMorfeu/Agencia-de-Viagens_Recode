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
    public class TBClientesController : Controller
    {
        private readonly Context _context;

        public TBClientesController(Context context)
        {
            _context = context;
        }

        // GET: TBClientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.clientes.ToListAsync());
        }

        // GET: TBClientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBClientes = await _context.clientes
                .FirstOrDefaultAsync(m => m.id_clientes == id);
            if (tBClientes == null)
            {
                return NotFound();
            }

            return View(tBClientes);
        }

        // GET: TBClientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TBClientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_clientes,nome,email,telefone")] TBClientes tBClientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tBClientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tBClientes);
        }

        // GET: TBClientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBClientes = await _context.clientes.FindAsync(id);
            if (tBClientes == null)
            {
                return NotFound();
            }
            return View(tBClientes);
        }

        // POST: TBClientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_clientes,nome,email,telefone")] TBClientes tBClientes)
        {
            if (id != tBClientes.id_clientes)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tBClientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TBClientesExists(tBClientes.id_clientes))
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
            return View(tBClientes);
        }

        // GET: TBClientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBClientes = await _context.clientes
                .FirstOrDefaultAsync(m => m.id_clientes == id);
            if (tBClientes == null)
            {
                return NotFound();
            }

            return View(tBClientes);
        }

        // POST: TBClientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tBClientes = await _context.clientes.FindAsync(id);
            _context.clientes.Remove(tBClientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TBClientesExists(int id)
        {
            return _context.clientes.Any(e => e.id_clientes == id);
        }
    }
}
