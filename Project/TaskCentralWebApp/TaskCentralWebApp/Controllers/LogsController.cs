using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskCentralWebApp.Areas.Identity.Data;
using TaskCentralWebApp.Models;
using TaskCentralWebApp.ViewModels;

namespace TaskCentralWebApp.Controllers
{
    [Authorize(Roles = Roles.Admin)]
    public class LogsController : Controller
    {
        private readonly TaskCentralDBContext _context;

        public LogsController(TaskCentralDBContext context)
        {
            _context = context;
        }
        // GET: Logs
        public async Task<IActionResult> Index()
        {
            var taskCentralDBContext = _context.Logs
    .OrderByDescending(x => x.DateTime)
    .Select(log => new LogViewModel
    {
        LogId = log.LogId,
        Source = log.Source,
        Type = log.Type,
        DateTime = log.DateTime,
        Message = log.Message,
        OriginalValue = log.OriginalValue,
        CurrentValue = log.CurrentValue,
        UserName = log.User.UserName
    });

            return View(await taskCentralDBContext.ToListAsync());
        }
        // GET: Logs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Logs == null)
            {
                return NotFound();
            }

            var log = await _context.Logs
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.LogId == id);
            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }
        // GET: Logs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Logs == null)
            {
                return NotFound();
            }

            var log = await _context.Logs
                .Include(l => l.User)
                .FirstOrDefaultAsync(m => m.LogId == id);
            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }
        // POST: Logs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Logs == null)
            {
                return Problem("Entity set 'TaskCentralDBContext.Logs'  is null.");
            }
            var log = await _context.Logs.FindAsync(id);
            if (log != null)
            {
                _context.Logs.Remove(log);
            }
            TempData["Success"] = "Log Deleted Successfully";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogExists(int id)
        {
          return (_context.Logs?.Any(e => e.LogId == id)).GetValueOrDefault();
        }
    }
}
