using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Domain.Entities.User
{
    public class URegisterData
    {
        public string Credential { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
        public string RegIp { get; set; }
        public DateTime RegDateTime { get; set; }


    }
}

