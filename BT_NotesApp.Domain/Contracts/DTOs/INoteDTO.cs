namespace BT_NotesApp.Domain.Contracts.DTOs
{
    public interface INoteDTO
    {
        long NoteId { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        string Contents { get; set; }
        bool IsActive { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime LastUpdatedDate { get; set; }
    }
}