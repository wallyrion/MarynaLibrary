using System.Collections.Generic;

namespace Library.BL.Models
{
    public class LibraryCard
    {
        public Reader Reader { get; set; }

        public List<Book> Books { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }
    }
}
