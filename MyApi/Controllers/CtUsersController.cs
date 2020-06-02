using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApi.Models;

namespace MyApi.Controllers
{
    [EnableCors("CorsApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class CtUsersController : ControllerBase
    {
        private readonly CRUDAPPContext _context;

        public CtUsersController(CRUDAPPContext context)
        {
            _context = context;
        }

        // GET: api/CtUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CtUsers>>> GetCtUsers()
        {
            return await _context.CtUsers.ToListAsync();
        }

        // GET: api/CtUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CtUsers>> GetCtUsers(int id)
        {
            var ctUsers = await _context.CtUsers.FindAsync(id);

            if (ctUsers == null)
            {
                return NotFound();
            }

            return ctUsers;
        }

        // PUT: api/CtUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCtUsers(int id, CtUsers ctUsers)
        {
            if (id != ctUsers.Id)
            {
                return BadRequest();
            }

            _context.Entry(ctUsers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CtUsersExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CtUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CtUsers>> PostCtUsers(CtUsers ctUsers)
        {
            _context.CtUsers.Add(ctUsers);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCtUsers", new { id = ctUsers.Id }, ctUsers);
        }

        // DELETE: api/CtUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CtUsers>> DeleteCtUsers(int id)
        {
            var ctUsers = await _context.CtUsers.FindAsync(id);
            if (ctUsers == null)
            {
                return NotFound();
            }

            _context.CtUsers.Remove(ctUsers);
            await _context.SaveChangesAsync();

            return ctUsers;
        }

        private bool CtUsersExists(int id)
        {
            return _context.CtUsers.Any(e => e.Id == id);
        }



        private bool GenerateExcelReport(int scheduleId)
        {
            return _context.CtUsers.Any(e => e.Id == scheduleId);
        }





        //https://localhost:5001/api/ctusers/GetUsersWF/2
        [Route("[action]/{id}")]
        [HttpGet]
        public async Task<ActionResult<CtUsers>> GetUsersWF(int id)
        {
            var ctUsers = await _context.CtUsers.FindAsync(id);

            if (ctUsers == null)
            {
                return NotFound();
            }

            return ctUsers;
        }


    }
}
