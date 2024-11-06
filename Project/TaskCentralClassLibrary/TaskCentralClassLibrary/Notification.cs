using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskCentralClassLibrary
{
    [Table("Notification")]
    public partial class Notification
    {
        [Key]
        [Column("notifID")]
        public int NotifId { get; set; }
        [Column("message")]
        public string Message { get; set; } = null!;
        [Column("type")]
        [StringLength(40)]
        public string? Type { get; set; }
        [Column("status")]
        [StringLength(20)]
        public string? Status { get; set; }
        [Column("userID")]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Notifications")]
        public virtual User User { get; set; } = null!;
    }
}
