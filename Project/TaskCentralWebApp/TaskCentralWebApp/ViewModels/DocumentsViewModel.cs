using TaskCentralWebApp.Models;
namespace TaskCentralWebApp.ViewModels
{
    public class DocumentsViewModel
    {
        public TaskCentralWebApp.Models.Task Task { get; set; }
        public IEnumerable<TaskCentralWebApp.Models.Document> Documents { get; set; }
    }
}
