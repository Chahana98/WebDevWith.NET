using Microsoft.AspNetCore.Mvc;

namespace CollegeAPI.Controllers
{
    [ApiController]
    [Route("sessions")]
    public class SessionController : ControllerBase
    {
        private readonly CollegeDbContext _context;
        public SessionController(CollegeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Session>> Get()
        {
            return _context.Sessions.ToList();
        }
        [HttpPost]
        public async Task<ActionResult<Session>> Post(Session session)
        {
            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = session.Id }, session);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Session session)
        {
            session.Id = id;
            _context.Sessions.Update(session);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var session = await _context.Sessions.FindAsync(id);
            if (session == null)
            {
                return NotFound("session not found");
            }
            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
            return NoContent();

        }


        //[HttpPost]
        //public string Post()
        //{
        //    return "Creating something on database.";
        //}

        //[HttpPut]
        //public string Put()
        //{
        //    return "Updating something on database.";
        //}

        //[HttpDelete]
        //public string Delete()
        //{
        //    return "Deleting something on database.";
        //}
    }
}