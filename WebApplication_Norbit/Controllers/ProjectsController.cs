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
    public class ProjectsController : ControllerBase
    {
        ProjectContext projects_db;
        public ProjectsController(ProjectContext projectsContext)
        {
            
            projects_db = projectsContext;
      
            if (!projects_db.Projects.Any())
            {
                //projects_db.Projects.Add(new Project { name = "Project 1", p_code = 1, active = true});
                //projects_db.Projects.Add(new Project { name = "Project 2", p_code = 2, active = true });
                //projects_db.Projects.Add(new Project { name = "Project 3", p_code = 3, active = true });
                projects_db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> Get()
        {
            return await projects_db.Projects.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> Get(int id)
        {
            Project project = await projects_db.Projects.FirstOrDefaultAsync(x => x.id == id);
            if (project == null)
                return NotFound();
            return new ObjectResult(project);
        }

        [HttpPost]
        public async Task<ActionResult<Project>> Post(Project project)
        {
            Console.WriteLine(project);
            if (project == null)
            {
                return BadRequest();
            }

            projects_db.Projects.Add(project);
            await projects_db.SaveChangesAsync();
            return Ok(project);
        }

        [HttpPut]
        public async Task<ActionResult<Project>> Put(Project project)
        {
            if (project == null)
            {
                return BadRequest();
            }
            if (!projects_db.Projects.Any(x => x.id == project.id))
            {
                return NotFound();
            }

            projects_db.Update(project);
            await projects_db.SaveChangesAsync();
            return Ok(project);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> Delete(int id)
        {
            Project project = projects_db.Projects.FirstOrDefault(x => x.id == id);
            if (project == null)
            {
                return NotFound();
            }
            projects_db.Projects.Remove(project);
            await projects_db.SaveChangesAsync();
            return Ok(project);
        }
    }
}
