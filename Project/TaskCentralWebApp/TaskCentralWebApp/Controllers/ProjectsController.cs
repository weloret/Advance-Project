using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public class ProjectsController : Controller
    {
        private readonly TaskCentralDBContext _context;
        private readonly IServiceProvider _serviceProvider;

        public ProjectsController(TaskCentralDBContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        // GET: Projects
        public async Task<IActionResult> Index(string searchString)
        {
            int currentUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider);
            IQueryable<Project> taskCentralDBContext = _context.Projects
                .Include(p => p.Manager)
                .Where(p => p.ManagerId == currentUserId || p.ProjectMembers.Any(pm => pm.UserId == currentUserId));

            if (!string.IsNullOrEmpty(searchString))
            {
                taskCentralDBContext = taskCentralDBContext.Where(p => p.ProjectName.Contains(searchString));
            }

            var projects = await taskCentralDBContext.ToListAsync();
            return View(projects);
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Manager)
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            // Check if the logged-in user is a project member
            var loggedInUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider); // Replace with the actual code to get the logged-in user's ID
            var isProjectMember = await AuthorizationHelper.IsProjectMember(id, loggedInUserId, _context);
            if (!isProjectMember)
            {
                return Forbid(); // If the user is not a project member, return a Forbidden status
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            var viewModel = new ProjectCreateViewModel();
            viewModel.ManagerId = CurrentUserHelper.GetCurrentUserId(_serviceProvider); // Set the ManagerId to the logged-in user's ID
            //ViewData["ManagerId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View(viewModel);
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectCreateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

                bool projectExists = await _context.Projects.AnyAsync(p => p.ProjectName == viewModel.ProjectName);
                if (projectExists)
                {
                    ModelState.AddModelError("ProjectName", "A project with the same name already exists.");
                    return View(viewModel);
                }

                var project = new Project
                {
                    ProjectName = viewModel.ProjectName,
                    Description = viewModel.Description,
                    ManagerId = viewModel.ManagerId
                };
                _context.Add(project);
                await _context.SaveChangesAsync();

                var loggedInUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider);
                var projectMember = new ProjectMember
                {
                    ProjectId = project.ProjectId,
                    UserId = loggedInUserId
                };
                _context.Add(projectMember);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Project Added Successfully";
                return RedirectToAction(nameof(Index));
            }

            //ViewData["ManagerId"] = new SelectList(_context.Users, "UserId", "UserId", viewModel.ManagerId);
            return View(viewModel);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }


            var project = await _context.Projects.FindAsync(id);
            // Check if the logged-in user is the project manager
            var loggedInUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider); // Replace with the actual code to get the logged-in user's ID
            var isProjectManager = await AuthorizationHelper.IsProjectManager(id, loggedInUserId, _context);
            if (!isProjectManager)
            {
                return Forbid(); // If the user is not the project manager, return a Forbidden status
            }
            if (project == null)
            {
                return NotFound();
            }


            var viewModel = new ProjectEditViewModel
            {
                ProjectId = project.ProjectId,
                ProjectName = project.ProjectName,
                Description = project.Description,
                ManagerId = project.ManagerId
            };

            //ViewData["ManagerId"] = new SelectList(_context.Users, "UserId", "UserId", project.ManagerId);
            return View(viewModel);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProjectEditViewModel viewModel)
        {
            if (id != viewModel.ProjectId)
            {
                return NotFound();
            }
            // Check if the logged-in user is the project manager
            var loggedInUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider); // Replace with the actual code to get the logged-in user's ID
            var isProjectManager = await AuthorizationHelper.IsProjectManager(id, loggedInUserId, _context);
            if (!isProjectManager)
            {
                return Forbid(); // If the user is not the project manager, return a Forbidden status
            }

            if (ModelState.IsValid)
            {
                bool projectExists = await _context.Projects.AnyAsync(p => p.ProjectName == viewModel.ProjectName && p.ProjectId != viewModel.ProjectId);
                if (projectExists)
                {
                    ModelState.AddModelError("ProjectName", "A project with the same name already exists.");
                    return View(viewModel);
                }
                try
                {
                    // Find the existing project in the database
                    var project = await _context.Projects.FindAsync(viewModel.ProjectId);
                    if (project == null)
                    {
                        return NotFound();
                    }

                    // Update the project entity with ViewModel data
                    project.ProjectName = viewModel.ProjectName;
                    project.Description = viewModel.Description;
                    project.ManagerId = viewModel.ManagerId;

                    _context.Update(project);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Project Updated Successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectExists(viewModel.ProjectId))
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

            //ViewData["ManagerId"] = new SelectList(_context.Users, "UserId", "UserId", viewModel.ManagerId);
            return View(viewModel);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Manager)
                .FirstOrDefaultAsync(m => m.ProjectId == id);
            if (project == null)
            {
                return NotFound();
            }

            // Check if the logged-in user is the project manager
            var loggedInUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider); // Replace with the actual code to get the logged-in user's ID
            var isProjectManager = await AuthorizationHelper.IsProjectManager(id, loggedInUserId, _context);
            if (!isProjectManager)
            {
                return Forbid(); // If the user is not the project manager, return a Forbidden status
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Projects == null)
            {
                return Problem("Entity set 'TaskCentralDBContext.Projects'  is null.");
            }
            var project = await _context.Projects
    .Include(x => x.Tasks)
        .ThenInclude(t => t.Comments)
    .Include(x => x.Tasks)
        .ThenInclude(t => t.Notifications)
    .Include(x => x.Tasks)
        .ThenInclude(t => t.Documents)
    .SingleOrDefaultAsync(x => x.ProjectId == id);


            // Check if the logged-in user is the project manager
            var loggedInUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider); // Replace with the actual code to get the logged-in user's ID
            var isProjectManager = await AuthorizationHelper.IsProjectManager(id, loggedInUserId, _context);
            if (!isProjectManager)
            {
                return Forbid(); // If the user is not the project manager, return a Forbidden status
            }
            if (project != null)
            {
                // Remove the project from the ProjectMember table
                var projectMembers = _context.ProjectMembers.Where(pm => pm.ProjectId == project.ProjectId);
                _context.ProjectMembers.RemoveRange(projectMembers);

                // Remove all comments, notifications, and documents associated with the project's tasks
                foreach (var task in project.Tasks)
                {
                    _context.Comments.RemoveRange(task.Comments);
                    _context.Notifications.RemoveRange(task.Notifications);
                    _context.Documents.RemoveRange(task.Documents);
                }

                // Remove all tasks associated with the project
                _context.Tasks.RemoveRange(project.Tasks);

                // Remove the project itself
                _context.Projects.Remove(project);

                await _context.SaveChangesAsync();
                TempData["Success"] = "Project Deleted Successfully";
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Dashboard(int id)
        {
            var project = await _context.Projects
    .Include(p => p.ProjectMembers)
    .FirstOrDefaultAsync(m => m.ProjectId == id);

            if (project == null)
            {
                return NotFound();
            }

            int currentUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider);
            bool isProjectMember = await AuthorizationHelper.IsProjectMember(id, currentUserId, _context);
            bool isProjectManager = await AuthorizationHelper.IsProjectManager(id, currentUserId, _context);

            if (!(isProjectManager || isProjectMember))
            {
                return Forbid();
            }

            int totalTasks = await _context.Tasks.CountAsync(t => t.ProjectId == id);
            int completedTasks = await _context.Tasks.CountAsync(t => t.ProjectId == id && t.Status == "Completed");
            int pendingTasks = await _context.Tasks.CountAsync(t => t.ProjectId == id && t.Status == "Pending");
            int overdueTasks = await _context.Tasks.CountAsync(t => t.ProjectId == id && t.Deadline < DateTime.Now);

            var tasksPerMember = await _context.ProjectMembers
                .Where(pm => pm.ProjectId == id)
                .GroupBy(pm => pm.UserId)
                .Select(g => new TasksPerMemberViewModel
                {
                    UserId = g.Key,
                    UserName = _context.Users.FirstOrDefault(u => u.UserId == g.Key) != null ? _context.Users.First(u => u.UserId == g.Key).UserName : null,
                    TaskCount = _context.Tasks.Count(t => t.ProjectId == id && t.UserId == g.Key)
                })
                .ToListAsync();

            var dashboardData = new ProjectDashboardViewModel
            {
                Project = project,
                TotalTasks = totalTasks,
                CompletedTasks = completedTasks,
                PendingTasks = pendingTasks,
                OverdueTasks = overdueTasks,
                TasksPerMember = tasksPerMember
            };

            return View(dashboardData);
        }

        private bool ProjectExists(int id)
        {
          return (_context.Projects?.Any(e => e.ProjectId == id)).GetValueOrDefault();
        }

        public IActionResult getProjectData(int id)
        {
            try
            {
                var tasksStatusData = _context.Tasks
                    .Where(t => t.ProjectId == id)
                    .GroupBy(t => t.Status)
                    .Select(g => new
                    {
                        Status = g.Key,
                        Count = g.Count()
                    });

                return Json(tasksStatusData);
            }
            catch
            {
                return BadRequest();
            }
        }
        public IActionResult getProjectUserData(int id)
        {
            try
            {
                var tasksPerUser = _context.Tasks
                    .Include(t => t.User)
                    .Where(t => t.ProjectId == id)
                    .GroupBy(t => new { t.User.UserName, t.Status })
                    .Select(g => new
                    {
                        UserId = g.Key.UserName,
                        Status = g.Key.Status,
                        Count = g.Count()
                    });

                return Json(tasksPerUser);
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
