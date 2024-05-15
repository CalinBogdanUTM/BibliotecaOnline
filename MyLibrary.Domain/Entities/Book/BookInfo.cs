using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations; // Add this namespace

namespace MyLibrary.Domain.Entities.Book
{
    public class BookInfo
    {
        [Key] // Add this attribute
        public int BookId { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public DateTime PublishingDate { get; set; }
        public string Language { get; set; }
        public string Category { get; set; }

        public string SourceUrl { get; set; }
    }
}