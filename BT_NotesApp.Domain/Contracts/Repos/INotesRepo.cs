using System;
using BT_NotesApp.Domain.Entities;

namespace BT_NotesApp.Domain.Contracts.Repos
{
    public interface INotesRepo
    {
        Task<List<Note>> GetAllNotesAsync();
        Task<List<Note>> GetAllActiveNotesAsync();
        Task<List<Note>> SearchNotesAsync(string keyword);
        Task<Note?> GetNoteAsync(long noteId);
        Task<long> AddNoteAsync(Note note);
        Task EditNoteAsync(Note note);
        Task DeleteNoteAsync(long noteId);
        Task DeactivateNoteAsync(long noteId);
    }
}

