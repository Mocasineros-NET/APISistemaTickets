namespace APISistemaTickets.Modules.UserAdministration.Domain.Entities;

public class UpdateRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}