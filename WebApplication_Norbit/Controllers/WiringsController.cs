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
    public class WiringsController : ControllerBase
    {
        WiringContext wirings_db;
        public WiringsController(WiringContext wiringsContext)
        {
            
            wirings_db = wiringsContext;
      
            if (!wirings_db.Wirings.Any())
            {
                //wirings_db.Wirings.Add(new Wiring { task_code = 1, name = "wiring 1", w_hours = 1 , w_date = "2022-01-01" });
                //wirings_db.Wirings.Add(new Wiring { task_code = 1, name = "wiring 2", w_hours = 2, w_date = "2022-01-01" });
                //wirings_db.Wirings.Add(new Wiring { task_code = 1, name = "wiring 3", w_hours = 3, w_date = "2022-01-01" });
                wirings_db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wiring>>> Get()
        {
            return await wirings_db.Wirings.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Wiring>> Get(int id)
        {
            Wiring wiring = await wirings_db.Wirings.FirstOrDefaultAsync(x => x.id == id);
            if (wiring == null)
                return NotFound();
            return new ObjectResult(wiring);
        }

        [HttpPost]
        public async Task<ActionResult<Wiring>> Post(Wiring wiring)
        {
            if (wiring == null)
            {
                return BadRequest();
            }

            wirings_db.Wirings.Add(wiring);
            await wirings_db.SaveChangesAsync();
            return Ok(wiring);
        }

        [HttpPut]
        public async Task<ActionResult<Wiring>> Put(Wiring wiring)
        {
            if (wiring == null)
            {
                return BadRequest();
            }
            if (!wirings_db.Wirings.Any(x => x.id == wiring.id))
            {
                return NotFound();
            }

            wirings_db.Update(wiring);
            await wirings_db.SaveChangesAsync();
            return Ok(wiring);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Wiring>> Delete(int id)
        {
            Wiring wiring = wirings_db.Wirings.FirstOrDefault(x => x.id == id);
            if (wiring == null)
            {
                return NotFound();
            }
            wirings_db.Wirings.Remove(wiring);
            await wirings_db.SaveChangesAsync();
            return Ok(wiring);
        }
    }
}
