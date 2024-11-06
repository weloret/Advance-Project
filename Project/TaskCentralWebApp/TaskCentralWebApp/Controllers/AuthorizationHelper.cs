using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskCentralWebApp.Models;

namespace TaskCentralWebApp.Controllers
{
    public static class AuthorizationHelper
    {
        public static async Task<bool> IsProjectMember(int? projectId, int loggedInUserId, TaskCentralDBContext _context)
        {
            var projectMember = await _context.ProjectMembers.FirstOrDefaultAsync(pm => pm.ProjectId == projectId && pm.UserId == loggedInUserId);
            return projectMember != null;
        }
        public static async Task<bool> IsProjectManager(int? projectId, int loggedInUserId, TaskCentralDBContext _context)
        {
            var project = await _context.Projects.FindAsync(projectId);
            return project.ManagerId == loggedInUserId;
        }
    }
}
