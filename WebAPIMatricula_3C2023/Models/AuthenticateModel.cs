using System.ComponentModel.DataAnnotations;

namespace WebAPIMatricula_3C2023.Models;

public class AuthenticateModel
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}
