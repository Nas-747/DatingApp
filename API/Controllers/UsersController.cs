using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class UsersController : ControllerBase
    {
        //an underscore is used for a private field as a practice 
        private readonly DataContext _context;

        //ctor shortcut to create a constructor
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task <ActionResult<IEnumerable<AppUser>>> GetUsers(){
            var users = await _context.Users.ToListAsync();

            return users;
        }

        [HttpGet("{id}")]
        public async Task< ActionResult<AppUser>> GetUser(int id){
            return await _context.Users.FindAsync(id);
        }
    }
}