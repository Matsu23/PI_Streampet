using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StreamPet.Models;

namespace StreamPet.Controllers
{
    public class PetServicesController : Controller
    {
        private readonly DataContext _context;

        public PetServicesController(DataContext context)
        {
            _context = context;
        }

        // GET: PetServices
        public async Task<IActionResult> Index()
        {
              return _context.PetServices != null ? 
                          View(await _context.PetServices.ToListAsync()) :
                          Problem("Entity set 'DataContext.PetServices'  is null.");
        }

        // GET: PetServices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PetServices == null)
            {
                return NotFound();
            }

            var petService = await _context.PetServices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (petService == null)
            {
                return NotFound();
            }

            return View(petService);
        }

        // GET: PetServices/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PetServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Endereco,Categoria,Avaliacao")] PetService petService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(petService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(petService);
        }

        // GET: PetServices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PetServices == null)
            {
                return NotFound();
            }

            var petService = await _context.PetServices.FindAsync(id);
            if (petService == null)
            {
                return NotFound();
            }
            return View(petService);
        }

        // POST: PetServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Endereco,Categoria,Avaliacao")] PetService petService)
        {
            if (id != petService.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(petService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PetServiceExists(petService.Id))
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
            return View(petService);
        }

        // GET: PetServices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PetServices == null)
            {
                return NotFound();
            }

            var petService = await _context.PetServices
                .FirstOrDefaultAsync(m => m.Id == id);
            if (petService == null)
            {
                return NotFound();
            }

            return View(petService);
        }

        // POST: PetServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PetServices == null)
            {
                return Problem("Entity set 'DataContext.PetServices'  is null.");
            }
            var petService = await _context.PetServices.FindAsync(id);
            if (petService != null)
            {
                _context.PetServices.Remove(petService);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PetServiceExists(int id)
        {
          return (_context.PetServices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
