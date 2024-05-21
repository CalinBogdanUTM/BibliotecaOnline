using System.Linq;
using System.Web.Mvc;
using MyLibrary.BusinessLogic;
using MyLibrary.BusinessLogic.Core;
using MyLibrary.BusinessLogic.DBModel;
using MyLibrary.BusinessLogic.Interfaces;
using MyLibrary.Domain.Entities.Book;
using MyLibrary.Domain.Entities.User;
using MyLibrary.Domain.User;
using MyLibrary.Web.Models;

namespace MyLibrary.Web.Controllers
{
     public class AdminController : Controller
     {
          private readonly BookContext _context;
          private readonly UserContext _interactionContext;
          private readonly ISessionAdmin _session;

          public AdminController()
          {
               var bl = new BussinesLogic();
               _session = bl.GetAdminSessionBL();
               _context = new BookContext();
               _interactionContext = new UserContext();
          }

          public ActionResult Index()
          {
               var viewModel = new AdminViewModel
               {
                    Books = _context.Books.ToList(),

               };
               return View(viewModel);
          }

          // Adăugare carte
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult AddBook(BookInfo bookData)
          {
               if (ModelState.IsValid)
               {
                    var result = _session.AddNewBook(bookData);
                    if (result.Status)
                    {
                         return RedirectToAction("Index");
                    }
                    else
                    {
                         ModelState.AddModelError("", result.StatusMsg);
                    }
               }
               return View(bookData);
          }

          // Editare carte
          public ActionResult EditBook(int bookId)
          {
               var book = _context.Books.Find(bookId);
               if (book == null)
               {
                    return HttpNotFound();
               }
               var viewModel = new AdminViewModel
               {
                    EditBook = book
               };
               return View(viewModel);
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult UpdateBook(BookInfo bookData)
          {
               if (ModelState.IsValid)
               {
                    var result = _session.UpdateBookInfo(bookData.BookId, bookData);
                    if (result.Status)
                    {
                         return RedirectToAction("Index");
                    }
                    else
                    {
                         ModelState.AddModelError("", result.StatusMsg);
                    }
               }
               return View("EditBook", bookData);
          }

          // Schimbarea email-ului utilizatorului
          public ActionResult EditUserEmail(int userId)
          {
               var user = _interactionContext.Users.Find(userId);
               if (user == null)
               {
                    return HttpNotFound();
               }
               var viewModel = new AdminViewModel
               {
                    UserEmailChange = new UserEmailChange { UserId = userId, NewEmail = user.Email }
               };
               return View(viewModel);
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult UpdateUserEmail(UserEmailChange emailData)
          {
               if (ModelState.IsValid)
               {
                    var result = _session.UpdateUserEmail(emailData.UserId, emailData.NewEmail);
                    if (result.Status)
                    {
                         return RedirectToAction("Index");
                    }
                    else
                    {
                         ModelState.AddModelError("", result.StatusMsg);
                    }
               }
               return View("EditUserEmail", emailData);
          }
     }
}