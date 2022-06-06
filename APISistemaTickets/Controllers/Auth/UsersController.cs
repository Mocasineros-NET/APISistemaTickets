using APISistemaTickets.Authorization;
using APISistemaTickets.Data.Models.Auth;
using APISistemaTickets.Data.Models.DTO.App;
using APISistemaTickets.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace APISistemaTickets.Controllers.Auth;


[Authorize]
[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest model)
    {
        _userService.Register(model);
        return Ok(new {message = "Registration successful"});
    }

    [AllowAnonymous]
    [HttpPost("[action]")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);
        return Ok(response);
    }

    [Authorize(Role.Admin)]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }

    [Authorize(Role.Admin, Role.Manager)]
    [HttpGet("[action]")]
    public IActionResult GetAllEngineers()
    {
        var users = _userService.GetAll().Where(u => u.Role == Role.Engineer);
        return Ok(users);
    }

    [Authorize(Role.Admin, Role.Manager)]
    [HttpPost("SetUserRole/{userId}")]
    public IActionResult SetUserRole(long userId, RoleDTO role)
    {
        _userService.SetUserRole(userId, (Role) role.RoleId);
        return Ok();
    }
    
    
    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateRequest model)
    {
        _userService.Update(id, model);
        return Ok(new { message = "User updated successfully" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _userService.Delete(id);
        return Ok(new { message = "User deleted successfully" });
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById(int id)
    {
        // only admins can access other user records
        var currentUser = (User)HttpContext.Items["User"];
        if (id != currentUser.Id && currentUser.Role != Role.Admin)
            return Unauthorized(new { message = "Unauthorized" });

        var user =  _userService.GetById(id);
        return Ok(user);
    }
}