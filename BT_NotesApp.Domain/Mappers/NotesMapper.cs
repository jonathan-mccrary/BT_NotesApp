using System;
using BT_NotesApp.DataAccess.Entities;
using BT_NotesApp.Domain.Contracts.DTOs;
using BT_NotesApp.Domain.Models;

namespace BT_NotesApp.Domain.Mappers
{
	public static class NotesMapper
	{
		public static Note ToEntity(this INoteDTO note)
        {
			return new Note()
			{
				Contents = note.Contents,
				CreatedDate = note.CreatedDate,
				Description = note.Description,
				IsActive = note.IsActive,
				LastUpdatedDate = note.LastUpdatedDate,
				NoteId = note.NoteId,
				Title = note.Title,
				UserId = note.UserId
			};
		}

        public static List<Note> ToEntities(this List<INoteDTO> notes)
        {
            List<Note> noteEntities = new List<Note>();
            foreach(var note in notes)
            {
                noteEntities.Add(note.ToEntity());
            }
			return noteEntities;
        }

        public static INoteDTO ToDTO(this Note note)
		{
			return new NoteDTO()
			{
                Contents = note.Contents,
                CreatedDate = note.CreatedDate,
                Description = note.Description,
                IsActive = note.IsActive,
                LastUpdatedDate = note.LastUpdatedDate,
                NoteId = note.NoteId,
                Title = note.Title,
                UserId = note.UserId
            };
		}

        public static List<INoteDTO> ToDTOs(this List<Note> notes)
        {
            List<INoteDTO> noteDTOs = new List<INoteDTO>();
            foreach (var note in notes)
            {
                noteDTOs.Add(note.ToDTO());
            }
            return noteDTOs;
        }
    }
}

