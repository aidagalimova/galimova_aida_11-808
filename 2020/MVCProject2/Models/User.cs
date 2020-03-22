using System.Collections.Generic;

namespace MVCProject2.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public ICollection<Post> Post { get; set; }

        public ICollection<Comment> Comment { get; set; }

    }
}
