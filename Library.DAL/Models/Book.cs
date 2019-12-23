using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Library.DAL.Models
{
    public class Book : IEntity
    {
        public string Author { get; set; }

        public string Title { get; set; }

        public int Quantity { get; set; }

        public int AvailableCount { get; set; }

        [BsonId]
        public Guid Id { get; set; }
    }
}