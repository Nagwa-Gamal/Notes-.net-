using Microsoft.AspNetCore.Identity;
using Notes.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.Authentication
{
    public class User:IdentityUser
    {
        public virtual ICollection<Note> Note { get; set; }
        public string isAdmin { get; set; }

    }
}
