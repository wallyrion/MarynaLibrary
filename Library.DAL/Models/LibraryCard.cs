using System;

namespace Library.DAL.Models
{
    public class LibraryCard
    {
        public int Id { get; set; }

        public int ReaderId { get; set; }

        public int BookId { get; set; }

        public DateTime GivenDate { get; set; }

        public DateTime ScheduleReturnDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}