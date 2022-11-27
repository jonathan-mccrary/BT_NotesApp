using BT_NotesApp.Domain.Contracts.DTOs;
using BT_NotesApp.Domain.Contracts.Service;
using BT_NotesApp.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public List<INoteDTO> GetAllNotes()
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

