using System;
using BT_NotesApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BT_NotesApp.Repository.Context
{
    public class NotesAppContext : DbContext
    {
        public NotesAppContext(DbContextOptions<NotesAppContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
    }
}

