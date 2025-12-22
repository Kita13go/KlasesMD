using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Klases;

namespace WebLietotne.Controllers
{
    public class AssignementsController : Controller
    {
        private readonly Md3Context _context;

        public AssignementsController(Md3Context context)
        {
            _context = context;
        }

        // GET: Assignements
        public async Task<IActionResult> Index()
        {
            var md3Context = _context.Assignements.Include(a => a.ITSupport).Include(a => a.Ticket);
            return View(await md3Context.ToListAsync());
        }

        // GET: Assignements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignement = await _context.Assignements
                .Include(a => a.ITSupport)
                .Include(a => a.Ticket)
                .FirstOrDefaultAsync(m => m.AssignementID == id);
            if (assignement == null)
            {
                return NotFound();
            }

            return View(assignement);
        }

        // GET: Assignements/Create
        public IActionResult Create()
        {
            ViewData["ITSupportID"] = new SelectList(_context.ITSupports, "UserID", "UserName");
            ViewData["TicketID"] = new SelectList(_context.Tickets, "TicketID", "Title");
            return View();
        }

        // POST: Assignements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssignementID,ITSupportID,TicketID,Comment")] Assignement assignement)
        {
            if (ModelState.IsValid)
            {
                // Uzstāda pašreizējo datumu un laiku AssignedAt laukam
                assignement.AssignedAt = DateTime.Now;
                _context.Add(assignement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ITSupportID"] = new SelectList(_context.ITSupports, "UserID", "UserName", assignement.ITSupportID);
            ViewData["TicketID"] = new SelectList(_context.Tickets, "TicketID", "Title", assignement.TicketID);
            return View(assignement);
        }

        // GET: Assignements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignement = await _context.Assignements.FindAsync(id);
            if (assignement == null)
            {
                return NotFound();
            }
            ViewData["ITSupportID"] = new SelectList(_context.ITSupports, "UserID", "UserName", assignement.ITSupportID);
            ViewData["TicketID"] = new SelectList(_context.Tickets, "TicketID", "Title", assignement.TicketID);
            return View(assignement);
        }

        // POST: Assignements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssignementID,ITSupportID,TicketID,Comment")] Assignement assignement)
        {
            if (id != assignement.AssignementID)
            {
                return NotFound();
            }
            var existing = await _context.Assignements.AsNoTracking().FirstOrDefaultAsync(a => a.AssignementID == id);

            if (existing == null)
                return NotFound();

            // Saglabājam nemainīto AssignedAt vērtību
            assignement.AssignedAt = existing.AssignedAt;

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssignementExists(assignement.AssignementID))
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
            ViewData["ITSupportID"] = new SelectList(_context.ITSupports, "UserID", "UserName", assignement.ITSupportID);
            ViewData["TicketID"] = new SelectList(_context.Tickets, "TicketID", "Title", assignement.TicketID);
            return View(assignement);
        }

        // GET: Assignements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assignement = await _context.Assignements
                .Include(a => a.ITSupport)
                .Include(a => a.Ticket)
                .FirstOrDefaultAsync(m => m.AssignementID == id);
            if (assignement == null)
            {
                return NotFound();
            }

            return View(assignement);
        }

        // POST: Assignements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assignement = await _context.Assignements.FindAsync(id);
            if (assignement != null)
            {
                _context.Assignements.Remove(assignement);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssignementExists(int id)
        {
            return _context.Assignements.Any(e => e.AssignementID == id);
        }
    }
}
