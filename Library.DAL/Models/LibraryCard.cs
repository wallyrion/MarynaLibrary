using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Library.DAL.Models
{
    public class LibraryCard : IEntity
    {
        [BsonId]
        public Guid Id { get; set; }

        public Guid ReaderId { get; set; }

        public Guid BookId { get; set; }

        public int BookQuantity { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public int Quantity { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public DateTime GivenDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}