using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Recipe
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public string Title { get; set; }

    public string Category { get; set; }
    public string Instructions { get; set; }
    public int PreparationTime { get; set; }

    // Relação com o Usuário
    [Required]
    public string UserId { get; set; }
    public virtual User User { get; set; }
}