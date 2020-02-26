using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace posts
{
    public class CommentEntry
    {
        public static int LastId { get; set; }
        public int Id { get; set; }
        public string AuthorName {get; set;}
        public string CommentText { get; set; }
        public int BlogEntryId { get; set; }
    }
}
