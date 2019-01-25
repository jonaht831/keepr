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

    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Keep>> GetUserKeeps(string id)
    {
      return Ok(_keepRepo.GetUserKeeps(id));
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
    [HttpPut]
    public ActionResult<string> Put([FromBody] Keep value)
    {
      int result = _keepRepo.EditKeep(value);
      if (result == 1)
      {
        return Ok("Keep");
      }
      return BadRequest("FAIL");
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