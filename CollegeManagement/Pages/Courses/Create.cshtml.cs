
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CollegeManagement.Pages;

public class CreateCourseModel : PageModel
{
    [BindProperty]

    public Course Course {get; set;}
    public IActionResult OnPost()
    {
        CollegeDbContext db= new();
        db.Courses.Add(Course);
        db.SaveChanges();
        return RedirectToPage("Courses");
    }
}
