using MyLibrary.Domain.Entities.Book;
using MyLibrary.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.BusinessLogic.Interfaces
{
     public interface ISessionAdmin
     {

          BAddResp AddNewBook(BookInfo bookData);

          BAddResp UpdateBookInfo(int bookId, BookInfo updatedBookData);

          UEmailResp UpdateUserEmail(int userId, string newEmail);
     }
}
