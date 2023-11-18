using APS.NET_MVC.Data;
using APS.NET_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace APS.NET_MVC.Controllers
{
    public class EnginesController : Controller
    {
        private readonly APSNET_MVCContext _context;

        public EnginesController(APSNET_MVCContext context)
        {
            _context = context;
        }

        // GET: Engines
        public async Task<IActionResult> Index()
        {
              return _context.Engine != null ? 
                          View(await _context.Engine.ToListAsync()) :
                          Problem("Entity set 'APSNET_MVCContext.Engine'  is null.");
        }

        // GET: Engines/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Engine == null)
            {
                return NotFound();
            }

            var engine = await _context.Engine
                .FirstOrDefaultAsync(m => m.EngineId == id);
            if (engine == null)
            {
                return NotFound();
            }

            return View(engine);
        }

        // GET: Engines/Create
        public IActionResult Create()
        {
            ViewBag.PetrolOptions = new SelectList(Enum.GetValues(typeof(FuelType))
                                        .Cast<FuelType>()
                                        .Select(e => new SelectListItem
                                        {
                                            Text = e.GetDescription(),
                                            Value = e.ToString()
                                        }), "Value", "Text"); ;
            return View();
        }

        // POST: Engines/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EngineId,Name,HorsePower,Capacity,Petrol")] Engine engine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(engine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(engine);
        }

        // GET: Engines/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.PetrolOptions = new SelectList(Enum.GetValues(typeof(FuelType))
                            .Cast<FuelType>()
                            .Select(e => new SelectListItem
                            {
                                Text = e.GetDescription(),
                                Value = e.ToString()
                            }), "Value", "Text");

            if (id == null || _context.Engine == null)
            {
                return NotFound();
            }

            var engine = await _context.Engine.FindAsync(id);
            if (engine == null)
            {
                return NotFound();
            }
            return View(engine);
        }

        // POST: Engines/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EngineId,Name,HorsePower,Capacity,Petrol")] Engine engine)
        {
            if (id != engine.EngineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(engine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EngineExists(engine.EngineId))
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
            return View(engine);
        }

        // GET: Engines/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Engine == null)
            {
                return NotFound();
            }

            var engine = await _context.Engine
                .FirstOrDefaultAsync(m => m.EngineId == id);
            if (engine == null)
            {
                return NotFound();
            }

            return View(engine);
        }

        // POST: Engines/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Engine == null)
            {
                return Problem("Entity set 'APSNET_MVCContext.Engine'  is null.");
            }
            var engine = await _context.Engine.FindAsync(id);
            if (engine != null)
            {
                _context.Engine.Remove(engine);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EngineExists(int id)
        {
          return (_context.Engine?.Any(e => e.EngineId == id)).GetValueOrDefault();
        }
    }
}
