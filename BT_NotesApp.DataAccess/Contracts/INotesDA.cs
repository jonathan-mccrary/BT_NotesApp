using System;
using BT_NotesApp.DataAccess.Entities;

namespace BT_NotesApp.DataAccess.Contracts
{
    public interface INotesDA
    {
        List<Note> GetAllNotes();
        List<Note> GetAllActiveNotes();
        List<Note> GetAllNotesForUser(long userId);
        List<Note> GetAllActiveNotesForUser(long userId);
        List<Note> SearchNotes(string keyword);
        List<Note> SearchNotesForUser(string keyword, long userId);
        Note? GetNote(long noteId);
        long AddNote(Note note);
        void EditNote(Note note);
        void DeleteNote(long noteId);
        void DeactivateNote(long noteId);

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

