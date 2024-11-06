using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskCentralWebApp.Models
{
    [Table("Log")]
    public partial class Log
    {
        [Key]
        [Column("logID")]
        public int LogId { get; set; }
        [Column("source")]
        [StringLength(20)]
        [Unicode(false)]
        public string Source { get; set; } = null!;
        [Column("type")]
        [StringLength(20)]
        public string Type { get; set; } = null!;
        [Column("dateTime", TypeName = "datetime")]
        [Display(Name = "Date of Record")]
        public DateTime DateTime { get; set; }
        [Column("message")]
        public string? Message { get; set; }
        [Column("originalValue")]
        [Display(Name = "Original Value")]
        public string? OriginalValue { get; set; }
        [Column("currentValue")]
        [Display(Name = "Current Value")]
        public string? CurrentValue { get; set; }
        [Column("userID")]
        public int? UserId { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("Logs")]
        public virtual User? User { get; set; } = null!;
    }
}
