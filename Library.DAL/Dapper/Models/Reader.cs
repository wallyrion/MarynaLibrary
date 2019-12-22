using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Library.DAL.Dapper.Models
{
    public class Reader
    {
        [BsonId]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }
    }
}