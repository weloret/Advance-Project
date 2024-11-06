using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using TaskCentralWebApp.Areas.Identity.Data;
using TaskCentralWebApp.Models;

namespace TaskCentralWebApp.Filters
{
    public class LogExceptionFilter : ExceptionFilterAttribute
    {
        private readonly TaskCentralDBContext _context;
        private readonly UserManager<Users> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LogExceptionFilter(TaskCentralDBContext context, UserManager<Users> userManager,
            IHttpContextAccessor httpContextAccessor) {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        public override void OnException(ExceptionContext context)
        {
            // Get the controller and action names
            string controllerName = context.RouteData.Values["controller"].ToString();
            string actionName = context.RouteData.Values["action"].ToString();

            // Use the controller and action names as the source of the error
            string source = $"{controllerName}.{actionName}";

            // Get the exception type and message
            string exceptionType = context.Exception.GetType().Name;
            string exceptionMessage = context.Exception.Message;

            // Create the log message
            string logMessage = $"Source: {source} | Exception: {exceptionType} | Message: {exceptionMessage}";

            // Log the exception details to the [dbo].[Log] table
            // ...
            var id = _userManager.GetUserId(_httpContextAccessor.HttpContext.User);
            int? userid;
            if (id != null)
            {
                userid = _context.Users.Where(x => x.AspUserId == id).FirstOrDefault().UserId;
            }
            else
            {
                userid = null;
            }
            var log = new Log
            {
                Source = "Web",
                CurrentValue = null,
                OriginalValue = null,
                Type = "Exception",
                Message = logMessage,
                DateTime = DateTime.Now,
                UserId = userid
            };
            _context.Logs.Add(log);
            _context.SaveChanges();
            base.OnException(context);
        }
    }

}
