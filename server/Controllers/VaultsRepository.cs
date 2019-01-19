using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Controllers
{
  public class VaultsRepository
  {

    private readonly IDbConnection _db;
    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Vault> GetAll()
    {
      return _db.Query<Vault>("SELECT * FROM Vaults");
    }

    public Vault GetById(int id)
    {
      return _db.QueryFirstOrDefault<Vault>($"SELECT * FROM Vaults WHERE id = @id", new { id });
    }

    public Vault EditVault(int id, Vault newvault)
    {
      try
      {
        newvault.Id = id;
        return _db.QueryFirstOrDefault<Vault>($@"
        UPDATE Vaults SET
          Name = @Name,
        WHERE Id = @Id;
        SELECT * FROM Vaults WHERE id = @Id;
        ", newvault);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }
    public Vault AddVault(Vault newvault)
    {
      int id = _db.ExecuteScalar<int>(@"
        INSERT INTO Vaults (Name, Description, UserId) 
        Values (@Name, @Description, @UserId); 
 	      SELECT LAST_INSERT_ID()", newvault
      );
      newvault.Id = id;
      return newvault;
    }

    public bool DeleteVault(int id)
    {
      int success = _db.Execute("DELETE FROM Vaults WHERE id = @id;", new { id });
      return success != 0;
    }
  }
}