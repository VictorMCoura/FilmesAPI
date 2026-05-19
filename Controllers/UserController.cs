using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    private readonly IMapper _mapper;

    public UserController (IMapper mapper)
    {
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult RegisterUser(CreateUserDto createUserDto)
    {
        User user = _mapper.Map<User>(createUserDto);
        
    }
}