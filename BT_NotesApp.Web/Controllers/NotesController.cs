using BT_NotesApp.Domain.Contracts.DTOs;
using BT_NotesApp.Domain.Contracts.Service;
using BT_NotesApp.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BT_NotesApp.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly INotesService _notesService;
        private readonly ILogger<NotesController> _logger;

        public NotesController(INotesService notesService, ILogger<NotesController> logger)
        {
            _notesService = notesService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<INoteDTO> Get()
        {
            List<INoteDTO> noteDTOs = new List<INoteDTO>();
            var response = _notesService.GetAllNotesAsync();
            if (response.IsCompletedSuccessfully)
            {
                noteDTOs = response.Result;
            }
            return noteDTOs;
        }
        //Task<List<INoteDTO>> GetAllNotesAsync();
        //Task<List<INoteDTO>> GetAllActiveNotesAsync();
        //Task<List<INoteDTO>> GetAllNotesForUserAsync(long userId);
        //Task<List<INoteDTO>> GetAllActiveNotesForUserAsync(long userId);
        //Task<List<INoteDTO>> SearchNotesAsync(string keyword);
        //Task<List<INoteDTO>> SearchNotesForUserAsync(string keyword, long userId);
        //Task<INoteDTO?> GetNoteAsync(long noteId);
        //Task<long> AddNewNoteAsync(INoteDTO note);
        //Task EditNoteAsync(INoteDTO note);
        //Task DeleteNoteAsync(long noteId);
        //Task DeactivateNoteAsync(long noteId);
    }
}

