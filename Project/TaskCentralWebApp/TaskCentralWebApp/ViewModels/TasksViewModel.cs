using TaskCentralWebApp.Models;

namespace TaskCentralWebApp.ViewModels
{
    public class TasksViewModel
    {
        public Project Project { get; set; }
        public IEnumerable<TaskCentralWebApp.Models.Task> Tasks { get; set;}
    }
}
