using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace APISistemaTickets.Data.Models.Auth;

public class User
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public Role Role { get; set; }
    [JsonIgnore]
    public string PasswordHash { get; set; }
}