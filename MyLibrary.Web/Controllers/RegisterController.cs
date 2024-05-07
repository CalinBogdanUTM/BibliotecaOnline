using MyLibrary.BusinessLogic.Interfaces;
using MyLibrary.BusinessLogic;
using MyLibrary.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MyLibrary.Domain.Entities.User;
using MyLibrary.BusinessLogic.DBModel;
using MyLibrary.Web.Models;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;

namespace MyLibrary.Web.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        private readonly ISession _session;
        public RegisterController()
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
        public ActionResult Index(UserReg reg)
        {
            if (ModelState.IsValid)
            {
                if (reg.Password == reg.ConfirmPassword)
                {
                    URegisterData data = new URegisterData
                    {
                        Credential = reg.Credential,
                        Password = reg.Password,
                        Email = reg.Email,
                        RegIp = Request.UserHostAddress,
                        RegDateTime = DateTime.Now
                    };

                    var userResp = _session.UserRegister(data);

                    if (userResp.Status )
                    {
                              HttpCookie cookie = _session.GenCookie(reg.Credential);
                              ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                              return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", userResp.StatusMsg);
                        return View();
                    }
                }

                else
                {
                   
                    return View();
                }
            }

           

            return View();
        }
    }
}