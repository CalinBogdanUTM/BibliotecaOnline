using MyLibrary.Domain.Entities.Book;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.BusinessLogic.DBModel
{
    public class BookContext : DbContext
    {
        public BookContext() : base("name=MyLibrary")
        {
        }

        public virtual DbSet<BookInfo> Books { get; set; }
        
    }
}
