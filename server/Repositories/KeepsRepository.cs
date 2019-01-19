using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Controllers
{
  public class KeepsRepository
  {

    private readonly IDbConnection _db;
    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM Keeps");
    }

    public Keep GetById(int id)
    {
      return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM Keeps WHERE id = @id", new { id });
    }

    public Keep EditKeep(int id, Keep newkeep)
    {
      try
      {
        newkeep.Id = id;
        return _db.QueryFirstOrDefault<Keep>($@"
        UPDATE Keeps SET
          Name = @Name,
          Size = @Size
        WHERE Id = @Id;
        SELECT * FROM Keeps WHERE id = @Id;
        ", newkeep);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return null;
      }
    }
    public Keep AddKeep(Keep newkeep)
    {
      int id = _db.ExecuteScalar<int>(@"
        INSERT INTO Keeps (Name, Description, UserId, Img, IsPrivate, Views, Shares, Keeps) 
        Values (@Name, @Description, @UserId, @Img, @IsPrivate, @Views, @Shares, @Keeps); 
 	      SELECT LAST_INSERT_ID()", newkeep
      );
      newkeep.Id = id;
      return newkeep;
    }

    public bool DeleteKeep(int id)
    {
      int success = _db.Execute("DELETE FROM Keeps WHERE id = @id;", new { id });
      return success != 0;
    }
  }
}