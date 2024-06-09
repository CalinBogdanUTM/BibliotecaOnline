using MyLibrary.BusinessLogic.Interfaces;
using MyLibrary.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyLibrary.BusinessLogic.DBModel;
using MyLibrary.Web.Extension;
using MyLibrary.Domain.User;

namespace MyLibrary.Web.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Payment()
        {
            var userId = System.Web.HttpContext.Current.GetMySessionObject()?.Id;
            // If user is not logged in, return false.
            if (userId == null)
            {
                return Json(new { success = false, redirectUrl = Url.Action("Index", "Login") });
            }

            using (var userContext = new UserContext())
            {
                // Find the user in the database
                var user = userContext.Users.FirstOrDefault(u => u.Id == userId);
                if (user != null)
                {
                    user.IsPremiumUser = 1; // Set to 1 (premium user)
                    userContext.SaveChanges(); // Save changes to the database

                    // Payment successful, return the URL to redirect to
                    return Json(new { success = true, redirectUrl = Url.Action("Index", "Home") });
                }
            }

            // Payment failed, return a false success status
            return Json(new { success = false });
        }
    }
}