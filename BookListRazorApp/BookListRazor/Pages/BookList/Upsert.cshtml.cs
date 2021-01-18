using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private ApplicationDbContext db;

        public UpsertModel(ApplicationDbContext db)
        {
            this.db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new Book();

            if(id==null)
            {
                return Page();
            }

            Book = await db.Book.FirstOrDefaultAsync(u => u.Id == id);

            if(Book == null)
            {
                return NotFound();
            }

            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
         
                if(Book.Id == 0)
                {
                    db.Book.Add(Book);
                }
                else
                {
                    db.Book.Update(Book);
                }


                await db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();

        }
    }
}
