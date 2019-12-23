using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Library.DAL.Interfaces;
using Library.DAL.Models;
using MongoDB.Driver;

namespace Library.DAL.Mongo.Repositories
{
    public class ReaderRepository : BaseMongoRepository<Reader>, IReaderRepository
    {
        public ReaderRepository(Context context) : base(context)
        {
        }


        public List<Reader> Search(string value)
        {
            throw new System.NotImplementedException();
        }
    }
}