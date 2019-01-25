using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Controllers
{
  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;
    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    // public IEnumerable<VaultKeep> GetAll()
    // {
    //   return _db.Query<VaultKeep>("SELECT * FROM VaultKeeps");
    // }

    public IEnumerable<Keep> GetVaultKeeps(int vaultId, string userId)
    {
      return _db.Query<Keep>($@"
      SELECT * FROM vaultkeeps vk
      INNER JOIN keeps k ON k.id = vk.keepId
      WHERE(vk.vaultId = @vaultId AND vk.userID = @userId)", new { vaultId, userId });
    }

    public int EditVaultKeep(VaultKeep vk)
    {
      try
      {
        return _db.Execute($@"
        DELETE FROM vaultkeeps WHERE 
        keepId = @KeepId AND 
        vaultId = @vaultId", vk);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return 0;
      }
    }
    public bool AddVaultKeep(VaultKeep newvaultkeep)
    {
      VaultKeep vk = _db.QueryFirstOrDefault<VaultKeep>(@"
      SELECT * FROM vaultkeeps
      WHERE vaultId = @VaultId AND keepId = @KeepId;", newvaultkeep);
      if (vk == null)
      {
        int success = _db.Execute(@"
      INSERT INTO vaultkeeps (VaultId, KeepId, UserId)
      Values (@VaultId, @KeepId, @UserId)", newvaultkeep);
        return success != 0;
      }
      return false;
    }

    public bool DeleteVaultKeep(int id)
    {
      int success = _db.Execute("DELETE FROM VaultKeeps WHERE id = @id;", new { id });
      return success != 0;
    }
  }
}