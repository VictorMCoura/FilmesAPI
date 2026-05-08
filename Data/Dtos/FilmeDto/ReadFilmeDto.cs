using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos;

public class ReadFilmeDto{
    
    public String? Titulo { get; set; }
    public String? Genero { get; set; }
    public int Duracao { get; set; }
    public DateTime HoraConsulta { get; set; } = DateTime.Now;

    }
