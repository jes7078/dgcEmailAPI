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

  public class EmailsController:ControllerBase
  {
    private readonly DatabaseContext database;
    public EmailsController(DatabaseContext context)
    {
      db=context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Emails>>> GetAllEmails()
    {
      return await db.Emails.ToListAsync();
    }

  }
}