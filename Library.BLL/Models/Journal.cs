using System.Collections.Generic;

namespace Library.BLL.Models
{
    public class Journal
    {
        public Person Person { get; set; }

        public List<Book> Books { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }
    }
}