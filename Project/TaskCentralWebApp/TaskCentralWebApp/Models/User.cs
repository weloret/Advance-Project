using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TaskCentralWebApp.Models
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Documents = new HashSet<Document>();
            Logs = new HashSet<Log>();
            Notifications = new HashSet<Notification>();
            ProjectMembers = new HashSet<ProjectMember>();
            Projects = new HashSet<Project>();
            Tasks = new HashSet<Task>();
        }

        [Key]
        [Column("userID")]
        public int UserId { get; set; }
        [Column("userName")]
        [StringLength(50)]
        public string? UserName { get; set; }
        [Column("aspUserId")]
        [StringLength(450)]
        public string AspUserId { get; set; } = null!;

        [InverseProperty("User")]
        public virtual ICollection<Comment> Comments { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Document> Documents { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Log> Logs { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Notification> Notifications { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
        [InverseProperty("Manager")]
        public virtual ICollection<Project> Projects { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
