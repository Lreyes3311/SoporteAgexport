using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ColaboradoresCRUD.Models;

namespace ColaboradoresCRUD.Controllers
{
    public class ColaboradoresController : Controller
    {
        private readonly DatosColaboradoresContext _context;

        public ColaboradoresController(DatosColaboradoresContext context)
        {
            _context = context;
        }

        // GET: Colaboradores
        public async Task<IActionResult> Index()
        {
              return _context.Colaboradores != null ? 
                          View(await _context.Colaboradores.ToListAsync()) :
                          Problem("Entity set 'DatosColaboradoresContext.Colaboradores'  is null.");
        }

        // GET: Colaboradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Colaboradores == null)
            {
                return NotFound();
            }

            var colaboradore = await _context.Colaboradores
                .FirstOrDefaultAsync(m => m.ColaboradorId == id);
            if (colaboradore == null)
            {
                return NotFound();
            }

            return View(colaboradore);
        }

        // GET: Colaboradores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colaboradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColaboradorId,Nombres,Apellidos,Genero,EstadoCivil,FechaNac,Edad,Dpi,Nit,AfIgss,AfIrtra,Pasaporte,Telefono,Correo,Direccion,Ciudad,Pais")] Colaboradore colaboradore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaboradore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colaboradore);
        }

        // GET: Colaboradores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Colaboradores == null)
            {
                return NotFound();
            }

            var colaboradore = await _context.Colaboradores.FindAsync(id);
            if (colaboradore == null)
            {
                return NotFound();
            }
            return View(colaboradore);
        }

        // POST: Colaboradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ColaboradorId,Nombres,Apellidos,Genero,EstadoCivil,FechaNac,Edad,Dpi,Nit,AfIgss,AfIrtra,Pasaporte,Telefono,Correo,Direccion,Ciudad,Pais")] Colaboradore colaboradore)
        {
            if (id != colaboradore.ColaboradorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaboradore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradoreExists(colaboradore.ColaboradorId))
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
            return View(colaboradore);
        }

        // GET: Colaboradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Colaboradores == null)
            {
                return NotFound();
            }

            var colaboradore = await _context.Colaboradores
                .FirstOrDefaultAsync(m => m.ColaboradorId == id);
            if (colaboradore == null)
            {
                return NotFound();
            }

            return View(colaboradore);
        }

        // POST: Colaboradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Colaboradores == null)
            {
                return Problem("Entity set 'DatosColaboradoresContext.Colaboradores'  is null.");
            }
            var colaboradore = await _context.Colaboradores.FindAsync(id);
            if (colaboradore != null)
            {
                _context.Colaboradores.Remove(colaboradore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColaboradoreExists(int id)
        {
          return (_context.Colaboradores?.Any(e => e.ColaboradorId == id)).GetValueOrDefault();
        }
    }
}
