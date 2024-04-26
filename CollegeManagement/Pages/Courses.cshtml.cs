
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CollegeManagement.Pages;

public class CoursesModel : PageModel
{
    public List<Course> Courses {get; set;}
    public void OnGet()
    {
        CollegeDbContext db= new();
        Courses = db.Courses.ToList();
    }
}
