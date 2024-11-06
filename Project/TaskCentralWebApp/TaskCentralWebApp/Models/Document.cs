using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TaskCentralWebApp.Models
{
    [Table("Document")]
    public partial class Document
    {
        [Key]
        [Column("docID")]
        public int DocId { get; set; }
        [Column("docName")]
        [Display(Name = "Document Name")]
        public string DocName { get; set; } = null!;
        [Column("uploadDate", TypeName = "date")]
        [Display(Name = "Upload Date")]
        public DateTime UploadDate { get; set; }
        [Column("docType")]
        [Display(Name = "Document Type")]
        public string DocType { get; set; } = null!;
        [Column("docSource")]
        public byte[] DocSource { get; set; } = null!;
        [Column("taskID")]
        public int TaskId { get; set; }
        [Column("userID")]
        public int UserId { get; set; }

        [ForeignKey("TaskId")]
        [InverseProperty("Documents")]
        public virtual Task Task { get; set; } = null!;
        [ForeignKey("UserId")]
        [InverseProperty("Documents")]
        public virtual User User { get; set; } = null!;
    }
}
