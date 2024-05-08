using MyLibrary.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.BusinessLogic.DBModel
{
     public class SessionContext : DbContext
     {
          public SessionContext() : base("name=MyLibrary")
          {
          }

          public virtual DbSet<Session> Sessions { get; set; }
     }
}
