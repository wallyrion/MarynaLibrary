using System.Collections.Generic;
using Library.DAL.Dapper.Models;

namespace Library.DAL.Interfaces
{
    public interface IReaderRepository : IRepository<Reader>
    {
        List<Reader> Search(string value);
    }
}