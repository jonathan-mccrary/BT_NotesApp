using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BT_NotesApp.DataAccess.Entities;
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
        public NotesController(INotesLogic notesLogic)
        {
            _notesLogic = notesLogic;
        }

        //List<Note> GetAllNotes();
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
                return StatusCode(500, "Internal server error");
            }
        }

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
                return StatusCode(500, "Internal server error");
            }
        }

        //List<Note> GetAllNotesForUser(long userId);
        //List<Note> SearchNotes(string keyword);
        //List<Note> SearchNotesForUser(string keyword, long userId);

        //long AddNote(Note note);
        //void EditNote(Note note);
        //void DeleteNote(long noteId);
        //void DeactivateNote(long noteId);


        //Note? GetNote(long noteId);
        // GET api/Notes/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/Notes
        [HttpPost]
        public void AddNote([FromBody]string value)
        {
        }

        // PUT api/Notes/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/Notes/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

