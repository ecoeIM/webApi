using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TerrariumApi.DataAccess;
using TerrariumApi.Models;

namespace TerrariumApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly TerrariumDbContext _terrariumDbContext;

        public ProfileController(TerrariumDbContext terrariumDbContext)
        {
            _terrariumDbContext = terrariumDbContext;
        }
        
        [HttpPost]
        [Route("/api/terrarium/profiles")]
        public async Task<ActionResult<Profile>> PostProfile([FromBody] Profile profile)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var profileWithProperId = await _terrariumDbContext.ProfileSet.AddAsync(profile);
                await _terrariumDbContext.SaveChangesAsync();
                return Created(profile.ProfileName,profileWithProperId.Entity);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }  
        
        [HttpGet]
        [Route("/api/terrarium/profiles")]
        public async Task<ActionResult<List<Profile>>> GetProfiles([FromQuery] int terrariumId)
        {
            try
            {
                var profiles = await _terrariumDbContext.ProfileSet.Where(profile => profile.TerrariumId == terrariumId).ToListAsync();
                return profiles;
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("/api/terrarium/profiles")]
        public async Task<ActionResult> UpdateProfile([FromBody] Profile profile)
        {
            try
            {
                var profileToUpdate = await _terrariumDbContext.ProfileSet.FirstOrDefaultAsync(p => p.Id == profile.Id);


                if (profileToUpdate != null)
                {
                    profileToUpdate.MaxCo2 = profile.MaxCo2;
                    profileToUpdate.MaxHumid = profile.MaxCo2;
                    profileToUpdate.MaxLight = profile.MaxCo2;
                    profileToUpdate.MaxLight = profile.MaxCo2;
                    profileToUpdate.MaxTemp = profile.MaxCo2;
                    profileToUpdate.MinCo2 = profile.MaxCo2;
                    profileToUpdate.MinHumid = profile.MaxCo2;
                    profileToUpdate.MinLight = profile.MaxCo2;
                    profileToUpdate.MinTemp = profile.MaxCo2;
                    profileToUpdate.ProfileName = profile.ProfileName;

                    await _terrariumDbContext.SaveChangesAsync();
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        

        [HttpDelete]
        [Route("/api/terrarium/profiles")]
        public async Task<ActionResult> DeleteProfile([FromQuery] int id)
        {
            try
            {
                var profileToRemove = await _terrariumDbContext.ProfileSet.FirstOrDefaultAsync(p => p.Id == id);
                _terrariumDbContext.ProfileSet.Remove(profileToRemove);
                await _terrariumDbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("/api/terrarium/profiles/active")]
        public async Task<ActionResult<Profile>> GetActiveProfile([FromQuery] int terrariumId)
        {
            try
            {
                var terrarium = await _terrariumDbContext.TerrariumSet.FirstOrDefaultAsync(t => t.TerrariumId == terrariumId);
                if (terrarium != null)
                {
                    var profile =
                        await _terrariumDbContext.ProfileSet.FirstOrDefaultAsync(p => p.Id == terrarium.ActiveProfileId);
                    return Ok(profile);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("/api/terrarium/profiles/active")]
        public async Task<ActionResult> SetActiveProfile([FromQuery] int terrariumId,[FromQuery] int profileId)
        {
            try
            {
                var terrarium = await _terrariumDbContext.TerrariumSet.FirstOrDefaultAsync(t => t.TerrariumId == terrariumId);
                if (terrarium != null)
                {
                    terrarium.ActiveProfileId = profileId;
                    await _terrariumDbContext.SaveChangesAsync();
                    return Ok();
                }
                return BadRequest();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}