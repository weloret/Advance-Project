using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskCentralClassLibrary
{
    [Table("Comment")]
    public partial class Comment
    {
        [Key]
        [Column("commentID")]
        public int CommentId { get; set; }
        [Column("text")]
        public string Text { get; set; } = null!;
        [Column("dateTime", TypeName = "datetime")]
        public DateTime DateTime { get; set; }
        [Column("taskID")]
        public int TaskId { get; set; }
        [Column("userID")]
        public int UserId { get; set; }

        [ForeignKey("TaskId")]
        [InverseProperty("Comments")]
        public virtual Task Task { get; set; } = null!;
        [ForeignKey("UserId")]
        [InverseProperty("Comments")]
        public virtual User User { get; set; } = null!;
    }
}
