using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TaskCentralWebApp.Areas.Identity.Data;
using TaskCentralWebApp.Models;
using TaskCentralWebApp.ViewModels;

namespace TaskCentralWebApp.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly TaskCentralDBContext _context;
        private readonly IServiceProvider _serviceProvider;

        public TasksController(TaskCentralDBContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }
        // GET: Tasks
        public async Task<IActionResult> Index(int? projectid, string searchString)
        {
            int currentUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider);

            TasksViewModel tasksVM = new TasksViewModel();

            tasksVM.Project = await _context.Projects
                .Where(p => p.ProjectId == projectid && (p.ManagerId == currentUserId || p.ProjectMembers.Any(pm => pm.UserId == currentUserId))).Include(x=>x.Manager)
                .FirstOrDefaultAsync();

            bool isProjectMember = await AuthorizationHelper.IsProjectMember(projectid, currentUserId, _context);
            bool isProjectManager = await AuthorizationHelper.IsProjectManager(projectid, currentUserId, _context);

            if (!(isProjectManager || isProjectMember))
            {
                return Forbid();
            }

            IQueryable<Models.Task> tasksQuery = _context.Tasks
                .Include(t => t.Project)
                .Include(t => t.User)
                .Where(t => t.ProjectId == projectid && (t.Project.ProjectMembers.Any(pm => pm.UserId == currentUserId) || t.Project.ManagerId == currentUserId));

            if (!string.IsNullOrEmpty(searchString))
            {
                tasksQuery = tasksQuery.Where(t => t.TaskName.Contains(searchString));
            }

            tasksVM.Tasks = await tasksQuery.ToListAsync();

            return View(tasksVM);
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .Include(t => t.Project)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }

            int currentUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider);
            bool isProjectMember = await AuthorizationHelper.IsProjectMember(task.ProjectId, currentUserId, _context);
            bool isProjectManager = await AuthorizationHelper.IsProjectManager(task.ProjectId, currentUserId, _context);

            if (!(isProjectManager || isProjectMember))
            {
                return Forbid();
            }

            ViewData["CurrentProjectId"] = task.ProjectId;
            return View(task);
        }

        // GET: Tasks/Create
        public IActionResult Create(int projectId)
        {
            if (_context.Projects.Find(projectId).ManagerId != CurrentUserHelper.GetCurrentUserId(_serviceProvider))
            {
                return Forbid();
            }
            ViewData["CurrentProjectId"] = projectId;
            ViewData["UserId"] = new SelectList(_context.ProjectMembers.Where(x => x.ProjectId == projectId).Select(x => new { x.UserId, x.User.UserName }), "UserId", "UserName");
            ViewData["Status"] = new SelectList(new[]
            {
                new { Value = "Pending", Text = "Pending" },
        new { Value = "Completed", Text = "Completed" }
        
    }, "Value", "Text");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskId,TaskName,Description,Status,Deadline,ProjectId,UserId")] TaskCentralWebApp.Models.Task task)
        {
            task.Project = _context.Projects.Find(task.ProjectId);
            bool isProjectManager = await AuthorizationHelper.IsProjectManager(task.Project.ProjectId, CurrentUserHelper.GetCurrentUserId(_serviceProvider), _context);
            if (!isProjectManager)
            {
                return Forbid();
            }
            task.Project.Manager = _context.Users.Find(task.Project.ManagerId);
            task.User = _context.Users.Find(task.UserId);
            ModelState.Clear();
            TryValidateModel(task);
            if (ModelState.IsValid)
            {
                _context.Add(task);
                await _context.SaveChangesAsync();
                User user;
                string message;
                string type;
                if (task.Status == "Pending")
                {
                    user = task.User;
                    message = "New Task (" + task.TaskName +") Has Been Assigned to You in project " + task.Project.ProjectName;
                    type = "Task Assignment";
                }
                else
                {
                    user = task.Project.Manager;
                    message = task.User.UserName + " Completed a Task in Project " + task.Project.ProjectName;
                    type = "Task Completion";
                }
                var notification = new Notification
                {
                    DateOfCreation = DateTime.Now,
                    Status = "Unread",
                    UserId = user.UserId,
                    User = user,
                    Task = task,
                    TaskId = task.TaskId,
                    Message = message,
                    Type = type
                };
                _context.Add(notification);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Task Created Successfully";
                return RedirectToAction(nameof(Index), new { projectid  = task.ProjectId});
            }
            ViewData["CurrentProjectId"] = task.ProjectId;
            ViewData["UserId"] = new SelectList(_context.ProjectMembers.Where(x => x.ProjectId == task.ProjectId).Select(x => new { x.UserId, x.User.UserName }),"UserId","UserName");
            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            // Check if the user is a project manager or project member
            bool isManagerOrMember = await _context.Projects
                .AnyAsync(p => p.ProjectId == task.ProjectId &&
                               (p.ManagerId == CurrentUserHelper.GetCurrentUserId(_serviceProvider) || p.ProjectMembers.Any(pm => pm.UserId == CurrentUserHelper.GetCurrentUserId(_serviceProvider))));

            if (!isManagerOrMember)
            {
                return Forbid();
            }
            ViewData["CurrentProjectId"] = task.ProjectId;
            ViewData["UserId"] = new SelectList(_context.ProjectMembers.Where(x => x.ProjectId == task.ProjectId).Select(x => new { x.UserId, x.User.UserName }), "UserId", "UserName");
            ViewData["Status"] = new SelectList(new[]
            {
        new { Value = "Completed", Text = "Completed" },
        new { Value = "Pending", Text = "Pending" }
    }, "Value", "Text");
            return View(task);
        }


        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskId,TaskName,Description,Status,Deadline,ProjectId,UserId")] TaskCentralWebApp.Models.Task task)
        {
            if (id != task.TaskId)
            {
                return NotFound();
            }
            // Check if the user is a project manager or project member
            bool isManagerOrMember = await _context.Projects
                .AnyAsync(p => p.ProjectId == task.ProjectId &&
                               (p.ManagerId == CurrentUserHelper.GetCurrentUserId(_serviceProvider) || p.ProjectMembers.Any(pm => pm.UserId == CurrentUserHelper.GetCurrentUserId(_serviceProvider))));

            if (!isManagerOrMember)
            {
                return Forbid();
            }
            task.Project = _context.Projects.Find(task.ProjectId);
            task.Project.Manager = _context.Users.Find(task.Project.ManagerId);
            task.User = _context.Users.Find(task.UserId);
            ModelState.Clear();
            TryValidateModel(task);
            if (ModelState.IsValid)
            {
                try
                {
                    var temp = new Models.Task
                    {
                        TaskId = task.TaskId,
                        TaskName = task.TaskName,
                        Description = task.Description,
                        Status = task.Status,
                        Deadline = task.Deadline,
                        ProjectId = task.ProjectId,
                        UserId = task.UserId,
                        Project = task.Project,
                        User = task.User
                    };
                    temp.Project.Manager = task.Project.Manager;
                    _context.Attach(task);
                    var entry = _context.Entry(task);
                    entry.Reload();
                    var originalStatus = _context.Entry(task).Property(t => t.Status).OriginalValue;
                    var originalUserId = _context.Entry(task).Property(t => t.UserId).OriginalValue;
                    User user;
                    string message;
                    string type;
                    user = temp.User;
                    if (originalUserId != temp.UserId)
                    {
                        if (temp.Status == "Pending")
                        {
                            message = "New Task (" + temp.TaskName + ") Has Been Assigned to You in project " + temp.Project.ProjectName;
                            type = "Task Assignment";
                            var notification = new Notification
                            {
                                DateOfCreation = DateTime.Now,
                                Status = "Unread",
                                UserId = user.UserId,
                                User = user,
                                TaskId = temp.TaskId,
                                Message = message,
                                Type = type
                            };
                            _context.Add(notification);
                        }
                        else if (originalStatus != temp.Status)
                        {
                            if (temp.Status == "Completed")
                            {
                                user = temp.Project.Manager;
                                message = temp.User.UserName + " Completed a Task in Project " + task.Project.ProjectName;
                                type = "Task Completion";
                                var notification = new Notification
                                {
                                    DateOfCreation = DateTime.Now,
                                    Status = "Unread",
                                    UserId = user.UserId,
                                    User = user,
                                    TaskId = temp.TaskId,
                                    Message = message,
                                    Type = type
                                };
                                _context.Add(notification);
                            }
                            
                        }
                        
                    }
                    else if (originalStatus != temp.Status)
                    {
                            // The status has changed
                        
                            if (temp.Status == "Pending")
                            {              
                                message = "Your Task (" + temp.TaskName + ")  in project " + temp.Project.ProjectName + " is Still Pending";                 
                                type = "Task Assignment";
                            }
                            else
                            {
                                user = temp.Project.Manager;
                                message = temp.User.UserName + " Completed a Task in Project " + task.Project.ProjectName;
                                type = "Task Completion";
                            }
                            var notification = new Notification
                            {
                                DateOfCreation = DateTime.Now,
                                Status = "Unread",
                                UserId = user.UserId,
                                User = user,
                                TaskId = temp.TaskId,
                                Message = message,
                                Type = type
                            };
                            _context.Add(notification);
                    }

                    // Update the properties of the original task with the values from the temp instance
                    entry.Entity.TaskName = temp.TaskName;
                    entry.Entity.Description = temp.Description;
                    entry.Entity.Status = temp.Status;
                    entry.Entity.Deadline = temp.Deadline;
                    entry.Entity.ProjectId = temp.ProjectId;
                    entry.Entity.UserId = temp.UserId;

                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Task Updated Successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.TaskId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { projectid = task.ProjectId });
            }
            ViewData["CurrentProjectId"] = task.ProjectId;
            ViewData["UserId"] = new SelectList(_context.ProjectMembers.Where(x => x.ProjectId == task.ProjectId).Select(x => new { x.UserId, x.User.UserName }), "UserId", "UserName");
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .Include(t => t.Project)
                .Include(t => t.User)
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (task == null)
            {
                return NotFound();
            }
            if (task.Project.ManagerId != CurrentUserHelper.GetCurrentUserId(_serviceProvider))
            {
                return Forbid();
            }
            ViewData["CurrentProjectId"] = task.ProjectId;
            return View(task);
        }

        // POST: Tasks/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tasks == null)
            {
                return Problem("Entity set 'TaskCentralDBContext.Tasks'  is null.");
            }
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                if (task.Project.ManagerId != CurrentUserHelper.GetCurrentUserId(_serviceProvider))
                {
                    return Forbid();
                }
                var notifications = _context.Notifications.Where(n => n.TaskId == id);
                var documents = _context.Documents.Where(d => d.TaskId == id);
                var comments = _context.Comments.Where(d => d.TaskId == id);
                _context.Notifications.RemoveRange(notifications);
                _context.Documents.RemoveRange(documents);
                _context.Comments.RemoveRange(comments);
                _context.Tasks.Remove(task);
            }
            
            await _context.SaveChangesAsync();
            TempData["Success"] = "Task Deleted Successfully";
            return RedirectToAction(nameof(Index), new { projectid = task.ProjectId });
        }

        private bool TaskExists(int id)
        {
            return (_context.Tasks?.Any(e => e.TaskId == id)).GetValueOrDefault();
        }
    }
}
