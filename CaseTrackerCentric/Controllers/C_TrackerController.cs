using CaseTrackerCentric.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseTrackerCentric.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class C_TrackerController : ControllerBase
    {
        private readonly casetrackerContext casetrackerContext;

        public C_TrackerController(casetrackerContext casetrackerContext)
        {
            this.casetrackerContext = casetrackerContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<CTracker>>> Getcasetracker()
        {
            var data = await casetrackerContext.CTrackers.ToListAsync();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CTracker>> GetcasetrackerById(int id)
        {
            var c_trakers = await casetrackerContext.CTrackers.FindAsync(id);
            if (c_trakers == null)
            {
                return NotFound();
            }
            return c_trakers;
        }

        [HttpPost]
        public async Task<ActionResult<CTracker>> createcasetracker(CTracker cTracker)
        {
            await casetrackerContext.CTrackers.AddAsync(cTracker);
            await casetrackerContext.SaveChangesAsync();
            return Ok(cTracker);
        }
        //update data
        [HttpPut("{id}")]
        public async Task<ActionResult<CTracker>> updatecasetracker(int id,CTracker cTracker) 
        {
            if (id!= cTracker.Id)
            {
                return BadRequest();
            }
            casetrackerContext.Entry(cTracker).State = EntityState.Modified;
            await casetrackerContext.SaveChangesAsync();
            return Ok(cTracker);
        }
        //delete casetracker 
        [HttpDelete("{id}")]
        public async Task<ActionResult<CTracker>> Deletecasetracker(int id)
        {
            var std = await casetrackerContext.CTrackers.FindAsync(id);
            if (std==null)
            {
                return NotFound();
            }
            casetrackerContext.CTrackers.Remove(std);   
            await casetrackerContext.SaveChangesAsync();
            return Ok(std);
        }










    }
}
