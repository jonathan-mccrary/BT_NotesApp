using BT_NotesApp.Domain.Contracts.DTOs;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BT_NotesApp.Domain.Models
{
    public class NoteDTO : INoteDTO
    {
        public NoteDTO()
        {
        }

        [JsonPropertyName("noteId")]
        public long NoteId { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("contents")]
        public string Contents { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; }

        [JsonPropertyName("createdDate")]
        public DateTime CreatedDate { get; set; }

        [JsonPropertyName("lastUpdatedDate")]
        public DateTime LastUpdatedDate { get; set; }
    }
}

