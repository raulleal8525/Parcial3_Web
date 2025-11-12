using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Parcial3_Web.Data;
using Parcial3_Web.Models;

namespace Parcial3_Web.Controllers
{    
    public class DirectorioController : Controller
    {
        private readonly ApplicationDbContext _context;
                
        public DirectorioController(ApplicationDbContext context)
        {
            _context = context;
        }

      
        public async Task<IActionResult> Index()
        {
           

            var contactos = await _context.Contactos
                .Where(c => c.Activo)
                .OrderBy(c => c.Nombre)
                .ToListAsync();

            return View(contactos);
        }

        public IActionResult Create()
        {
           

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Contacto contacto)
        {           

            if (ModelState.IsValid)
            {
                contacto.FechaCreacion = DateTime.Now;
                contacto.Activo = true;

                _context.Add(contacto);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Contacto agregado exitosamente";
                return RedirectToAction(nameof(Index));
            }

            return View(contacto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
           

            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto == null || !contacto.Activo)
            {
                return NotFound();
            }
            return View(contacto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Contacto contacto)
        {
            

            if (id != contacto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contacto);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Contacto actualizado exitosamente";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactoExists(contacto.Id))
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
            return View(contacto);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            

            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _context.Contactos
                .FirstOrDefaultAsync(m => m.Id == id && m.Activo);

            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           
            var contacto = await _context.Contactos.FindAsync(id);
            if (contacto != null)
            {
                // Soft delete
                contacto.Activo = false;
                _context.Update(contacto);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Contacto eliminado exitosamente";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ContactoExists(int id)
        {
            return _context.Contactos.Any(e => e.Id == id && e.Activo);
        }
    }
}