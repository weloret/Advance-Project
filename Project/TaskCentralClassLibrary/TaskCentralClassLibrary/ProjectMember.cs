using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskCentralClassLibrary
{
    [Table("ProjectMember")]
    public partial class ProjectMember
    {
        [Key]
        [Column("memberID")]
        public int MemberId { get; set; }
        [Column("projectID")]
        public int ProjectId { get; set; }
        [Column("userID")]
        public int UserId { get; set; }

        [ForeignKey("ProjectId")]
        [InverseProperty("ProjectMembers")]
        public virtual Project Project { get; set; } = null!;
        [ForeignKey("UserId")]
        [InverseProperty("ProjectMembers")]
        public virtual User User { get; set; } = null!;
    }
}
