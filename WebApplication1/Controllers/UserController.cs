using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.DbContexts;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly SchoolContext _context;

        public UsersController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(_context.Users);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int id)
        {
            
            if(!_context.Users.Any(data=>data.Id==id))
                return NotFound("User Detail not found for "+id);


            return Ok(_context.Users.Where(data=>data.Id==id));
        }

        [HttpPost]
        public IActionResult PostStudent(Users user)
        {
            var data=_context.Users.Add(user);
            _context.SaveChangesAsync();

            return Ok(_context.Users.Where(data => data.Id == user.Id));
        }

        [HttpPut("{id}")]
        public IActionResult PutStudent(int id, Users user)
        {
            if (!_context.Users.Any(data => data.Id == id))
                return BadRequest("User Details not found for " + id);

            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();

            return Ok(_context.Users.Where(data => data.Id == user.Id));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var user = _context.Users.Find(id);
            if(user == null)
                BadRequest("User Detail not found for " + id);

            _context.Users.Remove(user);
            _context.SaveChanges();

            return NoContent();
        }
    }

}
