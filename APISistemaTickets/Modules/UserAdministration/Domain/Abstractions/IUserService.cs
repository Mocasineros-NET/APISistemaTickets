using APISistemaTickets.Modules.UserAdministration.Domain.Entities;

namespace APISistemaTickets.Modules.UserAdministration.Domain.Abstractions;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User GetById(long id);
    IEnumerable<User> GetByRole(Role role);
    void Register(RegisterRequest model);
    void Update(long id, UpdateRequest model);
    void Delete(long id);
    void SetUserRole(long userId, Role role);
}