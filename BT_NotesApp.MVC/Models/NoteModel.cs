using System;
using System.ComponentModel.DataAnnotations;
using BT_NotesApp.Domain.Contracts.DTOs;

namespace BT_NotesApp.MVC.Models
{
	public class NoteModel
	{
		public NoteModel()
		{
		}

        public long NoteId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Contents is required")]
        [MaxLength(2000)]
        public string Contents { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public NoteViewType NoteViewType { get; set; }

        public bool IsValid { get; set; }
    }
}

