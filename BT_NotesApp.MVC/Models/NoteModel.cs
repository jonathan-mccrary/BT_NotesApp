using System;
using BT_NotesApp.Domain.Contracts.DTOs;

namespace BT_NotesApp.MVC.Models
{
	public class NoteModel
	{
		public NoteModel()
		{
		}

        public long NoteId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Contents { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        public NoteViewType NoteViewType { get; set; }
    }
}

