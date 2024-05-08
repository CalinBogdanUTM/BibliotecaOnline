using MyLibrary.BusinessLogic.Core;
using MyLibrary.BusinessLogic.Interfaces;
using MyLibrary.Domain.Entities.User;
using MyLibrary.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;


namespace MyLibrary.BusinessLogic.MainBL

{
     public class SessionBL : UserAPI, ISession
     {
          public ULoginResp UserLogin(ULoginData data)
          {
               return UserLoginAction(data);
          }

        public URegisterResp UserRegister(URegisterData data)
        {
            return UserRegisterAction(data);
        }

        public HttpCookie GenCookie(string loginCredential)
        {
            return Cookie(loginCredential);
        }

        public UserMinimal GetUserByCookie(string apiCookieValue)
        {
            return UserCookie(apiCookieValue);
        }
    }
}
