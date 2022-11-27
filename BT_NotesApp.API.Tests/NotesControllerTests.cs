using Azure;
using BT_NotesApp.API.Controllers;
using BT_NotesApp.Domain.Contracts.DTOs;
using BT_NotesApp.Domain.Contracts.Service;
using BT_NotesApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace BT_NotesApp.API.Tests;

public class NotesControllerTests : IDisposable
{
    private readonly Mock<INotesService> _mockNotesLogic;
    private readonly Mock<ILogger<NotesController>> _mockLogger;
    private readonly NotesController _notesController;

    public NotesControllerTests()
    {
        _mockNotesLogic = new Mock<INotesService>();
        _mockLogger = new Mock<ILogger<NotesController>>();
        _notesController = new NotesController(_mockNotesLogic.Object, _mockLogger.Object);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    public async void GetAllNotesAsync_Test(int count)
    {
        //arrange
        var notes = GetSampleNotes(count);
        _mockNotesLogic.Setup(x => x.GetAllNotesAsync())
            .ReturnsAsync(notes);

        //act
        var actionResult = await _notesController.GetAllNotesAsync();
        var okResult = actionResult as OkObjectResult;
        var actual = okResult?.Value as List<INoteDTO>;

        //assert
        Assert.NotNull(actionResult);
        Assert.NotNull(okResult);
        Assert.NotNull(actual);
        Assert.Equal(notes.Count, actual.Count);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    public async void GetAllActiveNotesAsync_Test(int count)
    {
        //arrange
        var notes = GetSampleNotes(count);
        _mockNotesLogic.Setup(x => x.GetAllActiveNotesAsync())
            .ReturnsAsync(notes.Where(p => p.IsActive == true).ToList());

        //act
        var actionResult = await _notesController.GetAllActiveNotesAsync();
        var okResult = actionResult as OkObjectResult;
        var actual = okResult?.Value as List<INoteDTO>;

        //assert
        Assert.NotNull(actionResult);
        Assert.NotNull(okResult);
        Assert.NotNull(actual);
        Assert.Equal(notes.Where(p => p.IsActive == true).ToList().Count, actual.Count);
    }

    [Theory]
    [InlineData(1,0)]
    [InlineData(10,1)]
    [InlineData(100,10)]
    public async void GetAllNotesForUserAsync_Test(int count, int userId)
    {
        //arrange
        var notes = GetSampleNotes(count);
        _mockNotesLogic.Setup(x => x.GetAllNotesForUserAsync(userId))
            .ReturnsAsync(notes.Where(p => p.UserId == userId).ToList());

        //act
        var actionResult = await _notesController.GetAllNotesForUserAsync(userId);
        var okResult = actionResult as OkObjectResult;
        var actual = okResult?.Value as List<INoteDTO>;

        //assert
        Assert.NotNull(actionResult);
        Assert.NotNull(okResult);
        Assert.NotNull(actual);
        Assert.Equal(notes.Where(p => p.UserId == userId).ToList().Count, actual.Count);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(10, 2)]
    [InlineData(100, 3)]
    public async void GetAllActiveNotesForUserAsync_Test(int count, int userId)
    {
        //arrange
        var notes = GetSampleNotes(count);
        _mockNotesLogic.Setup(x => x.GetAllActiveNotesForUserAsync(userId))
            .ReturnsAsync(notes.Where(p =>
                p.UserId == userId
                && p.IsActive == true
            ).ToList());

        //act
        var actionResult = await _notesController.GetAllActiveNotesForUserAsync(userId);
        var okResult = actionResult as OkObjectResult;
        var actual = okResult?.Value as List<INoteDTO>;

        //assert
        Assert.NotNull(actionResult);
        Assert.NotNull(okResult);
        Assert.NotNull(actual);
        Assert.Equal(notes.Where(p =>
            p.UserId == userId
            && p.IsActive == true
            ).ToList().Count, actual.Count);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(100)]
    public async void GetNoteAsync_Test(int count)
    {
        //arrange
        int noteId = count;
        var notes = GetSampleNotes(count);
        _mockNotesLogic.Setup(x => x.GetNoteAsync(noteId))
            .ReturnsAsync(notes.FirstOrDefault(p => p.NoteId == noteId));

        //act
        var actionResult = await _notesController.GetNoteAsync(noteId);
        var okResult = actionResult as OkObjectResult;
        var actual = okResult?.Value as NoteDTO;

        //assert
        Assert.NotNull(actionResult);
        Assert.NotNull(okResult);
        Assert.NotNull(actual);
        Assert.Equal(notes.FirstOrDefault(p => p.NoteId == noteId)?.NoteId, actual.NoteId);
    }


    [Fact]
    public async void AddNoteAsync_Test()
    {
        //arrange
        var notes = GetSampleNotes(1);
        _mockNotesLogic.Setup(x => x.AddNewNoteAsync(notes.First()))
            .ReturnsAsync(notes.First().NoteId);

        //act
        var actionResult = await _notesController.AddNoteAsync((NoteDTO)notes.First());
        var okResult = actionResult as OkObjectResult;
        var actual = (long)(okResult?.Value ?? -1);

        //assert
        Assert.NotNull(actionResult);
        Assert.NotNull(okResult);
        Assert.Equal(notes.First().NoteId, actual);
    }

    private List<INoteDTO> GetSampleNotes(int count)
    {
        List<INoteDTO> notes = new List<INoteDTO>();
        for (int i = 1; i <= count; i++)
        {
            notes.Add(new NoteDTO()
            {
                Contents = $"Note {i} Contents",
                CreatedDate = DateTime.Now.AddHours(i - count),
                Description = $"Note {i} Description",
                IsActive = i % 2 == 1,
                LastUpdatedDate = DateTime.Now.AddHours(i - count),
                NoteId = i,
                Title = $"Note {i} Title",
                UserId = (int)(i / 4)  + 1
            });
        }
        return notes;
    }

    public void Dispose()
    {
        _notesController.Dispose();
    }
}
