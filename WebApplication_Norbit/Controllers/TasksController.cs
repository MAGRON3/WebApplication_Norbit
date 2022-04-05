using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_Norbit.Models;

namespace WebApplication_Norbit.Controllers
{
    [Route("db/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        TaskContext task_db;
        public TasksController(TaskContext taskContext)
        {
            
            task_db = taskContext;
      
            if (!task_db.Tasks.Any())
            {
                //task_db.Tasks.Add(new Models.Task { name = "Task 1", project_code = 1 , active = true});
                //task_db.Tasks.Add(new Models.Task { name = "Task 2", project_code = 2, active = true });
                //task_db.Tasks.Add(new Models.Task { name = "Task 3", project_code = 3, active = true });
                task_db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Task>>> Get()
        {
            return await task_db.Tasks.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Task>> Get(int id)
        {
            Models.Task task = await task_db.Tasks.FirstOrDefaultAsync(x => x.id == id);
            if (task == null)
                return NotFound();
            return new ObjectResult(task);
        }

        [HttpPost]
        public async Task<ActionResult<Models.Task>> Post(Models.Task task)
        {
            if (task == null)
            {
                return BadRequest();
            }

            task_db.Tasks.Add(task);
            await task_db.SaveChangesAsync();
            return Ok(task);
        }

        [HttpPut]
        public async Task<ActionResult<Models.Task>> Put(Models.Task task)
        {
            if (task == null)
            {
                return BadRequest();
            }
            if (!task_db.Tasks.Any(x => x.id == task.id))
            {
                return NotFound();
            }

            task_db.Update(task);
            await task_db.SaveChangesAsync();
            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Models.Task>> Delete(int id)
        {
            Models.Task task = task_db.Tasks.FirstOrDefault(x => x.id == id);
            if (task == null)
            {
                return NotFound();
            }
            task_db.Tasks.Remove(task);
            await task_db.SaveChangesAsync();
            return Ok(task);
        }
    }
}
