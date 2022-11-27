
using BT_NotesApp.Domain.Contracts.DTOs;
using BT_NotesApp.Domain.Contracts.Logic;
using BT_NotesApp.Domain.Mappers;
using BT_NotesApp.Repository.Contracts;

namespace BT_NotesApp.Domain.Logic
{
    public class NotesLogic : INotesLogic
	{
        private readonly INotesRepo _notesRepo;
        public NotesLogic(INotesRepo notesRepo)
		{
            _notesRepo = notesRepo;
        }

        public async Task<List<INoteDTO>> GetAllNotesAsync()
        {
            var notes = await _notesRepo.GetAllNotesAsync();
            return notes.ToDTOs();
        }

        public async Task<List<INoteDTO>> GetAllActiveNotesAsync()
        {
            var notes = await _notesRepo.GetAllActiveNotesAsync();
            return notes.ToDTOs();
        }

        public async Task<List<INoteDTO>> GetAllNotesForUserAsync(long userId)
        {
            var notes = await _notesRepo.GetAllNotesForUserAsync(userId);
            return notes.ToDTOs();
        }

        public async Task<List<INoteDTO>> GetAllActiveNotesForUserAsync(long userId)
        {
            var notes = await _notesRepo.GetAllActiveNotesForUserAsync(userId);
            return notes.ToDTOs();
        }

        public async Task<List<INoteDTO>> SearchNotesAsync(string keyword)
        {
            var notes = await _notesRepo.SearchNotesAsync(keyword);
            return notes.ToDTOs();
        }

        public async Task<List<INoteDTO>> SearchNotesForUserAsync(string keyword, long userId)
        {
            var notes = await _notesRepo.SearchNotesForUserAsync(keyword, userId);
            return notes.ToDTOs();
        }

        public async Task<INoteDTO?> GetNoteAsync(long noteId)
        {
            var note = await _notesRepo.GetNoteAsync(noteId);
            return note?.ToDTO();
        }

        public async Task<long> AddNewNoteAsync(INoteDTO note)
        {
            return await _notesRepo.AddNoteAsync(note.ToEntity());
        }

        public async Task EditNoteAsync(INoteDTO note)
        {
            await _notesRepo.EditNoteAsync(note.ToEntity());
        }

        public async Task DeleteNoteAsync(long noteId)
        {
            await _notesRepo.DeleteNoteAsync(noteId);
        }

        public async Task DeactivateNoteAsync(long noteId)
        {
            await _notesRepo.DeactivateNoteAsync(noteId);
        }
    }
}