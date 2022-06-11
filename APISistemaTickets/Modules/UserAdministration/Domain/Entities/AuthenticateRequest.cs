using System.ComponentModel.DataAnnotations;

namespace APISistemaTickets.Modules.UserAdministration.Domain.Entities;

public class AuthenticateRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}