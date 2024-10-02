using Manajemen_Peminjaman_Mobil.Data;
using Manajemen_Peminjaman_Mobil.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Manajemen_Peminjaman_Mobil.Controllers
{
    public class ApproverController : Controller
    {
        private readonly VehicleManagementDbContext _context;

        public ApproverController(VehicleManagementDbContext context)
        {
            _context = context;
        }

        // GET: Approver
        public IActionResult Index()
        {
            var approvers = _context.Approvers.ToList();
            return View(approvers);
        }

        // GET: Approver/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Approver/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Approver approver)
        {
            if (ModelState.IsValid)
            {
                _context.Add(approver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(approver);
        }

        // GET: Approver/Edit/5
        public IActionResult Edit(int id)
        {
            var approver = _context.Approvers.Find(id);
            if (approver == null)
            {
                return NotFound();
            }

            return View(approver);
        }

        // POST: Approver/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Approver approver)
        {
            if (id != approver.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(approver);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(approver);
        }

        // GET: Approver/Delete/5
        public IActionResult Delete(int id)
        {
            var approver = _context.Approvers.Find(id);
            if (approver == null)
            {
                return NotFound();
            }

            return View(approver);
        }

        // POST: Approver/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var approver = await _context.Approvers.FindAsync(id);
            _context.Approvers.Remove(approver);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
