using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using FilmesAPI.Data;

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
        CreateMap<Cinema, ReadCinemaDto>()
            .ForMember(cinemaDto => cinemaDto.Sessoes, 
                opt => opt.MapFrom(cinema => cinema.Sessoes));
    }
}