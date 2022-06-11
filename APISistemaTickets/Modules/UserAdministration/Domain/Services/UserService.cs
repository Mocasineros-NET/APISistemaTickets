using APISistemaTickets.Modules.Authorization;
using APISistemaTickets.Modules.Helpers;
using APISistemaTickets.Modules.UserAdministration.Domain.Abstractions;
using APISistemaTickets.Modules.UserAdministration.Domain.Entities;
using AutoMapper;

namespace APISistemaTickets.Modules.UserAdministration.Domain.Services;

public class UserService : IUserService
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;

    public UserService(
        DataContext context,
        IJwtUtils jwtUtils,
        IMapper mapper)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);

        // validate
        if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            throw new AppException("Username or password is incorrect");

        // authentication successful
        var response = _mapper.Map<AuthenticateResponse>(user);
        response.Token = _jwtUtils.GenerateJwtToken(user);
        return response;
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }

    public User GetById(long id)
    {
        return GetUser(id);
    }

    public IEnumerable<User> GetByRole(Role role)
    {
        return _context.Users.Where(u => u.Role == role);
    }

    public void Register(RegisterRequest model)
    {
        // validate
        if (_context.Users.Any(x => x.Username == model.Username))
            throw new AppException("Username '" + model.Username + "' is already taken");

        // map model to new user object
        var user = _mapper.Map<User>(model);

        // hash password
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

        // save user
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void Update(long id, UpdateRequest model)
    {
        var user = GetUser(id);

        // validate
        if (model.Username != user.Username && _context.Users.Any(x => x.Username == model.Username))
            throw new AppException("Username '" + model.Username + "' is already taken");

        // hash password if it was entered
        if (!string.IsNullOrEmpty(model.Password))
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

        // copy model to user and save
        _mapper.Map(model, user);
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public void Delete(long id)
    {
        var user = GetUser(id);
        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    public void SetUserRole(long userId, Role role)
    {
        var user = GetUser(userId);
        user.Role = role;
        _context.Users.Update(user);
        _context.SaveChanges();
    }

    // helper methods

    private User GetUser(long id)
    {
        var user = _context.Users.Find(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }
}