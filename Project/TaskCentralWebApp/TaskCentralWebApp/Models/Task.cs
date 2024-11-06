using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskCentralWebApp.Models
{
    [Table("Task")]
    public partial class Task
    {
        public Task()
        {
            Comments = new HashSet<Comment>();
            Documents = new HashSet<Document>();
            Notifications = new HashSet<Notification>();
        }

        [Key]
        [Column("taskID")]
        public int TaskId { get; set; }
        [Column("taskName")]
        [Display(Name = "Task Name")]
        [StringLength(150)]
        public string TaskName { get; set; } = null!;
        [Column("description")]
        public string? Description { get; set; }
        [Column("status")]
        [StringLength(30)]
        [Unicode(false)]
        public string Status { get; set; } = null!;
        [Column("deadline", TypeName = "date")]
        public DateTime Deadline { get; set; }
        [Column("projectID")]
        public int ProjectId { get; set; }
        [Column("userID")]
        public int UserId { get; set; }

        [ForeignKey("ProjectId")]
        [InverseProperty("Tasks")]
        public virtual Project Project { get; set; } = null!;
        [ForeignKey("UserId")]
        [InverseProperty("Tasks")]
        public virtual User User { get; set; } = null!;
        [InverseProperty("Task")]
        public virtual ICollection<Comment> Comments { get; set; }
        [InverseProperty("Task")]
        public virtual ICollection<Document> Documents { get; set; }
        [InverseProperty("Task")]
        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
