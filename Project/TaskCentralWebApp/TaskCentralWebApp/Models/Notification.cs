using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskCentralWebApp.Models
{
    [Table("Notification")]
    public partial class Notification
    {
        [Key]
        [Column("notifID")]
        public int NotifId { get; set; }
        [Column("message")]
        public string Message { get; set; } = null!;
        [Column("dateOfCreation", TypeName = "datetime")]
        [Display(Name = "Notification Date")]
        public DateTime DateOfCreation { get; set; }
        [Column("type")]
        [StringLength(40)]
        public string? Type { get; set; }
        [Column("taskID")]
        public int TaskId { get; set; }
        [Column("status")]
        [StringLength(20)]
        public string? Status { get; set; }
        [Column("userID")]
        public int UserId { get; set; }

        [ForeignKey("TaskId")]
        [InverseProperty("Notifications")]
        public virtual Task Task { get; set; } = null!;
        [ForeignKey("UserId")]
        [InverseProperty("Notifications")]
        public virtual User User { get; set; } = null!;
    }
}
