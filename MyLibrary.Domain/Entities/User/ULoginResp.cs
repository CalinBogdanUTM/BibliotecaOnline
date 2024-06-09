using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLibrary.Domain.User;

namespace MyLibrary.Domain.Entities.User
{
     public class ULoginResp
     {
          public bool Status { get; set; }
          public string StatusMsg { get; set; }

          public URole level{ get; set; }
     }
}

