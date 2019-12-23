using System;
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
        public IActionResult Remove(Guid id)
        {
            _bookService.Remove(id);

            return Ok();
        }


        [HttpGet]
        public List<Book> Search([FromQuery] string value)
        {
            var result = _bookService.Search(value);

            return result;
        }
    }
}