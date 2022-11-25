using System;
namespace BT_NotesApp.DataAccess.Entities
{
	public class Note
	{
		public Note()
		{
		}

		public long NodeId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public string Contents { get; set; }
		public long UserId { get; set; }
	}
}

