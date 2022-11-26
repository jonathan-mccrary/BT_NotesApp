using BT_NotesApp.DataAccess.Contracts;
using BT_NotesApp.Domain.Contracts.DTOs;
using BT_NotesApp.Domain.Contracts.Logic;
using BT_NotesApp.Domain.Mappers;

namespace BT_NotesApp.Domain.Logic
{
    public class NotesLogic : INotesLogic
	{
        private INotesDA _notesDA;
        public NotesLogic(INotesDA notesDA)
		{
            _notesDA = notesDA;
        }

        #region Synch Methods

        public long AddNewNote(INoteDTO note)
        {
            return _notesDA.AddNote(note.ToEntity());
        }

        public void DeactivateNote(long noteId)
        {
            _notesDA.DeactivateNote(noteId);
        }

        public void DeleteNote(long noteId)
        {
            _notesDA.DeleteNote(noteId);
        }

        public void EditNote(INoteDTO note)
        {
            _notesDA.EditNote(note.ToEntity());
        }

        public List<INoteDTO> GetAllNotes()
        {
            return _notesDA.GetAllNotes().ToDTOs();
        }

        public List<INoteDTO> GetAllActiveNotes()
        {
            throw new NotImplementedException();
        }

        public List<INoteDTO> GetAllNotesForUser(long userId)
        {
            return _notesDA.GetAllNotesForUser(userId).ToDTOs();
        }

        public List<INoteDTO> GetAllActiveNotesForUser(long userId)
        {
            throw new NotImplementedException();
        }

        public INoteDTO? GetNote(long noteId)
        {
            return _notesDA.GetNote(noteId)?.ToDTO();
        }

        public List<INoteDTO> SearchNotes(string keyword)
        {
            return _notesDA.SearchNotes(keyword).ToDTOs();
        }

        public List<INoteDTO> SearchNotesForUser(string keyword, long userId)
        {
            return _notesDA.SearchNotesForUser(keyword, userId).ToDTOs();
        }

        #endregion Synchronous Methods

        #region Async Methods

        public async Task<List<INoteDTO>> GetAllNotesAsync()
        {
            var notes = await _notesDA.GetAllNotesAsync();
            return notes.ToDTOs();
        }

        public async Task<List<INoteDTO>> GetAllActiveNotesAsync()
        {
            var notes = await _notesDA.GetAllActiveNotesAsync();
            return notes.ToDTOs();
        }

        public async Task<List<INoteDTO>> GetAllNotesForUserAsync(long userId)
        {
            var notes = await _notesDA.GetAllNotesForUserAsync(userId);
            return notes.ToDTOs();
        }

        public async Task<List<INoteDTO>> GetAllActiveNotesForUserAsync(long userId)
        {
            var notes = await _notesDA.GetAllActiveNotesForUserAsync(userId);
            return notes.ToDTOs();
        }

        public async Task<List<INoteDTO>> SearchNotesAsync(string keyword)
        {
            var notes = await _notesDA.SearchNotesAsync(keyword);
            return notes.ToDTOs();
        }

        public async Task<List<INoteDTO>> SearchNotesForUserAsync(string keyword, long userId)
        {
            var notes = await _notesDA.SearchNotesForUserAsync(keyword, userId);
            return notes.ToDTOs();
        }

        public async Task<INoteDTO?> GetNoteAsync(long noteId)
        {
            var note = await _notesDA.GetNoteAsync(noteId);
            return note?.ToDTO();
        }

        public async Task<long> AddNewNoteAsync(INoteDTO note)
        {
            return await _notesDA.AddNoteAsync(note.ToEntity());
        }

        public async Task EditNoteAsync(INoteDTO note)
        {
            await _notesDA.EditNoteAsync(note.ToEntity());
        }

        public async Task DeleteNoteAsync(long noteId)
        {
            await _notesDA.DeleteNoteAsync(noteId);
        }

        public async Task DeactivateNoteAsync(long noteId)
        {
            await _notesDA.DeactivateNoteAsync(noteId);
        }

        #endregion Async Methods
    }
}