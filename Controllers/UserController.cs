namespace FilmesAPI.Controllers;

using FilmesAPI.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using FilmesAPI.Services;
 
[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController (UserService registerService)
    {
        _userService = registerService;
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> RegisterUser(CreateUserDto createUserDto)
    {
       await _userService.Register(createUserDto);
       return Ok("Usuário cadastrado.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserDto dto)
    {
        await _userService.Login(dto);
        return Ok("Usuário autenticado!");
    }
}

