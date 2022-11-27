using System;
using BT_NotesApp.Domain.Contracts.DTOs;

namespace BT_NotesApp.Domain.Contracts.Service
{
	public interface INotesService
	{
        Task<List<INoteDTO>> GetAllNotesAsync();
        Task<List<INoteDTO>> GetAllActiveNotesAsync();
        Task<List<INoteDTO>> SearchNotesAsync(string keyword);
        Task<INoteDTO?> GetNoteAsync(long noteId);
        Task<long> AddNewNoteAsync(INoteDTO note);
        Task EditNoteAsync(INoteDTO note);
        Task DeleteNoteAsync(long noteId);
        Task DeactivateNoteAsync(long noteId);
    }
}

