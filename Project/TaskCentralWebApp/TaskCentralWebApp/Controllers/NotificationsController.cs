using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskCentralWebApp.Areas.Identity.Data;
using TaskCentralWebApp.Models;
using TaskCentralWebApp.ViewModels;

namespace TaskCentralWebApp.Controllers
{
    [Authorize]
    public class NotificationsController : Controller
    {
        private readonly TaskCentralDBContext _context;
        private readonly IServiceProvider _serviceProvider;

        public NotificationsController(TaskCentralDBContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        // GET: Notifications
        public async Task<IActionResult> Index()
        {
            var currentUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider);
            var taskCentralDBContext = _context.Notifications.Include(n => n.Task).Include(n => n.User).Where(n => n.UserId == currentUserId).OrderByDescending(x=> x.DateOfCreation);
            return View(await taskCentralDBContext.ToListAsync());
        }

        // GET: Notifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Notifications == null)
            {
                return NotFound();
            }
            
            NotificationsViewModel notificationVM = new NotificationsViewModel();
            notificationVM.Notification = await _context.Notifications.Include(n => n.Task).Include(n => n.User).FirstOrDefaultAsync(m => m.NotifId == id);
            if (notificationVM.Notification != null && notificationVM.Notification.UserId != CurrentUserHelper.GetCurrentUserId(_serviceProvider))
            {
                return Forbid();
            }
            notificationVM.Task = await _context.Tasks.Include(t => t.User).Where(x => x.TaskId == notificationVM.Notification.TaskId).FirstOrDefaultAsync();
            notificationVM.Notification.Status = "Read";
            await _context.SaveChangesAsync();
            if (notificationVM.Task == null || notificationVM.Task == null)
            {
                return NotFound();
            }
            return View(notificationVM);
   
        }

        // GET: Notifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Notifications == null)
            {
                return NotFound();
            }

            var notification = await _context.Notifications
                .Include(n => n.Task)
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.NotifId == id);
            if (notification == null)
            {
                return NotFound();
            }
            if (notification.UserId != CurrentUserHelper.GetCurrentUserId(_serviceProvider))
            {
                return Forbid();
            }
            return View(notification);
        }

        // POST: Notifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Notifications == null)
            {
                return Problem("Entity set 'TaskCentralDBContext.Notifications'  is null.");
            }
            var notification = await _context.Notifications.FindAsync(id);
            if (notification.UserId != CurrentUserHelper.GetCurrentUserId(_serviceProvider))
            {
                return Forbid();
            }
            if (notification != null)
            {
                _context.Notifications.Remove(notification);
            }
            
            await _context.SaveChangesAsync();
            TempData["Success"] = "Notification Deleted Successfully";
            return RedirectToAction(nameof(Index));
        }

        private bool NotificationExists(int id)
        {
          return (_context.Notifications?.Any(e => e.NotifId == id)).GetValueOrDefault();
        }

    }
}
