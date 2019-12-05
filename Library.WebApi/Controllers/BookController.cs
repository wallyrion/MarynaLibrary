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

        [HttpPost("Create")]
        public IActionResult Create([FromBody] Book book)
        {
            var id = _bookService.Create(book);

            return Ok(id);
        }

        [HttpDelete("remove/{id}")]
        public IActionResult Remove(int id)
        {
            _bookService.Remove();

            return Ok();
        }
    }
}