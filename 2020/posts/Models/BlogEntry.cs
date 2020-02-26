using System;
using System.Collections.Generic;

namespace posts
{
	public class BlogEntry
	{
		public static int LastId { get; set; }
		public int Id { get; set; }
		public string AuthorName { get; set; }
		public string Text { get; set; }
		public DateTime CurrentTime { get; set; }
		public string FileName { get; set; }
		public List<CommentEntry> CommentEntries { get; set; }
	}
}