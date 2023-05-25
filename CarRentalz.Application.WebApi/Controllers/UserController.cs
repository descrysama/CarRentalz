using CarRentalz.Business.Dto;
using CarRentalz.Business.Service.Contract;
using CarRentalz.Datas.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    private readonly IConfiguration _configuration;

    public UserController(IUserService userService, IConfiguration configuration)
    {
        _userService = userService;
        _configuration = configuration;
    }

    [HttpPost("signup")]
    public async Task<UserReadDto> SignUp(CreateUserDto newUser)
    {
        UserReadDto userRead = await _userService.createUser(newUser).ConfigureAwait(false);

        return userRead;
    }

}