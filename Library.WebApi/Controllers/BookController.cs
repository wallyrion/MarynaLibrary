using System.Collections.Generic;
using Library.BL.Interfaces;
using Library.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("GetAll")]
        public List<Book> GetAll()
        {
            return _bookService.GetAll();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            _bookService.Create(book);

            return Ok();
        }

        [HttpDelete("Remove/{id}")]
        public IActionResult Remove(int id)
        {
            _bookService.Remove();

            return Ok();
        }
    }
}