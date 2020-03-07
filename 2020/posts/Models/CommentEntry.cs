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

        [NotEmpty(ErrorMessage = "Имя автора не может быть пустым!")]
        public string AuthorName {get; set;}

        [NotLongLength(ErrorMessage = "Длина текста не может превышать 1000 символов!")]
        [NotEmpty(ErrorMessage = "Текст не может быть пустым!")]
        public string CommentText { get; set; }
        public int BlogEntryId { get; set; }
    }
}
