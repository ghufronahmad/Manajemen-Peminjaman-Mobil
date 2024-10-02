using Manajemen_Peminjaman_Mobil.Data;
using Manajemen_Peminjaman_Mobil.Models.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Manajemen_Peminjaman_Mobil.Controllers
{
    public class ApprovalLevelController : Controller
    {
        private readonly VehicleManagementDbContext _context;

        public ApprovalLevelController(VehicleManagementDbContext context)
        {
            _context = context;
        }

        // GET: ApprovalLevel
        public IActionResult Index()
        {
            var approvalLevels = _context.ApproversLevels.ToList();
            return View(approvalLevels);
        }

        // GET: ApprovalLevel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApprovalLevel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApprovalLevel approvalLevel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(approvalLevel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(approvalLevel);
        }

        // GET: ApprovalLevel/Edit/5
        public IActionResult Edit(int id)
        {
            var approvalLevel = _context.ApproversLevels.Find(id);
            if (approvalLevel == null)
            {
                return NotFound();
            }

            return View(approvalLevel);
        }

        // POST: ApprovalLevel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ApprovalLevel approvalLevel)
        {
            if (id != approvalLevel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(approvalLevel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(approvalLevel);
        }

        // GET: ApprovalLevel/Delete/5
        public IActionResult Delete(int id)
        {
            var approvalLevel = _context.ApproversLevels.Find(id);
            if (approvalLevel == null)
            {
                return NotFound();
            }

            return View(approvalLevel);
        }

        // POST: ApprovalLevel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var approvalLevel = await _context.ApproversLevels.FindAsync(id);
            _context.ApproversLevels.Remove(approvalLevel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
