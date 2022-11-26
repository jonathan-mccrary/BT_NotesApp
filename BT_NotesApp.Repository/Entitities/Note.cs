
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BT_NotesApp.Repository.Entities
{
    [Table("Note")]
    public class Note
	{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column(Order = 1)]
        public long NoteId { get; set; }

        [Column(Order = 2)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Column(Order = 3)]
        [MaxLength(200)]
        public string Description { get; set; }

        [Column(Order = 4)]
        public string Contents { get; set; }

        [Column(Order = 5)]
        public bool IsActive { get; set; }

        [Column(Order = 6)]
        public DateTime CreatedDate { get; set; }

        [Column(Order = 7)]
        public DateTime LastUpdatedDate { get; set; }


        [Column(Order = 8)]
        [ForeignKey("User")]
		public long UserId { get; set; }
	}
}

