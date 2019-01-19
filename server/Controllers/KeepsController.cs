using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {

    private readonly KeepsRepository _keepRepo;
    public KeepsController(KeepsRepository repo)
    {
      _keepRepo = repo;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Keep>> Get()
    {
      return Ok(_keepRepo.GetAll());
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Keep> Get(int id)
    {
      Keep result = _keepRepo.GetById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    // POST api/values
    [HttpPost]
    [Authorize]
    public ActionResult<Keep> Post([FromBody] Keep newkeep)
    {
      var id = HttpContext.User.Identity.Name;
      newkeep.UserId = id;
      return Ok(_keepRepo.AddKeep(newkeep));
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<Keep> Put(int id, [FromBody] Keep value)
    {
      Keep result = _keepRepo.EditKeep(id, value);
      if (result != null)
      {
        return Ok(result);
      }
      return NotFound();
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
      if (_keepRepo.DeleteKeep(id))
      {
        return Ok("Successfully Deleted Keep");
      }
      return NotFound();
    }
  }
}