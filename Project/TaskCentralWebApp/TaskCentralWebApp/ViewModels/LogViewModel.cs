using System.ComponentModel.DataAnnotations;
using TaskCentralWebApp.Migrations;

namespace TaskCentralWebApp.ViewModels
{
    public class LogViewModel
    {
        public int LogId { get; set; }
        public string Source { get; set; }
        public string Type { get; set; }
        [Display(Name = "Date of Record")]
        public DateTime DateTime { get; set; }
        public string Message { get; set; }
        [Display(Name = "Original Value")]
        public string OriginalValue { get; set; }
        [Display(Name = "Current Value")]
        public string CurrentValue { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }
}
