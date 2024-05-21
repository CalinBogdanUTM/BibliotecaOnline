using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyLibrary.Domain.Entities.Book;

namespace MyLibrary.Domain.Entities.User
{
    public class UserInteraction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InteractionId { get; set; } // Primary Key

        public string UserUsername { get; set; }

        public int BookId { get; set; }

       public UAction Action { get; set; }

        public DateTime InteractionTime { get; set; }

       
    }
}