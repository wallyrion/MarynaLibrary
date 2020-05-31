using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Library.DAL.Models
{
    public class Reader : IEntity
    {
        [BsonId]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }
    }
}