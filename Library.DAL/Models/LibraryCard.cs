using System;

namespace Library.DAL.Models
{
    public class LibraryCard
    {
        public int Id { get; set; }

        public int ReaderId { get; set; }

        public int BookId { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public int Quantity { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public DateTime GivenDate { get; set; }

        public DateTime ScheduleReturnDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}