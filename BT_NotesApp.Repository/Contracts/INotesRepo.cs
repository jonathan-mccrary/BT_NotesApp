using System;
using BT_NotesApp.Repository.Entities;

namespace BT_NotesApp.Repository.Contracts
{
    public interface INotesRepo
    {
        Task<List<Note>> GetAllNotesAsync();
        Task<List<Note>> GetAllActiveNotesAsync();
        Task<List<Note>> GetAllNotesForUserAsync(long userId);
        Task<List<Note>> GetAllActiveNotesForUserAsync(long userId);
        Task<List<Note>> SearchNotesAsync(string keyword);
        Task<List<Note>> SearchNotesForUserAsync(string keyword, long userId);
        Task<Note?> GetNoteAsync(long noteId);
        Task<long> AddNoteAsync(Note note);
        Task EditNoteAsync(Note note);
        Task DeleteNoteAsync(long noteId);
        Task DeactivateNoteAsync(long noteId);
    }
}

