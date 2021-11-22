using Notes.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Notes.Entities
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User user { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Enter title")]

        public string Title { get; set; }
        [Required(ErrorMessage ="Enter message")]
        public string Text { get; set; }



    }
}
