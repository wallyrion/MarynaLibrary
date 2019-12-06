using System.Collections.Generic;
using Library.BL.Interfaces;
using Library.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ReaderController : Controller
    {
        private readonly IReaderService _readerService;

        public ReaderController(IReaderService readerService)
        {
            _readerService = readerService;
        }

        [HttpGet]
        public List<Reader> GetAll()
        {
            return new List<Reader>
            {
                new Reader{FirstName = "rewr", LastName = "rewrw", Phone = "4235"},
                new Reader{FirstName = "rewr", LastName = "rewrw", Phone = "4235"},new Reader{FirstName = "rewr", LastName = "rewrw", Phone = "4235"}
                
            };
            var readers = _readerService.GetAll();

            return readers;
        }

        [HttpPost]
        public IActionResult Create([FromBody]Reader reader)
        {
            var id = _readerService.Create(reader);

            return Ok(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody]Reader reader)
        {
            _readerService.Edit(reader);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            _readerService.Remove(id);

            return Ok();
        }

        [HttpGet]
        public List<Reader> Search([FromQuery] string value)
        {
            return new List<Reader>
            {
                new Reader{FirstName = "rewr", LastName = "rewrw", Phone = "4235"},
                new Reader{FirstName = "rewr", LastName = "rewrw", Phone = "4235"},new Reader{FirstName = "rewr", LastName = "rewrw", Phone = "4235"}

            };
            var result = _readerService.Search(value);

            return result;
        }
    }
}