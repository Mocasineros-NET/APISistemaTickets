using System.ComponentModel.DataAnnotations;

namespace APISistemaTickets.Data.Models.Auth;

public class AuthenticateRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}