using BT_NotesApp.Domain.Contracts.Service;
using BT_NotesApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BT_NotesApp.API.Controllers
{
    [Route("api/[controller]")]
    public class NotesController : Controller
    {
        private INotesService _notesLogic;
        private ILogger<NotesController> _logger;
        public NotesController(
            INotesService notesLogic,
            ILogger<NotesController> logger)
        {
            _notesLogic = notesLogic;
            _logger = logger;
        }

        /// <summary>
        /// GET: api/Notes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllNotesAsync()
        {
            try
            {
                var allNotes = await _notesLogic.GetAllNotesAsync();
                return Ok(allNotes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at GetAllNotesAsync: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// GET api/Notes/Active
        /// </summary>
        /// <returns></returns>
        [HttpGet("Active")]
        public async Task<IActionResult> GetAllActiveNotesAsync()
        {
            try
            {
                var allNotes = await _notesLogic.GetAllActiveNotesAsync();
                return Ok(allNotes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at GetAllActiveNotesAsync: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// GET api/Notes/User/5
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("User/{userId}")]
        public async Task<IActionResult> GetAllNotesForUserAsync(long userId)
        {
            try
            {
                var notes = await _notesLogic.GetAllNotesForUserAsync(userId);
                return Ok(notes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at GetAllNotesForUserAsync: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// GET api/Notes/Active/User/5
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("Active/User/{userId}")]
        public async Task<IActionResult> GetAllActiveNotesForUserAsync(long userId)
        {
            try
            {
                var notes = await _notesLogic.GetAllActiveNotesForUserAsync(userId);
                return Ok(notes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at GetAllActiveNotesForUserAsync: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// GET api/Notes/Search/{keyword}
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        [HttpGet("Search/{keyword}")]
        public async Task<IActionResult> SearchNotes(string keyword)
        {
            try
            {
                var notes = await _notesLogic.SearchNotesAsync(keyword);
                return Ok(notes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at GetAllActiveNotesForUserAsync: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// GET api/Notes/Search/{keyword}/User/{userId}
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("Search/{keyword}/User/{userId}")]
        public async Task<IActionResult> SearchNotesForUser(string keyword, long userId)
        {
            try
            {
                var notes = await _notesLogic.SearchNotesForUserAsync(keyword, userId);
                return Ok(notes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at GetAllActiveNotesForUserAsync: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// GET api/Notes/5
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        [HttpGet("{noteId}")]
        public async Task<IActionResult> GetNoteAsync(long noteId)
        {
            try
            {
                var note = await _notesLogic.GetNoteAsync(noteId);
                return Ok(note);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at GetAsync: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// POST api/Notes
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNoteAsync([FromBody]NoteDTO value)
        {
            try
            {
                var noteId = await _notesLogic.AddNewNoteAsync(value);
                return Ok(noteId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at AddNoteAsync: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// PUT api/Notes
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> EditNoteAsync([FromBody] NoteDTO value)
        {
            try
            {
                await _notesLogic.EditNoteAsync(value);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at EditNote: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// DELETE api/Notes/5
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        [HttpDelete("{noteId}")]
        public async Task<IActionResult> DeleteAsync(long noteId)
        {
            try
            {
                await _notesLogic.DeleteNoteAsync(noteId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at DeleteAsync: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// DELETE api/Notes/Deactivate/5
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns></returns>
        [HttpDelete("Deactivate/{noteId}")]
        public async Task<IActionResult> DeactivateAsync(long noteId)
        {
            try
            {
                await _notesLogic.DeactivateNoteAsync(noteId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at DeleteAsync: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}