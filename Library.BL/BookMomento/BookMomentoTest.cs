using Library.BL.Models;
using System;

namespace Library.BL.BookMomento
{
    public static class BookMomentoTest
    {
        public static void ChangeBook()
        {
            var book = new Book();
            var history = new BookHistory();
            book.Id = Guid.NewGuid();

            history.History.Push(book);

            book.Author = "jn. bouler";
            history.History.Push(book);
            history.History.Pop();

        }

    }
}
