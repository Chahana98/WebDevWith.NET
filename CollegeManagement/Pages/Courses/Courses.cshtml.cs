
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CollegeManagement.Pages;

public class CoursesModel : PageModel
{
    public List<Course> Courses {get; set;}
    public async Task OnGet()
    {
        // CollegeDbContext db= new();
        // Courses = db.Courses.ToList();

        // HTTP call
        HttpClient http = new HttpClient();
        Courses = await http.GetFromJsonAsync<List<Course>>("http://localhost:5261/courses");
    }
}
