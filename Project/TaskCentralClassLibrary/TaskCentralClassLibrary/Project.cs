using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskCentralClassLibrary
{
    [Table("Project")]
    public partial class Project
    {
        public Project()
        {
            ProjectMembers = new HashSet<ProjectMember>();
            Tasks = new HashSet<Task>();
        }

        [Key]
        [Column("projectID")]
        public int ProjectId { get; set; }
        [Column("projectName")]
        [StringLength(150)]
        public string ProjectName { get; set; } = null!;
        [Column("description")]
        public string? Description { get; set; }
        [Column("managerID")]
        public int ManagerId { get; set; }

        [ForeignKey("ManagerId")]
        [InverseProperty("Projects")]
        public virtual User Manager { get; set; } = null!;
        [InverseProperty("Project")]
        public virtual ICollection<ProjectMember> ProjectMembers { get; set; }
        [InverseProperty("Project")]
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
