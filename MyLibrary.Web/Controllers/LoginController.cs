using MyLibrary.BusinessLogic.Interfaces;
using MyLibrary.BusinessLogic;
using MyLibrary.Domain.User;
using MyLibrary.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLibrary.Web.Controllers
{
    public class LoginController : Controller
    {
          private readonly ISession _session;
          public LoginController()
          {
               var bl = new BussinesLogic();
               _session = bl.GetSessionBL();
          }
          // GET: Login
          public ActionResult Index()
          {
               return View();
          }
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Index(UserLogin login)
          {
               if(ModelState.IsValid)
               {
                    ULoginData data = new ULoginData
                    {
                         Credential = login.Credential,
                         Password = login.Password,
                         LoginIp = Request.UserHostAddress,
                         LoginDateTime = DateTime.Now
                    };
                    var userLogin = _session.UserLogin(data);

                    if (userLogin.Status)
                    {
                         HttpCookie cookie = _session.GenCookie(login.Credential);
                         ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                         //ADDcookie
                         return RedirectToAction("Index", "Home");
                    }
                    
                    else
                    {
                         ModelState.AddModelError("", userLogin.StatusMsg);
                         return View();
                    }
               }
               return View();

          }

    }
}