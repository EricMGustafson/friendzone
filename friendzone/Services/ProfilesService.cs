using System;
using System.Collections.Generic;
using friendzone.Models;
using friendzone.Repositories;

namespace friendzone.Services
{
  public class ProfilesService
  {
    private readonly ProfilesRepository _repo;
    private readonly FollowsRepository _frepo;

    public ProfilesService(ProfilesRepository repo, FollowsRepository frepo)
    {
      _repo = repo;
      _frepo = frepo;
    }

    internal List<Profile> Get()
    {
      List<Profile> profiles = _repo.Get();
      return profiles;
    }

    internal Profile Get(string id, string userId)
    {
      Profile found = _repo.Get(id);
      if (found == null)
      {
        throw new Exception("Invalid Profile Id");
      }
      return found;
    }
  }
}