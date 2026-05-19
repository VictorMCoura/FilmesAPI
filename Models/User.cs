
using Microsoft.AspNetCore.Identity;

namespace FilmesAPI.Models;

public class User : IdentityUser
{
    public DateTime BirthDate { get; set; }

    public User() : base() {}
}