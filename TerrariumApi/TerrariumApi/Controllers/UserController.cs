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
        
        [HttpPost]
        [Route("/api/terrarium/setUser")]
        public async Task<ActionResult<User>> CreateNewUser([FromBody] String UId)
        {
            try
            {
                var newUser = new User();
                newUser.UId = UId;
                var userWithProperId = _terrariumDbContext.UserSet.Add(newUser).Entity;
                await _terrariumDbContext.SaveChangesAsync();
                return Created(userWithProperId.UId, userWithProperId);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}