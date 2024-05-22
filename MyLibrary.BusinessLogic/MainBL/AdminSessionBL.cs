using MyLibrary.BusinessLogic.Core;
using MyLibrary.BusinessLogic.Interfaces;
using MyLibrary.Domain.Entities.Book;
using MyLibrary.Domain.Entities.User;
using MyLibrary.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace MyLibrary.BusinessLogic.MainBL

{
     public class AdminSessionBL : AdminAPI, ISessionAdmin
     {
          public BAddResp AddNewBook(BookInfo bookData)
          {
               return AddNewBookAction (bookData);
          }
          public BAddResp UpdateBookInfo(int bookId, BookInfo updatedBookData)
          {
               return UpdateBookInfoAction(bookId, updatedBookData);
          }
          public UEmailResp UpdateUserEmail(int userId, string newEmail)
          {
               return UpdateUserEmailAction(userId, newEmail);
          }
     }
}
