using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.Dtos;

public class UpdateFilmeDto{
    
    [Required(ErrorMessage = "O título é obrigatório")]
    public String? Titulo { get; set; }

    [Required(ErrorMessage = "O Gênero é obrigatório")]
    [StringLength(50, ErrorMessage = "texto deve ter no mínimo 50 caractéres")]
    public String? Genero { get; set; }

    [Required(ErrorMessage = "A Duração é obrigatória")]
    [Range(70, 600, ErrorMessage = "A Duração deve ser entre 70 e 600 minutos")]
    public int Duracao { get; set; }
    }

