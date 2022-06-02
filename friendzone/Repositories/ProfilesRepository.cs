using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using friendzone.Models;

namespace friendzone.Repositories
{
  public class ProfilesRepository
  {
    private readonly IDbConnection _db;

    public ProfilesRepository(IDbConnection db)
    {
      _db = db;
    }

    internal List<Profile> Get()
    {
      string sql = "SELECT * FROM profiles";
      return _db.Query<Profile>(sql).ToList();
    }

    internal Profile Get(string id)
    {
      string sql = "SELECT * FROM profiles WHERE id = @id";
      return _db.ExecuteScalar<int>(sql, )
    }
  }
}