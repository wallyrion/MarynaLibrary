using Library.BL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.BL.BookMomento
{
    public class BookHistory
    {
        public Stack<Book> History { get; private set; }
        public BookHistory()
        {
            History = new Stack<Book>();
        }
    }
}
