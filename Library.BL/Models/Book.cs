﻿using System;

namespace Library.BL.Models
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public int Quantity { get; set; }

        public int AvailableCount { get; set; }
    }
}