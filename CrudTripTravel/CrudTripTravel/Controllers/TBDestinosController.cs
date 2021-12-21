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
    public class TBDestinosController : Controller
    {
        private readonly Context _context;

        public TBDestinosController(Context context)
        {
            _context = context;
        }

        // GET: TBDestinos
        public async Task<IActionResult> Index()
        {
            return View(await _context.destinos.ToListAsync());
        }

        // GET: TBDestinos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBDestinos = await _context.destinos
                .FirstOrDefaultAsync(m => m.id_destinos == id);
            if (tBDestinos == null)
            {
                return NotFound();
            }

            return View(tBDestinos);
        }

        // GET: TBDestinos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TBDestinos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_destinos,destino,local_destino,data")] TBDestinos tBDestinos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tBDestinos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tBDestinos);
        }

        // GET: TBDestinos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBDestinos = await _context.destinos.FindAsync(id);
            if (tBDestinos == null)
            {
                return NotFound();
            }
            return View(tBDestinos);
        }

        // POST: TBDestinos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_destinos,destino,local_destino,data")] TBDestinos tBDestinos)
        {
            if (id != tBDestinos.id_destinos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tBDestinos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TBDestinosExists(tBDestinos.id_destinos))
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
            return View(tBDestinos);
        }

        // GET: TBDestinos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tBDestinos = await _context.destinos
                .FirstOrDefaultAsync(m => m.id_destinos == id);
            if (tBDestinos == null)
            {
                return NotFound();
            }

            return View(tBDestinos);
        }

        // POST: TBDestinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tBDestinos = await _context.destinos.FindAsync(id);
            _context.destinos.Remove(tBDestinos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TBDestinosExists(int id)
        {
            return _context.destinos.Any(e => e.id_destinos == id);
        }
    }
}
