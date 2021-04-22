using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TerrariumApi.DataAccess;
using TerrariumApi.Models;

namespace TerrariumApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly TerrariumDbContext _terrariumDbContext;

        public UserController(TerrariumDbContext terrariumDbContext)
        {
            _terrariumDbContext = terrariumDbContext;
        }

        [HttpGet]
        [Route("/api/user")]
        public async Task<ActionResult<User>> AuthenticateUser([FromQuery] string username, [FromQuery] string password)
        {
            try
            {
                var userToAuthenticate =
                    await _terrariumDbContext.UserSet.FirstOrDefaultAsync(u => u.Username.Equals(username));
                if (userToAuthenticate != null)
                {
                    if (userToAuthenticate.Password.Equals(password))
                        return Ok(userToAuthenticate);
                }
                return StatusCode(500, "wrong user data");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        [Route("/api/user")]
        public async Task<ActionResult<User>> CreateNewUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var userWithProperId = _terrariumDbContext.UserSet.Add(user).Entity;
                await _terrariumDbContext.SaveChangesAsync();
                return Created(userWithProperId.Id.ToString(), userWithProperId);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}