using System;
using BT_NotesApp.Domain.Contracts.Repos;
using BT_NotesApp.Domain.Entities;
using BT_NotesApp.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BT_NotesApp.Repository.Repos
{
	public class NotesRepo : INotesRepo
	{
        private readonly ILogger<NotesRepo> _logger;
        private readonly NotesAppContext _context;
        public NotesRepo(NotesAppContext context,
            ILogger<NotesRepo> logger)
		{
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Get all notes
        /// </summary>
        /// <returns></returns>
        public async Task<List<Note>> GetAllNotesAsync()
        {
            try
            {
                return await _context.Notes.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at NotesRepo.GetAllNotesAsync: {ex.Message}");
                return await Task.FromException<List<Note>>(ex);
            }
        }

        /// <summary>
        /// Get all active notes
        /// </summary>
        /// <returns></returns>
        public async Task<List<Note>> GetAllActiveNotesAsync()
        {
            try
            {
                return await _context.Notes.Where(p => p.IsActive == true).ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at NotesRepo.GetAllActiveNotesAsync: {ex.Message}");
                return await Task.FromException<List<Note>>(ex);
            }
        }

        /// <summary>
        /// Search notes based on a keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<List<Note>> SearchNotesAsync(string keyword)
        {
            try
            {
                return await _context.Notes.Where(p =>
                        EF.Functions.Like(p.Contents.ToLower(), "%" + keyword.ToLower() + "%")
                        || EF.Functions.Like(p.Title.ToLower(), "%" + keyword.ToLower() + "%")
                        || EF.Functions.Like(p.Description.ToLower(), "%" + keyword.ToLower() + "%"))
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at NotesRepo.SearchNotesAsync: {ex.Message}");
                return await Task.FromException<List<Note>>(ex);
            }
        }

        /// <summary>
        /// Get a note by its Id
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public async Task<Note?> GetNoteAsync(long noteId)
        {
            try
            {
                return await _context.Notes.FirstOrDefaultAsync(p => p.NoteId == noteId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at NotesRepo.GetNoteAsync: {ex.Message}");
                return await Task.FromException<Note?>(ex);
            }
        }

        /// <summary>
        /// Add a note
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public async Task<long> AddNoteAsync(Note note)
        {
            try
            {
                note.CreatedDate = DateTime.Now;
                note.LastUpdatedDate = DateTime.Now;
                note.IsActive = true;
                _context.Notes.Add(note);
                await _context.SaveChangesAsync();
                return note.NoteId;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at NotesRepo.AddNoteAsync: {ex.Message}");
                return await Task.FromException<long>(ex);
            }
        }

        /// <summary>
        /// Edit/update a note
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public async Task EditNoteAsync(Note note)
        {
            try
            {
                Note? current = await _context.Notes.FirstOrDefaultAsync(p => p.NoteId == note.NoteId);

                if (current != null)
                {
                    current.Contents = note.Contents;
                    current.Description = note.Description;
                    current.IsActive = note.IsActive;
                    current.Title = note.Title;
                    current.LastUpdatedDate = DateTime.Now;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at NotesRepo.EditNoteAsync: {ex.Message}");
                await Task.FromException(ex);
            }
        }

        /// <summary>
        /// Delete a note based on its noteId
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public async Task DeleteNoteAsync(long noteId)
        {
            try
            {
                Note? current = await _context.Notes.FirstOrDefaultAsync(p => p.NoteId == noteId);
                if (current != null)
                {
                    _context.Remove(current);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at NotesRepo.DeleteNoteAsync: {ex.Message}");
                await Task.FromException(ex);
            }
        }

        /// <summary>
        /// Deactivate a note based on its noteId
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public async Task DeactivateNoteAsync(long noteId)
        {
            try
            {
                Note? current = await _context.Notes.FirstOrDefaultAsync(p => p.NoteId == noteId);
                if (current != null)
                {
                    current.LastUpdatedDate = DateTime.Now;
                    current.IsActive = false;
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at NotesRepo.DeactivateNoteAsync: {ex.Message}");
                await Task.FromException(ex);
            }
        }
    }
}