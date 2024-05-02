using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.Pages_Sessions
{
    public class IndexModel : PageModel
    {
        private readonly CollegeDbContext _context;

        public IndexModel(CollegeDbContext context)
        {
            _context = context;
        }

        public IList<Session> Session { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Session = await _context.Sessions.ToListAsync();
        }
    }
}
