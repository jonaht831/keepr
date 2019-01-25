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
  public class VaultKeepsController : ControllerBase
  {

    private readonly VaultKeepsRepository _vaultkeepsRepo;
    public VaultKeepsController(VaultKeepsRepository repo)
    {
      _vaultkeepsRepo = repo;
    }

    // GET api/values
    [HttpGet]
    // public ActionResult<IEnumerable<VaultKeep>> Get()
    // {
    //   return Ok(_vaultkeepsRepo.GetAll());
    // }

    // GET api/values/5
    [Authorize]
    [HttpGet("{id}")]
    public ActionResult<IEnumerable<Keep>> Get(int id)
    {

      var result = _vaultkeepsRepo.GetVaultKeeps(id, HttpContext.User.Identity.Name);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    // POST api/values
    [HttpPost]
    [Authorize]
    public ActionResult<string> Post([FromBody] VaultKeep newvaultkeep)
    {
      newvaultkeep.UserId = HttpContext.User.Identity.Name;
      bool result = _vaultkeepsRepo.AddVaultKeep(newvaultkeep);
      if (result)
      {
        return Ok("successfully added!");
      }
      return BadRequest("already in vault or error");
    }

    // PUT api/values/5
    [Authorize]
    [HttpPut]
    public ActionResult<VaultKeep> Put([FromBody] VaultKeep value)
    {
      value.UserId = HttpContext.User.Identity.Name;
      int result = _vaultkeepsRepo.EditVaultKeep(value);
      if (result == 1)
      {
        return Ok(result);
      }
      return NotFound();
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
      if (_vaultkeepsRepo.DeleteVaultKeep(id))
      {
        return Ok("Successfully Removed Keep!");
      }
      return NotFound();
    }
  }
}