using AutoMapper;
using FilmesApi.Data;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    private FilmeContext _context;
    private IMapper _mapper;

    public EnderecoController(FilmeContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper; 
    }

    [HttpGet]
    public IEnumerable<ReadEnderecoDto> GetEndereco([FromQuery]int skip = 0, [FromQuery]int take = 50)
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.Skip(skip).Take(take)); 
    }

    [HttpGet("{id}")]
    public IActionResult GetEnderecoById([FromBody] int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
        if(endereco == null) return NotFound();
        var enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
        return Ok(enderecoDto);
    }

    [HttpPost]
    public IActionResult PostEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        var endereco = _mapper.Map<Endereco>(enderecoDto);
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetEnderecoById),
        new{id = endereco.Id}, enderecoDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateEndereco(int id, [FromBody]UpdateEnderecoDto enderecoDto)
    {
        var endereco = _context.Enderecos.FirstOrDefault(e => e.Id == id);
        if(endereco == null)return NotFound();
        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();
        return NoContent();
    }
    [HttpDelete("{id}")]
    public IActionResult DeleteEndereco(int id)
    {
        var endereco = _context.Enderecos.FirstOrDefault(e => e.Id== id);
        if(endereco == null) return NotFound();
        _context.Remove(endereco);
        _context.SaveChanges();
        return NoContent();
    }
    
}