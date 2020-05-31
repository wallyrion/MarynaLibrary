using System;
using System.Collections.Generic;

namespace Library.BL.Models
{
    public class LibraryCard
    {
        public Guid Id { get; set; }

        public Guid ReaderId { get; set; }

        public Guid BookId { get; set; }

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