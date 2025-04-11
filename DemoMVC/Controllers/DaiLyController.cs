using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoMVC.Data;
using DemoMVC.Models;

namespace MvcMovie.Controllers
{
    public class DaiLyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DaiLyController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DaiLy
        public async Task<IActionResult> Index()
        {
            var daiLys = _context.DaiLys.Include(d => d.HeThongPhanPhoi);
            return View(await daiLys.ToListAsync());
        }

        // GET: DaiLy/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var daiLy = await _context.DaiLys
                .Include(d => d.HeThongPhanPhoi)
                .FirstOrDefaultAsync(m => m.MaDaiLy == id);

            if (daiLy == null)
                return NotFound();

            return View(daiLy);
        }

        // GET: DaiLy/Create
        public IActionResult Create()
        {
            ViewData["MaHTPP"] = new SelectList(_context.HeThongPhanPhois, "MaHTPP", "MaHTPP");
            return View();
        }

        // POST: DaiLy/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaDaiLy,TenDaiLy,DiaChi,NguoiDaiDien,DienThoai,MaHTPP")] DaiLy daiLy)
        {
            if (ModelState.IsValid)
            {
                _context.Add(daiLy);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["MaHTPP"] = new SelectList(_context.HeThongPhanPhois, "MaHTPP", "MaHTPP", daiLy.MaHTPP);
            return View(daiLy);
        }

        // GET: DaiLy/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var daiLy = await _context.DaiLys.FindAsync(id);
            if (daiLy == null)
                return NotFound();

            ViewData["MaHTPP"] = new SelectList(_context.HeThongPhanPhois, "MaHTPP", "MaHTPP", daiLy.MaHTPP);
            return View(daiLy);
        }

        // POST: DaiLy/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("MaDaiLy,TenDaiLy,DiaChi,NguoiDaiDien,DienThoai,MaHTPP")] DaiLy daiLy)
        {
            if (id != daiLy.MaDaiLy)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(daiLy);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DaiLyExists(daiLy.MaDaiLy))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["MaHTPP"] = new SelectList(_context.HeThongPhanPhois, "MaHTPP", "MaHTPP", daiLy.MaHTPP);
            return View(daiLy);
        }

        // GET: DaiLy/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var daiLy = await _context.DaiLys
                .Include(d => d.HeThongPhanPhoi)
                .FirstOrDefaultAsync(m => m.MaDaiLy == id);

            if (daiLy == null)
                return NotFound();

            return View(daiLy);
        }

        // POST: DaiLy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var daiLy = await _context.DaiLys.FindAsync(id);
            if (daiLy != null)
            {
                _context.DaiLys.Remove(daiLy);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool DaiLyExists(string id)
        {
            return _context.DaiLys.Any(e => e.MaDaiLy == id);
        }
    }
}
