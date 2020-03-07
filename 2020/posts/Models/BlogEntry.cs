using System;
using System.Collections.Generic;

namespace posts
{
	public class BlogEntry
	{
		public static int LastId { get; set; }
		public int Id { get; set; }

		[NotEmpty(ErrorMessage = "Имя автора не может быть пустым!")]
		public string AuthorName { get; set; }

		[NotLongLength(ErrorMessage = "Длина текста не может превышать 1000 символов!")]
		[NotEmpty(ErrorMessage = "Текст не может быть пустым!")]
		public string Text { get; set; }
		public DateTime CurrentTime { get; set; }
		public string FileName { get; set; }
		public List<CommentEntry> CommentEntries { get; set; }
	}
}