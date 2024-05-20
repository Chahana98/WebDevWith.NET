using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CollegeManagement.Pages_Sessions
{
    public class CreateModel : PageModel
    {
        private readonly CollegeDbContext _context;

        public CreateModel(CollegeDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            Courses= _context.Courses
            .Select(x => new SelectListItem { Text=x.Name, Value=x.Id.ToString() })
            .ToList();
            return Page();
        }

        [BindProperty]
        public Session Session { get; set; } = default!;

        public List<SelectListItem> Courses {get; set;}

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Sessions.Add(Session);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
