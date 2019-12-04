using Library.DAL.Dapper;

namespace Library.DAL
{
    public class Repository : IRepository
    {
        private readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }
    }
}