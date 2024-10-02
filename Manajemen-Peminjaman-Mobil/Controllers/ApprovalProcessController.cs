using Manajemen_Peminjaman_Mobil.Data;
using Manajemen_Peminjaman_Mobil.Models;
using Microsoft.AspNetCore.Mvc;

namespace Manajemen_Peminjaman_Mobil.Controllers
{
    public class ApprovalProcessController : Controller
    {
        private readonly VehicleManagementDbContext _context;

        public ApprovalProcessController(VehicleManagementDbContext context)
        {
            _context = context;
        }

        // GET: ApprovalProcess
        public IActionResult Index()
        {
            var approvalProcesses = _context.approvalProcesses
                .ToList();
            return View(approvalProcesses);
        }

        // GET: ApprovalProcess/Details/5
        public IActionResult Details(int id)
        {
            var approvalProcess = _context.approvalProcesses
                .FirstOrDefault(ap => ap.Id == id);

            if (approvalProcess == null)
            {
                return NotFound();
            }

            return View(approvalProcess);
        }

        // GET: ApprovalProcess/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ApprovalProcess/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ApprovalProcess approvalProcess)
        {
            if (ModelState.IsValid)
            {
                _context.Add(approvalProcess);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(approvalProcess);
        }

        // GET: ApprovalProcess/Edit/5
        public IActionResult Edit(int id)
        {
            var approvalProcess = _context.approvalProcesses.Find(id);

            if (approvalProcess == null)
            {
                return NotFound();
            }

            return View(approvalProcess);
        }

        // POST: ApprovalProcess/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ApprovalProcess approvalProcess)
        {
            if (id != approvalProcess.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(approvalProcess);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(approvalProcess);
        }

        // GET: ApprovalProcess/Delete/5
        public IActionResult Delete(int id)
        {
            var approvalProcess = _context.approvalProcesses.Find(id);

            if (approvalProcess == null)
            {
                return NotFound();
            }

            return View(approvalProcess);
        }

        // POST: ApprovalProcess/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var approvalProcess = await _context.approvalProcesses.FindAsync(id);
            _context.approvalProcesses.Remove(approvalProcess);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
