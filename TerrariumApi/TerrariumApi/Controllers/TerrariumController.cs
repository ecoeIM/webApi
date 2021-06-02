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

        [HttpGet]
        [Route("/api/terrarium/temp/records")]
        public async Task<ActionResult<List<TemperatureRecord>>> GetTemperatureRecords([FromQuery] int terrariumDataId)
        {
            try
            {
                var records = await
                    _terrariumDbContext.TemperatureRecords.Where(record => record.TerrariumDataId == terrariumDataId).ToListAsync();
                return records;
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }        
        [HttpGet]
        [Route("/api/terrarium/hum/records")]
        public async Task<ActionResult<List<HumidityLevelRecord>>> GetHumidityLevelRecords([FromQuery] int terrariumDataId)
        {
            try
            {
                var records =await 
                    _terrariumDbContext.HumidityLevelRecords.Where(record => record.TerrariumDataId == terrariumDataId).ToListAsync();
                return records;
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }  
        [HttpGet]
        [Route("/api/terrarium/carbon/records")]
        public async Task<ActionResult<List<CarbonDioxideLevelRecord>>> GetCarbonDioxideLevelRecordRecords([FromQuery] int terrariumDataId)
        {
            try
            {
                var records =
                    await _terrariumDbContext.CarbonDioxideLevelRecords.Where(record => record.TerrariumDataId == terrariumDataId).ToListAsync();
                return records;
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet]
        [Route("/api/terrarium/light/records")]
        public async Task<ActionResult<List<NaturalLightLevelRecord>>> GetNaturalLightRecords([FromQuery] int terrariumDataId)
        {
            try
            {
                var records =
                    await _terrariumDbContext.NaturalLightLevelRecords.Where(record =>
                        record.TerrariumDataId == terrariumDataId).ToListAsync();
                return records;
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost]
        [Route("/api/terrarium/temp/records")]
        public async Task<ActionResult<List<TemperatureRecord>>> PostTemperatureRecords([FromBody] TemperatureRecord temperatureRecord)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _terrariumDbContext.TemperatureRecords.AddAsync(temperatureRecord);
                await _terrariumDbContext.SaveChangesAsync();
                return Created(result.Entity.DateTime.ToShortDateString(),result.Entity);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost]
        [Route("/api/terrarium/hum/records")]
        public async Task<ActionResult<List<HumidityLevelRecord>>> PostHumidityRecords([FromBody] HumidityLevelRecord humidityRecord)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _terrariumDbContext.HumidityLevelRecords.AddAsync(humidityRecord);
                await _terrariumDbContext.SaveChangesAsync();
                return Created(result.Entity.DateTime.ToShortDateString(),result.Entity);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpPost]
        [Route("/api/terrarium/carbon/records")]
        public async Task<ActionResult<List<CarbonDioxideLevelRecord>>> PostCarbonDioxideLevelRecords([FromBody] CarbonDioxideLevelRecord carbonDioxideLevelRecord)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var result = await _terrariumDbContext.CarbonDioxideLevelRecords.AddAsync(carbonDioxideLevelRecord);
                await _terrariumDbContext.SaveChangesAsync();
                return Created(result.Entity.DateTime.ToShortDateString(),result.Entity);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        } 
        [HttpPost]
        [Route("/api/terrarium/light/records")]
        public async Task<ActionResult<List<NaturalLightLevelRecord>>> PostCarbonDioxideLevelRecords([FromBody] NaturalLightLevelRecord naturalLightLevelRecord)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var result = await _terrariumDbContext.NaturalLightLevelRecords.AddAsync(naturalLightLevelRecord);
                await _terrariumDbContext.SaveChangesAsync();
                return Created(result.Entity.DateTime.ToShortDateString(),result.Entity);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("/api/terrarium/temperature/period/last")]
        public async Task<ActionResult<double>> GetLastTemperature()
        {
            try
            {
                var terrariumData = await _terrariumDbContext.TerrariumDataSet.FirstOrDefaultAsync(t => t.Id == 1);
                return terrariumData.Temperature;
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        } 
        [HttpGet]
        [Route("/api/terrarium/humidity/period/last")]
        public async Task<ActionResult<double>> GetLastHumidity()
        {
            try
            {
                var terrariumData = await _terrariumDbContext.TerrariumDataSet.FirstOrDefaultAsync(t => t.Id == 1);
                return terrariumData.HumidityLevel;
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }    
        
        [HttpGet]
        [Route("/api/terrarium/co2/period/last")]
        public async Task<ActionResult<double>> GetLastCo2()
        {
            try
            {
                var terrariumData = await _terrariumDbContext.TerrariumDataSet.FirstOrDefaultAsync(t => t.Id == 1);
                return terrariumData.CarbonDioxideLevel;
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet]
        [Route("/api/terrarium/light/period/last")]
        public async Task<ActionResult<double>> GetLastLight()
        {
            try
            {
                var terrariumData = await _terrariumDbContext.TerrariumDataSet.FirstOrDefaultAsync(t => t.Id == 1);
                return terrariumData.NaturalLightLevel;
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        } 
        [HttpGet]
        [Route("/api/terrarium/artLight/state")]
        public async Task<ActionResult<bool>> GetArtificialLightState()
        {
            try
            {
                var terrariumData = await _terrariumDbContext.TerrariumDataSet.FirstOrDefaultAsync(t => t.Id == 1);
                return terrariumData.IsArtificialLightOn;
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        } 
        [HttpGet]
        [Route("/api/terrarium/vent/state")]
        public async Task<ActionResult<bool>> GetVentState()
        {
            try
            {
                var terrariumData = await _terrariumDbContext.TerrariumDataSet.FirstOrDefaultAsync(t => t.Id == 1);
                return terrariumData.IsVentOn;
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        


    }
    
    
}