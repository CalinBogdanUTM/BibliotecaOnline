using MyLibrary.Domain.Entities.Book;
using MyLibrary.Domain.Entities.User;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Web;

namespace MyLibrary.Web.Models
{
     public class AdminViewModel
     {
          public BookInfo NewBook { get; set; }
          public int EditBookId { get; set; }
          public BookInfo EditBook { get; set; }
          public UserEmailChange UserEmailChange { get; set; }
          public List<UserMinimal> Users { get; set; }
          public List<BookInfo> Books { get; set; }
     }

     public class UserEmailChange
     {
          public int UserId { get; set; }
          public string NewEmail { get; set; }
     }
}