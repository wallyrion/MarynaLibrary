using System.Collections.Generic;
using Library.DAL.Dapper;
using Library.DAL.Entities;

namespace Library.DAL
{
    public class JournalRepository : IJournalRepository
    {
        private readonly Context _context;

        public JournalRepository(Context context)
        {
            _context = context;
        }

        public List<JournalEntity> GetAll()
        {
            return new List<JournalEntity>();
        }
    }
}