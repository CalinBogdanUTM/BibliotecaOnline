using MyLibrary.BusinessLogic.Interfaces;
using MyLibrary.BusinessLogic.MainBL;

namespace MyLibrary.BusinessLogic
{
    public class BussinesLogic
    {
          public ISession GetSessionBL()
          {
               return new SessionBL();
          }

          public ISessionAdmin GetAdminSessionBL()
          {
               return new AdminSessionBL();
          }
     }
}
