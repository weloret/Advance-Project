using TaskCentralWebApp.Models;

namespace TaskCentralWebApp.ViewModels
{
    public class ProjectDashboardViewModel
    {
        public Project Project { get; set; }
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int PendingTasks { get; set; }
        public int OverdueTasks { get; set; }
        public List<TasksPerMemberViewModel> TasksPerMember { get; set; }
    }

    public class TasksPerMemberViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int TaskCount { get; set; }
    }
}
