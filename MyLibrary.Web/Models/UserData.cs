using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLibrary.Web.Models
{
     public class UserData
    {
        public string Username { get; set; }

        public string Email { get; set; }
 
         public int Id { get; set; }
        public List<string> Products { get; set; }
     }
}