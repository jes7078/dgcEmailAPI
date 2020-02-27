using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dgcEmailAPI.Models;

namespace dgcEmailAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  public class EmailsController:ControllerBase
  {
    private readonly DatabaseContext db;
    public EmailsController(DatabaseContext context)
    {
      db=context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Emails>>> GetAllEmails()
    {
      return await db.Emails.ToListAsync();
    }
[HttpPost]
public async Task<ActionResult<Emails>> PostEmails(Emails emails)
{
  db.Emails.Add(emails);
  await db.SaveChangesAsync();
  return Ok(emails);
}

[HttpDelete("{id}")]
public async Task<ActionResult<Emails>> DeleteEmails(int id)
{
  var email = await db.Emails.FindAsync(id);
  if(email==null)
  {
    return NotFound();
  }
  db.Emails.Remove(email);
  await db.SaveChangesAsync();
  return email;
}
private bool EmailsExists(int id)
{
  return db.Emails.Any(e=>e.Id==id);
}
  }
}