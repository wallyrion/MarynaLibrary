using System.Collections.Generic;
using Library.BL.Interfaces;
using Library.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public List<Book> GetAll()
        {
            return _bookService.GetAll();
        }

        [HttpGet("{searchField}")]
        public List<Book> Search(string searchField)
        {
            return new List<Book>
            {
                new Book {Author = "alexey", Title = "ewtwt"},
                new Book {Author = "alexey", Title = "ewtwt"},
                new Book {Author = "alexey", Title = "ewtwt"}
            };
        }

        [HttpPost]
        public IActionResult Create([FromBody] Book book)
        {
            var id = _bookService.Create(book);

            return Ok(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Book book)
        {
            _bookService.Edit(book);

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            _bookService.Remove(id);

            return Ok();
        }
    }
}