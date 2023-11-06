using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FacturaCRUD.Models;

namespace FacturaCRUD.Controllers
{
    public class DetalleFacturasController : Controller
    {
        private readonly FacturaDbContext _context;

        public DetalleFacturasController(FacturaDbContext context)
        {
            _context = context;
        }

        // GET: DetalleFacturas
        public async Task<IActionResult> Index()
        {
            var facturaDbContext = _context.DetalleFacturas.Include(d => d.Factura);
            return View(await facturaDbContext.ToListAsync());
        }

        // GET: DetalleFacturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DetalleFacturas == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFacturas
                .Include(d => d.Factura)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Create
        public IActionResult Create()
        {
            ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "Id");
            return View();
        }

        // POST: DetalleFacturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Producto,Cantidad,MontoTotalLinea,FacturaId")] DetalleFactura detalleFactura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleFactura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "Id", detalleFactura.FacturaId);
            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DetalleFacturas == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFacturas.FindAsync(id);
            if (detalleFactura == null)
            {
                return NotFound();
            }
            ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "Id", detalleFactura.FacturaId);
            return View(detalleFactura);
        }

        // POST: DetalleFacturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Producto,Cantidad,MontoTotalLinea,FacturaId")] DetalleFactura detalleFactura)
        {
            if (id != detalleFactura.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleFactura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleFacturaExists(detalleFactura.Id))
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
            ViewData["FacturaId"] = new SelectList(_context.Facturas, "Id", "Id", detalleFactura.FacturaId);
            return View(detalleFactura);
        }

        // GET: DetalleFacturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DetalleFacturas == null)
            {
                return NotFound();
            }

            var detalleFactura = await _context.DetalleFacturas
                .Include(d => d.Factura)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detalleFactura == null)
            {
                return NotFound();
            }

            return View(detalleFactura);
        }

        // POST: DetalleFacturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DetalleFacturas == null)
            {
                return Problem("Entity set 'FacturaDbContext.DetalleFacturas'  is null.");
            }
            var detalleFactura = await _context.DetalleFacturas.FindAsync(id);
            if (detalleFactura != null)
            {
                _context.DetalleFacturas.Remove(detalleFactura);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleFacturaExists(int id)
        {
          return (_context.DetalleFacturas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
