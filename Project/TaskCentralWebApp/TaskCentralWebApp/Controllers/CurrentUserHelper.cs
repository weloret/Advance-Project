using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskCentralWebApp.Areas.Identity.Data;
using TaskCentralWebApp.Models;

namespace TaskCentralWebApp.Controllers
{
    public static class CurrentUserHelper
    {
        public static int GetCurrentUserId(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<Users>>();
            var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
            var context = serviceProvider.GetRequiredService<TaskCentralDBContext>();

            var userId = userManager.GetUserId(httpContextAccessor.HttpContext.User);
            var user = context.Users.FirstOrDefault(x => x.AspUserId == userId);

            return user?.UserId ?? 0;
        }

        public static async Task<int> GetCurrentUserIdAsync(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<Users>>();
            var context = serviceProvider.GetRequiredService<TaskCentralDBContext>();
            var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();

            var currentUser = await userManager.GetUserAsync(httpContextAccessor.HttpContext.User);
            var currentUserId = context.Users
                .Where(u => u.AspUserId == currentUser.Id)
                .Select(u => u.UserId)
                .FirstOrDefault();

            return currentUserId;
        }
    }
}
