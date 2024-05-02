
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CollegeManagement.Pages;

public class DeleteCourseModel : PageModel
{
    [BindProperty]

    public Course Course {get; set;}

    public void OnGet( int id)
    {
         CollegeDbContext db= new();
         Course = db.Courses.Find(id);

    }
    public IActionResult OnPost()
    {
        CollegeDbContext db= new();
        db.Courses.Remove(Course);
        db.SaveChanges();
        return RedirectToPage("Courses");
    }
}
