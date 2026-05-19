using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles;


public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, User>();
    }

}