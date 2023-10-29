using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")] // /api/users
public class UsersController : ControllerBase
{
    private readonly DataContext _dbContext;
    public UsersController(DataContext dbContext)
    {
        _dbContext = dbContext;

    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await _dbContext.Users.ToListAsync();
        return users;
    }

    [HttpGet("{id:int}")] // /api/users/2
    public async Task<ActionResult<AppUser>> GetUserById([FromRoute] int id)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

}
