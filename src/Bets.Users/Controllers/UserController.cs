using System;
using Microsoft.AspNetCore.Mvc;
using Bets.Users.Repository;
using Bets.Users.Services;
using Bets.Users.Models;
using Bets.Users.DTO;

namespace Bets.Users.Controllers;

[Route("[controller]")]
public class UserController : Controller
{
    private readonly IUserRepository _repository;
    public UserController(IUserRepository repository)
    {
        _repository = repository;
    }

    [HttpPost("signup")]
    public IActionResult Post([FromBody] User user)
    {
        try
        {
            User newUser = _repository.Post(user);
            string token = new TokenManager().Generate(newUser);
            AuthDTOResponse response = new AuthDTOResponse { Token = token };
            return Created("", response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] AuthDTORequest login)
    {
        try
        {
            User userFound = _repository.Login(login);
            string token = new TokenManager().Generate(userFound);
            AuthDTOResponse response = new AuthDTOResponse { Token = token };
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}