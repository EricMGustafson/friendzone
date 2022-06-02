using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using friendzone.Models;
using friendzone.Services;
using Microsoft.AspNetCore.Mvc;

namespace friendzone.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesService _ps;
    private readonly FollowsService _fs;
    private readonly AccountService _as;

    public ProfilesController(ProfilesService ps, FollowsService fs, AccountService @as)
    {
      _ps = ps;
      _fs = fs;
      _as = @as;
    }

    [HttpGet]
    public ActionResult<List<Profile>> Get()
    {
      try
      {
        List<Profile> profiles = _ps.Get();
        return Ok(profiles);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Profile>> Get(string id)
    {
      try
      {
        Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
        Profile profile = _ps.Get(id, userInfo?.Id);
        return Ok(profile);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
    [HttpGet("{id}/followers")]
    public ActionResult<List<FollowProfileViewModel>> GetFollowers(string id)
    {
      try
      {
        List<FollowProfileViewModel> followers = _fs.GetFollowersByProfileId(id);
        return Ok(followers);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}