using System.Collections.Generic;
using Library.BL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ReaderController : Controller
    {
        [HttpGet]
        public List<Reader> GetAll()
        {
            var list = new List<Reader>();
            return list;
        }

        [HttpPost]
        public IActionResult CreateRecord()
        {
            return Ok();
        }

        [HttpDelete("Remove/{id}")]
        public IActionResult Remove(int id)
        {
            return Ok();
        }
    }
}