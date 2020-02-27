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
  }
}