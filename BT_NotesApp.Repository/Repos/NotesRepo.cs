using System;
using BT_NotesApp.Repository.Context;
using BT_NotesApp.Repository.Contracts;
using BT_NotesApp.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BT_NotesApp.Repository.Operations
{
	public class NotesRepo : INotesRepo
	{
        private readonly NotesAppContext _context;
        public NotesRepo(NotesAppContext context)
		{
            _context = context;
        }

        /// <summary>
        /// Get all notes
        /// </summary>
        /// <returns></returns>
        public async Task<List<Note>> GetAllNotesAsync()
        {
            return await _context.Notes.ToListAsync();
        }

        /// <summary>
        /// Get all active notes
        /// </summary>
        /// <returns></returns>
        public async Task<List<Note>> GetAllActiveNotesAsync()
        {
            return await _context.Notes.Where(p => p.IsActive == true).ToListAsync();
        }

        /// <summary>
        /// Get all notes for a given userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Note>> GetAllNotesForUserAsync(long userId)
        {
            return await _context.Notes.Where(p => p.UserId == userId).ToListAsync();
        }

        /// <summary>
        /// Get all active notes for a given user
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Note>> GetAllActiveNotesForUserAsync(long userId)
        {
            return await _context.Notes.Where(p =>
                p.UserId == userId
                && p.IsActive == true).ToListAsync();
        }

        /// <summary>
        /// Search notes based on a keyword
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<List<Note>> SearchNotesAsync(string keyword)
        {
            return await _context.Notes.Where(p =>
                EF.Functions.Like(p.Contents.ToLower(), "%" + keyword.ToLower() + "%")
                || EF.Functions.Like(p.Title.ToLower(), "%" + keyword.ToLower() + "%")
                || EF.Functions.Like(p.Description.ToLower(), "%" + keyword.ToLower() + "%"))
                .ToListAsync();
        }

        /// <summary>
        /// search notes based on a keyword and a given user
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Note>> SearchNotesForUserAsync(string keyword, long userId)
        {
            return await _context.Notes.Where(p =>
                (
                    EF.Functions.Like(p.Contents.ToLower(), "%" + keyword.ToLower() + "%")
                    || EF.Functions.Like(p.Title.ToLower(), "%" + keyword.ToLower() + "%")
                    || EF.Functions.Like(p.Description.ToLower(), "%" + keyword.ToLower() + "%")
                )
                && p.UserId == userId)
                .ToListAsync();
        }

        /// <summary>
        /// Get a note by its Id
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public async Task<Note?> GetNoteAsync(long noteId)
        {
            return await _context.Notes.FirstOrDefaultAsync(p => p.NoteId == noteId);
        }

        /// <summary>
        /// Add a note
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public async Task<long> AddNoteAsync(Note note)
        {
            note.CreatedDate = DateTime.Now;
            note.LastUpdatedDate = DateTime.Now;
            note.IsActive = true;
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return note.NoteId;
        }

        /// <summary>
        /// Edit/update a note
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        public async Task EditNoteAsync(Note note)
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

        /// <summary>
        /// Delete a note based on its noteId
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public async Task DeleteNoteAsync(long noteId)
        {
            Note? current = await _context.Notes.FirstOrDefaultAsync(p => p.NoteId == noteId);
            if (current != null)
            {
                _context.Remove(current);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Deactivate a note based on its noteId
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        public async Task DeactivateNoteAsync(long noteId)
        {
            Note? current = await _context.Notes.FirstOrDefaultAsync(p => p.NoteId == noteId);
            if (current != null)
            {
                current.LastUpdatedDate = DateTime.Now;
                current.IsActive = false;
                await _context.SaveChangesAsync();
            }
        }
    }
}