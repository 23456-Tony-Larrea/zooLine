using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;
using zooLine.Data;
using zooLine.Models;
using zooLine.ViewModels;

namespace zooLine.Controllers
{
    [Authorize]
    public class AnimalesController : Controller
    {
        private readonly PrincipalContext _context;

        public AnimalesController(PrincipalContext context)
        {
            _context = context;
        }

        // GET: Animales
        public async Task<IActionResult> Index()
        {
            var animales = await _context.Animal.ToListAsync();
            animales.ForEach(p => p.FotografiaBase64 = $"data:image/png;base64,{Convert.ToBase64String(p.fotoAnimal)}");

            return View(await _context.Animal.ToListAsync());
        }

        // GET: Animales/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animales = await _context.Animal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animales == null)
            {
                return NotFound();
            }

            return View(animales);
        }

        // GET: Animales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AnimalesViewModel modelo)
        {
          
            if (ModelState.IsValid)
            {
                Animales animales = new Animales
                {
                    Nombre = modelo.Nombre,
                    ancho = modelo.ancho,
                    año_muerte = modelo.año_muerte,
                    año_nacimiento = modelo.año_nacimiento,
                    estatura = modelo.estatura,
                    NombreCientifico = modelo.NombreCientifico,
                    fotoAnimal = await ArchivoSubidoAsync(modelo.fotoAnimal)

                };
                
                _context.Add(animales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(modelo);
        }

        private async Task<byte[]> ArchivoSubidoAsync(IFormFile fotoAnimal)
        {
            if (fotoAnimal == null) return null;
            var memoryStream = new MemoryStream();
            await fotoAnimal.CopyToAsync(memoryStream);
            var limiteMax = 2097152;
            if (memoryStream.Length <limiteMax )
            
               return memoryStream.ToArray();
                return null;    
        }





        // GET: Animales/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animales = await _context.Animal.FindAsync(id);
            if (animales == null)
            {
                return NotFound();
            }
            return View(animales);
        }

        // POST: Animales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Nombre,NombreCientifico,año_nacimiento,año_muerte,estatura,ancho")] Animales animales)
        {
            if (id != animales.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalesExists(animales.Id))
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
            return View(animales);
        }

        // GET: Animales/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animales = await _context.Animal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (animales == null)
            {
                return NotFound();
            }

            return View(animales);
        }

        // POST: Animales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var animales = await _context.Animal.FindAsync(id);
            _context.Animal.Remove(animales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalesExists(Guid id)
        {
            return _context.Animal.Any(e => e.Id == id);
        }
    }
}
