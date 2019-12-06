using System;
using System.Collections.Generic;
using Library.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class LibraryCardController : Controller
    {
        [HttpGet]
        public List<LibraryCard> GetAllRecords()
        {
            var list = new List<LibraryCard>
            {
                new LibraryCard
                {
                    FirstName = "FirstName", LastName = "LastName", Phone = "1231245",
                    Id = 1, Author = "author", GivenDate = DateTime.UtcNow, Title = "title",
                    
                },
                new LibraryCard
                {
                    FirstName = "FirstName", LastName = "LastName", Phone = "1231245",
                    Id = 1, Author = "author", GivenDate = DateTime.UtcNow, Title = "title",

                },
                new LibraryCard
                {
                    FirstName = "FirstName", LastName = "LastName", Phone = "1231245",
                    Id = 1, Author = "author", GivenDate = DateTime.UtcNow, Title = "title",

                },
                new LibraryCard
                {
                    FirstName = "FirstName", LastName = "LastName", Phone = "1231245",
                    Id = 1, Author = "author", GivenDate = DateTime.UtcNow, Title = "title",

                },




            };

            return list;
        }

        [HttpPost]
        public IActionResult CreateRecord(LibraryCard card)
        {
            return Ok();
        }

        [HttpDelete("remove/{id}")]
        public IActionResult Remove(int id)
        {
            return Ok();
        }
    }
}