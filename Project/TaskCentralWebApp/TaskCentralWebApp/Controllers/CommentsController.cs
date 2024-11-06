using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using TaskCentralWebApp.Areas.Identity.Data;
using TaskCentralWebApp.Models;
using TaskCentralWebApp.ViewModels;

namespace TaskCentralWebApp.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private readonly TaskCentralDBContext _context;
        private readonly IServiceProvider _serviceProvider;

        public CommentsController(TaskCentralDBContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }
    

        // GET: Comments
        public async Task<IActionResult> Index(int? taskid)
        {
            CommentsViewModel commentsVM = new CommentsViewModel();
            commentsVM.Task = await _context.Tasks.Include(t => t.User).Where(x => x.TaskId == taskid).FirstOrDefaultAsync();
            commentsVM.Comments = await _context.Comments.Include(t => t.Task).Include(t => t.User).Where(x => x.TaskId == taskid).ToListAsync();

            var loggedInUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider); // Replace with the actual code to get the logged-in user's ID
            var task = await _context.Tasks
                .Include(t => t.Project)
                .Include(pm => pm.Project.ProjectMembers)
                .ThenInclude(u => u.User)
                .FirstOrDefaultAsync(t => t.TaskId == commentsVM.Task.TaskId);

            bool isManagerOrMember = task != null && (task.Project.ManagerId == loggedInUserId ||
                                                         task.Project.ProjectMembers.Any(pm => pm.UserId == loggedInUserId));

            if (!isManagerOrMember)
            {
                return Forbid(); // If the user is not the project manager or a project member, return a Forbidden status
            }

            return View(commentsVM);
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Comments == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .Include(c => c.Task)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (comment == null)
            {
                return NotFound();
            }
            var loggedInUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider); // Replace with the actual code to get the logged-in user's ID
            var task = await _context.Tasks
                .Include(t => t.Project)
                .Include(pm => pm.Project.ProjectMembers)
                .ThenInclude(u => u.User)
                .FirstOrDefaultAsync(t => t.TaskId == comment.TaskId);

            bool isManagerOrMember = task != null && (task.Project.ManagerId == loggedInUserId ||
                                                         task.Project.ProjectMembers.Any(pm => pm.UserId == loggedInUserId));

            if (!isManagerOrMember)
            {
                return Forbid(); // If the user is not the project manager or a project member, return a Forbidden status
            }
            ViewData["TaskId"] = comment.TaskId;
            ViewData["UserId"] = await CurrentUserHelper.GetCurrentUserIdAsync(_serviceProvider);
            return View(comment);
        }

        // GET: Comments/Create
        public async Task<IActionResult> Create(int taskid)
        {
            var loggedInUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider); // Replace with the actual code to get the logged-in user's ID
            var task = await _context.Tasks
                .Include(t => t.Project)
                .Include(pm => pm.Project.ProjectMembers)
                .ThenInclude(u => u.User)
                .FirstOrDefaultAsync(t => t.TaskId == taskid);

            bool isManagerOrMember = task != null && (task.Project.ManagerId == loggedInUserId ||
                                                         task.Project.ProjectMembers.Any(pm => pm.UserId == loggedInUserId));

            if (!isManagerOrMember)
            {
                return Forbid(); // If the user is not the project manager or a project member, return a Forbidden status
            }
            ViewData["TaskId"] = taskid;
            ViewData["UserId"] = await CurrentUserHelper.GetCurrentUserIdAsync(_serviceProvider);
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,Text,TaskId,UserId")] Comment comment)
        {
            comment.DateTime = DateTime.Now;
            comment.Task = _context.Tasks.Find(comment.TaskId);
            comment.Task.Project = _context.Projects.Find(comment.Task.ProjectId);
            comment.Task.Project.Manager = _context.Users.Find(comment.Task.Project.ManagerId);
            comment.Task.User = _context.Users.Find(comment.Task.UserId);

            comment.User = _context.Users.Find(comment.UserId);

            var loggedInUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider); // Replace with the actual code to get the logged-in user's ID
            var task = await _context.Tasks
                .Include(t => t.Project)
                .Include(pm => pm.Project.ProjectMembers)
                .ThenInclude(u=>u.User)
                .FirstOrDefaultAsync(t => t.TaskId == comment.TaskId);

            bool isManagerOrMember = task != null && (task.Project.ManagerId == loggedInUserId ||
                                                         task.Project.ProjectMembers.Any(pm => pm.UserId == loggedInUserId));

            if (!isManagerOrMember)
            {
                return Forbid(); // If the user is not the project manager or a project member, return a Forbidden status
            }

            ModelState.Clear();
            TryValidateModel(comment);
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Comment Added Successfully";
                return RedirectToAction(nameof(Index), new { taskid = comment.TaskId });
            }
            ViewData["TaskId"] = comment.TaskId;
            ViewData["UserId"] = await CurrentUserHelper.GetCurrentUserIdAsync(_serviceProvider);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Comments == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            var loggedInUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider); // Replace with the actual code to get the logged-in user's ID
            var task = await _context.Tasks
                .Include(t => t.Project)
                .Include(pm => pm.Project.ProjectMembers)
                .ThenInclude(u => u.User)
                .FirstOrDefaultAsync(t => t.TaskId == comment.TaskId);

            bool isManagerOrMember = task != null && (task.Project.ManagerId == loggedInUserId ||
                                                         task.Project.ProjectMembers.Any(pm => pm.UserId == loggedInUserId));

            if (!isManagerOrMember)
            {
                return Forbid(); // If the user is not the project manager or a project member, return a Forbidden status
            }
            ViewData["TaskId"] = comment.TaskId;
            ViewData["UserId"] = await CurrentUserHelper.GetCurrentUserIdAsync(_serviceProvider);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentId,Text,TaskId,UserId")] Comment comment)
        {
            comment.DateTime = DateTime.Now;
            if (id != comment.CommentId)
            {
                return NotFound();
            }
            comment.Task = _context.Tasks.Find(comment.TaskId);
            comment.Task.Project = _context.Projects.Find(comment.Task.ProjectId);
            comment.Task.Project.Manager = _context.Users.Find(comment.Task.Project.ManagerId);
            comment.Task.User = _context.Users.Find(comment.Task.UserId);
            comment.User = _context.Users.Find(comment.UserId);
            var loggedInUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider); // Replace with the actual code to get the logged-in user's ID
            var task = await _context.Tasks
                .Include(t => t.Project)
                .Include(pm => pm.Project.ProjectMembers)
                .ThenInclude(u => u.User)
                .FirstOrDefaultAsync(t => t.TaskId == comment.TaskId);

            bool isManagerOrMember = task != null && (task.Project.ManagerId == loggedInUserId ||
                                                         task.Project.ProjectMembers.Any(pm => pm.UserId == loggedInUserId));

            if (!isManagerOrMember)
            {
                return Forbid(); // If the user is not the project manager or a project member, return a Forbidden status
            }
            ModelState.Clear();
            TryValidateModel(comment);
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comment);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Comment Updated Successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.CommentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { taskid = comment.TaskId });
            }
            ViewData["TaskId"] = comment.TaskId;
            ViewData["UserId"] = await CurrentUserHelper.GetCurrentUserIdAsync(_serviceProvider);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Comments == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .Include(c => c.Task)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (comment == null)
            {
                return NotFound();
            }
            var loggedInUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider); // Replace with the actual code to get the logged-in user's ID
            var task = await _context.Tasks
                .Include(t => t.Project)
                .Include(pm => pm.Project.ProjectMembers)
                .ThenInclude(u => u.User)
                .FirstOrDefaultAsync(t => t.TaskId == comment.TaskId);

            bool isManagerOrMember = task != null && (task.Project.ManagerId == loggedInUserId ||
                                                         task.Project.ProjectMembers.Any(pm => pm.UserId == loggedInUserId));

            if (!isManagerOrMember)
            {
                return Forbid(); // If the user is not the project manager or a project member, return a Forbidden status
            }
            ViewData["UserId"] = await CurrentUserHelper.GetCurrentUserIdAsync(_serviceProvider);
            ViewData["TaskId"] = comment.TaskId;
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Comments == null)
            {
                return Problem("Entity set 'TaskCentralDBContext.Comments'  is null.");
            }
            var comment = await _context.Comments.FindAsync(id);
            var loggedInUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider); // Replace with the actual code to get the logged-in user's ID
            var task = await _context.Tasks
                .Include(t => t.Project)
                .Include(pm => pm.Project.ProjectMembers)
                .ThenInclude(u => u.User)
                .FirstOrDefaultAsync(t => t.TaskId == comment.TaskId);

            bool isManagerOrMember = task != null && (task.Project.ManagerId == loggedInUserId ||
                                                         task.Project.ProjectMembers.Any(pm => pm.UserId == loggedInUserId));

            if (!isManagerOrMember)
            {
                return Forbid(); // If the user is not the project manager or a project member, return a Forbidden status
            }
            if (comment != null)
            {
                _context.Comments.Remove(comment);
            }
            
            await _context.SaveChangesAsync();
            TempData["Success"] = "Comment Deleted Successfully";
            return RedirectToAction(nameof(Index), new { taskid = comment.TaskId });
        }

        private bool CommentExists(int id)
        {
          return (_context.Comments?.Any(e => e.CommentId == id)).GetValueOrDefault();
        }
    }
}
