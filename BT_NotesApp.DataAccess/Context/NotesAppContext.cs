using System;
using BT_NotesApp.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace BT_NotesApp.DataAccess.Context
{
	public class NotesAppContext : DbContext
	{
        public NotesAppContext(DbContextOptions<NotesAppContext> options) : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; }
    }
}

