using System;
using System.Collections.Generic;
using Library.BL.Interfaces;
using Library.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
{
    [Route("api/[controller]/[action]")]
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
            var list = _libraryService.GetAll();

            return list;
        }

        [HttpPost]
        public IActionResult CreateRecord([FromBody] LibraryCard card)
        {
            var newId = _libraryService.Create(card);
            return Ok(newId);
        }

        [HttpPut("{id}")]
        public IActionResult Return(Guid id)
        {
            _libraryService.ReturnBook(id);
            return Ok();
        }
    }
}