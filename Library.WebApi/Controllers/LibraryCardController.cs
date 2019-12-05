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
  

            };

            return list;
        }

        [HttpPost]
        public IActionResult CreateRecord()
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