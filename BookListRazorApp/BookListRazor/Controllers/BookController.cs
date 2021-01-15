using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext db;

        public BookController(ApplicationDbContext db)
        {
            this.db = db;
        }
        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = db.Book.ToList() }) ;
        }
    }
}
