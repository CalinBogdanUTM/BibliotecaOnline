using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MyLibrary.BusinessLogic.DBModel;
using MyLibrary.Domain.Entities.Book;
using MyLibrary.Domain.Entities.User;
using MyLibrary.Web.Extension; // Assuming your BookContext is here

namespace MyLibrary.Web.Controllers
{

    public class BooksController : Controller
    {
        private readonly BookContext _context = new BookContext();
        private readonly UserInteractionContext _interactionContext = new UserInteractionContext();

        // GET: Books
        public ActionResult Index()
        {

            List<BookInfo> books = _context.Books.ToList(); // Fetch all books from database
            return View(books); // Pass the list of books to the view
        }

        public ActionResult Details(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost]






        public ActionResult ReadNow(int bookId)
        {
            try
            {
                // Check if the user is logged in (using the session variable)
                if (Session["LoginStatus"] != null && (string)Session["LoginStatus"] == "login")
                {
                    var user = System.Web.HttpContext.Current.GetMySessionObject();
                    var username = user?.Username;

                    // Now you have the username!

                    // Check if the user already has this book marked as 'ReadNow'
                    if (_interactionContext.UserInteractions.Any(u =>
                            u.UserUsername == username &&
                            u.BookId == bookId &&
                            u.Action == UAction.ReadNow))
                    {
                        return Json(new { success = true, message = "Already marked as Read Now." });
                    }
                    else
                    {
                        var interaction = new UserInteraction
                        {
                            UserUsername = username,
                            BookId = bookId,
                            Action = UAction.ReadNow,
                            InteractionTime = DateTime.Now
                        };

                        _interactionContext.UserInteractions.Add(interaction);
                        _interactionContext.SaveChanges();

                        return Json(new { success = true, message = "Successfully marked as Read Now." });
                    }
                }
                else
                {
                    return Json(new { success = false, error = "User not logged in." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        public ActionResult AddtoFavorites(int bookId)
        {
            try
            {
                // Check if the user is logged in (using the session variable)
                if (Session["LoginStatus"] != null && (string)Session["LoginStatus"] == "login")
                {
                    var user = System.Web.HttpContext.Current.GetMySessionObject();
                    var username = user?.Username;

                    // Now you have the username!

                    // Check if the user already has this book marked as 'ReadNow'
                    if (_interactionContext.UserInteractions.Any(u =>
                            u.UserUsername == username &&
                            u.BookId == bookId &&
                            u.Action == UAction.Favorites))
                    {
                        return Json(new { success = true, message = "Already marked as Favorite." });
                    }
                    else
                    {
                        var interaction = new UserInteraction
                        {
                            UserUsername = username,
                            BookId = bookId,
                            Action = UAction.Favorites,
                            InteractionTime = DateTime.Now
                        };

                        _interactionContext.UserInteractions.Add(interaction);
                        _interactionContext.SaveChanges();

                        return Json(new { success = true, message = "Successfully marked as favorite." });
                    }
                }
                else
                {
                    return Json(new { success = false, error = "User not logged in." });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });
            }
        }

        public ActionResult MyBooks()
        {
            // Check if the user is logged in
            if (Session["LoginStatus"] != null && (string)Session["LoginStatus"] == "login")
            {
                var user = System.Web.HttpContext.Current.GetMySessionObject();
                var username = user?.Username;

                if (!string.IsNullOrEmpty(username))
                {
                    // Fetch ReadNow interactions
                    var readNowInteractions = _interactionContext.UserInteractions
                        .Where(u => u.UserUsername == username && u.Action == UAction.ReadNow)
                        .ToList();

                    // Fetch Favorites interactions
                    var favoritesInteractions = _interactionContext.UserInteractions
                        .Where(u => u.UserUsername == username && u.Action == UAction.Favorites)
                        .ToList();

                    // Fetch all books
                    var allBooks = _context.Books.ToList();

                    // Join in memory for Read Now
                    var readNowBooks = readNowInteractions
                        .Join(allBooks,
                            interaction => interaction.BookId,
                            book => book.BookId,
                            (interaction, book) => book)
                        .ToList();

                    // Join in memory for Favorites
                    var favoritesBooks = favoritesInteractions
                        .Join(allBooks,
                            interaction => interaction.BookId,
                            book => book.BookId,
                            (interaction, book) => book)
                        .ToList();

                    // Pass both lists to the view
                    return View(new MyBooksViewModel { ReadNowBooks = readNowBooks, FavoritesBooks = favoritesBooks });
                }
            }

            // User is not logged in, redirect to login page or display an error
            return RedirectToAction("Index", "Home");
        }
    }
}


