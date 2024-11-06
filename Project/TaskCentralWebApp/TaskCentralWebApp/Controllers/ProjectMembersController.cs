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
    public class ProjectMembersController : Controller
    {
        private readonly TaskCentralDBContext _context;
        private readonly IServiceProvider _serviceProvider;
        public ProjectMembersController(TaskCentralDBContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        // GET: ProjectMembers
        public async Task<IActionResult> Index(int? projectid)
        {
            ProjectMembersIndexViewModel viewModel = new ProjectMembersIndexViewModel();
            viewModel.Project = await _context.Projects.Where(x => x.ProjectId == projectid).FirstOrDefaultAsync();
            viewModel.ProjectMembers = await _context.ProjectMembers.Include(x => x.User).Include(x => x.Project).Where(x => x.ProjectId == projectid).ToListAsync();
            var taskCentralDBContext = _context.ProjectMembers.Include(p => p.Project).Include(p => p.User).Where(x => x.ProjectId == projectid);
            if (viewModel.Project.ManagerId != CurrentUserHelper.GetCurrentUserId(_serviceProvider))
            {
                return Forbid();
            }
            return View(viewModel);
        }

        // GET: ProjectMembers/Details/5
        public async Task<IActionResult> Details(int? projectid, int? userid)
        {
            if (projectid == null || userid == null || _context.ProjectMembers == null)
            {
                return NotFound();
            }

            var projectMember = await _context.ProjectMembers
                .Include(p => p.Project)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.UserId == userid && m.ProjectId == projectid);
            if (projectMember == null)
            {
                return NotFound();
            }
            if (projectMember.Project.ManagerId != CurrentUserHelper.GetCurrentUserId(_serviceProvider))
            {
                return Forbid();
            }
            return View(projectMember);
        }

        // GET: ProjectMembers/Create
        public IActionResult Create(int? projectid)
        {
            if (projectid == null)
            {
                return NotFound();
            }

            ProjectMembersCreateViewModel viewModel = new ProjectMembersCreateViewModel();
            viewModel.ProjectId = (int)projectid;
            if (_context.Projects.Find(viewModel.ProjectId).ManagerId != CurrentUserHelper.GetCurrentUserId(_serviceProvider))
            {
                return Forbid();
            }
            ViewData["ProjectId"] = projectid;
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserName"); // Modify the property used for displaying names

            return View(viewModel);
        }

        // POST: ProjectMembers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProjectMembersCreateViewModel viewModel)
        {
            var projectMembers = _context.ProjectMembers.Include(x => x.Project).Include(x => x.User).Where(x => x.ProjectId == viewModel.ProjectId);
            if (_context.Projects.Find(viewModel.ProjectId).ManagerId != CurrentUserHelper.GetCurrentUserId(_serviceProvider))
            {
                return Forbid();
            }
            if (projectMembers.Count(x => x.UserId == viewModel.UserId) > 0)
            {
                ModelState.AddModelError("UserId", "You cannot add this user. This user already exists in this project.");
                ViewData["ProjectId"] = viewModel.ProjectId;
                ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserName", viewModel.UserId); // Modify the property used for displaying names
            }
            if (ModelState.IsValid)
            {
                var projectMember = new ProjectMember
                {
                    ProjectId = viewModel.ProjectId,
                    UserId = viewModel.UserId
                };
                _context.Add(projectMember);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Project Member Added Successfully";
                return RedirectToAction(nameof(Index), new { projectid = projectMember.ProjectId });
            }
            ViewData["ProjectId"] = viewModel.ProjectId;
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserName", viewModel.UserId); // Modify the property used for displaying names

            return View(viewModel);
        }


        // GET: ProjectMembers/Delete/5
        public async Task<IActionResult> Delete(int? projectid, int? userid)
        {
            if (projectid == null || userid == null || _context.ProjectMembers == null)
            {
                return NotFound();
            }

            var projectMember = await _context.ProjectMembers
                .Include(p => p.Project)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.UserId == userid && m.ProjectId == projectid);
            if (projectMember == null)
            {
                return NotFound();
            }
            if (projectMember.Project.ManagerId != CurrentUserHelper.GetCurrentUserId(_serviceProvider))
            {
                return Forbid();
            }
            return View(projectMember);
        }

        // POST: ProjectMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? projectid, int? userid)
        {
            var projectMember = await _context.ProjectMembers.Include(p => p.Project).FirstOrDefaultAsync(x => x.ProjectId == projectid && x.UserId == userid);
            if (projectMember.Project.ManagerId != CurrentUserHelper.GetCurrentUserId(_serviceProvider))
            {
                return Forbid();
            }
            _context.ProjectMembers.Remove(projectMember);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Project Member Deleted Successfully";
            return RedirectToAction(nameof(Index), new { projectid = projectMember.ProjectId } );
        }

        private bool ProjectMemberExists(int id)
        {
          return (_context.ProjectMembers?.Any(e => e.MemberId == id)).GetValueOrDefault();
        }
    }
}
