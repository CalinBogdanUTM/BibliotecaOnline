using MyLibrary.Domain.Entities.Book;
using MyLibrary.Domain.Entities.User;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;
using MyLibrary.Domain.User;

namespace MyLibrary.Web.Models
{
     public class AdminViewModel
     {
        public BookInfo AddBook { get; set; } = new BookInfo(); // For adding a new book
        public BookInfo EditBook { get; set; } // For editing an existing book
        public UserData emailChange { get; set; } // For changing a user's email
        public IEnumerable<UDbTable> Users { get; set; } // List of users
        public IEnumerable<BookInfo> Books { get; set; } // List of books

 
     }


}