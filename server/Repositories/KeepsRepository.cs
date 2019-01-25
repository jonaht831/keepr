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

    public IEnumerable<Keep> GetUserKeeps(string id)
    {
      return _db.Query<Keep>($"SELECT * FROM Keeps WHERE userId = @id", new { id });
    }

    public Keep GetById(int id)
    {
      return _db.QueryFirstOrDefault<Keep>($"SELECT * FROM Keeps WHERE id = @id", new { id });
    }

    public int EditKeep(Keep keep)
    {
      try
      {
        return _db.Execute($@"
        UPDATE Keeps SET
          name = @Name,
          description = @Description,
          img = @Img,
          views = @Views,
          shares = @Shares,
          keeps = @Keeps
          WHERE id = @Id;
        ", keep);
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex);
        return 0;
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