using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesApi.Data;
using Microsoft.AspNetCore.Mvc;
using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CinemaController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public CinemaController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult CinemaPost([FromBody] CreateCinemaDto cinemaDto)
    {
        Cinema cinema = _mapper.Map<Cinema>(cinemaDto);
        _context.Cinemas.Add(cinema);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetCinemaById),
        new {id = cinema.Id}, cinemaDto);
    }

    [HttpGet]
    public IEnumerable<ReadCinemaDto> GetCinemas([FromQuery] int? enderecoId = null)
    {
        if(enderecoId == null)
        {
        return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas.ToList());
        }
        return _mapper.Map<List<ReadCinemaDto>>(_context.Cinemas
                .FromSqlRaw($"SELECT Id, Nome, EnderecoId FROM cinemas" + 
                "WHERE cinemas.EnderecoId = {enderecoId}").ToList());
    }


    [HttpGet("{id}")]
    public IActionResult GetCinemaById(int id)
    {
        Cinema? cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
        if(cinema != null)
        {
            ReadCinemaDto cinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
            return Ok(cinemaDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
    { 
        var cinema = _context.Cinemas.FirstOrDefault(c => c.Id == id);
        if(cinema == null) return NotFound();
        _mapper.Map(cinemaDto, cinema);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCinema(int id)
    {
        var cinema = _context.Cinemas.FirstOrDefault(c =>c.Id == id);
        if(cinema == null)return NotFound();
        _context.Remove(cinema);
        _context.SaveChanges();
        return NoContent();
    }
}