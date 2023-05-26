using CarRentalz.Business.Dto;
using CarRentalz.Business.Service.Contract;
using CarRentalz.Datas.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Tokens;
using CarRentalz.Utilities.Utilities;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;



namespace CarRentalz.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    private readonly IHttpContextAccessor _httpContextAccessor;

    private readonly IConfiguration _configuration;

    public UserController(IUserService userService, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    {
        _userService = userService;
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp(CreateUserDto newUser)
    {
        UserReadDto userRead = await _userService.createUser(newUser).ConfigureAwait(false);

        var cookieOptions = new CookieOptions
        {
            Expires = DateTime.UtcNow.AddDays(7),
            Path = "/",
            Secure = true,
            SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict,
            HttpOnly = true
        };

        Response.Cookies.Append("_auth", JwtGenerator.GenerateJwtToken(userRead.Id.ToString(), userRead.Email.ToString(), _configuration), cookieOptions);


        return Ok(userRead);
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        IEnumerable<User> users = await _userService.FindAll().ConfigureAwait(false);

        if (users != null)
        {
            return Ok(users);
        }
        else
        {
            return BadRequest("Aucun utilisateurs.");
        }
    }

}