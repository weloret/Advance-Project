using TaskCentralWebApp.Models;

namespace TaskCentralWebApp.ViewModels
{
    public class ProjectMembersIndexViewModel
    {
        public Project Project { get; set; }
        public IEnumerable<ProjectMember> ProjectMembers { get; set; }
    }
}
