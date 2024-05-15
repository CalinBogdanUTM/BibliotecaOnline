using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Domain.Entities.Book
{public class MyBooksViewModel
    {
        
        public List<BookInfo> ReadNowBooks { get; set; }
        public List<BookInfo> FavoritesBooks { get; set; }
    }
}
