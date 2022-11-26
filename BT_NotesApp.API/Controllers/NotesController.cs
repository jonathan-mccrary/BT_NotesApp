using BT_NotesApp.Domain.Contracts.DTOs;
using BT_NotesApp.Domain.Contracts.Logic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BT_NotesApp.API.Controllers
{
    [Route("api/[controller]")]
    public class NotesController : Controller
    {
        private INotesLogic _notesLogic;
        private ILogger _logger;
        public NotesController(
            INotesLogic notesLogic,
            ILogger logger)
        {
            _notesLogic = notesLogic;
            _logger = logger;
        }

        //List<Note> GetAllNotes();
        // GET: api/Notes
        [HttpGet]
        public IActionResult GetAllNotes()
        {
            try
            {
                var allNotes = _notesLogic.GetAllNotes();
                return Ok(allNotes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at GetAllNotes: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Notes
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

        // GET api/Notes/Active
        [HttpGet("Active")]
        public IActionResult GetAllActiveNotes()
        {
            try
            {
                var allNotes = _notesLogic.GetAllNotes();
                return Ok(allNotes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at GetAllNotes: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/Notes/Active
        [HttpGet("Active")]
        public async Task<IActionResult> GetAllActiveNotesAsync()
        {
            try
            {
                var allNotes = await _notesLogic.GetAllNotesAsync();
                return Ok(allNotes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at GetAllActiveNotesAsync: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        //List<Note> GetAllNotesForUser(long userId);
        // GET api/Notes/User/5
        [HttpGet("User/{userId}")]
        public IActionResult GetAllNotesForUser(long userId)
        {
            try
            {
                var notes = _notesLogic.GetAllNotesForUser(userId);
                return Ok(notes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at GetAllNotesForUser: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/Notes/User/5
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



        //List<Note> GetAllActiveNotesForUser(long userId);

        // GET api/Notes/Active/User/5
        [HttpGet("Active/User/{userId}")]
        public IActionResult GetAllActiveNotesForUser(long userId)
        {
            try
            {
                var notes = _notesLogic.GetAllActiveNotesForUser(userId);
                return Ok(notes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at GetAllActiveNotesForUser: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/Notes/Active/User/5
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
        //List<Note> SearchNotes(string keyword);
        //List<Note> SearchNotesForUser(string keyword, long userId);

        // GET api/Notes/5
        [HttpGet("{noteId}")]
        public IActionResult Get(long noteId)
        {
            try
            {
                var note = _notesLogic.GetNote(noteId);
                return Ok(note);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at Get: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET api/Notes/5
        [HttpGet("{noteId}")]
        public async Task<IActionResult> GetAsync(long noteId)
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


        //long AddNote(Note note);
        // POST api/Notes
        [HttpPost]
        public IActionResult AddNote([FromBody]INoteDTO value)
        {
            try
            {
                var noteId = _notesLogic.AddNewNote(value);
                return Ok(noteId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at AddNote: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        //long AddNote(Note note);
        // POST api/Notes
        [HttpPost]
        public async Task<IActionResult> AddNoteAsync([FromBody] INoteDTO value)
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

        //void EditNote(Note note);
        // PUT api/Notes
        [HttpPut]
        public IActionResult EditNote([FromBody]INoteDTO value)
        {
            try
            {
                _notesLogic.EditNote(value);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at EditNote: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        //void EditNote(Note note);
        // PUT api/Notes
        [HttpPut]
        public async Task<IActionResult> EditNoteAsync([FromBody] INoteDTO value)
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

        //void DeleteNote(long noteId);
        // DELETE api/Notes/5
        [HttpDelete("{noteId}")]
        public IActionResult Delete(long noteId)
        {
            try
            {
                _notesLogic.DeleteNote(noteId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at Delete: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        //void DeleteNote(long noteId);
        // DELETE api/Notes/5
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

        //void DeleteNote(long noteId);
        // DELETE api/Notes/Deactivate/5
        [HttpDelete("Deactivate/{noteId}")]
        public IActionResult Deactivate(long noteId)
        {
            try
            {
                _notesLogic.DeactivateNote(noteId);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error at noteId: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        //void DeleteNote(long noteId);
        // DELETE api/Notes/Deactivate5
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