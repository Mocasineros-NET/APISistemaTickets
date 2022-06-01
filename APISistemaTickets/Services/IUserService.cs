using APISistemaTickets.Data.Models.Auth;

namespace APISistemaTickets.Services;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User GetById(long id);
    void Register(RegisterRequest model);
    void Update(long id, UpdateRequest model);
    void Delete(long id);
}