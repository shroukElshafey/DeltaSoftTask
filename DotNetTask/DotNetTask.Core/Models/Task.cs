using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DotNetTask.Core.Models
{
   public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
        [Required, ForeignKey("Member")]
        public int MemberId { get; set; }
        [Required, MaxLength(100), MinLength(10)]
        public string Description { get; set; }
        [Required]
        public string DeliverDate { get; set; }
        public bool IsDone { get; set; }
        public virtual Member Member { get; set; }
    }
}
