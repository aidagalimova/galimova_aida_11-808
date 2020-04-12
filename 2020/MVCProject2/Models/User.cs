using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject2.Models
{
    [NotMapped]
    public class User : IdentityUser
    {
        public ICollection<Post> Post { get; set; }

        public ICollection<Comment> Comment { get; set; }

    }
}
