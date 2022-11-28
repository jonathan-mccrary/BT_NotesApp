using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BT_NotesApp.MVC.Models;
using BT_NotesApp.Domain.Contracts.Service;
using BT_NotesApp.Domain.Contracts.DTOs;

namespace BT_NotesApp.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly INotesService _notesService;

    public HomeController(
        ILogger<HomeController> logger,
        INotesService notesService)
    {
        _logger = logger;
        _notesService = notesService;
    }

    public async Task<IActionResult> Index()
    {
        _logger.LogInformation("Loading home page");
        NotesListViewModel model = new NotesListViewModel();
        model.Notes = await _notesService.GetAllNotesAsync();
        return View(model);
    }

    public IActionResult AddNote()
    {
        _logger.LogInformation("Adding Note");
        NoteModel model = new NoteModel();
        model.NoteViewType = NoteViewType.Add;
        model.IsActive = true;

        return View("NoteView", model);
    }

    public async Task<IActionResult> EditNote(long noteId)
    {
        _logger.LogInformation($"Editing Note {noteId}");
        var note = await _notesService.GetNoteAsync(noteId);
        if (note != null)
        {
            NoteModel model = new NoteModel()
            {
                Contents = note.Contents,
                CreatedDate = note.CreatedDate,
                Description = note.Description,
                IsActive = note.IsActive,
                LastUpdatedDate = note.LastUpdatedDate,
                NoteId = note.NoteId,
                Title = note.Title,
                NoteViewType = NoteViewType.Edit
            };
            return View("NoteView", model);
        }
        else
        {
            _logger.LogInformation($"Note {noteId} not found");
            ErrorViewModel model = new ErrorViewModel()
            {
                Message = "Note not found."
            };
            return View("Error", model);
        }
    }

    [HttpGet("{noteId}")]
    public async Task<IActionResult> GoToNote(long noteId)
    {
        _logger.LogInformation($"Go To Note {noteId}");
        var note = await _notesService.GetNoteAsync(noteId);
        if (note != null)
        {
            NoteModel model = new NoteModel()
            {
                Contents = note.Contents,
                CreatedDate = note.CreatedDate,
                Description = note.Description,
                IsActive = note.IsActive,
                LastUpdatedDate = note.LastUpdatedDate,
                NoteId = note.NoteId,
                Title = note.Title,
                NoteViewType = NoteViewType.View
            };
            return View("NoteView", model);
        }
        else
        {
            _logger.LogInformation($"Note {noteId} not found");
            ErrorViewModel model = new ErrorViewModel()
            {
                Message = "Note not found."
            };
            return View("Error", model);
        }
    }

    public async Task<IActionResult> ViewNote(long noteId)
    {
        _logger.LogInformation($"Viewing Note {noteId}");
        var note = await _notesService.GetNoteAsync(noteId);
        if (note != null)
        {
            NoteModel model = new NoteModel()
            {
                Contents = note.Contents,
                CreatedDate = note.CreatedDate,
                Description = note.Description,
                IsActive = note.IsActive,
                LastUpdatedDate = note.LastUpdatedDate,
                NoteId = note.NoteId,
                Title = note.Title,
                NoteViewType = NoteViewType.View
            };
            return View("NoteView", model);
        }
        else
        {
            _logger.LogInformation($"Note {noteId} not found");
            ErrorViewModel model = new ErrorViewModel()
            {
                Message = "Note not found."
            };
            return View("Error", model);
        }
    }

    public async Task<IActionResult> DeleteNote(long noteId)
    {
        _logger.LogInformation($"Deleting Note {noteId}");
        await _notesService.DeleteNoteAsync(noteId);
        return Redirect("~/Home/Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

