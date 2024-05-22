using System.Linq;
using System.Web.Mvc;
using System.Xml.XPath;
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
        public ActionResult AddBook(BookInfo addBook)
        {
            if (ModelState.IsValid)
            {
                var result = _session.AddNewBook(addBook);
                if (result.Status)
                {
                    return RedirectToAction("Index","Admin");
                }
                else
                {
                    ModelState.AddModelError("", result.StatusMsg);
                }
            }

            // If ModelState is invalid, return the view with the book data and any error messages
            return View("Index", new AdminViewModel { AddBook = addBook });
        }

       
          [HttpPost]
          [ValidateAntiForgeryToken]
     
          public ActionResult UpdateBook(AdminViewModel model)
          {

         
            if (ModelState.IsValid)
            {
                var bookData = model.EditBook;
                System.Diagnostics.Debug.WriteLine($"User ID: {bookData.BookId}");
                System.Diagnostics.Debug.WriteLine($"User Email: {bookData.Title}");

                var result = _session.UpdateBookInfo(bookData.BookId, bookData);
                  if (result.Status)
                  {
                      return RedirectToAction("Index", "Admin");
                  }
                  else
                  {
                      ViewBag.StatusMsg = result.StatusMsg;
                      ModelState.AddModelError("", result.StatusMsg);
                  }
              }
              // If ModelState is invalid, return the view with the book data and any error messages
              return View("Index", model);
          }


       

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult UpdateUserEmail(AdminViewModel model)
          {
              var emailData = model.emailChange;
              // Log the Id and Email received from the view
              System.Diagnostics.Debug.WriteLine($"User ID: {emailData.Id}");
              System.Diagnostics.Debug.WriteLine($"User Email: {emailData.Email}");

              if (ModelState.IsValid)
              {
                  var result = _session.UpdateUserEmail(emailData.Id, emailData.Email);
                  if (result.Status)
                  {
                      return RedirectToAction("Index");
                  }
                  else
                  {
                      ModelState.AddModelError("", result.StatusMsg);
                  }
              }

              // Log the model state errors for debugging
              var errors = ModelState.Values.SelectMany(v => v.Errors);
              foreach (var error in errors)
              {
                  System.Diagnostics.Debug.WriteLine(error.ErrorMessage);
              }

              // Return the view with the form and model errors
              return RedirectToAction("Index", "Login");
          }

    }
}