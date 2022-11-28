using System;
using BT_NotesApp.Domain.Contracts.DTOs;

namespace BT_NotesApp.MVC.Models
{
	public class NotesListViewModel
	{
		public NotesListViewModel()
		{
		}

		public List<INoteDTO> Notes { get; set; }
	}
}

