using System;
using BT_NotesApp.Domain.Contracts.DTOs;

namespace BT_NotesApp.Domain.Contracts.Logic
{
	public interface INotesLogic
	{
        Task<List<INoteDTO>> GetAllNotesAsync();
        Task<List<INoteDTO>> GetAllActiveNotesAsync();
        Task<List<INoteDTO>> GetAllNotesForUserAsync(long userId);
        Task<List<INoteDTO>> GetAllActiveNotesForUserAsync(long userId);
        Task<List<INoteDTO>> SearchNotesAsync(string keyword);
        Task<List<INoteDTO>> SearchNotesForUserAsync(string keyword, long userId);
        Task<INoteDTO?> GetNoteAsync(long noteId);
        Task<long> AddNewNoteAsync(INoteDTO note);
        Task EditNoteAsync(INoteDTO note);
        Task DeleteNoteAsync(long noteId);
        Task DeactivateNoteAsync(long noteId);
    }
}

