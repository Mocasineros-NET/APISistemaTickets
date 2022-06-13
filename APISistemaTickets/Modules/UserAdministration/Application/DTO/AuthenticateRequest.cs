using System.ComponentModel.DataAnnotations;

namespace APISistemaTickets.Modules.UserAdministration.Application.DTO;

public class AuthenticateRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}