using BT_NotesApp.Domain.Contracts.DTOs;
using BT_NotesApp.Domain.Contracts.Repos;
using BT_NotesApp.Domain.Contracts.Service;
using BT_NotesApp.Domain.Mappers;
using Microsoft.Extensions.Logging;

namespace BT_NotesApp.Service
{
    public class NotesService : INotesService
	{
        private readonly INotesRepo _notesRepo;
        private readonly ILogger<NotesService> _logger;

        public NotesService(INotesRepo notesRepo,
            ILogger<NotesService> logger)
        {
            _notesRepo = notesRepo;
            _logger = logger;
        }

        public async Task<List<INoteDTO>> GetAllNotesAsync()
        {
            try
            {
                var notes = await _notesRepo.GetAllNotesAsync();
                return notes.ToDTOs();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at NotesService.GetAllNotesAsync: {ex.Message}");
                return await Task.FromException<List<INoteDTO>>(ex);
            }
        }

        public async Task<List<INoteDTO>> GetAllActiveNotesAsync()
        {
            try
            {
                var notes = await _notesRepo.GetAllActiveNotesAsync();
                return notes.ToDTOs();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at NotesService.GetAllActiveNotesAsync: {ex.Message}");
                return await Task.FromException<List<INoteDTO>>(ex);
            }
        }

        public async Task<List<INoteDTO>> SearchNotesAsync(string keyword)
        {
            try
            {
                var notes = await _notesRepo.SearchNotesAsync(keyword);
                return notes.ToDTOs();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at NotesService.SearchNotesAsync: {ex.Message}");
                return await Task.FromException<List<INoteDTO>>(ex);
            }
        }

        public async Task<INoteDTO?> GetNoteAsync(long noteId)
        {
            try
            {
                var note = await _notesRepo.GetNoteAsync(noteId);
                return note?.ToDTO();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at NotesService.GetNoteAsync: {ex.Message}");
                return await Task.FromException<INoteDTO?>(ex);
            }
        }

        public async Task<long> AddNewNoteAsync(INoteDTO note)
        {
            try
            {
                return await _notesRepo.AddNoteAsync(note.ToEntity());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at NotesService.AddNewNoteAsync: {ex.Message}");
                return await Task.FromException<long>(ex);
            }
        }

        public async Task EditNoteAsync(INoteDTO note)
        {
            try
            {
                await _notesRepo.EditNoteAsync(note.ToEntity());
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at NotesService.EditNoteAsync: {ex.Message}");
                await Task.FromException(ex);
            }
        }

        public async Task DeleteNoteAsync(long noteId)
        {
            try
            {
                await _notesRepo.DeleteNoteAsync(noteId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at NotesService.DeleteNoteAsync: {ex.Message}");
                await Task.FromException(ex);
            }
        }

        public async Task DeactivateNoteAsync(long noteId)
        {
            try
            {
                await _notesRepo.DeactivateNoteAsync(noteId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at NotesService.DeactivateNoteAsync: {ex.Message}");
                await Task.FromException(ex);
            }
        }
    }
}