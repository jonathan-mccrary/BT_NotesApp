using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BT_NotesApp.Domain.Contracts.DTOs;
using BT_NotesApp.Domain.Contracts.Service;
using BT_NotesApp.Domain.Entities;
using BT_NotesApp.Domain.Models;
using BT_NotesApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BT_NotesApp.MVC.Controllers
{
    public class NoteController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly INotesService _notesService;

        public NoteController(
            ILogger<HomeController> logger,
            INotesService notesService)
        {
            _logger = logger;
            _notesService = notesService;
        }

        public async Task<IActionResult> SubmitNote(NoteModel model)
        {
            INoteDTO note = new NoteDTO()
            {
                IsActive = true,
                Contents = model.Contents,
                CreatedDate = model.NoteViewType == NoteViewType.Add
                    ? DateTime.Now
                    : model.CreatedDate,
                Description = model.Description,
                LastUpdatedDate = DateTime.Now,
                NoteId = model.NoteViewType == NoteViewType.Add
                    ? 0
                    : model.NoteId,
                Title = model.Title
            };

            if (model.NoteViewType == NoteViewType.Add)
            {
                var id = await _notesService.AddNewNoteAsync(note);
            }
            else
            {
                await _notesService.EditNoteAsync(note);
            }
            return Redirect("~/Home/Index");
        }
    }
}