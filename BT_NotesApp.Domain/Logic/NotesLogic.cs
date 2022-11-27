
using BT_NotesApp.Domain.Contracts.DTOs;
using BT_NotesApp.Domain.Contracts.Logic;
using BT_NotesApp.Domain.Mappers;
using BT_NotesApp.Repository.Contracts;

namespace BT_NotesApp.Domain.Logic
{
    public class NotesLogic : INotesLogic
	{
        private INotesRepo _notesRepo;
        public NotesLogic(INotesRepo notesRepo)
		{
            _notesRepo = notesRepo;
        }

        #region Synch Methods

        //public long AddNewNote(INoteDTO note)
        //{
        //    return _notesRepo.AddNote(note.ToEntity());
        //}

        //public void DeactivateNote(long noteId)
        //{
        //    _notesRepo.DeactivateNote(noteId);
        //}

        //public void DeleteNote(long noteId)
        //{
        //    _notesRepo.DeleteNote(noteId);
        //}

        //public void EditNote(INoteDTO note)
        //{
        //    _notesRepo.EditNote(note.ToEntity());
        //}

        //public List<INoteDTO> GetAllNotes()
        //{
        //    return _notesRepo.GetAllNotes().ToDTOs();
        //}

        //public List<INoteDTO> GetAllActiveNotes()
        //{
        //    throw new NotImplementedException();
        //}

        //public List<INoteDTO> GetAllNotesForUser(long userId)
        //{
        //    return _notesRepo.GetAllNotesForUser(userId).ToDTOs();
        //}

        //public List<INoteDTO> GetAllActiveNotesForUser(long userId)
        //{
        //    throw new NotImplementedException();
        //}

        //public INoteDTO? GetNote(long noteId)
        //{
        //    return _notesRepo.GetNote(noteId)?.ToDTO();
        //}

        //public List<INoteDTO> SearchNotes(string keyword)
        //{
        //    return _notesRepo.SearchNotes(keyword).ToDTOs();
        //}

        //public List<INoteDTO> SearchNotesForUser(string keyword, long userId)
        //{
        //    return _notesRepo.SearchNotesForUser(keyword, userId).ToDTOs();
        //}

        #endregion Synchronous Methods

        #region Async Methods

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

        #endregion Async Methods
    }
}