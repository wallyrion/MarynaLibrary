using System;
using System.Collections.Generic;
using Library.BL.Interfaces;
using Library.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class LibraryCardController : Controller
    {
        private readonly ILibraryService _libraryService;

        public LibraryCardController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

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
            var newId = _libraryService.Create(card);
            return Ok(newId);
        }

        [HttpDelete]
        public IActionResult Return(int id)
        {
            _libraryService.ReturnCard(id);
            return Ok();
        }
    }
}