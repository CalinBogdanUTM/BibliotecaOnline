using MyLibrary.BusinessLogic.Core;
using MyLibrary.Domain.Entities.User;
using MyLibrary.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.BusinessLogic.Interfaces;
using System.Web;
using MyLibrary.Domain.Entities.Book;

namespace MyLibrary.BusinessLogic.Interfaces

{
     public interface ISession
     {
         ULoginResp UserLogin(ULoginData data);
         URegisterResp UserRegister(URegisterData data);
         HttpCookie GenCookie(string loginCredential);
         UserMinimal GetUserByCookie(string apiCookieValue);

    }
}
