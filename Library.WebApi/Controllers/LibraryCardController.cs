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
            var list = _libraryService.GetAll();

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
            _libraryService.ReturnBook(id);
            return Ok();
        }
    }
}