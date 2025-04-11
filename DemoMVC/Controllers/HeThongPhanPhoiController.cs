using System.Linq;
using System.Threading.Tasks;
using DemoMVC.Data;
using DemoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoMVC.Controllers
{
    public class HeThongPhanPhoiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HeThongPhanPhoiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HeThongPhanPhoi
        public async Task<IActionResult> Index()
        {
            var danhSachHTPP = await _context.HeThongPhanPhois.ToListAsync();
            return View(danhSachHTPP);
        }

        // GET: HeThongPhanPhoi/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var heThongPhanPhoi = await _context.HeThongPhanPhois
                .FirstOrDefaultAsync(m => m.MaHTPP == id);

            if (heThongPhanPhoi == null)
                return NotFound();

            return View(heThongPhanPhoi);
        }

        // GET: HeThongPhanPhoi/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HeThongPhanPhoi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHTPP,TenHTPP")] HeThongPhanPhoi heThongPhanPhoi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(heThongPhanPhoi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(heThongPhanPhoi);
        }

        // GET: HeThongPhanPhoi/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var heThongPhanPhoi = await _context.HeThongPhanPhois.FindAsync(id);
            if (heThongPhanPhoi == null)
                return NotFound();

            return View(heThongPhanPhoi);
        }

        // POST: HeThongPhanPhoi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaHTPP,TenHTPP")] HeThongPhanPhoi heThongPhanPhoi)
        {
            if (id != heThongPhanPhoi.MaHTPP)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(heThongPhanPhoi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeThongPhanPhoiExists(heThongPhanPhoi.MaHTPP))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            return View(heThongPhanPhoi);
        }

        // GET: HeThongPhanPhoi/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var heThongPhanPhoi = await _context.HeThongPhanPhois
                .FirstOrDefaultAsync(m => m.MaHTPP == id);

            if (heThongPhanPhoi == null)
                return NotFound();

            return View(heThongPhanPhoi);
        }

        // POST: HeThongPhanPhoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var heThongPhanPhoi = await _context.HeThongPhanPhois.FindAsync(id);
            if (heThongPhanPhoi != null)
            {
                _context.HeThongPhanPhois.Remove(heThongPhanPhoi);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool HeThongPhanPhoiExists(string id)
        {
            return _context.HeThongPhanPhois.Any(e => e.MaHTPP == id);
        }
    }
}
