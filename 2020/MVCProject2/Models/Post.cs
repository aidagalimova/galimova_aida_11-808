using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVCProject2.Models
{
	public class Post
	{
		public int PostId { get; set; }

		public string PostName { get; set; }

		public string UserId { get; set; }
		public User User { get; set; }

		public string Text { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime CurrentTime { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime EditingTime { get; set; }
		public string FileName { get; set; }

		public ICollection<Comment> Comment { get; set; }

	}
}
