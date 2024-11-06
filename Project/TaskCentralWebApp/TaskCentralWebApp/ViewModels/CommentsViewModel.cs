using TaskCentralWebApp.Models;
namespace TaskCentralWebApp.ViewModels
{
    public class CommentsViewModel
    {
        public TaskCentralWebApp.Models.Task Task { get; set; }
        public IEnumerable<TaskCentralWebApp.Models.Comment> Comments { get; set; }
    }
}
