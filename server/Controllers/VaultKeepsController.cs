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
    public ActionResult<IEnumerable<VaultKeep>> Get()
    {
      return Ok(_vaultkeepsRepo.GetAll());
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<VaultKeep> Get(int id)
    {
      VaultKeep result = _vaultkeepsRepo.GetById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    // POST api/values
    [HttpPost]
    [Authorize]
    public ActionResult<VaultKeep> Post([FromBody] VaultKeep newvaultkeep)
    {
      newvaultkeep.UserId = HttpContext.User.Identity.Name;
      return Ok(_vaultkeepsRepo.AddVaultKeep(newvaultkeep));
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<VaultKeep> Put(int id, [FromBody] VaultKeep value)
    {
      VaultKeep result = _vaultkeepsRepo.EditVaultKeep(id, value);
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
      if (_vaultkeepsRepo.DeleteVaultKeep(id))
      {
        return Ok("Successfully Deleted VaultKeep");
      }
      return NotFound();
    }
  }
}