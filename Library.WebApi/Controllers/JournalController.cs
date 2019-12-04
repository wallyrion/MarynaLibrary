using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.DAL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class JournalController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var list = new List<Journal>
            {
                new Journal
                {
                    Date = DateTime.UtcNow, FirstName = "Oleksii", LastName = "Korniienko"
                },
                new Journal
                {
                    Date = DateTime.UtcNow, FirstName = "Muryna", LastName = "Kudriavtseva"
                },
                new Journal
                {
                    Date = DateTime.UtcNow, FirstName = "Oleksii", LastName = "Korniienko"
                },
                new Journal
                {
                    Date = DateTime.UtcNow, FirstName = "Muryna", LastName = "Kudriavtseva"
                }
            };

            return Ok(list);
        }
    }
}