using System;
using BT_NotesApp.Repository.Context;
using BT_NotesApp.Repository.Contracts;
using BT_NotesApp.Repository.Entities;
using Microsoft.EntityFrameworkCore;

namespace BT_NotesApp.Repository.Operations
{
	public class NotesRepo : INotesRepo
	{
        private readonly NotesAppContext _context;
        public NotesRepo(NotesAppContext context)
		{
            _context = context;
        }

        public List<Note> GetAllNotes()
        {
            return _context.Notes.ToList();
        }

        public List<Note> GetAllActiveNotes()
        {
            return _context.Notes.Where(p => p.IsActive == true).ToList();
        }

        public List<Note> GetAllNotesForUser(long userId)
        {
            return _context.Notes.Where(p => p.UserId == userId).ToList();
        }

        public List<Note> GetAllActiveNotesForUser(long userId)
        {
            return _context.Notes.Where(p =>
                p.UserId == userId
                && p.IsActive == true).ToList();
        }

        public Note? GetNote(long noteId)
        {
            return _context.Notes.FirstOrDefault(p => p.NoteId == noteId);
        }

        public List<Note> SearchNotes(string keyword)
        {
            return _context.Notes.Where(p =>
                p.Contents.Contains(keyword, StringComparison.CurrentCultureIgnoreCase)
            ).ToList();
        }

        public List<Note> SearchNotesForUser(string keyword, long userId)
        {
            return _context.Notes.Where(p =>
                p.Contents.Contains(keyword, StringComparison.CurrentCultureIgnoreCase)
                && p.UserId == userId
            ).ToList();
        }

        public long AddNote(Note note)
        {
            note.CreatedDate = DateTime.Now;
            note.LastUpdatedDate = DateTime.Now;
            note.IsActive = true;
            _context.Notes.Add(note);
            _context.SaveChanges();
            return note.NoteId;
        }

        public void DeactivateNote(long noteId)
        {
            Note? current = _context.Notes.FirstOrDefault(p => p.NoteId == noteId);
            if (current != null)
            {
                current.LastUpdatedDate = DateTime.Now;
                current.IsActive = false;
                _context.SaveChanges();
            }
        }

        public void DeleteNote(long noteId)
        {
            Note? current = _context.Notes.FirstOrDefault(p => p.NoteId == noteId);
            if (current != null)
            {
                _context.Remove(current);
                _context.SaveChanges();
            }
        }

        public void EditNote(Note note)
        {
            Note? current = _context.Notes.FirstOrDefault(p => p.NoteId == note.NoteId);

            if (current != null)
            {
                current.Contents = note.Contents;
                current.Description = note.Description;
                current.IsActive = note.IsActive;
                current.Title = note.Title;
                current.LastUpdatedDate = DateTime.Now;
                _context.SaveChanges();
            }
        }

        public async Task<List<Note>> GetAllNotesAsync()
        {
            return await _context.Notes.ToListAsync();
        }

        public async Task<List<Note>> GetAllActiveNotesAsync()
        {
            return await _context.Notes.Where(p => p.IsActive == true).ToListAsync();
        }

        public async Task<List<Note>> GetAllNotesForUserAsync(long userId)
        {
            return await _context.Notes.Where(p => p.UserId == userId).ToListAsync();
        }

        public async Task<List<Note>> GetAllActiveNotesForUserAsync(long userId)
        {
            return await _context.Notes.Where(p =>
                p.UserId == userId
                && p.IsActive == true).ToListAsync();
        }

        public async Task<List<Note>> SearchNotesAsync(string keyword)
        {
            return await _context.Notes.Where(p => p.Contents.Contains(keyword, StringComparison.CurrentCultureIgnoreCase))
                .ToListAsync();
        }

        public async Task<List<Note>> SearchNotesForUserAsync(string keyword, long userId)
        {
            return await _context.Notes.Where(p =>
                p.Contents.Contains(keyword, StringComparison.CurrentCultureIgnoreCase)
                && p.UserId == userId)
                .ToListAsync();
        }

        public async Task<Note?> GetNoteAsync(long noteId)
        {
            return await _context.Notes.FirstOrDefaultAsync(p => p.NoteId == noteId);
        }

        public async Task<long> AddNoteAsync(Note note)
        {
            note.CreatedDate = DateTime.Now;
            note.LastUpdatedDate = DateTime.Now;
            note.IsActive = true;
            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
            return note.NoteId;
        }

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

        public async Task DeleteNoteAsync(long noteId)
        {
            Note? current = await _context.Notes.FirstOrDefaultAsync(p => p.NoteId == noteId);
            if (current != null)
            {
                _context.Remove(current);
                await _context.SaveChangesAsync();
            }
        }

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