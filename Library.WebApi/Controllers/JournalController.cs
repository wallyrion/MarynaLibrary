
using System.Collections.Generic;
using Library.BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class JournalController : Controller
    {
        [HttpGet]
        public List<Journal> GetAllRecords()
        {
            var list = new List<Journal>
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