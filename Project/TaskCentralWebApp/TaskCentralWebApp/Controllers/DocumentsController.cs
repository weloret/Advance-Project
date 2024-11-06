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
    public class DocumentsController : Controller
    {
        private readonly TaskCentralDBContext _context;
        private readonly IServiceProvider _serviceProvider;

        public DocumentsController(TaskCentralDBContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        // GET: Documents
        public async Task<IActionResult> Index(int? taskid)
        {
            DocumentsViewModel documentVM = new DocumentsViewModel();
            documentVM.Task = await _context.Tasks.Include(t => t.User).Where(x => x.TaskId == taskid).FirstOrDefaultAsync();

            documentVM.Documents = await _context.Documents.Include(t => t.Task).Include(t => t.User).Where(x => x.TaskId == taskid).ToListAsync();

            var loggedInUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider); // Replace with the actual code to get the logged-in user's ID
            var task = await _context.Tasks
                .Include(t => t.Project)
                .Include(pm => pm.Project.ProjectMembers)
                .ThenInclude(u => u.User)
                .FirstOrDefaultAsync(t => t.TaskId == documentVM.Task.TaskId);

            bool isManagerOrMember = task != null && (task.Project.ManagerId == loggedInUserId ||
                                                         task.Project.ProjectMembers.Any(pm => pm.UserId == loggedInUserId));

            if (!isManagerOrMember)
            {
                return Forbid(); // If the user is not the project manager or a project member, return a Forbidden status
            }

            return View(documentVM);
        }

        // GET: Documents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }


            var document = await _context.Documents
                .Include(d => d.Task)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.DocId == id);
            if (document == null)
            {
                return NotFound();
            }
            var loggedInUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider); // Replace with the actual code to get the logged-in user's ID
            var task = await _context.Tasks
                .Include(t => t.Project)
                .Include(pm => pm.Project.ProjectMembers)
                .ThenInclude(u => u.User)
                .FirstOrDefaultAsync(t => t.TaskId == document.TaskId);

            bool isManagerOrMember = task != null && (task.Project.ManagerId == loggedInUserId ||
                                                         task.Project.ProjectMembers.Any(pm => pm.UserId == loggedInUserId));

            if (!isManagerOrMember)
            {
                return Forbid(); // If the user is not the project manager or a project member, return a Forbidden status
            }

            ViewData["TaskId"] = document.TaskId;
            return View(document);
        }

        // GET: Documents/Create
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
            // Pass the user's ID to the view
            ViewData["TaskId"] = taskid;
            ViewData["UserId"] = await CurrentUserHelper.GetCurrentUserIdAsync(_serviceProvider);
            return View();
        }


        // POST: Documents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocId,TaskId,UserId")] Document document, IFormFile documentFile)
        {
            // Read the uploaded file into a byte array
            using (var memoryStream = new MemoryStream())
            {
                await documentFile.CopyToAsync(memoryStream);
                byte[] fileBytes = memoryStream.ToArray();

                // TODO: Save the fileBytes to your database
                document.DocSource = fileBytes;
            }

            // Get the file name and content type
            string fileName = documentFile.FileName;
            string contentType = documentFile.ContentType;

            // TODO: Update the Document object with the file information
            document.DocType = contentType;
            document.DocName = fileName;
            document.UploadDate = DateTime.Now;

            document.Task = _context.Tasks.Find(document.TaskId);
            document.Task.Project = _context.Projects.Find(document.Task.ProjectId);
            document.Task.Project.Manager = _context.Users.Find(document.Task.Project.ManagerId);
            document.Task.User = _context.Users.Find(document.Task.UserId);

            document.User = _context.Users.Find(document.UserId);
            var loggedInUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider); // Replace with the actual code to get the logged-in user's ID
            var task = await _context.Tasks
                .Include(t => t.Project)
                .Include(pm => pm.Project.ProjectMembers)
                .ThenInclude(u => u.User)
                .FirstOrDefaultAsync(t => t.TaskId == document.TaskId);

            bool isManagerOrMember = task != null && (task.Project.ManagerId == loggedInUserId ||
                                                         task.Project.ProjectMembers.Any(pm => pm.UserId == loggedInUserId));

            if (!isManagerOrMember)
            {
                return Forbid(); // If the user is not the project manager or a project member, return a Forbidden status
            }
            ModelState.Clear();
            TryValidateModel(document);
            if (ModelState.IsValid)
            {
                
                _context.Add(document);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Document Added Successfully";
                return RedirectToAction(nameof(Index), new { taskid = document.TaskId });
            }
            ViewData["TaskId"] = document.TaskId;
            ViewData["UserId"] = await CurrentUserHelper.GetCurrentUserIdAsync(_serviceProvider);
            return View(document);
        }


        // GET: Documents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Documents == null)
            {
                return NotFound();
            }

            var document = await _context.Documents
                .Include(d => d.Task)
                .Include(d => d.User)
                .FirstOrDefaultAsync(m => m.DocId == id);
            if (document == null)
            {
                return NotFound();
            }
            var loggedInUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider); // Replace with the actual code to get the logged-in user's ID
            var task = await _context.Tasks
                .Include(t => t.Project)
                .Include(pm => pm.Project.ProjectMembers)
                .ThenInclude(u => u.User)
                .FirstOrDefaultAsync(t => t.TaskId == document.TaskId);

            bool isManagerOrMember = task != null && (task.Project.ManagerId == loggedInUserId ||
                                                         task.Project.ProjectMembers.Any(pm => pm.UserId == loggedInUserId));

            if (!isManagerOrMember)
            {
                return Forbid(); // If the user is not the project manager or a project member, return a Forbidden status
            }
            ViewData["TaskId"] = document.TaskId;
            return View(document);
        }

        // POST: Documents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Documents == null)
            {
                return Problem("Entity set 'TaskCentralDBContext.Documents'  is null.");
            }
            var document = await _context.Documents.FindAsync(id);
            var loggedInUserId = CurrentUserHelper.GetCurrentUserId(_serviceProvider); // Replace with the actual code to get the logged-in user's ID
            var task = await _context.Tasks
                .Include(t => t.Project)
                .Include(pm => pm.Project.ProjectMembers)
                .ThenInclude(u => u.User)
                .FirstOrDefaultAsync(t => t.TaskId == document.TaskId);

            bool isManagerOrMember = task != null && (task.Project.ManagerId == loggedInUserId ||
                                                         task.Project.ProjectMembers.Any(pm => pm.UserId == loggedInUserId));

            if (!isManagerOrMember)
            {
                return Forbid(); // If the user is not the project manager or a project member, return a Forbidden status
            }
            if (document != null)
            {
                _context.Documents.Remove(document);
            }
            TempData["Success"] = "Document Deleted Successfully";
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { taskid = document.TaskId });
        }

        private bool DocumentExists(int id)
        {
          return (_context.Documents?.Any(e => e.DocId == id)).GetValueOrDefault();
        }
        public async Task<IActionResult> Download(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var document = await _context.Documents.FindAsync(id);
            if (document == null)
            {
                return NotFound();
            }

            return File(document.DocSource, document.DocType);
        }
    }
}
