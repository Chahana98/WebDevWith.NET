using Microsoft.AspNetCore.Mvc;

namespace CollegeAPI.Controllers
{
        [ApiController]
        [Route("Courses")]
        public class CourseController : ControllerBase
        {
            private readonly CollegeDbContext _context;
            public CourseController(CollegeDbContext context)
            {
                _context = context;
            }

         [HttpGet]
         public ActionResult<IEnumerable<Course>> Get()
         {
            return _context.Courses.ToList();
         }
         [HttpPost]
         public async Task<ActionResult<Course>> Post(Course course)
         {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = course.Id }, course);
         }

         [HttpPut("{id}")]
         public async Task<IActionResult> Put(int id, Course course)
         {
            course.Id = id;
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return NoContent();
         }

        
         [HttpDelete("{id}")]
         public async Task<IActionResult> Delete(int id)
         {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound("Course not found");
            }
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return NoContent();

         }

        
        }
}
