using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

public class CinemaProfile : Profile
{
    public CinemaProfile()
    {
        //Post
        CreateMap<CreateCinemaDto, Cinema>();
        //Put
        CreateMap<UpdateCinemaDto, Cinema>();
        //Get
        CreateMap<Cinema, ReadCinemaDto>()
        .ForMember(cinemaDto => cinemaDto.Endereco, 
            opt => opt.MapFrom(cinema => cinema.Endereco));
    }
}