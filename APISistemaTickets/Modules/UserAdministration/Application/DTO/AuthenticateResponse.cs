using APISistemaTickets.Modules.UserAdministration.Domain.Entities;

namespace APISistemaTickets.Modules.UserAdministration.Application.DTO;

public class AuthenticateResponse
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public Role Role { get; set; }
    public string Token { get; set; }
    
    public AuthenticateResponse(User user, string token)
    {
        Id = user.Id;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Email = user.Email;
        Username = user.Username;
        Role = user.Role;
        Token = token;
    }

    public AuthenticateResponse()
    {
        
    }
}