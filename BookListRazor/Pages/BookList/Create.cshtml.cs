using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        // Page Handler
        public void OnGet()
        {

        }

        // Page Handler
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}