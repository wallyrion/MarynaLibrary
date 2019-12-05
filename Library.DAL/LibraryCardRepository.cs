using System.Collections.Generic;
using Library.DAL.Dapper;
using Library.DAL.Entities;

namespace Library.DAL
{
    public class LibraryCardRepository : ILibraryCardRepository
    {
        private readonly Context _context;

        public LibraryCardRepository(Context context)
        {
            _context = context;
        }

        public List<LibraryCard> GetAll()
        {
            return new List<LibraryCard>();
        }
    }
}