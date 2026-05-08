using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos;

public class ReadCinemaDto
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo de nome é obrigatório")]
    public String? Nome { get; set; }

    public ReadEnderecoDto? Endereco {get; set;}
}