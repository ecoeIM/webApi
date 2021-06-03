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
    public class TaskController : ControllerBase
    {
        private readonly TerrariumDbContext _terrariumDbContext;

        public TaskController(TerrariumDbContext terrariumDbContext)
        {
            _terrariumDbContext = terrariumDbContext;
        }

        [HttpPost]
        [Route("/api/terrarium/tasks")]
        public async Task<ActionResult<ScheduledTask>> PostScheduledTask([FromBody] ScheduledTask scheduledTask)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var scheduledTaskWithProperId = await _terrariumDbContext.ScheduledTasksSet.AddAsync(scheduledTask);
                await _terrariumDbContext.SaveChangesAsync();
                return Created(scheduledTaskWithProperId.Entity.Id.ToString(),
                    scheduledTaskWithProperId.Entity);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }   
        
        [HttpGet]
        [Route("/api/terrarium/tasks")]
        public async Task<ActionResult<List<ScheduledTask>>> GetScheduledTasks([FromQuery] int terrariumId)
        {
            try
            {
                var tasks = await _terrariumDbContext.ScheduledTasksSet.Where(t => t.TerrariumId == terrariumId)
                    .ToListAsync();
                return Ok(tasks);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPatch]
        [Route("/api/terrarium/tasks")]
        public async Task<ActionResult<ScheduledTask>> GetScheduledTasks([FromBody] ScheduledTask scheduledTask)
        {
            try
            {
                var taskToUpdate =
                    await _terrariumDbContext.ScheduledTasksSet.FirstOrDefaultAsync(t => t.Id == scheduledTask.Id);
                
                if (taskToUpdate != null)
                {
                    taskToUpdate.Name = scheduledTask.Name;
                    taskToUpdate.ToggleLight = scheduledTask.ToggleLight;
                    taskToUpdate.ToggleVent = scheduledTask.ToggleVent;
                    taskToUpdate.DateTime = scheduledTask.DateTime;
                    await _terrariumDbContext.SaveChangesAsync();
                    return Ok(taskToUpdate);
                    
                }
                return StatusCode(500, "not found");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete]
        [Route("/api/terrarium/tasks")]
        public async Task<ActionResult> DeleteScheduledTasks([FromQuery] int id)
        {
            try
            {
                var entityToRemove = await _terrariumDbContext.ScheduledTasksSet.FirstOrDefaultAsync(t => t.Id == id);
                if (entityToRemove == null)
                {
                    return StatusCode(500, "not found");
                }
                _terrariumDbContext.ScheduledTasksSet.Remove(entityToRemove);
                await _terrariumDbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}