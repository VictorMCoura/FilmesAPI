using Microsoft.AspNetCore.Mvc;
using FilmesApi.Models;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class FilmeController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult PostFilme([FromBody]  CreateFilmeDto filmeDto)
    {   
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetFilmeById),
          new{ id = filme.Id },
          filmeDto);
   }

    [HttpGet]
    public IEnumerable<ReadFilmeDto> GetFilmes([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));
    } 

    [HttpGet("{id}")]
    public IActionResult GetFilmeById(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);
        if (filme == null) return NotFound();
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
            return Ok(filmeDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        if(filmeDto == null) return NotFound();
        var filme =_context.Filmes.FirstOrDefault(f => f.Id == id);
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult PatchFilme(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        var filme =_context.Filmes.FirstOrDefault(f => f.Id == id);
        if(filme == null) return NotFound();

        var filmeToPatch = _mapper.Map<UpdateFilmeDto>(filme);

        patch.ApplyTo(filmeToPatch, ModelState);

        if (!TryValidateModel(filmeToPatch))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeToPatch, filme);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteFilme(int id)
    {
        var filme =_context.Filmes.FirstOrDefault(f => f.Id == id);
        if(filme == null) return NotFound();
        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
       
    }
}
