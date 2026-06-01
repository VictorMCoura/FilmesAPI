using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace FilmesAPI.Services;

public class TokenService
{
    public string GenerateToken(User user)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("username", user.UserName),
            new Claim("id", user.Id),
            new Claim(ClaimTypes.DateOfBirth, user.BirthDate.ToString())
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("APSKDA2312OPDSFJKAPOEJFOSJDF"));

        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            expires: DateTime.Now.AddMinutes(10),
            claims: claims,
            signingCredentials:signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}