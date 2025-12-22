using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Klases;
using Microsoft.AspNetCore.Authorization;

namespace WebLietotne.Controllers
    // Tikai reģistrēts lietotājs var dzēst ITSupportu
{
    public class ITSupportsController : Controller
    {
        private readonly Md3Context _context;

        public ITSupportsController(Md3Context context)
        {
            _context = context;
        }

        // GET: ITSupports
        public async Task<IActionResult> Index()
        {
            return View(await _context.ITSupports.ToListAsync());
        }

        // GET: ITSupports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iTSupport = await _context.ITSupports
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (iTSupport == null)
            {
                return NotFound();
            }

            return View(iTSupport);
        }

        // GET: ITSupports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ITSupports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,UserName,Email,IsActive,Specialization")] ITSupport iTSupport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iTSupport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iTSupport);
        }

        // GET: ITSupports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iTSupport = await _context.ITSupports.FindAsync(id);
            if (iTSupport == null)
            {
                return NotFound();
            }
            return View(iTSupport);
        }

        // POST: ITSupports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,UserName,Email,IsActive,Specialization")] ITSupport iTSupport)
        {
            if (id != iTSupport.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iTSupport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ITSupportExists(iTSupport.UserID))
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
            return View(iTSupport);
        }

        // GET: ITSupports/Delete/5
        // Kad tiek dzēst ITSupport ieraksts, tad Assignement ierakstos attiecīgais ITSupportID lauks tiek iestatīts uz null
        // Un tas tiek realizēts ar OnDelete(DeleteBehavior.SetNull) Md3Context klasē
        [Authorize] // Tikai autorizēti lietotāji var dzēst ITSupport ierakstus
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iTSupport = await _context.ITSupports
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (iTSupport == null)
            {
                return NotFound();
            }

            return View(iTSupport);
        }

        // POST: ITSupports/Delete/5
        [Authorize] // Tikai autorizēti lietotāji var apstiprināt ITSupport ierakstu dzēšanu
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iTSupport = await _context.ITSupports.FindAsync(id);
            if (iTSupport != null)
            {
                _context.ITSupports.Remove(iTSupport);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ITSupportExists(int id)
        {
            return _context.ITSupports.Any(e => e.UserID == id);
        }
    }
}
