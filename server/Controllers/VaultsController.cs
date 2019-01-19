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
  public class VaultsController : ControllerBase
  {

    private readonly VaultsRepository _vaultRepo;
    public VaultsController(VaultsRepository repo)
    {
      _vaultRepo = repo;
    }

    // GET api/values
    [HttpGet]
    public ActionResult<IEnumerable<Vault>> Get()
    {
      return Ok(_vaultRepo.GetAll());
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      Vault result = _vaultRepo.GetById(id);
      if (result != null)
      {
        return Ok(result);
      }
      return BadRequest();
    }

    // POST api/values
    [HttpPost]
    [Authorize]
    public ActionResult<Vault> Post([FromBody] Vault newvault)
    {
      var id = HttpContext.User.Identity.Name;
      newvault.UserId = id;
      return Ok(_vaultRepo.AddVault(newvault));
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public ActionResult<Vault> Put(int id, [FromBody] Vault value)
    {
      Vault result = _vaultRepo.EditVault(id, value);
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
      if (_vaultRepo.DeleteVault(id))
      {
        return Ok("Successfully Deleted Vault");
      }
      return NotFound();
    }
  }
}