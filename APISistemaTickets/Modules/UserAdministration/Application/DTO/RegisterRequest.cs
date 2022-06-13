using System.ComponentModel.DataAnnotations;

namespace APISistemaTickets.Modules.UserAdministration.Application.DTO;

public class RegisterRequest
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}