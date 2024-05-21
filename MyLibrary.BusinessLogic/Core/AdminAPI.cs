using MyLibrary.BusinessLogic.DBModel;
using MyLibrary.Domain.Entities.User;
using MyLibrary.Domain.User;
using MyLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Domain.Entities.Book;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace MyLibrary.BusinessLogic.Core
{
     public class AdminAPI
     {

          public BAddResp AddNewBookAction(BookInfo bookData)
          {
               using (var bookContext = new BookContext()) // Assuming you have a BookContext class that inherits from DbContext
               {
                    // Check for duplicate book based on some unique criteria (e.g., Title and Author)
                    if (bookContext.Books.Any(b => b.Title == bookData.Title && b.Author == bookData.Author))
                    {
                         return new BAddResp { Status = false, StatusMsg = "Book already exists" };
                    }

                    var newBook = new BookInfo
                    {
                         Title = bookData.Title,
                         Author = bookData.Author,
                         Description = bookData.Description,
                         ImageUrl = bookData.ImageUrl,
                         PublishingDate = bookData.PublishingDate,
                         Language = bookData.Language,
                         Category = bookData.Category,
                         SourceUrl = bookData.SourceUrl
                    };

                    bookContext.Books.Add(newBook);
                    bookContext.SaveChanges();

                    return new BAddResp { Status = true }; // Book added successfully
               }
          }


          public BAddResp UpdateBookInfoAction(int bookId, BookInfo updatedBookData)
          {
               using (var bookContext = new BookContext()) // Assuming you have a BookContext class that inherits from DbContext
               {
                    // Find the book by its ID
                    var book = bookContext.Books.Find(bookId);

                    if (book == null)
                    {
                         return new BAddResp { Status = false, StatusMsg = "Book already exists" };
                    }

                    // Update the book properties with the new data
                    book.Title = updatedBookData.Title;
                    book.Author = updatedBookData.Author;
                    book.Description = updatedBookData.Description;
                    book.ImageUrl = updatedBookData.ImageUrl;
                    book.PublishingDate = updatedBookData.PublishingDate;
                    book.Language = updatedBookData.Language;
                    book.Category = updatedBookData.Category;
                    book.SourceUrl = updatedBookData.SourceUrl;

                    bookContext.Entry(book).State = EntityState.Modified;
                    bookContext.SaveChanges();

                    return new BAddResp { Status = true };
               }
          }



          public UEmailResp UpdateUserEmailAction(int userId, string newEmail)
          {
               using (var userContext = new UserContext())
               {
                    // Find the user by their ID
                    var user = userContext.Users.Find(userId);

                    if (user == null)
                    {
                         return new UEmailResp { Status = false, StatusMsg = "User dont exist" };
                    }

                    // Check if the new email is already registered
                    if (userContext.Users.Any(u => u.Email == newEmail && u.Id != userId))
                    {
                         return new UEmailResp { Status = false, StatusMsg = "Email already registred" };
                    }

                    // Update the user's email
                    user.Email = newEmail;

                    userContext.Entry(user).State = EntityState.Modified;
                    userContext.SaveChanges();

                    return new UEmailResp { Status = true }; // Email updated successfully
               }
          }
     }
}
