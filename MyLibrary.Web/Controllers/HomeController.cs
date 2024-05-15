using MyLibrary.Web.Extension;
using MyLibrary.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLibrary.Web.Controllers
{
     public class HomeController : BaseController
     {
          // GET: Home
          public ActionResult Index()
          {
               SessionStatus();
               

               
               return View();
          }

        

         
     }
}