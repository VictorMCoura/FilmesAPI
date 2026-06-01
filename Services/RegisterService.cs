namespace FilmesAPI.Services;
using AutoMapper;
using FilmesAPI.Models;
using FilmesAPI.Data.Dtos;
using Microsoft.AspNetCore.Identity;
public class UserService
{
    private IMapper _mapper;
    private UserManager<User> _userManager;
    private SignInManager<User> _singInManager;
    private TokenService _tokenService;

    public UserService(UserManager<User> userManager, IMapper mapper, SignInManager<User> signInManager,
    TokenService tokenService)
    {
        _userManager = userManager;
        _mapper = mapper;
        _singInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task Register(CreateUserDto createUserDto){

        User user = _mapper.Map<User>(createUserDto);
        
        var resultado = await _userManager.CreateAsync(user, createUserDto.Password );

        if(!resultado.Succeeded){
            foreach (var erro in resultado.Errors)
            { 
                Console.WriteLine($"Erro do Identity: {erro.Description}");
            }
            throw new ApplicationException("Falha ao cadastrar usuário.");
        }       
    }

    public async Task<string> Login(LoginUserDto dto)
    {
        var resultado = await _singInManager.PasswordSignInAsync
                (dto.Username, dto.Password, false, false);
                
        if(!resultado.Succeeded){
            throw new ApplicationException("Usuário não autenticado.");
        }
        var user = _singInManager.UserManager.Users.FirstOrDefault(user=> user.NormalizedUserName == dto.Username.ToUpper());

        var token =_tokenService.GenerateToken(user);

        return token;
    }
}