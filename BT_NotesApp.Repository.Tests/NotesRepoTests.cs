using BT_NotesApp.Repository.Context;
using BT_NotesApp.Repository.Operations;
using BT_NotesApp.Repository.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.EntityFrameworkCore;

namespace BT_NotesApp.Repository.Tests;

public class NotesRepoTests
{
    private readonly Mock<NotesRepo> _notesRepoMock;
    private readonly Mock<NotesAppContext> _contextMock;
    
    public NotesRepoTests()
    {
        var optionsBuilder = new DbContextOptionsBuilder<NotesAppContext>();
        optionsBuilder.
        _contextMock = new Mock<NotesAppContext>(optionsBuilder.Options);
        _notesRepoMock = new Mock<NotesRepo>(_contextMock.Object);
    }


    [Fact]
    public void GetAllNotes_Test()
    {
        var options = new DbContextOptionsBuilder<NotesAppContext>()
            .UseInMemoryDatabase(databaseName: "MovieListDatabase")
            .Options;

        // Insert seed data into the database using one instance of the context
        using (var context = new MovieDbContext(options))
        {
            context.Movies.Add(new Movie { Id = 1, Title = "Movie 1", YearOfRelease = 2018, Genre = "Action" });
            context.Movies.Add(new Movie { Id = 2, Title = "Movie 2", YearOfRelease = 2018, Genre = "Action" });
            context.Movies.Add(new Movie { Id = 3, Title = "Movie 3", YearOfRelease = 2019, Genre = "Action" });
            context.SaveChanges();
        }

        // Use a clean instance of the context to run the test
        using (var context = new MovieDbContext(options))
        {
            MovieRepository movieRepository = new MovieRepository(context);
            List<Movies> movies == movieRepository.GetAll();

            Assert.Equal(3, movies.Count);
        }



        //arrange
        //var notes = GetSampleNotes();
        //_contextMock.Setup(x => x.Notes)
        //    .Returns(GetSampleNotes);
        _notesRepoMock.Setup(x => x.GetAllNotesAsync())
            .Returns(GetSampleNotes);
        //var repo = new NotesRepo(_contextMock.Object);

        //act
        var actionResult = _notesRepoMock.Object.GetAllNotesAsync();
        var result = actionResult.Result;

        //assert
        Assert.IsType<List<Note>?>(result);
        Assert.Equal(GetSampleNotes().Count(), result.Count());
    }

    private List<Note> GetSampleNotes()
    {
        int count = 10;
        List<Note> notes = new List<Note>();
        for (int i = 0; i < count; i++)
        {
            notes.Add(new Note()
            {
                Contents = $"Note {i} Contents",
                CreatedDate = DateTime.Now.AddDays(-i),
                Description = $"Note {i} Description",
                IsActive = true,
                LastUpdatedDate = DateTime.Now.AddDays(-i),
                NoteId = i,
                Title = $"Note {i} Title",
                UserId = i / 4 + 1
            });
        }
        return notes;
    }
}
