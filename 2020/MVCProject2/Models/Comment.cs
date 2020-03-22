
using System;
using System.ComponentModel.DataAnnotations;

namespace MVCProject2.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CurrentTime { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }


        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
