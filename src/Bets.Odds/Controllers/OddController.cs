using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using Bets.Odds.Repository;

namespace Bets.Odds.Controllers;

[Route("[controller]")]
public class OddController : Controller
{
    private readonly IOddRepository _repository;
    public OddController(IOddRepository repository)
    {
        _repository = repository;
    }

    [HttpPatch("{MatchId:int}/{TeamId:int}/{BetValue}")]

    public IActionResult Patch(int MatchId, int TeamId, string BetValue)
    {
        try
        {
            var response = _repository.Patch(MatchId, TeamId, BetValue);
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }
        catch
        {
            return BadRequest();
        }
    }
}
