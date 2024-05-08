using MyLibrary.BusinessLogic.DBModel;
using MyLibrary.Domain.Entities.User;
using MyLibrary.Domain.User;
using System;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Net.Cache;
using System.Security.Cryptography;
using MyLibrary.Helpers;
using System.Web.Mvc;
using AutoMapper;
namespace MyLibrary.BusinessLogic.Core
{
     public class UserAPI
     {
          internal ULoginResp UserLoginAction(ULoginData data)
          {
               UDbTable result;
               var validate = new EmailAddressAttribute();
               if (validate.IsValid(data.Credential))
               {
                    var pass = LoginHelper.HashGen(data.Password);
                    using (var db = new UserContext())
                    {
                         result = db.Users.FirstOrDefault(u => u.Email == data.Credential && u.Password == pass);
                    }

                    if (result == null)
                    {
                         return new ULoginResp { Status = 0, StatusMsg = "The Username or Password is Incorrect" };
                    }

                    using (var todo = new UserContext())
                    {
                         result.LasIp = data.LoginIp;
                         result.LastLogin = data.LoginDateTime;
                         todo.Entry(result).State = EntityState.Modified;
                         todo.SaveChanges();
                    }

                    return new ULoginResp { Status = 0 };
               }
               else
               {
                    var pass = LoginHelper.HashGen(data.Password);
                    using (var db = new UserContext())
                    {
                         result = db.Users.FirstOrDefault(u => u.Username == data.Credential && u.Password == pass);
                    }

                    if (result == null)
                    {
                         return new ULoginResp { Status = 0, StatusMsg = "The Username or Password is Incorrect" };
                    }
                    if (result.level == URole.User)
                    {
                         return new ULoginResp { Status = 1 };
                    }
                    if (result.level == URole.Moderator)
                    {
                         return new ULoginResp { Status = 3 };
                    }
                    if (result.level == URole.Admin)
                    {
                         return new ULoginResp { Status = 2 };
                    }

                    using (var todo = new UserContext())
                    {
                         result.LasIp = data.LoginIp;
                         result.LastLogin = data.LoginDateTime;
                         todo.Entry(result).State = EntityState.Modified;
                         todo.SaveChanges();
                    }

                    return new ULoginResp { Status = 1 };
               }
          }
          internal URegisterResp UserRegisterAction(URegisterData data)
          {
               using (var userContext = new UserContext())
               {
                    // Check for duplicate usernames
                    if (userContext.Users.Any(u => u.Username == data.Credential))
                    {
                         return new URegisterResp { Status = false, StatusMsg = "Username already exists" };
                    }

                    // Check for duplicate emails
                    if (userContext.Users.Any(u => u.Email == data.Email))
                    {
                         return new URegisterResp { Status = false, StatusMsg = "Email already registered" };
                    }

                    var user = new UDbTable
                    {
                         Username = data.Credential,
                         Password = LoginHelper.HashGen(data.Password), // Hash the password before storing
                         Email = data.Email,
                         LastLogin = data.RegDateTime,
                         LasIp = data.RegIp,
                    };

                    userContext.Users.Add(user);
                    userContext.SaveChanges();

                    return new URegisterResp { Status = true }; // Registration successful
               }
          }

          public HttpCookie Cookie(string loginCredential)
          {
               var apiCookie = new HttpCookie("X-KEY")
               {
                    Value = CookieGenerator.Create(loginCredential)
               };

               using (var db = new SessionContext())
               {
                    Session curent;
                    var validate = new EmailAddressAttribute();
                    if (validate.IsValid(loginCredential))
                    {
                         curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                    }
                    else
                    {
                         curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                    }

                    if (curent != null)
                    {
                         curent.CookieString = apiCookie.Value;
                         curent.ExpireTime = DateTime.Now.AddMinutes(60);
                         using (var todo = new SessionContext())
                         {
                              todo.Entry(curent).State = EntityState.Modified;
                              todo.SaveChanges();
                         }
                    }
                    else
                    {
                         db.Sessions.Add(new Session
                         {
                              Username = loginCredential,
                              CookieString = apiCookie.Value,
                              ExpireTime = DateTime.Now.AddMinutes(60)
                         });
                         db.SaveChanges();
                    }
               }

               return apiCookie;
          }

          internal UserMinimal UserCookie(string cookie)
          {
               Session session;
               UDbTable curentUser;

               using (var db = new SessionContext())
               {
                    session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
               }

               if (session == null) return null;
               using (var db = new UserContext())
               {
                    var validate = new EmailAddressAttribute();
                    if (validate.IsValid(session.Username))
                    {
                         curentUser = db.Users.FirstOrDefault(u => u.Email == session.Username);
                    }
                    else
                    {
                         curentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
                    }
               }

               if (curentUser == null) return null;
               Mapper.Initialize(cfg => cfg.CreateMap<UDbTable, UserMinimal>());
               var userminimal = Mapper.Map<UserMinimal>(curentUser);

               return userminimal;
          }
     }
}

