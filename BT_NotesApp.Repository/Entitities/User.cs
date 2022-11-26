using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace BT_NotesApp.Repository.Entities
{
    [Table("User")]
    public class User
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 1)]
        public long UserId { get; set; }

        [Column(Order = 2)]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Column(Order = 3)]
        [MaxLength(50)]
        public string Password { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}