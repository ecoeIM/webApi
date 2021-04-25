using System;
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
    public class TerrariumController : ControllerBase
    {
        private readonly TerrariumDbContext _terrariumDbContext;

        public TerrariumController(TerrariumDbContext terrariumDbContext)
        {
            _terrariumDbContext = terrariumDbContext;
        }

        
        [HttpGet]
        [Route("/api/terrarium/data")]
        public async Task<ActionResult<TerrariumData>> GetTerrariumData([FromQuery] int terrariumDataId)
        {
            try
            {
                return Ok(await _terrariumDbContext.TerrariumDataSet.FirstOrDefaultAsync(u => u.Id == terrariumDataId));
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("/api/terrarium")]
        public async Task<ActionResult<Terrarium>> PostTerrarium([FromBody] Terrarium terrarium)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var terrariumWithProperId = _terrariumDbContext.TerrariumSet.Add(terrarium).Entity;
                await _terrariumDbContext.SaveChangesAsync();
                return Created(terrariumWithProperId.TerrariumName, terrariumWithProperId);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("/api/terrarium/data")]
        public async Task<ActionResult<TerrariumData>> UpdateTerrariumData([FromBody] TerrariumData terrariumData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                bool tracking = _terrariumDbContext.ChangeTracker.Entries<TerrariumData>()
                    .Any(x => x.Entity.Id == terrariumData.Id);
                if (!tracking)
                {
                    _terrariumDbContext.TerrariumDataSet.Update(terrariumData);
                }
                var terrariumDataToUpdate =
                    _terrariumDbContext.TerrariumDataSet.FirstOrDefault(t => t.Id == terrariumData.Id);
                if (terrariumDataToUpdate == null)
                {
                    return StatusCode(500, "not found");
                }
                terrariumDataToUpdate.Temperature = terrariumData.Temperature;
                terrariumDataToUpdate.HumidityLevel = terrariumData.HumidityLevel; 
                terrariumDataToUpdate.CarbonDioxideLevel = terrariumData.CarbonDioxideLevel; 
                terrariumDataToUpdate.NaturalLightLevel = terrariumData.NaturalLightLevel; 
                terrariumDataToUpdate.IsArtificialLightOn = terrariumData.IsArtificialLightOn;
                terrariumDataToUpdate.IsVentOn = terrariumData.IsVentOn;
                
                await _terrariumDbContext.SaveChangesAsync();
                return terrariumDataToUpdate;
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPatch]
        [Route("/api/terrarium")]
        public async Task<ActionResult<Terrarium>> UpdateTerrarium ([FromBody] Terrarium terrarium)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var terrariumToUpdate =
                    _terrariumDbContext.TerrariumSet.FirstOrDefault(t => t.TerrariumId == terrarium.TerrariumId);
                if (terrariumToUpdate == null)
                {
                    return StatusCode(500, "not found");
                }
                terrariumToUpdate.AnimalName = terrarium.AnimalName;
                terrariumToUpdate.TerrariumName = terrarium.TerrariumName;
                await _terrariumDbContext.SaveChangesAsync();
                return Ok(terrariumToUpdate);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("/api/terrarium/light/state")]
        public async Task<ActionResult<bool>> UpdateLightStateOfTerrarium([FromQuery] bool lightState, [FromQuery] int terrariumDataId)
        {
            try
            {
                var terrariumDataToUpdate = await _terrariumDbContext.TerrariumDataSet.FirstOrDefaultAsync(td => td.Id == terrariumDataId);
                if (terrariumDataToUpdate == null)
                {
                    return StatusCode(500, "not found");
                }
                terrariumDataToUpdate.IsArtificialLightOn = lightState; 
                await _terrariumDbContext.SaveChangesAsync(); 
                return Ok(lightState);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        } 
        
        [HttpPatch]
        [Route("/api/terrarium/vent/state")]
        public async Task<ActionResult<bool>> UpdateVentStateOfTerrarium([FromQuery] bool ventState, [FromQuery] int terrariumDataId)
        {
            try
            {
                var terrariumDataToUpdate = await _terrariumDbContext.TerrariumDataSet.FirstOrDefaultAsync(td => td.Id == terrariumDataId);
                if (terrariumDataToUpdate == null)
                {
                    return StatusCode(500, "not found");
                }
                terrariumDataToUpdate.IsVentOn = ventState; 
                await _terrariumDbContext.SaveChangesAsync(); 
                return Ok(ventState);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
    
    
}