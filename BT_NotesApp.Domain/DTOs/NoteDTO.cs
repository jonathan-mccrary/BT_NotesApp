using BT_NotesApp.Domain.Contracts.DTOs;

namespace BT_NotesApp.Domain.Models
{
    public class NoteDTO : INoteDTO
    {
        public NoteDTO()
        {
        }

        public long NoteId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Contents { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public long UserId { get; set; }
    }
}

